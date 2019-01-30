<%@ Page Title="Update Screen Access" Language="C#" MasterPageFile="~/VV.Master"
    AutoEventWireup="true" Culture="en-IN" CodeBehind="UpdateScreenAccess.aspx.cs"
    Inherits="VV.UpdateScreenAccess" %>

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
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="10%">
                <asp:Label ID="lblPageTitle" runat="server" Text="Update Screen Access" />
            </td>
            <%--Added by Arun.
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif"
                            EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td width="80%" align="right" style="padding-left: 270px;" class="secondLevelHeader">
                <%--Added by Arun to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                <asp:Button ID="btnGiveAccess" Text="Update Access" runat="server" CssClass="buttonText" OnClick="btnGiveAccess_Click" Visible="true"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtEmpName" runat="server" ToolTip="Enter Employee Name to be Searched"
                        onKeyUp="ControlSearch(this)" />
                    <asp:RequiredFieldValidator ID="reqval1" runat="server" ControlToValidate="txtEmpName"
                        ErrorMessage="Enter Employee Name" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <%--Added by Arun 
                 Implemeted the Update Panel, so as to avoid showing the flickering, when any operations are done --%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="grdViewScreenResult" DataKeyNames="ScreenAccessID" ShowHeader="true"
                            AllowSorting="false" AllowPaging="false" AutoGenerateColumns="false" runat="server"
                            EmptyDataText="No Records To Display" CellPadding="3" CssClass="Grid" HeaderStyle-CssClass="Grid_Header"
                            PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="chkAll" name="chkAll" onclick="Check(this)" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" Checked='<%# Eval("HasAccess").ToString() == "True" %>' />
                                        <input id="hidScreenAccessID" value='<%# Eval("ScreenAccessID") %>' type="hidden" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Screen/ Menu Name" ItemStyle-HorizontalAlign="left" SortExpression="MenuName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScreenName" runat="server" Text='<%# Eval("MenuName") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Access" ItemStyle-HorizontalAlign="left" Visible="true" SortExpression="HasAccess">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHasAccess" runat="server" Text='<%# Eval("HasAccess") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
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
