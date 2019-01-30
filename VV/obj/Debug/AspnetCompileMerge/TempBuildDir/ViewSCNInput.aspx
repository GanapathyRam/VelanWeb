<%@ Page Title="View SCN Input" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="ViewSCNInput.aspx.cs" Inherits="VV.ViewSCNInput" %>

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

    
    </script>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="30%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View SCN Input" />
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

            <td width="60%" align="right" style="padding-left: 360px;" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:TextBox ID="txtFigNo" runat="server" ToolTip="Enter Figure No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:TextBox ID="txtOrderNo" runat="server" ToolTip="Enter Order No to be Searched" onKeyUp="ControlSearch(this)" />
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
                                        <asp:Label ID="lblProdComplDate" runat="server" Text='<%# Eval("ProdComplDate") %>' ></asp:Label>
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
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="QC Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQCRemarks" runat="server" Text='<%# Eval("QCRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField InsertVisible="false" HeaderText="IRN Comp Date">
                                    <ItemTemplate>
                                        <asp:TextBox Width="60px" ID="txtIRNComplDate" Font-Size="8.5" BorderStyle="None" BackColor="transparent" runat="server" Text='<%# Bind("IRNComplDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SCN Comp Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSCNComplDate" runat="server" Text='<%# Eval("SCNComplDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                       <asp:TextBox ID="txtSCNComplDate" runat="server" ValidationGroup="validaiton" Text='<%# Bind("SCNComplDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="dateValidator1" runat="server" ControlToValidate="txtSCNComplDate"
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" 
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                         <asp:CompareValidator ID="CompVal1" runat="server" ControlToValidate="txtSCNComplDate" ControlToCompare="txtIRNComplDate"
                                            ErrorMessage="SCN Date must be greater than IRN Date" Operator="GreaterThanEqual"
                                            Type="Date" Display="Dynamic"></asp:CompareValidator>
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
