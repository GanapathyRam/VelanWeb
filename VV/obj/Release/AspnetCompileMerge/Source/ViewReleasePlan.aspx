<%@ Page Title="View Release Plan" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true"
    Culture="en-IN" CodeBehind="ViewReleasePlan.aspx.cs" Inherits="VV.ViewReleasePlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function CheckWeekNo() {
            if (document.getElementById('<%= txtWeekNo.ClientID %>').value == "") {
                alert('First Load the Grid');
                return false;
            }
        }
    </script>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="30%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View Release Plan" />
            </td>
            <%--
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="15%">
                <asp:Button ID="btnMacro" runat="server" CssClass="buttonText" OnClientClick="return CheckWeekNo()"
                    Text="View Macro Data" OnClick="btnMacro_Click" Width="100"></asp:Button>
                <%--<asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif" EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
            </td>
            <td width="55%" align="right" style="padding-left: 270px;" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:Label ID="lblWeek" Text="Enter Starting Week No" runat="server"></asp:Label>
                    <asp:TextBox ID="txtWeekNo" runat="server" ToolTip="Enter Starting Week No" />
                    <asp:RequiredFieldValidator ID="reqval" runat="server" ControlToValidate="txtWeekNo"
                        Display="Dynamic" ErrorMessage="Week No is Mandatory"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="weekValidator1" runat="server" ControlToValidate="txtWeekNo"
                        ValidationExpression="^[1-9]$|^[1-4][0-9]$|^5[0-2]$" ErrorMessage="Only Numbers between 1 and 52"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" />
                    <asp:ImageButton ID="imgExcel" runat="server" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg"
                        OnClick="btnExcel_Click" Height="25px" Width="25px" />
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
                        <asp:GridView ID="grdViewReleasePlan" DataKeyNames="OrderNo" ShowHeader="true" AllowSorting="false"
                            AllowPaging="true" AutoGenerateColumns="false" runat="server" EmptyDataText="No Records To Display"
                            CellPadding="3" PageSize="24" OnPageIndexChanging="grdViewReleasePlan_PageIndexChanging"
                            CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager"
                            RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">
                            <Columns>
                                <asp:TemplateField HeaderText="Plan Week" ItemStyle-HorizontalAlign="left" SortExpression="WeekNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWeekNo" runat="server" Text='<%# Eval("WeekNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="left" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer" ItemStyle-HorizontalAlign="left" SortExpression="Customer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomer" runat="server" Text='<%# Eval("Customer") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planned Inv Qty" ItemStyle-HorizontalAlign="left"
                                    SortExpression="PlanInvQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanInvQty" runat="server" Text='<%# Eval("PlanInvQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planned FG Qty" ItemStyle-HorizontalAlign="left" SortExpression="PlanFGQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanFGQty" runat="server" Text='<%# Eval("PlanFGQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planned WIP Qty" ItemStyle-HorizontalAlign="left"
                                    SortExpression="PlanWIPQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanWIPQty" runat="server" Text='<%# Eval("PlanWIPQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planned ToRel Qty" ItemStyle-HorizontalAlign="left"
                                    SortExpression="PlanToRelQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanToRelQty" runat="server" Text='<%# Eval("PlanToRelQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planned Inv Val" ItemStyle-HorizontalAlign="right"
                                    SortExpression="PlanInvVal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanInvVal" runat="server" Text='<%# Eval("PlanInvVal","{0:c0}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planned FG Val" ItemStyle-HorizontalAlign="right"
                                    SortExpression="PlanFGVal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanFGVal" runat="server" Text='<%# Eval("PlanFGVal","{0:c0}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planned WIP Val" ItemStyle-HorizontalAlign="right"
                                    SortExpression="PlanWIPVal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanWIPVal" runat="server" Text='<%# Eval("PlanWIPVal","{0:c0}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Planned ToRel Val" ItemStyle-HorizontalAlign="right"
                                    SortExpression="PlanToRelVal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanToRelVal" runat="server" Text='<%# Eval("PlanToRelVal","{0:c0}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inv Qty" ItemStyle-HorizontalAlign="left" SortExpression="InvQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvQty" BackColor="LightGreen" runat="server" Text='<%# Eval("InvQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FG Qty" ItemStyle-HorizontalAlign="left" SortExpression="FGQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFGQty" BackColor="LightGreen" runat="server" Text='<%# Eval("FGQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WIP Qty" ItemStyle-HorizontalAlign="left" SortExpression="WIPQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWIPQty" BackColor="LightGreen" runat="server" Text='<%# Eval("WIPQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UnderPick Qty" ItemStyle-HorizontalAlign="left" SortExpression="UnderPickQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnderPickQty" BackColor="LightGreen" runat="server" Text='<%# Eval("UnderPickQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ToRel Qty" ItemStyle-HorizontalAlign="left" SortExpression="ToRelQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblToRelQty" BackColor="LightGreen" runat="server" Text='<%# Eval("ToRelQty") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inv Val" ItemStyle-HorizontalAlign="right" SortExpression="InvVal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvVal" BackColor="LightGreen" runat="server" Text='<%# Eval("InvVal","{0:c0}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FG Val" ItemStyle-HorizontalAlign="right" SortExpression="FGVal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFGVal" BackColor="LightGreen" runat="server" Text='<%# Eval("FGVal","{0:c0}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WIP Val" ItemStyle-HorizontalAlign="right" SortExpression="WIPVal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWIPVal" BackColor="LightGreen" runat="server" Text='<%# Eval("WIPVal","{0:c0}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ToRel Val" ItemStyle-HorizontalAlign="right" SortExpression="ToRelVal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblToRelVal" BackColor="LightGreen" runat="server" Text='<%# Eval("ToRelVal","{0:c0}") %>' />
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
