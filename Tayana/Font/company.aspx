<%@ Page Title="" Language="C#" MasterPageFile="~/Font/Site3.Master" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="Tayana.Font.company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%-- 上方banner照片 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder10" runat="server">
    <img src="../images/newbanner.jpg" alt="&quot;&quot;" width="967" height="371" />
</asp:Content>

<%-- 左側選單標題 --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <span>COMPANY</span>
</asp:Content>

<%-- 左側選單連結 --%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder12" runat="server">
    <asp:Literal ID="LeftMenu" runat="server"></asp:Literal>
</asp:Content>

<%-- 右上路徑 --%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder13" runat="server">
    <a href="company.aspx">
        <span class="on1">Company>></span>
        <span class="on1" id="LabLink" runat="server">About Us</span>
    </a>
</asp:Content>

<%-- 上方TITTLE --%>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder14" runat="server">
    <span id="LabTittle" runat="server">About Us</span>
</asp:Content>

<%--內容--%>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <div class="box2_list">
        <asp:Literal ID="AboutContent" runat="server" Mode="PassThrough"></asp:Literal>
    </div>
    <div class="box3">
        <asp:Literal ID="CertificatContent" runat="server"></asp:Literal>
        <br />
        <br />
        <div class="pit">
            <ul style="display: flex; flex-direction: column; align-items: flex-start;">
                <asp:Literal ID="LoadContentImgV" runat="server"></asp:Literal>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
