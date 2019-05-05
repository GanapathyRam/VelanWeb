<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" EnableEventValidation="false" CodeBehind="IPSubLocationMaster.aspx.cs" Inherits="VV.IPSubLocationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblLocationCode" Text="Location Code" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 30px; width: 220px;">
                <%--<asp:TextBox ID="txtLocationCode" Height="15px" CssClass="textBox" MaxLength="2" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlLocationCode" AutoPostBack="true" OnSelectedIndexChanged="ddlLocationCode_SelectedIndexChanged"
                    DataTextField="LocationCode" DataValueField="LocationCode" Width="140px" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblRequiredFields" Text="Please Enter Sub Location Code" Visible="false" ForeColor="Red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblSubLocationCode" Text="Sub Location Code" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtSubLocationCode" Height="15px" CssClass="textBox" MaxLength="2" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblRequiredFields1" Text="Please Enter Sub Location Code" Visible="false" ForeColor="Red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="margin-left: 100px; text-align: right; font-family: Verdana;">
                <asp:Label ID="lblLocationName" Text="Sub Location Name" runat="server"></asp:Label></td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtSubLocationName" Height="15px" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblRequiredFields2" Text="Please Enter Sub Location Name" Visible="false" ForeColor="Red" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div style="padding-left: 30px; margin-top: 10px;">
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
    <div style="margin-left: 800px; text-align: center; font-family: Verdana;">
        <asp:Label ID="lblLocationNameSearch" runat="server" Text="Sub Location Name"></asp:Label>
        <asp:TextBox ID="txtSubLocationNameSearch" Height="20px" Width="200px" runat="server" ToolTip="Enter Sub Location Name to be Searched" onKeyUp="ControlSearch(this)" />
        &nbsp;<asp:Button ID="btnSearchBox" runat="server" Width="100px" Style="font-style: normal; height: 27px; font-weight: 10px;" Height="30px" Enabled="true" OnClick="btnSearchBox_Click" Text="Search" ToolTip="Click to Search Data" />
        &nbsp;&nbsp;
    </div>
    <div style="margin-top: 30px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <div style="width: 600px; margin-left: auto; margin-right: auto;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="SubLocationCode" AllowPaging="true" PageSize="24"
                        OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Left" OnRowDataBound="GridView1_RowDataBound"
                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                        AutoGenerateEditButton="true" RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                        CellPadding="3">
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SubLocation Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubLocationCode" runat="server" Text='<%# Eval("SubLocationCode") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SubLocation Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubLocationName" runat="server" Text='<%# Eval("SubLocationName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSubLocationName" runat="server" Enabled="true" Text='<%# Bind("SubLocationName") %>'> </asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Wrap="false" />
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblLocationCode" runat="server" Text='<%# Eval("LocationCode")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="hdnLocationCode" runat="server" Value='<%#Eval("LocationCode") %>' />
                                    <asp:DropDownList ID="ddlLocationCodeGrid" Width="150px" runat="server"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </EditItemTemplate>
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
