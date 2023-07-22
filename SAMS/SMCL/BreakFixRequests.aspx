<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BreakFixRequests.aspx.cs" Inherits="SMCL_BreakFixRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetMaster" Font-Bold="True" ForeColor="Red" Height="720px" runat="server">
                <br />
               <b>    <asp:Label ID="LabeltotalAsset" Text="Below are the list of Break-Fix Requests : " runat="server" CssClass="cssLabel" style="color:#2E6293;font-size:large;margin-left:150px;font-weight:700"></asp:Label></b> 
     
                 <br />    <br />
        
                <asp:GridView Width="100%" ID="gvAssetMaster" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="20" CellPadding="1" GridLines="None"
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
                           <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="120px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="120px" ItemStyle-Width="120px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Schedule Technician" HeaderStyle-ForeColor="White" >
                            <ItemTemplate>
                                <asp:LinkButton  ID="btnschedule" Width="80px" CssClass="cssLabel" runat="server" Text="Click Here " OnClick="btnschedule_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="80px" />
                            <ItemStyle Width="80px" />
                            <FooterStyle Width="80px" />
                        </asp:TemplateField>
                      
                      

                          <asp:TemplateField HeaderText="Floor" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName12" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Floor") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Category" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName11" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("RequestType") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Asset Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName113" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Asset") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
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
                                <asp:Label ID="lblAssetSerialNo" Width="60px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EntryDate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="60px" />
                            <ItemStyle Width="60px" />
                            <FooterStyle Width="60px" />
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
                                <asp:Label ID="lblAssetSerialNo1111" Width="120px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ScheduleEmpCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="120px" />
                            <ItemStyle Width="120px" />
                            <FooterStyle Width="120px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                             
                                   <asp:Label ID="LbAssestcode" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>' ></asp:Label>
                       
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Email" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                  <asp:HiddenField ID="hfAutoID" runat="server" Value='<%# Bind("AutoId") %>' />
                                   <asp:HiddenField ID="hfScheduleStatus" runat="server" Value='<%# Bind("ScheduleStatus") %>' />
                                <asp:Label ID="LbAssestName" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EmailID") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName1" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("MobileNo") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
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
                            <asp:TextBox ID="txtfloor" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"></asp:TextBox>
                            </td>
                    </tr>
                       <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text="Category : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtCategory" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"  ></asp:TextBox>
                          
                              </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="Asset Code : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtAssetCode" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"  ></asp:TextBox>
                          
                              </td>
                    </tr>
                   
                           <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label2" CssClass="cssLable" runat="server" Text="Asset Name : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtAssetName" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"  ></asp:TextBox>
                          
                              </td>
                    </tr>
                   
                           <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="Problem Description : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtProblem" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"  ></asp:TextBox>
                          
                              </td>
                    </tr>

                           <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label5" CssClass="cssLable" runat="server" Text="Select Employee : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                         <asp:DropDownList ID="ddlEmp" runat="server" CssClass="cssDropDown" Width="150px"  >

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

