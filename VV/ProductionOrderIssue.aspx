<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" Culture="en-IN" CodeBehind="ProductionOrderIssue.aspx.cs" Inherits="VV.ProductionOrderIssue" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        /*
         * Added by Arun on 19-Mar-2008
         * Function will enable the Search Button, only if a minimum of 3 characters are entered in the search text box. 
         * If given less, then it will disable the search button
        */
        function ControlSearch(text) {
            if (text.value.length > 0) {
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = false;
            }
            else {
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
        }

        function disableControl(chosenText) {
            //alert(chosenText.value);
            if (chosenText.value == '0') {
                document.getElementById("<%=txtProdOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtProdOrderNo.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else if (chosenText.value == '--Remove Grouping--') {
                document.getElementById("<%=txtProdOrderNo.ClientID%>").value = "";
            document.getElementById("<%=txtProdOrderNo.ClientID%>").disabled = false;
            document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
        }
        else {
            document.getElementById("<%=txtProdOrderNo.ClientID%>").value = "";
            document.getElementById("<%=txtProdOrderNo.ClientID%>").disabled = true;
            document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
        }
}

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

function IsCheckBox(chk) {
    return (chk.type == 'checkbox');
}

    </script>

    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="10%">
                <asp:Label ID="lblPageTitle" runat="server" Text="Prod Order Issue" />

            </td>

            <%--Added by Arun on 26-Dec'07.
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif" EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>

            <td width="80%" align="right" style="padding-left: 270px;" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Export To Excel" ToolTip="ExportForWIPDates" ImageUrl="~/Images/excel.jpg"
                        CssClass="thirdLevelHeader" OnClick="ExcelExport_Click" Height="25px" Width="25px" />
                    &nbsp;
                    <asp:Button ID="btnReverse" runat="server" CssClass="buttonText" OnClick="btnReverse_Click" Text="Store Issue" Visible="true" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
                    <asp:TextBox ID="txtProdOrderNo" runat="server" ToolTip="Enter Prod Order No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click" ToolTip="Click to Search Data" CssClass="buttonText" />
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
                        <asp:GridView ID="grdViewWIPResult" DataKeyNames="OrderNo" ShowHeader="true" AllowSorting="false" AllowPaging="true"
                            AutoGenerateColumns="false" runat="server" EmptyDataText="No Records To Display"
                            CellPadding="3" PageSize="18" OnPageIndexChanging="grdViewWIPResult_PageIndexChanging"
                            CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager"
                            RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" />
                                        <input id="hidOrderNo" value='<%# Eval("OrderNo") %>' type="hidden" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="left" ItemStyle-Width="100px" HeaderStyle-Width="100px" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HypLnkOrderNo" NavigateUrl='<%# "UpdateWIPToFG.aspx?OrderNo=" +
                                                                DataBinder.Eval(Container.DataItem,"OrderNo") + "&LineNum=" +
                                                                DataBinder.Eval(Container.DataItem,"LineNum") + "&Pos=" +
                                                                DataBinder.Eval(Container.DataItem,"Pos") + "&SerialNo=" +
                                                                DataBinder.Eval(Container.DataItem,"SerialNo") + "&ProdOrderNo=" +
                                                                DataBinder.Eval(Container.DataItem,"ProdOrderNo") %>' 
                                            Enabled='<%# Eval("OrderType").ToString() == "ICS" ? true:false %>' runat="server" Text='<%# Eval("OrderNo") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                  </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="left" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%-- <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="left" SortExpression="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("OrderType") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%-- <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="left" SortExpression="CustomerName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustName" runat="server" Text='<%# Eval("CustomerName") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Line #" ItemStyle-HorizontalAlign="left" SortExpression="LineNum">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLineNum" runat="server" Text='<%# Eval("LineNum") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="left" SortExpression="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="left" SortExpression="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="200px" />
                            <HeaderStyle Width="200px" />--%>
                                </asp:TemplateField>
                                <%--   <asp:TemplateField HeaderText="Sales Order Revision" ItemStyle-HorizontalAlign="left" SortExpression="SalesOrderRevision">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesOrderRevision" runat="server" Text='<%# Eval("SalesOrderRevision") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>
                                <%--<asp:BoundField HeaderText="Revision Date" ItemStyle-HorizontalAlign="left" DataField="RevisionDate" SortExpression="RevisionDate" DataFormatString="{0:dd-MM-yyyy}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                                </asp:BoundField>--%>
                                <%--  <asp:TemplateField HeaderText="Area" ItemStyle-HorizontalAlign="left" SortExpression="Area">
                                    <ItemTemplate>
                                        <asp:Label ID="lblArea" runat="server" Text='<%# Eval("Area") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>
                                <%--<asp:BoundField HeaderText="Order Date" ItemStyle-HorizontalAlign="left" DataField="OrderDate" SortExpression="OrderDate" DataFormatString="{0:dd-MM-yyyy}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                                </asp:BoundField>--%>
                                <asp:BoundField HeaderText="Original Prom Date" ItemStyle-HorizontalAlign="left" DataField="OriginalPromDate" SortExpression="OriginalPromDate" DataFormatString="{0:dd-MM-yyyy}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />--%>
                                </asp:BoundField>
                                <%-- <asp:BoundField HeaderText="Planned Del Date" ItemStyle-HorizontalAlign="left" DataField="PlannedDelDate" SortExpression="PlannedDelDate" DataFormatString="{0:dd-MM-yyyy}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                                </asp:BoundField>--%>

                                <%--<asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="left" SortExpression="OrderQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="Balance Qty" ItemStyle-HorizontalAlign="left" SortExpression="BalanceQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalanceQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>
                                <%--<asp:BoundField DataField="Amount" HeaderText="Amount (INR)" SortExpression="Amount" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />--%>
                                <%-- <asp:TemplateField HeaderText="Amount (INR)"  ItemStyle-HorizontalAlign="Right" SortExpression="Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount","{0:c0}") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
<%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="Invoiced Qty"  ItemStyle-HorizontalAlign="left" SortExpression="InvoicedQty">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoicedQty" runat="server" Text='<%# Eval("InvoicedQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />--%>
                                <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                <%--</asp:TemplateField>
                        <asp:TemplateField HeaderText="FG Qty"  ItemStyle-HorizontalAlign="left" SortExpression="FGQty">
                            <ItemTemplate>
                                <asp:Label ID="lblFGQty" runat="server" Text='<%# Eval("FGQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />--%>
                                <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                <%-- </asp:TemplateField>
                        <asp:TemplateField HeaderText="WIP Qty"  ItemStyle-HorizontalAlign="left" SortExpression="WIPQty">
                            <ItemTemplate>
                                <asp:Label ID="lblWIPQty" runat="server" Text='<%# Eval("WIPQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />--%>
                                <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                <%--</asp:TemplateField>
                        <asp:TemplateField HeaderText="To Release Qty"  ItemStyle-HorizontalAlign="left" SortExpression="ToReleaseQty">
                            <ItemTemplate>
                                <asp:Label ID="lblToReleaseQty" runat="server" Text='<%# Eval("ToReleaseQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />--%>
                                <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                <%--</asp:TemplateField>--%>
                                <%-- <asp:TemplateField HeaderText="PO Release Qty" ItemStyle-HorizontalAlign="left" SortExpression="ProdRelQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdRelQty" runat="server" Text='<%# Eval("ProdRelQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="PO Bal Qty" ItemStyle-HorizontalAlign="left" SortExpression="ProdBalanceQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdBalanceQty" runat="server" Text='<%# Eval("ProdBalanceQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>--%>
                                <%--<asp:BoundField HeaderText="Release Date" ItemStyle-HorizontalAlign="left" DataField="RelDate" SortExpression="RelDate" DataFormatString="{0:dd-MM-yyyy}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                                </asp:BoundField>--%>
                                <%--<asp:BoundField HeaderText="Prod Completion Date" ItemStyle-HorizontalAlign="left" DataField="ProdCompletionDate" SortExpression="ProdCompletionDate" DataFormatString="{0:dd-MM-yyyy}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                                </asp:BoundField>--%>
                                <%--<asp:TemplateField HeaderText="Prod Remarks" ItemStyle-HorizontalAlign="left" SortExpression="ProdRemarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdRemarks" runat="server" Text='<%# Eval("ProdRemarks") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>
                                <%-- <asp:TemplateField HeaderText="Serial No" ItemStyle-HorizontalAlign="left" SortExpression="SerialNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Prod Ord No" ItemStyle-HorizontalAlign="left" SortExpression="ProdOrderNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdOrderNo" runat="server" Text='<%# Eval("ProdOrderNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created On" ItemStyle-HorizontalAlign="left" SortExpression="CreatedOn">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedOn" runat="server" Text='<%# Eval("CreatedOn") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PO Bal Qty" ItemStyle-HorizontalAlign="left" SortExpression="ProdBalanceQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdBalanceQty" runat="server" Text='<%# Eval("ProdBalanceQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="PO Release Qty" ItemStyle-HorizontalAlign="left" SortExpression="ProdRelQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdRelQty" runat="server" Text='<%# Eval("ProdRelQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>--%>
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
