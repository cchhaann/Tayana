using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Tayana.Back
{
    public class DBHelper
    {
        //建立SQL連線物件
        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

        //建立SQL命令物件
        SqlCommand sqlCommand = new SqlCommand();

        //連線資料庫，讓別人不能連線，設成私人
        private void ConnectDB()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        //關閉資料庫
        public void CloseDB()
        {
            connection.Close();
        }

        //查詢資料庫
        public SqlDataReader SearchDB(string sql)
        {
            ConnectDB();

            //發送SQL語法，取得結果，第一句前面有宣告過
            sqlCommand.Connection = connection;

            //查詢的方法，刪除並帶入上面參數
            //string sql = $"select * from Student";

            //將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            //執行該SQL查詢，用reader接資料
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //不能放在return下面
            //CloseDB();

            //必須把reader傳出
            return reader;
        }
    }
}