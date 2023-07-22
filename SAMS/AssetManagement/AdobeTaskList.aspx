<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AdobeTaskList.aspx.cs" Inherits="AssetManagement_AdobeTaskList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlTaskMaster" runat="server">
        <center>
            <b>
                <asp:Label ID="lblTicketNo" runat="server" CssClass="cssLabel" Style="font-size: larger; color: black; font-weight: 900" Text="Task Details"></asp:Label>
            </b>
        </center>
        <br />
        <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
            <tr style="background-color: #D3E8F4">
                <td style="text-align: right;">
                    <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ClientCode %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="csstxtbox" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"></asp:DropDownList>
                </td>

                <td style="text-align: right;">
                    <asp:Label ID="lblSiteId" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AsmtId %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlSiteId" runat="server" CssClass="csstxtbox" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlSiteId_SelectedIndexChanged"></asp:DropDownList>
                </td>

                <td style="text-align: right;">
                    <asp:Label ID="lblPostCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PostCode %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlPostCode" runat="server" CssClass="csstxtbox" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlPostCode_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <p></p>
        <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
            <tr style="background-color: #D3E8F4">
                <td style="text-align: right;">
                    <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="csstxtbox" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                        <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                        <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                        <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td style="text-align: right;">
                    <asp:Label ID="lblShift" CssClass="cssLable" runat="server" Text="Shift"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlShift" runat="server" CssClass="csstxtbox" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                        <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                        <asp:ListItem Text="Shift A (07:00 - 16:00)" Value="Shift A"></asp:ListItem>
                        <asp:ListItem Text="Shift B (13:00 - 22:00)" Value="Shift B"></asp:ListItem>
                        <asp:ListItem Text="Shift C (22:00 - 07:00)" Value="Shift C"></asp:ListItem>
                        <asp:ListItem Text="Executive" Value="Executive"></asp:ListItem>
                        <asp:ListItem Text="Assistant Manager" Value="Assistant Manager"></asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td style="text-align: right;">
                    <asp:Label ID="lblActivewef" CssClass="cssLable" Style="width: 100px;" runat="server" Text="From Date"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtDate" MaxLength="50" Width="100px" CssClass="csstxtbox" runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                </td>

                <td style="text-align: right;">
                    <asp:Label ID="Label4" CssClass="cssLable" Style="width: 100px;" runat="server" Text="To Date" Visible="true"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtToDate" MaxLength="50" Width="100px" CssClass="csstxtbox" runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true" Visible="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true" Visible="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtToDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvTaskMaster" Width="100%" CssClass="GridViewStyle" PageSize="100" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
            AutoGenerateColumns="False" ShowFooter="True" OnPageIndexChanging="gvTaskMaster_PageIndexChanging">
            <FooterStyle BackColor="#2e6293" Font-Bold="true" ForeColor="black" />
            <RowStyle CssClass="GridViewRowStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle BackColor="#2e6293" ForeColor="white" />
            <Columns>
                <asp:TemplateField HeaderText="S.No.">
                    <ItemTemplate>
                        <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                    <FooterStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$ Resources:Resource,AsmtId %>" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfAssetScheduleAutoId" runat="server" Value='<%# Bind("AssetScheduleAutoId") %>' />
                        <asp:Label ID="lblSiteId" CssClass="cssLabel" runat="server" Text='<%# Bind("Site") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                    <ItemStyle Width="100px" />
                    <FooterStyle Width="100px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$Resources:Resource,Date %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="lblDate" CssClass="cssLabel" runat="server" Text='<%# Bind("DutyDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$ Resources:Resource,Post %>" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <asp:Label ID="lblPostId" CssClass="cssLabel" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                    <ItemStyle Width="200px" />
                    <FooterStyle Width="200px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$Resources:Resource,Performer %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="lblPerformer" CssClass="cssLabel" runat="server" Text='<%# Bind("Performer") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$Resources:Resource,AssetName %>" HeaderStyle-Width="200px" FooterStyle-Width="200px" ItemStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="lblAssetName" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$Resources:Resource,TaskList %>" HeaderStyle-Width="170px" FooterStyle-Width="170px" ItemStyle-Width="170px">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfAutoId" runat="server" Value='<%# Bind("TaskListID") %>' />
                        <asp:Label ID="lblTasklist" CssClass="cssLabel" runat="server" Text='<%# Bind("TaskList") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$Resources:Resource,CheckListItems %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="220px" FooterStyle-Width="220px" ItemStyle-Width="220px" HeaderStyle-ForeColor="White">
                    <EditItemTemplate>
                        <asp:Label ID="lblTaskName" Width="200px" CssClass="cssLable" runat="server" Text='<%# Eval("CheckListItem") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTaskName" CssClass="cssLable" Width="200px" runat="server" Text='<%# Bind("CheckListItem") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$ Resources:Resource,Status %>" HeaderStyle-CssClass="cssLabelHeader" HeaderStyle-Width="70px" FooterStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-ForeColor="White">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="70px" CssClass="cssDropDown">
                            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                            <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" CssClass="cssLable" Width="70px" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfstatus" runat="server" />
    </asp:Panel>
    <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>" Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click" />
</asp:Content>

