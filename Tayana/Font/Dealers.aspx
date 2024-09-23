<%@ Page Title="" Language="C#" MasterPageFile="~/Font/Site2.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="Tayana.Font.dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%-- 上方banner照片 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder10" runat="server">
    <img src="../images/DEALERSCOVER.jpg" alt="&quot;&quot;" width="967" height="371" />
</asp:Content>

<%-- 左側選單標題 --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <span>DEALERS</span>
</asp:Content>

<%-- 左側選單連結 --%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder12" runat="server">
    <asp:Literal ID="LeftMenu" runat="server"></asp:Literal>
</asp:Content>

<%-- 右上路徑 --%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder13" runat="server">
    <a href="dealers.aspx">
        <span class="on1">Dealers>></span>
        <span class="on1" id="LabLink" runat="server">Unite States</span>
    </a>
</asp:Content>

<%-- 上方TITTLE --%>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder14" runat="server">
    <span id="LabTittle" runat="server">Unite States</span>
</asp:Content>

<%--body 代理商圖片、資訊--%>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <ul>
        <asp:Literal ID="DealersLiteral" runat="server"></asp:Literal>
    </ul>
</asp:Content>

<%--body 代理商資訊--%>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

<%--body 下方頁碼--%>
<asp:Content ID="Content10" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
