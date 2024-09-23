﻿using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Back
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Argon2 驗證加密密碼
        // Hash 處理加鹽的密碼功能
        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            //底下這些數字會影響運算時間，而且驗證時要用一樣的值
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // 4 核心就設成 8
            argon2.Iterations = 4; //迭代運算次數
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }
        //驗證
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash); // LINEQ
        }

        private void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票 //需額外引入 using System.Web.Security;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立 Cookie
            HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //將 Cookie 寫入回應
            Response.Cookies.Add(authenticationCookie);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pwd = TextBox1.Text;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            // 2.sql語法 (@參數化避免隱碼攻擊)
            string sql = "SELECT * FROM managerData WHERE Account = @Account";
            // 3.創建 command 物件
            SqlCommand command = new SqlCommand(sql, connection);
            // 4.放入參數化資料
            command.Parameters.AddWithValue("@Account", TextBox2.Text);
            // 5.資料庫用 Adapter 執行指令
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            // 6.建立一個空的 Table
            DataTable dataTable = new DataTable();
            // 7.將資料放入 Table
            dataAdapter.Fill(dataTable);
            // 登入流程管理 (Cookie)
            if (dataTable.Rows.Count > 0) 
            {
                //將字串轉回 byte
                byte[] hash = Convert.FromBase64String(dataTable.Rows[0]["Password"].ToString());
                byte[] salt = Convert.FromBase64String(dataTable.Rows[0]["salt"].ToString());
                //驗證密碼
                bool success = VerifyHash(pwd, salt, hash);
                if (success)
                {
                    //宣告驗證票要夾帶的資料 (用;區隔)
                    string userData = dataTable.Rows[0]["maxPower"].ToString() + ";" + dataTable.Rows[0]["Account"].ToString() + ";" + dataTable.Rows[0]["Name"].ToString() + ";" + dataTable.Rows[0]["Email"].ToString();
                    //設定驗證票(夾帶資料，cookie 命名) // 需額外引入using System.Web.Configuration;
                    SetAuthenTicket(userData, TextBox2.Text);
                    Response.Redirect("CheckAccount.ashx");

                }
                else 
                {
                    //資料庫裡找不到相同資料時，表示密碼有誤!
                    Label4.Text = "login error!";
                    Label4.Visible = true;
                    connection.Close();
                    return;
                }
                 connection.Close();
            }
        }
    }
}