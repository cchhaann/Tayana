<%@ Page Title="" Language="C#" MasterPageFile="~/Font/Site3.Master" AutoEventWireup="true" CodeBehind="YachYachtold.aspx.cs" Inherits="Tayana.Font.YachYacht" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/jquery.ad-gallery.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.ad-gallery.js"></script>
    <script type="text/javascript">
        $(function () {

            var galleries = $('.ad-gallery').adGallery();
            galleries[0].settings.effect = 'slide-hori';



        });
    </script>
</asp:Content>
<%-- 上方banner照片 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder10" runat="server">
    <img src="../images/banner01_masks.png" alt="&quot;&quot;" />
</asp:Content>

<%-- 輪播 --%>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="gallery" class="ad-gallery">
        <div class="ad-image-wrapper"></div>
        <div class="ad-controls" style="display: none"></div>
        <div class="ad-nav">
            <div class="ad-thumbs">
                <ul class="ad-thumb-list">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='<%# Eval("ImagUrl") %>'>
                                    <img src='<%# Eval("ImagUrl") %>' />
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>


<%-- 左側選單標題 --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <span>YACHTS</span>
</asp:Content>

<%-- 左側選單連結 --%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder12" runat="server">
    <asp:Literal ID="LeftMenu" runat="server"></asp:Literal>
</asp:Content>

<%-- 右上路徑 --%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder13" runat="server">
    <a href="YachYacht.aspx">
        <span class="on1">Yachts>></span>
        <span class="on1" id="LabLink" runat="server">Tayana 37</span>
    </a>
</asp:Content>

<%-- 上方TITTLE --%>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder14" runat="server">
    <span id="LabTittle" runat="server">Tayana 37</span>
</asp:Content>

<%--內容--%>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <!--次選單-->
    <div class="menu_y">
        <ul>
            <li class="menu_y00">YACHTS</li>
            <asp:Literal ID="TopMenuLinkHtml" runat="server"></asp:Literal>
<%--            <li><a class="menu_yli01" href="#">Interior</a></li>
            <li><a class="menu_yli02" href="#">Layout & deck pla</a>n</li>
            <li><a class="menu_yli03" href="#">Specification</a></li>--%>
        </ul>
    </div>
    <!--次選單-->

</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
