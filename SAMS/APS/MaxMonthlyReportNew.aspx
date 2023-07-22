<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MaxMonthlyReportNew.aspx.cs" Inherits="APS_MaxMonthlyReportNew" %>


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
                    <asp:DropDownList runat="server" ID="ddlYear" CssClass="cssDropDown" Width="229px" Font-Bold="True"  OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ForeColor="#ED1D22">
                    </asp:DropDownList>
                     <asp:Label Width="50px" ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="Months :" Font-Bold="True" Font-Size="Small" ForeColor="#2E6293"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlmonth" CssClass="cssDropDown" Width="229px" Font-Bold="True" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged" ForeColor="#ED1D22">
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
                     <asp:Button ID="btnview" runat="server" CssClass="cssButton" Text="Click to Fetch Report" OnClick="btnview_Click" />
                </td>
               
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="left" colspan="3">
                    <br />
                    <asp:GridView ID="gdvData" Width="250%" CssClass="GridViewStyle" PageSize="100" runat="server" AllowPaging="true" CellPadding="2" GridLines="Both"
                        AutoGenerateColumns="False" OnRowDataBound="gdvData_RowDataBound" ShowFooter="True" OnPageIndexChanging="gdvData_PageIndexChanging" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                        <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#D3E8F4" ForeColor="Black" CssClass="csspager" />
                        <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="lblSNo" CssClass="cssLable" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agency Code" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                       <asp:Label ID="lblEmpCode" CssClass="cssLabel" CausesValidation="false" runat="server"  Text='<%# Bind("ClientCode") %>' ></asp:Label>
                                             
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Name" HeaderStyle-Width="310px" FooterStyle-Width="310px" ItemStyle-Width="310px">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" CssClass="cssLable" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zone" HeaderStyle-Width="400px" FooterStyle-Width="400px" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Permanent Office Address " HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate1" CssClass="cssLable" runat="server" Text='<%# Bind("AsmtAddress") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate2" CssClass="cssLable" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                       <%--     <asp:TemplateField HeaderText="FO Name" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate3" CssClass="cssLable" runat="server" Text='<%# Bind("FONam") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>--%>
                          <%--     <asp:TemplateField HeaderText="FO Remarks" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26FOREMARKS" CssClass="cssLable" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>--%>
                            
                            <asp:TemplateField HeaderText="Site Visit" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate4" CssClass="cssLable" runat="server" Text='<%# Bind("Sitevisit") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                           <%--    <asp:TemplateField HeaderText="Audit Date" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateAudote" CssClass="cssLable" runat="server" Text='<%# Bind("AuditDate") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SPOC Name" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate5" CssClass="cssLable" runat="server" Text='<%# Bind("SPOCName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SPOC Contact No." HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate6" CssClass="cssLable" runat="server" Text='<%# Bind("SPOCCNo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Overall Feedback for Services rated by MLI SPOC" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26SPOCMLI" CssClass="cssLable" runat="server" Text='<%# Bind("Feedback") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Do the housekeepers have
uniform & valid id card?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate7" CssClass="cssLable" runat="server" Text='<%# Bind("1") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Upload full size pictures of
manpower" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate8" CssClass="cssLable" runat="server" Text='<%# Bind("2") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Number of Regular Fire
Extinguishers installed/placed in
the office area" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate9" CssClass="cssLable" runat="server" Text='<%# Bind("3") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extinguisher in Green & Red zone - BC
CO2 4.5 KG?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate10" CssClass="cssLable" runat="server" Text='<%# Bind("4") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Extinguisher in Green & Red zone -
ABC- 4 KG?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate11" CssClass="cssLable" runat="server" Text='<%# Bind("5") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extinguisher in Green & Red zone - ABC
2 KG?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate12" CssClass="cssLable" runat="server" Text='<%# Bind("6") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extinguisher in Green & Red zone-
Ceiling Mounted automatic FE36
5 KG of UPS/Server Room ?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate13" CssClass="cssLable" runat="server" Text='<%# Bind("7") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="Extinguisher in Red zone - BC
CO2 4.5 KG?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate14" CssClass="cssLable" runat="server" Text='<%# Bind("8") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extinguisher in Red zone - ABC-
4 KG?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate15" CssClass="cssLable" runat="server" Text='<%# Bind("9") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extinguisher in Red zone - ABC 2
KG?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate16" CssClass="cssLable" runat="server" Text='<%# Bind("10") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extinguisher in Red zone-Ceiling
Mounted automatic FE36 5 KG of
UPS/Server Room ?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate17" CssClass="cssLable" runat="server" Text='<%# Bind("11") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="How many Old Extinguishers are
kept for training
purpose?(Ceasefire/Safex/Minima
x )" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate18" CssClass="cssLable" runat="server" Text='<%# Bind("12") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="How many old Extinguishers are
in Green & Red Zone ?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate19" CssClass="cssLable" runat="server" Text='<%# Bind("13") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                          <%--  <asp:TemplateField HeaderText="How many old Extinguishers are
in Red Zone ?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate20" CssClass="cssLable" runat="server" Text='<%# Bind("14") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Are old Extinguishers tagged properly(For Training Purpose
Only ) and kept aside?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate21" CssClass="cssLable" runat="server" Text='<%# Bind("15") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Does the branch has emergency
exit? Upload Picture of
emergency exit if it is there" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate22" CssClass="cssLable" runat="server" Text='<%# Bind("16") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is the emergency exit found
obstruction free?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate23" CssClass="cssLable" runat="server" Text='<%# Bind("17") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Is the emergency exit door and
Pad lock placed on it are working
(to be checked physically)" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate28" CssClass="cssLable" runat="server" Text='<%# Bind("18") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Opex Scrap available in Office
Area" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate29" CssClass="cssLable" runat="server" Text='<%# Bind("19") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Capex IT Scrap available in Office
Area" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate30" CssClass="cssLable" runat="server" Text='<%# Bind("20") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Capex Non-IT Scrap available in
Office Area" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31" CssClass="cssLable" runat="server" Text='<%# Bind("21") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                             




                            <asp:TemplateField HeaderText="When did Deep cleaning happen?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate24" CssClass="cssLable" runat="server" Text='<%# Bind("22") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Would the housekeeping
consumables be in stock for next
7 days?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate25" CssClass="cssLable" runat="server" Text='<%# Bind("23") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chair shampooing/Sofa
shampooing required" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26" CssClass="cssLable" runat="server" Text='<%# Bind("24") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is the special services like
Rodent , rodent entry point
closure or termite treatment
required?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate27" CssClass="cssLable" runat="server" Text='<%# Bind("25") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="Please rate your overall
experience?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26idcard" CssClass="cssLable" runat="server" Text='<%# Bind("26") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Main Electrical Panel /DBs Inside
the office is intact and there is no
wire cut , smoke, black marks
around due to heat" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26thermo" CssClass="cssLable" runat="server" Text='<%# Bind("27") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Electrical Wires within office
premise are neatly tied and
dressed" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26stock7" CssClass="cssLable" runat="server" Text='<%# Bind("28") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                           
                          <asp:TemplateField HeaderText="If DG owned by MLI" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate30surroun22d1" CssClass="cssLable" runat="server" Text='<%# Bind("29") %>'></asp:Label>
                                </ItemTemplate>
                                  <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Specifying Holidays List
available?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround2" CssClass="cssLable" runat="server" Text='<%# Bind("30") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Name and address of the Wage/
Labour Inspector available" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround211" CssClass="cssLable" runat="server" Text='<%# Bind("31") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Rates of Minimum wages fixed
under the Minimum Wages Act
available" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround222" CssClass="cssLable" runat="server" Text='<%# Bind("32") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="Is S&E Certificate available?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround2333" CssClass="cssLable" runat="server" Text='<%# Bind("33") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="Is CLRA Registration Certificate
available?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround24444" CssClass="cssLable" runat="server" Text='<%# Bind("34") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="Is Trade License available (if
applicable)?" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround25555" CssClass="cssLable" runat="server" Text='<%# Bind("35") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="Any issue with R&M, including
condition of all equipment’s AC,
RO,DG etc." HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround2666" CssClass="cssLable" runat="server" Text='<%# Bind("36") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="Any general R&M works,
Electrical, plumbing, civil etc.
required" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround2777" CssClass="cssLable" runat="server" Text='<%# Bind("37") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="Any Observation related to
dampness /seepage especially in
server room or in other office
area (mention the area/s)" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround2888" CssClass="cssLable" runat="server" Text='<%# Bind("38") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                           
                       
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <table width="95%" align="left">
            <tr>
                <td>
                    <asp:Label ID="lblNodata" runat="server" CssClass="label-sm label-danger " ForeColor="White" Text="Record Not Available !!!"  Visible="false"/>
                </td>
                <td>
                    <asp:Button ID="bntExport" runat="server" CssClass="cssButton" Text="Export to Excel" OnClick="bntExport_Click" Visible="false" />
                </td>
                <td align="center"><asp:Image ID="imagebtn" Visible="false"  runat="server" ImageUrl="~/Images/loaderashir.gif" /> </td>
              
            </tr>
        </table>
        <br />
       
    </div>
    <%--</contenttemplate>--%>
    <%--</asp:UpdatePanel>--%>
</asp:Content>




