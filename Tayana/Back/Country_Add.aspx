<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Country_Add.aspx.cs" Inherits="Tayana.Back.Country_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3>新增國家</h3>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="form-group">
                <asp:Label ID="Country" runat="server" Text="Add Country"></asp:Label>
                <asp:TextBox ID="AddCountryTextBox" runat="server" class="form-control" placeholder="Enter Country Name"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="新增國家" class="btn  btn-primary" OnClick="Button1_Click"/>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
