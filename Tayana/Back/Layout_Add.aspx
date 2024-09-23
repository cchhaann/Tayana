<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Layout_Add.aspx.cs" Inherits="Tayana.Back.Layout_Add" %>

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
    <h3>新增Layout & deck plan</h3>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <div class="col-md-6 mx-2">
        <div class="form-group row">
            <div class="col-sm-9">
                <asp:Label ID="Label2" runat="server"><h5>YachtsModel</h5></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="YachtsModel" DataValueField="ID" class="form-control"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT [ID], [YachtsModel] FROM [YachartsInfo]"></asp:SqlDataSource>
            </div>
        </div>
        <div class="form-group row">
            <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>Layout & deck plan圖片: </h5></asp:Label>
            <div class="input-group">
                <asp:FileUpload ID="LayoutFileUpload" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
            </div>
        </div>
    </div>
    <br />
    <asp:Button ID="Button1" runat="server" Text="新增" class="btn  btn-outline-secondary" OnClick="Button1_Click" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
