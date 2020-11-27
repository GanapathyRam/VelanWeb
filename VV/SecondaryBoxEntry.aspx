<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" Culture="en-IN" CodeBehind="SecondaryBoxEntry.aspx.cs" Inherits="VV.SecondaryBoxEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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


    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="20%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View Secondary Box Items" />
            </td>

            <td class="secondLevelHeader" style="text-align: center;" width="40%">
                <asp:Label ID="lblSecondaryBoxNo" runat="server" Style="text-align: center;" Text="Secondary Box No:" />
                &nbsp;<asp:TextBox ID="txtSecondaryBoxNo" Enabled="false" runat="server"></asp:TextBox>
            </td>

            <td width="70%" align="left" style="padding-left: 100px;" class="secondLevelHeader">
                <%--Added by Arun to implement the search on pressing enter itslef--%>

                <asp:Button ID="btnSave" Style="font-style: normal;" runat="server" Width="90px" Height="25px" Text="Save" OnClick="btnSave_Click" ToolTip="Click to Save Data" />
                <%--<asp:Button ID="btnCancel" Style="font-style: normal;" runat="server" Width="90px" Height="25px" Text="Cancel" OnClick="btnCancel_Click" ToolTip="Click to Cancel Data" />--%>

            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center;">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <table style="height: 100%; margin-top: 20px; padding-left: 150px;" width="85%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">
                <%--Added by Arun on 26-Dec'07.
                 Implemeted the Update Panel, so as to avoid showing the flickering, when any operations are done --%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                    <%--<Triggers>
                        <asp:AsyncPostBackTrigger />
                    </Triggers>--%>
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
                            PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                            CellPadding="3">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Select">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="CheckSingleCheckbox(this)" />
                                        <input id="hidRemarksId" value='<%# Eval("PrimaryBoxNo") %>' type="hidden" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Primary Box No" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <div style="text-align: left;">
                                            <asp:Label ID="lblPrimaryBoxNo" Width="20px" runat="server" Text='<%# Eval("PrimaryBoxNo") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Primary Box Qty" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <div style="text-align: left;">
                                            <asp:Label ID="lblPrimaryBoxQty" runat="server" Text='<%# Eval("PrimaryBoxQty") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Created On" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <div style="text-align: left;">
                                            <asp:Label ID="lblCreatedOn" Width="20px" runat="server" Text='<%# Eval("CreatedOn") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Prod Order No" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <div style="text-align: left;">
                                            <asp:Label ID="lblProdOrderNo" Width="30px" runat="server" Text='<%# Eval("ProdOrderNo") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Order No" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <div style="text-align: left;">
                                            <asp:Label ID="lblOrderNum" Width="30px" runat="server" Text='<%# Eval("OrderNum") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Pos" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <div style="text-align: left;">
                                            <asp:Label ID="lblPos" Width="20px" runat="server" Text='<%# Eval("Pos") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <div style="text-align: left;">
                                            <asp:Label ID="lblItem" Width="50px" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>

                                <%--<asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>--%>
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
            </td>
        </tr>
    </table>
</asp:Content>
