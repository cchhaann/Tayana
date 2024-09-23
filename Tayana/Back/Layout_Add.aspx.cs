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
    public partial class Layout_Add : System.Web.UI.Page
    {
        private List<ImageLayout> saveLayoutList = new List<ImageLayout>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (LayoutFileUpload.HasFile)
            {
                string ServerFolderPath = Server.MapPath("upload/Images/");

                foreach (HttpPostedFile postedFile in LayoutFileUpload.PostedFiles)
                {
                    //儲存圖片檔案及圖片名稱
                    //檢查專案資料夾內有無同名檔案，有同名就加流水號
                    DirectoryInfo directoryInfo = new DirectoryInfo(ServerFolderPath);
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
                    postedFile.SaveAs(ServerFolderPath + "temp" + fileName);
                    //新增 JSON 資料
                    saveLayoutList.Add(new ImageLayout { saveLayoutList = fileName });
                    //使用 NetVips 套件進行壓縮圖檔
                    //判斷儲存的原始圖片寬度是否大於設定寬度的 2 倍
                    var img = NetVips.Image.NewFromFile(ServerFolderPath + "temp" + fileName);
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
                        newImg.WriteToFile(ServerFolderPath + fileName);
                    }
                    else
                    {
                        postedFile.SaveAs(ServerFolderPath + fileName);
                    }
                    //刪除原始圖片
                    File.Delete(ServerFolderPath + "temp" + fileName);

                }
                string fileNameJsonStr = JsonConvert.SerializeObject(saveLayoutList);
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

                // 反序列化為物件列表
                var imgObjects = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(fileNameJsonStr);

                // 取出第一張圖片的檔案名稱
                string thumbnailFileName = imgObjects.FirstOrDefault()["saveLayoutList"];

                // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
                connection.Open();

                // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
                SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
                sqlCommand.Connection = connection;           // Command物件的連線賦予connection物件
                string SQLSentence2 = "INSERT into Layout(YachtsModelID, LayoutImgPathJSON) VALUES (@YachtsModelID,@LayoutImgPathJSON)";
                sqlCommand.Parameters.Add("@YachtsModelID", DropDownList1.SelectedValue);
                sqlCommand.Parameters.Add("@LayoutImgPathJSON", fileNameJsonStr);

                sqlCommand.CommandText = SQLSentence2;
                int result1 = sqlCommand.ExecuteNonQuery();
                if (result1 == 1)
                {
                    Response.Write("<script>alert('新增" + result1 + "筆資料成功');location.href='Yachts_Layout.aspx';</script>");
                }
                connection.Close();   // 不要忘記關閉資料庫

            }

        }
    }
}
public class ImageLayout
{
    public string saveLayoutList { get; set; }
}