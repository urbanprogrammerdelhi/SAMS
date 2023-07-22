<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceMusterWithTiming.aspx.cs" Inherits="iAM360_AttendanceMusterWithTiming" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        </table>
        <br>
        <asp:GridView ID="gvAssetScheduling" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" GridLines="None"
            OnRowDataBound="gvAssetScheduling_RowDataBound" PageSize="20" ShowFooter="True" Width="250%" OnPageIndexChanging="gvAssetScheduling_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#D3E8F4" ForeColor="black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
            <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <Columns>                
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="400px">
                            <tr>
                                <td style="text-align: left; width: 70px; color:white">
                                    <asp:Label ID="Label03" runat="server" Text="S.No"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <asp:Label ID="Label13" runat="server" Text="Emp. Code"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 200px; color:white">
                                    <asp:Label ID="Label8" runat="server" Text="Employee Name"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 150px; color:white">
                                    <asp:Label ID="Label23" runat="server" Text="Designation"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 60px; color:white">
                                    <asp:Label ID="Label7" runat="server" Text="Total Duty Days"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 60px; color:white">
                                    <asp:Label ID="Label9" runat="server" Text="Total Duty Hrs"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table width="390px">
                            <tr>
                                <td style="text-align: center; width: 50px;">
                                    <asp:Label ID="Label444" runat="server" CssClass="cssLabel" Style="word-break: break-all;" Text='<%# Bind("SrNo") %>'></asp:Label>
                                </td>
                                <td style="text-align: center; width: 70px;">
                                    <u>
                                        <asp:LinkButton ID="lblEmpCode" CssClass="cssLabel" CausesValidation="false" runat="server" OnClick="lblEmpCode_Click" Text='<%# Bind("EmployeeNumber") %>'></asp:LinkButton>
                                    </u>
                                </td>
                                <td style="text-align: left; width: 160px;">
                                    <asp:Label ID="lblAssetName" runat="server" CssClass="cssLabel" Style="word-break: break-all;" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                </td>
                                <td style="text-align: left; width: 140px;">
                                    <asp:Label ID="lblAsseqName" runat="server" CssClass="cssLabel" Style="word-break: break-all;" Text='<%# Bind("Designation") %>'></asp:Label>
                                </td>
                                <td style="text-align: center; width: 40px;">
                                    <asp:Label ID="Label10" runat="server" CssClass="cssLabel" Style="word-break: break-all;" Text='<%# Bind("TotalDutyDays") %>'></asp:Label>
                                </td>
                                <td style="text-align: center; width: 60px;">
                                    <asp:Label ID="Label11" runat="server" CssClass="cssLabel" Style="word-break: break-all;" Text='<%# Bind("TotalDutyHrs") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="310px" />
                    <ItemStyle Width="310px" />
                    <FooterStyle Width="310px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld1" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp1" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli1" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo1" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla1" runat="server" Text='<%# Bind("100") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln1" runat="server" Text='<%# Bind("101") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt1" runat="server" Text='<%# Bind("102") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld2" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp2" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli2" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo2" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla2" runat="server" Text='<%# Bind("200") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln2" runat="server" Text='<%# Bind("201") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt2" runat="server" Text='<%# Bind("202") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld3" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp3" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli3" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo3" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla3" runat="server" Text='<%# Bind("300") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln3" runat="server" Text='<%# Bind("301") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt3" runat="server" Text='<%# Bind("302") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld4" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp4" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli4" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo4" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla4" runat="server" Text='<%# Bind("400") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln4" runat="server" Text='<%# Bind("401") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt4" runat="server" Text='<%# Bind("402") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld5" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp5" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli5" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo5" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla5" runat="server" Text='<%# Bind("500") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln5" runat="server" Text='<%# Bind("501") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt5" runat="server" Text='<%# Bind("502") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld6" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp6" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli6" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo6" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla6" runat="server" Text='<%# Bind("600") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln6" runat="server" Text='<%# Bind("601") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt6" runat="server" Text='<%# Bind("602") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld7" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp7" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli7" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo7" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla7" runat="server" Text='<%# Bind("700") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln7" runat="server" Text='<%# Bind("701") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt7" runat="server" Text='<%# Bind("702") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld8" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp8" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli8" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo8" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla8" runat="server" Text='<%# Bind("800") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln8" runat="server" Text='<%# Bind("801") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt8" runat="server" Text='<%# Bind("802") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld9" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp9" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli9" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo9" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla9" runat="server" Text='<%# Bind("900") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln9" runat="server" Text='<%# Bind("901") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt9" runat="server" Text='<%# Bind("902") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld10" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp10" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli10" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo10" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla10" runat="server" Text='<%# Bind("1000") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln10" runat="server" Text='<%# Bind("1001") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt10" runat="server" Text='<%# Bind("1002") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld11" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp11" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli11" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo11" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla11" runat="server" Text='<%# Bind("1100") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln11" runat="server" Text='<%# Bind("1101") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt11" runat="server" Text='<%# Bind("1102") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld12" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp12" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli12" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo12" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla12" runat="server" Text='<%# Bind("1200") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln12" runat="server" Text='<%# Bind("1201") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt12" runat="server" Text='<%# Bind("1202") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld13" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp13" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli13" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo13" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla13" runat="server" Text='<%# Bind("1300") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln13" runat="server" Text='<%# Bind("1301") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt13" runat="server" Text='<%# Bind("1302") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld14" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp14" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli14" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo14" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla14" runat="server" Text='<%# Bind("1400") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln14" runat="server" Text='<%# Bind("1401") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt14" runat="server" Text='<%# Bind("1402") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld15" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp15" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli15" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo15" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla15" runat="server" Text='<%# Bind("1500") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln15" runat="server" Text='<%# Bind("1501") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt15" runat="server" Text='<%# Bind("1502") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld16" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp16" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli16" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo16" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla16" runat="server" Text='<%# Bind("1600") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln16" runat="server" Text='<%# Bind("1601") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt16" runat="server" Text='<%# Bind("1602") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld17" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp17" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli17" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo17" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla17" runat="server" Text='<%# Bind("1700") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln17" runat="server" Text='<%# Bind("1701") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt17" runat="server" Text='<%# Bind("1702") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld18" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp18" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli18" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo18" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla18" runat="server" Text='<%# Bind("1800") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln18" runat="server" Text='<%# Bind("1801") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt18" runat="server" Text='<%# Bind("1802") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld19" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp19" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli19" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo19" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla19" runat="server" Text='<%# Bind("1900") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln19" runat="server" Text='<%# Bind("1901") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt19" runat="server" Text='<%# Bind("1902") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld20" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp20" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli20" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo20" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla20" runat="server" Text='<%# Bind("2000") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln20" runat="server" Text='<%# Bind("2001") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt20" runat="server" Text='<%# Bind("2002") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld21" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp21" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli21" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo21" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla21" runat="server" Text='<%# Bind("2100") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln21" runat="server" Text='<%# Bind("2101") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt21" runat="server" Text='<%# Bind("2102") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld22" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp22" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli22" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo22" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla22" runat="server" Text='<%# Bind("2200") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln22" runat="server" Text='<%# Bind("2201") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt22" runat="server" Text='<%# Bind("2202") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld23" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp23" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli23" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo23" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla23" runat="server" Text='<%# Bind("2300") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln23" runat="server" Text='<%# Bind("2301") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt23" runat="server" Text='<%# Bind("2302") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld24" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp24" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli24" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo24" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla24" runat="server" Text='<%# Bind("2400") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln24" runat="server" Text='<%# Bind("2401") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt24" runat="server" Text='<%# Bind("2402") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld25" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp25" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli25" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo25" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla25" runat="server" Text='<%# Bind("2500") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln25" runat="server" Text='<%# Bind("2501") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt25" runat="server" Text='<%# Bind("2502") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld26" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp26" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli26" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo26" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla26" runat="server" Text='<%# Bind("2600") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln26" runat="server" Text='<%# Bind("2601") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt26" runat="server" Text='<%# Bind("2602") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld27" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp27" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli27" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo27" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla27" runat="server" Text='<%# Bind("2700") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln27" runat="server" Text='<%# Bind("2701") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt27" runat="server" Text='<%# Bind("2702") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld28" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp28" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli28" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo28" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla28" runat="server" Text='<%# Bind("2800") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln28" runat="server" Text='<%# Bind("2801") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt28" runat="server" Text='<%# Bind("2802") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld29" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp29" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli29" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo29" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla29" runat="server" Text='<%# Bind("2900") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln29" runat="server" Text='<%# Bind("2901") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt29" runat="server" Text='<%# Bind("2902") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld30" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp30" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli30" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo30" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla30" runat="server" Text='<%# Bind("3000") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln30" runat="server" Text='<%# Bind("3001") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt30" runat="server" Text='<%# Bind("3002") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="90px">
                            <tr>
                                <td style="text-align: center; width: auto; background-color: skyblue; color: black; border: solid 1px;" colspan="4">
                                    <asp:Label ID="lbld31" runat="server" Text="Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 30px; color:white">
                                    <center>
                                        <asp:Label ID="lblp31" runat="server" Text="P/A"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 80px; color:white">
                                    <center>
                                        <asp:Label ID="lbli31" runat="server" Text="IN"></asp:Label></center>
                                </td>
                                <td style="text-align: left; width: 70px; color:white">
                                    <center>
                                        <asp:Label ID="lblo31" runat="server" Text="OUT"></asp:Label></center>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 93px; padding: 0; border-spacing: 0; margin: 0; border: 0;">
                            <tr>
                                <td style="text-align: left; width: 30px;">
                                    <center>
                                        <asp:Label ID="lbla31" runat="server" Text='<%# Bind("3100") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lbln31" runat="server" Text='<%# Bind("3101") %>' CssClass="cssLabel" /></center>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <center>
                                        <asp:Label ID="lblt31" runat="server" Text='<%# Bind("3102") %>' CssClass="cssLabel" /></center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="400px" />
                    <ItemStyle Width="400px" />
                    <FooterStyle Width="400px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table width="100%" align="left">
            <tr>                
                <td style="background-color: #9b062e">
                    <asp:Label ID="lblNodata" runat="server" Text="Record Not Available!!!" ForeColor="white" Style="margin-left: 5px; width: 100%" />
                </td>
                <td>
                    <asp:Button ID="btnExport" runat="server" CssClass="cssButton" Text="Export to Excel" OnClick="bntExport_Click" />
                </td>
                <td align="center">&nbsp;</td>
                <td align="right">
                    <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click" CssClass="cssButton">Back</asp:LinkButton>
                </td>
            </tr>
        </table>
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
                    <asp:GridView ID="GVDeatils" Width="100%" CssClass="GridViewStyle" PageSize="16" runat="server" AllowPaging="false" CellPadding="2" GridLines="None"
                        AutoGenerateColumns="False" OnRowDataBound="GVDeatils_RowDataBound" ShowFooter="True" ForeColor="#333333" AllowSorting="True">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                        <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
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
</asp:Content>




