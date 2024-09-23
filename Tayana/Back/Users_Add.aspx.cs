using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Tayana.Back
{
    public partial class Users_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                
            }

        }
        // Argon2 加密
        //產生 Salt 功能
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        // Hash 處理加鹽的密碼功能
        private byte[] HashPassword(string Password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(Password));

            //底下這些數字會影響運算時間，而且驗證時要用一樣的值
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // 4 核心就設成 8
            argon2.Iterations = 4; // 迭代運算次數
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool haveSameAccount = false;
            //連線設定
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);


            //執行SQL指令
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            string sqlCheck = $"SELECT * FROM managerData WHERE account = @account";
            string sql = $"insert into managerData(Account,Password,salt) Values (@Account,@Password,@salt)";
            SqlCommand commandCheck = new SqlCommand(sqlCheck, connection);
            SqlCommand commandAdd = new SqlCommand(sql, connection);
            //檢查有無重複帳號
            commandCheck.Parameters.AddWithValue("@Account", AddAccountTextBox.Text);
            connection.Open();
            SqlDataReader readerCountry = commandCheck.ExecuteReader();
            if (readerCountry.Read())
            {
                haveSameAccount = true;
                AccountLabel.Visible = true; //帳號重複通知
                Response.Write("<script>alert('已有該使用者')</script>");
            }
            connection.Close();

            //無重複帳號才執行加入
            if (!haveSameAccount)
            {
                //Hash 加鹽加密
                string password = AddPasswordTextBox.Text;
                var salt = CreateSalt();
                string saltStr = Convert.ToBase64String(salt); //將 byte 改回字串存回資料表

                var hash = HashPassword(password, salt);
                string hashPassword = Convert.ToBase64String(hash);
                commandAdd.Parameters.AddWithValue("@Account", AddAccountTextBox.Text);
                commandAdd.Parameters.AddWithValue("@Password", hashPassword);
                commandAdd.Parameters.AddWithValue("@salt", saltStr);

                connection.Open();

                int result = commandAdd.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
                if (result > 0)
                {
                    Response.Write("<script>alert('新增" + result + "筆資料成功');location.href='UserList.aspx';</script>");
                }

                connection.Close();

                //清空輸入欄位
                AddAccountTextBox.Text = "";
                AddPasswordTextBox.Text = "";
                AccountLabel.Visible = false;
                

            }
        }
    }
}