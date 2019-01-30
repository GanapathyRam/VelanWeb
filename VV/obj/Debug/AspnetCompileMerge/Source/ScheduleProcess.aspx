<%@ Page Title="Schedule Process" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" Culture="en-IN"
    CodeBehind="ScheduleProcess.aspx.cs" Inherits="VV.Schedule_Process" EnableEventValidation="false" %>

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

    <%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">--%>
    <%--<table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">--%>
    <div style="font: 14px Verdana">
        <p style="margin-left: 400px; font-family: Verdana">Import BOM (Once a month): </p>
        <div style="margin-left: 480px; border-color: red;">
            <asp:FileUpload ID="FileUpload" Width="235px" CssClass="Cntrl" runat="server" />
            &nbsp;<input type="button" id="btImport" class="buttonText" value="Upload" style="width: 80px; height: 22px;" onserverclick="btImport_ServerClick" runat="server" />
            &nbsp;Available counts : <asp:Label ID="lblBomCount" runat="server" Text="" style="font-weight: 700"></asp:Label>
        </div>

        <p style="margin-left: 400px; font-family: Verdana">Import Inventory (Daily):</p>
        <div style="margin-left: 480px; margin-top: 20px;">
            <asp:FileUpload ID="FileUploadForInventory" CssClass="Cntrl" Width="235px" runat="server" />
            &nbsp;<input type="button" id="btImportForInventory" class="buttonText" value="Upload" style="width: 80px; height: 22px;" onserverclick="btImportForInventory_ServerClick" runat="server" />
             &nbsp;Available counts : <asp:Label ID="lblInventoryCount" runat="server" Text="" style="font-weight: 700"></asp:Label>
        </div>

        <p style="margin-left: 400px; font-family: Verdana">Import WIP (Daily):</p>
        <div style="margin-left: 480px; margin-top: 20px;">
            <asp:FileUpload ID="FileUploadForWIP" CssClass="Cntrl" Width="235px" runat="server" />
            &nbsp;<input type="button" id="btImportForWIP" class="buttonText" value="Upload" style="width: 80px; height: 22px;" onserverclick="btImportForWIP_ServerClick" runat="server" />
            &nbsp;Available counts : <asp:Label ID="lblWipCount" runat="server" Text="" style="font-weight: 700"></asp:Label>
            &nbsp;<input type="button" id="btnDisplayWIPUploadItems" class="buttonText" visible="false" value="Display" style="width: 80px; height: 22px;" runat="server" onserverclick="btnDisplayWIPUploadItems_ServerClick" />
        </div>

        <p style="margin-left: 400px; font-family: Verdana">Import Pending PO (Daily): </p>
        <div style="margin-left: 480px; margin-top: 20px;">
            <asp:FileUpload ID="FileUploadForPO" CssClass="Cntrl" Width="235px" runat="server" />
            &nbsp;<input type="button" id="btImportForPO" class="buttonText" value="Upload" style="width: 80px; height: 22px;" onserverclick="btImportForPO_ServerClick" runat="server" />
            &nbsp;Available counts : <asp:Label ID="lblPoCount" runat="server" Text="" style="font-weight: 700"></asp:Label>
            &nbsp;<input type="button" id="btnDisplayPOUploadItems" class="buttonText" value="Display" style="width: 80px; height: 22px;" runat="server" visible="false" onserverclick="btnDisplayPOUploadItems_ServerClick" />
        </div>

        <div style="margin-top: 20px; margin-left: 630px;">
            <asp:Button ID="btnProcess" Width="150px" runat="server" Font-Bold="true" CssClass="buttonText" Text="Process" OnClick="btnProcess_Click" />
        </div>

        <div style="margin-left: 500px; margin-top: 10px;">
            <asp:Label ID="lblConfirm" runat="server"></asp:Label>
        </div>
    </div>
    <div style="margin-top: 10px;">
    </div>
    <div style="text-align: right;">
        <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
            <asp:TextBox ID="txtOrderNumber" runat="server" ToolTip="Enter Order Number to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtPos" runat="server" ToolTip="Enter Pos to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtItem" runat="server" ToolTip="Enter Item to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:TextBox ID="txtItemNumber" runat="server" ToolTip="Enter Item number to be Searched" onKeyUp="ControlSearch(this)" />
            <asp:Button ID="btnSearchBox" runat="server" Text="Search"
                ToolTip="Click to Search Data" CssClass="buttonText" Enabled="true" OnClick="btnSearchBox_Click" />
        </asp:Panel>
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <asp:MultiView ID="Multiview1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" AllowPaging="true" PageSize="24" CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnPageIndexChanging="GridView1_PageIndexChanging"
                            PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display" runat="server">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order No">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pos">
                            <ItemTemplate>
                                <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblItem" Text='<%# Eval("Item") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescription" Text='<%# Eval("Description") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Planned DelDate">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPlannedDelDate" Text='<%# Eval("PlannedDelDate") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Number">
                            <ItemTemplate>
                                <asp:Label ID="lblItemNumber" runat="server" Text='<%# Eval("ItemNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Position">
                            <ItemTemplate>
                                <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("position") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Desc">
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Dec") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To Release Qty">
                            <ItemTemplate>
                                <asp:Label ID="lblReleaseQty" runat="server" Text='<%# Eval("ToReleaseQty") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To Release BOM Qty">
                            <ItemTemplate>
                                <asp:Label ID="lblReleasebomqty" runat="server" Text='<%# Eval("ToReleaseBomQty") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
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
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false"
                            OnRowCancelingEdit="GridView2_RowCancelingEdit" AllowPaging="true" PageSize="24" OnPageIndexChanging="GridView2_PageIndexChanging"
                            OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                            PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                            CellPadding="3">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                                        <%--<asp:CheckBox ID = "chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                                        <%--<asp:CheckBox runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />--%>
                                        <input id="hidProdOrder" value='<%# Eval("ProdOrder") %>' type="hidden" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prod Order No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdOrderNo" runat="server" Text='<%# Eval("ProdOrder") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Del Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDelDate" runat="server" Text='<%# Eval("DelDate") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemNumber" runat="server" Text='<%# Eval("ItemNumber") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDescription" Text='<%# Eval("Description") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblProject" Text='<%# Eval("Project") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="70px" />
                                    <HeaderStyle Width="70px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty Ord">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblQtyOrd" Text='<%# Eval("QtyOrd") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="60px" />
                                    <HeaderStyle Width="60px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty Dlv">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQtyDlv" runat="server" Text='<%# Eval("QtyDlv") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomer" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sales Order">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesOrder" runat="server" Text='<%# Eval("SalesOrder") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Material Issued">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialIssued" runat="server" Text='<%# Eval("MaterialIssued") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="X">
                                    <ItemTemplate>
                                        <asp:Label ID="lblx" runat="server" Text='<%# Eval("X") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Balance Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalQuantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rec Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRecDate" runat="server" Text='<%# Bind("RecDate", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                        <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtRecDate"
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRecDate" runat="server" Text='<%# Bind("RecDate", "{0:dd-MM-yyyy}") %>'> </asp:TextBox>
                                        <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtRecDate"
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Edit" ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="150px" />
                                    <HeaderStyle Width="150px" />
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
                    </asp:View>

                    <asp:View ID="View3" runat="server">
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false"
                            OnRowCancelingEdit="GridView3_RowCancelingEdit" AllowPaging="true" PageSize="24" OnPageIndexChanging="GridView3_PageIndexChanging"
                            OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                            PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" EmptyDataText="No Records To Display"
                            CellPadding="3">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                                        <input id="hidPoOrder" value='<%# Eval("PoOrder") %>' type="hidden" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Po Order No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPoOrderNo" runat="server" Text='<%# Eval("PoOrder") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PO Position">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPOPosition" runat="server" Text='<%# Eval("POPosition") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plan DelDate">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlanDelDate" Text='<%# Eval("PlanDelDate") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Number">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblItemNumber" Text='<%# Eval("ItemNumber") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="70px" />
                                    <HeaderStyle Width="70px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order Balance">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderBalance" runat="server" Text='<%# Eval("OrderBalance") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReferenceA">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReferenceA" runat="server" Text='<%# Eval("ReferenceA") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="X">
                                    <ItemTemplate>
                                        <asp:Label ID="lblX" runat="server" Text='<%# Eval("X") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Commitment">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCommitment" runat="server" Text='<%# Bind("Commitment", "{0:dd/MM/yyyy}") %>'> </asp:TextBox>
                                        <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtCommitment"
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCommitment" runat="server" Text='<%# Bind("Commitment", "{0:dd/MM/yyyy}") %>'> </asp:TextBox>
                                        <asp:RegularExpressionValidator ID="dateValidator2" runat="server" ControlToValidate="txtCommitment"
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\-(0[13578]|1[02])\-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\-(0[13456789]|1[012])\-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\-02\-((19|[2-9]\d)\d{2}))|(29\-02\-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
                                            ErrorMessage="Format: dd-MM-yyyy" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <%--                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />--%>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Edit" ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemStyle Wrap="false" />
<%--                                    <ItemStyle Width="150px" />
                                    <HeaderStyle Width="150px" />
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
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--</table>--%>
</asp:Content>
<%-- </form>
    
</body>
</html>--%>
