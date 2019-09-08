<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="PatrolReview.aspx.cs" Inherits="VV.PatrolReview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="CSS/Main.css" rel="stylesheet" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-top: 20px;">
        <tr>
            <td style="padding-left: 200px; text-align: right; font-family: Verdana; width: 300px;">
                <asp:Label ID="lblFromDate" Text="From Date" runat="server"></asp:Label>
            </td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtFromDate" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFromDate" Format="dd-MM-yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="margin-left: 100px; text-align: right; font-family: Verdana;">
                <asp:Label ID="lblToDate" Text="To Date" runat="server"></asp:Label></td>
            <td style="padding-left: 10px; width: 220px;">
                <asp:TextBox ID="txtToDate" Height="15px" CssClass="textBox" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtToDate" Format="dd-MM-yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="margin-left: 100px; text-align: right; font-family: Verdana; height: 21px;">
                <asp:Label ID="lblMeetName" Text="Meet Name" runat="server"></asp:Label></td>
            <td style="padding-left: 30px; width: 220px; height: 25px;">
                <asp:DropDownList ID="ddlMeetName" Width="160px" Height="23px" DataTextField="MeetName" DataValueField="MeetCode" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSearch" Style="font-style: normal;" runat="server" Width="90px" Text="Search" OnClick="btnSearch_Click" />
                &nbsp;<asp:Label ID="lblMessage" Visible="false" ForeColor="Green" Font-Bold="true" runat="server" Text="lblMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>

    </table>
    <table style="width: 90%; text-align: right;">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblActionPlan" Style="text-align: center;" runat="server" Text="Action Plan"></asp:Label>
                &nbsp;<asp:TextBox ID="txtActionPlan" runat="server" Width="120px" ToolTip="Enter action plan to be Searched" onKeyUp="ControlSearch(this)" />
                &nbsp;<asp:Label ID="lblResponsibility" runat="server" Text="Responsibility"></asp:Label>
                &nbsp;<asp:TextBox ID="txtResponsibility" runat="server" Width="120px" ToolTip="Enter Responsibility to be Searched" onKeyUp="ControlSearch(this)" />
                &nbsp;<asp:Label ID="lblActionTaken" runat="server" Text="Action Taken"></asp:Label>
                &nbsp;<asp:TextBox ID="txtActionTaken" runat="server" ToolTip="Enter action taken to be Searched" onKeyUp="ControlSearch(this)" />
                &nbsp;<asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlStatus" Width="90px" Height="20px" runat="server">
                    <%--<asp:ListItem Text="--Select--" Value="2"></asp:ListItem>--%>
                    <asp:ListItem Text="Open" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Close" Value="1"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Label ID="lblTargetDate" runat="server" Text="Target Date"></asp:Label>
                &nbsp;<asp:TextBox ID="txtTargetDate" runat="server" ToolTip="Enter target date to be Searched" onKeyUp="ControlSearch(this)" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" TargetControlID="txtTargetDate" Format="dd-MM-yyyy" runat="server">
                </ajaxToolkit:CalendarExtender>
                &nbsp;
                <asp:Button ID="btnUpdate" Style="font-style: normal;" runat="server" Width="90px" Text="Update" OnClick="btnUpdate_Click" />
                &nbsp;
            </td>
        </tr>
    </table>

    <div style="margin-top: 30px;">
        <asp:UpdatePanel ID="EmployeePanel" UpdateMode="always" runat="server">
            <ContentTemplate>
                <div style="width: 1200px; margin-left: 50px; overflow: scroll;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="LocationName" AllowPaging="true" PageSize="24" AllowSorting="false"
                        OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-HorizontalAlign="Left"
                        CssClass="Grid" HeaderStyle-CssClass="Grid_Header" OnSorting="GridView1_Sorting"
                        RowStyle-CssClass="Grid_Record" EmptyDataText="No Records To Display"
                        CellPadding="3">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" EnableViewState="false" runat="server" onclick="EnableTextBox(this)" />
                                     <asp:HiddenField ID="hidPatrolNumber" runat="server" Value='<%#Bind("PatrolNumber") %>' />
                                     <asp:HiddenField ID="hidCheckListSerial" runat="server" Value='<%#Bind("CheckListSerial") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Patrol Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridPatrolDate" runat="server" Text='<%# Eval("PatrolDate") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>--%>
                             <asp:BoundField HeaderText="Patrol Date" ItemStyle-HorizontalAlign="left" DataField="PatrolDate" SortExpression="PatrolDate" 
                                DataFormatString="{0:dd-MM-yyyy}"
                                HtmlEncode="False">
                                <ItemStyle Wrap="false" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Patrol No">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridPatrolNo" runat="server" Text='<%# Eval("PatrolNumber") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Location Name" SortExpression="LocationName">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridLocationName" runat="server" Text='<%# Eval("LocationName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" SortExpression="SubLocationName" HeaderText="SubLocation Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridSubLocationName" runat="server" Text='<%# Eval("SubLocationName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" SortExpression="CheckListSerial" HeaderText="CheckList Serial">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridCheckListSerial" runat="server" Text='<%# Eval("CheckListSerial") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Prod Order No">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridProdOrderNo" runat="server" Text='<%# Eval("ProdOrderNo") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Item">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridItem" runat="server" Text='<%# Eval("Item") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridDescription" runat="server" Text='<%# Eval("Description") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="CheckList Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridCheckListDescription" runat="server" Text='<%# Eval("CheckListDescription") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Meet Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridMeetName" runat="server" Text='<%# Eval("MeetName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Meets Comments">
                                <ItemTemplate>
                                    <asp:Label ID="lblMeetsComments" runat="server" Text='<%# Eval("MeetsComments") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action Plan">
                                <ItemTemplate>
                                    <asp:Label ID="lblActionPlan" runat="server" Text='<%# Eval("ActionPlan") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Responsibility">
                                <ItemTemplate>
                                    <asp:Label ID="lblResponsibility" runat="server" Text='<%# Eval("Responsibility") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action Taken">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridActionTaken" runat="server" Text='<%# Eval("ActionTaken") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Status">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkShipped" Enabled="false" runat="server" Checked='<%# Eval("Status") %>' />
                                   <%-- <asp:Label ID="lblGridStatus" runat="server" Text='<%# Eval("Status") %>'>
                                    </asp:Label>--%>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="TargetDate">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lblTargetDate" runat="server" Text='<%# Eval("TargetDate") %>'></asp:Label>--%>
                                    <asp:Label ID="lblTargetDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TargetDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>

                            <%--<asp:BoundField HeaderText="Target Date" ItemStyle-HorizontalAlign="left" DataField="TargetDate" SortExpression="TargetDate" 
                                DataFormatString="{0:dd-MM-yyyy}"
                                HtmlEncode="False">
                                <ItemStyle Wrap="false" />
                            </asp:BoundField>--%>

                        </Columns>
                        <HeaderStyle CssClass="Grid_Header" />
                        <FooterStyle CssClass="Grid_Summary" />
                        <PagerStyle CssClass="Grid_Pager" />
                        <EmptyDataRowStyle CssClass="EmptyCell" />
                        <%--<RowStyle CssClass="Grid_Record" />--%>
                        <SelectedRowStyle BackColor="#FFEEC2" />
                        <%--<PagerSettings Position="TopAndBottom" />--%>
                        <RowStyle CssClass="Grid_RowRecord" />
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
