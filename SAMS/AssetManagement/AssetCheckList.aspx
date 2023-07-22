<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetCheckList.aspx.cs" Inherits="AssetManagement_AssetCheckList" EnableViewState="true" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklist" Font-Bold="True" ForeColor="Red" Height="220px" runat="server" GroupingText="Asset CheckList">
                <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetCategory" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCategory %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlAssetCategory" runat="server" CssClass="csstxtbox" Width="150px" Enabled="false"></asp:DropDownList>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetSubCategory" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetSubCategory %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlAssetSubCategory" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"></asp:DropDownList>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetManufacture" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ManufacturerName %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlAssetManufacture" runat="server" Width="150px" CssClass="csstxtbox" Enabled="false"></asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: right;" nowrap="nowrap">
                            <asp:Label ID="lblAssetCode" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCode %>"></asp:Label>
                        </td>
                        <td style="text-align: left;" nowrap="nowrap">
                            <asp:TextBox ID="txtAssetCode" CssClass="csstxtbox"
                                runat="server" Enabled="false"></asp:TextBox>

                        </td>

                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetName %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtAssetName" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblDescription" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Description %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtDescription" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblModelNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ModelNo %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtModelNo" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblModelName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ModelName %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtModelName" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>

                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SerialNo %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtSerialNo" Enabled="false" CssClass="csstxtbox"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblServicetype" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SelectServiceType %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlServicetype" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlServicetype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblChecklistName" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ChecklistName %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtCheccklistname" CssClass="csstxtbox" MaxLength="100" ValidationGroup="AssetChecklist"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtCheccklistname" ValidationGroup="AssetChecklist" ControlToValidate="txtCheccklistname" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hfAssetId" runat="server" Value="0" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div style="margin-left: 500px; margin-top: -30px;">
                <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:Resource,Submit %>" ValidationGroup="AssetChecklist" CausesValidation="true" CssClass="cssButton" OnClick="btnSubmit_Click" Visible="true" />
                <asp:Button ID="btnack" runat="server" Text="<%$ Resources:Resource,Back %>" CssClass="cssButton" OnClick="btnack_Click" Visible="true" />
            </div>
            <asp:Label ID="lblChecklistNameError" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklistDetail" Font-Bold="True" Height="420px" runat="server" Style="margin-top: 40px">
                <asp:GridView Width="8%" ID="gvAssetChecklistName" CssClass="GridViewStyle" runat="server" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None" OnPageIndexChanging="gvAssetChecklistName_PageIndexChanging"
                    AutoGenerateColumns="False">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>

                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ChecklistName %>">

                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetCheckListAutoId" runat="server" Value='<%# Bind("AssetCheckListAutoId") %>' />
                                <asp:LinkButton ID="lbChecklistName" CssClass="cssLabel" runat="server" Text='<%# Bind("CheckListName") %>' OnClick="lbChecklistName_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="30px" />
                            <ItemStyle Width="30px" />
                            <FooterStyle Width="30px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </asp:Panel>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklistNameDetail" Font-Bold="True" ForeColor="Red" Height="420px" runat="server" Style="margin-left: 150px; margin-top: -420px" Visible="false">
                <asp:HiddenField ID="hfid" runat="server" />
                <asp:GridView Width="100%" ID="gvAssetChecklistNameDetail" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAssetChecklistNameDetail_RowDataBound" OnRowCommand="gvAssetChecklistNameDetail_RowCommand"
                    OnRowDeleting="gvAssetChecklistNameDetail_RowDeleting" OnRowEditing="gvAssetChecklistNameDetail_RowEditing" OnPageIndexChanging="gvAssetChecklistNameDetail_PageIndexChanging"
                    OnRowUpdating="gvAssetChecklistNameDetail_RowUpdating" OnRowCancelingEdit="gvAssetChecklistNameDetail_RowCancelingEdit">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName%>">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                    ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                    ValidationGroup="EditChecklistNameDetail" />

                                <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                    ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                    CommandName="Cancel" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="NewChecklistNameDetail" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />

                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                    CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                    CommandName="Edit" />
                                &nbsp;
                                                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                            </ItemTemplate>
                            <FooterStyle Width="120px" />
                            <HeaderStyle Width="120px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ChecklistName %>">
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfAssetCheckListDetailAutoId" runat="server" Value='<%# Bind("AssetCheckListDetailAutoId") %>' />
                                <asp:HiddenField ID="hfAssetCheckListNameAutoId" runat="server" Value='<%# Bind("AssetCheckListAutoId") %>' />
                                <asp:Label ID="lblChecklistName" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("CheckListName") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetCheckListDetailAutoId" runat="server" Value='<%# Bind("AssetCheckListDetailAutoId") %>' />
                                <asp:HiddenField ID="hfAssetCheckListNameAutoId" runat="server" Value='<%# Bind("AssetCheckListAutoId") %>' />

                                <asp:Label ID="lblChecklistName" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("CheckListName") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,CheckListItems %>">
                            <EditItemTemplate>
                                <%--  <asp:HiddenField ID="hfAssetSubCategoryAutoId" runat="server" Value='<%# Bind("AssetSubCategoryAutoId") %>' />--%>
                                <asp:TextBox ID="txtChecklistNameDetail" MaxLength="100" ValidationGroup="EditChecklistNameDetail" CssClass="csstxtbox" runat="server" Text='<%# Bind("Items") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtAssetSubCategory" runat="server" ControlToValidate="txtChecklistNameDetail"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="EditChecklistNameDetail"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <%--  <asp:HiddenField ID="hfAssetSubCategoryAutoIdnew" runat="server" Value="0" />--%>

                                <asp:TextBox ID="txtChecklistNameDetail" MaxLength="100" ValidationGroup="NewChecklistNameDetail" CssClass="csstxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvnewtxtAsseSubtCategory" runat="server" ControlToValidate="txtChecklistNameDetail"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="NewChecklistNameDetail"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%--<asp:HiddenField ID="hfAssetSubCategoryAutoId" runat="server" Value='<%# Bind("AssetSubCategoryAutoId") %>' />--%>
                                <asp:Label ID="lblChecklistNameDetail" Width="200px" CssClass="cssLabel" runat="server" Text='<%# Bind("Items") %>'></asp:Label>

                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblChecklistDetail" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

