<%@ Page Title="" Language="C#" MasterPageFile="~/Font/Site3.Master" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="Tayana.Font.NewsDetails1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <div class="box2_list">
        <ul>
            <asp:Literal ID="NewsDetailsLiteral" runat="server"></asp:Literal>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
