<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master"
    EnableEventValidation="false" CodeBehind="ProductionOrderImporting.aspx.cs" Inherits="VV.ProductionOrderImporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font: 14px Verdana">
        <p style="margin-left: 400px; font-family: Verdana">Production Order Import: </p>
        <div style="margin-left: 480px; border-color: red;">
            <asp:FileUpload ID="FileUpload" Width="235px" CssClass="Cntrl" runat="server" />
            &nbsp;<input type="button" id="btImport" class="buttonText" value="Upload" style="width: 80px; height: 22px;" onserverclick="btImport_ServerClick" runat="server" />
        </div>
    </div>
    <div style="margin-top: 20px; visibility:hidden; margin-left: 630px;">
        <asp:Button ID="btnProcess" Width="150px" runat="server" Font-Bold="true" CssClass="buttonText" Text="Process" OnClick="btnProcess_Click" />
    </div>

    <div style="margin-left: 500px; margin-top: 10px;">
        <asp:Label ID="lblConfirm" runat="server"></asp:Label>
    </div>
</asp:Content>
