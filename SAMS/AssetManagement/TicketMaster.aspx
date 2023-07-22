﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TicketMaster.aspx.cs" Inherits="AssetManagement_TicketMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
body
{
    margin: 0;
    padding: 0;
    height: 100%;
}
.modal
{
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
#divImage
{
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
</style>
  <script type="text/javascript">
      function LoadDiv(url) {
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
               <asp:Panel ID="pnlTicetMaster" runat="server" Visible="true" >
                     <center>      <b><asp:Label ID="Label1" runat="server"   CssClass="cssLabel" style="font-size:larger;color:black;font-weight:900" Text="<%$ Resources:Resource,TicketsDetails %>" ></asp:Label></b>  </center> 
        <br />
                    <table align="center" width="90%" border="0" cellspacing="0px" cellpadding="0px">
             <tr>
              
                <td style="text-align: right;">
                    <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Status %>" ></asp:Label>
                </td>
                <td style="text-align: left;">
                     <asp:DropDownList ID="ddlStatusMain" runat="server" CssClass="csstxtbox" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlStatusMain_SelectedIndexChanged">
                          <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                         <asp:ListItem Text="NEW" Value="NEW"></asp:ListItem>
                         <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                          <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>
                          <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                     </asp:DropDownList>
                </td>
                   <td style="text-align: right;">
                    <asp:Label ID="lblPostCode" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,TicketNo %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                     <asp:TextBox ID="txtTicketNo" MaxLength="15" Width="150px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtTicketNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblSiteId" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,UserID %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtUserId" MaxLength="30" Width="150px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtUserId_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
              
                 <%-- <td style="text-align: right;">
                    <asp:Label ID="lblActivewef" CssClass="cssLable" Style="width: 100px;" runat="server" Text="From Date"></asp:Label>
                </td>
                 <td style="text-align: left;">
                    <asp:TextBox ID="txtFromDate" MaxLength="50" Width="150px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtFromDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtFromDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                </td>--%>
                  <td style="text-align: right;">
                    <asp:Label ID="Label2" CssClass="cssLable" Style="width: 100px;" runat="server" Text="From Date"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtDate" MaxLength="50" Width="80px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                </td>
                 <td style="text-align: right;">
                    <asp:Label ID="Label3" CssClass="cssLable" Style="width: 100px;" runat="server" Text="To Date"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtToDate" MaxLength="50" Width="80px" CssClass="csstxtbox" 
                        runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton4" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtToDate" PopupButtonID="ImageButton4" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                </td>
            </tr>
               </table>
                   <br />
                  <asp:UpdatePanel ID="pnlGrd" runat="server" UpdateMode="Conditional" >
                         <ContentTemplate>
            <asp:GridView ID="gvTicketMaster" Width="40%" CssClass="GridViewStyle" PageSize="20"
                runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
                AutoGenerateColumns="False" OnRowDataBound="gvTicketMaster_RowDataBound"
                ShowFooter="True" OnPageIndexChanging="gvTicketMaster_PageIndexChanging">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                   <asp:TemplateField HeaderText="<%$ Resources:Resource,TicketNo %>">
                    <ItemTemplate>                           
                            <asp:LinkButton ID="lblTicketNo" CssClass="cssLabel" runat="server"  Text='<%# Bind("AssetWONo") %>' OnClick="lblTicketNo_Click"></asp:LinkButton>

                        </ItemTemplate>
                     <HeaderStyle CssClass="cssLabelHeader" Width="300px" />
                        <ItemStyle Width="300px" />
                        <FooterStyle Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,Status %>" HeaderStyle-Width="300px"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                            <asp:Label ID="lblTicketStatus" CssClass="cssLable" runat="server" Text='<%# Bind("WOstatus") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                     <asp:TemplateField HeaderText="<%$Resources:Resource,UserID %>" HeaderStyle-Width="300px"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                            <asp:Label ID="lblUserID" CssClass="cssLable" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,DateOfCreation %>" HeaderStyle-Width="300px"
                        FooterStyle-Width="300px" ItemStyle-Width="300px">
                       <ItemTemplate>
                            <asp:Label ID="lblDate" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                </Columns>
            </asp:GridView>
                                </ContentTemplate>
                      </asp:UpdatePanel>
                   <asp:HiddenField ID="hfstatus" runat="server" />
                     <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"
                                                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click"/>
       </asp:Panel>
          
            <br />
            <asp:Panel ID="pnlTicketDetail" runat="server"  Visible="false">
             <center>  <b> <asp:Label ID="lblTicket" runat="server"  Text="Ticket No : " CssClass="cssLabel" style="font-size:larger;color:black;font-weight:900"></asp:Label>   <asp:Label ID="lblTicketNo" runat="server"   CssClass="cssLabel" style="font-size:larger;color:black;font-weight:900"></asp:Label></b></center>
                 <br /> 
                <br /> <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                       <tr>
                             <td rowspan="6" id="spanImage" runat="server" >
                  <%--  <asp:Image ID="ImageBox" runat="server" Height="120px" ImageUrl="~/Images/NoImageAvailable.jpg" Style="margin-top: 6px; margin-left: 12px;" Width="210px" Visible="true" />--%>
                                 <asp:ImageButton ID="ImageBox" runat="server" ImageUrl="~/Images/NoImageAvailable.jpg"
                Width="120px" Height="150px" Style="cursor: pointer;margin-top: 6px; margin-left: 12px;" OnClientClick="return LoadDiv(this.src);" />
                              
                 <%--   <asp:FileUpload ID="FileUploadAsset" Width="230px" CssClass="csstxtbox" runat="server" />
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server"
                        ControlToValidate="FileUploadAsset" SetFocusOnError="True" ErrorMessage="* .bmp, .gif, .png, .jpeg and .jpg formats are allowed" Style="color: red;"
                        ValidationExpression="(.+\.([Bb][Mm][Pp])|.+\.([Gg][Ii][Ff])|.+\.([Pp][Nn][Gg])|.+\.([Jj][Pp][Ee][Gg])|.+\.([Jj][Pp][Gg]))">
                    </asp:RegularExpressionValidator>
                    <asp:Button ID="btnUpload" CssClass="cssButton" Style="margin-left: 65px;" runat="server" Text="<%$ Resources:Resource,Upload %>" OnClick="btnUpload_Click" />
                    <asp:Label ID="lblImageUrl" Visible="false" runat="server" CssClass="csslblErrMsg"></asp:Label>--%>
                </td>
                       </tr>
            <tr>
              
                <td style="text-align: right;">
                    <asp:Label ID="lblClientName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,ClientName %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtClientName" CssClass="csstxtbox" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblSiteName" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SiteName %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                       <asp:TextBox ID="txtSiteName" CssClass="csstxtbox" runat="server"  Width="200px"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblDOC" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,DateOfCreation %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                       <asp:TextBox ID="txtDOC" CssClass="csstxtbox" runat="server"  ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" nowrap="nowrap">
                    <asp:Label ID="lblSummary" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SummaryOfIssues %>"></asp:Label>
                </td>
                <td style="text-align: left;" nowrap="nowrap">
                     <asp:TextBox ID="txtSummary" CssClass="csstxtbox" runat="server" Width="200px"></asp:TextBox>     </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblDesc" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,DescOfIssues %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                      <asp:TextBox ID="txtDesc" CssClass="csstxtbox" runat="server" Width="200px"></asp:TextBox>    </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblSeverity" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Severity %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                  <asp:TextBox ID="txtSeverity" CssClass="csstxtbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblCommecialValue" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,CommecialValue %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtCommercialValue" CssClass="csstxtbox" runat="server"></asp:TextBox>    </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblStatus" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Status %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlStatus" Width="150px" CssClass="cssDropDown" runat="server">
                        <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                        <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
         
        </table>

                  <div >

       <center>     <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:Resource,Update %>"  CssClass="cssButton" OnClick="btnUpdate_Click1"/>
                         <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource,Back %>"  CssClass="cssButton" OnClick="btnBack_Click"/></center>
                      &nbsp;</div>
                <br />
                 <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </asp:Panel>
             <div id="divBackground" class="modal">
</div>
<div id="divImage">
<center><table style="height: 90%; width: 100%">
     <tr>
        <td align="right" valign="right">
            <asp:ImageButton id="btnCancel"  runat="server" OnClientClick="HideDiv()" ImageUrl="~/Images/cancel (2).png" />
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
    </Ajax:UpdatePanel>
   
</asp:Content>

