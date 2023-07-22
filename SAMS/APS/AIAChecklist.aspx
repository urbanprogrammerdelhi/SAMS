<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AIAChecklist.aspx.cs" Inherits="SAMS_AIAChecklist" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .modal {
            display: none;
            position: absolute;
            top: 0px;
            left: 0px;
            background-color: black;
            z-index: 100;
            opacity: 0.8;
            filter: alpha(opacity=60);
            -moz-opacity: 0.8;
            min-height: 100%;
        }

        #divImage {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: whitesmoke;
            height: 415px;
            width: 310px;
            padding: 3px;
            border: solid 1px black;
        }

        .csspager td {
            padding-left: 10px;
            padding-right: 10px;
            color: #009900;
            font-weight: bold;
            font-size: 10pt;
        }
          .auto-style3 {
              width: 222px;
          }
          .auto-style4 {
              width: 68px;
          }
          .auto-style5 {
              width: 201px;
          }
          .auto-style6 {
              width: 63px;
          }
          .auto-style7 {
              width: 207px;
          }
          .auto-style8 {
              width: 83px;
          }
    </style>
  

    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>            
            <br />
            <div style="overflow: auto;">
                <table align="center" width="100%" border="0" cellspacing="1px" cellpadding="1px">
                
                    <tr style="background-color: #D3E8F4">
                         <td style="text-align: right;">
                            <asp:Label ID="lblfixClientName" CssClass="cssLabel" runat="server" Text="Branch Code"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style3">
                            <asp:DropDownList AutoPostBack="true" CssClass="cssDropDown" Width="180px" ID="ddlClientCode" runat="server" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"
                               >
                            </asp:DropDownList>
                        </td>
                          <td style="text-align: right;">
                            <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="Select Checklist Header"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style3">
                            <asp:DropDownList AutoPostBack="true" CssClass="cssDropDown" Width="180px" ID="ddlChecklistHeader" runat="server" OnSelectedIndexChanged="ddlChecklistHeader_SelectedIndexChanged"
                               >
                               
                                      <asp:ListItem Text="ALL" Value="0" ></asp:ListItem>
                                      <asp:ListItem Text="General Cleaning of Office Area" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Washroom Cleaning" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="Repair and Maintenance of Equipments" Value="3"></asp:ListItem>
                                  <asp:ListItem Text="COVID-19 : PPE Equipment Stock Availability" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right;" class="auto-style4">
                            <asp:Label ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style5">
                            <asp:TextBox ID="txtDutyDate" CssClass="csstxtbox" runat="server" Width="120px" OnTextChanged="txtDutyDate_TextChanged" AutoPostBack="true" ></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HlimgDutyDate"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CEDutyDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDutyDate" PopupButtonID="HlimgDutyDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                   
                           
                        <td>
                            <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,View %>" OnClick="btnView_Click" />
                        </td>
                     
                    </tr>
                </table>
            </div>

            <br />
            <div id="divGV" runat="server">
                <asp:GridView ID="gvAttendence" Width="100%" CssClass="GridViewStyle" PageSize="40" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAttendence_RowDataBound" ShowFooter="True" OnPageIndexChanging="gvAttendence_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#D3E8F4" ForeColor="Black" CssClass="csspager" />
                    <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Checklist Header" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNameHeader" CssClass="cssLable" runat="server" Text='<%# Bind("Header") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="250px" />
                            <ItemStyle Width="250px" />
                            <FooterStyle Width="250px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Checklist Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfid1" runat="server" Value='<%# Bind("AssetServiceTypeAutoId") %>' />
                                   <asp:HiddenField ID="hfid2" runat="server" Value='<%# Bind("AssetchecklistDetailAutoID") %>' />
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("Checklistitemname") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="500px" />
                            <ItemStyle Width="500px" />
                            <FooterStyle Width="500px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Remarks" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeRemarks" CssClass="cssLable" runat="server" Text='<%# Bind("Text") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                          
                             <asp:TemplateField HeaderText="Branch Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblbranchname" CssClass="cssLable" runat="server" Text='<%# Bind("ClientCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                     
                       
                        <asp:TemplateField HeaderText="<%$Resources:Resource,Date %>" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,Time %>" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" CssClass="cssLable" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="View Images" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              
                                <asp:LinkButton ID="lblimage" runat="server" OnClick="lblimage_Click" Visible="true" Text="Click Here"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"
                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click" Visible="true" />
                <asp:Label ID="lblmsg" runat="server" CssClass="label-danger" Text="No Checklist found on selected criteria.." ForeColor="White" Visible="false"/>
            </div>

            <asp:HiddenField ID="hfstatus" runat="server" />
            <div id="divBackground" class="modal"></div>

              <asp:Panel ID="pnlTaskImage" runat="server" Visible="false">
        <b>
            <asp:Label ID="Label7" runat="server" CssClass="cssLabel" Style="font-size: larger; color: black; font-weight: 900" Text="Below are the Checklist Images -"></asp:Label></b>
        <br /> <br />
       
        <asp:GridView ID="gvImage" Width="6%" CssClass="GridViewStyle"
            runat="server" AllowPaging="true" CellPadding="3" GridLines="None"
            AutoGenerateColumns="False"
            ShowFooter="true" OnPageIndexChanging="gvImage_PageIndexChanging" PageSize="5">
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblgvhdrEmployeeImage" CssClass="cssLabelHeader" runat="server" Text="Audit Images" Visible="false"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%--                                                <img alt="" id="imgEmpImage" height="300" width="300" runat="server" src='<%# DataBinder.Eval(Container.DataItem, "ImageBase64String").ToString()%>' />--%>
                        <asp:ImageButton ID="imgEmpImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageBase64String").ToString()%>'
                            Width="300px" Height="300px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>


       
        <asp:Button ID="btnbacktaskList" runat="server" Text="Back to Report" CssClass="cssButton" OnClick="btnbacktaskList_Click" />

    </asp:Panel>
        
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
    </Ajax:UpdatePanel>
</asp:Content>


