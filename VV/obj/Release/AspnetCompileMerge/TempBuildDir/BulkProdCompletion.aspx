<%@ Page Title="Bulk Production Completion" Language="C#" AutoEventWireup="true"
    CodeBehind="BulkProdCompletion.aspx.cs" Inherits="VV.BulkProdCompletion" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bulk Production Completion</title>
    <link href="CSS/PopUpStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <script language="javascript" type="text/javascript">
        function Reset() {
            this.form1.reset();
        }
    </script>
    <table>
        <tr>
            <td colspan="3" align="left" class="detailTableRowHead">
                <asp:Label ID="Label8" runat="server" Text="Serial No : "></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="detailTableRowHead">
                <asp:Label ID="Label7" runat="server" Text="Prefix : "></asp:Label>
                <asp:RequiredFieldValidator ID="reqValPrefix" runat="server" ControlToValidate="txtPrefix" Display="Dynamic" ErrorMessage="Serial No Prefix is Mandatory"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPrefix" CssClass="inputStyle" Width="45" runat="server"></asp:TextBox>
            </td>
            <td align="left" class="detailTableRowHead">
                <asp:Label ID="Label9" runat="server" Text="From : "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromSerialNo" Display="Dynamic" ErrorMessage="Serial No From is Mandatory"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" SetFocusOnError="true" ControlToValidate="txtFromSerialNo" Display="Dynamic" ErrorMessage="only Numbers" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtFromSerialNo" CssClass="inputStyle" Width="45" runat="server"></asp:TextBox>
            </td>
            <td align="left" class="detailTableRowHead">
                <asp:Label ID="Label10" runat="server" Text="To : "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToSerialNo" Display="Dynamic" ErrorMessage="Serial No To is Mandatory"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexToSerialNo" runat="server" SetFocusOnError="true" ControlToValidate="txtToSerialNo" Display="Dynamic" ErrorMessage="only Numbers" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                <asp:CompareValidator runat="server" id="cmpNumbers" controltovalidate="txtFromSerialNo" controltocompare="txtToSerialNo" operator="LessThan" type="Integer" errormessage="The From number should be smaller than the To number!" /><br />
                <asp:TextBox ID="txtToSerialNo" CssClass="inputStyle" Width="45" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="right" class="detailTableRowHead">
                <asp:Label ID="Label6" runat="server" Text="Prod Order No"></asp:Label>
            </td>
            <td align="left" class="detailTableRowContent">
                <asp:TextBox ID="txtProdOrderNo" CssClass="inputStyle" runat="server" Width="120"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProdOrderNo" Display="Dynamic" ErrorMessage="Prod Order No is Mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="detailTableRowHead">
                <asp:Label ID="Label3" runat="server" Text="Prod Commited Date"></asp:Label>
            </td>
            <td align="left" class="detailTableRowContent">
                <asp:TextBox ID="txtProdCommitedDate" CssClass="inputStyle" runat="server" Width="120"></asp:TextBox>
                <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtProdCommitedDate"
                    ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[-](0?[1-9]|1[012])[-]\d{4}$"
                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="detailTableRowHead">
                <asp:Label ID="Label4" runat="server" Text="CompDate"></asp:Label>
            </td>
            <td align="left" class="detailTableRowContent">
                <asp:TextBox ID="txtCompDate" CssClass="inputStyle" runat="server" Width="120"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCompDate"
                    ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[-](0?[1-9]|1[012])[-]\d{4}$"
                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="detailTableRowHead">
                <asp:Label ID="Label5" runat="server" Text="Prod Remarks"></asp:Label>
            </td>
            <td align="left" class="detailTableRowContent">
                <asp:DropDownList ID="drpDwnPrdRem" CssClass="inputStyle" runat="server" Width="120">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 50px;" align="right">
                <asp:Button ID="btnSubmit" Text="Update" runat="server" CssClass="buttonText" OnClick="btnSubmit_Click" />
            </td>
            <td style="padding-left: 20px;" align="right">
                <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="buttonText" OnClientClick="Reset();" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
