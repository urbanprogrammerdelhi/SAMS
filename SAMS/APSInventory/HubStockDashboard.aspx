<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HubStockDashboard.aspx.cs" Inherits="APSInventory_HubStockDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklist" Font-Bold="True" ForeColor="Red" Height="150px" runat="server" GroupingText="Hub Stock Dashboard">
                <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                     <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblOffice" CssClass="cssLable" runat="server" Text="Select Hub :  " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                         </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddloffice" runat="server" Font-Bold="true" ForeColor="Black" Width="150px" CssClass="csstxtbox" >
     
    </asp:DropDownList>
                        </td>
                          </tr>      
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetCategory" CssClass="cssLable" runat="server" Text="Select Equipment : " Font-Bold="true" Font-Size="Medium" ForeColor="Black" ></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlItemDescription" runat="server" Font-Bold="true" CssClass="csstxtbox" Width="150px" ForeColor="Black" ></asp:DropDownList>
                        </td>
                          </tr>  
                         
                   

                   
                      <tr>
                                  <td></td><td>
                                    <asp:Button ID="btnView" runat="server" Text="View Stock"  CssClass="cssButton" OnClick="btnView_Click" />
                                  
                                          </td>
                             </tr>
                </table>
                <asp:Label ID="lblmsg" runat="server" CssClass="cssLabel" style="color:red;font-size:medium" Font-Bold="true"></asp:Label>
            </asp:Panel>
            <div id="divStock" runat="server" visible="false">
               </div>
             <asp:Panel ScrollBars="Auto" ID="pnlorderstatus" Font-Bold="True" ForeColor="Red" Height="800px" runat="server">
                <asp:GridView Width="50%" ID="gvOrderGrid" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="35" CellPadding="1" GridLines="None"
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
                         
                        <asp:TemplateField HeaderText="Equipment Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfmaterialid" runat="server" Value='<%# Bind("[MaterialAutoID]") %>' />
                           <asp:Label ID="lblItemname" Width="500px" Style="word-break: break-all;" Font-Bold="true" Font-Size="Medium" ForeColor="Black"  CssClass="cssLabel" runat="server" Text='<%# Bind("Equipment") %>' ></asp:Label>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="500px" />
                            <ItemStyle Width="500px" />
                            <FooterStyle Width="500px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Available Stock" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                               <%-- <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                                <asp:Label ID="lblStock" Width="150px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Green"  CssClass="cssLabel" runat="server" Text='<%# Bind("AvailableStock") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="Action" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Button ID="btnViewStock" runat="server" Text="View Stock Details"  CssClass="cssButton" OnClick="btnViewStock_Click" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
               <asp:HiddenField ID="QRValue" runat="server" />
            </asp:Panel>
            
             <asp:Panel  ID="pnlItemLedger" Font-Bold="True" ForeColor="Red" Height="800px" runat="server" Visible="false">
                   <asp:Label ID="Label1" runat="server" CssClass="cssLabel" style="color:red;font-size:large" Font-Bold="true" Text="Available Stock : "></asp:Label>
               <asp:Label ID="lblavailble" runat="server" CssClass="cssLabel" style="color:green;font-size:large" Font-Bold="true" ></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnback" runat="server" Text="<<Back to Stock List"  CssClass="cssButton" OnClick="btnback_Click" />
                                  <br />
                 <br />
                <asp:GridView Width="100%" ID="gvItemLedger" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="15" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False"  OnPageIndexChanging="gvItemLedger_PageIndexChanging" OnRowDataBound="gvItemLedger_RowDataBound" >
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
                         
                     
                        <asp:TemplateField HeaderText="Equipment Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                               <%-- <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />--%>
                                <asp:Label ID="lblStockIN" Width="200px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Black"  CssClass="cssLabel" runat="server" Text='<%# Bind("Equipment") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="Date" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              <asp:Label ID="lblStockID" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Black"  CssClass="cssLabel" runat="server" Text='<%# Bind("InvoiceDate") %>'></asp:Label>
                           </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Hub Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              <asp:Label ID="lblStockDesc" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Black"  CssClass="cssLabel" runat="server" Text='<%# Bind("HubName") %>'></asp:Label>
                           </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Item Quantity" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              <asp:Label ID="lblStockIQ" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Green"  CssClass="cssLabel" runat="server" Text='<%# Bind("[Quantity]") %>'></asp:Label>
                           </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                       
                         <asp:TemplateField HeaderText="Stock Type" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              <asp:Label ID="lblStockType" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Black"  CssClass="cssLabel" runat="server" Text='<%# Bind("TransactionType") %>'></asp:Label>
                           </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Branch Name where Send" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              <asp:Label ID="lblStockDeptName" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Black"  CssClass="cssLabel" runat="server" Text='<%# Bind("[BranchName]") %>'></asp:Label>
                           </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="CP Name where Received" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              <asp:Label ID="lblStockDeptName1" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Black"  CssClass="cssLabel" runat="server" Text='<%# Bind("[FromCP]") %>'></asp:Label>
                           </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Delivery Thru" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              <asp:Label ID="lblStockOfficeName" Width="100px" Style="word-break: break-all;  " Font-Bold="true" Font-Size="Medium" ForeColor="Black"  CssClass="cssLabel" runat="server" Text='<%# Bind("[DeliveryThru]") %>'></asp:Label>
                           </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
               <asp:HiddenField ID="HiddenField1" runat="server" />
            </asp:Panel>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
