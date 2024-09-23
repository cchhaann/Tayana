using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tayana.Back
{
    public partial class News_Add : System.Web.UI.Page
    {
        private List<ImageNews> saveImageList = new List<ImageNews>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string savePath = Server.MapPath("../images/");

                //添加圖檔資料
                //逐一讀取選擇的圖片檔案
                foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                {
                    //儲存圖片檔案及圖片名稱
                    //檢查專案資料夾內有無同名檔案，有同名就加流水號
                    DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                    string fileName = postedFile.FileName;
                    string[] fileNameArr = fileName.Split('.');
                    int count = 0;
                    foreach (var fileItem in directoryInfo.GetFiles())
                    {
                        if (fileItem.Name.Contains(fileNameArr[0]))
                        {
                            count++;
                        }
                    }
                    fileName = fileNameArr[0] + $"({count + 1})." + fileNameArr[1];
                    //在圖片名稱前加入 temp 標示並儲存圖片檔案
                    postedFile.SaveAs(savePath + "temp" + fileName);
                    //新增 JSON 資料
                    saveImageList.Add(new ImageNews { SaveNews = fileName });

                    //使用 NetVips 套件進行壓縮圖檔
                    //判斷儲存的原始圖片寬度是否大於設定寬度的 2 倍
                    var img = NetVips.Image.NewFromFile(savePath + "temp" + fileName);
                    if (img.Width > 214 * 2)
                    {
                        //產生原使圖片一半大小的新圖片
                        var newImg = img.Resize(0.5);
                        //如果新圖片寬度還是大於原始圖片設定寬度的 2 倍就持續縮減
                        while (newImg.Width > 214 * 2)
                        {
                            newImg = newImg.Resize(0.5);
                        }
                        //儲存正式名稱的新圖片
                        newImg.WriteToFile(savePath + fileName);
                    }
                    else
                    {
                        postedFile.SaveAs(savePath + fileName);
                    }
                    //刪除原始圖片
                    File.Delete(savePath + "temp" + fileName);
                }


                string fileNameJsonStr = JsonConvert.SerializeObject(saveImageList);

                // 第一步：連線字串 ⇒ Connection String：選擇要連哪個資料庫 (使用Connection)
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

                // 反序列化為物件列表
                var imgObjects = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(fileNameJsonStr);

                // 取出第一張圖片的檔案名稱
                string thumbnailFileName = imgObjects.FirstOrDefault()["SaveNews"];

                // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
                connection.Open();

                // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
                SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
                sqlCommand.Connection = connection;           // Command物件的連線賦予connection物件
                string SQLSentence2 = "INSERT into News(NewsTittle, NewsContent,NewsDate,IsTop,NewsImage,NewsThumbnail) VALUES (@NewsTittle,@NewsContent,@NewsDate,@IsTop,@NewsImage,@NewsThumbnail)";
                sqlCommand.Parameters.Add("@NewsTittle", NewsTittleTextBox.Text);
                sqlCommand.Parameters.Add("@NewsContent", NewsContentTextBox.Text);
                sqlCommand.Parameters.Add("@NewsDate", Calendar1.SelectedDate.Date);
                sqlCommand.Parameters.Add("@IsTop", CBoxIsTop.Checked);
                sqlCommand.Parameters.Add("@NewsThumbnail", thumbnailFileName);
                sqlCommand.Parameters.Add("@NewsImage", fileNameJsonStr);
                sqlCommand.CommandText = SQLSentence2;
                int result1 = sqlCommand.ExecuteNonQuery();
                if (result1 == 1)
                {
                    Response.Write("<script>alert('新增" + result1 + "筆資料成功');location.href='News.aspx';</script>");
                }
                connection.Close();   // 不要忘記關閉資料庫
            }
        }
    }
}
public class ImageNews
{
    public string SaveNews { get; set; }
}