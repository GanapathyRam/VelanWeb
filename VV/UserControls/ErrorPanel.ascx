<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ErrorPanel.ascx.cs" Inherits="UserControls_ErrorPanel" %>
<table style="width: 431px" border="1">
    <tr>
        <td style="width: 426px">
            <asp:Label ID="lblErrorTitle" runat="server" Font-Size="Smaller" Width="421px" Font-Bold="True"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 426px">
            <asp:BulletedList ID="bltdList" runat="server" BulletStyle="Square" Font-Size="Smaller"
                Width="380px">
            </asp:BulletedList>
        </td>
    </tr>
</table>
