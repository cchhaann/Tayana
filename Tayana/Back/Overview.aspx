<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="Tayana.Back.Overview" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/4.1.392/pdf.min.mjs"></script>
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
    <h5>Yachts Overview</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <h6>YachYacht Model :</h6>
    <asp:DropDownList ID="DListModel" runat="server" DataSourceID="SqlDataSource1" DataTextField="YachtsModel" DataValueField="ID" OnSelectedIndexChanged="DListModel_SelectedIndexChanged" class="form-control"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT [ID], [YachtsModel] FROM [YachartsInfo]"></asp:SqlDataSource>
    <hr />
    <h6>Dimensions Image :</h6>
    <div class="input-group my-3" style="flex-wrap: unset;">
        <asp:FileUpload ID="DimImgUpload" runat="server" class="btn btn-outline-primary btn-block" />
    </div>
    <hr />
    <h6>Main Content :</h6>
    <asp:TextBox ID="YachtsContentTextBox" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
    <asp:Label ID="LabUploadMainContent" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
    <asp:Button ID="BtnUploadMainContent" runat="server" Text="Upload Overview Content" class="btn btn-outline-primary btn-block mt-3" OnClick="BtnUploadMainContent_Click" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
