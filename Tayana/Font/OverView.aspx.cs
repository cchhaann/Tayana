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
using Tayana.Back;

namespace Tayana.Font
{
    public partial class OverView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetYachartsID();
                LoadLeftMenu();
                YachartsLink();
                LoadTopMenu();
                LoadContent();
            }
            //取得網址傳值的 id 內容
            string urlIDStr = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            if (Page.RouteData.Values.Count > 0)
            {
                string urlYachartsStr = Page.RouteData.Values["shortUrl"].ToString();
                string sqlID = "SELECT id FROM YachartsInfo WHERE id = @urlYachartsStr";
                SqlCommand commandID = new SqlCommand(sqlID, connection);
                commandID.Parameters.AddWithValue("@urlYachartsStr", urlYachartsStr);
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
        private void GetYachartsID()
        {
            string urlIDStr = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            //如果是用短網址連入則用短網址 shortUrl 參數內容的國家名稱來判斷 ID
            if (Page.RouteData.Values.Count > 0)
            {
                string urlYachartsStr = Page.RouteData.Values["shortUrl"].ToString();
                string sqlID = "SELECT id FROM YachartsInfo WHERE id = @urlYachartsStr";
                SqlCommand commandID = new SqlCommand(sqlID, connection);
                commandID.Parameters.AddWithValue("@urlYachartsStr", urlYachartsStr);
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
            List<RowData> saveRowList = new List<RowData>();
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
                TopMenuHtml.Append($"<li><a class='menu_yli01' href='OverView.aspx?id={YachartsIDStr}' >OverView</a></li>");
                TopMenuHtml.Append($"<li><a class='menu_yli02' href='Yachts_Layout.aspx?id={YachartsIDStr}' >Layout & deck plan</a></li>");
                TopMenuHtml.Append($"<li><a class='menu_yli03' href='Yachts_Specification.aspx?id={YachartsIDStr}' >Specification</a></li>");

                saveRowList = JsonConvert.DeserializeObject<List<RowData>>(loadJson);
                if (!String.IsNullOrEmpty(saveRowList[0].SaveValue))
                {
                    TopMenuHtml.Append($"<li><a class='menu_yli04' href='Yachts_Video.aspx?id={YachartsIDStr}' >Video</a></li>");
                }
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
            string sql = "SELECT YachtsModel FROM YachartsInfo WHERE id = @NewsIDStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string NewsStr = reader["YachtsModel"].ToString();
                LabLink.InnerText = NewsStr;
                LabTittle.InnerText = NewsStr;
            }
            connection.Close();

            //依 Newsy id 取得資料 WHERE id = @NewsIDStr
            StringBuilder NewsDetailsHtml = new StringBuilder();
            string sqlNews = "SELECT ID,YachtsModel,YachtsContent,DimensionsName FROM YachartsInfo Where id = @NewsIDStr";
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
                NewsDetailsHtml.Append($"<div class='box1'>" + $"<p>{contentStr}</p><br/>"+ "</div>");
                NewsDetailsHtml.Append($"<div class='box3'><h4><span>{DimensionsNameStr}</span></h4></div>");

            }
            connection.Close();
            ContentLiteral.Text = NewsDetailsHtml.ToString();
        }
    }
}

public class RowData
{
    public string SaveItem { get; set; }
    public string SaveValue { get; set; }
}