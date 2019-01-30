<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSupplierUpdation.aspx.cs"
    MasterPageFile="~/VV.Master" Inherits="VV.LoginSupplierUpdation" EnableEventValidation="false" Culture="en-IN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        <%--function ControlSearch(text) {
            if (text.value.length > 0) {
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = false;
            }
            else {
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
        }

        function disableControl(chosenText) {
            if (chosenText.value == '0') {
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").value = "";
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").disabled = false;
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").disabled = true;
            }
            else if (chosenText.value == '--Remove Grouping--') {
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").value = "";
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").disabled = false;
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").disabled = true;
            }
            else {
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").value = "";
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").disabled = true;
                document.getElementById("<%=txtSupplierNameSearch.ClientID%>").disabled = true;
            }
    }--%>
    </script>
    <link href="CSS/Main.css" rel="stylesheet" />
    <%--<table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblSupplierName" Text="Supplier Name" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px; height: 40px;">
                <asp:TextBox ID="txtSupplierName" Height="15px" Style="height: 20px;" CssClass="textBox" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblRequiredFields" Text="Please Enter Supplier Name." Visible="false" ForeColor="Red" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                <div style="padding-left: 30px; margin-top: 10px;">
                    <asp:Button ID="btnSave" Style="font-style: normal;" runat="server" Width="90px" Height="30px" Text="Save" />
                    &nbsp;
        <asp:Button ID="btnClear" runat="server" Width="90px" Style="font-style: normal; font-weight: 10px;" Height="30px" Text="Clear" />
                </div>
            </td>
            <td style="text-align: left; font-size: medium; font-family: Verdana;">
                <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
    </table>--%>
    <div style="margin-left: 600px; text-align: center; font-family: Verdana;">
        <asp:Label ID="lblSupplierNameSearch" runat="server" Text="Supplier Name"></asp:Label>
        <asp:TextBox ID="txtSupplierNameSearch" Height="20px" Width="200px" runat="server" ToolTip="Enter Supplier Name to be Searched" onKeyUp="ControlSearch(this)" />
        &nbsp;<asp:Button ID="btnSearchBox" runat="server" Width="100px" Style="font-style: normal; font-weight: 10px;" Height="30px" Enabled="true" Text="Search" ToolTip="Click to Search Data" OnClick="btnSearchBox_Click" />
    </div>
    <asp:Label ID="lblMessage" CssClass="lblSuccessMessage" Style="text-align: center; color: green;" Visible="false" runat="server"></asp:Label>
    <div style="margin-top: 30px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="GridView1" Style="margin-left: 200px;" runat="server" Width="60%" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="10" DataKeyNames="UserName" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Center"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                    AutoGenerateEditButton="false" RowStyle-CssClass="Grid_Record"
                    EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>
                        <%--<asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <input id="hidUserId" value='<%# Eval("UserID") %>' type="hidden" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HiddenField ID="hidUserId" runat="server" Value='<%# Bind("UserID") %>' />
                                <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Supplier Name" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblSupplierName" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSupplierName" runat="server" Text='<%# Eval("SupplierName") %>'></asp:TextBox>
                            </EditItemTemplate>
                           <%-- <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />--%>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" ShowHeader="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <%--<ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />--%>
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


