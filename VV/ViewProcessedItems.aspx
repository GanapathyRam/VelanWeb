<%@ Page Language="C#" Title="ViewProcessedItems" MasterPageFile="~/VV.Master" Culture="en-IN"
    AutoEventWireup="true" CodeBehind="ViewProcessedItems.aspx.cs" Inherits="VV.ViewProcessedItems" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 500px; margin-top: 0px;">
        <asp:Label ID="lblConfirm" runat="server"></asp:Label>
    </div>
    <div style="text-align: right;">
        <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
            <asp:TextBox ID="txtOrderNumber" runat="server" ToolTip="Enter Order Number to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtPos" runat="server" ToolTip="Enter Pos to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtItem" runat="server" ToolTip="Enter Item to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtItemNumber" runat="server" ToolTip="Enter Item number to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:Button ID="btnSearchBox" runat="server" Text="Search"
                ToolTip="Click to Search Data" CssClass="buttonText" Enabled="true" OnClick="btnSearchBox_Click" />
            &nbsp;<asp:Button ID="btnExport" runat="server" Width="150px" Font-Bold="true" CssClass="buttonText" Text="Export" OnClick="btnExport_Click" />
        </asp:Panel>
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" AllowPaging="true" CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnPageIndexChanging="GridView1_PageIndexChanging"
                    PagerStyle-CssClass="Grid_Pager" AllowSorting="true" OnSorting="GridView1_Sorting" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display" runat="server">

                    <HeaderStyle CssClass="Grid_Header" />
                    <FooterStyle CssClass="Grid_Summary" />
                    <PagerStyle CssClass="Grid_Pager" />
                    <EmptyDataRowStyle CssClass="EmptyCell" />
                    <RowStyle CssClass="Grid_Record" />
                    <AlternatingRowStyle CssClass="Grid_Alternate_Record" />
                    <SelectedRowStyle BackColor="#FFEEC2" />
                    <PagerSettings Position="TopAndBottom" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
