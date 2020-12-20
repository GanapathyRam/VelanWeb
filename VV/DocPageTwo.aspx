<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/VV.Master" CodeBehind="DocPageTwo.aspx.cs" Inherits="VV.DocPageTwo" %>

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
    <div style="position: absolute; right: 10px; top: 110px">
        <asp:Button ID="btnBack" Width="100px" Height="30px" runat="server" Visible="false" Text="Back" OnClick="btnBack_Click" />
        <asp:Button ID="btnPrint" Width="100px" Height="30px" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
    </div>

    <asp:Panel ID="pnlContents" runat="server">
        <asp:Panel ID="Panel3" runat="server" Style="display: inline;">
            <div style="width: 100%;">
                <table border="0" style="margin: 0px auto; width: 100%; border-collapse: separate; border-spacing: 0 5px;  font-family: Times New Roman, Times, serif;">
                    <tr>
                        <td style="width: 20%;">
                            <img id="IMG1" align="center" alt="Company Logo"
                                src="Images/logo_velan.png" style="cursor: pointer; width: 147px; height: 39px" />
                        </td>
                        <td style="width: 45%;">
                            <h3 style="font-weight: 600; font-size:14px; margin: 10px; margin-left:55px; margin-bottom:-2px">INSPECTION CERTIFICATE /  </h3>
                            <h4 style="margin: 10px; font-weight: 600; font-size:14px; margin-left:35px; margin-bottom:-2px">CERTIFICATE OF CONFORMANCE </h4>
                            <h4 style="margin: 10px; font-weight: 600; font-size:14px; margin-left:100px">(EN 10204-3.1) </h4>
                        </td>
                        <td style="width: 25%; font-size: 10px;">
                            <%--<p>Page 2 of 3 </p>--%>
                            <h7 style="font-weight:600;">Certificate # / Rev: </h7>
                            <asp:Label ID="lblPrimaryBoxNo" Style="margin-left: 10px; font-weight:600;" runat="server" Text=""></asp:Label> 
                            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / 0
                        </td>
                    </tr>
                    <tr style="line-height:2;">
                    <asp:Panel ID="Panel1" Visible="false" runat="server">            
                        <td style="text-align: left; width: 24%; font-size: 9px;">
                            <asp:Label ID="lblSize" runat="server" Text="Company 41"></asp:Label><br>
                            <asp:Label ID="Label16" runat="server" Text="Velan Valves India Pvt Ltd"></asp:Label><br>
                            <asp:Label ID="Label22" runat="server" Text="S.F No.337/1,"></asp:Label><br>
                            <asp:Label ID="Label23" runat="server" Text="Thennampalayam-Annur Road"></asp:Label><br>
                            <asp:Label ID="Label24" runat="server" Text="Naranapuram Village"></asp:Label><br>
                            <asp:Label ID="Label25" runat="server" Text="Coimbatore-641 659 India"></asp:Label>
                        </td>
                        <td style="text-align: left; width: 30%; font-size: 9px;">
                            <asp:Label ID="lblCustomerName" runat="server" Style="font-weight: bold" Text="Customer Name :"></asp:Label>
                            &nbsp;<asp:Label ID="lblCustomerNameText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblCustomerPO" runat="server" Style="font-weight: bold" Text="Customer PO :"></asp:Label>
                            &nbsp;<asp:Label ID="lblCustomerPOText" runat="server" Text=""></asp:Label><br>
                            <asp:Label ID="lblPEDCategory" runat="server" Style="font-weight: bold" Text="Design Spec :"></asp:Label>
                            &nbsp;<asp:Label ID="lblPEDCategoryText" runat="server" Text="B 16.34"></asp:Label><br>
                            <asp:Label ID="lblPEDFluidGroup" runat="server" Style="font-weight: bold" Text="Drawing Number :"></asp:Label>
                            &nbsp;<asp:Label ID="lblPEDFluidGroupText" runat="server" Text="N/A Rev. N/A"></asp:Label><br>
                            <asp:Label ID="lblApplicableStds" runat="server" Style="font-weight: bold" Text="Tag Number(s) :"></asp:Label>
                            &nbsp;<asp:Label ID="lblApplicableStdsText" runat="server" Text="See Attached"></asp:Label><br>
                         <%--   <asp:Label ID="lblOtherAppDirectives" runat="server" Style="font-weight: bold" Text="Other App. Directiives :"> </asp:Label>
                            &nbsp;<asp:Label ID="lblOtherAppDirectivesText" runat="server" Text="ATEX 2014/34/EU, Group II Cat 2 G/D">
                            </asp:Label>--%>
                        </td>
                        <td style="text-align: left; width: 40%; font-size: 9px;">
                            <asp:Label ID="lblVelanOrder" runat="server" Style="font-weight: bold" Text="Velan Order # :"></asp:Label>
                            &nbsp;<asp:Label ID="lblVelanOrdertext" runat="server" Text=""></asp:Label>
                             <asp:Label ID="Label30" runat="server" Style="font-weight: bold; padding-left:5px;" Text="Position :"></asp:Label>
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
                            <%--<asp:Label ID="lblDrawingNo" runat="server" Style="font-weight: bold" Text="Drawing Number :"></asp:Label>
                                &nbsp;<asp:Label ID="lblDrawingNoText" runat="server" Text="N/A Rev. N/A">
                                </asp:Label>--%>
                        </td>
                        </asp:Panel>
                    </tr>
                    
                </table>

                <table style="border:1px solid; width:100%; margin-top:-5px;">
                        <tr style="height: 20px; font-size: 10px;">
                            <td colspan="1" style="text-align: left; width: 25%; padding-left:15px; font-weight:600;">
                                <asp:Label ID="lblBodyHeat" runat="server" Text="Test Standard :"></asp:Label>
                                &nbsp;<asp:Label ID="lblTeststd" runat="server" Text="ABC"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 25%; font-weight:600;">
                                <asp:Label ID="Label1" runat="server" Text="Dimensional Examination : "></asp:Label>
                                &nbsp;<asp:Label ID="lbltext" runat="server" Text="ACCEPTABLE"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 25%; font-weight:600;">
                                <asp:Label ID="Label7" runat="server" Text="Markings MSS SP-25 :"></asp:Label>
                                &nbsp;<asp:Label ID="Label2" runat="server" Text="ACCEPTABLE"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 25%; font-weight:600;">
                                <asp:Label ID="Label3" runat="server" Text="Visual :"></asp:Label>
                                &nbsp;<asp:Label ID="Label5" runat="server" Text="ACCEPTABLE"></asp:Label>
                            </td>
                        </tr>
                    </table>
                <table style="border:1px solid; width:75%; margin: 0 auto; margin-top:10px; border-collapse:collapse;">
                        <tr style="height: 20px; border-bottom: 1px solid; font-size: 10px;">
                            <td colspan="1" style="text-align: center; width: 10%; font-weight:600;">
                                <asp:Label ID="Label11" runat="server" Text="Test Type"></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; ;font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label12" Style="height: 25px; width: 10%" runat="server" Text="Shell"></asp:Label>
                            </td>
                             <td colspan="1" style="text-align: center; ;font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label4" Style="height: 25px; width: 10%" runat="server" Text="Packing"></asp:Label>
                            </td>
                             <td colspan="1" style="text-align: center; ;font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label6" Style="height: 25px; width: 10%" runat="server" Text="Seat (HP)"></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; ;font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label8" Style="height: 25px; width: 10%" runat="server" Text="Seat (LP)"></asp:Label>
                            </td>
                             <td colspan="1" style="text-align: center; ;font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label9" Style="height: 25px; width: 10%" runat="server" Text="Backseat"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 20px; border-bottom: 1px solid; font-size: 10px;">
                            <td colspan="1" style="text-align: center; width: 10%; font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label13" runat="server" Text="Duration (sec)"></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblShellTime" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblPackingTime" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblSeatHPTime" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblSeatLPTime" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblBackseatTime" runat="server" Text=""></asp:Label>
                            </td>
                         </tr>
                         <tr style="height: 20px; border-bottom: 1px solid; font-size: 10px;">
                            <td colspan="1" style="text-align: center; width: 10%; font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label15" runat="server" Text="Pressure (psig)"></asp:Label>
                            </td>
                             <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblShell" runat="server" Text=""></asp:Label>
                            </td>
                             <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblPacking" runat="server" Text=""></asp:Label>
                            </td>
                             <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblSeatHP" runat="server" Text=""></asp:Label>
                            </td>
                             <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblSeatLP" runat="server" Text=""></asp:Label>
                            </td>
                             <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblBackseat" runat="server" Text=""></asp:Label>
                            </td>
                          </tr>
                          <tr style="height: 20px; border-bottom: 1px solid; font-size: 10px;">
                            <td colspan="1" style="text-align: center; width: 10%; font-weight:600; border-left: 1px solid;">
                                <asp:Label ID="Label17" runat="server" Text="Result"></asp:Label>
                            </td>
                              <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblShellResult" runat="server" Text=""></asp:Label>
                            </td>
                              <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblPackingResult" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblSeatHPResult" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblSeatLPResult" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" style="text-align: center; width: 10%; border-left: 1px solid;">
                                <asp:Label ID="lblBackseatResult" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                     
                <div class="SecondGrid" id="secondGrid" runat="server">
                     <table style="border: 1px solid; width: 100%; margin: 0 auto; margin-top: 10px; border-collapse:collapse;">
                        <tr style="height: 25px; border-bottom: 1px solid; font-size: 10px;">
                            <td style="text-align: center; width: 5%; font-weight: 600;">
                                <span>Supplier</span>
                            </td>
                            <td style="text-align: center; width: 5%; font-weight: 600; border-left: 1px solid;">
                                <span Style="height: 25px; width: 10%"> Heat Code</span>
                            </td>
                            <td style="text-align: center; width: 6%; font-weight: 600; border-left: 1px solid;">
                                <span Style="height: 25px; width: 10%">ASTM Code</span>
                            </td>
                            <td style="text-align: center; width: 8%; font-weight: 600; border-left: 1px solid;">
                                <span Style="height: 25px; width: 10%">Description</span>
                            </td>
                            <td style="text-align: center; width: 40%; font-weight: 600; border-left: 1px solid;">
                                <span Style="height: 25px; width: 10%">CHEMICALS</span>
                            </td>
                            <td style="text-align: center; width: 37%; font-weight: 600; border-left: 1px solid;">
                                <span Style="height: 25px; width: 10%">MECHANICALS</span>
                            </td>
                        </tr>

                        <tr style="height: 30px; margin-bottom: 10px; font-size: 8px;">                        
                        <td colspan="1" style="text-align: center; width: 5%; font-weight: 600; border-left: 1px solid;">
                            <span>ABC</span>
                        </td>

                        <td colspan="1" style="text-align: center; width: 5%; border-left: 1px solid;">                            
                           <span>ABC</span>
                        </td>
                        <td colspan="1" style="text-align: center; width: 6%; border-left: 1px solid;">                           
                            <span>ABC</span>
                        </td>
                        <td colspan="1" style="text-align: center; width: 8%; border-left: 1px solid;">
                            <span>ABC</span>
                        </td>

                        <td style="text-align: left; border-left: 1px solid; display:flex;">
                            <div style="width:28%;">
                                <span style="padding: 6px 0 5px 3px;">Carbon (C)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Sulfur (S)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Nickel (Ni)></span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Vanadium (V)></span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">CE</span>
                                &nbsp;<span>ABC</span><br/>
                            </div>
                             <div style="width:28%;">
                                <span style="padding: 6px 0 5px 3px;">Manganese (Mn)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Silicon (Si)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Chromium (Cr)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span></span>
                                &nbsp;<span></span><br/>
                            </div>
                             <div style="width:33%;">
                               <span style="padding: 6px 0 5px 3px;">Phosphorous (P)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Copper (Cu)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Molybdenum (Mo)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;"></span>
                                &nbsp;<span></span><br/>
                            </div>
                        </td>
                        <td style="text-align: left; border-left: 1px solid;">
                             <div style="width:30%; display:inline-block;">
                               <span style="padding: 6px 0 5px 3px;">Tensile (MPa)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Yield (ksi)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Hardness (HB)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Heat Treatment</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;"></span>
                                &nbsp;<span></span><br/>
                            </div>
                             <div style="width:30%; display:inline-block;">
                                <span style="padding: 6px 0 5px 3px;">Tensile (ksi)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span style="padding: 6px 0 5px 3px;">Elongation (%)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span></span>
                                &nbsp;<span></span><br/>
                                <span></span>
                                &nbsp;<span></span><br/>
                                <span></span>
                                &nbsp;<span></span><br/>
                            </div>
                             <div style="width:24%; display:inline-block;">
                                <span style="padding: 6px 0 5px 3px;">Yield (MPa)</span>
                                &nbsp;<span></span><br/>
                                <span style="padding: 6px 0 5px 3px;">Reduction of Area(%)</span>
                                &nbsp;<span>ABC</span><br/>
                                <span></span>
                                &nbsp;<span></span><br/>
                                <span></span>
                                &nbsp;<span></span><br/>
                                <span></span>
                                &nbsp;<span></span><br/>
                            </div>
                        </td>
                    </tr>
                </table>
                   </div>

               
            </div>
        </asp:Panel>
    </asp:Panel>

</asp:Content>
