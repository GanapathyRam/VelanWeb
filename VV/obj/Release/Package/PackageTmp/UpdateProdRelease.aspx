<%@ Page Title="Update Prod Release" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="UpdateProdRelease.aspx.cs" Inherits="VV.UpdateProdRelease" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" width="30%" class="secondLevelHeader">
                <asp:Label ID="Label2" runat="server" Text="Production Release" />
            </td>
        </tr>
    </table>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
        <script type="text/javascript">
       
           //Function to ensure that non numeric values are not entered in the places where only the numeric values are to be given
            function AllowNumeric()
            {
              if ((event.keyCode>57) || (event.keyCode<48))
                {
	                event.keyCode=0;
                }
            }

            function SetZero() {
                if (document.getElementById("<%=txtProdReleaseQty.ClientID%>").value == "")
                    document.getElementById("<%=txtProdReleaseQty.ClientID%>").value = 0;
            }

            function Validate() {
                var RelQty = document.getElementById('<%= lblToRelQtyVal.ClientID %>').innerText;
                //alert(RelQty);
               // alert(parseInt(RelQty));
                
                var ProdRelQty = document.getElementById("<%=txtProdReleaseQty.ClientID%>").value;
               // alert(ProdRelQty);
               // alert(parseInt(ProdRelQty));

                if (parseInt(ProdRelQty) > parseInt(RelQty)) {
                    alert('Prod Release Qty Must be less than or equal to To Release Qty');
                    return false;
                }
            }

        </script>
    <div id="beforeInsert" runat="server" visible="true">
     <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblOrderNo" Text ="Order No" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblOrderNoVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblOrderType" Text ="Order Type" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblOrderTypeVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lbl" Text ="Pos" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblPosVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblLineNum" Text ="Line #" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblLineNumVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblCustName" Text ="Customer Name" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblCustNameVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblCustOrderNo" Text ="Customer Order No" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblCusOrderNoVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblItem" Text ="Item" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblItemVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblDesc" Text ="Description" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblDescVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblOrderQty" Text ="Order Qty" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblOrderQtyVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblToRelQty" Text ="To Release Qty" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblToRelQtyVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProdOrderNo"
                                    Display="Static" ErrorMessage="Product Order Number is required" InitialValue=""
                                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                <asp:Label ID="Label1" runat="Server" Text="*" ForeColor="red"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Text="Product Order Number"></asp:Label>
                            </td>
                 <td align="left" class="detailTableRowContent">
                     <asp:TextBox ID="txtProdOrderNo" runat="server" CssClass="inputStyle" ToolTip="Enter Product Order Number"></asp:TextBox>
                            </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="">
                                <asp:RequiredFieldValidator ID="valProdRelQty" runat="server" ControlToValidate="txtProdReleaseQty"
                                    Display="Static" ErrorMessage="Prod Release Quantity is required" InitialValue=""
                                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblMandatoryRelQty" runat="Server" Text="*" ForeColor="red"></asp:Label>
                                <asp:Label ID="lblReleaseQty" runat="server" Text="Prod Release Qty"></asp:Label>
                            </td>
                 <td align="left" class="detailTableRowContent">
                     <asp:TextBox ID="txtProdReleaseQty" runat="server" onkeypress="AllowNumeric();" onblur="SetZero();" CssClass="inputStyle" ToolTip="Enter Prod Release Qty"></asp:TextBox>
                            </td>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtProdReleaseQty" runat="server" SetFocusOnError="true" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                
            </tr>
             <%--<tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblReleaseType" Text ="Production Order Serial No Generation" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:CheckBox ID="chkBoxSerialNoGeneration" runat="server"></asp:CheckBox>
                </td>
            </tr>--%>
        </table>
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td align="center" colspan="2" valign="bottom">
                    <asp:Button ID="buttonUpdate" runat="server"  Width="100px" CssClass="buttonText" Text="Update" ToolTip="Update BaaN"
                        OnClick="buttonUpdate_Click" OnClientClick="return Validate()"/> &nbsp;
                    <asp:Button ID="buttonCancel" runat="server" CausesValidation="False" CssClass="buttonText" ToolTip="Cancel"
                        Text="Cancel" OnClick="buttonCancel_Click" />
                </td>
            </tr>
            <tr>
                <td align="left" class="detailTableRowHead"colspan="2">
                    <asp:ValidationSummary ID="valErrors" runat="server" CssClass="errorTxt" DisplayMode="BulletList"
                        HeaderText="Please correct the following errors::" />
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:GridView ID="grdViewUpdateProdResult" EnableViewState="false" DataKeyNames="OrderNum" ShowHeader="true" AllowSorting="false" AllowPaging="false" 
                    AutoGenerateColumns="false" runat="server" EmptyDataText="No Records To Display"
                    CellPadding="3" PageSize="13" CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager" 
                    RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" >                    
                   
                    <Columns>
                        <asp:TemplateField HeaderText="Order No"  ItemStyle-HorizontalAlign="left" SortExpression="OrderNum" >
                            <ItemTemplate>
                                <asp:Label ID="lblLineNum" runat="server" Text='<%# Eval("OrderNum") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Line #"  ItemStyle-HorizontalAlign="left" SortExpression="LineNum">
                            <ItemTemplate>
                                <asp:Label ID="lblLineNum" runat="server" Text='<%# Eval("LineNum") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pos"  ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                            <ItemTemplate>
                                <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Prod Order No"  ItemStyle-HorizontalAlign="left" SortExpression="ProdOrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblProdOrderNo" runat="server" Text='<%# Eval("ProdOrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial No"  ItemStyle-HorizontalAlign="left" SortExpression="SerialNo">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Prod Release Qty"  ItemStyle-HorizontalAlign="left" SortExpression="ProdReleaseQty">
                            <ItemTemplate>
                                <asp:Label ID="lblProdReleaseQty" runat="server" Text='<%# Eval("ProdReleaseQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <HeaderStyle Width="50px" />
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
                </td>
            </tr>
        </table>
        </div>

</asp:Content>
