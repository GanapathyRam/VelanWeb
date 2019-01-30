<%@ Page Title="View PO Dates" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" Culture="en-IN" CodeBehind="ViewPODates.aspx.cs" 
    Inherits="VV.ViewPODates" EnableEventValidation="false" %>

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
        <asp:RadioButtonList ID="RadioButtonListForPO" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonListForPO_SelectedIndexChanged" runat="server" AutoPostBack="True">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>Blank</asp:ListItem>
            <asp:ListItem>Past Dates</asp:ListItem>
            <asp:ListItem>Current Month</asp:ListItem>
            <asp:ListItem>Future Dates</asp:ListItem>
        </asp:RadioButtonList>
        <%--  <asp:ImageButton ID="ExportExcel" runat="server" AlternateText="Export To Excel" style="height:25px;width:25px;border-width:0px;margin-top: 0px;margin-left: 1100px;" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" OnClick="ExportExcel_Click"  Height="25px" Width="25px" />--%>
         <asp:Panel ID="pnlPO" runat="server" Style="display: inline;">
            <asp:Label ID="Label1" runat="server" Text="Export PO Data:" Style="text-align: center;" Font-Bold="True"></asp:Label>
            <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Export To Excel" ToolTip="ExportForPODates" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" OnClick="ExportExcel_Click" Height="25px" Width="25px" />
        </asp:Panel>
        <asp:Panel ID="pnlPOHistory" runat="server" Style="display: inline;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Label2" runat="server" Text="Export PO History:" Style="text-align: center;" Font-Bold="True"></asp:Label>
            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="Export To Excel" ToolTip="ExportForPODatesHistory" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" Height="25px" Width="25px" OnClick="ImageButton3_Click"/>
        </asp:Panel>
         <asp:Panel ID="Panel1" runat="server" Style="display: inline;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Label3" runat="server" Text="Export PO Data of Selection:" Style="text-align: center;" Font-Bold="True"></asp:Label>
            <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Export To Excel" ToolTip="ExportForPODatesHistory" ImageUrl="~/Images/excel.jpg"
            CssClass="thirdLevelHeader" Height="25px" Width="25px" OnClick="ImageButton1_Click"/>
        </asp:Panel>
        <%--<asp:Panel ID="BulkUpdatePO" runat="server">
            <asp:TextBox ID="txtPoOrder" runat="server" Width="70px" ToolTip="Enter PO Order to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtItemNumber" runat="server" Width="120px" ToolTip="Enter Item Number to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtBuyers" runat="server" ToolTip="Enter Buyer to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtName" runat="server" ToolTip="Enter Name to be Searched" onKeyUp="ControlSearch(this)" />
            
            <asp:Button ID="btnSearchBox" runat="server" Text="Search"
                ToolTip="Click to Search Data" CssClass="buttonText" Enabled="true" OnClick="btnSearchBox_Click" />

            &nbsp;&nbsp;

            <asp:TextBox ID="txtBuyer" ToolTip="Please enter Buyer" Width="125px" runat="server" style="margin-left: 0px"></asp:TextBox>            
             <asp:TextBox ID="txtPOUpdate" ToolTip="Please enter a valid date dd-MM-yyyy" Width="125px" runat="server" style="margin-left: 0px"></asp:TextBox>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPOUpdate" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                ErrorMessage="Invalid date format." ValidationGroup="Group1" />
            <asp:TextBox ID="txtRemarks" ToolTip="Please enter Remarks" Width="150px" runat="server" style="margin-left: 0px"></asp:TextBox>
            
            <input type="button" id="btnPOBulkUpdate" class="buttonText" value="Update" validationgroup="Group1" style="width: 90px; height: 22px;" runat="server" onserverclick="btnPOBulkUpdate_ServerClick" />
        </asp:Panel>--%>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false"
                OnRowCancelingEdit="GridView3_RowCancelingEdit" AllowPaging="true" OnPageIndexChanging="GridView3_PageIndexChanging"
                OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                PagerStyle-CssClass="Grid_Pager" PageSize="5000" AllowSorting="true" OnSorting="GridView3_Sorting" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                CellPadding="3">
                <Columns>
                    <asp:TemplateField Visible="false" HeaderText="Select">
                        <HeaderTemplate>
                            <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                            <input id="hidPoOrder" value='<%# Eval("PoOrder") %>' type="hidden" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Po Order No" SortExpression="PoOrder">
                        <ItemTemplate>
                            <asp:Label ID="lblPoOrderNo" runat="server" Text='<%# Eval("PoOrder") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="PO Position">
                        <ItemTemplate>
                            <asp:Label ID="lblPOPosition" runat="server" Text='<%# Eval("POPosition") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Order Date">
                        <ItemTemplate>
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Plan DelDate">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPlanDelDate" Text='<%# Eval("PlanDelDate") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Item Number" SortExpression="ItemNumber">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblItemNumber" Text='<%# Eval("ItemNumber") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="70px" />
                                    <HeaderStyle Width="70px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Description" SortExpression="Description">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Ordered">
                        <ItemTemplate>
                            <asp:Label ID="lblOrdered" runat="server" Text='<%# Eval("Ordered") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Deliv">
                        <ItemTemplate>
                            <asp:Label ID="lblDeliv" runat="server" Text='<%# Eval("Deliv") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Bal Qty">
                        <ItemTemplate>
                            <asp:Label ID="lblOrderBalance" runat="server" Text='<%# Eval("OrderBalance") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Urgent">
                        <ItemTemplate>
                            <asp:Label ID="lblUrgent" runat="server" Text='<%# Eval("Urgent") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" HeaderText="ReferenceA">
                        <ItemTemplate>
                            <asp:Label ID="lblReferenceA" runat="server" Text='<%# Eval("ReferenceA") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Name" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="Buyer" SortExpression="Buyer">
                        <ItemTemplate>
                            <asp:Label ID="lblBuyer" runat="server" Text='<%# Eval("Buyer") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks">
                         <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" Style="text-align: left; width: 90px;" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commitment">
                         <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblCommitment" runat="server" Text='<%# Bind("Commitment", "{0:dd-MM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="Commit1">
                        <ItemTemplate>
                            <asp:Label ID="lblCommit1" runat="server" Text='<%# Eval("Commit1") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Commit2">
                        <ItemTemplate>
                            <asp:Label ID="lblCommit2" runat="server" Text='<%# Eval("Commit2") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Commit3">
                        <ItemTemplate>
                            <asp:Label ID="lblCommit3" runat="server" Text='<%# Eval("Commit3") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Shipped">
                        <ItemTemplate>
                            <asp:Label ID="lblShipped" runat="server" Text='<%# Eval("Shipped") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SupplierRemarks">
                        <ItemTemplate>
                            <asp:Label ID="lblSupplierRemarks" runat="server" Text='<%# Eval("SupplierRemarks") %>'></asp:Label>
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
</asp:Content>
