<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/ErrorPage.aspx.cs" Inherits="ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HRS - Error</title>
    <link href="Css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: Gray">
    <table border="1" class="errorTxt" width="100%">
        <tr>
            <td align="center" >
                <asp:Label ID="lblHeading" Font-Size="15px" Text="Error in running the application. Please contact system administrator." runat="server"></asp:Label>
            </td>
        </tr>
        <tr>&nbsp;</tr>
        <tr>&nbsp;</tr>        
        <tr>
            <td>
                <asp:Label ID="lblRootURl" Font-Size="10px" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblErrorMsg" Font-Size="10px" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblErrorStackTrace" Font-Size="10px" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</body>
</html>
