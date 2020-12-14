<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocPageOne.aspx.cs" MasterPageFile="~/VV.Master" Inherits="VV.DocPageOne" %>

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
    <div style="position: absolute; right: 10px; top:110px">
        <asp:Button ID="btnBack" Width="100px" Height="30px" runat="server" Visible="false" Text="Back" OnClick="btnBack_Click" />
        <asp:Button ID="btnPrint" Width="100px" Height="30px" runat="server" Visible="false" Text="Print" OnClientClick="return PrintPanel();" />
    </div>

    <asp:Panel ID="pnlContents" runat="server">
        <asp:Panel ID="Panel1" runat="server" Style="display: inline;">
            <div style="width: 100%;">
                <table border="0" style="margin: 0px auto; width: 95%; border-collapse: separate; border-spacing: 0 5px;  font-family: Times New Roman, Times, serif;">
                    <tr>
                        <td style="width: 20%;">
                            <img id="IMG1" align="center" alt="Company Logo"
                                src="Images/logo_velan.png" style="cursor: pointer; width: 147px; height: 39px" />
                            <%--   <asp:Label ID="lblLocation" Style="margin: 10px; font-weight:700; font-size:20px;" runat="server" Text="Label"></asp:Label>--%>
                        </td>
                        <td style="width: 45%;">
                            <h3 style="font-style: italic; font-weight: 600; font-size:16px; margin: 10px; margin-left:55px; margin-bottom:-2px">EU Declaration of Conformity </h3>
                            <p style="margin: 10px; margin-left:110px; font-size:10px;">Issued in accordance with the</p>
                            <h4 style="margin: 10px; font-size:10px; font-weight:normal; margin-left:35px">PRESSURE EQUIPMENT DIRECTIVE (PED) 2014/68/EU</h4>
                            <%--<asp:Label ID="lblLocation" Style="margin-left: 10px;" runat="server" Text="Label"></asp:Label>--%>
                        </td>
                        <td style="width: 25%; font-size: 10px;">
                            <p>Page 1 of 3 </p>
                            <h7 style="font-weight:600;">Certificate # / Rev: </h7>
                            <asp:Label ID="lblPrimaryBoxNo" Style="margin-left: 10px; font-weight:600;" runat="server" Text=""></asp:Label> 
                            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / 0
                        </td>
                    </tr>

                    <tr style="line-height:2;">
                        <td style="text-align: left; width: 24%; font-size: 9px;">
                            <asp:Label ID="lblSize" runat="server" Text="Company 41"></asp:Label><br>
                            <asp:Label ID="Label1" runat="server" Text="Velan Valves India Pvt Ltd"></asp:Label><br>
                            <asp:Label ID="Label2" runat="server" Text="S.F No.337/1,"></asp:Label><br>
                            <asp:Label ID="Label3" runat="server" Text="Thennampalayam-Annur Road"></asp:Label><br>
                            <asp:Label ID="Label4" runat="server" Text="Naranapuram Village"></asp:Label><br>
                            <asp:Label ID="Label5" runat="server" Text="Coimbatore-641 659 India"></asp:Label>
                        </td>
                        <td style="text-align: left; width: 30%; font-size: 9px;">
                            <asp:Label ID="lblCustomerName" runat="server" Style="font-weight: bold" Text="Customer Name :"></asp:Label>
                            &nbsp;<asp:Label ID="lblCustomerNameText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblCustomerPO" runat="server" Style="font-weight: bold" Text="Customer PO :"></asp:Label>
                            &nbsp;<asp:Label ID="lblCustomerPOText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblPEDCategory" runat="server" Style="font-weight: bold" Text="PED Category :"></asp:Label>
                            &nbsp;<asp:Label ID="lblPEDCategoryText" runat="server" Text="III"></asp:Label><br>
                            <asp:Label ID="lblPEDFluidGroup" runat="server" Style="font-weight: bold" Text="PED Fluid Group :"></asp:Label>
                            &nbsp;<asp:Label ID="lblPEDFluidGroupText" runat="server" Text="1"></asp:Label><br>
                            <asp:Label ID="lblApplicableStds" runat="server" Style="font-weight: bold" Text="Applicable stds :"></asp:Label>
                            &nbsp;<asp:Label ID="lblApplicableStdsText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblOtherAppDirectives" runat="server" Style="font-weight: bold" Text="Other App. Directiives :"> </asp:Label>
                            &nbsp;<asp:Label ID="lblOtherAppDirectivesText" runat="server" Text="ATEX 2014/34/EU, Group II Cat 2 G/D">
                            </asp:Label>
                        </td>
                        <td style="text-align: left; width: 40%; font-size: 9px;">
                            <asp:Label ID="lblVelanOrder" runat="server" Style="font-weight: bold" Text="Velan Order # :"></asp:Label>
                            &nbsp;<asp:Label ID="lblVelanOrdertext" runat="server" Text=""></asp:Label>
                             <asp:Label ID="Label6" runat="server" Style="font-weight: bold; padding-left:5px;" Text="Position :"></asp:Label>
                            &nbsp;<asp:Label ID="lblPosText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblCustomerOrderPos" runat="server" Style="font-weight: bold" Text="Customer Order Pos :"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblCustomerOrderPosText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblQuantity" runat="server" Style="font-weight: bold" Text="Quantity :"></asp:Label>
                            &nbsp;<asp:Label ID="lblQuantitytext" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblFigureNumber" runat="server" Style="font-weight: bold" Text="Figure Number  :"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblFigureNumberText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblDescription" runat="server" Style="font-weight: bold" Text="Description :"></asp:Label>
                            &nbsp;<asp:Label ID="lblDescriptionText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblDrawingNo" runat="server" Style="font-weight: bold" Text="Drawing Number :"></asp:Label>
                                &nbsp;<asp:Label ID="lblDrawingNoText" runat="server" Text="N/A Rev. N/A">
                                </asp:Label>
                        </td>
                        <%--<td colspan="1" style="text-align: left; width: 10%">
                            <asp:Label ID="lblClass" runat="server" Text="Class:"></asp:Label>
                        </td>--%>
                        <%--<td colspan="1" style="text-align: center; font-size: small;">
                            <asp:TextBox ID="txtClass" Height="25px" Width="130px" runat="server"></asp:TextBox>
                            <asp:Label ID="lblTextClass" Style="height: 25px; width: 130px" runat="server" Text=""></asp:Label>

                        </td>--%>
                    </tr>

                    <tr style="line-height:2; font-size: 11px;">
                        <td colspan="12">
                            <p>We hereby declare that the products detailed above have been designed, manufactured, and tested in accordance with a quality assurance system subjected to conformity assessment module D as
                            approved on Certificate Number CE-0062-PED-D-VVI 001-17-IND-rev-A by Bureau Veritas S. A. (Notified Body No. 0062) of 67-71 Boulevard du Chateau, 92200 Neuilly sur Seine, France.
                             </p>
                        </td>
                    </tr>
                    <tr style="line-height:2; font-size:11px;">
                        <td colspan="12">We hereby declare that the products detailed above comply with the requirements of ATEX 2014/34/EU and that, in accordance with the requirements of Annex VIII, the applicable technical files
                           have been submitted to Bureau Veritas UK Ltd. (Notified Body No. 0041) of Parklands 825A Wilmslow Road, Didsbury, Manchester M20 2RE, UK.
                        </td>
                    </tr>
                </table>

                <div style="text-align: center; display: flex; margin: 0 auto; margin-top:30px;">
                    <div style="margin: 0 auto; font-size: 9px;">
                        <img src="Images/MuruganSirSign.bmp" style="width:200px; height:50px" /><br />
                        <span>Murugan Nagappan for</span><br />
                        <hr style="width: 100px; margin-top: 10px; margin-bottom: 10px" />
                        <span>Velan</span>
                    </div>

                    <div style="margin: 55px auto; font-size: 9px;">
                        <span>
                            <asp:Label ID="lblCreatedOn" runat="server" Text=""></asp:Label>
                        </span>
                        <br />
                        <hr style="width: 100px; margin-top: 10px; margin-bottom: 10px" />
                        <span>Date</span>
                    </div>

                </div>

            </div>
        </asp:Panel>
    </asp:Panel>

</asp:Content>
