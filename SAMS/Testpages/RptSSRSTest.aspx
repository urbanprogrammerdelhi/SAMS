﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptSSRSTest.aspx.cs" Inherits="Testpages_RptSSRSTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" Width="500px" ID="txtURL" Text=""></asp:TextBox>
        <asp:Button runat="server" ID ="btnSubmit" Text="Submit" 
            onclick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
