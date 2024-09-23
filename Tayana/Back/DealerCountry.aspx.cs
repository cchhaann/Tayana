using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Back
{
    public partial class DealerCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGridview1();
                ShowGridview2();
            }
        }
        protected void ShowGridview1()
        {
            DBHelper dbHelper = new DBHelper();
            string sql = $"select * from CountrySort";   // 建立 SQL語句
            SqlDataReader rd = dbHelper.SearchDB(sql);
            if (rd != null)
            {
                GridView1.DataSource = rd;
                GridView1.DataBind();
            }
            dbHelper.CloseDB();
        }
        protected void ShowGridview2()
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
            sqlCommand.Connection = connection;
            string sql = $"SELECT CountryArea.ID,CountrySort.Name,CountryArea.AreaName,CountryArea.CreateTime FROM CountryArea JOIN CountrySort ON CountrySort.ID = CountryArea.CountryId";   // 建立 SQL語句
            sqlCommand.CommandText = sql;
            SqlDataReader rd = sqlCommand.ExecuteReader();
            if (rd != null)
            {
                GridView2.DataSource = rd;      // 將 GridView 來源連結到 SqlDataReade 上
                GridView2.DataBind();           // 將 GridView 與資料來源 進行綁定 (倒資料進來)            
            }
            // 第四步：關閉連線 ⇒ Connection.Close()：斷開連結了！(使用Connection)
            connection.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowGridview1();
        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            ShowGridview2();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ShowGridview1();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            ShowGridview2();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IndeRow = e.RowIndex;

            string IDkey = GridView1.DataKeys[IndeRow].Value.ToString();

            // 3. 透過SQL語法進行資料的修改
            // 第一步：連線字串 ⇒ Connection String：選擇要連哪個資料庫(使用Connection)
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

            // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
            connection.Open();

            //第三步:執行sql指令
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            string SQLSentence3 = $"DELETE FROM CountrySort WHERE Id=@Id";   // 建立 SQL語句
            sqlCommand.Parameters.Add("@Id", IDkey);
            sqlCommand.CommandText = SQLSentence3;         // Command物件的命令賦予SQLSentence字串


            int result = sqlCommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {

                Response.Write($"result = confirm('確定要刪除此筆資料嗎？');<script>alert('刪除{result}筆資料成功')</script>");
            }

            connection.Close();

            // 4. 補充：不要忘記重新執行 showGV()
            connection.Close();
            ShowGridview1();   //當然也可以Redirect，就不用showGV了

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IndeRow = e.RowIndex;

            string IDkey = GridView2.DataKeys[IndeRow].Value.ToString();

            // 3. 透過SQL語法進行資料的修改
            // 第一步：連線字串 ⇒ Connection String：選擇要連哪個資料庫(使用Connection)
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

            // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
            connection.Open();

            //第三步:執行sql指令
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            string SQLSentence4 = $"DELETE FROM CountryArea WHERE Id=@Id";   // 建立 SQL語句
            sqlCommand.Parameters.Add("@Id", IDkey);
            sqlCommand.CommandText = SQLSentence4;         // Command物件的命令賦予SQLSentence字串


            int result = sqlCommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('刪除{result}筆資料成功')</script>");
            }

            connection.Close();

            // 4. 補充：不要忘記重新執行 showGV()
            connection.Close();
            ShowGridview2();   //當然也可以Redirect，就不用showGV了

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 1. 找到特定表格行數 (Row) ⇒ ex：第五行
            int IndexRow = e.RowIndex;

            // 2. 取得該行數的表格行數物件 (GridViewRow) ⇒ ex：第五行的物件 
            GridViewRow TargetRow = GridView1.Rows[IndexRow];

            // 3. 於該物件內部找到要修改的欄位 (Column) 物件⇒ ex：物件中的 Title 物件
            TextBox UpdateName = TargetRow.FindControl("CountryNameTextBox") as TextBox;
            // 4. 找到該行數的 Key Value (ID) ⇒ ex：第五行中的 ID 欄位值
            string IDkey = GridView1.DataKeys[IndexRow].Value.ToString();

            // 5. 透過SQL語法進行資料的修改 (開始撰寫dbhelper 4 個流程)
            // 第一步：連線字串 ⇒ Connection String：選擇要連哪個資料庫(使用Connection)
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

            // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
            connection.Open();

            // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
            SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
            sqlCommand.Connection = connection;           // Command物件的連線賦予connection物件
            string SQLSentence5 = $"UPDATE CountrySort SET Name=@Name WHERE Id=@Id";   // 建立 SQL語句
            sqlCommand.Parameters.Add("@Name", UpdateName.Text);
            sqlCommand.Parameters.Add("@Id", IDkey);


            sqlCommand.CommandText = SQLSentence5;         // Command物件的命令賦予SQLSentence字串
                int result = sqlCommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
                if (result > 0)
                {
                    Response.Write($"<script>alert('更新{result}筆資料成功')</script>");
                }
            // 6. 補充：不要忘記重新 把 編輯模式 改回 閱讀模式 以及執行 showGV()
            connection.Close();
            GridView1.EditIndex = -1;
            ShowGridview1();  //當然也可以Redirect，就不用showGV了

        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 1. 找到特定表格行數 (Row) ⇒ ex：第五行
            int IndexRow = e.RowIndex;

            // 2. 取得該行數的表格行數物件 (GridViewRow) ⇒ ex：第五行的物件 
            GridViewRow TargetRow = GridView2.Rows[IndexRow];

            // 3. 於該物件內部找到要修改的欄位 (Column) 物件⇒ ex：物件中的 Title 物件
            TextBox UpdateAreaName = TargetRow.FindControl("TextBox1") as TextBox;
            // 4. 找到該行數的 Key Value (ID) ⇒ ex：第五行中的 ID 欄位值
            string IDkey = GridView2.DataKeys[IndexRow].Value.ToString();

            // 5. 透過SQL語法進行資料的修改 (開始撰寫dbhelper 4 個流程)
            // 第一步：連線字串 ⇒ Connection String：選擇要連哪個資料庫(使用Connection)
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

            // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
            connection.Open();

            // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
            SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
            sqlCommand.Connection = connection;           // Command物件的連線賦予connection物件
            string SQLSentence2 = $"UPDATE CountryArea SET AreaName=@AreaName WHERE Id=@Id";   // 建立 SQL語句
            sqlCommand.Parameters.Add("@AreaName", UpdateAreaName.Text);
            sqlCommand.Parameters.Add("@Id", IDkey);


            sqlCommand.CommandText = SQLSentence2;         // Command物件的命令賦予SQLSentence字串
            int result = sqlCommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('更新{result}筆資料成功')</script>");
            }
            // 6. 補充：不要忘記重新 把 編輯模式 改回 閱讀模式 以及執行 showGV()
            connection.Close();
            GridView2.EditIndex = -1;
            ShowGridview2();  //當然也可以Redirect，就不用showGV了

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Country_Add.aspx");
        }
 
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Area_Add.aspx");
        }
    }
}