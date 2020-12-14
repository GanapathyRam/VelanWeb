<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" Culture="en-IN" CodeBehind="PrimaryBoxEntry.aspx.cs" Inherits="VV.PrimaryBoxEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<link type="text/css" rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>--%>
    <script language="javascript" type="text/javascript">

    </script>
    <div style="text-align: right; background-color: #eceded; line-height: normal;">
        <asp:Panel ID="BulkUpdateWIP" runat="server">
            <asp:Label ID="lblWIPSearch" runat="server" Font-Bold="true" Text="PrimaryBoxNo Search:"></asp:Label>
            <asp:Label ID="lblProdOrder" runat="server" Style="margin-left: 150px;" Text="Prod Order No"></asp:Label>
            <asp:TextBox ID="txtProdOrder" runat="server" Width="100px" ToolTip="Enter Prod Order Number to be Searched" onKeyUp="ControlSearch(this)" />

            &nbsp;<asp:Button ID="btnSearchBox" runat="server" CssClass="buttonText" Enabled="true" OnClick="btnSearchBox_Click" Text="Search" ToolTip="Click to Search Data" />
            &nbsp;&nbsp;
           
        </asp:Panel>
    </div>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="15%">
                <asp:Label ID="lblPageTitle" runat="server" Text="Primary Box Entry" />
            </td>

            <%--Added by Arun on 26-Dec'07.
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif" EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>

        </tr>
        <tr>
            <td colspan="3">
                <%--Added by Arun on 26-Dec'07.
                 Implemeted the Update Panel, so as to avoid showing the flickering, when any operations are done --%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                    <%--<Triggers>
                        <asp:AsyncPostBackTrigger />
                    </Triggers>--%>
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit" PageSize="30" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                            PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                            CellPadding="3">
                            <Columns>
                                <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"
                                    HeaderStyle-Width="100px" SortExpression="OrderNo">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HypLnkOrderNo" NavigateUrl='<%# "UpdatePrimaryBoxEntry.aspx?OrderNo=" + DataBinder.Eval(Container.DataItem,"OrderNo") + "&ProdOrderNo=" +
                                                                DataBinder.Eval(Container.DataItem,"ProdOrderNo") + "&Pos=" + DataBinder.Eval(Container.DataItem,"Pos") + "&ValveBoxQty=" +
                                                                DataBinder.Eval(Container.DataItem,"ValveBoxQty") + "&Item=" +
                                                                DataBinder.Eval(Container.DataItem,"Item") %>' runat="server" Text='<%# Eval("OrderNo") %>'></asp:HyperLink>
                                        <%--Enabled='<%# Eval("ItemGroup").ToString() != "" ? true:false %>'--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order No" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prod Order No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdOrderNo" runat="server" Text='<%# Eval("ProdOrderNo") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prod Release Qty">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblProdReleaseQty" Text='<%# Eval("ProdReleaseQty") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Balance Qty">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblBalanceQty" Text='<%# Eval("BalanceQty") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Packed Qty">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPackedQty" Text='<%# Eval("PackedQty") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPackedQty" runat="server" Enabled="true" Text='<%# Bind("PackedQty") %>'> </asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <%--  <asp:TemplateField HeaderText="Number of Boxes">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNoOfBoxes" Text='<%# Eval("PackedQty") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPackedQty" runat="server" Enabled="true" Text='<%# Bind("PackedQty") %>'> </asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Body Heat No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBodyHeatNo" runat="server" Text='<%# Eval("BodyHeatNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bonnet Heat No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBonnetHeatNo" runat="server" Text='<%# Eval("BonnetHeatNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Valve Box Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValveBoxQty" runat="server" Text='<%# Eval("ValveBoxQty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Edit" Visible="false" ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
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
