<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" EnableEventValidation="false" Culture="en-IN" CodeBehind="UtilityRequest.aspx.cs" Inherits="VV.UtilityRequest" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr style="height: 40px;">
            <td colspan="3" style="text-align: right; font-family: Arial;">
                <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Visible="false" Font-Size="Medium" runat="server"></asp:Label>
            </td>
            <td colspan="1" style="font-family: Verdana; text-align: center;">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="* fields are mandatory."></asp:Label>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblEmployees" Text="Requested By" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:DropDownList ID="ddlEmployess" style="width:185px; height:22px; margin-left:20px;" DataValueField="EmployeeCode" DataTextField="EmployeeName" runat="server"></asp:DropDownList>
                <asp:Label ID="lblRequiredFields" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lblRequestedDate" Text="Requested Date" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtRequestedDate" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblItemCodeFrom" Text="ItemCode From" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtItemCodeFrom" Height="15px" CssClass="textBox" AutoPostBack="true" OnTextChanged="txtItemCodeFrom_TextChanged" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>                
            </td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lblItemCodeTo" Text="ItemCode To" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtItemCodeTo" Height="15px" CssClass="textBox" AutoPostBack="true" OnTextChanged="txtItemCodeTo_TextChanged" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblOrderNo" Text="Order No" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtOrderNo" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lblPos" Text="Pos" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtPos" runat="server" CssClass="textBox" Height="15px"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblQuantity" Text="Quantity" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtQuantity" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
                <asp:Label ID="Label6" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>
            </td>
             <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lblRemarks" Text="Remarks" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textBox" Height="15px"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="3" style="text-align: center;">
                <asp:Button ID="Button1" Style="font-style: normal;" runat="server" Width="100px" Height="30px" Text="Save" OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" Width="100px" Style="font-style: normal; font-weight: 10px;" Height="30px" Text="Clear" OnClick="btnClear_Click" />
            </td>
            <td></td>
        </tr>
        <tr style="height:20px;">
            <td colspan="5"></td>
        </tr>
    </table>
</asp:content>
