using CKFinder.Settings;
using NetVips;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Tayana.Font.company;

namespace Tayana.Font
{
    public partial class Yacht : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNewsID();
                LoadLeftMenu();
                YachartsLink();
                LoadTopMenu();
                LoadContent();
                LoadGallery();
            }
            string urlIDStr = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            if (Page.RouteData.Values.Count > 0)
            {
                string urlCountryStr = Page.RouteData.Values["shortUrl"].ToString();
                string sqlID = "SELECT id FROM YachartsInfo WHERE id = @urlCountryStr";
                SqlCommand commandID = new SqlCommand(sqlID, connection);
                commandID.Parameters.AddWithValue("@urlCountryStr", urlCountryStr);
                connection.Open();
                SqlDataReader readerID = commandID.ExecuteReader();
                if (readerID.Read())
                {
                    urlIDStr = readerID["id"].ToString();
                }
                connection.Close();
            }
            //如無網址傳值則設為第一筆國家名稱 id
            if (string.IsNullOrEmpty(urlIDStr))
            {
                string sql = "SELECT TOP 1 id FROM YachartsInfo";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    urlIDStr = reader["id"].ToString();
                }
                connection.Close();
            }
            //將 id 存入 Session 使用
            Session["id"] = urlIDStr;

        }
        private void GetNewsID()
        {
            //取得網址傳值的 id 內容
            string urlIDStr = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            //如果是用短網址連入則用短網址 shortUrl 參數內容的國家名稱來判斷 ID
            if (Page.RouteData.Values.Count > 0)
            {
                //取得短網址參數內容的國家名稱
                string urlCountryStr = Page.RouteData.Values["shortUrl"].ToString();
                string sqlID = "SELECT id FROM YachartsInfo WHERE id = @urlCountryStr";
                SqlCommand commandID = new SqlCommand(sqlID, connection);
                commandID.Parameters.AddWithValue("@urlCountryStr", urlCountryStr);
                connection.Open();
                SqlDataReader readerID = commandID.ExecuteReader();
                if (readerID.Read())
                {
                    urlIDStr = readerID["id"].ToString();
                }
                connection.Close();
            }
            //如無網址傳值則設為第一筆國家名稱 id
            if (string.IsNullOrEmpty(urlIDStr))
            {
                string sql = "SELECT TOP 1 id FROM YachartsInfo";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    urlIDStr = reader["id"].ToString();
                }
                connection.Close();
            }

            //將 id 存入 Session 使用
            Session["id"] = urlIDStr;

        }

        private void LoadLeftMenu()
        {
            //反覆變更字串的值建議用 StringBuilder 效能較好
            StringBuilder leftMenuHtml = new StringBuilder();
            //取得國家分類
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sqlCountry = "SELECT * FROM YachartsInfo";
            SqlCommand commandCountry = new SqlCommand(sqlCountry, connection);
            connection.Open();
            SqlDataReader readerCountry = commandCountry.ExecuteReader();

            while (readerCountry.Read())
            {
                string idStr = readerCountry["ID"].ToString();
                string countryStr = readerCountry["YachtsModel"].ToString();
                string isNewDesignStr = readerCountry["isNewDesign"].ToString();
                string isNewBuildingStr = readerCountry["isNewBuilding"].ToString();
                string isNewStr = "";
                //依是否為新建或新設計加入標註
                if (isNewDesignStr.Equals("True"))
                {
                    isNewStr = "(New Design)";
                }
                else if (isNewBuildingStr.Equals("True"))
                {
                    isNewStr = "(New Building)";
                }
                // StringBuilder 用 Append 加入字串內容
                leftMenuHtml.Append($"<li><a href='Yacht.aspx?id={idStr}'> {countryStr}{isNewStr} </a></li>");
            }
            connection.Close();
            //渲染畫面
            LeftMenu.Text = leftMenuHtml.ToString();
        }
        private void YachartsLink()
        {
            string YachartsIDStr = Session["ID"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "SELECT * FROM YachartsInfo WHERE id = @YachartsIDStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@YachartsIDStr", YachartsIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string countryStr = reader["YachtsModel"].ToString();
                LabLink.InnerText = countryStr;
                LabTittle.InnerText = countryStr;
            }
            connection.Close();
        }

        private void LoadTopMenu()
        {

            string YachartsIDStr = Session["ID"].ToString();
            //List<RowData> saveRowList = new List<RowData>();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "SELECT * FROM YachartsInfo WHERE id = @YachartsIDStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@YachartsIDStr", YachartsIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder TopMenuHtml = new StringBuilder();
            while (reader.Read())
            {
                string yachtModelStr = reader["YachtsModel"].ToString();
                string contentStr = reader["YachtsContent"].ToString();
                string loadJson = reader["BannerImgPathJSON"].ToString();
                //加入渲染型號內容上方分類連結列表
                TopMenuHtml.Append($"<li><a class='menu_yli01' href='Yacht.aspx?id={YachartsIDStr}' >OverView</a></li>");
                TopMenuHtml.Append($"<li><a class='menu_yli02' href='Yachts_Layout.aspx?id={YachartsIDStr}' >Layout & deck plan</a></li>");
                TopMenuHtml.Append($"<li><a class='menu_yli03' href='Yachts_Specification.aspx?id={YachartsIDStr}' >Specification</a></li>");


                LabLink.InnerText = yachtModelStr;
                LabTittle.InnerText = yachtModelStr;
                TopMenuLink.Text = TopMenuHtml.ToString();
            }
            connection.Close();
        }
        private void LoadContent()
        {
            //取得 Session 儲存 id，Session 物件需轉回字串
            string NewsIDStr = Session["ID"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "SELECT YachtsModel,isNewDesign,isNewBuilding FROM YachartsInfo WHERE id = @NewsIDStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string NewsStr = reader["YachtsModel"].ToString();
                string NewDesignStr = reader["isNewDesign"].ToString();
                string NewBuildingStr = reader["isNewBuilding"].ToString();
                string NewStr = "";
                //依是否為新建或新設計加入標註
                if (NewDesignStr.Equals("True"))
                {
                    NewStr = "(New Design)";
                }
                else if (NewBuildingStr.Equals("True"))
                {
                    NewStr = "(New Building)";
                }

                LabLink.InnerText = NewsStr;
                LabTittle.InnerText = NewsStr + NewStr;
            }
            connection.Close();

            //依 Newsy id 取得資料 WHERE id = @NewsIDStr ID,YachtsModel,YachtsContent,DimensionsName,HullLength,ImgPath,LWL,BMAX,StandardDraft,Ballast,
            StringBuilder NewsDetailsHtml = new StringBuilder();
            string sqlNews = "SELECT * FROM YachartsInfo Where id = @NewsIDStr";
            SqlCommand commandArea = new SqlCommand(sqlNews, connection);
            commandArea.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
            connection.Open();
            SqlDataReader readerNews = commandArea.ExecuteReader();
            while (readerNews.Read())
            {
                string idStr = readerNews["id"].ToString();
                string NewsStr = readerNews["YachtsModel"].ToString();
                string contentStr = readerNews["YachtsContent"].ToString();
                string DimensionsNameStr = readerNews["DimensionsName"].ToString();
                string HullLengthStr = readerNews["HullLength"].ToString();
                string ImgPathStr = readerNews["ImgPath"].ToString();
                string LWLStr = readerNews["LWL"].ToString();
                string BMAXStr = readerNews["BMAX"].ToString();
                string DraftSrr = readerNews["Draft"].ToString();
                string HeadStr = readerNews["HeadRoom"].ToString();
                string StandardStr = readerNews["StandardDraft"].ToString();
                string BallastStr = readerNews["Ballast"].ToString();
                string DisplacementStr = readerNews["Displacement"].ToString();
                string EngineDieselStr = readerNews["EngineDiesel"].ToString();
                string SailAreaStr = readerNews["SailArea"].ToString();
                string CutterStr = readerNews["Cutter"].ToString();
                string DesignerStr = readerNews["Designer"].ToString();
                string OverallStr = readerNews["Overall"].ToString();
                string WaterlineStr = readerNews["Waterline"].ToString();
                string BeamStr = readerNews["Beam"].ToString();
                string LightshipStr = readerNews["lightship"].ToString();
                string ShallowStr = readerNews["Shallow"].ToString();
                string DRAFT44Str = readerNews["DRAFT44"].ToString();
                string DraOptionStr = readerNews["DraOption"].ToString();

                string DownloadsFileNameStr = readerNews["DownloadsFileName"].ToString();
                string DownloadsFileStr = readerNews["DownloadsFile"].ToString();
                NewsDetailsHtml.Append($"<div class='box1'>" + $"<p>{contentStr}</p><br/>");
                NewsDetailsHtml.Append($"<div class='box3'><h4><span>{DimensionsNameStr}</span></h4></div>");
                NewsDetailsHtml.Append($"<table class=table02><tbody><tr><td class=table02td01><table><tbody>");
                if (!string.IsNullOrEmpty(HullLengthStr))
                    NewsDetailsHtml.Append($"<tr><th>Hull length</th><td>{HullLengthStr}</td></tr>");

                if (!string.IsNullOrEmpty(LWLStr))
                    NewsDetailsHtml.Append($"<tr><th>L.W.L.</th><td>{LWLStr}</td></tr>");

                if (!string.IsNullOrEmpty(BMAXStr))
                    NewsDetailsHtml.Append($"<tr><th>B. MAX</th><td>{BMAXStr}</td></tr>");

                if (!string.IsNullOrEmpty(DraOptionStr))
                    NewsDetailsHtml.Append($"<tr><th>Draft shoal(option)</th><td>{DraOptionStr}</td></tr>");

                if (!string.IsNullOrEmpty(DraftSrr))
                    NewsDetailsHtml.Append($"<tr><th>Draft</th><td>{DraftSrr}</td></tr>");

                if (!string.IsNullOrEmpty(HeadStr))
                    NewsDetailsHtml.Append($"<tr><th>Head room</th><td>{HeadStr}</td></tr>");

                if (!string.IsNullOrEmpty(StandardStr))
                    NewsDetailsHtml.Append($"<tr><th>Standard draft</th><td>{StandardStr}</td></tr>");

                if (!string.IsNullOrEmpty(BallastStr))
                    NewsDetailsHtml.Append($"<tr><th>Ballast</th><td>{BallastStr}</td></tr>");

                if (!string.IsNullOrEmpty(DisplacementStr))
                    NewsDetailsHtml.Append($"<tr><th>Displacement</th><td>{DisplacementStr}</td></tr>");

                if (!string.IsNullOrEmpty(EngineDieselStr))
                    NewsDetailsHtml.Append($"<tr><th>Engine diesel</th><td>{EngineDieselStr}</td></tr>");

                if (!string.IsNullOrEmpty(SailAreaStr))
                    NewsDetailsHtml.Append($"<tr><th>Sail area</th><td>{SailAreaStr}</td></tr>");

                if (!string.IsNullOrEmpty(CutterStr))
                    NewsDetailsHtml.Append($"<tr><th>Cutter</th><td>{CutterStr}</td></tr>");

                if (!string.IsNullOrEmpty(DesignerStr))
                    NewsDetailsHtml.Append($"<tr><th>Designer</th><td>{DesignerStr}</td></tr>");

                NewsDetailsHtml.Append($"</tbody></table></td>");

                if (string.IsNullOrEmpty(ImgPathStr))
                {
                    //NewsDetailsHtml.Append($"<table border='1' cellpadding='1' cellspacing='1' class='table02' style='width: 500px'><tbody><tr><td style='text-align: center'><stong>LENGTH OVERALL</stong></td></tr></tbody></table>");


                    NewsDetailsHtml.Append($"<table border='1' cellpadding='1' cellspacing='1' style='width: 500px' class='table02'><tbody>");

                    NewsDetailsHtml.Append($"<tr><td style='text-align: center'><strong>LENGTH OVERALL</strong></td>");
                    NewsDetailsHtml.Append($"<td style='text-align: center'>{OverallStr}</td>" + $"<td style='text-align: center'>43'-5</td></tr>");
                    NewsDetailsHtml.Append($"<tr><td style='text-align: center'><strong>LENGTH WATERLINE</strong></td>");
                    NewsDetailsHtml.Append($"<td style='text-align: center'>{WaterlineStr}</td>" + $"<td style='text-align: center'>40'-11</td></tr>");
                    NewsDetailsHtml.Append($"<tr><td style='text-align: center'><strong>BEAM MAX</strong></td>");
                    NewsDetailsHtml.Append($"<td style='text-align: center'>{BeamStr}</td>" + $"<td style='text-align: center'>13'-9</td></tr>");
                    NewsDetailsHtml.Append($"<tr><td style='text-align: center'><strong>LIGHTSHIP DISPLACEMENT</strong></td>");
                    NewsDetailsHtml.Append($"<td style='text-align: center'>{LightshipStr}</td>" + $"<td style='text-align: center'>30,800 lbs</td></tr>");
                    NewsDetailsHtml.Append($"<tr><td style='text-align: center'><strong>DRAFT</strong></td>");
                    NewsDetailsHtml.Append($"<td style='text-align: center'>{DRAFT44Str}</td>" + $"<td style='text-align: center'>6'-6</td></tr>");
                    NewsDetailsHtml.Append($"<tr><td style='text-align: center'><strong>SHALLOW DRAFT KEEL</strong></td>");
                    NewsDetailsHtml.Append($"<td style='text-align: center'>{ShallowStr}</td>" + $"<td style='text-align: center'>5'-3</td></tr>");
                    NewsDetailsHtml.Append("</tbody></table>");
                }

                else
                {
                    NewsDetailsHtml.Append($"<td><img id='Image{NewsStr}' src='../Back/{ImgPathStr}' style='width: 278px; height: 345px' /></td>");
                }

                NewsDetailsHtml.Append($"</tr></tbody></table>");




                NewsDetailsHtml.Append($"<p>&nbsp;</p>");
                DownloadsLiteral.Text += $"<a id='HyperLink1' href='../Back/upload/files/{DownloadsFileStr}' target='blank' >{DownloadsFileNameStr}</a></div>";
            }
            connection.Close();
            ContentLiteral.Text = NewsDetailsHtml.ToString();

        }
        private void LoadGallery()
        {
            List<string> imageUrls = new List<string>();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string NewsIDStr = Session["ID"].ToString();
            string sql = "SELECT BannerImgPathJSON FROM YachartsInfo WHERE id = @NewsIDStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string loadJson = reader["BannerImgPathJSON"].ToString();
                List<ImageYPath> savePathYList = JsonConvert.DeserializeObject<List<ImageYPath>>(loadJson);
                foreach (var item in savePathYList)
                {
                    imageUrls.Add($"../Back/upload/Images/{item.SaveYachts}");
                }
            }

            connection.Close();

            RepeaterImg.DataSource = imageUrls;
            RepeaterImg.DataBind();
        }
    }
}
//型號輪播圖片 JSON 資料
public class ImageYPath
{
    public string SaveYachts { get; set; }
}