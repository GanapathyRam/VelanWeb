<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="WeekWiseShortageReport.aspx.cs" Inherits="VV.WeekWiseShortageReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <div style="margin-top: 20px;">
        <asp:Label ID="lblHeaderName" runat="server" Style="font-family: Verdana; color: brown; font-weight: 200; text-align: center;" Text="Week Wise Shortage Report:"></asp:Label>
    </div>
    <div style="text-align: center; line-height: normal;">
        <asp:Panel ID="Panel1" runat="server">
            &nbsp;<asp:Label ID="Label3" Style="font-family: Verdana; text-align: center;" runat="server" Text="Year"></asp:Label>
            <asp:TextBox ID="txtYear" runat="server" Style="height: 20px; width: 100px;" CssClass="textBox" ToolTip="Enter year to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="txtYear" runat="server"
                ErrorMessage="Only Numbers allowed"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator>
            &nbsp;<asp:Label ID="Label4" Style="font-family: Verdana; text-align: center;" runat="server" Text="Week No"></asp:Label>
            <asp:TextBox ID="txtWeekNo" runat="server" Style="height: 20px; width: 100px;" CssClass="textBox" ToolTip="Enter week no to be Searched" onKeyUp="ControlSearch(this)" />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                ControlToValidate="txtWeekNo" runat="server"
                ErrorMessage="Only Numbers allowed"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator>
            &nbsp;
            <asp:Button ID="btnSearchBox1" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Generate" OnClick="btnSearchBox1_Click" ToolTip="Click to Search Data" />
        </asp:Panel>
    </div>
    <div style="text-align: right; line-height: normal;">
        <asp:Panel ID="BulkUpdateWIP" Style="margin-top: 15px;" runat="server">
            <asp:Label ID="lblOrderNo" runat="server" Style="font-family: Verdana; text-align: center;" Text="PoOrder"></asp:Label>
            <asp:TextBox ID="txtOrderNo" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Order Number to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;<asp:Label ID="lblPos" Style="font-family: Verdana; text-align: center;" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtPos" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Position to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;<asp:Label ID="lblBuyer" Style="font-family: Verdana; text-align: center;" runat="server" Text="Buyer"></asp:Label>
            <asp:TextBox ID="txtBuyer" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Buyer to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;<asp:Label ID="lblDescription" Style="font-family: Verdana; text-align: center;" runat="server" Text="Item Number"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter Position to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;
            <asp:Button ID="btnSearchBox" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Search" OnClick="btnSearchBox_Click" ToolTip="Click to Search Data" />
            &nbsp;
            <asp:Button ID="btnExcelExport" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Excel Export" OnClick="btnExcelExport_Click" ToolTip="Click to Export Excel" />
        </asp:Panel>
    </div>

    <div style="margin-top: 10px;">
        <asp:Label ID="lblMessage" Style="margin-left: 900px; font-size: small; font-family: Verdana; text-align: right;" CssClass="lblSuccessMessage" Visible="false" runat="server"></asp:Label>
    </div>
    <div style="margin-top: 30px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
                    OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Left"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <%--<Columns>
                        <asp:TemplateField HeaderText="PoOrder" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPoOrder" runat="server" Text='<%# Eval("poorder") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PO Position" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPos" runat="server" Text='<%# Eval("poposition") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("name") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buyer" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblbuyer" runat="server" Text='<%# Eval("buyer") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Number" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblItemNumber" runat="server" Text='<%# Eval("itemnumber") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("description") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Till WK-0" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw0" runat="server" Text='<%# Eval("w0") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WK-1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw1" runat="server" Text='<%# Eval("w1") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WK-2" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw2" runat="server" Text='<%# Eval("w2") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WK-3" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw3" runat="server" Text='<%# Eval("w3") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WK-4" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw4" runat="server" Text='<%# Eval("w4") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WK-5" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw5" runat="server" Text='<%# Eval("w5") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WK-6" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw6" runat="server" Text='<%# Eval("w6") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WK-7" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw7" runat="server" Text='<%# Eval("w7") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="WK-8" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblw8" runat="server" Text='<%# Eval("w8") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Above WK" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblwn" runat="server" Text='<%# Eval("wn") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                    </Columns>--%>
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
