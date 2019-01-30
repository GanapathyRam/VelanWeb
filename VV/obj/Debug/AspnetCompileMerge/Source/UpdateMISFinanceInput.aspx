<%@ Page Title="Update MIS Finance Input" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="UpdateMISFinanceInput.aspx.cs" Inherits="VV.UpdateMISFinanceInput" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" width="30%" class="secondLevelHeader">
                <asp:Label ID="Label2" runat="server" Text="Update MIS Sales Input" />
            </td>
        </tr>
    </table>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
        <script type="text/javascript">
       
           //Function to ensure that non numeric values are not entered in the places where only the numeric values are to be given
            function AllowNumeric()
            {
              if ((event.keyCode>57) || (event.keyCode<48))
                {
	                event.keyCode=0;
                }
            }
        </script>
    <div id="beforeInsert" runat="server" visible="true">
     <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <table border="0" cellpadding="5" cellspacing="0" width="70%">
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="lblOrderNo" Text ="Order No" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblOrderNoVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px"> &nbsp; </td>
                <td align="left" class="detailTableRowContent"> &nbsp; </td>
            </tr>
           <tr>
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="lblABJ" Text ="ABG (Advance Bank Guarantee)" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:CheckBox ID="chkABG" Checked="false" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px"> &nbsp; </td>
                <td align="left" class="detailTableRowContent"> &nbsp; </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="lblPBG" Text ="PBG (Performance Bank Guarantee)" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:CheckBox ID="chkPBG" Checked="false" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px"> &nbsp; </td>
                <td align="left" class="detailTableRowContent"> &nbsp; </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="lblRP" Text ="RP (Road Permit)" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:CheckBox ID="chkRP" Checked="false" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px"> &nbsp; </td>
                <td align="left" class="detailTableRowContent"> &nbsp; </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="lbl" Text ="Pos" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblPosVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="lblLineNum" Text ="Line #" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblLineNumVal" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td align="center" colspan="2" valign="bottom">
                    <asp:Button ID="buttonUpdate" runat="server"  Width="100px" CssClass="buttonText" Text="Update" ToolTip="Update MIS Finance"
                        OnClick="buttonUpdate_Click" /> &nbsp;
                    <asp:Button ID="buttonCancel" runat="server" CausesValidation="False" CssClass="buttonText" ToolTip="Cancel"
                        Text="Cancel" OnClick="buttonCancel_Click" />
                </td>
            </tr>
            <tr>
                <td align="left" class="detailTableRowHead"colspan="2">
                    <asp:ValidationSummary ID="valErrors" runat="server" CssClass="errorTxt" DisplayMode="BulletList"
                        HeaderText="Please correct the following errors::" />
                </td>
            </tr>
        </table>
        </div>
</asp:Content>
