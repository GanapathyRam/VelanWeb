<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="UpdateOrderStatus.aspx.cs"
    EnableEventValidation="false" Culture="en-IN" Inherits="VV.UpdateOrderStatus" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function checkAll(parentChk) {

            var elements = document.querySelectorAll('.checkAll input');
            for (i = 0; i < elements.length; i++) {
                if (document.getElementById('chkAll').checked == true) {
                    //if (IsCheckBox(elements[i])) {
                    elements[i].checked = true;
                    //}

                }
                else {
                    //if (IsCheckBox(elements[i])) {
                    elements[i].checked = false;
                    //}
                }
            }
        }

        //function IsCheckBox(chk) {
        //    return (chk.type == 'checkbox');
        //}
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="height: 100%; margin-top: 20px;" width="100%" cellpadding="0" cellspacing="0">
        <tr style="height: 40px;">
            <td style="padding-left: 100px; text-align: right; font-family: Verdana; width: 250px;">
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " />
            </td>
            <td style="padding-left: 20px; width: 100px;">
                <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left: 20px; font-family: Verdana; width: 70px;">
                <asp:Label ID="lblOrderNo" runat="server" Text="Order No " />
            </td>
            <td style="width: 50px;">
                <asp:TextBox ID="txtOrderNo" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left: 10px; text-align: right; font-family: Verdana; width: 70px; padding-right: 15px;">
                <asp:Label ID="lblPos" runat="server" Text="Pos " />
            </td>
            <td>
                <asp:TextBox ID="txtPos" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td colspan="6" style="text-align: center;">
                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="100px" Height="27px" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 100px; text-align: right; font-family: Verdana; width: 250px;">
                <asp:Label ID="lblReceiptActivity" runat="server" Text="Receipt Activity " />
            </td>
            <td style="padding-left: 20px; width: 100px; height: 15px; width: 18px;">
                <%--<asp:TextBox ID="txtReceiptActivity" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkReceiptActivity" Style="height: 15px; width: 18px;" runat="server" Height="15px" Width="28px" OnCheckedChanged="chkReceiptActivity_CheckedChanged" />
            </td>
            <td style="padding-left: 20px; font-family: Verdana; text-align:right; width: 70px;">
                <asp:Label ID="lblNullDate" runat="server" Text="Null Date " />
            </td>
            <td style="width: 50px;">
                <%--<asp:TextBox ID="txtNullDate" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkNullDate" runat="server" />
            </td>
            <td style="padding-left: 10px; text-align: center; font-family: Verdana; width: 140px;">
                <asp:Label ID="lblMaterialReceiptDate" runat="server" Text="Material Receipt Date " />
            </td>
            <td>
                <asp:TextBox ID="txtMaterialReceiptDate" runat="server"></asp:TextBox>
                <%--<asp:TextBox ID="txtDcDate" Height="15px" Style="margin-right: 70px; margin-left:10px; width: 185px;" runat="server"></asp:TextBox>--%>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtMaterialReceiptDate" Format="dd/MM/yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>

                <asp:CheckBox ID="chkReceipt" runat="server" />
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 100px; text-align: right; font-family: Verdana; width: 250px;">
                <asp:Label ID="lblMachiningActivity" runat="server" Text="Machining Activity " />
            </td>
            <td style="padding-left: 20px; width: 100px;">
                <%--<asp:TextBox ID="txtMachiningActivity" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkMachiningActivity" runat="server" />
            </td>
            <td style="padding-left: 20px; font-family: Verdana; text-align:right; width: 70px;">
                <asp:Label ID="lblNullDate1" runat="server" Text="Null Date " />
            </td>
            <td style="width: 50px;">
                <%--<asp:TextBox ID="txtNullDate1" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkNullDate1" runat="server" />
            </td>
            <td style="padding-left: 10px; text-align: center; font-family: Verdana; width: 70px;">
                <asp:Label ID="lblMachiningCompletionDate" runat="server" Text="Machining Completion Date " />
            </td>
            <td>
                <asp:TextBox ID="txtMachiningCompletionDate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtMachiningCompletionDate" Format="dd/MM/yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
                <asp:CheckBox ID="chkMachine" runat="server" />
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 100px; text-align: right; font-family: Verdana; width: 250px;">
                <asp:Label ID="lblAssemblyActivity" runat="server" Text="Assembly Activity " />
            </td>
            <td style="padding-left: 20px; width: 100px;">
                <%--<asp:TextBox ID="txtAssemblyActivity" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkAssemblyActivity" runat="server" />
            </td>
            <td style="padding-left: 20px; font-family: Verdana; text-align:right; width: 70px;">
                <asp:Label ID="lblNullDate2" runat="server" Text="Null Date " />
            </td>
            <td style="width: 50px;">
                <%--<asp:TextBox ID="txtNullDate3" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkNullDate2" runat="server" />
            </td>
            <td style="padding-left: 10px; text-align: center; font-family: Verdana; width: 70px;">
                <asp:Label ID="lblAssemblyReleaseDate" runat="server" Text="Assembly Release Date " />
            </td>
            <td>
                <asp:TextBox ID="txtAssemblyReleaseDate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" TargetControlID="txtAssemblyReleaseDate" Format="dd/MM/yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
                <asp:CheckBox ID="chkAssembly" runat="server" />
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 100px; text-align: right; font-family: Verdana; width: 250px;">
                <asp:Label ID="lblTPI1Activity" runat="server" Text="TPI 1 Activity " />
            </td>
            <td style="padding-left: 20px; width: 100px;">
                <%--<asp:TextBox ID="txtTPI1Activity" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkTPI1Activity" runat="server" />
            </td>
            <td style="padding-left: 20px; font-family: Verdana; text-align:right; width: 70px;">
                <asp:Label ID="lblNullDate3" runat="server" Text="Null Date " />
            </td>
            <td style="width: 50px;">
                <%--<asp:TextBox ID="txtNullDate4" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkNullDate3" runat="server" />
            </td>
            <td style="padding-left: 10px; text-align: center; font-family: Verdana; width: 70px;">
                <asp:Label ID="lblTPI1Date" runat="server" Text="TPI 1 Date " />
            </td>
            <td>
                <asp:TextBox ID="txtTPI1Date" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" TargetControlID="txtTPI1Date" Format="dd/MM/yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
                <asp:CheckBox ID="chkTPI1" runat="server" />

            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="padding-left: 100px; text-align: right; font-family: Verdana; width: 250px;">
                <asp:Label ID="lblTPI2Activity" runat="server" Text="TPI 2 Activity " />
            </td>
            <td style="padding-left: 20px; width: 100px;">
                <%--<asp:TextBox ID="txtTPI2Activity" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkTPI2Activity" runat="server" />
            </td>
            <td style="padding-left: 20px; font-family: Verdana; text-align:right; width: 70px;">
                <asp:Label ID="lblNullDate4" runat="server" Text="Null Date " />
            </td>
            <td style="width: 50px;">
                <%--<asp:TextBox ID="txtNullDate5" runat="server"></asp:TextBox>--%>
                <asp:CheckBox ID="chkNullDate4" runat="server" />
            </td>
            <td style="padding-left: 10px; text-align: center; font-family: Verdana; width: 70px;">
                <asp:Label ID="lblTPI2Date" runat="server" Text="TPI 2 Date " />
            </td>
            <td>
                <asp:TextBox ID="txtTPI2Date" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" TargetControlID="txtTPI2Date" Format="dd/MM/yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
                <asp:CheckBox ID="chkTPI2" runat="server"/>

            </td>
        </tr>
        <tr style="height: 40px;">
            <td colspan="5" style="text-align: right;">
                <%--<asp:Button ID="btnUpdate" runat="server" Text="Update" Width="100px" Height="27px" OnClick="btnUpdate_Click" />--%>
            </td>
            <td colspan="5" style="text-align: left; padding-left: 30px;">
                <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" Height="27px" OnClick="btnCancel_Click" />--%>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td colspan="1" style="text-align: right;">
                <asp:Label ID="lblReson" runat="server" Text="Reason"></asp:Label>
            </td>
            <td colspan="3" style="text-align: left;">
                <textarea id="txtReason" name="txtReason" runat="server" class="textBox" style="margin-left: 20px; width: 500px; height: 38px;" cols="20" rows="2"></textarea>
            </td>
            <td>
                <asp:CheckBox ID="chkReason" runat="server"/>                
                <asp:Button ID="Button1" runat="server" Text="Update" Width="100px" Height="27px" OnClick="btnUpdate_Click" />
            </td>
            <td>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Visible="false" ForeColor="Green" Text=""></asp:Label>
                <%--<asp:Button ID="Button2" runat="server" Text="Cancel" Width="100px" Height="27px" OnClick="btnCancel_Click" />--%>
            </td>
        </tr>
    </table>
    <div style="margin-top: 20px;">
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                    PagerStyle-CssClass="Grid_Pager" PageSize="5000" AllowSorting="true" OnSorting="GridView1_Sorting" RowStyle-CssClass="Grid_Record"
                    AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <input type="checkbox" id="chkAll" name="chkAll" onclick="checkAll(this)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" class="checkAll" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                                <input id="hidCustomerName" value='<%# Eval("CustomerName") %>' type="hidden" runat="server" />
                                <input id="hidOrderNo" value='<%# Eval("OrderNo") %>' type="hidden" runat="server" />
                                <input id="hidPos" value='<%# Eval("Pos") %>' type="hidden" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Name" ItemStyle-HorizontalAlign="Center" SortExpression="CustomerName">
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order No" ItemStyle-HorizontalAlign="Center" SortExpression="OrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pos" ItemStyle-HorizontalAlign="Center" SortExpression="Pos">
                            <ItemTemplate>
                                <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Center" SortExpression="Item">
                            <ItemTemplate>
                                <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" SortExpression="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Original Prom Date" ItemStyle-HorizontalAlign="Center" DataField="OriginalPromDate" SortExpression="OriginalPromDate" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>

                        <%--  <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="Center" SortExpression="OrderQty">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Balance Qty" ItemStyle-HorizontalAlign="Center" SortExpression="BalanceQty">
                            <ItemTemplate>
                                <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalanceQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Planned Release Date" ItemStyle-HorizontalAlign="Center" DataField="PlannedReleaseDate" SortExpression="PlannedReleaseDate" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Receipt Activity" ItemStyle-HorizontalAlign="Center" SortExpression="ReceiptActivity">
                            <ItemTemplate>
                                <asp:Label ID="lblReceiptActivity" runat="server" Text='<%# Eval("ReceiptActivity") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Machining Activity" ItemStyle-HorizontalAlign="Center" SortExpression="MachiningActivity">
                            <ItemTemplate>
                                <asp:Label ID="lblMachiningActivity" runat="server" Text='<%# Eval("MachiningActivity") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Assembly Activity" ItemStyle-HorizontalAlign="Center" SortExpression="AssemblyActivity">
                            <ItemTemplate>
                                <asp:Label ID="lblAssemblyActivity" runat="server" Text='<%# Eval("AssemblyActivity") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TPI_1Activity" ItemStyle-HorizontalAlign="Center" SortExpression="TPI_1Activity">
                            <ItemTemplate>
                                <asp:Label ID="lblTPI_1Activity" runat="server" Text='<%# Eval("TPI_1Activity") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TPI_2Activity" ItemStyle-HorizontalAlign="Center" SortExpression="TPI_2Activity">
                            <ItemTemplate>
                                <asp:Label ID="lblTPI_2Activity" runat="server" Text='<%# Eval("TPI_2Activity") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Material Receipt Date" ItemStyle-HorizontalAlign="Center" DataField="MaterialReceiptDate" SortExpression="MaterialReceiptDate" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Machining Completion Date" ItemStyle-HorizontalAlign="Center" DataField="MachiningCompletionDate" SortExpression="MachiningCompletionDate" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Assembly Release Date" ItemStyle-HorizontalAlign="Center" DataField="AssemblyReleaseDate" SortExpression="AssemblyReleaseDate" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="TPI_1Date" ItemStyle-HorizontalAlign="Center" DataField="TPI_1Date" SortExpression="TPI_1Date" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="TPI_2Date" ItemStyle-HorizontalAlign="Center" DataField="TPI_2Date" SortExpression="TPI_2Date" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="False">
                            <ItemStyle Wrap="false" />
                            <%--                            --%><ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>



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
