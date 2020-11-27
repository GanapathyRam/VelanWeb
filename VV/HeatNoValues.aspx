<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="HeatNoValues.aspx.cs" Inherits="VV.HeatNoValues" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<link type="text/css" rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>--%>
    <script language="javascript" type="text/javascript">

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <asp:Panel ID="Message" Style="text-align: right;" runat="server" Visible="true">
        <asp:Label ID="lblMessage" Visible="false" Style="font-weight:700; text-align: center; padding-right: 300px;" runat="server" />
        <asp:Label ID="Label1" runat="server" Style="color: red;" CssClass="required" Text="(*) This fields are required" />
    </asp:Panel>
    <div class="container-fluid" style="border-bottom: 1px solid; padding-bottom: 10px; border-bottom-color: silver;">
        <div class="row">
            <div style="margin-left: 500px;">
                <asp:Label ID="lblHeatNo" runat="server" Text="Heat No" CssClass="text-right res-pad form-required col-lg-4 col-md-5 col-sm-4 col-xs-5"></asp:Label>
                &nbsp;<asp:TextBox ID="txtHeatNo" runat="server" AutoPostBack="true" OnTextChanged="txtHeatNo_TextChanged" CssClass="form-control col-md-8 col-sm-8 col-xs-7"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvLine1"
                    ControlToValidate="txtHeatNo" runat="server"
                    Display="Dynamic"
                    CssClass="field-validation-error"
                    Text="*" ForeColor="Red" Font-Bold="true" Style="margin-left: 10px;" />
            </div>
            <div style="margin-left: 800px;">
                <asp:Button ID="btnNew" Style="width: 80px;" OnClick="btnNew_Click" runat="server" Text="Save" />
                &nbsp;<asp:Button ID="btnUpdate" Style="width: 80px;" OnClick="btnUpdate_Click" runat="server" Text="Update" />
                &nbsp;<asp:Button ID="btnDelete" Style="width: 80px;" OnClick="btnDelete_Click" runat="server" Visible="true" Text="Delete" />
            </div>
        </div>
    </div>

    <div class="container-fluid" style="border-bottom: 1px solid; border-bottom-color: silver; padding-bottom: 10px;">
        <div class="row" style="margin: 20px">
            <table style="text-align: center; margin-left: 200px;">
                <tr>
                    <td colspan="1">
                        <div>
                            <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSupplier" runat="server" Style="width: 160px;"></asp:TextBox>
                        </div>
                    </td>
                    <td colspan="1" style="text-align: right;">
                        <div style="width: 200px;">
                            <asp:Label ID="lblDescription" runat="server" Text="PED"></asp:Label>
                        </div>
                    </td>
                    <td colspan="1">
                        <div>
                            <asp:CheckBoxList ID="CheckBoxList1" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="No" Value="1"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Heat Treatment"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlHeatTreatment" AutoPostBack="true" DataTextField="HTDesc" DataValueField="HTCode" Width="200px" runat="server" OnSelectedIndexChanged="ddlHeatTreatment_SelectedIndexChanged"></asp:DropDownList>

                        </div>
                    </td>
                    <td colspan="1">
                        <div style="width: 200px; text-align: right;">
                            <asp:Label ID="Label3" runat="server" Text="Material"></asp:Label>
                        </div>
                    </td>
                    <td colspan="1">
                        <div>
                            &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlMaterialCode" AutoPostBack="true" Width="200px" runat="server" DataTextField="MaterialDesc" DataValueField="MaterialCode" OnSelectedIndexChanged="ddlMaterialCode_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="test"
                                ControlToValidate="ddlMaterialCode" runat="server"
                                Display="Dynamic"
                                CssClass="field-validation-error"
                                Text="*" ForeColor="Red" Font-Bold="true" Style="margin-left: 10px;" />
                        </div>
                    </td>
                    <td colspan="1"></td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="row" style="margin-left: 100px; border-bottom: 1px solid; padding-bottom: 80px; border-bottom-color: silver;">
            <table style="text-align: center;">

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="Label94" runat="server" Style="font-weight: 800;" Text="Min"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="Label95" runat="server" Style="font-weight: 800;" Text="Max"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="Label96" runat="server" Style="font-weight: 800;" Text="Actual"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="Label98" runat="server" Style="font-weight: 800;" Text="Min"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="Label99" runat="server" Style="font-weight: 800;" Text="Max"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="Label103" runat="server" Style="font-weight: 800;" Text="Actual"></asp:Label>

                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="Label101" runat="server" Style="font-weight: 800;" Text="Min"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="Label102" runat="server" Style="font-weight: 800;" Text="Max"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="Label100" runat="server" Style="font-weight: 800;" Text="Actual"></asp:Label>

                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblMinMax" runat="server" Text="C"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblMnMinMnMax" runat="server" Text="Mn"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblMnMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblMnMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtMnActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblPMinMax" runat="server" Text="P"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblPMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblPMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtPActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblSMinSMax" runat="server" Text="S"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblSMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblSMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtSActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblSiMinSiMax" runat="server" Text="Si"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblSiMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblSiMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtSiActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblCuMinCuMax" runat="server" Text="Cu"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCuMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCuMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCuActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblNiMinNiMax" runat="server" Text="Ni"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNiMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNiMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtNiActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblCrMinCrMax" runat="server" Text="Cr"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCrMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCrMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCrActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblMoMinMoMax" runat="server" Text="Mo"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblMoMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblMoMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtMoActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblVMinVMax" runat="server" Text="V"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblVMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblVMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtVActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblCuNiCrMoVMinCuNiCrMoVMax" runat="server" Text="CuNiCrMoV"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCuNiCrMoVMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCuNiCrMoVMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCuNiCrMoVActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblCrMoMinCrMoMax" runat="server" Text="CrMo"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCrMoMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblCrMoMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtCrMoActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblNbMinNbMax" runat="server" Text="Nb"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNbMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNbMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtNbActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblNMinNMax" runat="server" Text="N"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtNActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblAlMinAlMax" runat="server" Text="Al"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblAlMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblAlMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtAlActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTiMinTiMax" runat="server" Text="Ti"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTiMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTiMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTiActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblZrMinZrMax" runat="server" Text="Zr"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblZrMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblZrMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtZrActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblFeMinFeMax" runat="server" Text="Fe"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblFeMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblFeMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtFeActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTaMinTaMax" runat="server" Text="Ta"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTaMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTaMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTaActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblNbTaMinNbTaMax" runat="server" Text="NbTa"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNbTaMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNbTaMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtNbTaActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileMPAMinTensileMPAMax" runat="server" Text="TensileMPA"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileMPAMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="TensileMPAMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTensileMPAActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileKSIMinTensileKSIMax" runat="server" Text="TensileKSI"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileKSIMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileKSIMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTensileKSIActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldMPAMinYieldMPAMax" runat="server" Text="YieldMPA"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldMPAMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldMPAMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtYieldMPAActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldKSIMinYieldKSIMax" runat="server" Text="YieldKSI"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldKSIMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldKSIMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtYieldKSIActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblElongationMinElongationMax" runat="server" Text="Elongation"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblElongationMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblElongationMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtElongationActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblReductionMinReductionMax" runat="server" Text="Reduction"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblReductionMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblReductionMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtReductionActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblHardnessMinHardnessMax" runat="server" Text="Hardness"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblHardnessMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblHardnessMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtHardnessActual" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact1" runat="server" Text="Impact1"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact1" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact2" runat="server" Text="Impact2"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact2" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact3" runat="server" Text="Impact3"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact3" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact4" runat="server" Text="Impact4"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact4" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact5" runat="server" Text="Impact5"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact5" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact6" runat="server" Text="Impact6"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact6" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTemperatureFAct" runat="server" Text="TemperatureF"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTemperatureF" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTemperatureC" runat="server" Text="TemperatureC"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTemperatureC" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
            </table>

        </div>
    </asp:Panel>
</asp:Content>
