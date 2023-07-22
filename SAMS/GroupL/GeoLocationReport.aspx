<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="GeoLocationReport.aspx.cs" Inherits="GroupL_GeoLocationReport" %>



 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
            color: white;
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
                            <asp:Label ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="From Date"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style5">
                            <asp:TextBox ID="txtDutyDate" CssClass="csstxtbox" runat="server" Width="120px" ></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HlimgDutyDate"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CEDutyDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDutyDate" PopupButtonID="HlimgDutyDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                       <td class="auto-style6" style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="cssLabel" Text="<%$ Resources:Resource,ToDate  %>" ></asp:Label>
                            </td>
                            <td class="auto-style7" style="text-align: left;">
                                <asp:TextBox ID="txtTodate" runat="server"  CssClass="csstxtbox"  Width="100px"></asp:TextBox>
                                <asp:HyperLink ID="HyperLink1" runat="server" Height="19px" ImageUrl="../Images/pdate.gif" Style="vertical-align: top;"  Width="20px"></asp:HyperLink>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="HyperLink1" TargetControlID="txtTodate" />
                            </td>
                  
                                <td style="text-align: right;" class="auto-style8">
                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,EmployeeNumber  %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtEmployeeNo" Width="120px" CssClass="csstxtbox" runat="server">
                            </asp:TextBox>
                            </td>
                      
                         
                            <td>
                                <asp:Button ID="btnView" runat="server" CssClass="cssButton" OnClick="btnView_Click" Text="Search" />
                            </td>
                         
                         
                      
                              
                          
                      
                        
                       
                         </tr>
                </table>
            </div>

            <br />
            <div id="divGV" runat="server">
                <asp:GridView ID="gvAttendence" Width="100%" CssClass="GridViewStyle" PageSize="50" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAttendence_RowDataBound" ShowFooter="false" OnPageIndexChanging="gvAttendence_PageIndexChanging"
              
              
           
               
                    >
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2E6293" ForeColor="White" CssClass="csspager" />
                    <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                    <Columns>
                      
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="120px" ItemStyle-Width="120px" >
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmpID") %>'></asp:Label>
                            </ItemTemplate>
                           
                            <HeaderStyle  Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Latitude" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("Latitude") %>'></asp:Label>
                            </ItemTemplate>
                         
                            <HeaderStyle  Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Longitude" HeaderStyle-Width="150px"
                            FooterStyle-Width="150px" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Text='<%# Bind("Longitude") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Location Address" HeaderStyle-Width="500px"
                            FooterStyle-Width="500px" ItemStyle-Width="500px">
                            <ItemTemplate>
                             
                              
                                <asp:Label ID="lblShift" CssClass="cssLable" runat="server" Text='<%# Bind("LocationAddress") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,Date %>" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time" HeaderStyle-Width="200px"
                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" CssClass="cssLable" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                     
                      
                      
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"  
                         
                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click" Visible="false" />
                 <asp:Label ID="lblerrormsg" runat="server" CssClass="cssLabel" ForeColor="Red" Font-Bold="true" Font-Size="Medium"  />
               
            </div>
      
           
             

                   
             
       </ContentTemplate>
        <Triggers>
     
        
                <asp:PostBackTrigger ControlID="btnExport" />
        
        </Triggers>
    </Ajax:UpdatePanel>
</asp:Content>

