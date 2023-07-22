<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DailyAttendance.aspx.cs" Inherits="SAMS_DailyAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .modal {
            display: none;
            position: absolute;
            top: 0px;
            left: 0px;
            background-color: black;
            z-index: 100;
            opacity: 0.8;
            filter: alpha(opacity=60);
            -moz-opacity: 0.8;
            min-height: 100%;
        }

        #divImage {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: whitesmoke;
            height: 415px;
            width: 310px;
            padding: 3px;
            border: solid 1px black;
        }

        .csspager td {
            padding-left: 10px;
            padding-right: 10px;
            color: #009900;
            font-weight: bold;
            font-size: 10pt;
        }
          .auto-style3 {
              width: 222px;
          }
          .auto-style4 {
              width: 68px;
          }
          .auto-style5 {
              width: 201px;
          }
          .auto-style6 {
              width: 63px;
          }
          .auto-style7 {
              width: 207px;
          }
          .auto-style8 {
              width: 83px;
          }
    </style>
     <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>            
            <br />
            <div style="overflow: auto;">
                <table align="center" width="100%" border="0" cellspacing="1px" cellpadding="1px">
               
                    <tr style="background-color: #D3E8F4">
                       
                        <td style="text-align: right;" class="auto-style4">
                            <asp:Label ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style5">
                            <asp:TextBox ID="txtDutyDate" CssClass="csstxtbox" runat="server" Width="120px" OnTextChanged="txtDutyDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HlimgDutyDate"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CEDutyDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDutyDate" PopupButtonID="HlimgDutyDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                        <td style="text-align: right;" class="auto-style6" >
                            <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,ToDate  %>" Visible="false"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style7">
                            <asp:TextBox ID="txtTodate" CssClass="csstxtbox" runat="server" Visible="false" Width="120px" OnTextChanged="txtTodate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HyperLink1" Visible="false"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server" 
                                TargetControlID="txtTodate" PopupButtonID="HyperLink1" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                     
               
                              
                     
                                <td style="text-align: right;" class="auto-style8">
                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,EmployeeNumber  %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtEmployeeNo" Width="120px" CssClass="csstxtbox" runat="server">
                            </asp:TextBox>
                            </td>
                           <td></td>
                        <td>
                            <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,View %>" OnClick="btnView_Click" />
                        </td>
                       
                         </tr>
                </table>
            </div>

            <br />
            <div id="divGV" runat="server">
                <asp:GridView ID="gvAttendence" Width="100%" CssClass="GridViewStyle" PageSize="10" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAttendence_RowDataBound" ShowFooter="True" OnPageIndexChanging="gvAttendence_PageIndexChanging"
                    >
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#D3E8F4" ForeColor="Black" CssClass="csspager" />
                    <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="80px" ItemStyle-Width="80px" >
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Client Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblClientName" CssClass="cssLable" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="350px" />
                            <ItemStyle Width="350px" />
                            <FooterStyle Width="350px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Zone" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblZone" CssClass="cssLable" runat="server" Text='<%# Bind("Zone") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="State" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblstate" CssClass="cssLable" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblBranchcode" CssClass="cssLable" runat="server" Text='<%# Bind("BranchCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Branch Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblbranchname" CssClass="cssLable" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="350px" />
                            <ItemStyle Width="350px" />
                            <FooterStyle Width="350px" />
                        </asp:TemplateField>--%>
                     

                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,Date %>" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="In Time" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" CssClass="cssLable" runat="server" Text='<%# Bind("InTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                     
                        <asp:TemplateField HeaderText="Out Time" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblOuttime" CssClass="cssLable" runat="server" Text='<%# Bind("OutTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Working Minutes" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblLongitude" CssClass="cssLable" runat="server" Text='<%# Bind("TotalMin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="IMEI" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblIMEI" CssClass="cssLable" runat="server" Text='<%# Bind("IMEI") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Cluster No." HeaderStyle-Width="200px"
                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblCluster" CssClass="cssLable" runat="server" Text='<%# Bind("ClusterNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"
                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click" Visible="false" />
                <asp:Label ID="lblmsg" runat="server" CssClass="label-danger" Text="Attendance Not Available..." ForeColor="White" Visible="false"/>
            </div>

       </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
    </Ajax:UpdatePanel>
</asp:Content>

