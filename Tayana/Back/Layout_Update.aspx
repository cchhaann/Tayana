<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Layout_Update.aspx.cs" Inherits="Tayana.Back.Layout_Update" %>

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
    <h5>Layout更新</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <h6>YachtsModel:</h6>
    <div class="form-group row">
        <div class="col-sm-9">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="YachtsModel" DataValueField="YachtsModelID" class="form-control"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT Layout.YachtsModelID, YachartsInfo.YachtsModel FROM YachartsInfo INNER JOIN Layout ON YachartsInfo.ID = Layout.YachtsModelID"></asp:SqlDataSource>
        </div>
    </div>
    <h6>上傳圖片:</h6>
    <div class="input-group my-3" style="flex-wrap: nowrap">
        <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
        <asp:Button ID="Button1" runat="server" Text="Upload" class="btn btn-primary" />
    </div>
    <h6>圖片列表:</h6>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" class="my-3 mx-auto" RepeatDirection="Horizontal" RepeatColumns="2" AutoPostBack="True" CellPadding="10"></asp:RadioButtonList>
    <asp:Button ID="DelHImageBtn" runat="server" Text="刪除 Image" type="button" class="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" Visible="False" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
