using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Back
{
    public partial class Specification_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // 第一步：連線字串 ⇒ Connection String：選擇要連哪個資料庫 (使用Connection)
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

            // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
            connection.Open();

            // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
            SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
            sqlCommand.Connection = connection;           // Command物件的連線賦予connection物件
            string[] items = DetailBox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string item in items)
            {
                // 忽略空白行
                if (string.IsNullOrWhiteSpace(item))
                    continue;

                string SQLSentence2 = "INSERT into Specification(YachtsModelID, DetailTittle, Detail) VALUES (@YachtsModelID, @DetailTittle, @Detail)";
                sqlCommand.Parameters.Clear(); // 清空參數
                sqlCommand.Parameters.Add("@YachtsModelID", DropDownList1.SelectedValue);
                sqlCommand.Parameters.Add("@DetailTittle", AddDetailTextBox.Text);
                sqlCommand.Parameters.Add("@Detail", item.Trim()); // 移除前後的空白字元
                sqlCommand.CommandText = SQLSentence2;

                sqlCommand.ExecuteNonQuery();
            }

            Response.Write("<script>alert('新增" + items.Length + "筆資料成功');location.href='Yachts_Specification.aspx';</script>");

            connection.Close();

            //string SQLSentence2 = "INSERT into Specification(YachtsModelID,DetailTittle,Detail) VALUES (@YachtsModelID,@DetailTittle,@Detail)";
            //sqlCommand.Parameters.Add("@YachtsModelID", DropDownList1.SelectedValue);
            //sqlCommand.Parameters.Add("@DetailTittle", AddDetailTextBox.Text);
            //sqlCommand.Parameters.Add("@Detail", DetailBox.Text);
            //sqlCommand.CommandText = SQLSentence2;

            //int result1 = sqlCommand.ExecuteNonQuery();
            //if (result1 == 1)
            //{
            //    Response.Write("<script>alert('新增" + result1 + "筆資料成功');location.href='Yachts_Specification.aspx';</script>");

            //}
            //connection.Close();   // 不要忘記關閉資料庫

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yachts_Specification.aspx");
        }
    }
}