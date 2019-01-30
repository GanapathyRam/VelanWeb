<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FGOrderChange.aspx.cs" EnableEventValidation="false" Culture="en-IN"
    MasterPageFile="~/VV.Master" Inherits="VV.FGOrderChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        /*
        * Added by Arun on 19-Mar-2008
        * Function will enable the Search Button, only if a minimum of 3 characters are entered in the search text box. 
        * If given less, then it will disable the search button
        */
        <%--function ControlSearch(text) {
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
    }--%>

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

        //function editGrid(rowId) {
        //    location.href = "UpdateBaan.aspx?BadgeNo=" + rowId;
        //}

    </script>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="20%">
                <asp:Label ID="lblPageTitle" runat="server" Text="FG Order Change" />
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
                    <asp:TextBox ID="txtOrderType" runat="server" ToolTip="Enter Order Type to be Searched" />
                    <asp:TextBox ID="txtSalesOrderNo" runat="server" ToolTip="Enter Order Number to be Searched" />
                    <asp:TextBox ID="txtPos_Search" runat="server" ToolTip="Enter Pos to be Searched" />
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="true" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" width="70%" align="left" style="padding-left: 575px;" class="secondLevelHeader">
                <asp:Panel ID="Panel1" DefaultButton="btnSearchBox" runat="server">
                    <asp:Label ID="lblQtyToConvert" runat="server" Style="text-align: center;" Text="Qty To Convert"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtQtyToConvert" runat="server" ToolTip="Enter Qty To Convert Data" />
                    &nbsp;
                    <asp:Button ID="btnConvert" runat="server" Text="List To Orders" OnClick="btnConvert_Click"
                        ToolTip="Click to Convert Data" CssClass="buttonText" Enabled="true" />
                    &nbsp; &nbsp;
                     <asp:Button ID="btnConfirm" runat="server" Text="Convert FG" OnClick="btnConfirm_Click"
                         CssClass="buttonText" Enabled="true" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center; color: green; font-size: small; font-family: Verdana;">
                <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="secondLevelHeader">
                <asp:Label ID="Label1" runat="server" Text="From Order:"></asp:Label>
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
                            PageSize="100" CellPadding="3" OnPageIndexChanging="grdViewBaaNResult_PageIndexChanging"
                            CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager"
                            RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Select">
                                    <HeaderTemplate>
                                        <%--<input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />--%>
                                        <%--<asp:CheckBox ID = "chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="CheckSingleCheckbox(this)" />
                                        <%--<asp:CheckBox runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                                        <input id="hidProdOrder" value='<%# Eval("OrderNo") %>' type="hidden" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"
                                    HeaderStyle-Width="100px" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HypLnkOrderNo" NavigateUrl='<%# "UpdateProdRelease.aspx?OrderNo=" +
                                                                DataBinder.Eval(Container.DataItem,"OrderNo") + "&LineNum=" +
                                                                DataBinder.Eval(Container.DataItem,"LineNum") + "&Pos=" +
                                                                DataBinder.Eval(Container.DataItem,"Pos") %>'
                                            Enabled='<%# Eval("ItemGroup").ToString() != "" ? true:false %>'
                                            runat="server" Text='<%# Eval("OrderNo") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="left" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="left" SortExpression="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("OrderType") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="left" SortExpression="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

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
                                <%--<asp:BoundField DataField="Amount" HeaderText="Amount (INR)" SortExpression="Amount" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />--%>
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
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td colspan="3" class="secondLevelHeader">
                <asp:Label ID="lblForToGrid" runat="server" Text="To Order:"></asp:Label>
                 <asp:Panel ID="Panel2" DefaultButton="btnSearchBox" Style="text-align :right;" runat="server">
                    <asp:TextBox ID="txtOrderType1" runat="server" ToolTip="Enter Order Type to be Searched" />
                    <asp:TextBox ID="txtSalesOrderNo1" runat="server" ToolTip="Enter Order Number to be Searched" />
                    <asp:TextBox ID="txtPos1" runat="server" ToolTip="Enter Pos to be Searched" />
                    <asp:Button ID="btnSearch1" runat="server" Text="Search" OnClick="btnSearch1_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="true" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="always" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" DataKeyNames="OrderNo" ShowHeader="true" AllowSorting="false"
                            AllowPaging="true" AutoGenerateColumns="false" runat="server" EmptyDataText="No Records To Display"
                            PageSize="100" CellPadding="3" OnPageIndexChanging="GridView1_PageIndexChanging"
                            CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager"
                            RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Select">
                                    <HeaderTemplate>
                                        <%--<input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />--%>
                                        <%--<asp:CheckBox ID = "chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect1" EnableViewState="false" runat="server" onclick="CheckSingleCheckbox(this)" />
                                        <%--<asp:CheckBox runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                                        <input id="hidProdOrder" value='<%# Eval("OrderNo") %>' type="hidden" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"
                                    HeaderStyle-Width="100px" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HypLnkOrderNo" NavigateUrl='<%# "UpdateProdRelease.aspx?OrderNo=" +
                                                                DataBinder.Eval(Container.DataItem,"OrderNo") + "&LineNum=" +
                                                                DataBinder.Eval(Container.DataItem,"LineNum") + "&Pos=" +
                                                                DataBinder.Eval(Container.DataItem,"Pos") %>'
                                            Enabled='<%# Eval("ItemGroup").ToString() != "" ? true:false %>'
                                            runat="server" Text='<%# Eval("OrderNo") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="left" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="left" SortExpression="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("OrderType") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="left" SortExpression="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

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
                                <%--<asp:BoundField DataField="Amount" HeaderText="Amount (INR)" SortExpression="Amount" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />--%>
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

