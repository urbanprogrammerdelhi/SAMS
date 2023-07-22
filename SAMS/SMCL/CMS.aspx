<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CMS.aspx.cs" Inherits="SMCL_CMS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetMaster" Font-Bold="True" ForeColor="Red" Height="720px" runat="server">
                <br />
               <b>    <asp:Label ID="LabeltotalAsset" Text="Below are the list of Complaints : " runat="server" CssClass="cssLabel" style="color:#2E6293;font-size:large;margin-left:150px;font-weight:700"></asp:Label></b> 
     

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
                       <td style="text-align: right;" class="auto-style6" >
                            <asp:Label ID="Label6" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,ToDate  %>" ></asp:Label>
                        </td>
                           <td style="text-align: left;" class="auto-style7">
                            <asp:TextBox ID="txtTodate" CssClass="csstxtbox" runat="server"  Width="100px" ></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HyperLink1" 
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server" 
                                TargetControlID="txtTodate" PopupButtonID="HyperLink1" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>      
                  
                                <td style="text-align: right;" class="auto-style8">
                            <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="Search By Complaint No. "></asp:Label>
   <asp:TextBox ID="txtdneg" Width="45px" CssClass="csstxtbox" runat="server" Text="DNEG-" Enabled="false" ForeColor="Black" Font-Bold="true">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtEmployeeNo" Width="60px" CssClass="csstxtbox" runat="server">
                            </asp:TextBox>
                            </td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <td>
                            <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="Search" OnClick="btnView_Click" />
                        </td>
                        
                          <td>
                            <asp:Button ID="btnAll" runat="server" CssClass="cssButton" Text="View All" OnClick="btnAll_Click" />
                        </td>
                        
                                              
                        
                       
                         </tr>
                </table>
            </div>

                
                <br />


        
                <asp:GridView Width="150%" ID="gvAssetMaster" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="50" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAssetMaster_RowDataBound" 
                OnPageIndexChanging="gvAssetMaster_PageIndexChanging"
                 >
                      <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#DBDDF8" />
                    <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" />
                       <PagerStyle BackColor="#2E6293" ForeColor="White"  />
                    <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>
                         
                          <asp:TemplateField HeaderText="Schedule Technician" HeaderStyle-ForeColor="White" >
                            <ItemTemplate>
                                <asp:LinkButton  ID="btnschedule" Width="120px" CssClass="cssLabel" runat="server" Text="Click Here " OnClick="btnschedule_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="120px" />
                            <ItemStyle Width="120px" />
                            <FooterStyle Width="120px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="S.No.   " HeaderStyle-Width="150px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="150px" ItemStyle-Width="150px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Complaint No." HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="lblcompl" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ComplaintNo") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                      

                          <asp:TemplateField HeaderText="Floor" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName12" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Floor") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Type Of Request" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName11" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("RequestType") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Location" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName113" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Asset") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
  <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName1131" Width="70px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Status") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="70px" />
                            <ItemStyle Width="70px" />
                            <FooterStyle Width="70px" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Problem Date n Time" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetSerialNo" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EntryDate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Problem Description" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetModelNo" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Problem") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Schedule Emp Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetSerialNo1111" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ScheduleEmpCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                             
                                   <asp:Label ID="LbAssestcode" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>' ></asp:Label>
                       
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Email" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                  <asp:HiddenField ID="hfAutoID" runat="server" Value='<%# Bind("AutoId") %>' />
                                   <asp:HiddenField ID="hfScheduleStatus" runat="server" Value='<%# Bind("ScheduleStatus") %>' />
                                <asp:Label ID="LbAssestName" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EmailID") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                       
                 
                       
                       
                          
                    </Columns>
                </asp:GridView>

                <div id="divSchedule" runat="server" visible="false" >

                      <table  width="50%" border="0" cellspacing="0px" cellpadding="0px">
                     <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetManufacture" CssClass="cssLable" runat="server" Text=" Floor : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtfloor" runat="server" Width="300px" CssClass="csstxtbox" Enabled="false"></asp:TextBox>
                            </td>
                    </tr>
                       <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text="Type Of Request : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtCategory" runat="server" Width="300px" CssClass="csstxtbox" Enabled="false"  ></asp:TextBox>
                          
                              </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="Location : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtAssetCode" runat="server" Width="300px" CssClass="csstxtbox" Enabled="false"  ></asp:TextBox>
                          
                              </td>
                    </tr>
                   
                        
                   
                           <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="Problem Description : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtProblem" runat="server" Width="300px" CssClass="csstxtbox" Enabled="false"  ></asp:TextBox>
                          
                              </td>
                    </tr>

                           <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label5" CssClass="cssLable" runat="server" Text="Select Employee : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                         <asp:DropDownList ID="ddlEmp" runat="server" CssClass="cssDropDown" Width="300px"  >

                            </asp:DropDownList>
                          
                              </td>
                    </tr>
                         
                    
                   
                     </table>
                     <br />
                          <br />
                       <asp:Button ID="btnBack" runat="server" CssClass="cssButton" OnClick="btnBack_Click" Text="<< Back" />
                            <asp:Button ID="btnScheduleemp" runat="server" CssClass="cssButton" OnClick="btnScheduleemp_Click" Text="Schedule Employee" />
                    <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Medium"></asp:Label>
                </div>
            </asp:Panel>
          
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


