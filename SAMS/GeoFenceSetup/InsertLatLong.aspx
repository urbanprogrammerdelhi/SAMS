<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="InsertLatLong.aspx.cs" Inherits="GeoFenceSetup_InsertLatLong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4>Geo Cordinates Master</h4>
    <table   >
        <tr>
            <td>
                <asp:Label ID="lbl1" runat="server" Text="Client Code :- " Font-Size="Large" Font-Bold="true" ForeColor="Black" CssClass="cssLabel" ></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlclientcode" CssClass="cssDropDown" Width="300px" runat="server" OnSelectedIndexChanged="ddlclientcode_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>

       
         <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Latitude :- " Font-Size="Large" Font-Bold="true" ForeColor="Black" CssClass="cssLabel" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLatitude" runat="server" Width="300px" CssClass="csstxtbox" ></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Longitude :- " Font-Size="Large" Font-Bold="true" ForeColor="Black" CssClass="cssLabel" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLong" runat="server" Width="300px" CssClass="csstxtbox" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
             <td >
                <asp:Button ID="btnupdate" runat="server" Text="Update Geo Cordinates" CssClass="cssButton" OnClick="btnupdate_Click"></asp:Button>
            </td>
            
        </tr>
    </table>
    <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Large"></asp:Label>
</asp:Content>

