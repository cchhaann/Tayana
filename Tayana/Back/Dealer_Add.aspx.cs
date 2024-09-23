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
    public partial class Dealer_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCountryId = Convert.ToInt32(DropDownList1.SelectedValue);
            SqlDataSource2.SelectCommand = $"SELECT CountryArea.ID, CountrySort.Name, CountryArea.AreaName FROM CountryArea INNER JOIN CountrySort ON CountrySort.ID = CountryArea.CountryId WHERE (CountryArea.CountryId = {selectedCountryId})";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ServerFolderPath = Server.MapPath("~/images/");

            if (FileUpload1.HasFiles)  // Note：控制項目可以開啟 "AllowMultiple" 功能
            {
                // 3. 將 FileUpload 控制項裡面的檔案跑迴圈
                foreach (var postfile in FileUpload1.PostedFiles)
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
                        // 第一步：連線字串 ⇒ Connection String：選擇要連哪個資料庫 (使用Connection)
                        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["TayanaYachtConnectionString"].ConnectionString);

                        // 第二步：進行連線 ⇒ Connection.Open()：開始連線了！(使用Connection)
                        connection.Open();

                        // 第三步：執行 SQL 指令 ⇒ ExecuteReader：CRUD (使用Command執行、DataReader承接)
                        SqlCommand sqlCommand = new SqlCommand();     // 建立 Command物件
                        sqlCommand.Connection = connection;           // Command物件的連線賦予connection物件
                        string SQLSentence2 = "INSERT into Dealer(FileName, DealerImgPath,DealerName,CountryId,AreaId,Contant,Address,TEL,Fax,Mail,Link) VALUES (@FileName,@DealerImgPath,@DealerName,@CountryId,@AreaId,@Contant,@Address,@TEL,@Fax,@Mail,@Link)";
                        sqlCommand.Parameters.Add("@FileName", FileName); //用 單一檔案 名稱變數接
                        string PathStore = "/images/" + FileName;   // Note：請參考HTML的圖片相對路徑  
                        sqlCommand.Parameters.Add("@DealerImgPath", PathStore); //用 PathStore 接
                        sqlCommand.Parameters.Add("@DealerName", DealerNameTextBox.Text);
                        sqlCommand.Parameters.Add("@CountryId", DropDownList1.SelectedValue);
                        sqlCommand.Parameters.Add("@AreaId", Convert.ToInt32(DropDownList2.SelectedValue));
                        sqlCommand.Parameters.Add("@Contant", ContactNameTextBox.Text);
                        sqlCommand.Parameters.Add("@Address", AddressTextBox.Text);
                        sqlCommand.Parameters.Add("@TEL", PhoneTextBox.Text);
                        sqlCommand.Parameters.Add("@Fax", FaxTextBox.Text);
                        sqlCommand.Parameters.Add("@Mail", MailTextBox.Text);
                        sqlCommand.Parameters.Add("@Link", LinkTextBox.Text);
                        sqlCommand.CommandText = SQLSentence2;
                        int result1 = sqlCommand.ExecuteNonQuery();
                        if (result1 == 1)
                        {
                            FileUpload1.SaveAs(FilePath);  // 成功資料庫寫入後，將檔案存入指定資料夾路徑
                            Response.Write("<script>alert('新增" + result1 + "筆資料成功');location.href='DealerList.aspx';</script>");
                        }
                        connection.Close();   // 不要忘記關閉資料庫
                        
                    }
                }
            }

        }
    }
}