<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="IPCheckListMaster.aspx.cs" Inherits="VV.IPCheckListMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblLocationCode" Text="Location Name" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 30px; width: 220px;">
                <%--<asp:TextBox ID="txtLocationCode" Height="15px" CssClass="textBox" MaxLength="2" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlLocationCode" AutoPostBack="true" OnSelectedIndexChanged="ddlLocationCode_SelectedIndexChanged"
                    DataTextField="LocationName" DataValueField="LocationCode" Width="140px" Height="25px" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblRequiredFields" Text="Please Select Location Name" Visible="false" ForeColor="Red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblSubLocationCode" Text="SubLocation Name" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 30px; width: 220px;">
                <%--<asp:TextBox ID="txtLocationCode" Height="15px" CssClass="textBox" MaxLength="2" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlSubLocationCode" AutoPostBack="true" OnSelectedIndexChanged="ddlSubLocationCode_SelectedIndexChanged"
                    DataTextField="SubLocationName" DataValueField="SubLocationCode" Width="140px" Height="25px" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblRequiredFields1" Text="Please Select Sub Location Name" Visible="false" ForeColor="Red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblCheckListSerial" Text="CheckList Description" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 30px; width: 220px;">
                <asp:DropDownList ID="ddlCheckListSerial" AutoPostBack="true" OnSelectedIndexChanged="ddlCheckListSerial_SelectedIndexChanged"
                    DataTextField="CheckListDescription" DataValueField="CheckListSerial" Width="140px" Height="25px" runat="server">
                </asp:DropDownList>
                <td>
                    <asp:Label ID="lblRequiredFields2" Text="Please Select CheckList Description" Visible="false" ForeColor="Red" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="margin-left: 100px; text-align: right; font-family: Verdana;">
                <asp:Label ID="lblLocationName" Text="Active" runat="server"></asp:Label></td>
            <td style="padding-left: 25px; width: 220px;">
                <asp:RadioButton ID="RadioButton1" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblPriority" Text="Priority" runat="server"></asp:Label></td>
            <td style="padding-left: 30px; width: 220px;">
                <asp:TextBox ID="txtPriority" MaxLength="2" Style="width: 70px; height: 18px;" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                    ControlToValidate="txtPriority" runat="server"
                    ErrorMessage="Only Numbers!"
                    ValidationExpression="^\d{2}$">
                </asp:RegularExpressionValidator>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div style="padding-left: 30px; margin-top: 5px;">
                    <asp:Button ID="btnSave" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Save" OnClick="btnSave_Click" />
                    &nbsp;
        <asp:Button ID="btnClear" runat="server" Width="90px" Style="font-style: normal; font-weight: 10px;" Height="30px" Text="Clear" OnClick="btnClear_Click" />
                </div>
            </td>
            <td style="text-align: left; font-size: 16px; font-family: Verdana;">
                <asp:Label ID="lblMessage" Style="font-size: 16px;" CssClass="lblSuccessMessage" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <div style="margin-left: 450px; margin-top: 10px; text-align: center; font-family: Verdana;">
        <asp:Label ID="lblLocationNameSearch" runat="server" Text="Location Name"></asp:Label>
        <asp:DropDownList ID="ddlLocationCodeGrid" OnSelectedIndexChanged="ddlLocationCode_SelectedIndexChanged"
            DataTextField="LocationName" DataValueField="LocationCode" Width="140px" Height="25px" runat="server">
        </asp:DropDownList>
        <%--<asp:TextBox ID="txtLocationNameSearch" Height="20px" Width="200px" runat="server" ToolTip="Enter SubLocation Name to be Searched" onKeyUp="ControlSearch(this)" />--%>
        <asp:Label ID="lblSubLocationCodeSearch" runat="server" Text="SubLocation Name"></asp:Label>
        <asp:DropDownList ID="ddlSubLocationCodeGrid" OnSelectedIndexChanged="ddlSubLocationCode_SelectedIndexChanged"
            DataTextField="SubLocationName" DataValueField="SubLocationCode" Width="140px" Height="25px" runat="server">
        </asp:DropDownList>
        <%--<asp:TextBox ID="txtSubLocationNameSearch" Height="20px" Width="200px" runat="server" ToolTip="Enter SubLocation Name to be Searched" onKeyUp="ControlSearch(this)" />--%>
        &nbsp;<asp:Button ID="btnSearchBox" runat="server" Width="100px" Style="font-style: normal; height: 27px; font-weight: 10px;" Height="30px" Enabled="true" OnClick="btnSearchBox_Click" Text="Search" ToolTip="Click to Search Data" />
        &nbsp;&nbsp;
    </div>
    <div style="margin-top: 30px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <div style="margin-left: auto; margin-right: auto;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="SubLocationCode" AllowPaging="true" PageSize="24"
                        OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Left" OnRowDataBound="GridView1_RowDataBound"
                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                        AutoGenerateEditButton="true" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display" AutoGenerateDeleteButton="true"
                        CellPadding="3">
                        <Columns>
                            <asp:TemplateField HeaderText="Location Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnLocationCode" runat="server" Value='<%#Bind("LocationCode") %>' />
                                    <asp:Label ID="lblLocationCode" runat="server" Text='<%# Eval("LocationName")%>'></asp:Label>
                                </ItemTemplate>
                                <%--  <EditItemTemplate>
                                    <asp:HiddenField ID="hdnLocationCode" runat="server" Value='<%#Eval("LocationCode") %>' />
                                    <asp:DropDownList ID="ddlLocationCodeGrid" Width="150px" runat="server"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </EditItemTemplate>--%>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SubLocation Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnSubLocationCode" runat="server" Value='<%#Bind("SubLocationCode") %>' />
                                    <asp:Label ID="lblSubLocationCode" runat="server" Text='<%# Eval("SubLocationName")%>'></asp:Label>
                                </ItemTemplate>
                                <%--  <EditItemTemplate>
                                    <asp:HiddenField ID="hdnSubLocationCode" runat="server" Value='<%#Eval("SubLocationCode") %>' />
                                    <asp:DropDownList ID="ddlSubLocationCodeGrid" Width="150px" runat="server"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </EditItemTemplate>--%>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description" ItemStyle-Wrap="true">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnCheckListSerial" runat="server" Value='<%#Bind("CheckListSerial") %>' />
                                    <asp:Label ID="lblCheckListSerial" runat="server" Text='<%# Eval("CheckListDescription")%>'></asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:HiddenField ID="hdnCheckListSerial" runat="server" Value='<%#Eval("CheckListSerial") %>' />
                                    <asp:DropDownList ID="ddlCheckListSerialGrid" Width="150px" runat="server"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </EditItemTemplate>--%>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Active">
                                <ItemTemplate>
                                    <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="hdnActive" runat="server" Value='<%#Eval("Active") %>' />
                                    <asp:DropDownList ID="ddlActiveGrid" Width="150px" runat="server"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Priority">
                                <ItemTemplate>
                                    <asp:Label ID="lblPriortyGrid" runat="server" Text='<%# Eval("Priority") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="hdnPriority" runat="server" Value='<%#Eval("Priority") %>' />
                                    <asp:TextBox ID="txtGridPriority" MaxLength="2" Text='<%# Eval("Priority") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
