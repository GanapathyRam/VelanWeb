<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Culture="en-IN" MasterPageFile="~/VV.Master"
    CodeBehind="UtilityEnquiriesReports.aspx.cs" Inherits="VV.UtilityEnquiriesReports" %>


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
    <div style="text-align: left; background-color: #eceded; padding:5px; line-height: normal;">
        <asp:Panel ID="BulkUpdatePO1" runat="server">
            <asp:RadioButtonList ID="RadioButtonList1" Style="margin-left: 500px;" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server">
                <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
        </asp:Panel>
    </div>
    <div style="text-align: right; margin-top: 10px; line-height: normal;">
        <asp:Panel ID="BulkUpdateWIP" runat="server">
            <asp:Label ID="lblRequestedBy" runat="server" Style="font-family: Verdana; text-align: center;" Text="RequestedBy"></asp:Label>
            <asp:TextBox ID="txtRequestedBy" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Requested By to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;<asp:Label ID="lblItemCodeFrom" Style="font-family: Verdana; text-align: center;" runat="server" Text="ItemCodeFrom"></asp:Label>
            <asp:TextBox ID="txtItemCodeFrom" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Item Code From to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;
            <asp:Label ID="lblItemCodeTo" Style="font-family: Verdana; text-align: center;" runat="server" Text="ItemCodeTo"></asp:Label>
            <asp:TextBox ID="txtItemCodeTo" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Item Code To to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;
            <asp:Button ID="btnSearchBox" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Search" OnClick="btnSearchBox_Click" ToolTip="Click to Search Data" />
        </asp:Panel>
        <div>
            <asp:Panel ID="SearchPanel" runat="server" Style="margin-left: 50px;">
                <asp:ImageButton ID="imgExcelForPending" runat="server" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="imgExcelForPending_Click" Height="25px" Width="25px" />
            </asp:Panel>
        </div>
    </div>
    <div style="margin-top: 10px;">
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
                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left" HeaderText="Select">
                            <HeaderTemplate>
                                <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                                <input id="hidId" value='<%# Eval("Id") %>' type="hidden" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Requested By" SortExpression="RequestedBy">
                            <ItemTemplate>
                                <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("EmployeeName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Requested Date">
                            <ItemTemplate>
                                <asp:Label ID="lblRequestDate" runat="server" Text='<%# Bind("RequestDate", "{0:dd-MM-yyyy}") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Itemcode From" SortExpression="ItemcodeFrom">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblItemcodeFrom" runat="server" Text='<%# Eval("ItemcodeFrom") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Itemcode To" SortExpression="ItemcodeTo">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblItemcodeTo" Text='<%# Eval("ItemcodeTo") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="OrderNo">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblOrderNo" Text='<%# Eval("OrderNo") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Pos">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPos" Text='<%# Eval("Pos") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Request Remarks">
                            <ItemTemplate>
                                <asp:Label ID="lblRequestRemarks" runat="server" Text='<%# Eval("RequestRemarks") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QCBy">
                            <ItemTemplate>
                                <asp:Label ID="lblQCBy" runat="server" Text='<%# Eval("QCBy") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QCOn">
                            <ItemTemplate>
                                <asp:Label ID="lblQCOn" runat="server" Text='<%# Bind("QCOn", "{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QCDisposition">
                            <ItemTemplate>
                                <asp:Label ID="lblQCDisposition" runat="server" Text='<%# Eval("QCDisposition") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                          <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QCRemarks">
                            <ItemTemplate>
                                <asp:Label ID="lblQcRemarks" runat="server" Text='<%# Eval("QCRemarks") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="StoresOn">
                            <ItemTemplate>
                                <asp:Label ID="lblStoresOn" runat="server" Text='<%# Bind("StoresOn", "{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="StoresDisposition">
                            <ItemTemplate>
                                <asp:Label ID="lblStoresDisposition" runat="server" Text='<%# Eval("StoresDisposition") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                          <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="StoresRemarks">
                            <ItemTemplate>
                                <asp:Label ID="lblStoresRemarks" runat="server" Text='<%# Eval("StoresRemarks") %>'></asp:Label>
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
