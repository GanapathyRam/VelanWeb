<%@ Page Language="C#" MasterPageFile="~/VV.Master" Culture="en-IN" AutoEventWireup="true" CodeBehind="UpdatePO.aspx.cs" Inherits="VV.UpdatePO" EnableEventValidation="false" %>

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

    <div style="text-align: left; background-color: #D99694; line-height: normal;">
        <asp:Panel ID="BulkUpdatePO" runat="server">
            
            <asp:Panel ID="BulkUpdatePO1" runat="server">
                <div style="text-align: right; font-family:Verdana; font-size:small;" >
                    <asp:Label ID="lblresult" runat="server" Font-Bold="true"></asp:Label>
                </div>
                <asp:RadioButtonList ID="RadioButtonList1" Style="margin-left: 500px;" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="OverDue" Value="0"></asp:ListItem>
                    <asp:ListItem Text="NonOverDue" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:Panel>
        </asp:Panel>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" OnPreRender="GridView3_PreRender" OnRowDataBound="GridView3_RowDataBound"
                OnRowCancelingEdit="GridView3_RowCancelingEdit" AllowPaging="true" OnPageIndexChanging="GridView3_PageIndexChanging"
                OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                CellPadding="3">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Po Order No">
                        <ItemTemplate>
                            <input id="hidPoOrder" value='<%# Eval("PoOrder") %>' type="hidden" runat="server" />
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
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Plan DueDays">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPlanDueDays" Text='<%# Eval("DueDays") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Item Number">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label1" Text='<%# Eval("ItemNumber") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
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

                  <%--  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Name">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>--%>

                   <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commitment">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCommitment" runat="server" Enabled="false" Text='<%# Bind("Commitment", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator" runat="server" ControlToValidate="txtCommitment"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCommitment" runat="server" Enabled="false" Text='<%# Bind("Commitment", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator" runat="server" ControlToValidate="txtCommitment"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>--%>

                   <%-- <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                            <asp:Label ID="lblBuyer" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commitment1">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCommitment1" runat="server" Enabled="false" Text='<%# Bind("Comm1", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator1" runat="server" ControlToValidate="txtCommitment1"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCommitment1" runat="server" Enabled="true" Text='<%# Bind("Comm1", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator1" runat="server" ControlToValidate="txtCommitment1"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemStyle Wrap="true" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commitment2">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCommitment2" runat="server" Enabled="false" Text='<%# Bind("Comm2", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtCommitment2"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCommitment2" runat="server" Enabled="true" Text='<%# Bind("Comm2", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtCommitment2"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commitment3">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCommitment3" runat="server" Enabled="false" Text='<%# Bind("Comm3", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator3" runat="server" ControlToValidate="txtCommitment3"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCommitment3" runat="server" Enabled="true" Text='<%# Bind("Comm3", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                            <asp:RegularExpressionValidator ID="dateValidator3" runat="server" ControlToValidate="txtCommitment3"
                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemStyle Wrap="false" />
                        <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Shipped">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkShipped" runat="server" Checked='<%# Eval("Shipped") %>' />
                            <%--<asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>--%>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Supplier Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblSupplierRemarks" runat="server" Text='<%# Eval("SupplierRemarks")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdnSupplierRemarks" runat="server" Value='<%#Eval("SupplierRemarks") %>' />
                            <asp:DropDownList ID="ddlSupplierRemarks" Width="150px" runat="server"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" ShowHeader="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                            <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <%--<ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />--%>
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
