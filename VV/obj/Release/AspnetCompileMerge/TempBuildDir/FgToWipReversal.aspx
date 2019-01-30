<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FgToWipReversal.aspx.cs" MasterPageFile="~/VV.Master" Culture="en-IN" Inherits="VV.FgToWipReversal" %>

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
    //function editGrid(rowId) {
    //    location.href = "UpdateBaan.aspx?BadgeNo=" + rowId;
    //}

    </script>

    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">

        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblOrderNumber" Text="Order Number" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px; height: 40px;">
                <asp:TextBox ID="txtOrderNumber" Height="15px" Style="height: 20px;" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOrderNumber" runat="server" ErrorMessage="Please Enter Order No to be reduced."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblPosition" Text="Position" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px; height: 40px;">
                <asp:TextBox ID="txtPosition" Height="15px" Style="height: 20px;" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td>
                <%--<asp:Label ID="Label2" Text="Please Enter Position to be reduced." Visible="false" ForeColor="Red" runat="server"></asp:Label>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPosition" runat="server" ErrorMessage="Please Enter Position to be reduced."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div style="padding-left: 20px; margin-top: 10px;">
                    <asp:Button ID="btn_Search" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Search" OnClick="btn_Search_Click" />
                    &nbsp;
        <asp:Button ID="btnClear" runat="server" Width="90px" Style="font-style: normal; font-weight: 10px;" Height="30px" Text="Clear" Visible="false" OnClick="btnClear_Click" />
                </div>
            </td>
            <td style="text-align: left; font-size: medium; font-family: Verdana;">
                <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Style="margin-left:10px;" ForeColor="Green" Font-Size="Medium"  Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <div style="text-align: right; line-height: normal;">
        <asp:Panel ID="BulkUpdateWIP" runat="server">
            <asp:Label ID="lblOrderNo" runat="server" Style="font-family: Verdana; text-align: center;" Visible="false" Text="Prod Order No"></asp:Label>
            <asp:TextBox ID="txtProdOrderNo" runat="server" Height="15px" Style="height: 20px;" Visible="false" CssClass="textBox" ToolTip="Enter Order Number to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;<asp:Label ID="lblPos" Style="font-family: Verdana; text-align: center;" runat="server" Visible="false" Text="Sales Order No"></asp:Label>
            <asp:TextBox ID="txtSalesOrderNo" runat="server" Visible="false" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Position to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;
            <asp:Button ID="btnSearchBox" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Visible="false" Text="Search" OnClick="btnSearchBox_Click" ToolTip="Click to Search Data" />
            &nbsp;
            <asp:Button ID="btnUpdate" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Reverse" OnClick="btnUpdate_Click" ToolTip="Click to Search Data" />
        </asp:Panel>
    </div>
    <div style="margin-top: 10px;">
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
                        <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-Width="100px" SortExpression="OrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" SortExpression="Type">
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
                        <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="Center" SortExpression="Pos">
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
                        <asp:TemplateField HeaderText="Prod Order No" ItemStyle-HorizontalAlign="Center" SortExpression="ProdOrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblProdOrderNo" runat="server" Text='<%# Eval("ProdOrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                            <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Serial No" ItemStyle-HorizontalAlign="Center" SortExpression="SerialNo">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                            <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prod Release Qty" ItemStyle-HorizontalAlign="Center" SortExpression="ProdReleaseQty">
                            <ItemTemplate>
                                <asp:Label ID="lblProdReleaseQty" runat="server" Text='<%# Eval("ProdReleaseQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                            <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Balance Qty" ItemStyle-HorizontalAlign="Center" SortExpression="BalanceQty">
                            <ItemTemplate>
                                <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalanceQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                            <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="FG Qty" ItemStyle-HorizontalAlign="Center" SortExpression="FGQty">
                            <ItemTemplate>
                                <asp:Label ID="lblFGQty" runat="server" Text='<%# Eval("FGQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                            <%--                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
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
