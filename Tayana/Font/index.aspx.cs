using CKFinder.Settings;
using NetVips;
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
using Tayana.Back;
using static Tayana.Font.company;

namespace Tayana.Font
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ShowNews();
                //LoadBanner();
                ShowBanner();
            }

        }


        private void ShowNews()
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "SELECT TOP 3 ID, NewsThumbnail, NewsTittle, NewsDate, IsTop FROM News ORDER BY NewsDate DESC";
            SqlCommand command = new SqlCommand(sql, connection);
           
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            StringBuilder NewsContentHtmlStr = new StringBuilder();
            int count = 1;
            while (reader.Read())
            {
                string newsImg = reader["NewsThumbnail"].ToString();
                string newsTittle = reader["NewsTittle"].ToString();
                DateTime newsDate = DateTime.Parse(reader["NewsDate"].ToString());
                string Date = newsDate.ToString("yyyy/M/d");
                string IDStr = reader["ID"].ToString();
                string isTop = reader["IsTop"].ToString();
                if (count == 1)
                {
                    Literalimg.Text = $"<img src='../images/{newsImg}' alt='{newsTittle}' style='height: 100%;' />";
                    Literal2.Text = $"<span>{Date}</span>";
                    HyperLink1.Text = $"<a href='NewsDetails.aspx?id={IDStr}'>{newsTittle}</a></p>";
                    if (isTop.Equals("True"))
                    {
                        ImgIsTop1.Visible = true;
                    }
                } else if (count == 2)
                {
                    Literal3.Text = $"<img src='../images/{newsImg}' alt='{newsTittle}' style='height: 100%;' />";
                    Literal4.Text = $"<span>{Date}</span>";
                    HyperLink2.Text = $"<a href='NewsDetails.aspx?id={IDStr}'>{newsTittle}</a></p>";
                    if (isTop.Equals("True"))
                    {
                        Image1.Visible = true;
                    }
                }
                else if (count == 3)
                {
                    Literal6.Text = $"<img src='../images/{newsImg}' alt='{newsTittle}' style='height: 100%;' />";
                    Literal7.Text = $"<span>{Date}</span>";
                    HyperLink3.Text = $"<a href='NewsDetails.aspx?id={IDStr}'>{newsTittle}</a></p>";
                    if (isTop.Equals("True"))
                    {
                        Image2.Visible = true;
                    }

                }
                else break; //超過3筆後停止
                count++;

            }
            connection.Close();
        }

        private void ShowBanner() 
        {
            List<ImagePath> savePathList = new List<ImagePath>();
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sqlLoad = "SELECT * FROM YachartsInfo ORDER BY id DESC";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder bannerHtml = new StringBuilder();
            while (reader.Read()) 
            {
                string loadJson = reader["BannerImgPathJSON"].ToString();
                savePathList = JsonConvert.DeserializeObject<List<ImagePath>>(loadJson);
                string imgNameStr = "";
                if (savePathList?.Count > 0 && savePathList[0] != null)
                {
                    imgNameStr = savePathList[0].SaveYachts;
                }

                string[] modelArr = reader["YachtsModel"].ToString().Split(' ');
                string isNewDesignStr = reader["isNewDesign"].ToString();
                string isNewBuildingStr = reader["isNewBuilding"].ToString();
                string newTagStr = "";
                string displayNewStr = "0";

                if (isNewDesignStr.Equals("True"))
                {
                    displayNewStr = "1";
                    newTagStr = "../images/new02.png";
                }
                else if (isNewBuildingStr.Equals("True"))
                {
                    displayNewStr = "1";
                    newTagStr = "../images/new01.png";
                }

                if (modelArr.Length >= 2)
                {
                    bannerHtml.Append($"<li class='info' style='border-radius: 5px;height: 424px;width: 978px;'><a href='' target='_blank'><img src='../Back/upload/Images/{imgNameStr}' style='width: 978px;height: 424px;border-radius: 5px;'/></a><div class='wordtitle'>{modelArr[0]} <span>{modelArr[1]}</span><br /><p>SPECIFICATION SHEET</p></div><div class='new' style='display: none;overflow: hidden;border-radius:10px;'><img src='{newTagStr}' alt='new' /></div><input type='hidden' value='{displayNewStr}' /></li>");
                }
            }
            connection.Close();
            //渲染畫面
            LiteralBanner.Text = bannerHtml.ToString();
            LiteralNum.Text = bannerHtml.ToString(); //不顯示但影響輪播圖片數量計算
        }
    }
}
//輪播圖 JSON 資料
public class ImagePath
{
    public string SaveYachts { get; set; }
}