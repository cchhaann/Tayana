<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Tayana.Back.News" %>

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
    <h5>News & Events</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <asp:Button ID="Button1" runat="server" class="btn  btn-outline-primary mb-2" Text="新增News & Events" OnClick="Button1_Click" />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" >
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:TemplateField HeaderText="NewsThumbnail" SortExpression="NewsThumbnail">
                <EditItemTemplate>
                    <asp:TextBox ID="ThumbnailTextBox" runat="server" Text='<%# Bind("NewsThumbnail") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("NewsThumbnail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NewsImage" SortExpression="NewsImage">
                <EditItemTemplate>
                    <asp:TextBox ID="NewsImageTextBox" runat="server" Text='<%# Bind("NewsImage") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("NewsImage") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NewsTittle" SortExpression="NewsTittle">
                <EditItemTemplate>
                    <asp:TextBox ID="NewsTittleTextBox" runat="server" Text='<%# Bind("NewsTittle") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("NewsTittle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NewsContent" SortExpression="NewsContent">
                <EditItemTemplate>
                    <asp:TextBox ID="NewsContentTextBox" runat="server" Text='<%# Bind("NewsContent") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("NewsContent") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NewsDate" SortExpression="NewsDate">
                <EditItemTemplate>
                    <asp:TextBox ID="NewsDateTextBox" runat="server" Text='<%# Bind("NewsDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("NewsDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="IsTop" HeaderText="IsTop" SortExpression="IsTop" />
            <asp:BoundField DataField="CreateTime" HeaderText="CreateTime" SortExpression="CreateTime" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT * FROM [News]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
