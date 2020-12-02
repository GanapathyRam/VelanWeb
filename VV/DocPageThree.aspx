<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="DocPageThree.aspx.cs" Inherits="VV.DocPageThree" %>

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
        <asp:Button ID="btnPrint" Width="100px" Height="30px" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
    </div>

<asp:Panel ID="pnlContents" runat="server">
        <asp:Panel ID="Panel4" runat="server" Style="display: inline;">
            <div style="width: 100%;">
                <table border="0" style="margin: 0px auto; width: 95%; border-collapse: separate; border-spacing: 0 5px;  font-family: Times New Roman, Times, serif;">
                    <tr>
                        <td style="width: 20%;">
                            <img id="IMG1" align="center" alt="Company Logo"
                                src="Images/logo_velan.png" style="cursor: pointer; width: 147px; height: 39px" />
                        </td>
                        <td style="width: 45%;">
                            <h3 style="font-weight: 600; font-size:14px; margin: 10px; margin-left:55px; margin-bottom:-2px">INSPECTION CERTIFICATE /  </h3>
                            <h4 style="margin: 10px; font-weight: 600; font-size:14px; margin-left:35px">CERTIFICATE OF CONFORMANCE </h4>
                            <h4 style="margin: 10px; font-weight: 600; font-size:14px; margin-left:100px">(EN 10204-3.1) </h4>
                        </td>
                        <td style="width: 25%; font-size: 10px;">
                            <p>Page 3 of 3 </p>
                            <h7 style="font-weight:600;">Certificate # / Rev: </h7>
                            <asp:Label ID="lblPrimaryBoxNoText" Style="margin-left: 10px; font-weight:600;" runat="server" Text=""></asp:Label> 
                            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / 0
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="font-size:9px; font-weight:600; margin-left:45%;">EN 10204 - 2.1 Valve Specification</p>
                        </td>
                    </tr>
                    </table>
                    <table style="border:1px solid; width:60%;">
                        <tr style="height: 30px; border-bottom: 1px solid; font-size: 10px;">
                            <td colspan="1" style="text-align: left; width: 50%; font-weight:600;">
                                <asp:Label ID="Label11" runat="server" Text="Valve Item"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: left; ;font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label12" Style="height: 25px; width: 350px" runat="server" Text="Specification"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 30px; border-bottom: 1px solid; font-size: 10px;">
                            <td colspan="1" style="text-align: left; width: 50%">
                                <asp:Label ID="Label13" runat="server" Text="DISC"></asp:Label>
                                </td>
                            <td colspan="3" style="text-align: left; border-left: 1px solid;">
                                <asp:Label ID="lblDiscText" Style="height: 25px; width: 350px" runat="server" Text=""></asp:Label>
                            </td>
                         </tr>
                         <tr style="height: 30px; border-bottom: 1px solid; font-size: 10px;">
                            <td colspan="1" style="text-align: left; width: 50%">
                                <asp:Label ID="Label15" runat="server" Text="SEAT"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: left; border-left: 1px solid;">
                                <asp:Label ID="lblSeatText" Style="height: 25px; width: 350px" runat="server" Text=""></asp:Label>
                            </td>
                          </tr>
                          <tr style="height: 30px; border-bottom: 1px solid; font-size: 10px;">
                            <td colspan="1" style="text-align: left; width: 50%">
                                <asp:Label ID="Label17" runat="server" Text="STEM"></asp:Label>
                                </td>
                            <td colspan="3" style="text-align: left; border-left: 1px solid;">
                                <asp:Label ID="lblStemText" Style="height: 25px; width: 350px;" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                <div> 

                    <div style="font-weight:600; margin-left:37%; margin-top:15px; font-size:9px;">Declaration Of Compliance (EN 10204 -2.1)</div>

                    <div style="font-weight:600; font-size:9px; margin-bottom: 10px; margin-left: 35px;">EN 10204 -2.1 PRESSURE BOUNDARY BOLTING  : N/A</div>

                    <div style="font-weight:600; font-size:9px; margin-bottom: 30px; margin-left: 35px;">(up to 39 mm)  : N/A</div> 

                    <p style="font-size:9px; margin-top:10px;">We hereby certify that the valves described above are in conformity with the purchase order and specification requirements</p>

                    <table>
                         <tr style="height: 35px; font-size:9px;">
                            <td colspan="1" style="font-weight:600; text-align:left;">
                                <asp:Label ID="Label19" runat="server" style="margin-left:35px;" Text="List of Tag Numbers for Certificate Number"></asp:Label>
                                :</td>
                            <td colspan="3" style="text-align: left; font-weight:600;">
                                <asp:Label ID="lblCerifiedNoText" Style="height: 25px; width: 50px" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>


                    <table style="margin: 0px auto; width: 40%; border:1px solid; border-collapse:collapse; ">
                        <tr style="height: 25px; border-bottom: 1px solid; font-size:9px;">
                            <td colspan="1" style="text-align: center; font-weight:600; width: 20%">
                                <asp:Label ID="Label21" runat="server" Text="TAG NUMBER"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 25px; border-bottom: 1px solid; font-size:9px;">
                            <td colspan="1" style="text-align: center; width: 20%">
                                <asp:Label ID="Label22" runat="server" Text="NONE"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </div>

                <div style="text-align: center; display: flex; margin: 0 auto; margin-top:30px;">
                    <div style="margin: 0 auto; font-size: 9px;">
                        <img src="Images/MuruganSirSign.bmp" style="width:200px; height:50px" /><br />
                        <span>Murugan Nagappan for</span><br />
                        <hr style="width: 100px; margin-top: 10px ; margin-bottom: 10px; background-color: black; height:1px;" />
                        <span>Velan</span>
                    </div>
                    <div style="margin : 55px auto; font-size: 9px;">
                        <span>
                            <asp:Label ID="lblCreatedOnText" runat="server" Text=""></asp:Label>
                        </span>
                        <br />
                        <hr style="width : 100px; margin-top: 10px ;  margin-bottom: 10px; background-color: black; height:1px;" />
                        <span>Date</span>
                    </div>
                    <div style="margin : 65px auto; font-size: 9px;">
                        <hr style="width: 200px; margin-top: 10px ; margin-bottom: 10px; background-color: black; height:1px;" />
                        <span>Customer Representative</span>
                    </div>

                    <div style="margin : 55px auto; font-size: 9px;">
                        <span>
                            <asp:Label ID="Label24" runat="server" Text=""></asp:Label>
                        </span>
                        <br />
                        <hr style="width: 100px; margin-top: 10px; margin-bottom: 10px; background-color: black; height:1px;" />
                        <span>Date</span>
                    </div>

                </div>

            </div>
        </asp:Panel>
    </asp:Panel>
    </asp:content>
