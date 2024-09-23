<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Area_Add.aspx.cs" Inherits="Tayana.Back.Area_Add" %>

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
    <h3>新增區域</h3>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <div class="col-sm-12">
        <div class="form-group">
            <h5>
                <asp:Label ID="Label2" runat="server">請選擇國家別</asp:Label></h5>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" class="form-control"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT * FROM [CountrySort]"></asp:SqlDataSource>
            <br/>
            <h5><asp:Label ID="Country" runat="server" Text="區域"></asp:Label></h5>
            <asp:TextBox ID="AddAreaTextBox" runat="server" class="form-control" placeholder="Enter Area"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="新增Area" class="btn  btn-primary" OnClick="Button1_Click"/>
    </div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
