<%@ Page Title="View Prod Completion" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="ViewProdCompletion.aspx.cs" Inherits="VV.ViewProdCompletion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<link type="text/css" rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>--%>
    <script language="javascript" type="text/javascript">

        /*Bulk Update
         * Added by Arun on 19-Mar-2008
         * Function will enable the Search Button, only if a minimum of 3 characters are entered in the search text box. 
         * If given less, then it will disable the search button
        */
        function ControlSearch(text) {
            if (text.value.length > 0) {
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = false;
            }
            else {
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
        }

        function disableControl(chosenText) {
            //alert(chosenText.value);
            if (chosenText.value == '0') {
                document.getElementById("<%=txtProdOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtProdOrderNo.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else if (chosenText.value == '--Remove Grouping--') {
                document.getElementById("<%=txtProdOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtProdOrderNo.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else {
                document.getElementById("<%=txtProdOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtProdOrderNo.ClientID%>").disabled = true;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
    }

    function Redirect() {
        window.location = "ViewProdCompletion.aspx";
    }
    </script>
    <%--  <div>
        <asp:Label ID="lblMessage" Visible="true" Style="text-align: left;" runat="server"></asp:Label>
    </div>--%>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="15%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View Production Completion" />
            </td>

            <%--Added by Arun on 26-Dec'07.
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif" EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td width="75%" align="right" style="padding-left: 200px;" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                    <asp:Label ID="lblPopupName" Text="Bulk Update" runat="server" CssClass="secondLevelHeader"></asp:Label>
                    <iframe style="width: 350px; height: 230px;" id="irm1" src="BulkProdCompletion.aspx" runat="server"></iframe>
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Close" CssClass="buttonText" OnClientClick="Redirect();" />
                </asp:Panel>
                <%--<asp:Button ID="Button1" runat="server" Text="Bulk Update" CssClass="buttonText"/>--%>

                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="Background">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:Button ID="Button1" runat="server" Text="Bulk Update" CssClass="buttonText" />
                    <asp:TextBox ID="txtFigNo" runat="server" ToolTip="Enter Figure No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:TextBox ID="txtProdOrderNo" runat="server" ToolTip="Enter Prod Order No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" />
                    <asp:Label ID="lblMessage" Visible="false" Style="text-align: left;" runat="server"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <%--Added by Arun on 26-Dec'07.
                 Implemeted the Update Panel, so as to avoid showing the flickering, when any operations are done --%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit" AllowPaging="true" PageSize="30" OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                            PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                            CellPadding="3">
                            <Columns>
                                <asp:TemplateField HeaderText="Prod Order No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdOrderNo" runat="server" Text='<%# Eval("ProdOrderNo") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--<ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Serial No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNo") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text='<%# Eval("BalanceQty") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order No">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblOrderNo" Text='<%# Eval("OrderNum") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Line #">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblLineNo" Text='<%# Eval("LineNum") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="70px" />
                                    <HeaderStyle Width="70px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPos" Text='<%# Eval("Pos") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="60px" />
                                    <HeaderStyle Width="60px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fig No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFigNo" runat="server" Text='<%# Eval("FigNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Descr") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Released On">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReleasedOn" runat="server" Text='<%# Bind("CreatedOn", "{0:dd-MM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prod Committed Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdDeliveryDate" runat="server" Text='<%# Eval("ProdDeliveryDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtProdDeliveryDate" runat="server" Text='<%# Eval("ProdDeliveryDate").ToString() == "" ? Eval("ProdDeliveryDate") : Convert.ToDateTime(Eval("ProdDeliveryDate")).ToString("dd-MM-yyyy") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="dateValidator1" runat="server" ControlToValidate="txtProdDeliveryDate"
                                            ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[-](0?[1-9]|1[012])[-]\d{4}$"
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comp Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdComplDate" runat="server" Text='<%# Eval("ProdComplDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtProdComplDate" runat="server" Text='<%# Eval("ProdComplDate").ToString() == "" ? Eval("ProdComplDate") : Convert.ToDateTime(Eval("ProdComplDate")).ToString("dd-MM-yyyy") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtProdComplDate"
                                            ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[-](0?[1-9]|1[012])[-]\d{4}$"
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prod Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdRemarks" runat="server" Text='<%# Eval("ProdRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <%--<asp:TextBox ID="txtProdRemarks" runat="server" Text='<%# Eval("ProdRemarks") %>'></asp:TextBox>--%>
                                        <asp:DropDownList ID="drpDwnPrdRem" runat="server" DataSource='<%#GetRemarks() %>' DataTextField="remarkdesc" DataValueField="remarkid" AppendDataBoundItems="true">
                                            <%-- <asp:ListItem Enabled="false" Selected="True" Value="">(none)</asp:ListItem>--%>
                                            <asp:ListItem Value="0" Enabled="false">Please Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Body Heat No" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBodyHeatNo" runat="server" Text='<%# Eval("BodyHeatNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--<ItemStyle Width="150px" />
                                    <HeaderStyle Width="150px" />--%>
                                </asp:TemplateField>
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
