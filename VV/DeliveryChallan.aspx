<%@ Page Title="Delivery Challan" Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" Culture="en-IN" CodeBehind="DeliveryChallan.aspx.cs"
    Inherits="VV.DeliveryChallan" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="text-align: center; background-color: #D99694; line-height: normal;">
        <div style="text-align: center; margin-left: 800px;">
            <asp:Button ID="btnAdd" Style="font-style: normal;" runat="server" Width="100px" Height="30px" Text="Add" OnClick="btnAdd_Click" />
            &nbsp;
        <asp:Button ID="btnEdit" runat="server" Width="100px" Style="font-style: normal; font-weight: 10px;" Height="30px" Text="Edit" OnClick="btnEdit_Click" />
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Style="display: inline;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
            <tr style="height: 40px;">
                <td style="padding-left: 420px; text-align: right; width: 180px;" colspan="2">
                    <asp:Label ID="lblDcType" Text="DC Type" runat="server"></asp:Label>
                </td>
                <td style="padding-left: 10px; width: 220px;">
                    <asp:DropDownList ID="ddlDcType" Style="margin-left: 10px; width: 180px; text-align: center; height: 21px;" DataTextField="DCType" DataValueField="DCCode" runat="server" OnSelectedIndexChanged="ddlDcType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblDcTypeErrorMsg" ForeColor="Red" Visible="false" runat="server" Text="Please Select DC Type"></asp:Label>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                    <asp:Label ID="lblDcNumber" Text="DC Number" runat="server"></asp:Label>
                </td>
                <td style="padding-left: 10px; width: 220px;">
                    <asp:TextBox ID="txtDcNumber" Height="15px" CssClass="textBox" ReadOnly="true" runat="server"></asp:TextBox></td>
                <td style="padding-left: 10px; text-align: right; width: 220px;">
                    <asp:Label ID="lblDcDate" Text="DC Date" runat="server"></asp:Label>
                </td>
                <td style="padding-left: 10px; width: 220px;">
                    <asp:TextBox ID="txtDcDate" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
                </td>
                <%-- <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDcDate" Format="dd/MM/yyyy" runat="server">
                    </ajaxToolkit:CalendarExtender>
                </td>--%>
            </tr>
            <tr style="height: 40px;">
                <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                    <asp:Label ID="lblVendorName" Text="Vendor Name" runat="server"></asp:Label>
                </td>
                <td style="padding-left: 10px; width: 220px;">
                    <asp:DropDownList ID="ddlVendorName" Style="margin-left: 20px; width: 185px; height: 21px;" DataTextField="VendorName" DataValueField="VendorCode" runat="server"></asp:DropDownList>
                </td>
                <td style="padding-left: 10px; text-align: right; width: 220px;">
                    <asp:Label ID="lblRequestedBy" Text="Requested By" runat="server"></asp:Label>
                </td>
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <td style="padding-left: 10px; width: 220px;">
                            <asp:DropDownList ID="ddlRequestedBy" OnSelectedIndexChanged="ddlRequestedBy_SelectedIndexChanged" AutoPostBack="true" Style="margin-left: 20px; width: 185px; height: 21px;" DataTextField="EmployeeName" DataValueField="EmployeeCode" runat="server"></asp:DropDownList>
                        </td>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <td></td>
            </tr>
            <tr style="height: 40px;">

                <td style="padding-left: 80px; text-align: right; font-family: Verdana; width: 300px;">
                    <asp:Label ID="lblPreparedBy" Text="Prepared By" runat="server"></asp:Label>
                </td>
                <td style="padding-left: 10px; width: 220px;">
                    <asp:DropDownList ID="ddlPreparedBy" Style="margin-left: 20px; width: 185px; height: 21px;" DataTextField="EmployeeName" DataValueField="EmployeeCode" runat="server"></asp:DropDownList></td>
                <td style="padding-left: 10px; text-align: right; width: 220px;">
                    <asp:Label ID="lblReason" Text="Reason" runat="server"></asp:Label>
                </td>
                <td style="padding-left: 10px; width: 220px;">
                    <asp:TextBox ID="txtReason" Style="margin-left: 20px;" TextMode="MultiLine" runat="server" Width="183px"></asp:TextBox>
                    <%--<textarea id="txtAreaForReason" name="txtAreaForReason" runat="server" class="textBox" style="margin-left: 20px;" cols="20" rows="2"></textarea>--%>
                </td>
                <td></td>
            </tr>
        </table>

        <div style="margin-top: 10px;">
            <asp:UpdatePanel ID="EmployeePanel" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="10" ShowFooter="true" AutoPostback="false"
                        CssClass="Grid" HeaderStyle-CssClass="Grid_Header" DataKeyNames="SLNo"
                        OnRowDeleting="GridView1_RowDeleting" AutoGenerateDeleteButton="True"
                        PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record"
                        EmptyDataText="No Records To Display"
                        CellPadding="3">
                        <Columns>
                            <asp:TemplateField HeaderText="SL.No">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Bind("SlNo") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="400px" HeaderText="Item Description">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtItemDescription" Width="300px" runat="server" Text='<%# Bind("ItemDescription") %>'> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Units">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlForUnits" Style="width: 60px;" DataTextField="Units" DataValueField="Id" Width="100px" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" HeaderText="QtyReceived">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReceived" Width="130px" runat="server" Text='<%# Bind("QuantityReceived") %>'> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="400px" HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQty" Style="width: 60px;" Enabled="true" AutoPostBack="false" OnTextChanged="txtQty_TextChanged" runat="server" Text='<%# Bind("Quantity") %>'> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="400px" HeaderText="Rate">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRate" Style="width: 60px;" Enabled="true" AutoPostBack="false" OnTextChanged="txtRate_TextChanged" runat="server" Text='<%# Bind("Rate") %>'> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                                <FooterStyle HorizontalAlign="Right" />
                                <FooterTemplate>
                                    <asp:Button ID="ButtonAdd" OnClick="ButtonAdd_Click" Width="100px" Height="25px" runat="server"
                                        Text="Add New Row" />
                                </FooterTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="text-align: center;">
            <asp:Label ID="lblMessage" runat="server" Style="font-family: Arial; font-size: small;" ForeColor="Green" Font-Bold="true" Text=""></asp:Label>
        </div>
        <div style="margin-left: 70%;">
            <asp:Button ID="btnSearch" runat="server" Style="width: 70px; height: 30px;" Text="Search" OnClick="btnSearch_Click" />
            &nbsp;
            <asp:Button ID="btnUpdate" runat="server" Style="width: 70px; height: 30px;" Text="Update" OnClick="btnUpdate_Click" />
            &nbsp;
            <asp:Button ID="btnAddItem" runat="server" Style="width: 70px; height: 30px;" Text="Add" OnClick="btnAddItem_Click" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" Style="width: 70px; height: 30px;" Text="Cancel" OnClick="btnCancel_Click" />
            &nbsp;
            &nbsp;<asp:Button ID="btnPrint" runat="server" Style="width: 70px; height: 30px;" Text="Print" OnClick="btnPrint_Click" />
        </div>
    </asp:Panel>
</asp:Content>

