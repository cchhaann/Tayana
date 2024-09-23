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
    public partial class NewsDetails1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNewsID();
                LoadNewsDetails();
            }
            //取得網址傳值的 id 內容
            string urlIDStr = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            if (Page.RouteData.Values.Count > 0)
            {
                string urlCountryStr = Page.RouteData.Values["shortUrl"].ToString();
                string sqlID = "SELECT id FROM News WHERE id = @urlCountryStr";
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
                string sql = "SELECT TOP 1 id FROM News";
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
                string sqlID = "SELECT id FROM News WHERE id = @urlCountryStr";
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
                string sql = "SELECT TOP 1 id FROM News";
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

        private void LoadNewsDetails()
        {
            //取得 Session 儲存 id，Session 物件需轉回字串
            string NewsIDStr = Session["ID"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "SELECT NewsSort FROM News WHERE id = @NewsIDStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string NewsStr = reader["NewsSort"].ToString();
                LabLink.InnerText = NewsStr;
                LabTittle.InnerText = NewsStr;
            }
            connection.Close();

            //依 Newsy id 取得資料 WHERE id = @NewsIDStr
            StringBuilder NewsDetailsHtml = new StringBuilder();
            string sqlNews = "SELECT ID,NewsTittle,NewsContent,NewsImage FROM News Where id = @NewsIDStr";
            SqlCommand commandArea = new SqlCommand(sqlNews, connection);
            commandArea.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
            connection.Open();
            SqlDataReader readerNews = commandArea.ExecuteReader();
            while (readerNews.Read())
            {
                string idStr = readerNews["id"].ToString();
                string NewsStr = readerNews["NewsTittle"].ToString();
                string contentStr = readerNews["NewsContent"].ToString();
                string imgsPathStr = readerNews["NewsImage"].ToString();
                NewsDetailsHtml.Append($"<div class='box3'><h4><span>{NewsStr}</span></h4></div>" + $"<p>{contentStr}</p><br/>");

                if (!string.IsNullOrEmpty(imgsPathStr))
                {
                    // 反序列化JSON字串為物件陣列
                    var imgObjects = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(imgsPathStr );

                    // 遍歷物件陣列,取出圖片檔案名稱並呈現
                    foreach (var imgObject in imgObjects)
                    {
                        string imgFileName = imgObject["SaveNews"];
                        NewsDetailsHtml.Append($"<p><img src='../images/{imgFileName}' /></p>");
                    }
                }

            }
            connection.Close();
            NewsDetailsLiteral.Text = NewsDetailsHtml.ToString();
        }

    }
}