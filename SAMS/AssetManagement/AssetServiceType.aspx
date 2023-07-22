<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetServiceType.aspx.cs" Inherits="AssetManagement_AssetServiceType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:GridView ID="gvAssetServiceType" Width="100%" CssClass="GridViewStyle" PageSize="15"
                runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                AutoGenerateColumns="False" OnRowCancelingEdit="gvAssetServiceType_RowCancelingEdit"
                OnRowCommand="gvAssetServiceType_RowCommand" OnRowDataBound="gvAssetServiceType_RowDataBound"
                OnRowDeleting="gvAssetServiceType_RowDeleting" OnRowEditing="gvAssetServiceType_RowEditing" OnRowUpdating="gvAssetServiceType_RowUpdating"
                ShowFooter="True" OnPageIndexChanging="gvAssetServiceType_PageIndexChanging" OnSelectedIndexChanged="gvAssetServiceType_SelectedIndexChanged">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                        FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdateAsset" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImageButton2Asset" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEditAsset" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="IBDeleteAsset" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>">
                        <EditItemTemplate>

                             <asp:HiddenField ID="hfAssetServiceTypeAutoId" runat="server" Value='<%# Bind("AssetServiceTypeAutoId") %>' />

                            <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>

                        </EditItemTemplate>
                         <ItemTemplate>
                              <asp:HiddenField ID="hfAssetServiceTypeAutoId" runat="server" Value='<%# Bind("AssetServiceTypeAutoId") %>' />
                            <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            
                            <asp:DropDownList ID="ddlAssetName" CssClass="cssDropDown" Width="25%" runat="server">
                            </asp:DropDownList>

                        </FooterTemplate>
                       
                        <HeaderStyle CssClass="cssLabelHeader" Width="350px" />
                        <ItemStyle Width="350px" />
                        <FooterStyle Width="350px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,AssetServiceTypeName %>" HeaderStyle-Width="700px"
                        FooterStyle-Width="700px" ItemStyle-Width="700px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAssetServiceTypeName" Width="700px" MaxLength="100" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("AssetServiceTypename") %>'></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvtxtAssetServiceTypeName" runat="server" ControlToValidate="txtAssetServiceTypeName"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAssetServiceTypeName" CssClass="cssLable" runat="server" Text='<%# Bind("AssetServiceTypename") %>'></asp:Label>
                       
                             </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewAssetServiceTypeName" Width="700px" MaxLength="100" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewAssetServiceTypeName"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>

