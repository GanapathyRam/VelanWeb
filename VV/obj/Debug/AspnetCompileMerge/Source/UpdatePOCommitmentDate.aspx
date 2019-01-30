<%@ Page Title="Update CommitmentDate" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" Culture="en-IN"
    CodeBehind="UpdatePOCommitmentDate.aspx.cs" Inherits="VV.UpdatePOCommitmentDate" EnableEventValidation="false" %>

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
    <%-- <div style="font: 14px Verdana">
        <div style="margin-left: 500px; margin-top: 10px;">
            <asp:Label ID="lblConfirm" Visible="false" runat="server"></asp:Label>
        </div>
    </div>--%>
    <div style="text-align: left; background-color: #D99694; line-height: normal;">
        <asp:Panel ID="BulkUpdatePO" runat="server">
            <asp:Label ID="lblPOSearch" runat="server" Font-Bold="true" Text="PO Search:"></asp:Label>
            <asp:Label ID="lblPOOrder" runat="server" Style="margin-left: 200px;" Text="PO Order"></asp:Label>
            <asp:TextBox ID="txtPoOrder" runat="server" Width="70px" ToolTip="Enter PO Order to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:Label ID="lblItemNumber" runat="server" Text="Item Number"></asp:Label>
            <asp:TextBox ID="txtItemNumber" runat="server" Width="120px" ToolTip="Enter Item Number to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:Label ID="lblBuyers" runat="server" Text="Buyers"></asp:Label>
            <asp:TextBox ID="txtBuyers" runat="server" ToolTip="Enter Buyer to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:Label ID="lblSupplierName" runat="server" Text="Supplier Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" ToolTip="Enter Name to be Searched" onKeyUp="ControlSearch(this)" />

            &nbsp;
            <asp:Button ID="btnSearchBox" runat="server" CssClass="buttonText" Enabled="true" OnClick="btnSearchBox_Click" Text="Search" ToolTip="Click to Search Data" />
            &nbsp;&nbsp;
             <asp:Panel ID="BulkUpdatePO1" runat="server">
                 <asp:Label ID="lblBulkUpdate" runat="server" Font-Bold="true" Text="Bulk Update:"></asp:Label>
                 <%--<asp:TextBox ID="txtBuyer" ToolTip="Please enter Buyer" Style="margin-top: 10px; margin-left: 256px;" Width="125px" runat="server"></asp:TextBox>--%>
                 <asp:DropDownList ID="ddlForBuyers" runat="server" DataTextField="BuyerName" DataValueField="BuyerName" Style="margin-top: 10px; margin-left: 256px; width: 130px;">
                     <asp:ListItem Value="0" Enabled="false">Please Select</asp:ListItem>
                 </asp:DropDownList>
                 <asp:TextBox ID="txtPOUpdate" ToolTip="Please enter a valid date dd-MM-yyyy" Width="125px" runat="server" Style="margin-left: 0px"></asp:TextBox>
                 <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPOUpdate" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                     ErrorMessage="Invalid date format." ValidationGroup="Group1" />
                 <asp:TextBox ID="txtRemarks" ToolTip="Please enter Remarks" Width="150px" runat="server" Style="margin-left: 0px"></asp:TextBox>

                 &nbsp;

                 <input type="button" id="btnPOBulkUpdate" class="buttonText" value="Update" validationgroup="Group1" style="width: 90px; height: 22px;" runat="server" onserverclick="btnPOBulkUpdate_ServerClick" />
             </asp:Panel>
        </asp:Panel>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false"
                OnRowCancelingEdit="GridView3_RowCancelingEdit" AllowPaging="true" OnPageIndexChanging="GridView3_PageIndexChanging"
                OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                CellPadding="3">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <HeaderTemplate>
                            <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                            <input id="hidPoOrder" value='<%# Eval("PoOrder") %>' type="hidden" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Po Order No">
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
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Item Number">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblItemNumber" Text='<%# Eval("ItemNumber") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="70px" />
                                    <HeaderStyle Width="70px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Description">
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
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" HeaderText="ReferenceA">
                        <ItemTemplate>
                            <asp:Label ID="lblReferenceA" runat="server" Text='<%# Eval("ReferenceA") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Name">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Buyer">
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
                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="X">
                                    <ItemTemplate>
                                        <asp:Label ID="lblX" runat="server" Text='<%# Eval("X") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commitment">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCommitment" runat="server" Enabled="false" Text='<%# Bind("Commitment", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtCommitment"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCommitment" runat="server" Enabled="false" Text='<%# Bind("Commitment", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtCommitment"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Edit" ShowHeader="false">
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
