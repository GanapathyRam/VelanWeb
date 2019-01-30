<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="AllDCReport.aspx.cs"
    Inherits="VV.AllDCReport" EnableEventValidation="false" Culture="en-IN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="15%">
                <asp:Label ID="lblPageTitle" runat="server" Text="Pending DC Items" />
                <asp:Panel ID="SearchPanel" runat="server" Style="margin-left: 50px;">
                    <asp:ImageButton ID="imgExcelForPending" runat="server" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="imgExcelForPending_Click" Height="25px" Width="25px" />
                </asp:Panel>
            </td>
            <td align="left" class="secondLevelHeader" width="10%">
                <asp:Label ID="Label1" runat="server" Text="Sent DC Items" />
                <asp:Panel ID="Panel1" runat="server" Style="margin-left: 50px;">
                    <asp:ImageButton ID="imgExcelForSentDCItems" runat="server" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="imgExcelForSentDCItems_Click" Height="25px" Width="25px" />
                </asp:Panel>
            </td>
            <td align="left" class="secondLevelHeader" width="10%">
                <asp:Label ID="Label2" runat="server" Text="Received DC Items" />
                <asp:Panel ID="Panel2" runat="server" Style="margin-left: 50px;">
                    <asp:ImageButton ID="imgExcelForReceivedDCItems" runat="server" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="imgExcelForReceivedDCItems_Click" Height="25px" Width="25px" />
                </asp:Panel>
            </td>
            <td align="left" class="secondLevelHeader" width="15%">
                    <asp:Label ID="Label3" runat="server" Text="Attaching DC Pending Items Into Mail" />
                     <asp:DropDownList ID="dropdownCustomer" CssClass="inputStyle" runat="server" DataTextField="EmployeeName" DataValueField="Email" Width="120" OnSelectedIndexChanged="dropdownCustomer_SelectedIndexChanged">
                    </asp:DropDownList>
               <asp:Panel ID="Panel3" runat="server" Style="margin-top: 3px; margin-left: 190px;">
                    <%--<asp:Button ID="btnSubmitBox" runat="server" Text="Attach" Visible="true" ToolTip="Attaching excel to mail" CssClass="buttonText" OnClick="btnSubmitBox_Click" />--%>
                </asp:Panel>
            </td>
            <td align="left" class="secondLevelHeader" width="5%">
                    <asp:Button ID="Button1" runat="server" Text="Attach" Visible="true" ToolTip="Attaching excel to mail" CssClass="buttonText" OnClick="btnSubmitBox_Click" />
            </td>
        </tr>
    </table>
    <table style="width: 900px; margin-left: 280px;">
        <tr>
            <td style="text-align: right">
                <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" Style="width: 170px;"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFromDate" Format="dd-MM-yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="text-align: right">
                <asp:Label ID="lblToDate" Style="margin-left: 10px;" runat="server" Text="To Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtToDate" Style="width: 170px; text-align: left;" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtToDate" Format="dd-MM-yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
                <asp:Label ID="lblMessage" Visible="true" Style="text-align: center; margin-left: 5px;" ForeColor="Red" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
