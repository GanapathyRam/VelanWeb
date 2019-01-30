<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" EnableEventValidation="false"
    Culture="en-IN" CodeBehind="ReadyToRelease.aspx.cs" Inherits="VV.ReadyToRelease" %>

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

        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }

        function IsCheckBox(chk) {
            return (chk.type == 'checkbox');
        }
    </script>
    <div style="margin-left: 600px; text-align: center; font-family: Verdana;">
        <asp:Panel ID="BulkUpdateWIP" runat="server">
            <asp:Label ID="lblItem" runat="server" Style="font-family: Verdana; text-align: center;" Text="Item"></asp:Label>
            <asp:TextBox ID="txtItem" runat="server" Height="15px" Style="height: 20px;" CssClass="textBox" ToolTip="Enter item to be Searched" onKeyUp="ControlSearch(this)" />
            &nbsp;
            <asp:Button ID="btnSearchBox" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Search" OnClick="btnSearchBox_Click" ToolTip="Click to Search Data" />
            &nbsp;
            <asp:Button ID="btnExcelExport" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Excel Export" OnClick="btnExcelExport_Click" ToolTip="Click to Export Excel" />
        </asp:Panel>
    </div>
     <div style="margin-top:10px;">
        <asp:Label ID="lblMessage" Style="margin-left: 900px; font-size: small; font-family: Verdana; text-align: right;" CssClass="lblSuccessMessage" Visible="false" runat="server"></asp:Label>
    </div>
    <div style="margin-top: 30px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                    Style="margin-left: 200px;" Width="60%"
                    OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Center"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnRowDataBound="GridView1_RowDataBound"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblItemGrid" runat="server" Text='<%# Eval("Item") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Matchset" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblMatches" runat="server" Text='<%# Eval("Matchset") %>' />
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
