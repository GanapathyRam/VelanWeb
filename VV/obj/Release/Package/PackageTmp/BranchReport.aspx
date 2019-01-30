<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="BranchReport.aspx.cs"
    EnableEventValidation="false" Culture="en-IN" Inherits="VV.BranchReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="height: 100%; margin-top: 20px;" width="100%" cellpadding="0" cellspacing="0">
        <tr style="height: 40px;">
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="Label3" runat="server" Text="Report Type " />
            </td>
            <td colspan="3" style="padding-left: 20px;">
                <asp:DropDownList ID="ddlReportTypes" CssClass="inputStyle" runat="server" Width="170" DataTextField="ReportName" DataValueField="ReportId" AutoPostBack="true" OnSelectedIndexChanged="ddlReportTypes_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " />
            </td>
            <td style="padding-left: 20px;">
                <asp:DropDownList ID="ddlCustomerName" CssClass="inputStyle" AutoPostBack="true" DataTextField="CustomerName" DataValueField="CustomerName" runat="server" Width="170" OnSelectedIndexChanged="ddlCustomerName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="padding-left: 20px;">
                <asp:Label ID="lblOrderNo" runat="server" Text="Order No " />
            </td>
            <td style="padding-right: 180px;">
                <asp:DropDownList ID="ddlOrderNo" CssClass="inputStyle" runat="server" DataTextField="OrderNo" DataValueField="OrderNo" AutoPostBack="true" Width="170" OnSelectedIndexChanged="ddlOrderNo_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
            </td>
            <td style="padding-left: 20px;">              
            </td>
            <td style="padding-left: 20px;">
            </td>
             <td style="padding-right: 180px;">
                <asp:TextBox ID="txtOrderNo" runat="server"></asp:TextBox>
                 &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" Width="91px" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr style="height: 40px;">
            <td></td>
            <td colspan="2" style="padding-left: 20px; margin-top: 10px;">
                <asp:Button ID="btnGenerateExcel" runat="server" Text="Generate Excel" OnClick="btnGenerateExcel_Click" />
            </td>
        </tr>
    </table>
    <div style="margin-top: 20px;">
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                    PagerStyle-CssClass="Grid_Pager" PageSize="5000" AllowSorting="true" OnSorting="GridView1_Sorting" RowStyle-CssClass="Grid_Record"
                    AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                         <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center" SortExpression="OrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="Center" SortExpression="Pos">
                            <ItemTemplate>
                                <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="LineNum" ItemStyle-HorizontalAlign="Center" SortExpression="LineNum">
                            <ItemTemplate>
                                <asp:Label ID="lbllinenum" runat="server" Text='<%# Eval("LineNum") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="Center" SortExpression="CustomerName">
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                       
                          <asp:TemplateField HeaderText="CustomerOrderNo" ItemStyle-HorizontalAlign="Center" SortExpression="CustomerOrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerOrderNo" runat="server" Text='<%# Eval("CustomerOrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        

                        <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Center" SortExpression="Item">
                            <ItemTemplate>
                                <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" SortExpression="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Original Prom Date" ItemStyle-HorizontalAlign="Center" DataField="OriginalPromDate" SortExpression="OriginalPromDate" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>

                        <%-- <asp:TemplateField HeaderText="OriginalPromDate" ItemStyle-HorizontalAlign="Center" SortExpression="OriginalPromDate">
                            <ItemTemplate>
                                <asp:Label ID="lblOriginalPromDate" runat="server" Text='<%# Eval("OriginalPromDate") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="Center" SortExpression="OrderQty">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance Qty" ItemStyle-HorizontalAlign="Center" SortExpression="BalanceQty">
                            <ItemTemplate>
                                <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalanceQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="Amount" HeaderText="Amount (INR)" SortExpression="Amount" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />--%>
                        <asp:TemplateField HeaderText="Invoiced Qty" ItemStyle-HorizontalAlign="Center" SortExpression="InvoicedQty">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoicedQty" runat="server" Text='<%# Eval("InvoicedQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FG Qty" ItemStyle-HorizontalAlign="Center" SortExpression="FGQty">
                            <ItemTemplate>
                                <asp:Label ID="lblFGQty" runat="server" Text='<%# Eval("FGQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="UnderPick Qty" ItemStyle-HorizontalAlign="Center" SortExpression="UnderPickQty">
                            <ItemTemplate>
                                <asp:Label ID="lblUnderPickQty" runat="server" Text='<%# Eval("UnderPickQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To Release Qty" ItemStyle-HorizontalAlign="Center" SortExpression="ToReleaseQty">
                            <ItemTemplate>
                                <asp:Label ID="lblToReleaseQty" runat="server" Text='<%# Eval("ToReleaseQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Material Receipt" ItemStyle-HorizontalAlign="Center" SortExpression="MaterialReceipt">
                            <ItemTemplate>
                                <asp:Label ID="lblMaterialReceipt" runat="server" Text='<%# Eval("MaterialReceipt") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Machining Completion" ItemStyle-HorizontalAlign="Center" SortExpression="MachiningCompletion">
                            <ItemTemplate>
                                <asp:Label ID="lblMachiningCompletion" runat="server" Text='<%# Eval("MachiningCompletion") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="AssemblyRelease" ItemStyle-HorizontalAlign="Center" SortExpression="AssemblyRelease">
                            <ItemTemplate>
                                <asp:Label ID="lblAssemblyRelease" runat="server" Text='<%# Eval("AssemblyRelease") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TPI_1" ItemStyle-HorizontalAlign="Center" SortExpression="TPI_1">
                            <ItemTemplate>
                                <asp:Label ID="lblTPI_1" runat="server" Text='<%# Eval("TPI_1") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TPI_2" ItemStyle-HorizontalAlign="Center" SortExpression="TPI_2">
                            <ItemTemplate>
                                <asp:Label ID="lblTPI_2" runat="server" Text='<%# Eval("TPI_2") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" SortExpression="Remarks">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>


                    </Columns>
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

        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" OnPageIndexChanging="GridView2_PageIndexChanging"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                    PagerStyle-CssClass="Grid_Pager" PageSize="5000" AllowSorting="true" OnSorting="GridView2_Sorting" RowStyle-CssClass="Grid_Record"
                    AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="Center" SortExpression="CustomerName">
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center" SortExpression="OrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Original Prom Date" ItemStyle-HorizontalAlign="Center" DataField="OriginalPromDate" SortExpression="OriginalPromDate" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>

                        <%-- <asp:TemplateField HeaderText="OriginalPromDate" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd-MM-yyyy}" SortExpression="OriginalPromDate">
                            <ItemTemplate>
                                <asp:Label ID="lblOriginalPromDate" runat="server" Text='<%# Eval("OriginalPromDate") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="Center" SortExpression="TotalOrderQty">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("TotalOrderQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Balance Qty" ItemStyle-HorizontalAlign="Center" SortExpression="TotalBalanceQty">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalBalanceQty" runat="server" Text='<%# Eval("TotalBalanceQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Invoiced Qty" ItemStyle-HorizontalAlign="Center" SortExpression="TotalInvoicedQty">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalInvoicedQty" runat="server" Text='<%# Eval("TotalInvoicedQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total FG Qty" ItemStyle-HorizontalAlign="Center" SortExpression="TotalFGQty">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalFGQty" runat="server" Text='<%# Eval("TotalFGQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total WIP Qty" ItemStyle-HorizontalAlign="Center" SortExpression="TotalWIPQty">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalWIPQty" runat="server" Text='<%# Eval("TotalWIPQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Underpick Qty" ItemStyle-HorizontalAlign="Center" SortExpression="TotalUnderpickQty">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalUnderpickQty" runat="server" Text='<%# Eval("TotalUnderpickQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total ToRelease Qty" ItemStyle-HorizontalAlign="Center" SortExpression="TotalToReleaseQty">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalToReleaseQty" runat="server" Text='<%# Eval("TotalToReleaseQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>


                    </Columns>
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
