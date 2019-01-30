<%@ Page Title="Vendor Master" Language="C#" AutoEventWireup="true" CodeBehind="VendorMaster.aspx.cs" MasterPageFile="~/VV.Master"
    Inherits="VV.VendorMaster" Culture="en-IN" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr style="height: 40px;">
            <td></td>
            <td colspan="2" style="text-align: center; font-family: Arial; font-size: 10px;">
                <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Visible="false" runat="server"></asp:Label>
            </td>
            <td colspan="1" style="font-family: Verdana; text-align: center;">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="* fields are mandatory."></asp:Label>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblvendorname" Text="Vendor Name" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtVendorName" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
                <asp:Label ID="lblRequiredFields" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lbladdress1" Text="Address1" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtAddress1" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblAddress2" Text="Address2" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtAddress2" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lblAddress3" Text="Address3" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtAddress3" Height="15px" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblcity" Text="City" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtcity" Height="15px" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lblstate" Text="State" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtstate" runat="server" CssClass="textBox" Height="15px"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblpin" Text="Pin" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtpin" Height="15px" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lbltinnumber" Text="TIN Number" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txttinnumber" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblcstnumber" Text="GST Number" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtcstnumber" Height="15px" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 220px;">
                <asp:Label ID="lblemail" Text="Email" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtemail" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblSupplierCode" Text="Supplier Code" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtSupplierCode" Height="15px" CssClass="textBox" runat="server"></asp:TextBox></td>
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
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td style="text-align: right;">
                <asp:Label ID="lblSupplierName" Style="font: 13px Verdana;" runat="server" Text="Vendor Name"></asp:Label>
            </td>
            <td style="text-align: center;">
                <asp:TextBox ID="txtSupplierName" Height="20px" Width="200px" runat="server" ToolTip="Enter Vendor Name to be Searched" onKeyUp="ControlSearch(this)" />
            </td>
            <td>
                <asp:Button ID="btnSearchBox" runat="server" Width="100px" Style="font-style: normal; font-weight: 10px;" Height="30px" Enabled="true" OnClick="btnSearchBox_Click" Text="Search" ToolTip="Click to Search Data" />
            </td>
        </tr>
    </table>
    <div style="margin-top: 20px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="VendorCode" AllowPaging="true" PageSize="24"
                    OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                    PagerStyle-CssClass="Grid_Pager" HeaderStyle-HorizontalAlign="Left"
                    AutoGenerateEditButton="true" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <RowStyle CssClass="Grid_RowRecord" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
