<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BranchStockDashboardaspx.aspx.cs" Inherits="APSInventory_BranchStockDashboardaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklist" Font-Bold="True" ForeColor="Red" Height="120px" runat="server" GroupingText="Branch Stock Dashboard">
                <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                     <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblOffice" CssClass="cssLable" runat="server" Text="Select Branch :  " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                         </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlBranch" runat="server" Font-Bold="true" ForeColor="Black" Width="350px" CssClass="csstxtbox" >
     
    </asp:DropDownList>
                        </td>
                          </tr>                   
                   

                   
                      <tr>
                                  <td></td><td>
                                    <asp:Button ID="btnView" runat="server" Text="View Stock Details"  CssClass="cssButton" OnClick="btnView_Click" />
                                  
                                          </td>
                             </tr>
                </table>
                <asp:Label ID="lblmsg" runat="server" CssClass="cssLabel" style="color:red;font-size:medium" Font-Bold="true"></asp:Label>
            </asp:Panel>
            <div id="divStock" runat="server" visible="false">
               </div>
             <asp:Panel ScrollBars="Auto" ID="pnlorderstatus" Font-Bold="True" ForeColor="Red" Height="1200px" runat="server">
                <asp:GridView Width="100%" ID="gvOrderGrid" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="35" CellPadding="1" GridLines="Both"
                    AutoGenerateColumns="False"  OnPageIndexChanging="gvOrderGrid_PageIndexChanging" OnRowDataBound="gvOrderGrid_RowDataBound" Visible="false">
                      <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>
                          <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" Width="50px" CssClass="cssLabel" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="50px"   />
                            <ItemStyle Width="50px" />
                            <FooterStyle Width="50px" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Branch Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfmaterialid" runat="server" Value='<%# Bind("[MaterialAutoID]") %>' />
                           <asp:Label ID="lblItemname" Width="150px" Style="word-break: break-all;" Font-Bold="true" Font-Size="Medium"   CssClass="cssLabel" runat="server" Text='<%# Bind("BranchName") %>' ></asp:Label>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Equipment Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                               <%-- <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                                <asp:Label ID="lblStock" Width="370px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium"   CssClass="cssLabel" runat="server" Text='<%# Bind("MaterialName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="370px" />
                            <ItemStyle Width="370px" />
                            <FooterStyle Width="370px" />
                        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="Received From Hub" HeaderStyle-ForeColor="White">
                             <ItemTemplate>
                               <%-- <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                                <asp:Label ID="lblStock1" Width="90px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium"   CssClass="cssLabel" runat="server" Text='<%# Bind("HubName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="90px" />
                            <ItemStyle Width="90px" />
                            <FooterStyle Width="90px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Received Date" HeaderStyle-ForeColor="White">
                             <ItemTemplate>
                               <%-- <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                                <asp:Label ID="lblStock12" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium"   CssClass="cssLabel" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Qty Received" HeaderStyle-ForeColor="White">
                             <ItemTemplate>
                               <%-- <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                                <asp:Label ID="lblStock123" Width="80px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium"   CssClass="cssLabel" runat="server" Text='<%# Bind("QuantityReceived") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="80px" />
                            <ItemStyle Width="80px" />
                            <FooterStyle Width="80px" />
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Spare Qty" HeaderStyle-ForeColor="White">
                             <ItemTemplate>
                               <%-- <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                                <asp:Label ID="lblStock1236" Width="70px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Red"   CssClass="cssLabel" runat="server" Text='<%# Bind("SpareQty") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="70px" />
                            <ItemStyle Width="70px" />
                            <FooterStyle Width="70px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Installed Qty" HeaderStyle-ForeColor="White">
                             <ItemTemplate>
                               <%-- <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                                <asp:Label ID="lblStock1234" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Green"   CssClass="cssLabel" runat="server" Text='<%# Bind("InstalledQty") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
              
            </asp:Panel>
            
       
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

