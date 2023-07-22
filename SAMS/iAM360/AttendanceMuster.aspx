<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceMuster.aspx.cs" Inherits="iAM360_AttendanceMuster" %>


<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">--%>
    <%--<contenttemplate>--%>
    <style>
        .csspager td {
            padding-left: 10px;
            padding-right: 10px;
            color: #009900;
            font-weight: bold;
            font-size: 10pt;
        }
    </style>
    <div style="overflow: auto;" class="text-left" runat="server">
        <br />
        <center>
            <p>
                <asp:Label ID="lblMainHead" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="Black"></asp:Label>
            </p>
        </center>
        <table id="attDetail" runat="server" width="100%">
            <tr>
                <td align="right">&nbsp;</td>
                <td class="text-left">
                    <strong>
                        <asp:Label ID="lblArea" runat="server" CssClass="cssLabel" Font-Bold="True" Font-Size="Small" ForeColor="#2E6293" Text="Year :"></asp:Label>
                    </strong>
                    <asp:DropDownList runat="server" ID="ddlYear" CssClass="cssDropDown" Width="229px" Font-Bold="True" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ForeColor="#ED1D22">
                    </asp:DropDownList>
                </td>
                <td align="right">&nbsp;</td>
                <td align="right">
                    <asp:Label Width="50px" ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="Months :" Font-Bold="True" Font-Size="Small" ForeColor="#2E6293"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlmonth" CssClass="cssDropDown" AutoPostBack="true" Width="229px" Font-Bold="True" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged" ForeColor="#ED1D22">
                        <asp:ListItem Value="01">January</asp:ListItem>
                        <asp:ListItem Value="02">February</asp:ListItem>
                        <asp:ListItem Value="03">March</asp:ListItem>
                        <asp:ListItem Value="04">April</asp:ListItem>
                        <asp:ListItem Value="05">May</asp:ListItem>
                        <asp:ListItem Value="06">June</asp:ListItem>
                        <asp:ListItem Value="07">July</asp:ListItem>
                        <asp:ListItem Value="08">August</asp:ListItem>
                        <asp:ListItem Value="09">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="left" colspan="3">
                    <br />
                    <asp:GridView ID="gdvData" Width="100%" CssClass="GridViewStyle" PageSize="20" runat="server" AllowPaging="true" CellPadding="2" GridLines="None"
                        AutoGenerateColumns="False" OnRowDataBound="gdvData_RowDataBound" ShowFooter="True" OnPageIndexChanging="gdvData_PageIndexChanging" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                        <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#D3E8F4" ForeColor="Black" CssClass="csspager" />
                        <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="lblSNo" CssClass="cssLable" runat="server" Text='<%# Bind("SNo") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emp.Code" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                        <u>
                                            <asp:LinkButton ID="lblEmpCodeLink" CssClass="cssLabel" CausesValidation="false" runat="server" OnClick="lblEmpCode_Click" Text='<%# Bind("EmpCode") %>' Visible="false"></asp:LinkButton>
                                   </u>    <asp:Label ID="lblEmpCode" CssClass="cssLabel" CausesValidation="false" runat="server"  Text='<%# Bind("EmpCode") %>' ></asp:Label>
                                             
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EmployeeName" HeaderStyle-Width="310px" FooterStyle-Width="310px" ItemStyle-Width="310px">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" CssClass="cssLable" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="400px" FooterStyle-Width="400px" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="01" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate1" CssClass="cssLable" runat="server" Text='<%# Bind("01") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="02" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate2" CssClass="cssLable" runat="server" Text='<%# Bind("02") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="03" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate3" CssClass="cssLable" runat="server" Text='<%# Bind("03") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="04" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate4" CssClass="cssLable" runat="server" Text='<%# Bind("04") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="05" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate5" CssClass="cssLable" runat="server" Text='<%# Bind("05") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="06" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate6" CssClass="cssLable" runat="server" Text='<%# Bind("06") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="07" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate7" CssClass="cssLable" runat="server" Text='<%# Bind("07") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="08" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate8" CssClass="cssLable" runat="server" Text='<%# Bind("08") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="09" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate9" CssClass="cssLable" runat="server" Text='<%# Bind("09") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="10" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate10" CssClass="cssLable" runat="server" Text='<%# Bind("10") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="11" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate11" CssClass="cssLable" runat="server" Text='<%# Bind("11") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="12" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate12" CssClass="cssLable" runat="server" Text='<%# Bind("12") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="13" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate13" CssClass="cssLable" runat="server" Text='<%# Bind("13") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="14" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate14" CssClass="cssLable" runat="server" Text='<%# Bind("14") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="15" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate15" CssClass="cssLable" runat="server" Text='<%# Bind("15") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="16" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate16" CssClass="cssLable" runat="server" Text='<%# Bind("16") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="17" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate17" CssClass="cssLable" runat="server" Text='<%# Bind("17") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="18" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate18" CssClass="cssLable" runat="server" Text='<%# Bind("18") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="19" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate19" CssClass="cssLable" runat="server" Text='<%# Bind("19") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="20" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate20" CssClass="cssLable" runat="server" Text='<%# Bind("20") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="21" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate21" CssClass="cssLable" runat="server" Text='<%# Bind("21") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="22" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate22" CssClass="cssLable" runat="server" Text='<%# Bind("22") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="23" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate23" CssClass="cssLable" runat="server" Text='<%# Bind("23") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="24" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate24" CssClass="cssLable" runat="server" Text='<%# Bind("24") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="25" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate25" CssClass="cssLable" runat="server" Text='<%# Bind("25") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="26" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26" CssClass="cssLable" runat="server" Text='<%# Bind("26") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="27" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate27" CssClass="cssLable" runat="server" Text='<%# Bind("27") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="28" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate28" CssClass="cssLable" runat="server" Text='<%# Bind("28") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="29" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate29" CssClass="cssLable" runat="server" Text='<%# Bind("29") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="30" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate30" CssClass="cssLable" runat="server" Text='<%# Bind("30") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="31" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31" CssClass="cssLable" runat="server" Text='<%# Bind("31") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duty Days" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                        <b>
                                            <asp:Label ID="lblDutyday" CssClass="cssLable" runat="server" Text='<%# Bind("DutyDays") %>'></asp:Label>
                                        </b>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--  <asp:TemplateField HeaderText="Duty Hours" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                        <b>
                                            <asp:Label ID="lblDutyHrs" CssClass="cssLable" runat="server" Text='<%# Bind("DutyHrs") %>'></asp:Label>
                                        </b>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Over Time" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                        <b>
                                            <asp:Label ID="lblOverTime" CssClass="cssLable" runat="server" Text='<%# Bind("OverTime") %>'></asp:Label>
                                        </b>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <table width="95%" align="left">
            <tr>
                <td>
                    <asp:Label ID="lblNodata" runat="server" CssClass="label-sm label-danger " ForeColor="White" Text="Record Not Available !!!" />
                </td>
                <td>
                    <asp:Button ID="bntExport" runat="server" CssClass="cssButton" Text="Export to Excel" OnClick="bntExport_Click" />
                </td>
                <td align="center">&nbsp;</td>
                <td align="right">
                    <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click" CssClass="cssButton">Back</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <table id="divDetails" runat="server" width="90%" align="left">
            <tr>
                <td align="left">
                    <strong>
                        <asp:Label ID="lblEmpCode1" runat="server" ForeColor="#2E6293" Text="Employee Number :"></asp:Label>
                        <asp:Label ID="lblEmpCode0" runat="server" ForeColor="#ED1D22"></asp:Label>
                    </strong>
                </td>
                <td align="left">
                    <strong>
                        <asp:Label ID="lblTAttd1" runat="server" ForeColor="#2E6293" Text="Total Workable Days :"></asp:Label>
                        <asp:Label ID="lblTAttd0" runat="server" ForeColor="Black"></asp:Label>
                        &nbsp;[<asp:Label ID="lblTDetail1" runat="server" ForeColor="#B36F05">WeekOff (W/O) : </asp:Label><asp:Label ID="lblTDetai2" runat="server" ForeColor="Black"></asp:Label>
                        ;<asp:Label ID="lblTDetail3" runat="server" ForeColor="#2E6293">Holidays (H) : </asp:Label><asp:Label ID="lblTDetail4" runat="server" ForeColor="Black"></asp:Label>]</strong></td>
            </tr>
            <tr>
                <td align="left">
                    <strong>
                        <asp:Label ID="lblEmpName1" runat="server" ForeColor="#2E6293" Text="Employee Name :"></asp:Label>
                        <asp:Label ID="lblEmpName0" runat="server" ForeColor="#ED1D22"></asp:Label>
                    </strong>
                </td>
                <td align="left">
                    <strong>
                        <asp:Label ID="lblTAttdPresent1" runat="server" ForeColor="#009933" Text="No. of Days Present (P) :"></asp:Label>
                        <asp:Label ID="lblTAttdPresent0" runat="server" ForeColor="Black"></asp:Label>
                    </strong>
                    &nbsp;[<strong><asp:Label ID="lblExtraDuty" runat="server" ForeColor="#663300"></asp:Label></strong>]</td>
            </tr>
            <tr>
                <td align="left">
                    <strong>
                        <asp:Label ID="lblMonths1" runat="server" ForeColor="#2E6293" Text="Attendance Month :"></asp:Label>
                        <asp:Label ID="lblMonths0" runat="server" ForeColor="#ED1D22"></asp:Label>
                    </strong>
                </td>
                <td align="left">
                    <strong>
                        <asp:Label ID="Label1" runat="server" ForeColor="#ED1D22" Text="No. of Days Absent (A) :"></asp:Label>
                        <asp:Label ID="lblTAttdAbsent0" runat="server" ForeColor="Black"></asp:Label>
                        &nbsp;
                                <asp:Label ID="Label2" runat="server" ForeColor="Maroon" Text="Duty Hrs :"></asp:Label>
                        <asp:Label ID="lblDutyHrs" runat="server" ForeColor="Black"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <asp:GridView ID="GridView1" Width="100%" CssClass="GridViewStyle" PageSize="16" runat="server" AllowPaging="false" CellPadding="2" GridLines="None"
                        AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" OnPageIndexChanging="GridView1_PageIndexChanging" ForeColor="#333333" AllowSorting="True">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#012160" Font-Bold="True" ForeColor="black" />
                        <HeaderStyle BackColor="#012160" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#D3E8F4" ForeColor="black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                        <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblSNo" CssClass="cssLable" runat="server" Text='<%# Bind("SNo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" CssClass="cssLable" runat="server" Text='<%# Bind("DutyDate") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                                <FooterStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shift Details" HeaderStyle-Width="400px" FooterStyle-Width="400px" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="lblShiftDetail" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftDetail") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="400px" />
                                <HeaderStyle Width="400px" />
                                <ItemStyle Width="400px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="In Time" HeaderStyle-Width="310px" FooterStyle-Width="310px" ItemStyle-Width="310px">
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeFrom" CssClass="cssLable" runat="server" Text='<%# Bind("TimeFrom") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="310px" />
                                <HeaderStyle Width="310px" />
                                <ItemStyle Width="310px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Out Time" HeaderStyle-Width="400px" FooterStyle-Width="400px" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeTo" CssClass="cssLable" runat="server" Text='<%# Bind("TimeTo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="400px" />
                                <HeaderStyle Width="400px" />
                                <ItemStyle Width="400px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duty Hrs" HeaderStyle-Width="400px" FooterStyle-Width="400px" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="lblHrs" CssClass="cssLable" runat="server" Text='<%# Bind("Hrs") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="400px" />
                                <HeaderStyle Width="400px" />
                                <ItemStyle Width="400px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Over Time" HeaderStyle-Width="400px" FooterStyle-Width="400px" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="lblOverTime" CssClass="cssLable" runat="server" Text='<%# Bind("OverTime") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="400px" />
                                <HeaderStyle Width="400px" />
                                <ItemStyle Width="400px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="400px" FooterStyle-Width="400px" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" CssClass="cssLable" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="400px" />
                                <HeaderStyle Width="400px" />
                                <ItemStyle Width="400px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnExport2" runat="server" CssClass="cssButton" Text="Export to Excel" OnClick="btnExport2_Click" />
                </td>
            </tr>
        </table>
    </div>
    <%--</contenttemplate>--%>
    <%--</asp:UpdatePanel>--%>
</asp:Content>



