<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="PatrolAnalysisDateSet.aspx.cs" Inherits="VV.AnalysisDateSet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="CSS/Main.css" rel="stylesheet" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblFromDate" Text="From Date" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtFromDate" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFromDate" Format="dd-MM-yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="margin-left: 100px; text-align: right; font-family: Verdana;">
                <asp:Label ID="lblToDate" Text="To Date" runat="server"></asp:Label></td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtToDate" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtToDate" Format="dd-MM-yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div style="padding-left: 125px; margin-top: 10px;">
                    <asp:Button ID="btnSubmit" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Submit" OnClick="btnSubmit_Click" />
                    &nbsp;
                </div>
            </td>
            <td style="text-align: left; font-size: medium; font-family: Verdana;">
                <div>
                    <asp:Panel ID="SearchPanel" style="margin-top:13px;" runat="server">
                        <asp:ImageButton ID="imgExcelForPending" runat="server" Visible="false" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="imgExcelForPending_Click" Height="25px" Width="25px" />
                    </asp:Panel>
                </div>
            </td>
        </tr>

    </table>

    <div style="margin-top: 30px;">
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <div style="width: 600px; margin-left: auto; margin-right: auto;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
                        DataKeyNames="LocationName" AllowPaging="true" PageSize="24"
                        OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Left"
                        CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                        RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
