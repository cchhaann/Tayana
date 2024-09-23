 <%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Yachts_Specification.aspx.cs" Inherits="Tayana.Back.Specification" %>

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
    <h5>Specification</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <asp:Button ID="Button1" runat="server" class="btn  btn-outline-primary mb-2" Text="新增Specification" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="YachtsModel" HeaderText="YachtsModel" SortExpression="YachtsModel" />
            <asp:TemplateField HeaderText="DetailTittle" SortExpression="DetailTittle">
                <EditItemTemplate>
                    <asp:TextBox ID="DetailTittleTextBox" runat="server" Text='<%# Bind("DetailTittle") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("DetailTittle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Detail" SortExpression="Detail">
                <EditItemTemplate>
                    <asp:TextBox ID="DetailTextBox" runat="server" Text='<%# Bind("Detail") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Detail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreateTime" HeaderText="CreateTime" SortExpression="CreateTime" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT Specification.ID, YachartsInfo.YachtsModel, Specification.DetailTittle, Specification.Detail, Specification.CreateTime FROM Specification INNER JOIN YachartsInfo ON YachartsInfo.ID = Specification.YachtsModelID"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
