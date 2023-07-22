<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HubCheckIn.aspx.cs" Inherits="APSInventory_HubCheckIn" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
table,  td {
  border: 1px solid black;
}
tr:nth-child(even) {
  background-color: #D6EEEE;
}

</style>
    <asp:Label ID="lblheader" runat="server" Text="HUB Material IN Form" Font-Bold="true" ForeColor="Red" Font-Size="Large" style="align-self:center" ></asp:Label>
    <br />
      <br />
   <asp:Label ID="lblheader1" runat="server" Text="Select HUB for Material's IN -" Font-Bold="true" ForeColor="black" Font-Size="Medium" style="align-self:center" ></asp:Label>
    <asp:DropDownList ID="ddlHUB" runat="server" Font-Bold="true" ForeColor="Black" Width="350px" >
     
    </asp:DropDownList>
     <br />
      <br />
     <asp:Label ID="Label35" runat="server" Text="Select Center Point From Where Material's Comes In -" Font-Bold="true" ForeColor="black" Font-Size="Medium" style="align-self:center" ></asp:Label>
   <asp:DropDownList ID="ddlCP" runat="server" Font-Bold="true" ForeColor="Black" Width="150px" >
        <asp:ListItem Text="Delhi" Value="Delhi" ></asp:ListItem>
         <asp:ListItem Text="Mumbai" Value="Mumbai" ></asp:ListItem>
         <asp:ListItem Text="Chandigarh" Value="Chandigarh" ></asp:ListItem>
         <asp:ListItem Text="Jaipur" Value="Jaipur" ></asp:ListItem>
    </asp:DropDownList>
     <br />
      <br />

    <table >
      
        <tr>
            <td style="background-color:yellow;color:red;font-size:large;align-content:center" ><strong>S.No&nbsp;&nbsp;</strong></td>
             <td style="background-color:yellow;color:red;font-size:large;align-content:center" ><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Equipment List</strong></td>
             <td style="background-color:yellow;color:red;font-size:large" ><strong>&nbsp;&nbsp;&nbsp; Date</strong></td>
             <td style="background-color:yellow;color:red;font-size:large" ><strong>Qty. Received</strong></td>
         
              <td style="background-color:yellow;color:red;font-size:large" ><strong>Action</strong></td>
        </tr>
         <tr>
             <td style="color:black"> <strong><asp:Label ID="Label1" runat="server" Text="1"></asp:Label> </strong></td>
          <td style="color:black">   <strong>32 Zone Integrated alarm panel</strong></td>
             <td><asp:TextBox ID="txtdate1" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty1" runat="server"></asp:TextBox></td>
          
             <td>
                 <asp:Button ID="btn1" runat="server" Text="Material In" OnClick="btn1_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
             <td style="color:black"> <strong><asp:Label ID="Label2" runat="server" Text="2"></asp:Label></strong> </td>
             <td style="color:black"> <strong>Lobby Two way Communication</strong></td>
             <td><asp:TextBox ID="txtdate2" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty2" runat="server"></asp:TextBox></td>
              
                 <td>
                 <asp:Button ID="btn2" runat="server" Text="Material In" OnClick="btn2_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label3" runat="server" Text="3"></asp:Label></strong></td>
               <td style="color:black">  <strong>ATM Two way communication GSM based voice.</strong></td>
             <td><asp:TextBox ID="txtdate3" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty3" runat="server"></asp:TextBox></td>
           
                  <td>
                 <asp:Button ID="btn3" runat="server" Text="Material In" OnClick="btn3_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
               <td style="color:black">  <strong><asp:Label ID="Label4" runat="server" Text="4"></asp:Label></strong></td>
              <td style="color:black">  <strong>Analog Dome Camera </strong> </td>
             <td><asp:TextBox ID="txtdate4" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty4" runat="server"></asp:TextBox></td>
            
                  <td>
                 <asp:Button ID="btn4" runat="server" Text="Material In" OnClick="btn4_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label5" runat="server" Text="5"></asp:Label></strong></td>
             <td style="color:black">  <strong>Analog Bullet Camera </strong></td>
             <td><asp:TextBox ID="txtdate5" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty5" runat="server"></asp:TextBox></td>
             
                  <td>
                 <asp:Button ID="btn5" runat="server" Text="Material In" OnClick="btn5_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label6" runat="server" Text="6"></asp:Label></strong></td>
               <td style="color:black">  <strong>6 TB surveillance HDD (To ensure 90 days back-up)</strong></td>
             <td><asp:TextBox ID="txtdate6" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty6" runat="server"></asp:TextBox></td>
               
                  <td>
                 <asp:Button ID="btn6" runat="server" Text="Material In" OnClick="btn6_Click" CssClass="cssButton" />
             </td>
        </tr>
       
             <tr>
               <td style="color:black">  <strong><asp:Label ID="Label7" runat="server" Text="7"></asp:Label></strong></td>
              <td style="color:black">  <strong>PIR</strong></td>
             <td><asp:TextBox ID="txtdate7" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty7" runat="server"></asp:TextBox></td>
            
                  <td>
                 <asp:Button ID="btn7" runat="server" Text="Material In" OnClick="btn7_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label8" runat="server" Text="8"></asp:Label></strong></td>
              <td style="color:black">  <strong>Smoke Detector</strong></td>
             <td><asp:TextBox ID="txtdate8" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty8" runat="server"></asp:TextBox></td>
             
                  <td>
                 <asp:Button ID="btn8" runat="server" Text="Material In" OnClick="btn8_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
               <td style="color:black">  <strong><asp:Label ID="Label9" runat="server" Text="9"></asp:Label></strong></td>
              <td style="color:black">  <strong>Magnetic Contact </strong></td>
             <td><asp:TextBox ID="txtdate9" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty9" runat="server"></asp:TextBox></td>
            
                  <td>
                 <asp:Button ID="btn9" runat="server" Text="Material In" OnClick="btn9_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
             <td style="color:black">  <strong><asp:Label ID="Label10" runat="server" Text="10"></asp:Label></strong></td>
              <td style="color:black">  <strong>Shutter Sensor (ATM, Cheque Drop Box)</strong></td>
             <td><asp:TextBox ID="txtdate10" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty10" runat="server"></asp:TextBox></td>
           
                  <td>
                 <asp:Button ID="btn10" runat="server" Text="Material In" OnClick="btn10_Click" CssClass="cssButton" />
             </td>
        </tr>
        
             <tr>
               <td style="color:black">  <strong><asp:Label ID="Label11" runat="server" Text="11"></asp:Label></strong></td>
              <td style="color:black">  <strong>Vibration Sensor</strong></td>
             <td><asp:TextBox ID="txtdate11" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty11" runat="server"></asp:TextBox></td>
             
                  <td>
                 <asp:Button ID="btn11" runat="server" Text="Material In" OnClick="btn11_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label12" runat="server" Text="12"></asp:Label></strong></td>
              <td style="color:black">  <strong>Glass Break Sensor</strong></td>
             <td><asp:TextBox ID="txtdate12" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty12" runat="server"></asp:TextBox></td>
           
                  <td>
                 <asp:Button ID="btn12" runat="server" Text="Material In" OnClick="btn12_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label13" runat="server" Text="13"></asp:Label></strong></td>
              <td style="color:black">  <strong>Panic</strong></td>
             <td><asp:TextBox ID="txtdate13" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty13" runat="server"></asp:TextBox></td>
            
                   <td>
                 <asp:Button ID="btn13" runat="server" Text="Material In" OnClick="btn13_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label14" runat="server" Text="14"></asp:Label></strong></td>
              <td style="color:black">  <strong>Hooter</strong></td>
             <td><asp:TextBox ID="txtdate14" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty14" runat="server"></asp:TextBox></td>
             
                   <td>
                 <asp:Button ID="btn14" runat="server" Text="Material In" OnClick="btn14_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
             <td style="color:black"> <strong><asp:Label ID="Label15" runat="server" Text="15"></asp:Label></strong></td>
              <td style="color:black">  <strong>Heat Sensor</strong></td>
             <td><asp:TextBox ID="txtdate15" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty15" runat="server"></asp:TextBox></td>
           
                   <td>
                 <asp:Button ID="btn15" runat="server" Text="Material In" OnClick="btn15_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label16" runat="server" Text="16"></asp:Label></strong></td>
             <td style="color:black">  <strong>Thermal VD</strong></td>
             <td><asp:TextBox ID="txtdate16" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty16" runat="server"></asp:TextBox></td>
           
                   <td>
                 <asp:Button ID="btn16" runat="server" Text="Material In" OnClick="btn16_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label17" runat="server" Text="17"></asp:Label></strong></td>
              <td style="color:black">  <strong>Keypad</strong></td>
             <td><asp:TextBox ID="txtdate17" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty17" runat="server"></asp:TextBox></td>
          
                   <td>
                 <asp:Button ID="btn17" runat="server" Text="Material In" OnClick="btn17_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label18" runat="server" Text="18"></asp:Label></strong></td>
               <td style="color:black">  <strong>Antenna – 18 dbi</strong></td>
             <td><asp:TextBox ID="txtdate18" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty18" runat="server"></asp:TextBox></td>
             
                   <td>
                 <asp:Button ID="btn18" runat="server" Text="Material In" OnClick="btn18_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label19" runat="server" Text="19"></asp:Label></strong></td>
              <td style="color:black">  <strong>4G Dual Sim Router</strong></td>
             <td><asp:TextBox ID="txtdate19" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty19" runat="server"></asp:TextBox></td>
              
                   <td>
                 <asp:Button ID="btn19" runat="server" Text="Material In" OnClick="btn19_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
               <td style="color:black">  <strong><asp:Label ID="Label20" runat="server" Text="20"></asp:Label></strong></td>
              <td style="color:black"> <strong>Battery 12 V 12AH</strong></td>
             <td><asp:TextBox ID="txtdate20" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty20" runat="server"></asp:TextBox></td>
              
                   <td>
                 <asp:Button ID="btn20" runat="server" Text="Material In" OnClick="btn20_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label21" runat="server" Text="21"></asp:Label></strong></td>
             <td style="color:black">  <strong>Monitor 19"</strong></td>
             <td><asp:TextBox ID="txtdate21" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty21" runat="server"></asp:TextBox></td>
            
                   <td>
                 <asp:Button ID="btn21" runat="server" Text="Material In" OnClick="btn21_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label22" runat="server" Text="22"></asp:Label></strong></td>
              <td style="color:black"> <strong>VGA Cable (1Mtr.)</strong></td>
             <td><asp:TextBox ID="txtdate22" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty22" runat="server"></asp:TextBox></td>
           
                   <td>
                 <asp:Button ID="btn22" runat="server" Text="Material In" OnClick="btn22_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
             <td style="color:black">  <strong><asp:Label ID="Label23" runat="server" Text="23"></asp:Label></strong></td>
               <td style="color:black">  <strong>Mouse Extender</strong></td>
             <td><asp:TextBox ID="txtdate23" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty23" runat="server"></asp:TextBox></td>
           
                   <td>
                 <asp:Button ID="btn23" runat="server" Text="Material In" OnClick="btn23_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label24" runat="server" Text="24"></asp:Label></strong></td>
              <td style="color:black">  <strong>Cable 3+1</strong></td>
             <td><asp:TextBox ID="txtdate24" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty24" runat="server"></asp:TextBox></td>
           
                   <td>
                 <asp:Button ID="btn24" runat="server" Text="Material In" OnClick="btn24_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label25" runat="server" Text="25"></asp:Label></strong></td>
              <td style="color:black">  <strong>2 Core</strong></td>
             <td><asp:TextBox ID="txtdate25" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty25" runat="server"></asp:TextBox></td>
           
                   <td>
                 <asp:Button ID="btn25" runat="server" Text="Material In" OnClick="btn25_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
               <td style="color:black">  <strong><asp:Label ID="Label26" runat="server" Text="26"></asp:Label></strong></td>
              <td style="color:black">  <strong>8 Core Cable</strong></td>
             <td><asp:TextBox ID="txtdate26" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty26" runat="server"></asp:TextBox></td>
             
                   <td>
                 <asp:Button ID="btn26" runat="server" Text="Material In" OnClick="btn26_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label27" runat="server" Text="27"></asp:Label></strong></td>
              <td style="color:black">  <strong>DVR 4 Channel</strong></td>
             <td><asp:TextBox ID="txtdate27" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty27" runat="server"></asp:TextBox></td>
             
                   <td>
                 <asp:Button ID="btn27" runat="server" Text="Material In" OnClick="btn27_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label28" runat="server" Text="28"></asp:Label></strong></td>
             <td style="color:black"> <strong>HDD 2 TB</strong></td>
             <td><asp:TextBox ID="txtdate28" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty28" runat="server"></asp:TextBox></td>
             
                   <td>
                 <asp:Button ID="btn28" runat="server" Text="Material In" OnClick="btn28_Click" CssClass="cssButton" />
             </td>
        </tr>
             <tr>
              <td style="color:black">  <strong><asp:Label ID="Label29" runat="server" Text="29"></asp:Label></strong></td>
              <td style="color:black">  <strong>Switcher</strong></td>
             <td><asp:TextBox ID="txtdate29" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty29" runat="server"></asp:TextBox></td>
           
                   <td>
                 <asp:Button ID="btn29" runat="server" Text="Material In" OnClick="btn29_Click" CssClass="cssButton" />
             </td>
        </tr>
        <tr>
              <td style="color:black"> <strong><asp:Label ID="Label30" runat="server" Text="30"></asp:Label></strong></td>
             <td style="color:black"> <strong>VGA (10Mtr.)</strong></td>
             <td><asp:TextBox ID="txtdate30" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty30" runat="server"></asp:TextBox></td>
            
              <td>
                 <asp:Button ID="btn30" runat="server" Text="Material In" OnClick="btn30_Click" CssClass="cssButton" />
             </td>
        </tr>
        <tr>
              <td style="color:black">  <strong><asp:Label ID="Label31" runat="server" Text="31"></asp:Label></strong></td>
              <td style="color:black">  <strong>Connectors - DC</strong></td>
             <td><asp:TextBox ID="txtdate31" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty31" runat="server"></asp:TextBox></td>
            
              <td>
                 <asp:Button ID="btn31" runat="server" Text="Material In" OnClick="btn31_Click" CssClass="cssButton" />
             </td>
        </tr>

          <tr>
              <td style="color:black">  <strong><asp:Label ID="Label32" runat="server" Text="32"></asp:Label></strong></td>
              <td style="color:black">  <strong>Connectors - BNC</strong></td>
             <td><asp:TextBox ID="txtdate32" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty32" runat="server"></asp:TextBox></td>
           
              <td>
                 <asp:Button ID="btn32" runat="server" Text="Material In" OnClick="btn32_Click" CssClass="cssButton" />
             </td>
        </tr>
          <tr>
              <td style="color:black">  <strong><asp:Label ID="Label33" runat="server" Text="33"></asp:Label></strong></td>
              <td style="color:black">  <strong>Connectors - RC</strong></td>
             <td><asp:TextBox ID="txtdate33" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty33" runat="server"></asp:TextBox></td>
              
              <td>
                 <asp:Button ID="btn33" runat="server" Text="Material In" OnClick="btn33_Click" CssClass="cssButton" />
             </td>
        </tr>
        <tr>
              <td style="color:black">  <strong><asp:Label ID="Label34" runat="server" Text="34"></asp:Label></strong></td>
              <td style="color:black">  <strong>Installation Book</strong></td>
             <td><asp:TextBox ID="txtdate34" runat="server"></asp:TextBox></td>
             <td><asp:TextBox ID="txtqty34" runat="server"></asp:TextBox></td>
               
              <td>
                 <asp:Button ID="btn34" runat="server" Text="Material In" OnClick="btn34_Click" CssClass="cssButton" />
             </td>
        </tr>


    </table>

    
</asp:Content>
