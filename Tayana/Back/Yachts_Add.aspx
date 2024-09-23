<%@ Page Title="" Language="C#" MasterPageFile="~/Back/Site1.Master" AutoEventWireup="true" CodeBehind="Yachts_Add.aspx.cs" Inherits="Tayana.Back.Yachts_Add" %>

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
    <h5>新增Yachts</h5>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>Yachts Model : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="AddYachtsTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>New Design : </h5></asp:Label>
                <div class="col-sm-9" style="display: flex; align-items: center;">
                    <asp:CheckBox ID="CBoxIsNewDesign" runat="server" Text="New Design" Width="100%" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>New Building : </h5></asp:Label>
                <div class="col-sm-9" style="display: flex; align-items: center;">
                    <asp:CheckBox ID="CheckBoxNewBuilding" runat="server" Text="New Building" Width="100%" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>內容 : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="YachtsContentTextBox" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>Dimensions Name : </h5></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="DimensionsNameTextBox" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-3 col-form-label"><h5>Dimensions List : </h5></asp:Label>
                <table class="table table-hover">
                    <thead>
                        <tr class="table-info">
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal ID="LitDimensionsHtml" runat="server"></asp:Literal>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">Hull length</p>
                            </th>
                            <td>
                                <asp:TextBox ID="HullLengthTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">L.W.L.</p>
                            </th>
                            <td>
                                <asp:TextBox ID="LWLTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">B. MAX</p>
                            </th>
                            <td>
                                <asp:TextBox ID="BMAXTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">draft</p>
                            </th>
                            <td>
                                <asp:TextBox ID="draftTextBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">HeadRoom</p>
                            </th>
                            <td>
                                <asp:TextBox ID="HeadRoomTextBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">Standard draft</p>
                            </th>
                            <td>
                                <asp:TextBox ID="StandardDraftTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">Ballast</p>
                            </th>
                            <td>
                                <asp:TextBox ID="BallastTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">Displacement</p>
                            </th>
                            <td>
                                <asp:TextBox ID="DisplacementTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">Engine diesel</p>
                            </th>
                            <td>
                                <asp:TextBox ID="EngineDieselTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">Sail area</p>
                            </th>
                            <td>
                                <asp:TextBox ID="SailAreaTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">Cutter</p>
                            </th>
                            <td>
                                <asp:TextBox ID="CutterTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <p class="d-inline-block m-r-20">Designer</p>
                            </th>
                            <td>
                                <asp:TextBox ID="DesignerTBox" runat="server" type="text" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th>
                                <asp:Label ID="LabUpdateTitle" runat="server" Text="Click for Update"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabUpdateDimensionsList" runat="server" Text="*Upload Success!" ForeColor="green" class="d-flex justify-content-center" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <h6>Dimensions Banner圖:</h6>
            <div class="input-group my-3" style="flex-wrap: nowrap">
                <asp:FileUpload ID="FileUploadBanner" runat="server" class="btn btn-outline-primary btn-block" AllowMultiple="True" />
            </div>
            <br />
            <h6>Dimensions List圖:</h6>
            <div class="input-group my-3" style="flex-wrap: nowrap">
                <asp:FileUpload ID="FileUploadImg" runat="server" class="btn btn-outline-primary btn-block" />
            </div>
            <br />
            <h6>Dimensions File名稱:</h6>
            <div class="input-group my-3" style="flex-wrap: nowrap">
                <asp:TextBox ID="FileTextBox" runat="server" type="text" class="form-control"></asp:TextBox>
            </div>
            <h6>Downloads File :</h6>
            <asp:Literal ID="PDFpreview" runat="server"></asp:Literal>
            <div class="input-group my-3" style="flex-wrap: unset;">
                <asp:FileUpload ID="FileUploadPDF" runat="server" class="btn btn-outline-primary btn-block" />
            </div>
            <br />
        </div>
    </div>
    <br />
    <asp:Button ID="Button1" runat="server" Text="新增" class="btn  btn-outline-secondary" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="返回" class="btn  btn-outline-primary mx-2" OnClick="Button2_Click" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
