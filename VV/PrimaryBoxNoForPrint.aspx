<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="PrimaryBoxNoForPrint.aspx.cs" Inherits="VV.PrimaryBoxNoForPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=1200,width=1000');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <link href="CSS/Main.css" rel="stylesheet" />
    <div style="text-align: right; margin:10px;">
        <asp:Button ID="btnBack" Width="100px" Height="30px" runat="server" Visible="false" Text="Back" OnClick="btnBack_Click" />
        <asp:Button ID="btnPrint" Width="100px" Height="30px" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
    </div>
    <asp:Panel ID="pnlContents" runat="server">
        <asp:Panel ID="Panel1" runat="server" Style="display: inline;">
            <div style="width: 100%;">
                <table border="0" style="margin: 0px auto; width: 40%; border:1px solid; border-collapse:collapse; ">
                    <tr style="height: 35px; border-bottom:1px solid;">
                        <td colspan="4" style="text-align: left; padding-left: 1px; width: 10%;">
                            <img id="IMG1" align="center" alt="Company Logo"
                                src="Images/logo_velan.png" style="cursor: pointer; width: 147px; height: 39px" />
                            <asp:Label ID="lblLocation" Style="margin: 10px; font-weight:700; font-size:20px;" runat="server" Text="Label"></asp:Label>
                        </td>
                        <%--<td colspan="2" style="text-align: left; font-size: small;">
                            <asp:Label ID="lblLocation" Style="margin-left: 10px;" runat="server" Text="Label"></asp:Label>
                        </td>--%>
                    </tr>
                    <tr style="height: 35px; border-bottom: 1px solid;">
                        <td colspan="1" style="text-align: left; width: 20%">
                            <asp:Label ID="lblBoxNo" runat="server" Text="Box No"></asp:Label>
                            :</td>
                        <td colspan="3" style="text-align: left; font-size: small;">
                            <%--<asp:TextBox ID="TextBox1" Height="25px" Width="350px" runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblTextBoxNo" Style="height: 25px; width: 350px" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 35px; border-bottom: 1px solid;">
                        <td colspan="1" style="text-align: left; width: 20%">
                            <asp:Label ID="lblFigureNo" runat="server" Text="Fig No"></asp:Label>
                            :</td>
                        <td colspan="3" style="text-align: left; font-size: small;">
                            <%--<asp:TextBox ID="txtFigNo" Height="25px" Width="350px" runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblTextFigNo" Style="height: 25px; width: 400px" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 35px; border-bottom: 1px solid;">
                        <td colspan="1" style="text-align: left; width: 20%">
                            <asp:Label ID="lblSize" runat="server" Text="Size"></asp:Label>
                            :</td>
                        <td colspan="1" style="text-align: left; font-size: small;">
                            <%--<asp:TextBox ID="txtSize" Height="25px" Width="130px" runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblTextSize" Style="height: 25px; width: 130px" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="1" style="text-align: left; width: 10%">
                            <asp:Label ID="lblClass" runat="server" Text="Class:"></asp:Label>
                        </td>
                        <td colspan="1" style="text-align: center; font-size: small;">
                            <%--<asp:TextBox ID="txtClass" Height="25px" Width="130px" runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblTextClass" Style="height: 25px; width: 130px" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                    <tr style="height: 35px; border-bottom: 1px solid;">
                        <td colspan="1" style="text-align: left; width: 20%">
                            <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                            :</td>
                        <td colspan="1" style="text-align: left; font-size: small;">
                            <%--<asp:TextBox ID="txtType" Height="25px" Width="130px" runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblTextType" Style="height: 25px; width: 130px" runat="server" Text=""></asp:Label>

                        </td>
                        <td colspan="1" style="text-align: left; width: 10%">
                            <asp:Label ID="lblQty" runat="server" Text="Qty:"></asp:Label></td>
                        <td colspan="1" style="text-align: center; font-size: small;">
                            <%--<asp:TextBox ID="txtQty" Height="25px" Width="130px" runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblTextQty" Style="height: 25px; width: 130px" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 35px; border-bottom: 1px solid;">
                        <td colspan="1" style="text-align: left; width: 20%">
                            <asp:Label ID="lblBodyHeat" runat="server" Text="Body Heat"></asp:Label>
                            :</td>
                        <td colspan="3" style="text-align: left; font-size: small;">
                            <asp:Label ID="lblTextHeatCode" Style="height: 25px; width: 350px" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 35px; border-bottom: 1px solid;">
                        <td colspan="1" style="text-align: left;width: 30%">
                            <asp:Label ID="lblBonnerCoverHeat" runat="server" Text="Bonnet Heat"></asp:Label>
                            :</td>
                        <td colspan="3" style="text-align: left; font-size: small;">
                            <%--<asp:TextBox ID="TextBox3" Height="25px" Width="350px" runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblTextBonnetHeatNo" Style="height: 25px; width: 350px" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>

            </div>
        </asp:Panel>
    </asp:Panel>
    <br />
</asp:Content>

