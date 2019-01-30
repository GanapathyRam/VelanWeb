<%@ Page Title="Upload Invoice" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" CodeBehind="UploadInvoice.aspx.cs" Inherits="VV.UploadInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script language="javascript" type="text/javascript">
     
     /*
      * Added by Arun on 19-Mar-2008
      * Function will enable the Search Button, only if a minimum of 3 characters are entered in the search text box. 
      * If given less, then it will disable the search button
     */
    function ControlSearch(text) 
    {
        if (text.value.length > 1)
        {
            document.getElementById("<%=btnSearchBox.ClientID%>").disabled=false;
        }
        else
        {
            document.getElementById("<%=btnSearchBox.ClientID%>").disabled=true;
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
                <asp:Label ID="lblPageTitle" runat="server" Text="Import From Invoice" />            
            </td> 
            <%--Added by Arun on 26-Dec'07.
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
               <asp:UpdateProgress ID="UpdateProgress2" runat="server" >
                <ProgressTemplate>
                 Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif" EnableTheming="true"  ImageAlign="AbsMiddle" />
                </ProgressTemplate>
                </asp:UpdateProgress>      
             </td>    
            <td width="60%" align="right" style="padding-left:500px;" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <%--<asp:Button ID="btnShowInactive" Text="Show All" runat="server" CssClass="buttonText" ToolTip="Click to show InActive Records Also" OnClick="btnShowInactive_Click" />--%>
                    <%--<asp:Label ID="lblGroupBY" runat="server" Text="Group BY   :    " ForeColor="Black"
                        Font-Bold="true" Font-Size="10px" />
                    <asp:DropDownList ID="ddlGroupBy" runat="server" Font-Size="X-Small" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlGroupBy_SelectedIndexChanged" ToolTip="Select the Grouping" onClick="disableControl(this);" />--%>
                    <asp:TextBox ID="txtSearchBox" runat="server" ToolTip="Enter Data to be Searched" onKeyUp="ControlSearch(this)" Visible="false"/>
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" Visible="false"/>

                        <asp:ImageButton ID="imgExcel" runat="server" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="btnExcel_Click" Height="25px" Width="25px" />
                    <%--<asp:Button ID="btnShowInactive" Text="Show InActive" runat="server" CssClass="buttonText" 
                        ToolTip="Click to show InActive Records Also" OnClick="btnShowInactive_Click" />--%>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">

                <asp:FileUpload ID="FileUploader" runat="server" AllowMultiple="false" CssClass="Cntrl" /> &nbsp;
                <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="UploadButton_Click"  CssClass="buttonText"/>
                
             <%--Added by Arun on 26-Dec'07.
                 Implemeted the Update Panel, so as to avoid showing the flickering, when any operations are done --%>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
            </Triggers>
                <ContentTemplate>
                <asp:GridView ID="grdInvoiceResult" EnableViewState="false" DataKeyNames="OrderNo" ShowHeader="true" AllowSorting="false" AllowPaging="true" 
                    AutoGenerateColumns="false" runat="server" EmptyDataText="No Records To Display" OnSorting="grdInvoiceResult_Sorting"
                    CellPadding="3" OnPageIndexChanging="grdInvoiceResult_PageIndexChanging" PageSize="23"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager" 
                    RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" >                    
                   <Columns>
                       <%--<asp:HyperLinkField DataNavigateUrlFields="OrderNo,LineNum,Pos" DataNavigateUrlFormatString="UpdateProdRelease.aspx?OrderNo={0}&LineNum={1}&Pos={2}"
                            NavigateUrl="UpdateProdRelease.aspx"
                            HeaderText="Order No" DataTextField="OrderNo" SortExpression="OrderNo" >
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:HyperLinkField>--%>
                        <asp:TemplateField HeaderText="Order No"  ItemStyle-HorizontalAlign="left" SortExpression="OrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Line #"  ItemStyle-HorizontalAlign="left" SortExpression="LineNum">
                            <ItemTemplate>
                                <asp:Label ID="lblLineNum" runat="server" Text='<%# Eval("LineNum") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pos"  ItemStyle-HorizontalAlign="left" SortExpression="Pos">
                            <ItemTemplate>
                                <asp:Label ID="lblPos" runat="server" Text='<%# Eval("Pos") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Del Qty"  ItemStyle-HorizontalAlign="left" SortExpression="DelQty">
                            <ItemTemplate>
                                <asp:Label ID="lblDelQty" runat="server" Text='<%# Eval("DelQty") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Date"  ItemStyle-HorizontalAlign="left" SortExpression="InvoiceDate">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Eval("InvoiceDate") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                            <HeaderStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Number"  ItemStyle-HorizontalAlign="left" SortExpression="InvoiceNumber">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%# Eval("InvoiceNumber") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Is Success"  ItemStyle-HorizontalAlign="left" SortExpression="IsSuccess">
                            <ItemTemplate>
                                <asp:Label ID="lblIsSuccess" runat="server" Text='<%# Eval("IsSuccess").ToString() == "2" ? "Failure":"Success" %>' />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" />
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
