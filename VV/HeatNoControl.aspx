<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master"
    EnableEventValidation="false" CodeBehind="HeatNoControl.aspx.cs" Inherits="VV.HeatNoControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <div style="margin-left:500px; margin-top: 20px;">
        <asp:Label ID="lblDc" Text="Heat No Control" runat="server"></asp:Label>
        <asp:CheckBox ID="chkCheck" CssClass="textBox" runat="server" />
    </div>
    <div style="margin-left:615px; margin-top: 10px;">
        <div style="margin-top: 10px; margin-bottom:10px;">
        <asp:Button ID="btnSave" Style="font-style: normal;" runat="server" Width="55px" Height="30px" Text="Save" OnClick="btnSave_Click" />
            &nbsp;
        <%--<asp:Button ID="btnUpdate" runat="server" Width="55px" Style="font-style: normal; font-weight: 10px;" Height="30px" Text="Update" OnClick="btnUpdate_Click" />--%>
        &nbsp;<asp:Label ID="lblMessage" CssClass="lblSuccessMessage" style="font-size:medium;" Visible="false" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
