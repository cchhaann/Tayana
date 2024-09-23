<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="DealerList.aspx.cs" Inherits="Tayana.Back.DealerList" %>

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
    <h5>經銷商列表</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <asp:Button ID="Button1" runat="server" class="btn  btn-outline-primary mb-2" Text="新增經銷商" OnClick="Button1_Click"/>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" >
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="AreaName" HeaderText="AreaName" SortExpression="AreaName" />
            <asp:TemplateField HeaderText="DealerImgPath" SortExpression="DealerImgPath">
                <EditItemTemplate>
                    <asp:TextBox ID="DealerImgPathTextBox" runat="server" Text='<%# Bind("DealerImgPath") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("DealerImgPath") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DealerName" SortExpression="DealerName">
                <EditItemTemplate>
                    <asp:TextBox ID="DealerNameTextBox" runat="server" Text='<%# Bind("DealerName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DealerName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contant" SortExpression="Contant">
                <EditItemTemplate>
                    <asp:TextBox ID="ContantTextBox" runat="server" Text='<%# Bind("Contant") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Contant") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address" SortExpression="Address">
                <EditItemTemplate>
                    <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TEL" SortExpression="TEL">
                <EditItemTemplate>
                    <asp:TextBox ID="TELTextBox" runat="server" Text='<%# Bind("TEL") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("TEL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fax" SortExpression="Fax">
                <EditItemTemplate>
                    <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Fax") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mail" SortExpression="Mail">
                <EditItemTemplate>
                    <asp:TextBox ID="MailTextBox" runat="server" Text='<%# Bind("Mail") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Mail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Link" SortExpression="Link">
                <EditItemTemplate>
                    <asp:TextBox ID="LinkTextBox" runat="server" Text='<%# Bind("Link") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Link") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaYachtConnectionString %>" SelectCommand="SELECT Dealer.ID, CountrySort.Name, CountryArea.AreaName, Dealer.DealerImgPath, Dealer.DealerName, Dealer.Contant, Dealer.Address, Dealer.TEL, Dealer.Fax, Dealer.Mail, Dealer.Link FROM Dealer INNER JOIN CountrySort ON CountrySort.ID = Dealer.CountryId INNER JOIN CountryArea ON CountryArea.ID = Dealer.AreaId"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
