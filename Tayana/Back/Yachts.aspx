<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Yachts.aspx.cs" Inherits="Tayana.Back.Yachts" %>

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
    <h5>Yachts</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <asp:Button ID="Button1" runat="server" class="btn  btn-outline-primary mb-2" Text="新增Yachart" OnClick="Button1_Click"/>
    <asp:Button ID="Button2" runat="server" class="btn  btn-outline-primary mb-2" Text="修改Yachart型號" OnClick="Button2_Click"/>
    <asp:Button ID="Button3" runat="server" class="btn  btn-outline-primary mb-2" Text="修改Overview" OnClick="Button3_Click"/>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="YachtsModel" HeaderText="YachtsModel" SortExpression="YachtsModel" />
            <asp:CheckBoxField DataField="isNewDesign" HeaderText="isNewDesign" SortExpression="isNewDesign" />
            <asp:CheckBoxField DataField="isNewBuilding" HeaderText="isNewBuilding" SortExpression="isNewBuilding" />
            <asp:BoundField DataField="YachtsContent" HeaderText="YachtsContent" SortExpression="YachtsContent" />
            <asp:BoundField DataField="HullLength" HeaderText="HullLength" SortExpression="HullLength" />
            <asp:BoundField DataField="LWL" HeaderText="LWL" SortExpression="LWL" />
            <asp:BoundField DataField="BMAX" HeaderText="BMAX" SortExpression="BMAX" />
            <asp:BoundField DataField="StandardDraft" HeaderText="StandardDraft" SortExpression="StandardDraft" />
            <asp:BoundField DataField="Ballast" HeaderText="Ballast" SortExpression="Ballast" />
            <asp:BoundField DataField="Displacement" HeaderText="Displacement" SortExpression="Displacement" />
            <asp:BoundField DataField="EngineDiesel" HeaderText="EngineDiesel" SortExpression="EngineDiesel" />
            <asp:BoundField DataField="SailArea" HeaderText="SailArea" SortExpression="SailArea" />
            <asp:BoundField DataField="Cutter" HeaderText="Cutter" SortExpression="Cutter" />
            <asp:BoundField DataField="Designer" HeaderText="Designer" SortExpression="Designer" />
            <asp:BoundField DataField="BannerImgPathJSON" HeaderText="BannerImgPathJSON" SortExpression="BannerImgPathJSON" />
            <asp:BoundField DataField="ImgPath" HeaderText="ImgPath" SortExpression="ImgPath" />
            <asp:BoundField DataField="DimensionsImg" HeaderText="DimensionsImg" SortExpression="DimensionsImg" />
            <asp:BoundField DataField="DownloadsFileName" HeaderText="DownloadsFileName" SortExpression="DownloadsFileName" />
            <asp:BoundField DataField="DownloadsFile" HeaderText="DownloadsFile" SortExpression="DownloadsFile" />
            <asp:BoundField DataField="CreateTime" HeaderText="CreateTime" SortExpression="CreateTime" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT * FROM [YachartsInfo]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
