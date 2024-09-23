<%@ Page Title="" Language="C#" MasterPageFile="~/Font/Site4.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tayana.Font.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%-- 上方banner照片 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder10" runat="server">
    <img src="../images/banner00_masks.png" alt="&quot;&quot;" width="967" height="371" />
</asp:Content>


<%-- 換圖開始 --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Literal ID="LiteralBanner" runat="server"></asp:Literal>
<%--    <li class="info on">
        <a href="#">
            <img src="../images/banner001b.jpg" /></a><!--文字開始-->
        <div class="wordtitle">
            TAYANA <span>48</span><br />
            <p>SPECIFICATION SHEET</p>
        </div>
        <!--文字結束-->
    </li>
    <li class="info">
        <a href="#">
            <img src="../images/banner002b.jpg" /></a><!--文字開始-->
        <div class="wordtitle">
            TAYANA <span>54</span><br />
            <p>SPECIFICATION SHEET</p>
        </div>
        <!--文字結束-->
        <!--新船型開始  54型才出現其於隱藏 -->
        <div class="new">
            <img src="../images/new01.png" alt="new" /></div>
        <!--新船型結束-->
    </li>
    <li class="info">
        <a href="#">
            <img src="../images/banner003b.jpg" /></a><!--文字開始-->
        <div class="wordtitle">
            TAYANA <span>37</span><br />
            <p>SPECIFICATION SHEET</p>
        </div>
        <!--文字結束-->
    </li>
    <li class="info">
        <a href="#">
            <img src="../images/banner004b.jpg" /></a><!--文字開始-->
        <div class="wordtitle">
            TAYANA <span>64</span><br />
            <p>SPECIFICATION SHEET</p>
        </div>
        <!--文字結束-->
    </li>
    <li class="info">
        <a href="#">
            <img src="../images/banner005b.jpg" /></a><!--文字開始-->
        <div class="wordtitle">
            TAYANA <span>58</span><br />
            <p>SPECIFICATION SHEET</p>
        </div>
        <!--文字結束-->
    </li>
    <li class="info">
        <a href="#">
            <img src="../images/banner006b.jpg" /></a><!--文字開始-->
        <div class="wordtitle">
            TAYANA <span>55</span><br />
            <p>SPECIFICATION SHEET</p>
        </div>
        <!--文字結束-->
    </li>--%>
    <!--文字結束-->
</asp:Content>

<%-- 小圖開始 --%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Literal ID="LiteralNum" runat="server"></asp:Literal>
</asp:Content>

<%-- news --%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <li>
        <div class="newstop">
            <asp:Image ID="ImgIsTop1" runat="server" ImageUrl="../images/new_top01.png" alt="top" Visible="false" AlternateText="&quot;&quot" style="position: absolute;top: 592px;z-index:1;"  />
        </div>
        <div class="news01">
            <asp:Literal ID="news01Literal" runat="server"></asp:Literal>
            <div class="news02p1">
                <p class="news02p1img">
                    <asp:Literal ID="Literalimg" runat="server"></asp:Literal>
                </p>
            </div>
            <p class="news02p2">
                <span>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </span>
                <span>
                    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                </span>
            </p>
            <input type="hidden" value='0' />
        </div>
    </li>
    <!--TOP第一則最新消息結束-->
    <!--第二則-->
    <li>
        <div class="newstop">
            <asp:Image ID="Image1" runat="server" ImageUrl="../images/new_top01.png" alt="top" Visible="false" AlternateText="&quot;&quot" style="position: absolute;top: 592px;z-index:1;" />
        </div>
        <div class="news01">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <div class="news02p1">
                <p class="news02p1img">
                    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                </p>
            </div>
            <p class="news02p2">
                <span>
                    <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                </span>
                <span>
                    <asp:HyperLink ID="HyperLink2" runat="server">HyperLink</asp:HyperLink>
                </span>
            </p>
            <input type="hidden" value='0' />
        </div>
    </li>
    <!--第二則結束-->
    <li>
        <div class="newstop">
            <asp:Image ID="Image2" runat="server" ImageUrl="../images/new_top01.png" alt="top" Visible="false" AlternateText="&quot;&quot" style="position: absolute;top: 592px;z-index:1;" />
        </div>
        <div class="news01">
            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
            <div class="news02p1">
                <p class="news02p1img">
                    <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                </p>
            </div>
            <p class="news02p2">
                <span>
                    <asp:Literal ID="Literal7" runat="server"></asp:Literal>
                </span>
                <span>
                    <asp:HyperLink ID="HyperLink3" runat="server">HyperLink</asp:HyperLink>
                </span>
            </p>
            <input type="hidden" value='0' />
        </div>
    </li>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
