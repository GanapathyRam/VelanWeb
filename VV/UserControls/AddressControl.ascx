<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddressControl.ascx.cs"
    Inherits="AddressControl" %>
<table width="100%" cellpadding="0px" cellspacing="0px">
    <tr>
        <td colspan="2" class="detailTableRowHead">
            <asp:DataGrid ID="AddressList" runat="server">
            </asp:DataGrid>
        </td>
    </tr>
    <tr>
        <td align="right" style="" class="detailTableRowHead">
            <asp:Label ID="lblAddrType" runat="server" Text="Address Type"></asp:Label>
        </td>
        <td align="left" class="detailTableRowContent">
            <asp:DropDownList ID="drpDwAddrType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="addressTypeChange">
            </asp:DropDownList>

        <asp:Label ID="lblXrefId" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" style="" class="detailTableRowHead" width="30%">
            <asp:Label ID="lblAddr1" runat="server" Text="Address Line 1" Width="372px"></asp:Label>
        </td>
        <td align="left" class="detailTableRowContent">
            <asp:TextBox CssClass="inputStyle" ID="txtAddr1" runat="server" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" style="" class="detailTableRowHead" width="30%">
            <asp:Label ID="lblAddr2" runat="server" Text="Address Line 2" Width="372px"></asp:Label>
        </td>
        <td align="left" class="detailTableRowContent">
            <asp:TextBox CssClass="inputStyle" ID="txtAddr2" runat="server" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" style="" class="detailTableRowHead" width="30%">
            <asp:Label ID="lblAddr3" runat="server" Text="Address Line 3" Width="372px"></asp:Label>
        </td>
        <td align="left" class="detailTableRowContent">
            <asp:TextBox CssClass="inputStyle" ID="txtAddr3" runat="server" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" style="" class="detailTableRowHead" width="30%">
            <asp:Label ID="lblAddrCity" runat="server" Text="City"></asp:Label>
        </td>
        <td align="left" class="detailTableRowContent">
            <asp:TextBox CssClass="inputStyle" ID="txtCity" runat="server" MaxLength="100"></asp:TextBox>
        </td>
        </tr>
        <tr>
            <td align="right" style="" class="detailTableRowHead" width="30%">
                <asp:Label ID="lblAddrState" runat="server" Text="State"></asp:Label>
            </td>
            <td align="left" class="detailTableRowContent">
                <asp:TextBox CssClass="inputStyle" ID="txtState" runat="server" MaxLength="100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="" class="detailTableRowHead" width="30%">
                <asp:Label ID="lblAddrCtry" runat="server" Text="Country"></asp:Label>
            </td>
            <td align="left" class="detailTableRowContent">
                <asp:DropDownList ID="drpDwCtry" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="" class="detailTableRowHead" width="30%">
                <asp:Label ID="lblAddrZip" runat="server" Text="Zip/Postal Code"></asp:Label>
            </td>
            <td align="left" class="detailTableRowContent">
                <asp:TextBox CssClass="inputStyle" ID="txtZip" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="bottom" align="center">
                <asp:Button ID="buttonAdd" runat="server" CssClass="buttonText" Text="Add/Update Address"
                    OnClick="buttonAddClick" />
                <asp:Button ID="buttonCancel" runat="server" CssClass="buttonText" Text="Cancel" OnClick="buttonCancelClick"/>
            </td>
        </tr>
</table>
