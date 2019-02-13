<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" EnableEventValidation="false" Culture="en-IN" CodeBehind="UtilityQuality.aspx.cs" Inherits="VV.UtilityQuality" %>

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

    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr style="height: 40px;">
            <td colspan="3" style="text-align: right; font-family: Arial;">
                <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Visible="false" Font-Size="Medium" runat="server"></asp:Label>
            </td>
            <td colspan="1" style="font-family: Verdana; text-align: center;">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="* fields are mandatory."></asp:Label>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblRequestedBy" Text="Approved By" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:DropDownList ID="ddlEmployess" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployess_SelectedIndexChanged" Style="width: 185px; height: 22px; margin-left: 20px;" DataValueField="EmployeeCode" DataTextField="EmployeeName" runat="server"></asp:DropDownList>
                <asp:Label ID="lblRequiredFields" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 25px;  font-family: Verdana; width: 70px;">
                <asp:Label ID="lblDisposition" Text="Disposition" runat="server"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDisposition" AutoPostBack="true" OnSelectedIndexChanged="ddlDisposition_SelectedIndexChanged" Style="width: 185px; height: 22px; margin-left: 20px;" DataValueField="Disposition" DataTextField="Disposition" runat="server"></asp:DropDownList>
                <asp:Label ID="Label2" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblRemarks" Text="Remarks" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtRemarks" Style="width: 182px; height: 17px; margin-left: 20px;" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td colspan="3" style="text-align: center;">
                <asp:Button ID="btnUpdate" Style="font-style: normal;height: 30px;width: 100px; font-style: normal; margin-right: 25px; margin-top: 15px;" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            </td>
            <td></td>
        </tr>
        <tr style="height: 20px;">
            <td colspan="5"></td>
        </tr>
    </table>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView" Style="margin-left: 200px; margin-bottom:20px;" runat="server" Width="60%"
                AutoGenerateColumns="false" EmptyDataText="No Records To Display"
                AllowPaging="true" CellPadding="3" OnPageIndexChanging="GridView_PageIndexChanging"
                CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager"
                RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Select">
                        <HeaderTemplate>
                            <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                            <input id="hidId" value='<%# Eval("Id") %>' type="hidden" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Requested By" SortExpression="RequestedBy">
                        <ItemTemplate>
                            <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("EmployeeName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Requested Date">
                        <ItemTemplate>
                            <asp:Label ID="lblRequestDate" runat="server" Text='<%# Bind("RequestDate", "{0:dd-MM-yyyy}") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Itemcode From" SortExpression="ItemcodeFrom">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="lblItemcodeFrom" runat="server" Text='<%# Eval("ItemcodeFrom") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Itemcode To" SortExpression="ItemcodeTo">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblItemcodeTo" Text='<%# Eval("ItemcodeTo") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="True" HeaderText="OrderNo">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblOrderNo" Text='<%# Eval("OrderNo") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Pos">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPos" Text='<%# Eval("Pos") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblRequestRemarks" runat="server" Text='<%# Eval("RequestRemarks") %>'></asp:Label>
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
</asp:Content>
