<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" Culture="en-IN" CodeBehind="StatusImporting.aspx.cs" Inherits="VV.StatusImporting"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function Check(parentChk) {

            var elements = document.getElementsByTagName("INPUT");
            for (i = 0; i < elements.length; i++) {
                if (parentChk.checked == true) {
                    if (IsCheckBox(elements[i])) {
                        elements[i].checked = true;
                    }

                }
                else {
                    if (IsCheckBox(elements[i])) {
                        elements[i].checked = false;
                    }
                }
            }
        }

        function IsCheckBox(chk) {
            return (chk.type == 'checkbox');
        }
    </script>

    <div style="font: 14px Verdana">
        <p style="margin-left: 400px; font-family: Verdana">File Import: </p>
        <div style="margin-left: 480px; border-color: red;">
            <asp:FileUpload ID="FileUpload" Width="235px" CssClass="Cntrl" runat="server" />
            &nbsp;<input type="button" id="btImport" class="buttonText" value="Upload" style="width: 80px; height: 22px;" onserverclick="btImport_ServerClick" runat="server" />
            <%--&nbsp;Available counts : <asp:Label ID="lblBomCount" runat="server" Text="" style="font-weight: 700"></asp:Label>--%>
        </div>
    </div>
     <div style="margin-left: 500px; margin-top: 10px;">
            <asp:Label ID="lblConfirm" runat="server"></asp:Label>
        </div>
</asp:Content>


