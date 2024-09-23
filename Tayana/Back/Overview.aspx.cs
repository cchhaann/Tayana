using CKEditor.NET;
using CKFinder;
using CKFinder.Settings;
using NetVips;
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
    public partial class Overview : System.Web.UI.Page
    {
        private List<ImageY> saveImageListH = new List<ImageY>();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                DListModel.DataBind(); //先綁定取得選取值

            }
        }



        protected void DListModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //隱藏上傳成功提示
            LabUploadMainContent.Visible = false;

        }

        protected void BtnUploadMainContent_Click(object sender, EventArgs e)
        {
            string ServerFolderPath = Server.MapPath("upload/Images/");

            if (DimImgUpload.HasFiles)
            {
                foreach (var postfile in DimImgUpload.PostedFiles)
                {
                    // 4. 建立 單一檔案 篩選邏輯                                                                          
                    int FileMemory = postfile.ContentLength;  // 取得 單一檔案 容量變數      
                    string FileName = Path.GetFileName(postfile.FileName); // 取得 單一檔案 名稱變數
                    string FileExtention = Path.GetExtension(postfile.FileName); // 取得 單一檔案 檔名變數 
                    string FilePath = Path.Combine(ServerFolderPath, FileName);  // 取得 單一檔案 儲存路徑
                    if (FileMemory > 1000000)           // 4-1. 如果 單一檔案 大於 1M，跳過不存
                    {
                        continue;
                    }
                    else if (FileExtention == ".pdf")   // 4-2. 如果 單一檔案 不是".jpg"檔名 跳過不存
                    {
                        continue;
                    }
                    else    // 4-3. 如果 單一檔案 吻合格式
                    {
                        //依下拉選單選取型號存入型號介紹主要圖文內容
                        string selectModel_id = DListModel.SelectedValue;
                        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
                        // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
                        connection.Open();

                        // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
                        SqlCommand command = new SqlCommand();     // 建立 Command物件
                        command.Connection = connection;           // Command物件的連線賦予connection物件
                        string sql = "UPDATE YachartsInfo SET YachtsContent = @YachtsContent,ImgPath=@ImgPath,DimensionsImg=@DimensionsImg WHERE id = @selectModel_id";
                        command.Parameters.AddWithValue("@YachtsContent", YachtsContentTextBox.Text);
                        command.Parameters.AddWithValue("@selectModel_id", selectModel_id);
                        command.Parameters.Add("@DimensionsImg", FileName); //用 單一檔案 名稱變數接
                        string PathStore = "/upload/Images/" + FileName;   // Note：請參考HTML的圖片相對路徑  
                        command.Parameters.Add("@ImgPath", PathStore); //用 單一檔案 名稱變數接
                        DimImgUpload.SaveAs(FilePath);
                        command.CommandText = sql;

                        int result1 = command.ExecuteNonQuery();
                        if (result1 == 1)
                        {
                              // 成功資料庫寫入後，將檔案存入指定資料夾路徑
                            Response.Write("<script>alert('更新" + result1 + "筆資料成功');location.href='Yachts.aspx';</script>");
                        }
                        connection.Close();   // 不要忘記關閉資料庫

                    }
                }

            }

            //渲染上傳成功提示
            DateTime nowtime = DateTime.Now;
            LabUploadMainContent.Visible = true;
            LabUploadMainContent.Text = "*Upload Success! - " + nowtime.ToString("G");
        }
    }
}

public class ImageY
{
    public string SaveYName { get; set; }
}