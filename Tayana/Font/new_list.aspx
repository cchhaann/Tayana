<%@ Page Title="" Language="C#" MasterPageFile="~/Font/Site2.Master" AutoEventWireup="true" CodeBehind="new_list.aspx.cs" Inherits="Tayana.Font.new_list" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        div#pagination {
            height: 50px;
            margin-top: 3px;
        }

            div#pagination .count {
                float: left;
                padding: 5px;
            }

            div#pagination .pages {
                float: right;
                padding: 5px;
            }

        div#paginationTop .count {
            float: left;
            padding: 5px;
        }

        div#paginationTop .pages {
            float: right;
            padding: 5px;
        }

        div.pagination {
            padding: 0px;
            margin: 0px;
        }

            div.pagination a {
                padding: 2px 5px 2px 5px;
                margin: 2px;
                border: 1px solid #8dab68;
                text-decoration: none; /* no underline */
                color: #5f7f39;
            }

                div.pagination a:hover, div.pagination a:active {
                    border: 1px solid #5f7f39;
                    color: #000;
                }

            div.pagination span.current {
                padding: 2px 5px 2px 5px;
                margin: 2px;
                border: 1px solid #5f7f39;
                font-weight: bold;
                background-color: #5f7f39;
                color: #FFF;
            }

            div.pagination span.disabled {
                padding: 2px 5px 2px 5px;
                margin: 2px;
                border: 1px solid #EEE;
                color: #DDD;
            }

        .bold14 {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: bold;
        }

        .rederror {
            color: red;
        }
    </style>
</asp:Content>

<%-- 上方banner照片 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder10" runat="server">
    <img src="../images/newbanner.jpg" alt="&quot;&quot;" width="967" height="371" />
</asp:Content>

<%-- 左側選單標題 --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <span>News</span>
</asp:Content>

<%-- 左側選單連結 --%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder12" runat="server">
    <li>
        <a href="new_list.aspx">News & Events</a>
    </li>
</asp:Content>

<%-- 右上路徑 --%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder13" runat="server">
    <a href="new_list.aspx">
        <span class="on1">News>></span>
        <span class="on1" id="LabLink" runat="server">News & Events</span>
    </a>
</asp:Content>

<%-- 上方TITTLE --%>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder14" runat="server">
    <span id="LabTittle" runat="server">News & Events</span>
</asp:Content>

<%--內容--%>
<%--body 遊艇圖片、資訊、頁碼--%>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <ul>
        <asp:Literal ID="NewsLiteral" runat="server"></asp:Literal>
    </ul>
    <div class="pagenumber">
        <uc1:WebUserControl1 runat="server" ID="WebUserControl_Page" />
    </div>
</asp:Content>

<%--body 遊艇資訊--%>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>


<asp:Content ID="Content10" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>


<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
