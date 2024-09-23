<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="News_Add.aspx.cs" Inherits="Tayana.Back.News_Add" %>

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
    <h3>新增News & Events</h3>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>標題 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="NewsTittleTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>置頂 : </h5></asp:Label>
                <div class="col-sm-9" style="display: flex; align-items: center;">
                    <asp:CheckBox ID="CBoxIsTop" runat="server" Text="Top Tag" Width="100%" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>日期 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>內容 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="NewsContentTextBox" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <h6>縮圖:</h6>
            <div class="input-group my-3" style="flex-wrap: nowrap">
                <asp:FileUpload ID="FileUpload2" runat="server" class="btn btn-outline-primary btn-block"/>
            </div>
            <br />
            <h6>上傳圖片:</h6>
            <div class="input-group my-3" style="flex-wrap: nowrap">
                <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
            </div>
            <br />
        </div>
    </div>
    <br />
    <asp:Button ID="Button1" runat="server" Text="新增" class="btn  btn-outline-secondary" OnClick="AddBtn_Click" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
