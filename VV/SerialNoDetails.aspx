<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SerialNoDetails.aspx.cs" MasterPageFile="~/VV.Master"
    EnableEventValidation="false" Culture="en-IN" Inherits="VV.SerialNoDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <div style="text-align: right; margin-top: 10px; line-height: normal;">
        <asp:Panel ID="BulkUpdateWIP" runat="server">
            <asp:Label ID="lblEmployeeName" runat="server" Style="font-family: Verdana; text-align: center;" Text="Serial Number"></asp:Label>
            <asp:TextBox ID="txtSerialNo" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter serial no to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;<asp:Label ID="lblProdOrderNo" Style="font-family: Verdana; text-align: center;" runat="server" Text="Prod Order No"></asp:Label>
            <asp:TextBox ID="txtProdOrderNo" runat="server" Style="height: 20px; width:120px;" CssClass="textBox" ToolTip="Enter Prod Order No to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;
            <asp:Label ID="lblSaleOrderNo" Style="font-family: Verdana; text-align: center;" runat="server" Text="Sale Order No + Pos"></asp:Label>
            <asp:TextBox ID="txtSaleOrderNo" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Sale Order No To to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtPos" runat="server" Style="height: 20px; width:50px; margin-left:0px;" CssClass="textBox" ToolTip="Enter Sale Order Position To to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:Button ID="btnSearchBox" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Search" OnClick="btnSearch_Click" ToolTip="Click to Search Data" />
        </asp:Panel>
    </div>
    <div style="margin-top: 50px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="24"
                    OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Center"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField HeaderText="Order Number" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Planned DelDate" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPlannedDelDate" runat="server" Text='<%# Bind("PlannedDelDate", "{0:dd-MM-yyyy}") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Original PromDate" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblOriginalPromDate" runat="server" Text='<%# Bind("OriginalPromDate", "{0:dd-MM-yyyy}") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial No" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProdOrder No" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("ProdOrderNo") %>' />
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




