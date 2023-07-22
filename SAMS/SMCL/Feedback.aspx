<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="SMCL_Feedback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetMaster" Font-Bold="True" ForeColor="Red" Height="720px" runat="server">
                <br />
               <b>    <asp:Label ID="LabeltotalAsset" Text="Below are the list of Received Feedbacks : " runat="server" CssClass="cssLabel" style="color:#2E6293;font-size:large;margin-left:150px;font-weight:700"></asp:Label></b> 
     
                 <br />    <br />
        
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
                       
                         <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
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
                     <asp:TemplateField HeaderText="Feedback Date n Time" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetSerialNo" Width="120px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EntryDate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="120px" />
                            <ItemStyle Width="120px" />
                            <FooterStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Feedback" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetModelNo" Width="300px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Feedback") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                       
                          
                    </Columns>
                </asp:GridView>
            </asp:Panel>
          
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

