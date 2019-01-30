<%@ Page Title="Create New User" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="CreateNewUser.aspx.cs" Inherits="VV.CreateNewUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" width="30%" class="secondLevelHeader">
                <asp:Label ID="Label2" runat="server" Text="Create New User" />
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
        <table border="0" cellpadding="5" cellspacing="0" style="width: 75%">
            <%--<tr>
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="Label1" runat="Server" Text="*" ForeColor="red"></asp:Label>
                    <asp:Label ID="lblEmpID" Text="Employee ID" runat="server"></asp:Label>
                </td>
                <td align="left" class="detailTableRowContent">
                    <asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValEmpID" runat="server" ControlToValidate="txtEmpID" Display="Dynamic" ErrorMessage="Employee ID is Mandatory" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px"> &nbsp; </td>
                <td align="left" class="detailTableRowContent"> &nbsp; </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="Label3" runat="Server" Text="*" ForeColor="red"></asp:Label>
                    <asp:Label ID="lblUserName" Text="User Name" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="User Name is Mandatory" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px"> &nbsp; </td>
                <td align="left" class="detailTableRowContent"> &nbsp; </td>
            </tr>
           <tr>
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="Label4" runat="Server" Text="*" ForeColor="red"></asp:Label>
                    <asp:Label ID="lblPassword" Text ="Password" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password is Mandatory" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px"> &nbsp; </td>
                <td align="left" class="detailTableRowContent"> &nbsp; </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="width: 616px">
                    <asp:Label ID="Label5" runat="Server" Text="*" ForeColor="red"></asp:Label>
                    <asp:Label ID="lblConfirmPassword" Text ="Confirm Password" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                   <asp:TextBox ID="txtConfPassword" runat="server" TextMode="Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfPassword" Display="Dynamic" ErrorMessage="Confirm Password is Mandatory" SetFocusOnError="true"></asp:RequiredFieldValidator>
                   <asp:CompareValidator ID="compVal1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfPassword" Display="Dynamic" ErrorMessage="Passwords does not match" Type="String"></asp:CompareValidator>
                </td>
            </tr>
            <tr style="visibility:hidden;">
                <td align="right" class="detailTableRowHead" style="width: 616px"> &nbsp; </td>
                <td align="left" class="detailTableRowContent"> &nbsp; </td>
            </tr>
        </table>
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td align="center" colspan="2" valign="bottom">
                    <asp:Button ID="buttonUpdate" runat="server"  Width="100px" CssClass="buttonText" Text="Add" ToolTip="Create New User"
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
