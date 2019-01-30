<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="DCReports.aspx.cs"
    EnableEventValidation="false" Inherits="VV.DCReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=1100,width=900');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <link href="CSS/Main.css" rel="stylesheet" />
    <div style="text-align: right;">
        <asp:Button ID="btnPrint" Width="100px" Height="30px" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
    </div>
    <asp:Panel ID="pnlContents" runat="server">
        <asp:Panel ID="Panel1" runat="server" Style="display: inline;">
            <table border="0" cellpadding="0" cellspacing="0"  style="margin-top: 0px;width:100%">
                <tr style="height: 30px;">
                    <td  style="text-align: center; font-size: medium;width:30%">
                        <img id="IMG1" align="center" alt="Company Logo"
                            src="Images/logo_velan.png" style="cursor: pointer; width: 167px; height: 39px" />
                    </td>
                    <td colspan="5" style="text-align: left; font-size: small;">
                        <asp:Label ID="lblVelanName" runat="server" Text="Label"></asp:Label><br />
                        <asp:Label ID="lblVelanAddress1" runat="server" Text="Label"></asp:Label><br />
                        <asp:Label ID="lblVelanAddress2" runat="server" Text="Label"></asp:Label><br />
                        <asp:Label ID="lblVelanAddress3" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lblVelanWebsite" runat="server" Text="Label"></asp:Label><br />
                        <asp:Label ID="lblVelanCSTAndTINNo" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                </table>
            <table>
                <tr style="height: 20px;">
                    <td colspan="5">
                        <hr style="color: #1567A1" />
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td colspan="5" style="text-align: center; font-size: medium;text-decoration:underline">
                        <asp:Label ID="lblHeader" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 10px;">
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td style="text-align: left; width:25%">
                        <asp:Label ID="lblDcNumber" Text="Delivery Challan No :" runat="server"></asp:Label>
                    </td>
                    <td style="text-align:left; width: 220px;">
                        <asp:Label ID="lbldcnumber1" Height="15px" CssClass="textBox" Text="" runat="server"></asp:Label></td>
                    <td style="padding-left: 10px; text-align: right; width: 220px;">
                        <asp:Label ID="lblDcDate" Text="Date :" runat="server"></asp:Label>
                    </td>
                    <td style="padding-left: 10px; width: 220px;">
                        <asp:Label ID="lbldcdate1" Height="15px" CssClass="textBox" Text="" runat="server"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 20px;">
                    <td></td>
                </tr>
                <tr style="height: 30px;">
                    <td style="text-align: left;">
                        <asp:Label ID="lblconsignee" Text="Consignee           :" runat="server"></asp:Label>
                    </td>
                    <td style="width: 1000px;">
                        <asp:Label ID="lblconsignee1" Height="15px" CssClass="textBox" Text="" runat="server"></asp:Label>
                    </td>
                    <td colspan="3"></td>
                </tr>
                <tr style="height: 30px;">
                    <td style="text-align: left;">
                        <asp:Label ID="lblconsigneeaddress" Text="Consignee Address :" runat="server"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 1000px;">
                        <asp:Label ID="lblconsigneeaddress1" Height="15px" CssClass="textBox" Text="" runat="server"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                </tr>
                <tr style="height: 30px;">
                    <td style="padding-left: 80px; text-align: right; width: 300px;">&nbsp;</td>
                    <td colspan="3" style="width: 1000px;">
                        <asp:Label ID="lbladdress2address3" Height="15px" CssClass="textBox" Text="" runat="server"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                </tr>
                <tr style="height: 30px;">
                    <td style="padding-left: 80px; text-align: right; width: 300px;">&nbsp;</td>
                    <td colspan="3" style="width: 1000px;">
                        <asp:Label ID="lblcitystatepin" Height="15px" CssClass="textBox" Text="" runat="server"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                </tr>
                <tr style="height: 20px;">
                    <td></td>
                </tr>
                <tr style="height: 30px;">
                   <%-- <td style="text-align: right; width: 300px;">
                        <asp:Label ID="lbltinno" Text="TIN NO :" runat="server"></asp:Label>
                    </td>
                    <td style="width: 220px;">
                        <asp:Label ID="lbltinno1" Height="15px" CssClass="textBox" Text="" runat="server"></asp:Label></td>--%>
                    <td style="text-align: left; width:25%">
                        <asp:Label ID="lblcstno" Text="Supplier GST No :" runat="server"></asp:Label>
                    </td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblcstno1" Height="15px" CssClass="textBox" Text="" runat="server"></asp:Label>
                    </td>
                    <td></td>
                </tr>
            </table>

            <div style="margin-top: 10px;">
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                <ContentTemplate>--%>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                    PageSize="10" CssClass="Grid" HeaderStyle-CssClass="Grid_Header" DataKeyNames="SLNo"
                    OnRowDataBound="GridView1_RowDataBound"
                    PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                    CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.No">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Bind("SlNo") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="400px" HeaderText="Item Description">
                            <ItemTemplate>
                                <asp:Label ID="lblitemdescription" Width="430px" runat="server" Text='<%# Bind("ItemDescription") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Units">
                            <ItemTemplate>
                                <asp:Label ID="lblunits" Width="60px" runat="server" Text='<%# Bind("Units") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" Visible="false" HeaderText="QtyReceived">
                            <ItemTemplate>
                                <asp:Label ID="lblquantityreceived" Width="130px" runat="server" Text='<%# Bind("QuantityReceived") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="400px" HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblquantitysend" Width="60px" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 20px;">
                <tr style="height: 30px;">
                    <td colspan="1" style=" text-align:left;">
                        <asp:Label ID="lblReasonForSend" Text="Reason for Sending Outside :" runat="server"></asp:Label>
                    </td>
                    <td colspan="3" style="text-align:left; margin-left:10px;">
                        <asp:Label ID="lblReasonForSend1" style="margin-left:10px;" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <%--<tr style="height: 40px;">
                    <td colspan="4" style="padding-left: 10px; font-family: Verdana; width: 220px;">
                        <asp:Label ID="lblReasonForSend1" Style="margin-left: 250px" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
                <tr style="height: 30px;">
                    <td colspan="5"></td>
                </tr>
                <tr style="height: 30px;">
                    <td colspan="5"></td>
                </tr>
                <tr style="height: 30px;">
                    <td colspan="5"></td>
                </tr>
                <tr style="height: 30px;">
                    <td colspan="5"></td>
                </tr>
                <tr style="height: 30px;">
                    <td style="text-align: left; width: 350px;">
                        <asp:Label ID="lblrequestedBy" Text="Requested By :" runat="server"></asp:Label>
                    </td>
                    <td style="text-align: left; width: 350px;">
                        <asp:Label ID="lblpreparedBy" Text="Prepared By :" runat="server"></asp:Label>
                    </td>
                    <td style="text-align: left; width: 350px;">
                        <asp:Label ID="lblapprovedBy" Text="Approved By :" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td style="text-align: left; width: 350px;">
                        <asp:Label ID="lblrequestedBy1" Style="text-align: center;" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="text-align: left; width: 350px;">
                        <asp:Label ID="lblpreparedBy1" Style="text-align: center;" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="text-align: left; width: 350px;">
                        <asp:Label ID="lblapprovedBy1" Style="text-align: center" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
    <br />

    <%-- </form>--%>
</asp:Content>
