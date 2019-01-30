<%@ Page Title="QR & QA Sales Summary" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" Culture="en-IN" CodeBehind="ViewQRAndQASalesSummary.aspx.cs" Inherits="VV.ViewQRAndQASalesSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script language="javascript" type="text/javascript">
    </script>

     <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="25%">
                <asp:Label ID="lblPageTitle" runat="server" Text="View QR & QA Sales Summary" />            
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
                        <asp:BoundField DataField="Month1" HeaderText="Month1" SortExpression="Month1" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="Month2" HeaderText="Month2" SortExpression="Month2" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="Month3" HeaderText="Month3" SortExpression="Month3" DataFormatString="{0:N0}" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" />
                        <%--<asp:TemplateField HeaderText="Amount (INR)"  ItemStyle-HorizontalAlign="Right" SortExpression="Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount","{0:c0}") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Month1"  ItemStyle-HorizontalAlign="left" SortExpression="Month1">
                            <ItemTemplate>
                                <asp:Label ID="lblMonth1" runat="server" Text='<%# Eval("Month1") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Month2"  ItemStyle-HorizontalAlign="left" SortExpression="Month2">
                            <ItemTemplate>
                                <asp:Label ID="lblMonth2" runat="server" Text='<%# Eval("Month2") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Month3"  ItemStyle-HorizontalAlign="left" SortExpression="Month3">
                            <ItemTemplate>
                                <asp:Label ID="lblMonth3" runat="server" Text='<%# Eval("Month3") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="ITP"  ItemStyle-HorizontalAlign="left" SortExpression="ITP">
                            <ItemTemplate>
                                <asp:Label ID="lblITP" runat="server" Text='<%# Eval("ITP") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A/ITP"  ItemStyle-HorizontalAlign="left" SortExpression="AITP">
                            <ItemTemplate>
                                <asp:Label ID="lblAITP" runat="server" Text='<%# Eval("AITP") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GAD"  ItemStyle-HorizontalAlign="left" SortExpression="GAD">
                            <ItemTemplate>
                                <asp:Label ID="lblGAD" runat="server" Text='<%# Eval("GAD") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A/GAD"  ItemStyle-HorizontalAlign="left" SortExpression="AGAD">
                            <ItemTemplate>
                                <asp:Label ID="lblAGAD" runat="server" Text='<%# Eval("AGAD") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inspection1"  ItemStyle-HorizontalAlign="left" SortExpression="Inspection1">
                            <ItemTemplate>
                                <asp:Label ID="lblInspection1" runat="server" Text='<%# Eval("Inspection1") %>' />
                            </ItemTemplate>
                            <ItemStyle Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inspection2"  ItemStyle-HorizontalAlign="left" SortExpression="Inspection2">
                            <ItemTemplate>
                                <asp:Label ID="lblInspection2" runat="server" Text='<%# Eval("Inspection2") %>' />
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
