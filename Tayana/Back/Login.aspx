<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site2Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tayana.Back.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<%-- 帳號 MayDay(一般) --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="form-group mb-3">
        <asp:TextBox ID="TextBox2" runat="server" class="form-control" required="required" placeholder="帳號"></asp:TextBox>
    </div>
</asp:Content>

<%--密碼 mayday530--%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="form-group mb-4">
        <asp:TextBox ID="TextBox1" runat="server" class="form-control" TextMode="Password" required="required" placeholder="密碼"></asp:TextBox>
    </div>
    <div class="form-group mb-4">
        <asp:Label ID="Label4" runat="server" ForeColor="Red" ></asp:Label>
    </div>
</asp:Content>

<%-- 登入 --%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Sign up" class="btn btn-primary btn-block mb-4" OnClick="Button1_Click" />
</asp:Content>
