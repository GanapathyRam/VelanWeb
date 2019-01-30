<%@ Page Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" Culture="en-IN" CodeBehind="ViewSCM.aspx.cs" Inherits="VV.ViewSCM"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:Panel ID="BulkUpdatePO" runat="server">
            <asp:Panel ID="BulkUpdatePO1" runat="server">
                <br />
                <asp:Label ID="lblOption1" Style="margin-left: 452px;" runat="server" Text="Supplier"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" Style="margin-left: 500px; margin-top: -20px;" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="All" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Specific" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:Panel>
        </asp:Panel>
    </div>
    <br />
    <div>
        <asp:Label ID="lblSupplierName" Style="margin-left: 420px;" runat="server" Text="Supplier Name"></asp:Label>
        <asp:DropDownList ID="ddlSupplierName" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplierName_SelectedIndexChanged" DataTextField="SupplierName" DataValueField="SupplierName" Style="margin-left: 5px; width: 190px; height: 22px;" runat="server"></asp:DropDownList>
    </div>
    <br />
    <div>
        <asp:Label ID="lblOption2" Style="margin-left: 452px;" runat="server" Text="Criteria"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList2" Style="margin-left: 500px; margin-top: -20px;" RepeatDirection="Horizontal" runat="server">
            <asp:ListItem Text="OverDue" Selected="True" Value="0"></asp:ListItem>
            <asp:ListItem Text="Non OverDue" Value="1"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />
    <div style="text-align:center;">
        <asp:Button ID="btnSearch" style="width:100px; margin-bottom: 10px; height: 25px;"  runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>

    <div class="border border-white">
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView3_RowDataBound"
                    AllowPaging="true" OnPageIndexChanging="GridView3_PageIndexChanging" AllowSorting="true"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnSorting="GridView3_Sorting"
                    PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records Found"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Po Order No">
                            <ItemTemplate>
                                <input id="hidPoOrder" value='<%# Eval("PoOrder") %>' type="hidden" runat="server" />
                                <asp:Label ID="lblPoOrderNo" runat="server" Text='<%# Eval("PoOrder") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Pos">
                            <ItemTemplate>
                                <asp:Label ID="lblPOPosition" runat="server" Text='<%# Eval("POPosition") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
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
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Due">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPlanDueDays" Text='<%# Eval("DueDays") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Item Number">
                            <%--<HeaderTemplate>
                                <asp:LinkButton ID="lnkSort" runat="server" Text="ItemNumber" CommandName="Sort" CommandArgument="ItemNumber" />
                            </HeaderTemplate>--%>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label1" Text='<%# Eval("ItemNumber") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Description">
                            <ItemStyle Wrap="false" Width="90px" HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" ToolTip='<%# Eval("Description") %>' Text='<%# Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                          <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Supplier Name">
                            <ItemStyle Wrap="false" Width="90px"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" ToolTip='<%# Eval("Name") %>' Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Ord Qty">
                            <ItemTemplate>
                                <asp:Label ID="lblOrdered" runat="server" Style="text-align: left; width: 100px;" Text='<%# Eval("Ordered") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Dly Qty">
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
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commit1">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCommitment1" runat="server" Style="text-align: left; width: 90px;" Enabled="false" Text='<%# Bind("Comm1", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                <asp:RegularExpressionValidator ID="dateValidator1" runat="server" ControlToValidate="txtCommitment1"
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCommitment1" AutoPostBack="true" Style="text-align: left; width: 90px;" runat="server" Enabled="true" Text='<%# Bind("Comm1", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                <asp:RegularExpressionValidator ID="dateValidator1" runat="server" ControlToValidate="txtCommitment1"
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemStyle Wrap="false" />
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commit2">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCommitment2" runat="server" Style="text-align: left; width: 90px;" Enabled="false" Text='<%# Bind("Comm2", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtCommitment2"
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCommitment2" runat="server" Style="text-align: left; width: 90px;" Enabled="true" Text='<%# Bind("Comm2", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtCommitment2"
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemStyle Wrap="false" />
                            <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Commit3">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCommitment3" runat="server" Style="text-align: left; width: 90px;" Enabled="false" Text='<%# Bind("Comm3", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                <asp:RegularExpressionValidator ID="dateValidator3" runat="server" ControlToValidate="txtCommitment3"
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                    ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCommitment3" runat="server" Style="text-align: left; width: 90px;" Enabled="true" Text='<%# Bind("Comm3", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
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
                                <asp:CheckBox ID="chkShipped" Enabled="false" runat="server" Checked='<%# Eval("Shipped") %>' />
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
                                <asp:DropDownList ID="ddlSupplierRemarks" Width="80px" runat="server"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </EditItemTemplate>
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


