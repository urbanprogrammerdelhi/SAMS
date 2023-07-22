<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="IPSGateINOut.aspx.cs" Inherits="AssetManagement_IPSGateINOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ScrollBars="Auto" ID="PanelAssetChecklist" Font-Bold="True" ForeColor="Red" Height="80px" runat="server" GroupingText="Invoice Details">
                <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetCategory" CssClass="cssLable" runat="server" Text="Vendor Name : "></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlAssetCategory" runat="server" CssClass="csstxtbox" Width="150px" Enabled="false"></asp:DropDownList>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetSubCategory" CssClass="cssLable" runat="server" Text="Invoice No. : "></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtInvoiceNo" runat="server" Width="150px" CssClass="csstxtbox" ></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssetManufacture" CssClass="cssLable" runat="server" Text="Date : "></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="ddlAssetManufacture" runat="server" Width="150px" CssClass="csstxtbox" ></asp:TextBox>
                        </td>
                          <td style="text-align: right;">
                            <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="Invoice Amount : "></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtInvoiceAmount" runat="server" Width="150px" CssClass="csstxtbox" ></asp:TextBox>
                        </td>

                    </tr>
                        </asp:Panel>
                 <asp:Panel ScrollBars="Auto" ID="Panel1" Font-Bold="True" ForeColor="Red" Height="120px" runat="server" GroupingText="Items Details">
                         <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td style="text-align: right;" nowrap="nowrap">
                            <asp:Label ID="lblAssetCode" Width="100px" CssClass="cssLable" runat="server" Text="Item Description : "></asp:Label>
                        </td>
                        <td style="text-align: left;" nowrap="nowrap">
                            <asp:DropDownList ID="ddlItemDescription" CssClass="cssDropDown" Width="150px"
                                runat="server" Enabled="false"></asp:DropDownList>

                        </td>

                      <%--  <td style="text-align: right;">
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

                        </td>--%>

                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblModelNo" CssClass="cssLable" runat="server" Text="Item Quantity : "></asp:Label>
                        </td>
                        <td style="text-align: left;" nowrap="nowrap">
                            <asp:DropDownList ID="ddlQuantity" CssClass="cssDropDown" Width="150px"
                                runat="server" Enabled="false">
                                <asp:ListItem  Text="1" Value="1"></asp:ListItem>
                                      <asp:ListItem  Text="2" Value="2"></asp:ListItem>
                                      <asp:ListItem  Text="3" Value="3"></asp:ListItem>
                                      <asp:ListItem  Text="4" Value="4"></asp:ListItem>
                                      <asp:ListItem  Text="5" Value="5"></asp:ListItem>
                                      <asp:ListItem  Text="6" Value="6"></asp:ListItem>
                                      <asp:ListItem  Text="7" Value="7"></asp:ListItem>
                                      <asp:ListItem  Text="8" Value="8"></asp:ListItem>
                                      <asp:ListItem  Text="9" Value="9"></asp:ListItem>
                                      <asp:ListItem  Text="10" Value="10"></asp:ListItem>
                            </asp:DropDownList>
                            
                        </td>
                      <%--  <td style="text-align: right;">
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
                        </td>--%>
                    </tr>

                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblServicetype" CssClass="cssLable" runat="server" Text="Item Price : "></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtItemPrice" runat="server" CssClass="csstxtbox" Width="150px" ></asp:TextBox>
                        </td>
                       
                     
                    </tr>
                             <tr>
                                 <td></td><td>
                                     <asp:Button ID="btnAdd" runat="server" Text="Add Item"  CssClass="cssButton"/>
                                          </td>
                             </tr>
                </table>
            </asp:Panel>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

