<%@ Page Title="View Assembly Order Processing" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true"
    Culture="en-IN" CodeBehind="ViewAssemblyOrderProcessing.aspx.cs" Inherits="VV.ViewAssemblyOrderProcessing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function CheckWeekNo() {
            if (document.getElementById('<%= txtProdOrderNo.ClientID %>').value == "") {
                alert('First Load the Grid');
                return false;
            }
        }
    </script>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="30%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View Assembly Order Processing" />
            </td>
            <%--
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
                <%--<asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif" EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
            </td>
            <td width="60%" align="right" style="padding-left: 270px;" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:Label ID="lblProdOrderNo" Text="Enter Prod Order No" runat="server"></asp:Label>
                    <asp:TextBox ID="txtProdOrderNo" runat="server" ToolTip="Enter Prod Order No" />
                    <asp:RequiredFieldValidator ID="reqval" runat="server" ControlToValidate="txtProdOrderNo" Display="Dynamic" ErrorMessage="Prod Order No is Mandatory"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click" ToolTip="Click to Search Data" CssClass="buttonText"  />
                    <asp:ImageButton ID="imgExcel" runat="server" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="btnExcel_Click" Height="25px" Width="25px" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <%--Added by Arun on 26-Dec'07.
                 Implemeted the Update Panel, so as to avoid showing the flickering, when any operations are done --%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="grdViewAssemblyPlan" DataKeyNames="GAD" ShowHeader="true" AllowSorting="false"
                            AllowPaging="true" AutoGenerateColumns="false" runat="server" EmptyDataText="No Records To Display"
                            CellPadding="3" PageSize="24" OnPageIndexChanging="grdViewAssemblyPlan_PageIndexChanging"
                            CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager"
                            RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">
                            <Columns>
                                <asp:TemplateField HeaderText="Product Serial No" ItemStyle-HorizontalAlign="left" SortExpression="ProductSerialNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductSerialNo" runat="server" Text='<%# Eval("ProductSerialNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sales Order" ItemStyle-HorizontalAlign="left" SortExpression="SalesOrder">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesOrder" runat="server" Text='<%# Eval("SalesOrder") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Position" ItemStyle-HorizontalAlign="left" SortExpression="Position">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("Position") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="QCI & REV" ItemStyle-HorizontalAlign="left" SortExpression="QCI&REV">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQCIREV" runat="server" Text='<%# Eval("QCI&REV") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SAP Code" ItemStyle-HorizontalAlign="left" SortExpression="SAPCode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSAPCode" runat="server" Text='<%# Eval("SAPCode") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Stock Code" ItemStyle-HorizontalAlign="left" SortExpression="StockCode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockCode" runat="server" Text='<%# Eval("StockCode") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tag No" ItemStyle-HorizontalAlign="left" SortExpression="TagNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTagNo" runat="server" Text='<%# Eval("TagNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Order No" ItemStyle-HorizontalAlign="left" SortExpression="CustomerOrderNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerOrderNo" runat="server" Text='<%# Eval("CustomerOrderNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Line#" ItemStyle-HorizontalAlign="left" SortExpression="LineNum">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLineNum" runat="server" Text='<%# Eval("LineNum") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GAD" ItemStyle-HorizontalAlign="left" SortExpression="GAD">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGAD" runat="server" Text='<%# Eval("GAD") %>' />
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
            </td>
        </tr>
    </table>
</asp:Content>
