<%@ Page Title="View TPI Offering" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="ViewTPIOffering.aspx.cs" Inherits="VV.ViewTPIOffering" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        /*
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
                document.getElementById("<%=txtOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtOrderNo.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else if (chosenText.value == '--Remove Grouping--') {
                document.getElementById("<%=txtOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtOrderNo.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else {
                document.getElementById("<%=txtOrderNo.ClientID%>").value = "";
                document.getElementById("<%=txtOrderNo.ClientID%>").disabled = true;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
    }

    function Redirect() {
        window.location = "ViewTPIOffering.aspx";
    }
    
    </script>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="20%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View TPI Offering" />
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

            <td width="70%" align="right" style="padding-left: 60px;" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
                    <asp:Label ID="lblPopupName" Text="Bulk Update" runat="server" CssClass="secondLevelHeader"></asp:Label>
                    <iframe style=" width: 350px; height: 230px;" id="irm1" src="BulkTPIOffering.aspx" runat="server"></iframe>
                    <br/>
                    <asp:Button ID="Button2" runat="server" Text="Close" CssClass="buttonText" OnClientClick="Redirect();" />
                </asp:Panel>
                <%--<asp:Button ID="Button1" runat="server" Text="Bulk Update" CssClass="buttonText"/>--%>
 
                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="Background">
                </cc1:ModalPopupExtender>

                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Bulk Update" CssClass="buttonText"/>
                    <asp:TextBox ID="txtProdSerialNo" runat="server" ToolTip="Enter Prod Order No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:TextBox ID="txtFigNo" runat="server" ToolTip="Enter Figure No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:TextBox ID="txtOrderNo" runat="server" ToolTip="Enter Order No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:TextBox ID="txtPos" runat="server" ToolTip="Enter Pos No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" />
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
                            OnRowCancelingEdit="GridView1_RowCancelingEdit" AllowPaging="true" PageSize="24" OnPageIndexChanging="GridView1_PageIndexChanging"
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
<%--                                    <ItemStyle Width="100px" />
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
                                <asp:TemplateField HeaderText="Prod Delivery Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdDeliveryDate" runat="server" Text='<%# Eval("ProdDeliveryDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prod Comp Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdComplDate" runat="server" Text='<%# Eval("ProdComplDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prod Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdRemarks" runat="server" Text='<%# Eval("ProdRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TPI Offer Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTPIOfferDate" runat="server" Text='<%# Eval("TPIOfferDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTPIOfferDate" runat="server" Text='<%# Bind("TPIOfferDate", "{0:dd/MM/yyyy}") %>'> </asp:TextBox> 
                                        <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtTPIOfferDate"
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="QC Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQCRemarks" runat="server" Text='<%# Eval("QCRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtQCRemarks" runat="server" Text='<%# Eval("QCRemarks") %>'></asp:TextBox>
                                        <%--<asp:DropDownList ID="drpDwnQCRem" runat="server"  DataSource='<%#GetRemarks() %>' DataTextField="remarkdesc" DataValueField="remarkid" AppendDataBoundItems="true">
                                        <%--<asp:ListItem Selected="True" Value="">(none)</asp:ListItem>--%>
                                        <%-- <asp:ListItem Value="0" Enabled="false">Please Select</asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IRN Comp Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIRNComplDate" runat="server" Text='<%# Eval("IRNComplDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                         <asp:TextBox ID="txtIRNComplDate" runat="server" Text='<%# Bind("IRNComplDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="dateValidator1" runat="server" ControlToValidate="txtIRNComplDate"
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="CompVal1" runat="server" ControlToCompare="txtTPIOfferDate" ControlToValidate="txtIRNComplDate" 
                                            ErrorMessage="IRN Comp Date must be greater than TPI Offer Date" Operator="GreaterThanEqual" 
                                            Type="String" Display="Dynamic"></asp:CompareValidator>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
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
<%--                                    <ItemStyle Width="150px" />
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
