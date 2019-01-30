<%@ Page Title="Upload Updated MIS Sales Input" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="UploadUpdatedMISSalesInput.aspx.cs" Inherits="VV.UploadUpdatedMISSalesInput" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        /*
         * Added by Arun on 19-Mar-2008
         * Function will enable the Search Button, only if a minimum of 3 characters are entered in the search text box. 
         * If given less, then it will disable the search button
        */
        function ControlSearch(text) {
            if (text.value.length > 1) {
                document.getElementById("<%=btnSearchBox.ClientID%>").disabled = false;
        }
        else {
            document.getElementById("<%=btnSearchBox.ClientID%>").disabled = true;
        }
    }

    function Confirm() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("Do you want to save data?")) {
            confirm_value.value = "Yes";
        } else {
            confirm_value.value = "No";
        }
        document.forms[0].appendChild(confirm_value);
    }

    </script>

    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" style="width: 15%">
                <asp:Label ID="lblPageTitle" runat="server" Text="Stock Code / Tag No Import" />
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
            <td width="60%" align="left" style="padding-left: 500px;" class="secondLevelHeader">
                <%--Added by Arun to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <asp:TextBox ID="txtSearchBox" runat="server" ToolTip="Enter Data to be Searched" onKeyUp="ControlSearch(this)" Visible="false" />
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" Visible="false" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">

                <asp:FileUpload ID="FileUploader" runat="server" AllowMultiple="false" CssClass="Cntrl" />
                &nbsp;
                <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="UploadButton_Click" CssClass="buttonText" />

                <%--Added by Arun to Implement the Update Panel, so as to avoid showing the flickering, when any operations are done --%>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="grdSearchResult" EnableViewState="false" DataKeyNames="OrderNo" ShowHeader="true" AllowSorting="false" AllowPaging="true" CssClass="Grid"
                            AutoGenerateColumns="true" runat="server" EmptyDataText="No Records To Display" CellPadding="3" OnPageIndexChanging="grdSearchResult_PageIndexChanging"
                            HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager" RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">

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
