using CKEditor.NET;
using CKFinder;
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
    public partial class company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetInfoID();
                LoadLeftMenu();
                CompanyLink();
                LoadcertificatContent();
                LoadContentImg();
                LoadAbout();

            }

        }
        private void GetInfoID()
        {
            //取得網址傳值的 id 內容
            string urlIDStr = Request.QueryString["id"];
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            //如果是用短網址連入則用短網址 shortUrl 參數內容的國家名稱來判斷 ID
            if (Page.RouteData.Values.Count > 0)
            {
                //取得短網址參數內容的國家名稱
                string urlCountryStr = Page.RouteData.Values["shortUrl"].ToString();
                string sqlID = "SELECT id FROM Company WHERE Tittle = @urlCountryStr";
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
                string sql = "SELECT TOP 1 id FROM Company";
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

        //  右上路徑
        private void CompanyLink() 
        {
            string countryIDStr = Session["ID"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "SELECT * FROM Company WHERE id = @countryIDStr";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@countryIDStr", countryIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string countryStr = reader["Tittle"].ToString();
                LabLink.InnerText = countryStr;
                LabTittle.InnerText = countryStr;
            }
            connection.Close();
          
        }

        //CertificatContent
        private void LoadcertificatContent()
        {
            string countryIDStr = Session["ID"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sqlCountry = "select Company.Tittle,CompanyCertificat.CertificatContent from CompanyCertificat join Company on Company.ID = CompanyCertificat.CompanySortID WHERE Company.ID = @countryIDStr";
            SqlCommand command = new SqlCommand(sqlCountry, connection);
            command.Parameters.AddWithValue("@countryIDStr", countryIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                CertificatContent.Text = reader["certificatContent"].ToString();
            }
            connection.Close();
        }

        //LoadContentImgV
        private void LoadContentImg()
        {
            //會重複添加內容所以用 StringBuilder 效能較好
            StringBuilder ImgVHtml = new StringBuilder();
            //用 List<T> 來存取 JSON 格式圖片檔名
            List<ImagePathV> savePathListV = new List<ImagePathV>();
            //從資料庫取出直式圖檔檔名
            string countryIDStr = Session["ID"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sqlLoad = "select CompanyCertificat.CertificatImage from CompanyCertificat join Company on Company.ID = CompanyCertificat.CompanySortID WHERE Company.ID = @countryIDStr";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            command.Parameters.AddWithValue("@countryIDStr", countryIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string loadJson = HttpUtility.HtmlDecode(reader["CertificatImage"].ToString());
                //反序列化JSON格式
                savePathListV = JsonConvert.DeserializeObject<List<ImagePathV>>(loadJson);
            }
            connection.Close();
            // ?. 可用來判斷不是 Null 才執行 Count
            if (savePathListV?.Count > 0)
            {
                foreach (var item in savePathListV)
                {
                    ImgVHtml.Append($"<li><p><img src='../images/{item.SaveName}' alt='Tayana ' /></p></li>");
                }
            }
            //渲染畫面
            LoadContentImgV.Text = ImgVHtml.ToString();
        }

        private void LoadAbout() 
        {

            //從資料庫取出直式圖檔檔名
            string countryIDStr = Session["ID"].ToString();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sqlLoad = "select CompanyAbout.AboutUsHtml from CompanyAbout join Company on Company.ID = CompanyAbout.CompanySortID WHERE Company.ID = @countryIDStr";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            command.Parameters.AddWithValue("@countryIDStr", countryIDStr);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                AboutContent.Text = HttpUtility.HtmlDecode(reader["AboutUsHtml"].ToString());

            }
            connection.Close();


        }

        // JSON 資料 V 直式
        public class ImagePathV
        {
            public string SaveName { get; set; }
        }

        private void LoadLeftMenu()
        {
            //反覆變更字串的值建議用 StringBuilder 效能較好
            StringBuilder leftMenuHtml = new StringBuilder();
            //取得國家分類
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sqlCountry = "SELECT * FROM Company";
            SqlCommand commandCountry = new SqlCommand(sqlCountry, connection);
            connection.Open();
            SqlDataReader readerCountry = commandCountry.ExecuteReader();
            while (readerCountry.Read())
            {
                string idStr = readerCountry["ID"].ToString();
                string countryStr = readerCountry["Tittle"].ToString();
                // StringBuilder 用 Append 加入字串內容
                leftMenuHtml.Append($"<li><a href='company.aspx?id={idStr}'> {countryStr} </a></li>");
            }
            connection.Close();

            //渲染畫面
            LeftMenu.Text = leftMenuHtml.ToString();
        }

    }
}