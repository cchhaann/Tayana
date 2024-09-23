<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Users_Add.aspx.cs" Inherits="Tayana.Back.Users_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h5>新增使用者</h5>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="form-group">
                <asp:Label ID="AccountLabel" runat="server" Text="Account"></asp:Label>
                <asp:TextBox ID="AddAccountTextBox" runat="server" class="form-control" placeholder="Enter Account"></asp:TextBox>
                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <div class="form-group">
                <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="AddPasswordTextBox" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="新增使用者" class="btn  btn-primary" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
