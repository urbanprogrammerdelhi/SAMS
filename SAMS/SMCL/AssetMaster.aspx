<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetMaster.aspx.cs" Inherits="SMCL_AssetMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetMaster" Font-Bold="True" ForeColor="Red" Height="720px" runat="server">
                <br />
               <b>    <asp:Label ID="LabeltotalAsset" Text="Total No. Of Asset's : " runat="server" CssClass="cssLabel" style="color:#2E6293;font-size:large;margin-left:150px;font-weight:700"></asp:Label></b> 
          <asp:Label ID="lblNoofAsset"  runat="server" CssClass="cssLabel" style="color:red;font-size:large;font-weight:700"></asp:Label>
                  <asp:Button ID="btnAddNew" runat="server" Text="Add New" Style="margin-left: 400px;" CssClass="cssButton" OnClick="btnAddNew_Click" Visible="false"/>
                <br />
                 <br />
        
                <asp:GridView Width="90%" ID="gvAssetMaster" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="20" CellPadding="1" GridLines="None"
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
                       
                         <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCode %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AutoID") %>' />
                                   <asp:Label ID="LbAssestcode" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>' ></asp:Label>
                       
                           <asp:LinkButton Visible="false" ID="lblAssetCode" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>' OnClick="LbAssestName_Click"></asp:LinkButton>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Asset Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                
                                <asp:Label ID="LbAssestName1" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Status") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Asset Category" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetModelNo" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Asset Location" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetSerialNo" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:Resource,ManufacturerName %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Make") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Model No." HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer1" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ModelNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Serial No." HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer2" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Specification" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer3" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Specification") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Comisision Date" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer4" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ComisisionDate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />

                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Handover Date" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer5" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("HandoverDate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Warranty Date From" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer6" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("WarrantyDateFrom") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Warranty Date To" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer7" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("WarrantyDateTo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Comments" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer8" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Comments") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,CheckList %>" HeaderStyle-ForeColor="White" Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton Visible="false" ID="btnCheckList" Width="100px" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,CheckList %>" OnClick="btnCheckList_Click"></asp:LinkButton>
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



