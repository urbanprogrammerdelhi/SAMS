﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="GroupL_Register" %>


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
    <script type="text/javascript">
        function LoadDivImage(url) {
            var img = new Image();
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            var imgLoader = document.getElementById("imgLoader");
            imgLoader.style.display = "block";
            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
            };
            img.src = url;
            var width = document.body.clientWidth;
            if (document.body.clientHeight > document.body.scrollHeight) {
                bcgDiv.style.height = document.body.clientHeight + "px";
            }
            else {
                bcgDiv.style.height = document.body.scrollHeight + "px";
            }
            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";

            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;
        }
        function HideDiv() {
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            if (bcgDiv != null) {
                bcgDiv.style.display = "none";
                imgDiv.style.display = "none";
                imgFull.style.display = "none";
            }
        }
    </script>

    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>            
            <br />
            <div style="overflow: auto;">
                <table align="center" width="100%" border="0" cellspacing="1px" cellpadding="1px">
                  <%--  <tr>
                        <td align="right">
                            <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel" Visible="false"></asp:Label>
                        </td>
                        <td align="left" class="auto-style1">
                            <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                                Width="200px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged" Visible="false">
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
           <%--         <tr style="background-color: #D3E8F4">
                       
                        <td style="text-align: right;">
                            <asp:Label ID="lblAssmtId" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,AsmtId  %>" Visible="false"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style2">
                            <asp:DropDownList ID="ddlAsmtId" Width="280px" CssClass="cssDropDown" runat="server" AutoPostBack="True" Visible="false"
                                OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                      <%--  <td style="text-align: right;">
                            <asp:Label ID="lblShift" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,Shift  %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlShift" Width="200px" CssClass="cssDropDown" runat="server"></asp:DropDownList>
                        </td>
                    </tr>--%>
                    <tr style="background-color: #D3E8F4">
                        
                        <td style="text-align: right;" class="auto-style4">
                            <asp:Label ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style5">
                            <asp:TextBox ID="txtDutyDate" CssClass="csstxtbox" runat="server" Width="120px" OnTextChanged="txtDutyDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HlimgDutyDate"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CEDutyDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDutyDate" PopupButtonID="HlimgDutyDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                      <%--  <td style="text-align: right;" class="auto-style6">
                            <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,ToDate  %>"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style7">
                            <asp:TextBox ID="txtTodate" CssClass="csstxtbox" runat="server" Width="120px" OnTextChanged="txtTodate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HyperLink1"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtTodate" PopupButtonID="HyperLink1" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>--%>
                            <td style="text-align: right;" class="auto-style8">
                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,EmployeeNumber  %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtEmployeeNo" Width="120px" CssClass="csstxtbox" runat="server">
                            </asp:TextBox>
                            </td>
                           <td></td>
                        <td>
                            <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,View %>" OnClick="btnView_Click" />
                        </td>
                     
                    </tr>
                     <tr style="background-color: #D3E8F4">
                             <%--   <td style="text-align: right;" class="auto-style8">
                            <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="Total Count : " ForeColor="Green" Font-Size="Large" Font-Bold="true" Width="100px"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblcount" Width="100px" CssClass="cssLabel" runat="server" ForeColor="Red" Font-Size="Large" Font-Bold="true">
                            </asp:Label>
                            </td>--%>
                     
                            
                       
                         </tr>
                </table>
            </div>

            <br />
            <div id="divGV" runat="server">
                <asp:GridView ID="gvAttendence" Width="100%" CssClass="GridViewStyle" PageSize="10" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
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
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Shift Details" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblCluster" CssClass="cssLable" runat="server" Text='<%# Bind("ShiftDetails") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                           <%--  <asp:TemplateField HeaderText="Branch Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblBranchcode" CssClass="cssLable" runat="server" Text='<%# Bind("ClientCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>--%>
                          <%--   <asp:TemplateField HeaderText="Branch Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblbranchname" CssClass="cssLable" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>--%>
                     
                        <asp:TemplateField HeaderText="<%$Resources:Resource,Status %>" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" CssClass="cssLable" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
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
                     
                        <asp:TemplateField HeaderText="Latitude" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblLatitude" CssClass="cssLable" runat="server" Text='<%# Bind("Latitude") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Longitude" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblLongitude" CssClass="cssLable" runat="server" Text='<%# Bind("Longitude") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Location Name" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblLocationName" CssClass="cssLable" runat="server" Text='<%# Bind("LocationName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrEmployeeImage" CssClass="cssLabelHeader" runat="server" Text="Employee Image" Style="color: white"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEmpImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageBase64String").ToString()%>'
                                    Width="100px" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDivImage(this.src);" />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"
                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click" Visible="false" />
                <asp:Label ID="lblmsg" runat="server" CssClass="label-danger" Text="Attendance Not Available..." ForeColor="White" Visible="false"/>
            </div>

            <asp:HiddenField ID="hfstatus" runat="server" />
            <div id="divBackground" class="modal"></div>
            <div id="divImage">
                <center>
                    <table style="height: 90%; width: 100%">
                        <tr>
                            <td align="right" valign="right">
                                <asp:ImageButton ID="btnCancel" runat="server" OnClientClick="HideDiv()" ImageUrl="~/Images/cancel (2).png" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" align="center">
                                <img id="imgLoader" alt="" src="images/loader.gif" />
                                <img id="imgFull" alt="" src="" style="display: none; height: 370px; width: 300px" />
                            </td>
                        </tr>
                        <%-- <tr>
        <td align="center" valign="bottom">
            <input id="btnClose" type="button" value="Close" class="cssButton" onclick="HideDiv()" />
        </td>
    </tr>--%>
                    </table>
                </center>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
    </Ajax:UpdatePanel>
</asp:Content>

