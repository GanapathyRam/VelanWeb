<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SerialNoDetails.aspx.cs" MasterPageFile="~/VV.Master"
    EnableEventValidation="false" Culture="en-IN" Inherits="VV.SerialNoDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblEmployeeName" Text="Serial Number" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px; height: 40px;">
                <asp:TextBox ID="txtSerialNo" Height="15px" Style="height: 20px;" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblRequiredFields" Text="Please Enter Serial Number." Visible="false" ForeColor="Red" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                <div style="padding-left: 30px; margin-top: 10px;">
                    <asp:Button ID="btnSearch" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Search" OnClick="btnSearch_Click" />
                    &nbsp;
        <asp:Button ID="btnClear" runat="server" Width="90px" Style="font-style: normal; font-weight: 10px;" Height="30px" Text="Clear" OnClick="btnClear_Click" />
                </div>
            </td>
            <td style="text-align: left; font-size: medium; font-family: Verdana;">
                <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <%--<div style="margin-left: 800px; text-align: center; font-family: Verdana;">
        <asp:Label ID="lblEmployeeNameSearch" runat="server" Text="Buyer Name"></asp:Label>
        <asp:TextBox ID="txtEmployeeNameSearch" Height="20px" Width="200px" runat="server" ToolTip="Enter Buyer Name to be Searched" onKeyUp="ControlSearch(this)" />
        &nbsp;<asp:Button ID="btnSearchBox" runat="server" Width="100px" Style="font-style: normal; font-weight: 10px;" Height="30px" Enabled="true" OnClick="btnSearchBox_Click" Text="Search" ToolTip="Click to Search Data" />
        &nbsp;&nbsp;
    </div>--%>
    <div style="margin-top: 30px;">
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




