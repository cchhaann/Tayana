<%@ Page Title="" Language="C#" MasterPageFile="~/Font/Yach.Master" AutoEventWireup="true" CodeBehind="Yachts_Specification.aspx.cs" Inherits="Tayana.Font.Specification" %>

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
    <script type="text/javascript">
        $(function () {
            $('.topbuttom').click(function () {
                $('html, body').scrollTop(0);

            });

        });
    </script>

</asp:Content>
<%-- 上方banner照片 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder10" runat="server">
    <img src="../images/banner01_masks.png" alt="&quot;&quot;" />

</asp:Content>

<%-- 輪播 --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div id="gallery" class="ad-gallery">
        <div class="ad-image-wrapper"></div>
        <div class="ad-controls" style="display: none"></div>
        <div class="ad-nav">
            <div class="ad-thumbs">
                <ul class="ad-thumb-list">
                    <asp:Repeater ID="RepeaterImg" runat="server">

                        <ItemTemplate>

                            <li>
                                <a href='<%# Container.DataItem %>'>
                                    <img src='<%# Container.DataItem %>' class="imag0" alt="" style="height: 59px" />
                                </a>
                            </li>

                        </ItemTemplate>

                    </asp:Repeater>

                </ul>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <span>YACHTS</span>
</asp:Content>

<%-- 左側選單連結 --%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder12" runat="server">
    <asp:Literal ID="LeftMenu" runat="server"></asp:Literal>
</asp:Content>

<%-- 右上路徑 --%>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder13" runat="server">
    <a href="YachYacht.aspx">
        <span class="on1">Yachts>></span>
        <span class="on1" id="LabLink" runat="server">Tayana 37</span>
    </a>
</asp:Content>

<%-- 上方TITTLE --%>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder14" runat="server">
    <span id="LabTittle" runat="server">Tayana 37</span>
</asp:Content>

<%--次選單--%>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Literal ID="TopMenuLink" runat="server"></asp:Literal>
</asp:Content>

<%--內容--%>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <div class="box5">
        <h4>DETAIL SPECIFICATION</h4>
        <asp:Literal ID="ContentHtml" runat="server"></asp:Literal>
    </div>
    <div class="clear"></div>
    <p class='topbuttom'>
        <img src='../images/top.gif' alt="top" />
    </p>
</asp:Content>

<asp:Content ID="Content10" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
