<%@ Page Title="Delivery Challan Receipts" MasterPageFile="~/VV.Master" Culture="en-IN" Language="C#" AutoEventWireup="true"
    CodeBehind="DeliveryChallanReceipts.aspx.cs" EnableEventValidation="false" Inherits="VV.DeliveryChallanReceipts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; line-height: normal;">
        <div style="margin-left:900px; font-family: Verdana; margin-top:10px;">
            <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Text="* fields are mandatory message"></asp:Label>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" width="80%" style="margin-top: 20px; margin-left: 40px;">
            <tr style="height: 40px;">
                <td style="text-align: right; font-family: Verdana;">
                    <asp:Label ID="lblDcNumber" Text="Vendor DC Number" runat="server"></asp:Label>
                </td>
                <td style="width: 220px;">
                    <asp:TextBox ID="txtDcNumber" Height="15px" Width="185px" runat="server"></asp:TextBox></td>
                <td style="width: 1%">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Bold="true" Visible="true" ControlToValidate="txtDcNumber" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    <asp:Label ID="lblRequiredFields" Text="*" Font-Bold="true" Visible="true" ForeColor="Red" runat="server"></asp:Label>
                </td>
                <td style="text-align:right;">
                    <asp:Label ID="lblDcDate" Text="Vendor DC Date" runat="server"></asp:Label>
                </td>
                <td style="width: 220px;">
                    <asp:TextBox ID="txtDcDate" Height="15px" Style="margin-right: 70px; margin-left:10px; width: 185px;" runat="server"></asp:TextBox>
                     <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDcDate" Format="dd/MM/yyyy" runat="server">
                    </ajaxToolkit:CalendarExtender>
                </td>
                <td style="width: 1%">
                </td>
            </tr>
            <tr style="height: 40px;">
                <td style="text-align: right; font-family: Verdana; width: 300px;">
                    <asp:Label ID="lblVendorName" Text="Received Date" runat="server"></asp:Label>
                </td>
                <td style="width: 220px;">
                    <asp:TextBox ID="txtReceivedDate" Height="15px" Width="185px" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtReceivedDate" Format="dd/MM/yyyy" runat="server">
                    </ajaxToolkit:CalendarExtender>
                </td>
                <td style="width: 1%"></td>
                <td style="text-align:right;">
                    <asp:Label ID="lblRequestedBy" Text="Received By" runat="server"></asp:Label>
                </td>
                <td style="width: 220px;">
                    <asp:DropDownList ID="ddlReceiveddBy" Style="margin-right: 70px; margin-left:10px; height: 21px; width: 185px;" DataTextField="EmployeeName" DataValueField="EmployeeCode" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr style="height: 40px;">
                <td style="text-align: right; font-family: Verdana; width: 300px;">
                    <asp:Label ID="lblVendor" Text="Vendor" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlVendor" DataTextField="VendorName" DataValueField="VendorCode" Style="width: 185px; height:21px;" AutoPostBack="true" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged" runat="server"></asp:DropDownList></td>
                <td style="width: 1%"></td>
            </tr>
        </table>        
        <div style="text-align: center;">
            <asp:Label ID="lblMessage" runat="server" Style="font-family: Arial; font-size:small;" ForeColor="Green" Font-Bold="true" Text=""></asp:Label>
        </div>
        <div style="margin-left: 50%;">
            <asp:Button ID="btnSearch" runat="server" Visible="false" Style="font-style: normal;" Width="100px" Height="30px" Text="Search" OnClick="btnSearch_Click" />
            &nbsp;
            <asp:Button ID="btnUpdate" runat="server" Style="font-style: normal;" Width="100px" Height="30px" Text="Update" OnClick="btnUpdate_Click" />
            &nbsp;
            <%--<asp:Button ID="btnAddItem" runat="server" Style="width: 70px; height: 30px;" Text="Add" OnClick="btnAddItem_Click" />--%>
        </div>
        <div style="margin-top: 10px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" ShowFooter="true"
                        CssClass="Grid" HeaderStyle-CssClass="Grid_Header" DataKeyNames="SLNo"
                        PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                        CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="SL.No">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Bind("SLNo") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="DC Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblDCNumber" Text='<%# Bind("DCNumber") %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="DC Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDCDate" Text='<%# Bind("DCDate") %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Item Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemDescription" Text='<%# Bind("ItemDescription") %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Units">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnits" Text='<%# Bind("Units") %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblQtySend" Text='<%# Bind("QtySend") %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Quantity Already Received">
                                <ItemTemplate>
                                    <asp:Label ID="lblQtyAlreadyReceived" Text='<%# Bind("QtyReceived") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Quantity Balance">
                                <ItemTemplate>
                                    <asp:Label ID="lblQtyBalance" Text='<%# Bind("QtyBalance") %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Quantity Received">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReceived" runat="server" AutoPostBack="false" OnTextChanged="txtReceived_TextChanged" Text='<%# Bind("NewReceivedQty") %>'> </asp:TextBox>
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
