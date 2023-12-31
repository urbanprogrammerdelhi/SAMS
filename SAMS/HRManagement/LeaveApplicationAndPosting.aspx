﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveApplicationAndPosting.aspx.cs"
    Inherits="HRManagement_LeaveApplicationAndPosting" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/WRStyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../css/WRGridView.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager EnablePartialRendering="true" EnableScriptGlobalization="true"
            ScriptMode="Release" EnableScriptLocalization="true" ID="script" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/javaScript/validation.js" />
                <asp:ScriptReference Path="~/javaScript/jquery-1.8.1.min.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="98%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center">
                                <asp:HiddenField ID="HFEmployeeNumber" runat="server" />
                                <asp:HiddenField ID="HFDutyDate" runat="server" />
                                <asp:HiddenField ID="HFShiftPatternCode" runat="server" />
                                <asp:HiddenField ID="HFPatternPosition" runat="server" />
                                <asp:HiddenField ID="HFIsDefaultSite" runat="server" />
                                <asp:HiddenField ID="HFAsmtCode" runat="server" />
                                <asp:HiddenField ID="HFRowNumber" runat="server" />
                                <asp:HiddenField ID="HFAttendanceType" runat="server" />
                                <asp:HiddenField ID="HFPost" runat="server" />
                                <asp:HiddenField ID="HFLeaveUpdateStatus" runat="server" />
                                <asp:TextBox ID="txtChangedToDate" Style="display: none;" Width="100px" CssClass="csstxtbox"
                                    runat="server">
                                </asp:TextBox>
                                <asp:TextBox ID="txtNewLeaveUnits" Style="display: none;" Width="100px" CssClass="csstxtbox"
                                    runat="server">
                                </asp:TextBox>
                                        <div class="squareboxgradientcaption" style="height: 20px; ">
                                                    <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Resource, LeaveApplicationPosting %>"></asp:Label>
                                        </div>
                                        <div>
                                            <AjaxToolKit:TabContainer Style="text-align: left;" runat="server" ID="TabLeave"
                                                Width="930px" Height="400px" ActiveTabIndex="0">
                                                <AjaxToolKit:TabPanel TabIndex="0" ID="LeavePosting" runat="server" HeaderText="<%$Resources:Resource,LeaveEntryModificationScreen%>">
                                                    <ContentTemplate>
                                                        <asp:Panel ID="PanelModification" runat="server" GroupingText="<%$Resources:Resource,LeaveEntryModificationScreen%>"
                                                            BorderWidth="0px">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                                <tr>
                                                                    <td style="width: 18%">
                                                                        <asp:Label ID="lblLeaveCalendarCode" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveCalendarCode %>"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 22%">
                                                                        <asp:TextBox MaxLength="16" AutoPostBack="true" ID="txtLeaveCalendarCode" OnTextChanged="txtLeaveCalendarCode_OnTextChanged"
                                                                            Width="120px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                                        <asp:ImageButton ID="ImgLCCode" ToolTip="<%$Resources:Resource,SearchLeaveCalendar%>"
                                                                            runat="server" ImageUrl="~/Images/icosearch.gif" />
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:Label Width="350px" Style="font-weight: bold;" ID="lblLeaveCalendarDesc" CssClass="csstxtboxReadonly"
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td colspan="2" align="right">
                                                                        <asp:LinkButton ID="lbtnAddNew" runat="server" Text="<%$Resources:Resource,LeaveEntitlement%>"
                                                                            CssClass="cssLable" Style="font-weight: bold; font-size: 12px;"></asp:LinkButton>
                                                                        <asp:Image ID="img1" runat="server" ImageUrl="~/Images/spacer.gif" Width="14" Height="1" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblEffectiveFromDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EffectiveFrom %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label Width="120px" Style="font-weight: bold;" ID="lblEffectiveFrom" CssClass="csstxtboxReadonly"
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 12%">
                                                                        <asp:Label ID="lblEffectiveToDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EffectiveTo %>"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 20%">
                                                                        <asp:Label Width="150px" Style="font-weight: bold;" ID="lblEffectiveTo" CssClass="csstxtboxReadonly"
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table border="0" width="100%">
                                                                            <tr>
                                                                                <td style="height: 1px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 1px; background-color: Gray;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 1px">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,EmployeeNumber %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEmployeeNumber" AutoPostBack="true" OnTextChanged="txtEmployeeNumber_OnTextChanged"
                                                                            Width="120px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                                        <asp:ImageButton ID="imgEmployeeNumberSearch" AlternateText="SearchClient" runat="server"
                                                                            ImageUrl="~/Images/icosearch.gif" ToolTip="<%$Resources:Resource,SearchEmployee %>" />
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <asp:Label Width="350px" Style="font-weight: bold;" ID="lblEmployeeName" CssClass="csstxtboxReadonly"
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label Style="font-weight: bold;" ID="lblEmpJoiningDate" CssClass="csstxtboxReadonly"
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblLeaveType" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveType %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlLeaveType_OnSelectedIndexChanged"
                                                                            AutoPostBack="true" Width="160px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblUnit" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,Units %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label Width="150px" Style="font-weight: bold;" ID="lblUnits" CssClass="csstxtboxReadonly"
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSubLeaveType" CssClass="cssLabel" runat="server" Visible="false"
                                                                            Text="<%$Resources:Resource,SubLeaveType %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSubLeaveType" runat="server" CssClass="cssDropDown" Visible="false"
                                                                            Width="160px">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="HFRequestedLeaveUnitSource" runat="server" />
                                                                        <asp:HiddenField ID="HFAssociatedLeaveCode" runat="server" />
                                                                        <asp:HiddenField ID="HFRequestedLeaveUnitSourceXml" runat="server" />
                                                                    </td>
                                                                    <td colspan="4">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblApplicationNo" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveApplicationNo %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlApplicationNo" runat="server" OnSelectedIndexChanged="ddlApplicationNo_OnSelectedIndexChanged"
                                                                            CssClass="cssDropDown" AutoPostBack="true" Width="100px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblBalanceUnits" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveBalance %>"></asp:Label>
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox MaxLength="5" ID="txtLeaveBalanceUnits" Style="font-weight: bold; color: Red;"
                                                                            Width="150px" runat="server" CssClass="csstxtboxReadonly"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblNotifiedDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveNotifiedDate %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtNotifiedDate" Width="100px" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender4" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtNotifiedDate" PopupButtonID="IMGDate" />
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="cbMedicalCerificationProv" Font-Names="Verdana" Font-Size="Smaller"
                                                                            Font-Bold="true" Text="<%$Resources:Resource,LeaveMedicalCertificationProvided %>"
                                                                            TextAlign="Right" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblFromDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,FromDate %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFromDate" Width="100px" CssClass="csstxtbox" AutoPostBack="true"
                                                                                        OnTextChanged="txtFromDate_OnTextChanged" runat="server"></asp:TextBox>
                                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                                        TargetControlID="txtFromDate" PopupButtonID="IMGDate" />
                                                                                    <asp:HiddenField ID="HFLeaveCancelFromDate" runat="server" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFromTime" onBlur="javascript:checkForm(this)" ValidationGroup="AddJob" Width="34px" CssClass="csstxtbox"
                                                                                        MaxLength="5" AutoPostBack="true" runat="server" OnTextChanged="txtFromTime_TextChanged"></asp:TextBox>
                                                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtendertxtFromTime" runat="server"
                                                                                        TargetControlID="txtFromTime" Mask="99:99" MessageValidatorTip="true" MaskType="Time"
                                                                                        AcceptAMPM="false" UserTimeFormat="None" />
                                                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidatortxtFromTime" runat="server"
                                                                                        ControlExtender="MaskedEditExtendertxtFromTime" ControlToValidate="txtFromTime"
                                                                                        IsValidEmpty="False" Display="Dynamic"  />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblToDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,ToDate %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtToDate" Width="100px" AutoPostBack="true" OnTextChanged="txtToDate_OnTextChanged"
                                                                                        CssClass="csstxtbox" runat="server"></asp:TextBox>
                                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                                                        TargetControlID="txtToDate" PopupButtonID="IMGDate" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtToTime" onBlur="javascript:checkForm1(this)" ValidationGroup="AddJob" Width="34px" CssClass="csstxtbox"
                                                                                        MaxLength="5" AutoPostBack="true" runat="server" OnTextChanged="txtToTime_TextChanged"></asp:TextBox>
                                                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtendertxtToTime" runat="server" TargetControlID="txtToTime"
                                                                                        Mask="99:99" MessageValidatorTip="true" MaskType="Time" AcceptAMPM="false" UserTimeFormat="None" />
                                                                                    <AjaxToolKit:MaskedEditValidator ID="MaskedEditValidatortxtToTime" runat="server"
                                                                                        ControlExtender="MaskedEditExtendertxtToTime" ControlToValidate="txtToTime" IsValidEmpty="False"
                                                                                        Display="Dynamic" />
                                                                                    <asp:HiddenField ID="HFLeaveCancelToDate" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblFollowupDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveFollowupDate %>"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 20%" align="left">
                                                                        <asp:TextBox ID="txtFollowUpDate" ReadOnly="true" Width="100px" CssClass="csstxtbox"
                                                                            runat="server"></asp:TextBox>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtFollowUpDate" PopupButtonID="IMGDate" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblFromSession" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveSession %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlFromSession" OnSelectedIndexChanged="ddlFromSession_OnSelectedIndexChanged"
                                                                            runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="100px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblToSession" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveSession %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlToSession" OnSelectedIndexChanged="ddlToSession_OnSelectedIndexChanged"
                                                                            runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="100px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblExpectedDate" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveExpectedReturnDate %>"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtExpectedDate" ReadOnly="true" Width="100px" CssClass="csstxtbox"
                                                                            runat="server"></asp:TextBox>
                                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                                                                            TargetControlID="txtExpectedDate" PopupButtonID="IMGDate" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblLeaveUnits" CssClass="cssLabel" runat="server" Text="<%$Resources:Resource,LeaveRequestedLeaveUnits %>"></asp:Label>
                                                                    </td>
                                                                    <td colspan="5">
                                                                        <asp:TextBox ID="txtLeaveUnits" Width="100px" Text="00.00" runat="server" ReadOnly="true"
                                                                            CssClass="csstxtbox"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table border="0" width="100%">
                                                                            <tr>
                                                                                <td style="height: 1px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 1px; background-color: Gray;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 1px">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" style="text-align: center">
                                                                        <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="0" align="right">
                                                                        <asp:CheckBox ID="cbOverwriteWeekOFF" Font-Names="Verdana" Checked="true" Enabled="false"
                                                                            Font-Size="Smaller" Font-Bold="true" Width="150px" Text="<%$Resources:Resource,DeleteWeekOFF %>"
                                                                            TextAlign="Right" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnWeekOFF" runat="server" Visible="false" class="cssButton" Text="<%$Resources:Resource,WeekOff %>"
                                                                            OnClientClick="javascript:openwoscreen()" />
                                                                    </td>
                                                                    <td colspan="4" style="text-align: left">
                                                                        <asp:Button ID="btnSave" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Save %>"
                                                                            OnClick="btnSave_Click" ValidationGroup="AddJob" />
                                                                        <asp:Button ID="btnUpdate" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Update %>"
                                                                            OnClick="btnUpdate_Click" ValidationGroup="AddJob" />
                                                                        <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource, Delete %>"
                                                                            OnClick="btnDelete_Click" ValidationGroup="AddJob" />
                                                                        <asp:Button ID="btnCancel" runat="server" CssClass="cssButton" Text="<%$Resources:Resource, Clear %>"
                                                                            OnClick="btnCancel_Click" />
                                                                        <asp:Button ID="btnLeaveCancelation" runat="server" CssClass="cssButton" Text="<%$Resources:Resource, CancelLeave %>"
                                                                            OnClick="btnLeaveCancelation_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </AjaxToolKit:TabPanel>
                                            </AjaxToolKit:TabContainer>
                                        </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:Panel ID="PanelMultipleSaveResult" BackColor="white" CssClass="ScrollBar" Style="height: 250px;
                                    width: 490px; display: none;" runat="server">
                                    <asp:Button ID="Button3" runat="server" Style="display: none" />
                                    <AjaxToolKit:ModalPopupExtender ID="MPE" runat="server" TargetControlID="Button3"
                                        BehaviorID="ModalBehavior" BackgroundCssClass="cssModelPopUpBg" DropShadow="true"
                                        OnOkScript="onOk()" PopupControlID="PanelMultipleSaveResult">
                                    </AjaxToolKit:ModalPopupExtender>
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                        <div class="squareboxgradientcaption" style="height: 20px;">
                                                                    <asp:Label ID="Label15" runat="server" Text="Employee Roster Details"></asp:Label>
                                                        </div>
                                                        <div>
                                                            <asp:GridView Width="450px" ID="gvMulRosterResult" CssClass="GridViewStyle" runat="server"
                                                                CellPadding="0" GridLines="None" AutoGenerateColumns="False" AllowSorting="True"
                                                                AllowPaging="true" PageSize="15">
                                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                                <RowStyle CssClass="GridViewRowStyle" />
                                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                <PagerStyle CssClass="GridViewPagerStyle" />
                                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblhdrMulResultAsmtNumber" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource,Asmt %>"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMulResultAsmtNumber" CssClass="CssLabel" runat="server" Text='<%# Bind("AsmtCode") %>'
                                                                                Width="100Px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblhdrMulResultDutyDate" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource,DutyDate %>"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMulResultDutyDate" CssClass="CssLabel" runat="server" Width="100Px"
                                                                                Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDate")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblhdrMulResultFromTime" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource,FromTime %>"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMulResultFromTime" CssClass="CssLabel" runat="server" Width="100Px"
                                                                                Text='<%# String.Format("{0:HH:mm}",Eval("TimeFrom")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblhdrMulResultToTime" CssClass="CssLabel" runat="server" Text="<%$ Resources:Resource,ToTime %>"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMulResultToTime" CssClass="CssLabel" runat="server" Width="100Px"
                                                                                Text='<%# String.Format("{0:HH:mm}",Eval("TimeTo")) %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnOk" runat="server" Text="Overwrite" ValidationGroup="a" CssClass="cssButton" OnClick="btnOk_onClick" />
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnCancel2" runat="server" Text="Cancel"  ValidationGroup="a" CssClass="cssButton" OnClick="btnCancel2_onClick" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </telerik:RadAjaxPanel>
    </div>
    </form>
    <script language="javascript" type="text/javascript">

        window.onbeforeunload = CallParentWindowFunction;
        function CallParentWindowFunction() {
            window.returnValue = "1";
        }
        <%var uInfo = new CommonLibrary.Session.UserInformation(); %>
        var SessionCulture = '<% = uInfo.CountryCode %>';

        var January = '<%= Resources.Resource.January %>';
        var February = '<%= Resources.Resource.February %>';
        var March = '<%= Resources.Resource.March %>';
        var April = '<%= Resources.Resource.April %>';
        var May = '<%= Resources.Resource.May %>';
        var June = '<%= Resources.Resource.June %>';
        var July = '<%= Resources.Resource.July %>';
        var August = '<%= Resources.Resource.August %>';
        var September = '<%= Resources.Resource.September %>';
        var October = '<%= Resources.Resource.October %>';
        var November = '<%= Resources.Resource.November %>';
        var December = '<%= Resources.Resource.December %>';
        var invalidTime ='<%= Resources.Resource.InvalidTime %>';


        function openwoscreen() {
            var varFrmDate = DateInFormat(document.getElementById('<% =txtFromDate.ClientID %>').value);
            var varToDate = DateInFormat(document.getElementById('<% =txtToDate.ClientID %>').value);
            var varEmpNo = document.getElementById('<% =txtEmployeeNumber.ClientID %>').value;
            if (varFrmDate != "" && varToDate != "" && varEmpNo != "") {
                var PageName = "../Transactions/DefineWeekOff_AnEmp.aspx?EmpNo=" + varEmpNo + "&FromDate=" + varFrmDate + "&ToDate=" + varToDate;
                window.open(PageName, 'WeekOff', 'status=on,center=no,scrollbars=yes,resizeable=yes,Width=1000px,height=450px,help=no');
            }

        }
        function DateInFormat(str) {
            if (str == "") {
                return str;
            }
            else {

                var arr = str.split("-");
                var strMonthName;
                var strDay, strYear;
                if (SessionCulture == "Ar-sa") {
                    strMonthName = arr[2];
                    strDay = arr[0];
                    strYear = arr[1];
                }
                else {
                    strDay = arr[0];
                    strMonthName = arr[1];
                    strYear = arr[2];
                }
                var DateReturn;

                if (strMonthName == January || strMonthName.toUpperCase() == "JAN") {
                    DateReturn = strDay + "-JAN-" + strYear;
                }
                else if (strMonthName == February || strMonthName.toUpperCase() == "FEB") {
                    DateReturn = strDay + "-FEB-" + strYear;
                }
                else if (strMonthName == March || strMonthName.toUpperCase() == "MAR") {
                    DateReturn = strDay + "-MAR-" + strYear;
                }
                else if (strMonthName == April || strMonthName.toUpperCase() == "APR") {
                    DateReturn = strDay + "-APR-" + strYear;
                }
                else if (strMonthName == May || strMonthName.toUpperCase() == "MAY") {
                    DateReturn = strDay + "-MAY-" + strYear;
                }
                else if (strMonthName == June || strMonthName.toUpperCase() == "JUN") {
                    DateReturn = strDay + "-JUN-" + strYear;
                }
                else if (strMonthName == July || strMonthName.toUpperCase() == "JUL") {
                    DateReturn = strDay + "-JUL-" + strYear;
                }
                else if (strMonthName == August || strMonthName.toUpperCase() == "AUG") {
                    DateReturn = strDay + "-AUG-" + strYear;
                }
                else if (strMonthName == September || strMonthName.toUpperCase() == "SEP") {
                    DateReturn = strDay + "-SEP-" + strYear;
                }
                else if (strMonthName == October || strMonthName.toUpperCase() == "OCT") {
                    DateReturn = strDay + "-OCT-" + strYear;
                }
                else if (strMonthName == November || strMonthName.toUpperCase() == "NOV") {
                    DateReturn = strDay + "-NOV-" + strYear;
                }
                else if (strMonthName == December || strMonthName.toUpperCase() == "DEC") {
                    DateReturn = strDay + "-DEC-" + strYear;
                }
                return DateReturn;
            }
        }

        function OpenEntitlement(controlID) {
            var strPageName;
            if (document.getElementById('<% =HFDutyDate.ClientID %>').value == "") {
                strPageName = "../HRManagement/LeaveEntitlement.aspx?BackOption=" + 'Back';
            }
            else {
                strPageName = "../HRManagement/LeaveEntitlement.aspx?BackOption=" + 'Back' + "&EmployeeNumber=" + document.getElementById('<% =txtEmployeeNumber.ClientID %>').value +
                "&FromDate=" + DateInFormat(document.getElementById('<% =HFDutyDate.ClientID %>').value) +
                "&AsmtCode=" + document.getElementById('<%=HFAsmtCode.ClientID %>').value +
                "&ShiftPatternCode=" + document.getElementById('<%=HFShiftPatternCode.ClientID %>').value +
                "&PatternCode=" + document.getElementById('<%=HFPatternPosition.ClientID %>').value +
                "&DefaultSite=" + document.getElementById('<% =HFIsDefaultSite.ClientID %>').value +
                "&RowNumber=" + document.getElementById('<% =HFRowNumber.ClientID %>').value +
                "&AttendanceType=" + document.getElementById('<% =HFAttendanceType.ClientID %>').value +
                "&Post=" + document.getElementById('<% =HFPost.ClientID %>').value + "&LeaveBalanceClientID=" + controlID;
            }
            var winW = 1000;
            var winH = 600;
            var winX = (screen.availWidth - winW) / 2;
            var winY = (screen.availHeight - winH) / 2;
            var features = 'left=' + winX + ',top=' + winY + ',height=' + winH + ',' + 'width=' + winW + ',status=yes,' + 'toolbar=no,menubar=no,location=no';
            window.open(strPageName, 'Search', features);
        }

 
 function checkForm(form)
  {

     enteredTime=document.getElementById('<% =txtFromTime.ClientID %>').value;
    // regular expression to match required date format
    re = /^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$/;

    if(enteredTime != '' && !enteredTime.match(re) && enteredTime!="__:__") {
      alert(invalidTime + "" + enteredTime);
      document.getElementById('<% =txtFromTime.ClientID %>').focus();
     document.getElementById('<% =txtFromTime.ClientID %>').value='00:00';
      return false;
    }

    // regular expression to match required time format
    re = /^\d{1,2}:\d{2}([ap]m)?$/;

    if(enteredTime != '' && !enteredTime.match(re) && enteredTime!="__:__") {
      alert(invalidTime + "" +enteredTime);
      document.getElementById('<% =txtFromTime.ClientID %>').focus();
  document.getElementById('<% =txtFromTime.ClientID %>').value='00:00';
      return false;
    }
    
    return true;
 }

function checkForm1(form)
 {  
  enteredTime1=document.getElementById('<% =txtToTime.ClientID %>').value;
    // regular expression to match required date format
    re = /^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$/;

    if(enteredTime1 != '' && !enteredTime1.match(re)  && enteredTime1!="__:__") {
      alert(invalidTime + "" + enteredTime1);
      document.getElementById('<% =txtToTime.ClientID %>').focus();
        document.getElementById('<% =txtToTime.ClientID %>').value = '00:00';

      return false;
    }

    // regular expression to match required time format
    re = /^\d{1,2}:\d{2}([ap]m)?$/;

    if(enteredTime1 != '' && !enteredTime1.match(re)&& enteredTime1!="__:__") {
      alert(invalidTime + "" + enteredTime1);
      document.getElementById('<% =txtToTime.ClientID %>').focus();
  document.getElementById('<% =txtToTime.ClientID %>').value='00:00';
      return false;
    }
   
    return true;
 }
    </script>
</body>
</html>
