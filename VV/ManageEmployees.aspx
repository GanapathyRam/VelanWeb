<%@ Page Language="C#" MasterPageFile="~/VV.master" AutoEventWireup="true" CodeFile="ManageEmployees.aspx.cs" Inherits="VV.ManageEmployees" Title="View Employees" %>

<%--<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
--%><asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
    
    function disableControl(chosenText)
    {
        //alert(chosenText.value);
        if(chosenText.value == '0')
        {
            document.getElementById("<%=txtSearchBox.ClientID%>").value = "";
            document.getElementById("<%=txtSearchBox.ClientID%>").disabled=false;
            document.getElementById("<%=btnSearchBox.ClientID%>").disabled=true;
        }
        else if( chosenText.value == '--Remove Grouping--')
        {
            document.getElementById("<%=txtSearchBox.ClientID%>").value = "";
            document.getElementById("<%=txtSearchBox.ClientID%>").disabled=false;
            document.getElementById("<%=btnSearchBox.ClientID%>").disabled=true;
        }
        else
        {
            document.getElementById("<%=txtSearchBox.ClientID%>").value = "";
            document.getElementById("<%=txtSearchBox.ClientID%>").disabled=true;
            document.getElementById("<%=btnSearchBox.ClientID%>").disabled=true;
        }
    }
     
     function editGrid(rowId)
    {
         location.href="UpdateEmployee.aspx?BadgeNo="+rowId;
    }
        
    function expandcollapse(obj,row)
    {
        var div = document.getElementById(obj);
        var img = document.getElementById('img' + obj);
        
        if (div.style.display == "none")
        {
            div.style.display = "block";
            if (row == 'alt')
            {
                img.src = "Images/minus.gif";
            }
            else
            {
                img.src = "Images/minus.gif";
            }
            img.alt = "Close to view other Columns";
        }
        else
        {
            div.style.display = "none";
            if (row == 'alt')
            {
                img.src = "Images/plus.gif";
            }
            else
            {
                img.src = "Images/plus.gif";
            }
            img.alt = "Expand to show Column";
        }
    } 
       
    </script>
    
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="30%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View Employees" />            
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
            <td width="60%" align="right" class="secondLevelHeader">
                <%--Added by Arun on 27-Jan'08 to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                    <%--<asp:Button ID="btnShowInactive" Text="Show All" runat="server" CssClass="buttonText" ToolTip="Click to show InActive Records Also" OnClick="btnShowInactive_Click" />--%>
                    <%--<asp:Label ID="lblGroupBY" runat="server" Text="Group BY   :    " ForeColor="Black"
                        Font-Bold="true" Font-Size="10px" />
                    <asp:DropDownList ID="ddlGroupBy" runat="server" Font-Size="X-Small" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlGroupBy_SelectedIndexChanged" ToolTip="Select the Grouping" onClick="disableControl(this);" />--%>
                    <asp:TextBox ID="txtSearchBox" runat="server" ToolTip="Enter Data to be Searched" onKeyUp="ControlSearch(this)"/>
                    <asp:Button ID="btnSearchBox" runat="server" Text="Search" OnClick="btnSearchBox_Click"
                        ToolTip="Click to Search Data" CssClass="buttonText" Enabled="false" />
                    <%--<asp:Button ID="btnShowInactive" Text="Show InActive" runat="server" CssClass="buttonText" 
                        ToolTip="Click to show InActive Records Also" OnClick="btnShowInactive_Click" />--%>
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
                <asp:AsyncPostBackTrigger ControlID="ddlGroupBy" />
                <asp:AsyncPostBackTrigger ControlID="btnSearchBox" />
            </Triggers>
                <ContentTemplate>
                <asp:GridView ID="grdSearchResult" EnableViewState="false" DataKeyNames="BadgeNumber" ShowHeader="true" AllowSorting="true" AllowPaging="true" AutoGenerateColumns="False"
                    runat="server" EmptyDataText="No Records To Display" OnSorting="grdSearchResult_Sorting"
                    CellPadding="3" PageSize="15" OnPageIndexChanging="grdSearchResult_PageIndexChanging"
                    CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager" 
                    RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record" >                    
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="javascript:expandcollapse('div<%# Eval("BadgeNumber") %>', 'one');">
                                    <img id="imgdiv<%# Eval("BadgeNumber") %>" alt="Click to show/hide Grouping for ColumnName <%# Eval("BadgeNumber") %>"
                                        width="9px" border="0" src="Images/plus.gif" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="BadgeNumber,Status" DataNavigateUrlFormatString="UpdateEmployee.aspx?BadgeNo={0}&StatusInfo={1}"
                            NavigateUrl="UpdateEmployee.aspx"
                            HeaderText="BadgeNumber" DataTextField="BadgeNumber" SortExpression="BadgeNumber" >
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:HyperLinkField>
                        <asp:TemplateField HeaderText="FirstName"  ItemStyle-HorizontalAlign="left" SortExpression="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MiddleName" ItemStyle-HorizontalAlign="left" SortExpression="MiddleName">
                            <ItemTemplate>
                                <asp:Label ID="lblMiddleName" runat="server" Text='<%# Eval("MiddleName") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LastName" ItemStyle-HorizontalAlign="left" SortExpression="LastName">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="130px" />
                            <HeaderStyle Width="130px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NT Login Name" ItemStyle-HorizontalAlign="left" SortExpression="NTLogin">
                            <ItemTemplate>
                                <asp:Label ID="lblNTLogin" runat="server" Text='<%# Eval("NTLogin") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="180px" />
                            <HeaderStyle Width="180px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender" ItemStyle-HorizontalAlign="left" SortExpression="Sex">
                            <ItemTemplate>
                                <asp:Label ID="lblSex" runat="server" Text='<%# Eval("Sex") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="left" SortExpression="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation" ItemStyle-HorizontalAlign="left" SortExpression="Designation">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MaritalStatus" ItemStyle-HorizontalAlign="left" SortExpression="MaritalStatus">
                            <ItemTemplate>
                                <asp:Label ID="lblMaritalStatus" runat="server" Text='<%# Eval("MaritalStatus") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Date Of Birth" ItemStyle-HorizontalAlign="left" DataField="DateOfBirth" SortExpression="DateOfBirth" DataFormatString="{0:MMM d yyyy}" 
                            HtmlEncode="False" >
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Date Of Join" ItemStyle-HorizontalAlign="left" DataField="DateOfJoin" SortExpression="DateOfJoin" DataFormatString="{0:MMM d yyyy}" 
                            HtmlEncode="False" >
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <tr>
                                    <td colspan="100%">
                                        <div id="div<%# Eval("BadgeNumber") %>" style="display: none; position: relative;
                                            left: 15px; overflow: auto; width: 99%">
                                            <asp:GridView ID="GridView2" AllowPaging="False" AllowSorting="true" BackColor="White"
                                                Width="100%" CssClass="Grid" CellPadding="3" AutoGenerateColumns="false" runat="server"
                                                ShowHeader="false" DataKeyNames="BadgeNumber" ShowFooter="true" GridLines="None"
                                                BorderStyle="Double" BorderColor="#0083C1">
                                                <HeaderStyle CssClass="Grid_Header" />
                                                <FooterStyle CssClass="Grid_Summary" />
                                                <PagerStyle CssClass="Grid_Pager" />
                                                <EmptyDataRowStyle CssClass="EmptyCell" />
                                                <RowStyle CssClass="Grid_Record" />
                                                <AlternatingRowStyle CssClass="Grid_Alternate_Record" />
                                                <SelectedRowStyle BackColor="#FFEEC2" />
                                                <Columns>
                                                    <%--<asp:TemplateField HeaderText="BadgeNumber" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                        SortExpression="BadgeNumber">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBadgeNumber" Text='<%# Eval("BadgeNumber") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:HyperLinkField DataNavigateUrlFields="BadgeNumber,Status" DataNavigateUrlFormatString="UpdateEmployee.aspx?BadgeNo={0}&StatusInfo={1}"
                                                        NavigateUrl="UpdateEmployee.aspx"
                                                       DataTextField="BadgeNumber" SortExpression="BadgeNumber" >
                                                        <ItemStyle Width="120px" />
                                                        <HeaderStyle Width="120px" />
                                                    </asp:HyperLinkField>
                                                    <asp:TemplateField HeaderText="FirstName" ItemStyle-HorizontalAlign="left" ItemStyle-Width="150px" HeaderStyle-Width="150px"
                                                        SortExpression="FirstName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MiddleName" ItemStyle-HorizontalAlign="left" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                        SortExpression="MiddleName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMiddleName" runat="server" Text='<%# Eval("MiddleName") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="LastName" ItemStyle-HorizontalAlign="left" ItemStyle-Width="130px" HeaderStyle-Width="130px"
                                                        SortExpression="LastName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="NT Login Name" ItemStyle-HorizontalAlign="left" ItemStyle-Width="180px" HeaderStyle-Width="180px"
                                                        SortExpression="NTLogin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNTLogin" runat="server" Text='<%# Eval("NTLogin") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Gender" ItemStyle-HorizontalAlign="left" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                        SortExpression="Sex">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSex" runat="server" Text='<%# Eval("Sex") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="left" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                        SortExpression="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation" ItemStyle-HorizontalAlign="left" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                        SortExpression="Designation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MaritalStatus" ItemStyle-HorizontalAlign="left" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                        SortExpression="MaritalStatus">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMaritalStatus" runat="server" Text='<%# Eval("MaritalStatus") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Date Of Birth" ItemStyle-HorizontalAlign="left" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                        DataField="DateOfBirth" SortExpression="DateOfBirth" DataFormatString="{0:MMM d yyyy}" 
                                                        HtmlEncode="false" />
                                                    <asp:BoundField HeaderText="Date Of Join" ItemStyle-HorizontalAlign="left" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                        DataField="DateOfJoin" SortExpression="DateOfJoin" DataFormatString="{0:MMM d yyyy}" 
                                                        HtmlEncode="false" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
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
