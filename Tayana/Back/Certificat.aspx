<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Certificat.aspx.cs" Inherits="Tayana.Back.Certificat" MaintainScrollPositionOnPostback="True" %>

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
    <h5>Certificat</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <h6>Certificat內容:</h6>
    <asp:TextBox ID="certificatTbox" runat="server" type="text" class="form-control" placeholder="Enter certificat text" TextMode="MultiLine" Height="200px"></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Text="上傳Certificat內容" class="btn  btn-primary btn-sm mt-3 mb-3" OnClick="AddCertificatBtn_Click" />
    <asp:Label ID="Label1" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
    <asp:Button ID="uploadCertificatBtn" runat="server" Text="更新Certificat內容" class="btn  btn-secondary btn-sm mt-3 mb-3" OnClick="uploadCertificatBtn_Click" />
    <asp:Label ID="uploadCertificatLab" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
    <br/>
    <h6>上傳圖片:</h6>
    <div class="input-group my-3" style="flex-wrap: nowrap">
        <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
        <asp:Button ID="Button1" runat="server" Text="Upload" class="btn btn-primary" OnClick="UploadButton" />
    </div>
    <h6>圖片列表:</h6>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" class="my-3 mx-auto" RepeatDirection="Horizontal" RepeatColumns="2" AutoPostBack="True" CellPadding="10"  OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"></asp:RadioButtonList>
    <asp:Button ID="DelHImageBtn" runat="server" Text="刪除 Image" type="button" class="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" Visible="False" OnClick="DelHImageBtn_Click" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
