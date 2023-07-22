<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetMaster.aspx.cs" Inherits="AssetManagement_AssetMaster" EnableViewState="true" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetMaster" Font-Bold="True" ForeColor="Red" Height="690px" runat="server">
                <asp:GridView Width="100%" ID="gvAssetMaster" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="100" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAssetMaster_RowDataBound" OnRowCommand="gvAssetMaster_RowCommand"
                    OnRowDeleting="gvAssetMaster_RowDeleting" OnRowEditing="gvAssetMaster_RowEditing" OnPageIndexChanging="gvAssetMaster_PageIndexChanging"
                    OnRowUpdating="gvAssetMaster_RowUpdating" OnRowCancelingEdit="gvAssetMaster_RowCancelingEdit">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCode %>">
                            <ItemTemplate>
                           <asp:Label ID="lblAssetCode" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                                <asp:LinkButton ID="LbAssestName" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>' OnClick="LbAssestName_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ManufacturerName %>">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetmanufacturer" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ManufacturerName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelNo %>">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetModelNo" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ModelNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNo %>">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetSerialNo" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,TagId %>">
                            <ItemTemplate>
                           <asp:Label ID="lblTagID" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("TagId") %>'></asp:Label>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,CheckList %>">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnCheckList" Width="100px" CssClass="cssLabel" runat="server" Text='<%# Bind("Checklist") %>' OnClick="btnCheckList_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Button ID="btnAddNew" runat="server" Text="Add New" Style="margin-left: 500px;" CssClass="cssButton" OnClick="btnAddNew_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

