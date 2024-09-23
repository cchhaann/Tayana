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
    public partial class Yachts_Add : System.Web.UI.Page
    {
        private List<ImageYachts> saveImageList = new List<ImageYachts>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if (FileUploadBanner.HasFile || FileUploadImg.HasFiles)
            {
                string ServerFolderPath = Server.MapPath("upload/Images/");

                foreach (HttpPostedFile postedFile in FileUploadBanner.PostedFiles)
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
                    saveImageList.Add(new ImageYachts { SaveYachts = fileName });
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
                string fileNameJsonStr = JsonConvert.SerializeObject(saveImageList);
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

                // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
                connection.Open();

                // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
                SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
                sqlCommand.Connection = connection;
                string SQLSentence2 = "INSERT into YachartsInfo(YachtsModel,isNewDesign,isNewBuilding,YachtsContent,HullLength,LWL,BMAX,StandardDraft,Ballast,Displacement,EngineDiesel,SailArea,Cutter,Designer,ImgPath,DimensionsImg,DownloadsFile,DownloadsFileName,BannerImgPathJSON,DimensionsName,HeadRoom,Draft)" +
                "VALUES (@YachtsModel,@isNewDesign,@isNewBuilding,@YachtsContent,@HullLength,@LWL,@BMAX,@StandardDraft,@Ballast,@Displacement,@EngineDiesel,@SailArea,@Cutter,@Designer,@ImgPath,@DimensionsImg,@DownloadsFile,@DownloadsFileName,@BannerImgPathJSON,@DimensionsName,@HeadRoom,@Draft)";
                sqlCommand.Parameters.Add("@YachtsModel", AddYachtsTextBox.Text);
                sqlCommand.Parameters.Add("@isNewDesign", CBoxIsNewDesign.Checked);
                sqlCommand.Parameters.Add("@isNewBuilding", CheckBoxNewBuilding.Checked);
                sqlCommand.Parameters.Add("@YachtsContent", YachtsContentTextBox.Text);
                sqlCommand.Parameters.Add("@HullLength", HullLengthTBox.Text);
                sqlCommand.Parameters.Add("@LWL", LWLTBox.Text);
                sqlCommand.Parameters.Add("@BMAX", BMAXTBox.Text);
                sqlCommand.Parameters.Add("@Draft", draftTextBox.Text);
                sqlCommand.Parameters.Add("@HeadRoom", HeadRoomTextBox.Text);
                sqlCommand.Parameters.Add("@StandardDraft", StandardDraftTBox.Text);
                sqlCommand.Parameters.Add("@Ballast", BallastTBox.Text);
                sqlCommand.Parameters.Add("@Displacement", DisplacementTBox.Text);
                sqlCommand.Parameters.Add("@EngineDiesel", EngineDieselTBox.Text);
                sqlCommand.Parameters.Add("@SailArea", SailAreaTBox.Text);
                sqlCommand.Parameters.Add("@Cutter", CutterTBox.Text);
                sqlCommand.Parameters.Add("@Designer", DesignerTBox.Text);
                sqlCommand.Parameters.Add("@DimensionsName", DimensionsNameTextBox.Text);
                sqlCommand.Parameters.Add("@BannerImgPathJSON", fileNameJsonStr);

                foreach (var postfile in FileUploadImg.PostedFiles)
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
                    else
                    {
                        sqlCommand.Parameters.Add("@DimensionsImg", FileName); //用 單一檔案 名稱變數接
                        string PathStore = "/upload/Images/" + FileName;   // Note：請參考HTML的圖片相對路徑  
                        sqlCommand.Parameters.Add("@ImgPath", PathStore); //用 PathStore 接
                        FileUploadImg.SaveAs(FilePath);
                    }
                }
                string filePDFName = FileUploadPDF.FileName;
                string savePath = Server.MapPath("upload/files/");
                if (FileUploadPDF.HasFiles) 
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                    int count = 0;
                    foreach (var fileItem in directoryInfo.GetFiles())
                    {
                        if (fileItem.Name.Contains(filePDFName))
                        {
                            count++;
                        }
                    }
                    string[] filePDFNameArr = filePDFName.Split('.');
                    filePDFName = filePDFNameArr[0] + $"({count + 1})." + filePDFNameArr[1];
                    FileUploadPDF.SaveAs(savePath + filePDFName);
                   
                }
                sqlCommand.Parameters.Add("@DownloadsFile", filePDFName);
                sqlCommand.Parameters.Add("@DownloadsFileName", FileTextBox.Text);

                sqlCommand.CommandText = SQLSentence2;
                int result1 = sqlCommand.ExecuteNonQuery();
                if (result1 == 1)
                {
                    Response.Write("<script>alert('新增" + result1 + "筆資料成功');location.href='Yachts.aspx';</script>");
                }
                connection.Close();   // 不要忘記關閉資料庫
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yachts.aspx");
        }
    }
}

public class ImageYachts
{
    public string SaveYachts { get; set; }
}