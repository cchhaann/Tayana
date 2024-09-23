using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Back
{
    public partial class Yachts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ShowGridview1();
            }
        }
        protected void ShowGridview1()
        {
            DBHelper dbHelper = new DBHelper();
            string sql = $"select * from YachartsInfo";   // 建立 SQL語句
            SqlDataReader rd = dbHelper.SearchDB(sql);
            if (rd != null)
            {
                GridView1.DataSource = rd;
                GridView1.DataBind();
            }
            dbHelper.CloseDB();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yachts_Add.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yachts_Update.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Overview.aspx");
        }
    }
}