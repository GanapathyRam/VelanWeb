<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesOrderLineItemDeletion.aspx.cs"
    MasterPageFile="~/VV.Master" EnableEventValidation="false" Culture="en-IN" Inherits="VV.SalesOrderLineItemDeletion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function Check(parentChk) {

            var elements = document.getElementsByTagName("INPUT");
            for (i = 0; i < elements.length; i++) {
                if (parentChk.checked == true) {
                    if (IsCheckBox(elements[i])) {
                        elements[i].checked = true;
                    }

                }
                else {
                    if (IsCheckBox(elements[i])) {
                        elements[i].checked = false;
                    }
                }
            }
        }

        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }

        function IsCheckBox(chk) {
            return (chk.type == 'checkbox');
        }
    </script>
    <link href="CSS/Main.css" rel="stylesheet" />
    <div style="text-align: right; line-height: normal;">
        <asp:Panel ID="BulkUpdateWIP" runat="server">
            <asp:Label ID="lblOrderNo" runat="server" Style="font-family: Verdana; text-align: center;" Text="Order Number"></asp:Label>
            <asp:TextBox ID="txtOrderNo" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Order Number to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;<asp:Label ID="lblPos" Style="font-family: Verdana; text-align: center;" runat="server" Text="Pos"></asp:Label>
            <asp:TextBox ID="txtPos" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Position to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;
            <asp:Button ID="btnSearchBox" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Search" OnClick="btnSearchBox_Click" ToolTip="Click to Search Data" />
            &nbsp;
            <asp:Button ID="btnUpdate" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Confirm" OnClick="btnUpdate_Click" ToolTip="Click to Update Data" />
        </asp:Panel>
    </div>
    <div style="margin-top:10px;">
        <asp:Label ID="lblMessage" Style="margin-left: 900px; font-size: small; font-family: Verdana; text-align: right;" CssClass="lblSuccessMessage" Visible="false" runat="server"></asp:Label>
    </div>
    <div style="margin-top: 30px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="24"
                    OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Center"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnRowDataBound="GridView1_RowDataBound"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Select">
                            <HeaderTemplate>
                                <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                                <%--<asp:CheckBox ID = "chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                                <%--onclick="CheckSingleCheckbox(this)"--%>
                                <%--<asp:CheckBox runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                                <input id="hidProdOrder" value='<%# Eval("OrderNo") %>' type="hidden" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Number" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblQrderQty" runat="server" Text='<%# Eval("OrderQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance Qty" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalanceQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Invoiced Qty" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoicedQty" runat="server" Text='<%# Eval("InvoicedQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="FG Qty" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblFGQty" runat="server" Text='<%# Eval("FGQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WIP Qty" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblWipQty" runat="server" Text='<%# Eval("WIPQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="UnderPick Qty" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblUnderPickQty" runat="server" Text='<%# Eval("UnderPickQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ToRelease Qty" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblReleaseQty" runat="server" Text='<%# Eval("ToReleaseQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                    </Columns>
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
