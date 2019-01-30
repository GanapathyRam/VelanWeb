<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VV.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding-left: 450px; padding-top: 200px; padding-right: 200px;">
        <tr>
            <td>
                <asp:Label ID="lblUserName" Text="UserName" runat="server"></asp:Label></td>
            <%--<td> <asp:Label ID="lblSep" Text=" : " runat="server" ></asp:Label></td>--%>
            <td>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassword" Text="Password" runat="server"></asp:Label></td>
            <%--<td> <asp:Label ID="lblSep1" Text=" : " runat="server" ></asp:Label></td>--%>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding-left: 450px; padding-top: 30px; padding-bottom: 200px; padding-right: 200px;">
        <tr>
            <td style="padding-left: 100px;">
                <asp:Button ID="btnLogin" Text="Login" CssClass="buttonText" runat="server" OnClick="btnLogin_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancell" Text="Cancel" CssClass="buttonText" runat="server" OnClick="btnCancell_Click" />
            </td>

        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
