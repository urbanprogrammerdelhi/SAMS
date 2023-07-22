<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MaxMonthlyReport.aspx.cs" Inherits="APS_MaxMonthlyReport" %>

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
                    <asp:GridView ID="gdvData" Width="250%" CssClass="GridViewStyle" PageSize="20" runat="server" AllowPaging="true" CellPadding="2" GridLines="Both"
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
                            <asp:TemplateField HeaderText="FO Name" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate3" CssClass="cssLable" runat="server" Text='<%# Bind("FONam") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="FO Remarks" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26FOREMARKS" CssClass="cssLable" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Site Visit" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate4" CssClass="cssLable" runat="server" Text='<%# Bind("Sitevisit") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Audit Date" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
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
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Deep Cleaning Date" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate7" CssClass="cssLable" runat="server" Text='<%# Bind("DCDate") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Scrap Status" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate8" CssClass="cssLable" runat="server" Text='<%# Bind("ScrapYesNo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emergency Exit Availability" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate9" CssClass="cssLable" runat="server" Text='<%# Bind("EmergencyAvail") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emergency Exit Obstruction Free" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate10" CssClass="cssLable" runat="server" Text='<%# Bind("EmergencyObs") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="New Fire Extinguisher Total Quantity" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate11" CssClass="cssLable" runat="server" Text='<%# Bind("FireTotal") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Fire Extinguisher ABC 2KG Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate12" CssClass="cssLable" runat="server" Text='<%# Bind("ABC2kgW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Fire Extinguisher ABC 2KG Non-Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate13" CssClass="cssLable" runat="server" Text='<%# Bind("ABC2kgNW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Fire Extinguisher ABC 4KG Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate14" CssClass="cssLable" runat="server" Text='<%# Bind("ABC4KgW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Fire Extinguisher ABC 4KG Non-Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate15" CssClass="cssLable" runat="server" Text='<%# Bind("ABC4kgNW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Fire Extinguisher BC(CO2) 4.5KG Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate16" CssClass="cssLable" runat="server" Text='<%# Bind("BCW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Fire Extinguisher BC(CO2) 4.5KG Non-Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate17" CssClass="cssLable" runat="server" Text='<%# Bind("BCNW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Fire Extinguisher Ceiling Mounted Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate18" CssClass="cssLable" runat="server" Text='<%# Bind("CMW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Fire Extinguisher Ceiling Mounted Non-Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate19" CssClass="cssLable" runat="server" Text='<%# Bind("CMNW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Old Fire Extinguisher Total Quantity" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate20" CssClass="cssLable" runat="server" Text='<%# Bind("OldTotal") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Old Fire Extinguisher Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate21" CssClass="cssLable" runat="server" Text='<%# Bind("OldW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Old Fire Extinguisher Non-Working" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate22" CssClass="cssLable" runat="server" Text='<%# Bind("OldNW") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Old Fire Extinguisher Tagged Properly(For Training)" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate23" CssClass="cssLable" runat="server" Text='<%# Bind("OldTraining") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Main Electrical  Panel /DBs Inside the office is intact and there is no wire cut , smoke, black marks around due to heat (Yes/ No)" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate28" CssClass="cssLable" runat="server" Text='<%# Bind("DBInside") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Electrical Wires within office premise are neatly tied and dressed (Yes/ No)" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate29" CssClass="cssLable" runat="server" Text='<%# Bind("ElectricalWire") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Is DG owned by MLI" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate30" CssClass="cssLable" runat="server" Text='<%# Bind("MLI") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="If DG owned by MLI then is it placed with basic safety and security to avoid any theft" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31" CssClass="cssLable" runat="server" Text='<%# Bind("MLIPLace1") %>'></asp:Label>
                                </ItemTemplate>
                                    <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                             




                            <asp:TemplateField HeaderText="Sanitizer Availability" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate24" CssClass="cssLable" runat="server" Text='<%# Bind("Sanitizer") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Virex Availability" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate25" CssClass="cssLable" runat="server" Text='<%# Bind("Virex") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pest Control Activity" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26" CssClass="cssLable" runat="server" Text='<%# Bind("Pest") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chair/Sofa shampooing/Rodent/termite treatment required" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate27" CssClass="cssLable" runat="server" Text='<%# Bind("ChairShampoo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="Possession of Uniform and valid ID card by all staff" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26idcard" CssClass="cssLable" runat="server" Text='<%# Bind("Uniform") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="IR thermometer working fine" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26thermo" CssClass="cssLable" runat="server" Text='<%# Bind("Thermometer") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Stock availability of housekeeping consumables for next 7 days" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate26stock7" CssClass="cssLable" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                           
                          <asp:TemplateField HeaderText="Is Office seems to have safe surroundings considering periphery and geography" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate30surroun22d1" CssClass="cssLable" runat="server" Text='<%# Bind("Surrounding1") %>'></asp:Label>
                                </ItemTemplate>
                                  <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="The surroundings and way heading to MLI office is clean and tidy" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31surround2" CssClass="cssLable" runat="server" Text='<%# Bind("Surrounding2") %>'></asp:Label>
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



