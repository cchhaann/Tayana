using Newtonsoft.Json;
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
    public partial class Yachts_Layout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGridview1();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Layout_Add.aspx");
        }

        protected void ShowGridview1()
        {
            DBHelper dbHelper = new DBHelper();
            string sql = $"select Layout.ID,YachartsInfo.YachtsModel,Layout.LayoutImgPathJSON FROM Layout join YachartsInfo　on YachartsInfo.ID = Layout.YachtsModelID";   // 建立 SQL語句
            SqlDataReader rd = dbHelper.SearchDB(sql);
            if (rd != null)
            {
                GridView1.DataSource = rd;
                GridView1.DataBind();
            }
            dbHelper.CloseDB();
        }
       
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Layout_Update.aspx");
        }
    }
}