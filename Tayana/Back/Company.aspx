<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="Tayana.Back.Company" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


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
    <h5>Company About</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="../Scripts/ckeditor/"
        Toolbar="Bold|Italic|Underline|Strike|Subscript|Superscript|-|RemoveFormat
        NumberedList|BulletedList|-|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|BidiLtr|BidiRtl
        /
        Styles|Format|Font|FontSize
        TextColor|BGColor
        Link|Image"
        Height="400px">
    </CKEditor:CKEditorControl>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    <asp:Label ID="UploadAboutUsLab" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="新增" class="btn  btn-primary btn-sm mt-3 mb-3" OnClick="Button1_Click" />
    <asp:Button ID="UploadAboutUsBtn" runat="server" Text="更新 About Us Content" class="btn  btn-primary btn-sm mt-3 mb-3" OnClick="UploadAboutUsBtn_Click" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
