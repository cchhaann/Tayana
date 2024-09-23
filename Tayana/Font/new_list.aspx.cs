using NetVips;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Razor.Tokenizer;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tayana.Back;

namespace Tayana.Font
{
    public partial class new_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNewsID();
                //LoadNewsList();
                LoadNewsPageList();

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


        //private void LoadNewsList()
        //{
        ////    //取得 Session 儲存 id，Session 物件需轉回字串
        ////    string NewsIDStr = Session["ID"].ToString();
        ////    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
        ////    string sql = "SELECT NewsSort FROM News WHERE id = @NewsIDStr";
        ////    SqlCommand command = new SqlCommand(sql, connection);
        ////    command.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
        ////    connection.Open();

        ////    SqlDataReader reader = command.ExecuteReader();
        ////    if (reader.Read())
        ////    {
        ////        string NewsStr = reader["NewsSort"].ToString();
        ////        LabLink.InnerText = NewsStr;
        ////        LabTittle.InnerText = NewsStr;
        ////    }
        ////    connection.Close();

        ////    //依 Newsy id 取得資料 WHERE id = @NewsIDStr
        ////    StringBuilder NewsListHtml = new StringBuilder();
        ////    string sqlNews = "SELECT ID,NewsDate,NewsTittle,NewsThumbnail FROM News ";
        ////    SqlCommand commandArea = new SqlCommand(sqlNews, connection);
        ////    commandArea.Parameters.AddWithValue("@NewsIDStr", NewsIDStr);
        ////    connection.Open();
        ////    SqlDataReader readerNews = commandArea.ExecuteReader();
        ////    while (readerNews.Read())
        ////    {
        ////        string idStr = readerNews["id"].ToString();
        ////        string DateStr;
        ////        if (!readerNews.IsDBNull(readerNews.GetOrdinal("NewsDate")) && !string.IsNullOrEmpty(readerNews["NewsDate"].ToString()))
        ////        {
        ////            // NewsDate 不為空,擷取前 10 個字元作為日期字串
        ////            DateStr = readerNews["NewsDate"].ToString().Substring(0, 10);
        ////        }
        ////        else
        ////        {
        ////            // NewsDate 為空,設置 newsDateStr 為空字串
        ////            DateStr = string.Empty;
        ////        }



        ////        string NewsStr = readerNews["NewsTittle"].ToString();
        ////        string newsLink = $"<a href='NewsDetails.aspx?id={idStr}'>{NewsStr}</a>";
        ////        string imgPathStr = readerNews["NewsThumbnail"].ToString();
        ////        NewsListHtml.Append("<li><div class='list02'><ul><li class='list02li'><div>" +
        ////        $"<p><img id='Image{idStr}' src='../images/{imgPathStr}' style='border-width:0px;' Width='209px' /> </p></div></li>" +
        ////        $"<li class='list02li02'> <span>{DateStr}</span><br />{newsLink}");
        ////        NewsListHtml.Append("</li></ul></div></li>");
        ////    }
        ////    connection.Close();
        ////    NewsLiteral.Text = NewsListHtml.ToString();
        //}

        private void LoadNewsPageList()
        {
            //預設為第1頁
            int page = 1;
            //判斷網址後有無參數
            //也可用String.IsNullOrWhiteSpace
            if (!String.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }
            //設定頁面參數屬性
            //設定控制項參數: 一頁幾筆資料
            WebUserControl_Page.limit = 5;
            //設定控制項參數: 作用頁面完整網頁名稱
            WebUserControl_Page.targetPage = "new_list.aspx";
            //建立計算分頁資料顯示邏輯 (每一頁是從第幾筆開始到第幾筆結束)
            //計算每個分頁的第幾筆到第幾筆
            var floor = (page - 1) * WebUserControl_Page.limit + 1; //每頁的第一筆
            var ceiling = page * WebUserControl_Page.limit; //每頁的最末筆

            //5.建立計算資料筆數的 SQL 語法，算出我們要秀的資料數
            string sql_countTotal = $"SELECT CEILING(CAST(COUNT(id) AS FLOAT) / 5) AS TotalPages FROM News";


            //將取得的資料數設定給參數 count
            DBHelper dB = new DBHelper();
            string sql = $"SELECT COUNT(id) FROM News";   // 建立 SQL語句
            SqlDataReader rd = dB.SearchDB(sql);
            int count = 0; // 初始化計數

            if (rd.Read()) // 讀取查詢結果
            {
                count = Convert.ToInt32(rd[0]); // 將查詢結果轉換為整數
            }
            //設定控制項參數: 總共幾筆資料
            WebUserControl_Page.totalItems = count;
            //渲染分頁控制項
            WebUserControl_Page.ShowPageControls();

            // 處理完總資料數後，重新定位 SqlDataReader 
            rd.Close();
            string sql2 = $"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) AS rowindex, * FROM News) AS temp WHERE rowindex BETWEEN {floor} AND {ceiling}";
            rd = dB.SearchDB(sql2);
            //設定模擬資料內容
            StringBuilder listHtml = new StringBuilder();
            while (rd.Read())
            {
                string idStr = rd["id"].ToString();
                string DateStr;
                if (!rd.IsDBNull(rd.GetOrdinal("NewsDate")) && !string.IsNullOrEmpty(rd["NewsDate"].ToString()))
                {
                    // NewsDate 不為空,擷取前 10 個字元作為日期字串
                    DateStr = rd["NewsDate"].ToString().Substring(0, 10);
                }
                else
                {
                    // NewsDate 為空,設置 newsDateStr 為空字串
                    DateStr = string.Empty;
                }
                string NewsStr = rd["NewsTittle"].ToString();
                string newsLink = $"<a href='NewsDetails.aspx?id={idStr}'>{NewsStr}</a>";
                string thumbnailPathStr = rd["NewsThumbnail"].ToString();
                string isTopStr = rd["isTop"].ToString();

                string displayStr = "none";
                if (isTopStr.Equals("True"))
                {
                    displayStr = "inline-block";
                }
                listHtml.Append("<li><div class='list02'><ul><li class='list02li'><div>" +
                     $"<img src='../images/new_top01.png' alt='&quot;&quot;' style='display: {displayStr};position: absolute;z-index: 5;'/>" +
                    $"<p><img id='Image{idStr}' src='../images/{thumbnailPathStr}' style='border-width:0px;' Width='209px' /> </p></div></li>" +
                    $"<li class='list02li02'> <span>{DateStr}</span><br />{newsLink}");
                listHtml.Append("</li></ul></div></li>");
            }
            dB.CloseDB();

            //渲染新聞列表
            NewsLiteral.Text = listHtml.ToString();
        }
    }

}
