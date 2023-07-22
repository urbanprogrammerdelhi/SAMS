<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ShortageReport.aspx.cs" Inherits="GroupL_ShortageReport" %>

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
          .auto-style4 {
              width: 68px;
          }
          .auto-style5 {
              width: 201px;
          }
          .auto-style8 {
              width: 83px;
          }
            .auto-style9 {
                width: 80px;
            }
            .auto-style10 {
                border: 1px solid #B6B6B6;
                color: black;
                text-indent: 0.01px;
                text-overflow: "";
                border-radius: 2px;
                padding: 1px 2px 1px 1px;
                box-shadow: inset 0 0 1px rgba(000,000,000, 0.5);
                font-family: robotolight;
                margin: 1px 3px 3px 0px;
            }
    </style>
     <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>            
            <br />
            <div style="overflow: auto;">

                 
                <table align="center" width="100%" border="0" cellspacing="1px" cellpadding="1px">
               
                    <tr style="background-color: #D3E8F4">
                       
                        <td style="text-align: right;" class="auto-style4">
                            <asp:Label ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="Date" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style5">
                            <asp:TextBox ID="txtDutyDate" CssClass="csstxtbox" runat="server" Width="120px" OnTextChanged="txtDutyDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HlimgDutyDate"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CEDutyDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDutyDate" PopupButtonID="HlimgDutyDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                       
                    
                        
                  <td class="auto-style9" style="text-align: right;">
                           <asp:Label ID="LabelCity" CssClass="cssLabel" runat="server" Text="Select Region" Font-Bold="true" Width="120px"></asp:Label>
                     </td>
                        <td>
                            <asp:DropDownList ID="ddlregion" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlregion_SelectedIndexChanged" AutoPostBack="true"  Width="128px"></asp:DropDownList>
                        </td>
                              
                     
                                <td style="text-align: right;" class="auto-style8">
                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="Select Branch" Font-Bold="true" Width="120px"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                                   <asp:DropDownList ID="ddlbranch" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged" AutoPostBack="true" Width="149px"></asp:DropDownList>
              
                            </td>
                             <td class="auto-style9" style="text-align: right;">
                           <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="Select Employee" Font-Bold="true" Width="120px"></asp:Label>
                     </td>
                        <td>
                            <asp:DropDownList ID="ddlemployee" runat="server" CssClass="cssDropDown" OnSelectedIndexChanged="ddlemployee_SelectedIndexChanged" AutoPostBack="true"  Width="128px">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                    <asp:ListItem Text="Present" Value="Present"></asp:ListItem>
                                    <asp:ListItem Text="Absent" Value="Absent"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                      
                     
                         </tr>
                </table>
            </div>
             <div >
                                         
                      <asp:Button ID="btnAll" runat="server" OnClick="btnAll_Click" style="width:300px;height:70px;background-color:orange;font-size:medium;color:white" Font-Bold="true" Text="Total Employees" Visible="true"  />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="width:300px;height:70px;background-color:green;font-size:medium;color:white" Font-Bold="true"  Text="Present" Visible="true"  />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="width:300px;height:70px;background-color:red;font-size:medium;color:white" Font-Bold="true"  Text="Absent"  Visible="true" />
                 </div>
            <br />
            <div id="divGV" runat="server">
                <asp:GridView ID="gvAttendence" Width="100%" CssClass="GridViewStyle" PageSize="150" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
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
                     <%--    <asp:TemplateField HeaderText="Client Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblClientName" CssClass="cssLable" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="350px" />
                            <ItemStyle Width="350px" />
                            <FooterStyle Width="350px" />
                        </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="Company" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblbranchnamecma" CssClass="cssLable" runat="server" Text='<%# Bind("CompanyDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="350px" />
                            <ItemStyle Width="350px" />
                            <FooterStyle Width="350px" />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Branch " HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblbranchname" CssClass="cssLable" runat="server" Text='<%# Bind("HrLocationDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="250px" />
                            <ItemStyle Width="250px" />
                            <FooterStyle Width="250px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Region " HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblbranchnameregion" CssClass="cssLable" runat="server" Text='<%# Bind("LocationDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="450px" />
                            <ItemStyle Width="450px" />
                            <FooterStyle Width="450px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeCode" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="400px" />
                            <ItemStyle Width="400px" />
                            <FooterStyle Width="400px" />
                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="400px" />
                            <ItemStyle Width="400px" />
                            <FooterStyle Width="400px" />
                        </asp:TemplateField>




                       
                         
                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                      

                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="400px"
                            FooterStyle-Width="400px" ItemStyle-Width="400px">
                            <ItemTemplate>
                                <asp:Label ID="lblShift" CssClass="cssLable" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
