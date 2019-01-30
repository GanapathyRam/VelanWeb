<%@ Page Title="Tag No Details" Language="C#" MasterPageFile="~/VV.Master" AutoEventWireup="true" Culture="en-IN" CodeBehind="TagNoDetails.aspx.cs"
    Inherits="VV.TagNoDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font: 14px Verdana">
        <p style="margin-left: 400px; font-family: Verdana">Import Tag No Details: </p>
        <div style="margin-left: 480px; border-color: red;">
            <asp:FileUpload ID="FileUpload" Width="235px" CssClass="Cntrl" runat="server" />
            &nbsp;<input type="button" id="btImport" class="buttonText" value="Upload" style="width: 80px; height: 22px;" onserverclick="btImport_ServerClick" runat="server" />
            &nbsp;Available counts :
            <asp:Label ID="lblTagNoDetailsCount" runat="server" Text="" Style="font-weight: 700"></asp:Label>
        </div>
    </div>
</asp:Content>
