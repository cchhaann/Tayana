<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Yachts_Layout.aspx.cs" Inherits="Tayana.Back.Yachts_Layout" %>

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
    <h5>Layout</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <asp:Button ID="Button1" runat="server" class="btn  btn-outline-primary mb-2" Text="新增Layout & deck plan" OnClick="Button1_Click" />
<%--    <asp:Button ID="Button2" runat="server" class="btn  btn-outline-primary mb-2" Text="修改Layout & deck plan" OnClick="Button2_Click"/>--%>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="YachtsModel" HeaderText="YachtsModel" SortExpression="YachtsModel" />
            <asp:BoundField DataField="LayoutImgPathJSON" HeaderText="LayoutImgPathJSON" SortExpression="LayoutImgPathJSON" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT Layout.ID, YachartsInfo.YachtsModel, Layout.LayoutImgPathJSON FROM Layout INNER JOIN YachartsInfo ON YachartsInfo.ID = Layout.YachtsModelID"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
