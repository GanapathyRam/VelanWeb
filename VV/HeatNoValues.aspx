<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="HeatNoValues.aspx.cs" Inherits="VV.HeatNoValues" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <asp:Panel ID="Message" Style="text-align: right;" runat="server" Visible="true">
        <asp:Label ID="lblMessage" Visible="false" Style="font-weight: 700; text-align: center; padding-right: 300px;" runat="server" />
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
                <asp:Button ID="btnNew" Style="width: 80px;" OnClick="btnNew_Click" runat="server" ValidationGroup="Insert" Text="Save" />
                &nbsp;<asp:Button ID="btnUpdate" Style="width: 80px;" OnClick="btnUpdate_Click" ValidationGroup="Insert" runat="server" Text="Update" />
                &nbsp;<asp:Button ID="btnDelete" Style="width: 80px;" OnClick="btnDelete_Click" ValidationGroup="Insert" runat="server" Visible="true" Text="Delete" />
            </div>
        </div>
    </div>

    <div class="container-fluid" style="border-bottom: 1px solid; border-bottom-color: silver;">
        <div class="row" style="margin: 10px">
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
                            <%--<asp:CheckBoxList ID="CheckBoxList1" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="No" Value="1"></asp:ListItem>
                            </asp:CheckBoxList>--%>
                            <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="No" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
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
    <asp:Panel ID="Panel2" Style="text-align: center;" runat="server" Visible="false">
        <textarea id="TextArea1" runat="server" style="text-align: left; width: 500px; height: 30px; color: red" cols="20" rows="2"></textarea>
    </asp:Panel>
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
                        <asp:TextBox ID="txtCActual" CausesValidation="True" runat="server" AutoPostBack="true" ValidationGroup="Insert" OnTextChanged="txtCActual_TextChanged"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            ControlToValidate="txtCActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtMnActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtMnActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator10"
                            ControlToValidate="txtMnActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtPActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtPActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator24"
                            ControlToValidate="txtPActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtSActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtSActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                            ControlToValidate="txtSActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtSiActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtSiActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator11"
                            ControlToValidate="txtSiActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtCuActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtCuActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator23"
                            ControlToValidate="txtCuActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtNiActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtNiActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                            ControlToValidate="txtNiActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtCrActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtCrActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator12"
                            ControlToValidate="txtCrActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtMoActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtMoActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator22"
                            ControlToValidate="txtMoActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtVActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtVActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                            ControlToValidate="txtVActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtCuNiCrMoVActual" Enabled="false" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtCrMoActual" Enabled="false" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtNbActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtNbActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                            ControlToValidate="txtNbActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtNActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtNActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator13"
                            ControlToValidate="txtNActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtAlActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtAlActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator21"
                            ControlToValidate="txtAlActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtTiActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtTiActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator6"
                            ControlToValidate="txtTiActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtZrActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtZrActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator14"
                            ControlToValidate="txtZrActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtFeActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtFeActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20"
                            ControlToValidate="txtFeActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtTaActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtTaActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                            ControlToValidate="txtTaActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtNbTaActual" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileMPAMinTensileMPAMax" runat="server" Text="Tensile (MPa)"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileMPAMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="TensileMPAMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTensileMPAActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtTensileMPAActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator19"
                            ControlToValidate="txtTensileMPAActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileKSIMinTensileKSIMax" runat="server" Text="Tensile (ksi)"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileKSIMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblTensileKSIMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTensileKSIActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtTensileKSIActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                            ControlToValidate="txtTensileKSIActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldMPAMinYieldMPAMax" runat="server" Text="Yield (MPa)"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldMPAMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldMPAMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtYieldMPAActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtYieldMPAActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator15"
                            ControlToValidate="txtYieldMPAActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldKSIMinYieldKSIMax" runat="server" Text="Yield (ksi)"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldKSIMin" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblYieldKSIMax" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtYieldKSIActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtYieldKSIActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18"
                            ControlToValidate="txtYieldKSIActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtElongationActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtElongationActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator9"
                            ControlToValidate="txtElongationActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                        <asp:TextBox ID="txtReductionActual" AutoPostBack="true" CausesValidation="True" ValidationGroup="Insert" OnTextChanged="txtReductionActual_TextChanged" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1">
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator16"
                            ControlToValidate="txtReductionActual"
                            ValidationExpression="[0-9]*\.?[0-9]*"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Invalid Input"
                            ValidationGroup="Insert"
                            runat="server" />
                    </td>
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
                    <td colspan="1">
                    </td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact1" runat="server" Text="Impact (ft-lb)"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact1" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact2" runat="server" Text="Impact (J)"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact2" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact3" runat="server" Text="Impact (ft-lb)"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact3" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                </tr>

                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact4" runat="server" Text="Impact (J)"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact4" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact5" runat="server" Text="Impact (ft-lb)"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtImpact5" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblImpact6" runat="server" Text="Impact (J)"></asp:Label>
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
                        <asp:Label ID="lblTemperatureFAct" runat="server" Text="Temp (F)"></asp:Label>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:TextBox ID="txtTemperatureF" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:Label ID="lblTemperatureC" runat="server" Text="Temp (C)"></asp:Label>
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
