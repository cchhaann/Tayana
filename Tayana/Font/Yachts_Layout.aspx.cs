using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Font
{
    public partial class Yachts_Layout_aspx : System.Web.UI.Page
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
            string sql = "SELECT Layout.YachtsModelID,YachartsInfo.YachtsModel,Layout.LayoutImgPathJSON FROM Layout JOIN YachartsInfo ON YachartsInfo.ID = Layout.YachtsModelID WHERE YachartsInfo.ID = @NewsIDStr"; 
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder layoutHtmlStr = new StringBuilder();

            if (reader.Read())
            {
                string imgsPathStr = reader["LayoutImgPathJSON"].ToString();
                if (!string.IsNullOrEmpty(imgsPathStr)) 
                {
                    // 反序列化JSON字串為物件陣列
                    var imgs = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(imgsPathStr);
                    foreach (var item in imgs)
                    {
                        string imgFileName = item["saveLayoutList"];
                        layoutHtmlStr.Append($"<li><img src='../Back/upload/Images/{imgFileName}' alt='layout' Width='670px' /></li>");
                        //渲染畫面
                        Literal1.Text = layoutHtmlStr.ToString();
                    }
                }

                
            }
            connection.Close();

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
//頁面組圖 JSON 資料
public class LayoutPath
{
    public string SavePath { get; set; }
}