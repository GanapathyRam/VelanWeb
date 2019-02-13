<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" EnableEventValidation="false" Culture="en-IN" CodeBehind="UtilityStores.aspx.cs" 
    Inherits="VV.UtilityStores" %>

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
    <link href="CSS/Main.css" rel="stylesheet" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr style="height: 40px;">
            <td colspan="3" style="text-align: right; font-family: Arial;">
                <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Visible="false" Font-Size="larger" runat="server"></asp:Label>
            </td>
            <td colspan="1" style="font-family: Verdana; text-align: center;">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="* fields are mandatory."></asp:Label>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 25px;  font-family: Verdana; width: 70px;">
            </td>
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblDisposition" Text="Stores Disposition" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:DropDownList ID="ddlDisposition" AutoPostBack="true" OnSelectedIndexChanged="ddlDisposition_SelectedIndexChanged" Style="width: 185px; height: 22px; margin-left: 20px;" DataValueField="Disposition" DataTextField="Disposition" runat="server"></asp:DropDownList>
                <asp:Label ID="lblRequiredFields" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 25px;  font-family: Verdana; width: 70px;">
            </td>
            <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblRemarks" Text="Remarks" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtRemarks" Style="width: 182px; height: 17px; margin-left: 20px;" runat="server"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td colspan="3" style="text-align: center;">
                <asp:Button ID="btnUpdate" Style="font-style: normal;height: 30px;width: 100px; font-style: normal; margin-right: 180px; margin-top: 15px;" runat="server" Text="Update" OnClick="btnUpdate_Click" />
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
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="1"
                    OnPageIndexChanging="GridView3_PageIndexChanging" HeaderStyle-HorizontalAlign="Center"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnRowDataBound="GridView3_RowDataBound"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Select">
                        <HeaderTemplate>
                            <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                            <input id="hidId" value='<%# Eval("Id") %>' type="hidden" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Requested By" SortExpression="RequestedBy">
                        <ItemTemplate>
                            <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("EmployeeName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Requested Date">
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
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="OrderNo">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblOrderNo" Text='<%# Eval("OrderNo") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Pos">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPos" Text='<%# Eval("Pos") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Request Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblRequestRemarks" runat="server" Text='<%# Eval("RequestRemarks") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QCBy">
                        <ItemTemplate>
                            <asp:Label ID="lblQCBy" runat="server" Text='<%# Eval("QCBy") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QCOn">
                        <ItemTemplate>
                            <asp:Label ID="lblQCOn" runat="server" Text='<%# Bind("QCOn", "{0:dd-MM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QCDisposition">
                        <ItemTemplate>
                            <asp:Label ID="lblQCDisposition" runat="server" Text='<%# Eval("QCDisposition") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="QCRemarks">
                        <ItemTemplate>
                            <asp:Label ID="lblQCRemarks" runat="server" Text='<%# Eval("QCRemarks") %>'></asp:Label>
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
                    <PagerSettings Position="TopAndBottom"  />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
