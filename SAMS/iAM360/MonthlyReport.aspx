<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MonthlyReport.aspx.cs" Inherits="iAM360_MonthlyReport" enableeventvalidation="false" %>





<%--<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
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
                    <asp:DropDownList runat="server" ID="ddlYear" CssClass="cssDropDown" Width="200px" Font-Bold="True" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ForeColor="#ED1D22">
                    </asp:DropDownList>
                </td>
             
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
                   <td align="right">   <strong>
                        <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Font-Bold="True" Font-Size="Small" ForeColor="#2E6293" Text="Select Branch :"></asp:Label>
                    </strong>
                    <asp:DropDownList runat="server" ID="ddlbranch" CssClass="cssDropDown" Width="229px" Font-Bold="True" AutoPostBack="true" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged" ForeColor="#ED1D22">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="left" colspan="3">
                    <br />
                    <div id="divgrif" runat="server">
                    <asp:GridView ID="gdvData" Width="100%" CssClass="GridViewStyle" PageSize="20" runat="server" AllowPaging="true" CellPadding="2" GridLines="None"
                        AutoGenerateColumns="False" OnRowDataBound="gdvData_RowDataBound" ShowFooter="True" OnPageIndexChanging="gdvData_PageIndexChanging" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                        <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#D3E8F4" ForeColor="Black" CssClass="csspager" />
                        <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                <ItemTemplate>
                                  
                                        <asp:Label ID="lblSNo" CssClass="cssLable" runat="server"></asp:Label>
                                  
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="District" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                   
                                        <asp:Label ID="lblSNoDistrict" CssClass="cssLable" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                  
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Center" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                  
                                        <asp:Label ID="lblSNoCenter" CssClass="cssLable" runat="server" Text='<%# Bind("Center") %>'></asp:Label>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Location" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                  
                                        <asp:Label ID="lblSNoLocation" CssClass="cssLable" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                                  
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="EmployeeName" HeaderStyle-Width="310px" FooterStyle-Width="310px" ItemStyle-Width="310px">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" CssClass="cssLable" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="310px" FooterStyle-Width="310px" ItemStyle-Width="310px">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpDesignation" CssClass="cssLable" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Total Working Days" HeaderStyle-Width="350px" FooterStyle-Width="350px" ItemStyle-Width="350px">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="lblSNoTWorking" CssClass="cssLable" runat="server" Text='<%# Bind("TotalWorkingDays") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Total Present" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="lblSNoTPre" CssClass="cssLable" runat="server" Text='<%# Bind("TotalPresent") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Total Absent" HeaderStyle-Width="300px" FooterStyle-Width="300px" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="lblSNoTAb" CssClass="cssLable" runat="server" Text='<%# Bind("TotalAbsent") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>

                         
                        
                        </Columns>
                    </asp:GridView>
                        </div>
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

    </div>
   
</asp:Content>






