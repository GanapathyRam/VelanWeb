<%@ Page Title="View Prod Release" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="ViewProdRelease.aspx.cs" Inherits="VV.ViewProdRelease" %>

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
                document.getElementById("<%=txtSalesOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtSalesOrderNo.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else if (chosenText.value == '--Remove Grouping--') {
                document.getElementById("<%=txtSalesOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtSalesOrderNo.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else {
                document.getElementById("<%=txtSalesOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtSalesOrderNo.ClientID%>").disabled = true;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
        }

        //function editGrid(rowId) {
        //    location.href = "UpdateBaan.aspx?BadgeNo=" + rowId;
        //}

    </script>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="20%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View BaaN Items" />
            </td>
            <%--Added by Arun on 26-Dec'07.
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif"
                            EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td width="70%" align="left" style="padding-left: 160px;" class="secondLevelHeader">
                <%--Added by Arun to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:TextBox ID="txtOrderType" runat="server" ToolTip="Enter Order Type to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:TextBox ID="txtSalesOrderNo" runat="server" ToolTip="Enter Order Number to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:TextBox ID="txtPos_Search" runat="server" ToolTip="Enter Pos to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <%--Added by Arun.
                 Implemeted the Update Panel, so as to avoid showing the flickering, when any operations are done --%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="grdViewBaaNResult" DataKeyNames="OrderNo" ShowHeader="true" AllowSorting="false"
                            AllowPaging="true" AutoGenerateColumns="false" runat="server" EmptyDataText="No Records To Display"
                            PageSize="23" CellPadding="3" OnPageIndexChanging="grdViewBaaNResult_PageIndexChanging"
                            CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager"
                            RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">
                            <Columns>
                                <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"
                                    HeaderStyle-Width="100px" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HypLnkOrderNo" NavigateUrl='<%# "UpdateProdRelease.aspx?OrderNo=" +
                                                                DataBinder.Eval(Container.DataItem,"OrderNo") + "&LineNum=" +
                                                                DataBinder.Eval(Container.DataItem,"LineNum") + "&Pos=" +
                                                                DataBinder.Eval(Container.DataItem,"Pos") %>' Enabled='<%# Eval("ItemGroup").ToString() != "" ? true:false %>'
                                            runat="server" Text='<%# Eval("OrderNo") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="left" SortExpression="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("OrderType") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="left" SortExpression="CustomerName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustName" runat="server" Text='<%# Eval("CustomerName") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Line #" ItemStyle-HorizontalAlign="left" SortExpression="LineNum">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLineNum" runat="server" Text='<%# Eval("LineNum") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="left" SortExpression="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="left" SortExpression="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sales Order Revision" ItemStyle-HorizontalAlign="center"
                                    SortExpression="SalesOrderRevision">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesOrderRevision" runat="server" Text='<%# Eval("SalesOrderRevision") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Group Mapping" ItemStyle-HorizontalAlign="left"
                                    SortExpression="ItemGroup">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemGroup" runat="server" Text='<%# Eval("ItemGroup") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Revision Date" ItemStyle-HorizontalAlign="left" DataField="RevisionDate"
                                    SortExpression="RevisionDate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Area" ItemStyle-HorizontalAlign="left" SortExpression="Area">
                                    <ItemTemplate>
                                        <asp:Label ID="lblArea" runat="server" Text='<%# Eval("Area") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Order Date" ItemStyle-HorizontalAlign="left" DataField="OrderDate"
                                    SortExpression="OrderDate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Original Prom Date" ItemStyle-HorizontalAlign="left"
                                    DataField="OriginalPromDate" SortExpression="OriginalPromDate" DataFormatString="{0:dd-MM-yyyy}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Planned Del Date" ItemStyle-HorizontalAlign="left" DataField="PlannedDelDate"
                                    SortExpression="PlannedDelDate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="left" SortExpression="OrderQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Balance Qty" ItemStyle-HorizontalAlign="left" SortExpression="BalanceQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalanceQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Amount" HeaderText="Amount (INR)" SortExpression="Amount" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />
                                <%--<asp:TemplateField HeaderText="Amount (INR)" ItemStyle-HorizontalAlign="Right" SortExpression="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount","{0:c0}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Invoiced Qty" ItemStyle-HorizontalAlign="left" SortExpression="InvoicedQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoicedQty" runat="server" Text='<%# Eval("InvoicedQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FG Qty" ItemStyle-HorizontalAlign="left" SortExpression="FGQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFGQty" runat="server" Text='<%# Eval("FGQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WIP Qty" ItemStyle-HorizontalAlign="left" SortExpression="WIPQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWIPQty" runat="server" Text='<%# Eval("WIPQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="UnderPick Qty" ItemStyle-HorizontalAlign="left" SortExpression="UnderPickQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnderPickQty" runat="server" Text='<%# Eval("UnderPickQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To Release Qty" ItemStyle-HorizontalAlign="left" SortExpression="ToReleaseQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblToReleaseQty" runat="server" Text='<%# Eval("ToReleaseQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Release Date" ItemStyle-HorizontalAlign="left" DataField="RelDate"
                                    SortExpression="RelDate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Prod Completion Date" ItemStyle-HorizontalAlign="left"
                                    DataField="ProdCompletionDate" SortExpression="ProdCompletionDate" DataFormatString="{0:dd-MM-yyyy}"
                                    HtmlEncode="False">
                                    <ItemStyle Wrap="false" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Prod Remarks" ItemStyle-HorizontalAlign="left" SortExpression="ProdRemarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdRemarks" runat="server" Text='<%# Eval("ProdRemarks") %>' />
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
