using NetVips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Tayana.Font;

namespace Tayana.Back
{
    /// <summary>
    /// CheckAccount 的摘要描述
    /// </summary>
    public class CheckAccount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // ashx 裡的 Request/Response 都要加上 context
            string ticketUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            string[] ticketUserDataArr = ticketUserData.Split(';');
            bool haveRight = HttpContext.Current.User.Identity.IsAuthenticated;
            //依管理權限導頁
            if (haveRight)
            {
                if (ticketUserDataArr[0].Equals("True"))
                {
                    //以驗證票夾帶資料作為限制
                    context.Response.Redirect("Index.aspx"); //最高管理員-跳至管理員審核頁面
                }
                else
                {
                    context.Response.Redirect("../Font/index.aspx");
                }
            }
            else
            {
                context.Response.Redirect("Index.aspx"); //導回登入頁
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}