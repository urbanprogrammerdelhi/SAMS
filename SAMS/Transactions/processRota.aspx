<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" ValidateRequest="false"
    CodeFile="processRota.aspx.cs" Inherits="Transactions_processRota" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="width: 700px;">
                            <div class="squarebox">
                                <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                                    <div style="float: left; width: 670px;">
                                        <tt style="text-align: center;">
                                            <asp:Label ID="Label5" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, ProcessRota %>"></asp:Label></tt></div>
                                </div>
                                <div class="squareboxcontent">
                                    <table border="0" cellpadding="1" cellspacing="1" style="width: 700px">
                                        <%--                                        <tr>
                                            <td align="right" style="height: 27px">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="Label1" runat="server"
                                                    Text="Select Period"></asp:Label>
                                            </td>
                                            <td align="left" style="height: 27px" >
                                                <asp:DropDownList ID="ddlPayPeriod" runat="server" CssClass="cssDropDown" Width="122" AutoPostBack="true" OnSelectedIndexChanged="ddlPayPeriod_SelectedIndexChanged"  >                                                   
                                                </asp:DropDownList>
                                            </td>                                            
                                         </tr>
--%>
                                        <tr>
                                            <td align="right">
                                                <asp:Label Style="width: 100px" CssClass="cssLable" ID="lblMonth" runat="server"
                                                    Text="<%$ Resources:Resource, MonthYear %>"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" Width="80"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                    <asp:ListItem Text="<%$ Resources:Resource,January%>" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,February%>" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,March%>" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,April%>" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,May%>" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,June%>" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,July%>" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,August%>" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,September%>" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,October%>" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,November%>" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="<%$ Resources:Resource,December%>" Value="12"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtYear" OnTextChanged="txtYear_OnTextChanged" runat="server" AutoPostBack="true"
                                                    CssClass="csstxtboxSmall" Text="" MaxLength="4" Width="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label CssClass="cssLable" ID="lblFromdate" runat="server" Text="<%$ Resources:Resource,FromDate%>"
                                                    Enabled="false"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="csstxtbox" Text="" ID="txtFromDate" runat="server" Enabled="false"
                                                    AutoPostBack="true" Width="90"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label Style="width: 200px" CssClass="cssLable" ID="lblToDate" runat="server"
                                                    Text="<%$ Resources:Resource,ToDate%>" Enabled="false"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox CssClass="csstxtbox" Text="" ID="txtToDate" runat="server" Enabled="false"
                                                    AutoPostBack="true" Width="90"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left" height="30">
                                                <asp:Button ID="btnProcess" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource,Process%>"
                                                    OnClick="btnProcess_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <br>
                                                <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                <br>
                                                <Ajax:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                Please wait.....<img alt="" src="../Images/spinner.gif" />
                                                </ProgressTemplate>
                                                </Ajax:UpdateProgress>
                                            </td>
                                            <td>
                                             <asp:HiddenField ID="HDFromDate" runat="server" Value="" />
                                             <asp:HiddenField ID="HDToDate" runat="server" Value="" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
