<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site2Login.Master" AutoEventWireup="true" CodeBehind="BackLogin.aspx.cs" Inherits="Tayana.Back.BackLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<%-- 帳號  mayday530--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:TextBox ID="Account" runat="server" class="form-control" required="required" placeholder="帳號"></asp:TextBox>
</asp:Content>

<%-- 密碼 --%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control" required="required" placeholder="密碼"></asp:TextBox>
</asp:Content>

<%--登入--%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:Button ID="LoginBtn" class="btn btn-block btn-primary mb-4" runat="server" Text="登入" OnClick="LoginBtn_Click"/>
    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>

