<%@ Page Title="Update MIS Sales Input" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="UpdateMISSalesInput.aspx.cs" Inherits="VV.UpdateMISSalesInput" %>
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
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lblOrderNo" Text ="Order No" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblOrderNoVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lbl" Text ="Pos" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblPosVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lblLineNum" Text ="Line #" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblLineNumVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lblSAPCode" Text ="SAP Code" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:TextBox ID="txtSAPCode" MaxLength="20" runat="server" cssclass="inputStyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lblStockCode" Text ="Stock Code" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:TextBox ID="txtStockCode" MaxLength="20" runat="server" cssclass="inputStyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lblO2" Text ="O2" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:CheckBox ID="chkO2" Checked="false" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lblH2" Text ="H2" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:CheckBox ID="chkH2" Checked="false" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lblIBR" Text ="IBR" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:CheckBox ID="chkIBR" Checked="false" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 675px">
                    <asp:Label ID="lblASU" Text ="ASU" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:CheckBox ID="chkASU" Checked="false" runat="server"></asp:CheckBox>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td align="center" colspan="2" valign="bottom">
                    <asp:Button ID="buttonUpdate" runat="server"  Width="100px" CssClass="buttonText" Text="Update" ToolTip="Update MIS Sales"
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
