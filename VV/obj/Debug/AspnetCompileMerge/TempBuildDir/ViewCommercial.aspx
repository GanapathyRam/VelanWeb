<%@ Page Title="View Commercial" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" Culture="en-IN" CodeBehind="ViewCommercial.aspx.cs" Inherits="VV.ViewCommercial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script language="javascript" type="text/javascript">
    </script>

     <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="12%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View Commercial" />            
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
            <td width="83%" align="right" style="padding-left:10px;" class="secondLevelHeader">
                <%--Added by Arun to implement the search on pressing enter itslef--%>
                <asp:Panel ID="SearchPanel" DefaultButton="btnSearchBox" runat="server">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <asp:Label ID="lblOrderType" runat="server" Text="Choose Order Type" CssClass="plainTextForSecondLevelHeaderData"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="ChkOrderType" BorderColor="Maroon" runat="server" RepeatDirection="Horizontal" CssClass="plainTextForSecondLevelHeaderData" >
                                <asp:ListItem Text="ICS" Value="ICS" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="M" Value="M" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="X" Value="X" Selected="True"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <td style="padding-left:20px;">
                            <asp:Label ID="lblWeek" Text="Enter Week No" runat="server" CssClass="plainTextForSecondLevelHeaderData"></asp:Label>
                            <asp:TextBox ID="txtWeekNo" runat="server" ToolTip="Enter Week No" />
                            <asp:RequiredFieldValidator CssClass="plainTextForSecondLevelHeaderData" ID="reqval" runat="server" ControlToValidate="txtWeekNo" Display="Dynamic" ErrorMessage="Week No is Mandatory"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator  CssClass="plainTextForSecondLevelHeaderData" ID="weekValidator1" runat="server" ControlToValidate="txtWeekNo" ValidationExpression="^[1-9]$|^[1-4][0-9]$|^5[0-2]$" ErrorMessage="Only Numbers between 1 and 52" Display="Dynamic" ></asp:RegularExpressionValidator>
                            <asp:Button ID="btnSearchBox" runat="server" Text="View Data" OnClick="btnSearchBox_Click" ToolTip="Click to View Data" CssClass="buttonText"/>
                            <asp:ImageButton ID="imgExcel" runat="server" AlternateText="Export To Excel" ImageUrl="~/Images/excel.jpg" OnClick="btnExcel_Click" Height="25px" Width="25px" />
                        </td>
                    </tr>
                </table>
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
                <asp:GridView ID="grdViewResult" DataKeyNames="OrderNo" ShowHeader="true" AllowSorting="false" AllowPaging="true" 
                    AutoGenerateColumns="false" runat="server" EmptyDataText="No Records To Display" PageSize="23"
                    CellPadding="3" OnPageIndexChanging="grdViewResult_PageIndexChanging" CssClass="Grid" HeaderStyle-CssClass="Grid_Header" PagerStyle-CssClass="Grid_Pager" 
                    RowStyle-CssClass="Grid_Record" AlternatingRowStyle-CssClass="Grid_Alternate_Record">                    
                    <Columns>
                        <asp:TemplateField HeaderText="OrderNo"  ItemStyle-HorizontalAlign="left" SortExpression="Type">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Name"  ItemStyle-HorizontalAlign="left" SortExpression="CustomerName">
                            <ItemTemplate>
                                <asp:Label ID="lblCustName" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount (INR)" SortExpression="Amount" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="CurrentMonth" HeaderText="CurrentMonth" SortExpression="CurrentMonth" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />
                       <%-- <asp:TemplateField HeaderText="Amount (INR)"  ItemStyle-HorizontalAlign="Right" SortExpression="Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount","{0:c0}") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="CurrentMonth"  ItemStyle-HorizontalAlign="left" SortExpression="CurrentMonth">
                            <ItemTemplate>
                                <asp:Label ID="lblCurrentMonth" runat="server" Text='<%# Eval("CurrentMonth") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="ABG"  ItemStyle-HorizontalAlign="left" SortExpression="ABG">
                            <ItemTemplate>
                                <asp:Label ID="lblABG" runat="server" Text='<%# Eval("ABG") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PBG"  ItemStyle-HorizontalAlign="left" SortExpression="PBG">
                            <ItemTemplate>
                                <asp:Label ID="lblPBG" runat="server" Text='<%# Eval("PBG") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RP"  ItemStyle-HorizontalAlign="left" SortExpression="RP">
                            <ItemTemplate>
                                <asp:Label ID="lblRP" runat="server" Text='<%# Eval("RP") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hold1"  ItemStyle-HorizontalAlign="left" SortExpression="Hold1">
                            <ItemTemplate>
                                <asp:Label ID="lblHold1" runat="server" Text='<%# Eval("Hold1") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hold2"  ItemStyle-HorizontalAlign="left" SortExpression="Hold2">
                            <ItemTemplate>
                                <asp:Label ID="lblHold2" runat="server" Text='<%# Eval("Hold2") %>' />
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
