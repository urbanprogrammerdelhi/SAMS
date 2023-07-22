<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="cssnew/bootstrap.css" rel="stylesheet" />
    <a href="fontsnew/glyphicons-halflings-regular.ttf"></a>
    <script src="js/bootstrap.js"></script>
    <title>Login</title>
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }

        .auto-style2 {
            width: 365px;
            height: 9px;
        }
    </style>
</head>
<body class="login-class" style="background-color: #2E6292;">
    <form id="form1" runat="server">
        <div class="panel panel-head" style="margin-bottom: 0px">
            <table style="padding-left: 15px; width: 100%; background-color: white;" class="table-responsive">
                <tr style="background-color: white; width: 80%">
                  <td class="auto-style4" style="padding-left: 15px" colspan="3">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/SAMS Logo New.png" Width="1411px" Height="150px"  class="img-responsive" />
                </td>
                </tr>
            </table>
        </div>
        <div class="panel-body table-responsive">
            <table class="table-responsive-xl form-group">
                <tr class="table-info">
                    <td class="auto-style4" style="padding-left: 5px" rowspan="5">
                        <asp:Image ID="imgbaner" runat="server" ImageUrl="~/images/building1.jpg" Width="790px" class="img-responsive" />
                    </td>
                    <td style="text-align: right; padding-left: 80px;" class="auto-style1">
                        <div class="input-group input-lg">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <asp:TextBox ID="txtUserID" TabIndex="1" runat="server" Style="background-color: deepskyblue" placeholder="LoginID" Height="32px"
                                ForeColor="White" Font-Bold="true" class="form-control"></asp:TextBox>
                        </div>

                        <div class="input-group input-lg">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="txtPassword" TabIndex="2" runat="server" Style="background-color: deepskyblue;" Height="32px" placeholder="Password"
                                class="form-control" TextMode="Password" ForeColor="White" Font-Bold="true">  </asp:TextBox>
                        </div>

                        <div class="input-group input-lg">
                               <asp:DropDownList AutoPostBack="true" ID="ddllanguage" CssClass="cssDropDown dropdownlogin" onKeyUp="SomeKeyPressed(event)"
                        runat="server" OnSelectedIndexChanged="ddllanguage_SelectedIndexChanged" Visible="false">
                       <asp:ListItem Text="<%$Resources:Resource,DefaultLanguage %>" Value="<%$Resources:Resource,DefaultLanguageValue %>"></asp:ListItem>
                               </asp:DropDownList>
                  
                <BotDetect:Captcha ID="SampleCaptcha" runat="server" BackColor="DeepSkyBlue" ForeColor="White" Width="100px"></BotDetect:Captcha>   
       
                        </div>

                        <div class="input-group input-lg">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-eye-open"></i></span>
                            <asp:TextBox ID="CaptchaCodeTextBox" TabIndex="3" runat="server" placeholder="Captcha" Style="background-color: deepskyblue;" Height="32px"
                                class="form-control" ForeColor="White" Font-Bold="true"></asp:TextBox>
                          </div>
                        <div class="input-group input-lg">
                            <asp:Button ID="BtnSubmit" runat="server" Text="Sign In" CssClass="form-control btn btn-success"></asp:Button>
                            <span class="input-group-addon"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                        </div>
                                
                         <div class="input-group input-lg">
        <BotDetect:CaptchaValidator ID="SampleCaptchaValidator" 
        runat="server" ControlToValidate="CaptchaCodeTextBox" CaptchaControl="SampleCaptcha" BackColor="DeepSkyBlue" ForeColor="White" Font-Bold="true"
        ErrorMessage="Retype the characters" 
        EnableClientScript="true" SetFocusOnError="true" Visible="false">
      </BotDetect:CaptchaValidator>
                      </div>

                      
                        <asp:Label ID="ValidationPassedLabel" runat="server" CssClass="alert-danger" Visible="false" Text="Validation passed!" />
                     
                        <div class="auto-style2">
                          
                                           
                        <asp:Label ID="Label1" runat="server" Visible="true" Text="Powered by" Style="font-size: large; color: white" Font-Bold="true"></asp:Label>
                        <asp:HyperLink ID="btnlink" Text="IFM360" Target="http://www.v19tech.in/" Style="font-size: large; color: white;" runat="server" NavigateUrl="http://www.v19tech.in/ifm360.html" Font-Bold="true"></asp:HyperLink>
           
                     
                        <p class="cssLoginFooterText" >
                 <asp:Label ID="lblSoftwareVersion" runat="server" visible="true" Style="font-size: large; color: white;"></asp:Label>&nbsp;
            <asp:Label ID="lblRelease" runat="server" visible="true" Style="font-size: large; color: white;"></asp:Label>&nbsp;
            <asp:ImageButton ID="ImgConfiguration" runat="server" Width="20px" Height="10px" style="cursor:default;" ImageUrl="~/Images/spacer.gif" onclick="ImgConfiguration_Click" visible="true"  />
          </p>
                             <p class="loginheader">
        <asp:Label ID="lblSoftwareName" CssClass="cssLabelSoftwareName" runat="server" Visible="false"></asp:Label>
      
            <asp:Label style="display: block;text-align: center;color: red;font-weight:bold; opacity: 0.8;" ID="lbErrMsg" EnableViewState="false" CssClass="cssLoginErrorMsgLable" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbErrMsg1" EnableViewState="false" CssClass="cssLoginErrorMsgLable" runat="server" Text=""></asp:Label>
            <asp:Label ID="ScreenResolution" runat="server" Visible="false" />
                                     <asp:DropDownList ID="ddlCountry" runat="server" CssClass="cssDropDown hide-obj"
                style="background-color:transparent; border:0; color:transparent; -webkit-appearance: none;-moz-appearance: none;">
            </asp:DropDownList>
          
    </p>
                      
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
     <script type="text/javascript">
         function SomeKeyPressed(e) {
             //alert(e.keyCode);
             //190 for .
             if (e.keyCode == 190) {
                 //alert(document.getElementById('<%=ddlCountry.ClientID%>').options[document.getElementById('<%=ddlCountry.ClientID%>').selectedIndex].text);
                document.getElementById('<%=ddlCountry.ClientID%>').style.display = 'block';
            }

        }
    </script>
</body>
</html>

