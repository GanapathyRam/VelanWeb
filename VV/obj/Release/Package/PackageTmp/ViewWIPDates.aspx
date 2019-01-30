<%@ Page Title="View WIP Dates" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" Culture="en-IN" CodeBehind="ViewWIPDates.aspx.cs" Inherits="VV.ViewWIPDates"
    EnableEventValidation="false" %>

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

        function IsCheckBox(chk) {
            return (chk.type == 'checkbox');
        }
    </script>
    <%--<div style="font: 14px Verdana">
        <div style="margin-left: 500px; margin-top: 10px;">
            <asp:Label ID="lblConfirm" Visible="false" runat="server"></asp:Label>
        </div>
    </div>--%>
    <div style="text-align: center; background-color: #D99694; line-height: normal;">
        <asp:RadioButtonList ID="RadioButtonListForWIP" OnSelectedIndexChanged="RadioButtonListForWIP_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server" AutoPostBack="True">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>Blank</asp:ListItem>
            <asp:ListItem>Past Dates</asp:ListItem>
            <asp:ListItem>Current Month</asp:ListItem>
            <asp:ListItem>Future Dates</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Panel ID="pnlA" runat="server" Style="display: inline;">
            <asp:Label ID="Label1" runat="server" Text="Export WIP Data:" Style="text-align: center;" Font-Bold="True"></asp:Label>
            <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Export To Excel" ToolTip="ExportForWIPDates" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" OnClick="ExcelExport_Click" Height="25px" Width="25px" />
        </asp:Panel>
        <asp:Panel ID="pnlB" runat="server" Style="display: inline;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Label2" runat="server" Text="Export WIP History:" Style="text-align: center;" Font-Bold="True"></asp:Label>
            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="Export To Excel" ToolTip="ExportForWIPDatesHistory" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" Height="25px" Width="25px" OnClick="ImageButton3_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlC" runat="server" Style="display: inline;">
            <asp:Label ID="Label3" runat="server" Text="Export WIP Data of Selection:" Style="text-align: center;" Font-Bold="True"></asp:Label>
            <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Export To Excel" ToolTip="ExportForWIPDates" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" OnClick="ImageButton1_Click" Height="25px" Width="25px" />
        </asp:Panel>
     <%--   <asp:ImageButton ID="ExcelExport" runat="server" AlternateText="Export To Excel" ToolTip="ExportForWIPDates" Style="height: 25px; width: 25px; border-width: 0px; margin-top: 0px; margin-left: 1100px;" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" OnClick="ExcelExport_Click" Height="25px" Width="25px" />
        <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Export To Excel" ToolTip="ExportForWIPHistory" Style="height: 25px; width: 25px; border-width: 0px; margin-top: 0px; margin-left: 1200px;" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" OnClick="ExcelExport_Click" Height="25px" Width="25px" />--%>
        <%-- <asp:Panel ID="BulkUpdateWIP" runat="server">
            <asp:TextBox ID="txtProdOrder" runat="server" Width="70px" ToolTip="Enter Prod Order Number to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtItemNumber" runat="server" Width="120px" ToolTip="Enter Item Number to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtBuyers" runat="server" ToolTip="Enter Buyer Name to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtSupplierName" runat="server" ToolTip="Enter Supplier Name to be Searched" onKeyUp="ControlSearch(this)" />
            
            <asp:Button ID="btnSearchBox" runat="server" Text="Search"
                ToolTip="Click to Search Data" CssClass="buttonText" Enabled="true" OnClick="btnSearchBox_Click" />

            &nbsp;&nbsp;

            <asp:TextBox ID="txtBuyer" ToolTip="Please enter Buyer" Width="125px" runat="server" Style="margin-top: 10px"></asp:TextBox>
            <asp:TextBox ID="txtWIPUpdate" ToolTip="Please enter a valid date dd-MM-yyyy" Width="125px" runat="server" Style="margin-left: 0px"></asp:TextBox>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtWIPUpdate" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                ErrorMessage="Invalid date format." ValidationGroup="Group1" />
            <asp:TextBox ID="txtRemarks" ToolTip="Please enter Remarks" Width="150px" runat="server" Style="margin-left: 0px"></asp:TextBox>

            <input type="button" id="btnWIPBulkUpdate" class="buttonText" validationgroup="Group1" value="Update" style="width: 90px; height: 22px;" runat="server" onserverclick="btnWIPBulkUpdate_ServerClick" />

        </asp:Panel>--%>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false"
                OnRowCancelingEdit="GridView2_RowCancelingEdit" AllowPaging="true" OnPageIndexChanging="GridView2_PageIndexChanging"
                OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                PagerStyle-CssClass="Grid_Pager" PageSize="5000"  AllowSorting="true" OnSorting="GridView2_Sorting" RowStyle-CssClass="Grid_Record" 
                AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                CellPadding="3">
                <Columns>
                    <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Center" HeaderText="Select">
                        <HeaderTemplate>
                            <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                            <%--<asp:CheckBox ID = "chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                            <%--<asp:CheckBox runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                            <input id="hidProdOrder" value='<%# Eval("ProdOrder") %>' type="hidden" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Prod Order No" SortExpression="ProdOrder">
                        <ItemTemplate>
                            <asp:Label ID="lblProdOrderNo" runat="server" Text='<%# Eval("ProdOrder") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Rel.Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDelDate" runat="server" Text='<%# Eval("DelDate") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Item Number" SortExpression="ItemNumber">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblItemNumber" runat="server" Text='<%# Eval("ItemNumber") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Description" SortExpression="Description">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDescription" Text='<%# Eval("Description") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" HeaderText="Project">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblProject" Text='<%# Eval("Project") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="70px" />
                                    <HeaderStyle Width="70px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Qty Ord">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblQtyOrd" Text='<%# Eval("QtyOrd") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="60px" />
                                    <HeaderStyle Width="60px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Qty Dlv">
                        <ItemTemplate>
                            <asp:Label ID="lblQtyDlv" runat="server" Text='<%# Eval("QtyDlv") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Bal Qty">
                        <ItemTemplate>
                            <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalQuantity") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Start Date">
                        <ItemTemplate>
                            <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="End Date">
                        <ItemTemplate>
                            <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("FinishDate") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buyer" SortExpression="Buyer">
                        <ItemTemplate>
                            <asp:Label ID="lblBuyer" runat="server" Text='<%# Eval("Buyer") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SupplierName" SortExpression="SupplierName">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblSupplierName" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="RecDate">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblRecDate" runat="server" Text='<%# Bind("RecDate", "{0:dd-MM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Rec Date">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRecDate" Enabled="false" runat="server" Text='<%# Bind("RecDate", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtRecDate"
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRecDate" Enabled="false" runat="server" Text='<%# Bind("RecDate", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtRecDate"
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemStyle Wrap="false" />
                            <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                        </asp:TemplateField>--%>
                    <%--<asp:TemplateField HeaderText="Edit" ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="150px" />
                                    <HeaderStyle Width="150px" />
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
</asp:Content>

