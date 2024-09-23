<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Dealer_Add.aspx.cs" Inherits="Tayana.Back.Dealer_Add" %>

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
    <h3>新增經銷商</h3>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>經銷商公司名 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="DealerNameTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>請選擇國家 :</h5></asp:Label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT * FROM [CountrySort]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>請選擇地區 :</h5></asp:Label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" DataSourceID="SqlDataSource2" DataTextField="AreaName" DataValueField="ID"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT CountryArea.ID, CountrySort.Name, CountryArea.AreaName FROM CountryArea INNER JOIN CountrySort ON CountrySort.ID = CountryArea.CountryId"></asp:SqlDataSource>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>聯絡人 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="ContactNameTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>公司地址 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="AddressTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>電話 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="PhoneTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>Fax : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="FaxTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>Mail : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="MailTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>公司網頁 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="LinkTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <asp:Label runat="server"><h5>經銷商照片 : </h5></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
<%--            <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" />--%>
            <br />
        </div>
    </div>
    <br />
    <asp:Button ID="Button1" runat="server" Text="新增" class="btn  btn-outline-secondary" OnClick="Button1_Click" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

