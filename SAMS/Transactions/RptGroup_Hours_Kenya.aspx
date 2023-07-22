<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptGroup_hours_Kenya.aspx.cs" Inherits="Sales_RptGroup_Hours_Kenya" Title="<%$ Resources:Resource, AppTitle %>" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" border="0" cellpadding="1" cellspacing="0">
        <tr>
            <td align="center" style="width: 100%">
                <asp:Panel ID="PanelReportType" Width="700px" GroupingText="<%$Resources:Resource,HoursComparison %>"
                    BorderWidth="0px" runat="server" BorderStyle="Solid" EnableTheming="true">
                    <asp:Panel ID="Panel1" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label7" runat="server" Text="<%$Resources:Resource,ReportType %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlReportName" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelDivision" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Resource, HrLocation %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelBranch" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Resource, Branch %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlBranch" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"  AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAreaID" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0"> 
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="lblArea" runat="server" Text="<%$Resources:Resource,Area %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList Width="120px" ID="ddlAreaID" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged" runat="server" CssClass="cssDropDown">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelMonth" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label20" runat="server" Text="<%$ Resources:Resource, Month %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" Width="150px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                                    <asp:TextBox ID="txtYear"  MaxLength = "4" runat="server" Width="100px" CssClass="csstxtbox" AutoPostBack="True"
                                        OnKeyUp="javascript:validateNumeric(this);" OnTextChanged="txtYear_TextChanged"></asp:TextBox>
                                     <AjaxToolKit:MaskedEditExtender runat="server" ID="MaskedEditExtender2" TargetControlID="txtyear"
                                        Mask="9999" MaskType="Number" ClearTextOnInvalid="false" InputDirection="LeftToRight"  />
                                    <AjaxToolKit:MaskedEditValidator runat="server" ID="MaskedEditValidator" IsValidEmpty="false"
                                       MinimumValue="1753" MinimumValueMessage="Year should be greater than or equal to 1753" ControlExtender="MaskedEditExtender2" ControlToValidate="txtYear" ErrorMessage="enter valid year"
                                        MaximumValue='9998' MaximumValueMessage="Year should be less than or equal to 9998" EmptyValueMessage="Year is required"  />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HFStartDate" runat="server" />
                                    <asp:HiddenField ID="HFEndDate" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelWeek" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:HiddenField ID="HFFromDate" runat="server" />
                                    <asp:HiddenField ID="HFToDate" runat="server" />
                                    <asp:HiddenField ID="HFMaxDate" runat="server" />
                                    <asp:Label ID="Label14" runat="server" Text="<%$Resources:Resource,Week  %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlWeek" AutoPostBack="true" CssClass="cssDropDownSmall" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged"
                                        Width="30%" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelClientName" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlClientCode" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelClientId" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label21" runat="server" Text="<%$ Resources:Resource, ClientName %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlClientId" runat="server" CssClass="cssDropDown" Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAsmt" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, Asmt %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlAsmtCode" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <%--****Start of Code added by Manish  on 30-jun-2010 to vie report on Cost Price and Selling Price Basis ******/--%>
                    <asp:Panel ID="PanelPriceOption" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, Price %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlPriceOption" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                        Width="350px">
                                        <asp:ListItem Value="SP">Selling Price</asp:ListItem>
                                        <asp:ListItem Value="CP">Cost Price</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <%--****End of Code added by Manish  on 30-jun-2010 to vie report on Cost Price and Selling Price Basis ******/--%>
                    <asp:Panel ID="PanelVariance" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label18" runat="server" Text="<%$ Resources:Resource, Variance %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlVariance" runat="server" CssClass="cssDropDown" Width="350px">
                                        <asp:ListItem Value="ALL" Text="<%$ Resources:Resource, All %>"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="<%$ Resources:Resource, Yes %>"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="<%$ Resources:Resource, No %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelTypeOfService" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label19" runat="server" Text="<%$ Resources:Resource, TypeOfService %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlTypeOfService" runat="server" CssClass="cssDropDown" Width="350px">
                                        <asp:ListItem Value="ALL" Text="<%$ Resources:Resource, All %>"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="<%$ Resources:Resource, Complimentary %>"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="<%$ Resources:Resource, Billable %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelDates" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label5" runat="server" Text="<%$Resources:Resource,FromDate %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtFromDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                    <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label6" runat="server" Text="<%$Resources:Resource,ToDate %>" CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox CssClass="csstxtboxSmall" Text="" ID="txtToDate" runat="server" AutoPostBack="false"></asp:TextBox>
                                    <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                        TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                    </AjaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelWorking" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,AttendanceType %>"
                                        CssClass="cssLable"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAttendType" runat="server" CssClass="cssDropDown">
                                        <asp:ListItem Text="Scheduling" Value="SCH" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Actual" Value="ACT"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 200px">
                                        <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,Type %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlReportType" runat="server" CssClass="cssDropDown">
                                            <asp:ListItem Text="Worked > Minimum Hrs In Week" Value="SchEmpMinDutyMinInWeek"
                                                Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Worked > Max Hrs In Month" Value="SchEmpMaxDutyMinInMonth"></asp:ListItem>
                                            <asp:ListItem Text="Worked All on Fri & Sat in Month" Value="FORFRIDAYSATURDAY"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelButton" Width="800px" BorderWidth="0px" runat="server">
                        <table width="800px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="300px">
                                </td>
                                <td align="left" width="400px">
                                    <asp:Button ID="btnViewReport" runat="server" Text="<%$Resources:Resource,ViewReport %>"
                                        CssClass="cssButton" OnClick="btnViewReport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblErrorMsg" EnableViewState="false" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
