<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Specification_Add.aspx.cs" Inherits="Tayana.Back.Specification_Add" %>

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
    <h5>新增Specification</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="form-group row">
                <asp:Label ID="Label2" runat="server" class="col-sm-3 col-form-label"><h5>YachtsModel</h5></asp:Label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="YachtsModel" DataValueField="ID" class="form-control"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT [ID], [YachtsModel] FROM [YachartsInfo]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>Detail 標題: </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="AddDetailTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>Detail : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="DetailBox" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="Button1" runat="server" Text="新增" class="btn  btn-outline-secondary" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="返回" class="btn  btn-outline-primary mx-2" OnClick="Button2_Click" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
