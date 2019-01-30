<%@ Page Title="Freeze Plan" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true"  Culture="en-IN" CodeBehind="FreezePlan.aspx.cs" Inherits="VV.FreezePlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="height: 100%;" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="secondLevelHeader" width="30%">
                <asp:Label ID="lblPageTitle" runat="server" Text="Freeze Plan" />
            </td>

            <%--Added by Arun on 26-Dec'07.
            To show the Progress Bar image when any of the operations are done--%>
            <td class="secondLevelHeader" align="left" width="10%">
                <%--<asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        Loading.....<asp:Image ID="ImgLoad" runat="server" ImageUrl="~/Images/loading.gif" EnableTheming="true" ImageAlign="AbsMiddle" />
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
            </td>
           
            <td width="60%" align="right" style="padding-left: 360px;" class="secondLevelHeader">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnFreeze" Text="Freeze" runat="server" CssClass="buttonText" onclick="btnFreeze_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
