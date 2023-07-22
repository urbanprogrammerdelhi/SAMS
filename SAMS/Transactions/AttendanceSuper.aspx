<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceSuper.aspx.cs" Inherits="Transactions_AttendanceSuper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
            color: white;
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
        function executeGreen() {
            $('#myModalGreen').modal('show');
        }
        function executeRed() {
            $('#myModalRed').modal('show');
        }
        function clientAdd() {
            $('#ClientAdd').modal('show');
        }
        function clientDelete() {
            $('#ClientDelete').modal('show');
        }
        function executeError() {
            $('#TimeErrorID').modal('show');
        }
    </script>
     <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>            
            <br />
            <div style="overflow: auto;">
                <table align="center" width="100%" border="0" cellspacing="1px" cellpadding="1px">
               
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
                       
                           
                  
                                <td style="text-align: right;" class="auto-style8">
                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,EmployeeNumber  %>"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtEmployeeNo" Width="120px" CssClass="csstxtbox" runat="server">
                            </asp:TextBox>
                            </td>
                         <td style="text-align: right;" class="auto-style6" >
                            <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,ToDate  %>" Visible="false"></asp:Label>
                        </td>
                           <td style="text-align: left;" class="auto-style7">
                            <asp:TextBox ID="txtTodate" CssClass="csstxtbox" runat="server" Visible="false" Width="120px" OnTextChanged="txtTodate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HyperLink1" Visible="false"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server" 
                                TargetControlID="txtTodate" PopupButtonID="HyperLink1" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>      
                           <td></td>
                        <td>
                            <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="Search" OnClick="btnView_Click" />
                        </td>
                          <td>
                            <asp:Button ID="btnAll" runat="server" CssClass="cssButton" Text="View All" OnClick="btnAll_Click" />
                        </td>
                       
                         </tr>
                </table>
            </div>

            <br />
            <div id="divGV" runat="server">
                <asp:GridView ID="gvAttendence" Width="100%" CssClass="GridViewStyle" PageSize="50" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvAttendence_RowDataBound" ShowFooter="false" OnPageIndexChanging="gvAttendence_PageIndexChanging"
                    OnRowCancelingEdit="gvAttendence_RowCancelingEdit" OnRowDeleting="gvAttendence_RowDeleting"
              
                 OnRowEditing="gvAttendence_RowEditing" OnRowUpdating="gvAttendence_RowUpdating"
               
                    >
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#2E6293" Font-Bold="True" ForeColor="black" />
                    <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2E6293" ForeColor="White" CssClass="csspager" />
                    <RowStyle BackColor="#E4E4E4" CssClass="GridViewRowStyle" />
                    <Columns>
                         <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="50px"
                        FooterStyle-Width="50px" ItemStyle-Width="50px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdate" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImgbtnCancel" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnEdit" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                             <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                            
                        </ItemTemplate>
                      
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="80px" ItemStyle-Width="80px" >
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Client Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblClientName" CssClass="cssLable" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="350px" />
                            <ItemStyle Width="350px" />
                            <FooterStyle Width="350px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Zone" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblZone" CssClass="cssLable" runat="server" Text='<%# Bind("Zone") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="State" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblstate" CssClass="cssLable" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblBranchcode" CssClass="cssLable" runat="server" Text='<%# Bind("BranchCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Branch Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblbranchname" CssClass="cssLable" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  Width="350px" />
                            <ItemStyle Width="350px" />
                            <FooterStyle Width="350px" />
                        </asp:TemplateField>--%>
                     

                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>
                         
                            <asp:Label ID="lblEmployeeNumber" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                        </EditItemTemplate>
                            <HeaderStyle  Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>                         
                            <asp:Label ID="lblEmployeeName" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                        </EditItemTemplate>
                            <HeaderStyle  Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>                         
                            <asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                        </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$Resources:Resource,Date %>" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                               <EditItemTemplate>                         
                            <asp:Label ID="lblDate" CssClass="cssLabel" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="In Time" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" CssClass="cssLable" runat="server" Text='<%# Bind("InTime") %>' ForeColor="Green" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                               <EditItemTemplate>                         
                            <asp:TextBox ID="txtInTime" CssClass="csstxtbox" runat="server" Text='<%# Bind("InTime") %>'  Width="40px" MaxLength="5"></asp:TextBox>
                                      <AjaxToolKit:MaskedEditExtender runat="server" ID="MEE2" TargetControlID="txtInTime" Mask="99:99" />
                        </EditItemTemplate>
                        </asp:TemplateField>
                     
                        <asp:TemplateField HeaderText="Out Time" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblOuttime" CssClass="cssLable" runat="server" Text='<%# Bind("OutTime") %>' ForeColor="Red" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>                         
                            <asp:TextBox ID="txtOuttime" CssClass="csstxtbox" runat="server" Text='<%# Bind("OutTime") %>' Width="40px" MaxLength="5"></asp:TextBox>
                                       <AjaxToolKit:MaskedEditExtender runat="server" ID="MEE3" TargetControlID="txtOuttime" Mask="99:99" />
                        </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Working Minutes" HeaderStyle-Width="300px"
                            FooterStyle-Width="300px" ItemStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblLongitude" CssClass="cssLable" runat="server" Text='<%# Bind("TotalMin") %>'></asp:Label>
                            </ItemTemplate>
                              <EditItemTemplate>                         
                            <asp:Label ID="lblLongitude" CssClass="cssLabel" runat="server" Text='<%# Bind("TotalMin") %>'></asp:Label>
                        </EditItemTemplate>
                        </asp:TemplateField>
                      
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>" 
                         
                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click" Visible="false" />
                  <asp:Button ID="Button2" runat="server" class="btn btn-success" OnClick="btnYes_Click" Text="YES" Visible="false" />
                 <asp:Button ID="btnActual" runat="server" CssClass="cssButton" Text="Attendance Approval" OnClick="btnActual_Click" />
                   <asp:Button ID="btnAdd" runat="server" CssClass="cssButton" Style="background-color: MenuText" Text="Add Employee Attendance" OnClick="btnAdd_Click"/>
                 <asp:Button ID="btnDelete" runat="server" CssClass="cssButton" Style="background-color: #4800ff" Text="Delete Employee Attendance" OnClick="btnDelete_Click" Visible="false" />
                <asp:Label ID="lblmsg" runat="server" CssClass="label-danger" Text="Attendance Not Available..." ForeColor="White" Visible="false"/>
                 <asp:Label ID="lblerrormsg" runat="server" CssClass="cssLabel" ForeColor="Red" Font-Bold="true" Font-Size="Medium" />
            </div>
            <div class="modal fade" id="myModalGreen" role="dialog">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-body">
                            <center>
                                <asp:Label ID="lblPopHeaderGreen" runat="server" Style="font-weight: bold;" Text="Are you sure you want to approved the attendance ?" /><br />
                                <asp:Label ID="lblPopMsgGreen" runat="server" Style="font-weight: bold;" Text="[Once attendance is approved, No modification will be made.]" />
                            </center>
                        </div>
                        <div class="modal-footer">
                            <center>
                                <asp:Button ID="btnYes" runat="server" class="btn btn-success" OnClick="btnYes_Click" Text="YES" />
                                <button id="btnNo" type="button" class="btn btn-danger" data-dismiss="modal" runat="server">NO</button>
                            </center>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="myModalRed" role="dialog">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-body">
                            <center>
                                <center>
                                    <asp:Label ID="Label4" runat="server" Style="font-weight: bold;" Text="Sorry" /></center>
                                <br />
                                <asp:Label ID="Label5" runat="server" Style="font-weight: bold;" Text="You can't approved the attendance before 48 Hrs." />
                            </center>
                        </div>
                        <div class="modal-footer">
                            <center>
                                <asp:Button ID="Button3" runat="server" class="btn btn-danger" data-dismiss="modal" Text="Cancel" />
                            </center>
                        </div>
                    </div>
                </div>
            </div>
              <div class="modal fade" id="TimeErrorID" role="dialog">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-body">
                            <center>
                                <center>
                                    <asp:Label ID="Label11" runat="server" Style="font-weight: bold;" Text="Sorry" />
                                </center>
                                <br />
                                <asp:Label ID="Label12" runat="server" Style="font-weight: bold;" Text="You can't approved the attendance " />
                                <b>because InTime / OutTime is missing...</b><br />
                            </center>
                        </div>
                        <div class="modal-footer">
                            <center>
                                <asp:Button ID="Button1" runat="server" class="btn btn-danger" data-dismiss="modal" Text="Cancel" />
                            </center>
                        </div>
                    </div>
                </div>
            </div>

                   
                     <div id="AddMissing" runat="server" visible="false" >
                        <div class="modal-body">
                            <div class="table-responsive">
                                <table class="table">
                                    <tr>
                                        <td align="right">
                                            <asp:Label Width="70px" ID="Label2" CssClass="cssLabel" runat="server" Text="Employee No"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPopEmpNo" Width="200px" CssClass="csstxtbox" runat="server" AutoPostBack="true" OnTextChanged="txtPopEmpNo_TextChanged" MaxLength="10"></asp:TextBox>
                                            <asp:Label ID="lblPopMsg" runat="server" Text="Employee Not Exist!!" Visible="false" class="label label-danger" />
                                        </td>
                                        <td align="right">
                                            <asp:Label Width="90px" ID="Label6" CssClass="cssLabel" runat="server" Text="Employee Name"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPopEmpName" Width="200px" CssClass="csstxtbox" ReadOnly="true" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                  <%--  <tr id="tr2" runat="server" visible="false">
                                        <td align="right">
                                            <asp:Label Width="50px" ID="Label7" CssClass="cssLabel" runat="server" Text="Site ID"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList CssClass="cssDropDown" Width="200px" ID="ddlPopSiteId" runat="server"></asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label Width="50px" ID="Label8" CssClass="cssLabel" runat="server" Text="Post"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlPopPost" Width="200px" CssClass="cssDropDown" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>--%>
                                <%--    <tr id="tr3" runat="server" visible="false">
                                        <td align="right">
                                            <asp:Label Width="50px" ID="Label10" CssClass="cssLabel" runat="server" Text="Shift"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlPopShift" Width="200px" CssClass="cssDropDown" runat="server"></asp:DropDownList>
                                        </td>
                                      <td align="right">
                                            <asp:Label Width="50px" ID="Label9" CssClass="cssLabel" runat="server" Text="Date"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPopDate" Width="200px" CssClass="csstxtbox" runat="server" ReadOnly="true"></asp:TextBox>
                                        </td>
                                       
                                    </tr>--%>
                                    <tr id="tr4" runat="server" visible="false">
                                       
                                        <td align="right">
                                            <asp:Label Width="50px" ID="Label13" CssClass="cssLabel" runat="server" Text="In Time"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPopInTime" Width="200px" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender runat="server" ID="MEE2" TargetControlID="txtPopInTime" Mask="99:99" />
                                            <asp:Label ID="lblPopInTime" runat="server" class="label label-danger" Visible="false" />
                                        </td>
                                        <td align="right">
                                            <asp:Label Width="50px" ID="Label14" CssClass="cssLabel" runat="server" Text="Out Time"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPopOutTime" Width="200px" CssClass="csstxtbox" runat="server" MaxLength="5"></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender runat="server" ID="MEE1" TargetControlID="txtPopOutTime" Mask="99:99" />
                                            <asp:Label ID="lblPopOutTime" runat="server" Visible="false" class="label label-danger" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <center>
                                <asp:Button ID="btnPopReset" runat="server" class="btn btn-info"  Text="Reset" Visible="true" OnClick="btnPopReset_Click" />
                                <asp:Button ID="btnPopSubmit" runat="server" class="btn btn-success"  Text="Submit" Visible="true"  OnClick="btnPopSubmit_Click"/>
                                <asp:Button ID="btnPopCancel" runat="server" class="btn btn-danger" Text="Back" OnClick="btnPopCancel_Click" />
                                 <asp:Label EnableViewState="false" ID="lblErrorMsgAdd" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </center>
                        </div>
                         </div>
                  
       </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" /> 
          
            <asp:PostBackTrigger ControlID="btnPopCancel" />
            <asp:PostBackTrigger ControlID="btnPopSubmit" />
            <asp:PostBackTrigger ControlID="btnYes" />
         <%--   <asp:PostBackTrigger ControlID="btnPopCancleDel" />
            <asp:PostBackTrigger ControlID="btnPopSubmitDel" />--%>
     
        </Triggers>
    </Ajax:UpdatePanel>
</asp:Content>
