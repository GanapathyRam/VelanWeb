<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePrimaryBoxEntry.aspx.cs" MasterPageFile="~/VV.Master" Inherits="VV.UpdatePrimaryBoxEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function OpenWindowForSticker() {
            window.open("PrimaryBoxNoForPrint.aspx");
        }
        function OpenWindowForDocPageOne() {
            window.open("DocPageOne.aspx");
        }
        function OpenWindowForDocPageThree() {
            window.open("DocPageThree.aspx");
        }
    </script>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="20%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View Primary Box Items" />
            </td>
            <%--Added by Arun on 26-Dec'07.
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif"
                            EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td width="70%" align="left" style="padding-left: 100px;" class="secondLevelHeader">
                <%--Added by Arun to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:Label ID="lblPackingQty" runat="server" Text="Total Qty"></asp:Label>
                    <asp:TextBox ID="txtPackingQtyInput" runat="server" ToolTip="Enter Total Qty to be Searched" onKeyUp="ControlSearch(this)" />

                    <asp:Label ID="lblNumberOfBoxes" runat="server" Text="Number of Boxes"></asp:Label>
                    <asp:TextBox ID="txtNumberOfBoxes" runat="server" ToolTip="Enter Number of Boxes to be Searched" onKeyUp="ControlSearch(this)" />

                    <%--  <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" />--%>
                    <asp:Button ID="btnSearchBox" Style="font-style: normal;" runat="server" Width="90px" Height="25px" Text="Search" OnClick="btnSearchBox_Click" ToolTip="Click to Search Data" />
                    <asp:Button ID="btnUpdate" Style="font-style: normal;" runat="server" Width="90px" Height="25px" Text="Save" OnClick="btnUpdate_Click" ToolTip="Click to Update Data" />
                    <%--<asp:Button ID="buttonCancel" runat="server" CausesValidation="False" CssClass="buttonText" ToolTip="Cancel"
                        Text="Cancel" OnClick="buttonCancel_Click" />--%>
                    <asp:Button ID="btnCancel" Style="font-style: normal;" runat="server" CausesValidation="False" Width="90px" Height="25px" Text="Back" OnClick="btnCancel_Click" ToolTip="Click to Back to main screen." />
                </asp:Panel>
            </td>
        </tr>

        <%-- <tr>
            <td colspan="3" style="text-align: center;">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
        </tr>--%>
    </table>
    <div>
        <table>
            <tr>
                <td colspan="1">
                    <asp:Label ID="lblProdOrderNoLabel" runat="server" Style="padding-left: 10px;" Text="Prod Order No">
                    </asp:Label>&nbsp;
                    <asp:TextBox ID="txtProdOrderNoLabel" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td colspan="1" style="padding-left: 40px;">
                    <asp:Label ID="lblItemLabel" runat="server" Text="Item"></asp:Label>&nbsp;
                    <asp:TextBox ID="txtItemLabel" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td colspan="1" style="padding-left: 60px;">
                    <asp:Label ID="lblSoNoLabel" runat="server" Text="So No"></asp:Label>&nbsp;
                    <asp:TextBox ID="txtSoNoLabel" Enabled="false" runat="server"></asp:TextBox>

                </td>
                <td colspan="1" style="padding-left: 80px;">
                    <asp:Label ID="lblPosLabel" runat="server" Text="Pos"></asp:Label>&nbsp;
                    <asp:TextBox ID="txtPosLabel" Enabled="false" runat="server"></asp:TextBox>

                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center;">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
    <div style="margin-top: 10px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Style="margin-left: 10px; overflow-y:scroll;" Width="60%"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" PageSize="30" OnRowEditing="GridView1_RowEditing"
                    HeaderStyle-HorizontalAlign="Left" CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnRowUpdating="GridView1_RowUpdating"
                    RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                    CellPadding="3">
                    <Columns>

                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Primary Box No">
                            <ItemTemplate>
                                <%--<asp:TextBox ID="txtPrimaryBoxNo" runat="server" Enabled="true" Text='<%# Bind("PrimaryBoxNo") %>'> </asp:TextBox>--%>
                                <asp:Label ID="lblPrimaryBoxNo" runat="server" Text='<%# Eval("PrimaryBoxNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prod Order No">
                            <ItemTemplate>
                                <%--<asp:TextBox ID="txtPrimaryBoxNo" runat="server" Enabled="true" Text='<%# Bind("PrimaryBoxNo") %>'> </asp:TextBox>--%>
                                <asp:Label ID="lblProdOrderNo" runat="server" Text='<%# Eval("ProdOrderNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Body Heat No">
                            <ItemTemplate>
                                <asp:TextBox ID="txtBodyHeatNo" runat="server" Enabled="true" Text='<%# Bind("BodyHeatNo") %>'> </asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Bonnet Heat No">
                            <ItemTemplate>
                                <asp:TextBox ID="txtBonnetHeatNo" runat="server" Enabled="true" Text='<%# Bind("BonnetHeatNo") %>'> </asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Box Qty">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPackingQty" runat="server" Enabled="true" Text='<%# Bind("ValveBoxQty") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Valve Box Qty" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="txtValveBoxQty" runat="server" Enabled="true" Text='<%# Bind("ValveBoxQty") %>'> </asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Drg No">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDrgNo" runat="server" Enabled="true" Text='<%# Bind("DrgNo") %>'> </asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tag No">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTagNo" runat="server" Enabled="true" Text='<%# Bind("TagNo") %>'> </asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prod Release Qty" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblProdReleaseQty" runat="server" Text='<%# Eval("ProdReleaseQty") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" Visible="true">
                            <ItemTemplate>
                                <asp:Button ID="BtnPrint" runat="server" Text="Sticker"
                                    OnClick="BtnPrint_Click" OnClientClick="OpenWindowForSticker()"/>
                                <input id="hidPrimaryBoxNo" value='<%# Eval("PrimaryBoxNo") %>' type="hidden" runat="server" />
                                <input id="hidBoxQty" value='<%# Eval("ValveBoxQty") %>' type="hidden" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" Visible="true">
                            <ItemTemplate>
                                <asp:Button ID="BtnDocPage1" runat="server" Text="DOCPage1"
                                    OnClick="BtnDocPage1_Click" OnClientClick="OpenWindowForDocPageOne()"/>
                                <input id="hidPrimaryBoxNoDocPage1" value='<%# Eval("PrimaryBoxNo") %>' type="hidden" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" Visible="true">
                            <ItemTemplate>
                                <asp:Button ID="BtnDOCPage2" runat="server" Text="DOCPage2"
                                    OnClick="BtnDOCPage2_Click" OnClientClick="target ='_blank';"/>
                                <input id="hidPrimaryBoxNoDocPage2" value='<%# Eval("PrimaryBoxNo") %>' type="hidden" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" Visible="true">
                            <ItemTemplate>
                                <asp:Button ID="BtnDocPage3" runat="server" Text="DOCPage3"
                                    OnClick="BtnDocPage3_Click" OnClientClick="OpenWindowForDocPageThree()"/>
                                <input id="hidPrimaryBoxNoDocPage3" value='<%# Eval("PrimaryBoxNo") %>' type="hidden" runat="server" />
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
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
