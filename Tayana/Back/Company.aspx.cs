using CKFinder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static NetVips.Enums;

namespace Tayana.Back
{
    public partial class Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) 
            {

                LoadCkeditorContent();
                
            }
            FileBrowser fileBrowser = new FileBrowser();
            fileBrowser.BasePath = "../ckfinder";
            fileBrowser.SetupCKEditor(CKEditorControl1);
            //Literal1.Text = HttpUtility.HtmlEncode(CKEditorControl1.Text);
        }

        protected void LoadCkeditorContent() 
        {

            //取得 About Us 頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "SELECT AboutUsHtml FROM CompanyAbout WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                Literal1.Text = HttpUtility.HtmlDecode(reader["AboutUsHtml"].ToString());
            }
            connection.Close();
        }

        protected void UploadAboutUsBtn_Click(object sender, EventArgs e)
        {

            //取得 CKEditorControl 的 HTML 內容
            string aboutUsHtmlStr = HttpUtility.HtmlEncode(CKEditorControl1.Text);
            //更新 About Us 頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "UPDATE CompanyAbout SET AboutUsHtml = @AboutUsHtml WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@aboutUsHtml", aboutUsHtmlStr);
            connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                Literal2.Text = HttpUtility.HtmlDecode(reader["AboutUsHtml"].ToString());
            }
            connection.Close();


            //渲染畫面提示
            DateTime nowtime = DateTime.Now;
            UploadAboutUsLab.Visible = true;
            UploadAboutUsLab.Text = "*Upload Success! - " + nowtime.ToString("G");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //新增 About Us 頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "INSERT into CompanyAbout (AboutUsHtml) VALUES (@AboutUsHtml)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@AboutUsHtml", CKEditorControl1.Text);
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();

            //渲染畫面提示
            DateTime nowtime = DateTime.Now;
            UploadAboutUsLab.Visible = true;
            UploadAboutUsLab.Text = "*新增成功! - " + nowtime.ToString("G");
        }
    }
}