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
using static NetVips.Enums;

namespace Tayana.Back
{
    public partial class Certificat : System.Web.UI.Page
    {
        //宣告全域 List<T> 可用 Add 依序添加資料
        private List<ImageNameH> saveNameListH = new List<ImageNameH>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCertificatContent();
                LoadImageList();
            }
        }

        protected void AddCertificatBtn_Click(object sender, EventArgs e)
        {
            // 第一步：連線字串 ⇒ Connection String：選擇要連哪個資料庫 (使用Connection)
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

            // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
            connection.Open();

            // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
            SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
            sqlCommand.Connection = connection;           // Command物件的連線賦予connection物件
            string SQLSentence2 = "INSERT into CompanyCertificat(CertificatContent) VALUES (@CertificatContent)";
            sqlCommand.Parameters.Add("@CertificatContent", certificatTbox.Text);
            sqlCommand.CommandText = SQLSentence2;
            int result1 = sqlCommand.ExecuteNonQuery();
            DateTime nowtime = DateTime.Now;

            if (result1 == 1)
            {
                Label1.Visible = true;
                Label1.Text = "*新增成功 ! - " + nowtime.ToString("G");
            }
            connection.Close();   // 不要忘記關閉資料庫

        }

        protected void uploadCertificatBtn_Click(object sender, EventArgs e)
        {
            //更新 Certificat 頁文字說明資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "UPDATE CompanyCertificat SET CertificatContent = @certificatContent WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@certificatContent", certificatTbox.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染畫面提示
            DateTime nowtime = DateTime.Now;
            uploadCertificatLab.Visible = true;
            uploadCertificatLab.Text = "*更新成功! - " + nowtime.ToString("G");
        }

        protected void LoadCertificatContent()
        {
            //取得 Certificat 頁文字說明資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sql = "SELECT CertificatContent FROM CompanyCertificat WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                certificatTbox.Text = reader["CertificatContent"].ToString();
            }
            connection.Close();
        }

        //圖片區
        protected void LoadImageList()
        {
            //取得 Certificat 頁文字說明資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string sqlLoad = "SELECT CertificatImage FROM CompanyCertificat WHERE id = 1";
            SqlCommand command = new SqlCommand(sqlLoad, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string loadJson = reader["CertificatImage"].ToString();
                //反序列化JSON格式
                saveNameListH = JsonConvert.DeserializeObject<List<ImageNameH>>(loadJson);
            }
            connection.Close();
            //可以改成用 ?.Count 來判斷不是 Null 後才執行 .Count 避免錯誤
            if (saveNameListH?.Count > 0)
            {
                //逐一取出 JSON 的每筆資料
                foreach (var item in saveNameListH)
                {
                    //將 RadioButtonList 選項內容改為圖片格式，值設為檔案名稱
                    ListItem listItem = new ListItem($"<img src='../images/{item.SaveName}' alt='thumbnail' class='img-thumbnail' width='230px'/>", item.SaveName);
                    //加入圖片選項
                    RadioButtonList1.Items.Add(listItem);
                }
            }
            DelHImageBtn.Visible = false; //刪除鈕有選擇圖片時才顯示
        }

        protected void UploadButton(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                LoadImageList();
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
                    saveNameListH.Add(new ImageNameH { SaveName = fileName });

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

                //更新新增後的圖片名稱 JSON 存入資料庫
                string fileNameJsonStr = JsonConvert.SerializeObject(saveNameListH);
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
                string sql = $"UPDATE CompanyCertificat SET CertificatImage = @CertificatImage WHERE id = 1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CertificatImage", fileNameJsonStr);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                //渲染畫面
                RadioButtonList1.Items.Clear();
                LoadImageList();
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelHImageBtn.Visible = true;
        }

        protected void DelHImageBtn_Click(object sender, EventArgs e)
        {
            //先讀取資料庫原有資料
            LoadImageList();
            //取得選取項目的值
            string selHImageStr = RadioButtonList1.SelectedValue;

            //刪除圖片檔案
            string savePath = Server.MapPath("../images/");
            File.Delete(savePath + selHImageStr);

            //逐一比對原始資料 List<saveNameListH> 中的檔案名稱
            for (int i = 0; i < saveNameListH.Count; i++)
            {
                //與刪除的選項相同名稱
                if (saveNameListH[i].SaveName.Equals(selHImageStr))
                {
                    //移除 List 中同名的資料
                    saveNameListH.RemoveAt(i);
                }
            }
            //更新刪除後的圖片名稱 JSON 存入資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);
            string saveNameJsonStr = JsonConvert.SerializeObject(saveNameListH);
            string sql = "UPDATE CompanyCertificat SET CertificatImage = @saveNameJsonStr WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@saveNameJsonStr", saveNameJsonStr);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染畫面
            RadioButtonList1.Items.Clear();
            LoadImageList();
        }

    }
}
// JSON 資料 Horizontal Image
public class ImageNameH
{
    public string SaveName { get; set; }
}
