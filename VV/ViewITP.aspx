<%@ Page Title="View ITP" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="ViewITP.aspx.cs" Inherits="VV.ViewITP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        /*
         * Added by Arun 
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
                document.getElementById("<%=txtSearchBox.ClientID%>").value = "";
                document.getElementById("<%=txtSearchBox.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else if (chosenText.value == '--Remove Grouping--') {
                document.getElementById("<%=txtSearchBox.ClientID%>").value = "";
                document.getElementById("<%=txtSearchBox.ClientID%>").disabled = false;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
            else {
                document.getElementById("<%=txtSearchBox.ClientID%>").value = "";
                document.getElementById("<%=txtSearchBox.ClientID%>").disabled = true;
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
            }
    }

     </script>
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="30%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View ITP/ GAD Info" />
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

            <td width="60%" align="right" style="padding-left: 350px;" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:TextBox ID="txtSearchBox" runat="server" ToolTip="Enter Order No to be Searched" onKeyUp="ControlSearch(this)" />
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSearchBox" runat="server" SetFocusOnError="true" ErrorMessage="Only Numbers allowed" Display="Dynamic" ValidationExpression="\d+"></asp:RegularExpressionValidator>
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
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="23"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="Grid" HeaderStyle-CssClass="Grid_Header" 
                            PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" 
                            EmptyDataText="No Records To Display"
                            CellPadding="3">
                            <Columns>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustName" runat="server" Text='<%# Eval("CustomerName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order No">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblOrderNo" Text='<%# Eval("OrderNo") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Line #" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblLineNo" Text='<%# Eval("LineNum") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                    <HeaderStyle Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pos" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPos" Text='<%# Eval("Pos") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="60px" />
                                    <HeaderStyle Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PlannedDelDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlannedDelDate" runat="server" Text='<%# Eval("PlannedDelDate").ToString() == "" ? Eval("PlannedDelDate") : Convert.ToDateTime(Eval("PlannedDelDate")).ToString("dd-MM-yyyy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ITP">
                                    <ItemTemplate>
                                        <asp:Label ID="lblITP" runat="server" Text='<%# Eval("ITP") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtITP" runat="server" Text='<%# Eval("ITP") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approved ITP">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprovedITP" runat="server" Text='<%# Eval("ApprovedITP") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtApprovedITP" runat="server" Text='<%# Eval("ApprovedITP") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GAD">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGAD" runat="server" Text='<%# Eval("GAD") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGAD" runat="server" Text='<%# Eval("GAD") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approved GAD">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppGAD" runat="server" Text='<%# Eval("ApprovedGAD") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtApprovedGAD" runat="server" Text='<%# Eval("ApprovedGAD") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inspection1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIns1" runat="server" Text='<%# Eval("Inspection1") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtInspection1" runat="server" Text='<%# Eval("Inspection1") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inspection2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIns2" runat="server" Text='<%# Eval("Inspection2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtInspection2" runat="server" Text='<%# Eval("Inspection2") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                    <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemStyle Width="150px" />
                                    <HeaderStyle Width="150px" />
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
