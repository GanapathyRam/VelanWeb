<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Login.aspx.cs" Inherits="VV.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
   
        <table>
            </br> </br> </br> </br> </br> </br> </br></br> </br> </br> </br> </br> </br> </br>
        </table>
        <table  align="center" title="Please login." cellspacing="0" cellpadding="1" cellpadding="4" CssSelectorClass="PrettyLogin" border="0" id="ctl00_ctl00_MainContent_LiveExample_loginview1_login1" style="background-color:White;border-color:#284775;border-width:1px;border-style:Solid;border-collapse:collapse;vertical-align:middle;">
          <tr>
            <td><table cellpadding="0" border="0" style="font-family:Verdana;font-size:0.8em;">
              <tr>
                <td align="center" colspan="2" style="color:#F7F6F3;background-color:#5D7B9D;font-weight:bold;height:2em;">Login</td>
              </tr><tr>
                <td align="right" style="color:#5D7B9D;"><label for="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_UserName">User Name:</label></td>
                  <%--<td><input name="ctl00$ctl00$MainContent$LiveExample$loginview1$login1$UserName" type="text" id="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_UserName" style="color:#5D7B9D;border-color:#5D7B9D;border-width:1px;border-style:Solid;" /></td>--%>
                  <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
              </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                <td align="right" style="color:#5D7B9D;"><label for="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_Password">Password:</label></td>
                    <%--<td><input name="ctl00$ctl00$MainContent$LiveExample$loginview1$login1$Password" type="password" id="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_Password" style="color:#5D7B9D;border-color:#5D7B9D;border-width:1px;border-style:Solid;" /></td>--%>
                    <td> <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
              </tr>
               <%-- <tr>
                <td colspan="2" style="color:#5D7B9D;"><input id="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_RememberMe" type="checkbox" name="ctl00$ctl00$MainContent$LiveExample$loginview1$login1$RememberMe" /><label for="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_RememberMe">Remember me next time.</label></td>
              </tr>--%>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" colspan="2"><asp:Button ID="btnLogin" Text="Login" runat="server" style="color:Cyan;background-color:#284775;border-color:#5D7B9D;border-width:1px;border-style:Solid;" OnClick="btnLogin_Click"/> </td>
                <%--<td align="right" colspan="1"><input type="submit" name="ctl00$ctl00$MainContent$LiveExample$loginview1$login1$LoginButton" value="Login" id="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_LoginButton" style="color:Cyan;background-color:#284775;border-color:#5D7B9D;border-width:1px;border-style:Solid;" /></td>--%>
              </tr>
                <%--<tr>
                <td colspan="2"><a id="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_CreateUserLink" href="CreateUserWizard.aspx">Register here.</a><br /><a id="ctl00_ctl00_MainContent_LiveExample_loginview1_login1_PasswordRecoveryLink" href="PasswordRecovery.aspx">Forgot your password?</a></td>
              </tr>--%>
            </table></td>
          </tr>
        </table>
    
    </form>
</body>
</html>
