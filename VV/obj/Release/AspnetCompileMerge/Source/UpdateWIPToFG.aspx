<%@ Page Title="Update WIP To FG" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="UpdateWIPToFG.aspx.cs" Inherits="VV.UpdateWIPToFG" %>
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
                if (document.getElementById("<%=txtFGQty.ClientID%>").value == "")
                    document.getElementById("<%=txtFGQty.ClientID%>").value = 0;
            }

            function Validate() {
                //var WIPQty = document.getElementById('lblWIPQtyVal').innerText;
                var x = document.getElementById('<%= lblBalanceQtyVal.ClientID %>').innerText;
               // alert(x);
                var FGQty = document.getElementById("<%=txtFGQty.ClientID%>").value;
                // alert(FGQty);

                if (FGQty > x) {
                    alert('FG Must be less than or equal to Balance Qty');
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
                    <asp:Label ID="lblSerialNo" Text ="Serial No" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblSerialNoVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblProdOrderNo" Text ="Prod. Order No" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblProdOrderNoVal" runat="server"></asp:Label>
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
                    <asp:Label ID="lblWIPQty" Text ="WIP Qty" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblWIPQtyVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead">
                    <asp:Label ID="lblBalanceQty" Text ="Balance Qty" runat="server"></asp:Label>
                   </td>
                <td align="left" class="detailTableRowContent">
                    <asp:Label ID="lblBalanceQtyVal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="detailTableRowHead" style="">
                                <asp:RequiredFieldValidator ID="valFGQty" runat="server" ControlToValidate="txtFGQty"
                                    Display="Static" ErrorMessage="FG Quantity is required" InitialValue=""
                                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblMandatoryRelQty" runat="Server" Text="*" ForeColor="red"></asp:Label>
                                <asp:Label ID="lblFGQty" runat="server" Text="FG Qty"></asp:Label>
                            </td>
                 <td align="left" class="detailTableRowContent">
                     <asp:TextBox ID="txtFGQty" runat="server" onkeypress="AllowNumeric();" onblur="SetZero();" CssClass="inputStyle" ToolTip="Enter FG Qty"></asp:TextBox>
                            </td>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtFGQty" runat="server" SetFocusOnError="true" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                
            </tr>
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
        </div>

</asp:Content>
