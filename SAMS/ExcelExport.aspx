<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelExport.aspx.cs" Inherits="ExcelExport" %>

<!DOCTYPE html>

<html>
<head>
    <title>Import Excel Data</title>
</head>
<body>
    <form id="form1" runat="server">
    
        <!-- ADD A FILE UPLOAD CONTROL AND A BUTTON TO EXECUTE. -->
        <div style="font:14px Verdana">
        
            Select a file to upload: 
                <asp:FileUpload ID="FileUpload" Width="450px" runat="server" />
            <p><asp:Button ID="btninsert" Text="ImportDAta" OnClick="btninsert_Click" runat="server" /></p>
            <p><asp:Label id="lblConfirm" runat="server"></asp:Label></p>
                
        </div>
        
    </form>
</body>
</html>