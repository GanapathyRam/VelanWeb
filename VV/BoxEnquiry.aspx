<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/VV.Master" CodeBehind="BoxEnquiry.aspx.cs" Inherits="VV.BoxEnquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <div style="margin-top: 20px;">
        <asp:Label ID="lblHeaderName" runat="server" Style="font-family: Verdana; color: brown; font-weight: 200; text-align: center;" Text="Box Enquiry:"></asp:Label>
    </div>
    
    <div style="text-align: right; line-height: normal;">
        <asp:Panel ID="BulkUpdateWIP" Style="margin-top: 15px;" runat="server">
            <asp:Button ID="btnExcelExport" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Excel Export" OnClick="btnExcelExport_Click" ToolTip="Click to Export Excel" />
        </asp:Panel>
    </div>

    <div style="margin-top: 10px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
                    HeaderStyle-HorizontalAlign="Left"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    
                    <HeaderStyle CssClass="Grid_Header" />
                    <FooterStyle CssClass="Grid_Summary" />
                    <PagerStyle CssClass="Grid_Pager" />
                    <EmptyDataRowStyle CssClass="EmptyCell" />
                    <%--<RowStyle CssClass="Grid_Record" />--%>
                    <SelectedRowStyle BackColor="#FFEEC2" />
                    <%--<PagerSettings Position="TopAndBottom" />--%>
                    <RowStyle CssClass="Grid_RowRecord" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
