<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MapEmp.aspx.cs" Inherits="GeoFenceSetup_MapEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4>Map Employee to Location</h4>
    <table   >
        <tr>
            <td>
                <asp:Label ID="lbl1" runat="server" Text="Enter Employee Code :- " Font-Size="Large" Font-Bold="true" ForeColor="Black" CssClass="cssLabel" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtempcode" CssClass="csstxtbox" Width="300px" runat="server" ></asp:TextBox>
            </td>
        </tr>

       
         <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Select Client Code :- " Font-Size="Large" Font-Bold="true" ForeColor="Black" CssClass="cssLabel" ></asp:Label>
            </td>
            <td>
               <asp:DropDownList ID="ddlclientcode" CssClass="cssDropDown" Width="300px" runat="server" ></asp:DropDownList>
                </td>
        </tr>
        
        <tr>
            <td></td>
             <td >
                <asp:Button ID="btnmap" runat="server" Text="Map Emp to Location" CssClass="cssButton" OnClick="btnmap_Click"></asp:Button>
            </td>
            
        </tr>
    </table>
    <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Large"></asp:Label>

    <br />
    <br />
     <h5>Below is the list of Mapped Employee details to this location - </h5>
         <asp:GridView ID="gvAttendence" Width="50%" CssClass="GridViewStyle" PageSize="50" runat="server" AllowPaging="true" CellPadding="1" GridLines="None"
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
                     
                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>
                         
                            <asp:TextBox ID="txtEmployeeNumber" CssClass="csstxtbox" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:TextBox>
                        </EditItemTemplate>
                            <HeaderStyle  Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client Code" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                    <asp:HiddenField ID="hfShiftCodevalue" runat="server" Value='<%# Bind("MappingAutoID") %>' />
                                <asp:Label ID="lblEmployeeName" CssClass="cssLable" runat="server" Text='<%# Bind("ClientCode") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>      
                                     <asp:HiddenField ID="hfShiftCodevalue" runat="server" Value='<%# Bind("MappingAutoID") %>' />
                            <asp:Label ID="txtEmployeeName" CssClass="cssLabel" runat="server" Text='<%# Bind("ClientCode") %>'></asp:Label>
                        </EditItemTemplate>
                            <HeaderStyle  Width="300px" />
                            <ItemStyle Width="300px" />
                            <FooterStyle Width="300px" />
                        </asp:TemplateField>
                         
                     
                      
                    </Columns>
                </asp:GridView>
</asp:Content>
