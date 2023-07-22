<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaxPDFReport.aspx.cs" Inherits="APS_MaxPDFReport" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
          .auto-style9 {
              width: 1012px;
              height: 12px;
          }
          .auto-style10 {
              width: 178px;
          }
          .auto-style11 {
              width: 116px;
          }
          .auto-style12 {
              width: 195px;
          }
          .auto-style13 {
              width: 106px;
          }
          .auto-style14 {
              width: 243px;
          }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  
  
          
            <br />
            <div style="overflow: auto;">
                <table align="center" width="100%" border="0" cellspacing="1px" cellpadding="1px">
                
                    <tr style="background-color: #D3E8F4" >
                         <td style="text-align: right;">
                            <asp:Label ID="lblfixClientName" CssClass="cssLabel" runat="server" Text="Branch Code" Font-Bold="true" Visible="false"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style13">
                            <asp:DropDownList AutoPostBack="true" CssClass="cssDropDown" Width="270px" ID="ddlClientCode" runat="server" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"  Visible="false"
                               >
                            </asp:DropDownList>
                        </td>
                          <td style="text-align: right;" class="auto-style14">
                            <asp:Label ID="fromdate" CssClass="cssLabel" runat="server" Text="From Date" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style3">
                           <asp:TextBox ID="txtFromDate" CssClass="csstxtbox" runat="server" Width="150px" ></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HyperLink1"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>

                           <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtFromDate" PopupButtonID="HyperLink1" Enabled="True"></AjaxToolKit:CalendarExtender>--%>
                        </td>
                        <td style="text-align: right;" class="auto-style4">
                            <asp:Label ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="To Date" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="text-align: left;" class="auto-style5">
                            <asp:TextBox ID="txtDutyDate" CssClass="csstxtbox" runat="server" Width="120px"  ></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HlimgDutyDate"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>

<%--                            <AjaxToolKit:CalendarExtender ID="CEDutyDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDutyDate" PopupButtonID="HlimgDutyDate" Enabled="True"></AjaxToolKit:CalendarExtender>--%>
                        </td>
                   
                           
                        <td>
                            <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="View Audit Branch Details" OnClick="btnView_Click" />
                        </td>
                     
                    </tr>
                </table>
            </div>

            <br />
            <div id="divfinal" runat="server">
            <div id="divGV" runat="server" visible="true">
                   <asp:Button ID="btnBack" runat="server" CssClass="cssButton" ToolTip="Back to List"
                    Text="<< Back to List" OnClick="btnBack_Click" Visible="true" />
                <br />
                <br />
                <div id="divspoc" runat="server">
                <table runat="server" class="auto-style9" >
                    <tr>
                        <td colspan="4" style="background-color:blueviolet;text-align:center"> <asp:Label Text="Max Branch Audit Report" runat="server"  Font-Bold="true" style="color:white;text-align:center" Font-Size="Larger"  ></asp:Label></td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style10"><asp:Label ID="Label1" runat="server" Text="Branch Code : " Font-Bold="true" ForeColor="Red"></asp:Label> </td>
                         <td class="auto-style12"><asp:Label ID="lblBranchCode" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                         <td class="auto-style11"><asp:Label ID="Label2" runat="server" Text="Branch Name : " Font-Bold="true" ForeColor="Red"></asp:Label>  </td>
                         <td><asp:Label ID="lblBranchName" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="auto-style10"><asp:Label ID="Label3" runat="server" Text="MLI SPOC Name : " Font-Bold="true" ForeColor="Red"></asp:Label> </td>
                         <td class="auto-style12"><asp:Label ID="lblspocname" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                         <td class="auto-style11"> <asp:Label ID="Label4" runat="server" Text="MLI SPOC No. : " Font-Bold="true" ForeColor="Red"></asp:Label>  </td>
                         <td><asp:Label ID="lblspocno" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="auto-style10"><asp:Label ID="Label5" runat="server" Text="Field Officer Name : " Font-Bold="true" ForeColor="Red"></asp:Label></td>
                         <td class="auto-style12"><asp:Label ID="lblfo" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                         <td class="auto-style11"><asp:Label ID="Label6" runat="server" Text="Audit Date : " Font-Bold="true" ForeColor="Red"></asp:Label></td>
                         <td><asp:Label ID="lbldate" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label></td>
                    </tr>
                      
                </table>
                    </div>
                <br />
             

                <asp:GridView ID="gvAttendence" Width="100%" CssClass="GridViewStyle" PageSize="45" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAttendence_RowDataBound" ShowFooter="True" OnPageIndexChanging="gvAttendence_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                    <HeaderStyle BackColor="Wheat" Font-Bold="True" ForeColor="black" />
                    <PagerStyle BackColor="#D3E8F4" ForeColor="Black" CssClass="csspager" />
                    <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                    <Columns>
                        <%--<asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="Green" ControlStyle-Font-Bold="true"
                            FooterStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Section" HeaderStyle-ForeColor="Green">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Visible="false" Text='<%# Bind("ChecklistId") %>'></asp:Label>
                                  <asp:HiddenField ID="hfflag" runat="server"  Value='<%# Bind("Flag") %>'></asp:HiddenField>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("Section") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Question" HeaderStyle-ForeColor="Green">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("Question") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="450px" />
                            <ItemStyle Width="450px" />
                            <FooterStyle Width="450px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Response" HeaderStyle-ForeColor="Green">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeRemarks" CssClass="cssLable" runat="server" Text='<%# Bind("Response") %>'></asp:Label>
                               
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                           <%--  <asp:TemplateField HeaderText="View Images" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              
                                <asp:LinkButton ID="lblimage" runat="server" OnClick="lblimage_Click" Visible="true" Text="Click Here"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>--%>
                              <asp:TemplateField HeaderText="Audit Image" HeaderStyle-ForeColor="Green">
                               <ItemTemplate>
                                <asp:image ID="imgEmpImage" runat="server" 
                                    Width="100px" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDivImage(this.src);" />
                                      <asp:LinkButton ID="lblimage" runat="server" OnClick="lblimage_Click" Visible="true" Text="Click Here to view More"></asp:LinkButton>
                            </ItemTemplate>
                           <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                       
                     
                        
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnExport" runat="server" CssClass="cssButton" Text="export" OnClick="btnExport_Click1" Visible="true" />

                  <asp:Button ID="btnExporttoPDF" runat="server" CssClass="cssButton" 
                    Text="Export to PDF" OnClick="btnExporttoPDF_Click" Visible="true" />
              
                 </div>

            <div id="divBranchCode" runat="server" visible="false">
               
                    <asp:GridView ID="gvBranchCode" Width="100%" CssClass="GridViewStyle" PageSize="15" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvBranchCode_RowDataBound" ShowFooter="True" OnPageIndexChanging="gvBranchCode_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#D3E8F4" ForeColor="Black" CssClass="csspager" />
                    <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                    <Columns>
<%--                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Branch Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                               <asp:Label ID="lblBranchCode" CssClass="cssLable" runat="server" Text='<%# Bind("BranchCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BranchName" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblBranchName" CssClass="cssLable" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="250px" />
                            <ItemStyle Width="250px" />
                            <FooterStyle Width="250px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Audit Date" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblAuditDate" CssClass="cssLable" runat="server" Text='<%# Bind("Audittime") %>'></asp:Label>                               
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Action" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                              
                                <asp:LinkButton ID="lblFetchReport" runat="server" OnClick="lblFetchReport_Click" Visible="true" Text="Click to Fetch Audit Report"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>

                       
                           
                       
                     
                        
                    </Columns>
                </asp:GridView>
            </div>
            </div>
             <asp:Label ID="lblmsg" runat="server" CssClass="label-danger" Text="No Audit Report available on selected criteria.." ForeColor="White" Visible="false"/>
          
            <asp:HiddenField ID="hfstatus" runat="server" />
            <div id="divBackground" class="modal"></div>

        
             <asp:Panel ID="pnlTaskImage" runat="server" Visible="false">
        <b>
            <asp:Label ID="Label7" runat="server" CssClass="cssLabel" Style="font-size: larger; color: black; font-weight: 900" Text="Below are the Images -"></asp:Label></b>
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

      
    </form>
</body>
</html>
