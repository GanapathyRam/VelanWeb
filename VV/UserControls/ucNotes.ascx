<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucNotes.ascx.cs" Inherits="UserControls_ucNotes" %>
<table style="width: 332px; height: 55px">
    <tr>
        <td>
            <asp:Label ID="lblName" runat="server" Text="Label" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="12px" ForeColor="Maroon"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Wrap="true" ToolTip="Enter Notes" Height="47px" Width="252px"></asp:TextBox>
        </td>
        <td>
          <asp:ImageButton ID="imgBtnSave" runat="server" ToolTip="Click to Save" ImageUrl="~\Images\tick.jpg" OnClick="imgBtnSave_Click" />
        </td>                
        <td>
          <asp:ImageButton ID="imgBtnCancel" runat="server" ToolTip="Click to Cancel" ImageUrl="~\Images\wrong.jpg" OnClick="imgBtnCancel_Click" />
        </td>        
    </tr>
</table>