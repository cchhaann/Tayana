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
    public partial class Layout_Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadImageList();
            }
        }
        protected void LoadImageList() 
        {
            string selectedYachtsModelID = DropDownList1.SelectedValue;
            //取得 Certificat 頁文字說明資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sqlLoad = "SELECT LayoutImgPathJSON FROM Layout WHERE YachtsModelID = @YachtsModelID";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            command.Parameters.AddWithValue("@YachtsModelID", selectedYachtsModelID);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                string loadJson = reader["LayoutImgPathJSON"].ToString();
                List<SaveLayoutList> saveLayoutLists = JsonConvert.DeserializeObject<List<SaveLayoutList>>(loadJson);


                foreach (var item in saveLayoutLists)
                {
                    ListItem listItem = new ListItem($"<img src='../images/{item.saveLayoutList}' alt='thumbnail' class='img-thumbnail' width='230px'/>", item.saveLayoutList);
                    RadioButtonList1.Items.Add(listItem);
                }
            }
            connection.Close();
            DelHImageBtn.Visible = !RadioButtonList1.Items.Cast<ListItem>().Any();
        }
    }
}
public class SaveLayoutList
{
    public string saveLayoutList { get; set; }
}