<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateCPData.aspx.cs" Inherits="APSInventory_UpdateCPData" %>


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
 
     <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>            
        
            <div id="divGV" runat="server">
                <asp:GridView ID="gvAttendence" Width="100%" CssClass="GridViewStyle" PageSize="25" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
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
                         <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                        FooterStyle-Width="100px" ItemStyle-Width="100px">
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
                            FooterStyle-Width="120px" ItemStyle-Width="120px" >
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                     

                        <asp:TemplateField HeaderText="Equipment Name" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                  <asp:HiddenField ID="HF1" runat="server" Value='<%# Bind("AutoId") %>' />
                                  <asp:HiddenField ID="HF2" runat="server" Value='<%# Bind("MaterialAutoID") %>' />
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("MaterialName") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>
                           <asp:HiddenField ID="HF1" runat="server" Value='<%# Bind("AutoId") %>' />
                                  <asp:HiddenField ID="HF2" runat="server" Value='<%# Bind("MaterialAutoID") %>' />
                            <asp:Label ID="lblEmployeeNumber" CssClass="cssLabel" runat="server" Text='<%# Bind("MaterialName") %>'></asp:Label>
                        </EditItemTemplate>
                            <HeaderStyle  Width="400px" />
                            <ItemStyle Width="400px" />
                            <FooterStyle Width="400px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>                         
                            <asp:TextBox ID="txtDate" CssClass="cssLabel" runat="server" Text='<%# Bind("Date") %>' Width="80px" Enabled="false"></asp:TextBox>
                                     <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                        </EditItemTemplate>
                            <HeaderStyle  Width="200px" />
                            <ItemStyle Width="200px" />
                            <FooterStyle Width="200px" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Transaction Type" HeaderStyle-Width="100px"
                            FooterStyle-Width="100px" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" CssClass="cssLable" runat="server" Text='<%# Bind("TransactionType") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>                         
                            <asp:Label ID="lblDesignation" CssClass="cssLabel" runat="server" Text='<%# Bind("TransactionType") %>'></asp:Label>
                        </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Center Point" HeaderStyle-Width="100px"
                            FooterStyle-Width="100px" ItemStyle-Width="100px">
                            <ItemTemplate>                           
                              
                                <asp:Label ID="lblShift" CssClass="cssLable" runat="server" Text='<%# Bind("CP") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>           
                                            
                            <asp:Label ID="lblShift" CssClass="cssLabel" runat="server" Text='<%# Bind("CP") %>'></asp:Label>
                        </EditItemTemplate>
                        </asp:TemplateField>
                     
                        <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="200px"
                            FooterStyle-Width="200px" ItemStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" CssClass="cssLable" runat="server" Text='<%# Bind("Quantity") %>' ForeColor="Green" Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                               <EditItemTemplate>                         
                            <asp:TextBox ID="txtQuantity" CssClass="csstxtbox" runat="server" Text='<%# Bind("Quantity") %>'  Width="100px" ></asp:TextBox>
                                  
                        </EditItemTemplate>
                        </asp:TemplateField>
                     
                     
                    </Columns>
                </asp:GridView>
             
                  </div>
         
                  
       </ContentTemplate>
     
    </Ajax:UpdatePanel>
</asp:Content>

