<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MacquarieMuster.aspx.cs" Inherits="APS_MacquarieMuster" %>


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
                    <asp:GridView ID="gdvData" Width="100%" CssClass="GridViewStyle" PageSize="100" runat="server" AllowPaging="true" CellPadding="2" GridLines="None"
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
                                        <asp:Label ID="lblSNo" CssClass="cssLable" runat="server"></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emp.Code" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                        <u>
                                           
                                   </u>    <asp:Label ID="lblEmpCode" CssClass="cssLabel" CausesValidation="false" runat="server"  Text='<%# Bind("EmpNo") %>' ></asp:Label>
                                             
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
                                    <asp:Label ID="lblDate1" CssClass="cssLable" runat="server" Text='<%# Bind("1") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="02" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate2" CssClass="cssLable" runat="server" Text='<%# Bind("2") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="03" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate3" CssClass="cssLable" runat="server" Text='<%# Bind("3") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="04" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate4" CssClass="cssLable" runat="server" Text='<%# Bind("4") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="05" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate5" CssClass="cssLable" runat="server" Text='<%# Bind("5") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="06" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate6" CssClass="cssLable" runat="server" Text='<%# Bind("6") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="07" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate7" CssClass="cssLable" runat="server" Text='<%# Bind("7") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="08" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate8" CssClass="cssLable" runat="server" Text='<%# Bind("8") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Width="300px" />
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="09" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate9" CssClass="cssLable" runat="server" Text='<%# Bind("9") %>'></asp:Label>
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

                               <asp:TemplateField HeaderText="Total" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate31total" CssClass="cssLable" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                          
                      
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
               
            </tr>
        </table>
        <br />
     
    </div>
    <%--</contenttemplate>--%>
    <%--</asp:UpdatePanel>--%>
</asp:Content>



