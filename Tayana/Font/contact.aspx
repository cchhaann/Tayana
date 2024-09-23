<%@ Page Title="" Language="C#" MasterPageFile="~/Font/Site1.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Tayana.Font.contact" %>

<%@ Register Assembly="Recaptcha.Web" Namespace="Recaptcha.Web.UI.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<%-- 表單上方banner照片 --%>
<asp:Content ID="Content11" ContentPlaceHolderID="ContentPlaceHolder10" runat="server">
    <img src="../images/contact.jpg" alt="&quot;&quot;" width="967" height="371" />
</asp:Content>

<%-- 表單右上路徑 --%>
<asp:Content ID="Content14" ContentPlaceHolderID="ContentPlaceHolder13" runat="server">
    <a href="contact.aspx">
        <span class="on1">Contact</span>
    </a>
</asp:Content>

<%-- 表單左側選單標題 --%>
<asp:Content ID="Content12" ContentPlaceHolderID="ContentPlaceHolder11" runat="server">
    <span>CONTACT</span>
</asp:Content>

<%-- 表單左側選單連結 --%>
<asp:Content ID="Content13" ContentPlaceHolderID="ContentPlaceHolder12" runat="server">
    <li><a href="contact.aspx">contacts</a></li>
</asp:Content>

<%-- 表單上方TITTLE --%>
<asp:Content ID="Content15" ContentPlaceHolderID="ContentPlaceHolder14" runat="server">
    <span>Contact</span>
</asp:Content>

<%-- 表單 Name --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:TextBox runat="server" name="Name" type="text" ID="Name" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
</asp:Content>

<%-- 表單 Email --%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:TextBox runat="server" name="Email" type="text" ID="Email" class="{validate:{required:true, email:true, messages:{required:'Required', email:'Please check the E-mail format is correct'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
</asp:Content>

<%-- 表單 Phone --%>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:TextBox runat="server" name="Phone" type="text" ID="Phone" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
</asp:Content>

<%-- 表單 Country --%>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <asp:DropDownList ID="CountryList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:TayanaYachtConnectionString %>' ProviderName='<%$ ConnectionStrings:TayanaYachtConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [CountrySort]"></asp:SqlDataSource>
</asp:Content>

<%-- 表單 YACHTS --%>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <asp:DropDownList name="Yachts" ID="Yachts" runat="server" DataTextField="type" DataValueField="type"></asp:DropDownList>
</asp:Content>

<%-- 表單 Comments --%>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
    <asp:TextBox ID="Comments" runat="server" TextMode="MultiLine" Columns="45" Rows="5"></asp:TextBox>
</asp:Content>

<%-- 表單 機器人驗證 --%>
<asp:Content ID="Content16" ContentPlaceHolderID="ContentPlaceHolder15" runat="server">
    <!-- Render recaptcha API script (非必要，同頁使用兩個以上時才需要)-->
    <cc1:RecaptchaApiScript ID="RecaptchaApiScript1" runat="server" />
    <!-- Render recaptcha widget -->
    <cc1:RecaptchaWidget ID="Recaptcha1" runat="server" RenderApiScript="False" />
    <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red"></asp:Label>
</asp:Content>

<%-- 表單 送出 --%>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
    <a href="#">
        <asp:ImageButton ID="ImageButton1" runat="server" src="../images/buttom03.gif" alt="submit" Width="59" Height="25" OnClick="ImageButton1_Click" />
    </a>
</asp:Content>

<%-- 下方頁面 --%>
<asp:Content ID="Content10" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
    <div class="box1">
        <span class="span02">Contact with us</span><br />
        Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
                            As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
                            If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
    </div>
    <div class="list03">
        <p>
            <span>TAYANA HEAD OFFICE</span><br />
            NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
            tel. +886(7)641 2422<br />
            fax. +886(7)642 3193<br />
            info@tayanaworld.com<br />
        </p>
    </div>
    <div class="list03">
        <p>
            <span>SALES DEPT.</span><br />
            +886(7)641 2422  ATTEN. Mr.Basil Lin<br />
            <br />
        </p>
    </div>
    <div class="box4">
        <h4>Location</h4>
        <p>
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d14730.759082337467!2d120.29208358763076!3d22.628057144601026!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x346e0491c81682db%3A0xa22784fb40b817fa!2zODAw6auY6ZuE5biC5paw6IiI5Y2A5rCR55Sf5LiA6LevNTbomZ8yIOS5iyAy!5e0!3m2!1szh-TW!2stw!4v1712031143331!5m2!1szh-TW!2stw" width="695" height="518" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </p>
    </div>
</asp:Content>


