<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" EnableEventValidation="false" Culture="en-IN" CodeBehind="WIPAgingReport.aspx.cs" Inherits="VV.WIPAgingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="SearchPanel" runat="server" Style="margin-left: 1000px;">
            <asp:DropDownList ID="ddlSelection" Width="150px" runat="server" OnSelectedIndexChanged="ddlSelection_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;<asp:ImageButton ID="imgExcelForPending" runat="server" Style="margin-bottom: -7px" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="imgExcelForPending_Click" Height="25px" Width="25px" />
        </asp:Panel>
    </div>
    <div style="margin-top: 10px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView3" Style="margin-left: 125px; margin-bottom: 20px;" runat="server" Width="80%" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="24"
                    OnPageIndexChanging="GridView3_PageIndexChanging" HeaderStyle-HorizontalAlign="Center"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnRowDataBound="GridView3_RowDataBound"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" HeaderText="PO Series">
                            <ItemStyle HorizontalAlign="Left" Font-Bold="true"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblPOSeries" runat="server" Text='<%# Eval("POSeries") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count(Upto 14 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblCount1" runat="server" Text='<%# Eval("Count1") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count(15 to 30 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblCount2" runat="server" Text='<%# Eval("Count2") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count(31 to 60 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblCount3" runat="server" Text='<%# Eval("Count3") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count(61 to 90 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblCount4" runat="server" Text='<%# Eval("Count4") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>


                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count(Above 90 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblCount5" runat="server" Text='<%# Eval("Count5") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle CssClass="Grid_Header" />
                    <FooterStyle CssClass="Grid_Summary" />
                    <PagerStyle CssClass="Grid_Pager" />
                    <EmptyDataRowStyle CssClass="EmptyCell" />
                    <SelectedRowStyle BackColor="#FFEEC2" />
                    <RowStyle CssClass="Grid_RowRecord" />
                    <PagerSettings Position="TopAndBottom" />
                </asp:GridView>

                <asp:GridView ID="GridView1" Style="margin-left: 125px; margin-bottom: 20px;" runat="server" Width="80%" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="24"
                    OnPageIndexChanging="GridView3_PageIndexChanging" HeaderStyle-HorizontalAlign="Center"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnRowDataBound="GridView3_RowDataBound"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" HeaderText="PO Series">
                            <ItemStyle HorizontalAlign="Left" Font-Bold="true"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblPOSeries" runat="server" Text='<%# Eval("POSeries") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Qty(Upto 14 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblSum1" runat="server" Text='<%# Eval("Sum1") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Qty(15 to 30 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblSum2" runat="server" Text='<%# Eval("Sum2") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Qty(31 to 60 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblSum3" runat="server" Text='<%# Eval("Sum3") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Qty(61 to 90 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblSum4" runat="server" Text='<%# Eval("Sum4") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Qty(Above 90 days)">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblSum5" runat="server" Text='<%# Eval("Sum5") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle CssClass="Grid_Header" />
                    <FooterStyle CssClass="Grid_Summary" />
                    <PagerStyle CssClass="Grid_Pager" />
                    <EmptyDataRowStyle CssClass="EmptyCell" />
                    <SelectedRowStyle BackColor="#FFEEC2" />
                    <RowStyle CssClass="Grid_RowRecord" />
                    <PagerSettings Position="TopAndBottom" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
