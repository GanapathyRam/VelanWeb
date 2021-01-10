using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class DocPageTwo : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DBUtil _dbObj = new DBUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            # region Master Control

            # region Welcome Msg
            string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
            System.Web.UI.WebControls.Label lblUserName = (System.Web.UI.WebControls.Label)this.Page.Master.FindControl("lblUserName");
            lblUserName.Text = "Welcome " + UserName;

            LinkButton logout_btn = (LinkButton)this.Page.Master.FindControl("lnkBtnLogOut");
            logout_btn.Visible = true;
            # endregion

            # region Menu Access
            DataSet ds_Menu = (DataSet)HttpContext.Current.Session["ds_AccessPages"];
            System.Web.UI.WebControls.Menu tbstr = (System.Web.UI.WebControls.Menu)this.Master.FindControl("Menu1");

            for (int i = 0; i < ds_Menu.Tables[0].Rows.Count; i++)
            {
                String MenuName = ds_Menu.Tables[0].Rows[i]["MenuName"].ToString().Trim();
                int MenuID = Int32.Parse(ds_Menu.Tables[0].Rows[i]["MenuID"].ToString().Trim());

                String ParentMenuName = ds_Menu.Tables[0].Rows[i]["ParentMenuName"].ToString().Trim();
                int ParentMenuID = Int32.Parse(ds_Menu.Tables[0].Rows[i]["ParentMenuID"].ToString().Trim());

                # region Planning
                if (ParentMenuID == 1) // Planning
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Import from BaaN to be changed as Import SO Backlog
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // Production Release
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // Invoiced Data Import
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 3) // Freeze Plan
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // Plan Review -- Release Plan
                        tbstr.Items[ParentMenuID].ChildItems[4].ChildItems[0].Enabled = true;
                    else if (MenuID == 5) // Plan Review -- FG Plan
                        tbstr.Items[ParentMenuID].ChildItems[4].ChildItems[1].Enabled = true;
                    else if (MenuID == 6) // Plan Review -- Sales Plan
                        tbstr.Items[ParentMenuID].ChildItems[4].ChildItems[2].Enabled = true;
                    else if (MenuID == 7) // Reports - Order Status Report
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[0].Enabled = true;
                    else if (MenuID == 8) // Reports - ToRelease Report
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[1].Enabled = true;
                    else if (MenuID == 9) // Reports - SO BackLog Report
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[2].Enabled = true;
                    else if (MenuID == 10) // Prod Order Reversal
                        tbstr.Items[ParentMenuID].ChildItems[6].Enabled = true;
                    else if (MenuID == 11) // Schedule Process
                        tbstr.Items[ParentMenuID].ChildItems[7].Enabled = true;
                    else if (MenuID == 12) // Update WIP RecDate
                        tbstr.Items[ParentMenuID].ChildItems[8].Enabled = true;
                    else if (MenuID == 13) // Update PO Committment date
                        tbstr.Items[ParentMenuID].ChildItems[9].Enabled = true;
                    else if (MenuID == 14) // View WIP Dates
                        tbstr.Items[ParentMenuID].ChildItems[10].Enabled = true;
                    else if (MenuID == 15) // View PO Dates
                        tbstr.Items[ParentMenuID].ChildItems[11].Enabled = true;
                    else if (MenuID == 16) // View Processed Items
                        tbstr.Items[ParentMenuID].ChildItems[12].Enabled = true;
                    else if (MenuID == 17) // Reports - Ready To Release
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[3].Enabled = true;
                    else if (MenuID == 18) // Reports - Shortage Report
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[4].Enabled = true;
                    else if (MenuID == 19) // Buyer Master
                        tbstr.Items[ParentMenuID].ChildItems[13].Enabled = true;
                    else if (MenuID == 20) // Shortage
                        tbstr.Items[ParentMenuID].ChildItems[14].Enabled = true;
                    else if (MenuID == 21) // Update Order Status
                        tbstr.Items[ParentMenuID].ChildItems[15].Enabled = true;
                    else if (MenuID == 22) // Supplier Remarks
                        tbstr.Items[ParentMenuID].ChildItems[16].Enabled = true;
                    else if (MenuID == 23) // Bulk Release
                        tbstr.Items[ParentMenuID].ChildItems[17].Enabled = true;
                    else if (MenuID == 24) // View SCM
                        tbstr.Items[ParentMenuID].ChildItems[18].Enabled = true;
                    else if (MenuID == 25) // Week Wise Shortage Report
                        tbstr.Items[ParentMenuID].ChildItems[19].Enabled = true;
                }
                # endregion

                # region Production
                else if (ParentMenuID == 2) // Production
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // WIP To FG
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // Production Completion
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // WIP Report
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 3) // Primary Box Entry
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // Primary Box Maintance
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                # endregion

                # region Quality
                else if (ParentMenuID == 3) // Quality
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // TPI Offering
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // TPI Pending Report
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // Status Importing
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;

                    else if (MenuID == 3) // Operator Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[0].Enabled = true;
                    else if (MenuID == 4) // IP Location Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[1].Enabled = true;
                    else if (MenuID == 5) // IP Sub Location Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[2].Enabled = true;
                    else if (MenuID == 6) // Check List Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[3].Enabled = true;
                    else if (MenuID == 7) // IP Check List Master
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[4].Enabled = true;
                    else if (MenuID == 8) // Report - Date Wise
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[5].Enabled = true;
                    else if (MenuID == 9) // Report - Monthly wise
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[6].Enabled = true;
                    else if (MenuID == 10) // Patrol Review
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[7].Enabled = true;
                    else if (MenuID == 11) // Production Order Importing
                        tbstr.Items[ParentMenuID].ChildItems[3].ChildItems[8].Enabled = true;
                    else if (MenuID == 12) // Heat No Values
                        tbstr.Items[ParentMenuID].ChildItems[4].Enabled = true;
                    else if (MenuID == 13) // Box Enquiry
                        tbstr.Items[ParentMenuID].ChildItems[5].Enabled = true;
                }
                # endregion

                # region Sales
                if (ParentMenuID == 4) // Sales
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // ITP/ GAD Info
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // Stock Code/ Tag No Import
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // SCN Input
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 3) // MIS Finance Input/ Commercial
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // QR & QA
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 5) // QR & QA Sales Summary
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 6) // Commercial Review
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 7) // Branch Report
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                # endregion

                # region Print
                else if (ParentMenuID == 5) // Print
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Assembly Order Processing
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                # endregion

                # region System Util
                else if (ParentMenuID == 6) // System Util
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Create New User
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 1) // Update Role Access
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // Change Password
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 3) // Login SupplierName Update
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // Heat No Control
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                }
                #endregion

                #region Stores

                else if (ParentMenuID == 7) // Sysem Util
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Production Order Issues
                        tbstr.Items[ParentMenuID].ChildItems[0].Enabled = true;
                    else if (MenuID == 1) // Vendor Master
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 2) // Item Master
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 3) // Employee Master
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 4) // Delivery Challan
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 5) // Delivery Challan Receipts
                        tbstr.Items[ParentMenuID].ChildItems[MenuID].Enabled = true;
                    else if (MenuID == 6) // Delivery Challan Reports
                        tbstr.Items[ParentMenuID].ChildItems[5].ChildItems[0].Enabled = true;

                    else if (MenuID == 7) // Secondary Box Entry
                        tbstr.Items[ParentMenuID].ChildItems[6].Enabled = true;
                    else if (MenuID == 8) // Secondary Box Entry - Maintenance
                        tbstr.Items[ParentMenuID].ChildItems[7].Enabled = true;
                }
                #endregion

                #region MIS Utility

                else if (ParentMenuID == 8) // Sysem Util
                {
                    tbstr.Items[ParentMenuID].Enabled = true;

                    if (MenuID == 0) // Sales Order Line Item Deletion
                        tbstr.Items[ParentMenuID].ChildItems[0].Enabled = true;

                    if (MenuID == 1) // Serial No Details
                        tbstr.Items[ParentMenuID].ChildItems[1].Enabled = true;

                    if (MenuID == 2) // Sales Order Qty Decrement
                        tbstr.Items[ParentMenuID].ChildItems[2].Enabled = true;

                    if (MenuID == 3) // FG Order Change
                        tbstr.Items[ParentMenuID].ChildItems[3].Enabled = true;

                    if (MenuID == 4) // FG To WIP Reversal
                        tbstr.Items[ParentMenuID].ChildItems[4].Enabled = true;

                    if (MenuID == 5) // Update PO
                        tbstr.Items[ParentMenuID].ChildItems[5].Enabled = true;

                    if (MenuID == 6) // Ready To Release
                        tbstr.Items[ParentMenuID].ChildItems[6].Enabled = true;

                    if (MenuID == 7) // WIP Aging
                        tbstr.Items[ParentMenuID].ChildItems[7].Enabled = true;

                    if (MenuID == 8) // Request
                        tbstr.Items[ParentMenuID].ChildItems[8].ChildItems[0].Enabled = true;

                    if (MenuID == 9) // Quality
                        tbstr.Items[ParentMenuID].ChildItems[8].ChildItems[1].Enabled = true;

                    if (MenuID == 10) // Stores
                        tbstr.Items[ParentMenuID].ChildItems[8].ChildItems[2].Enabled = true;

                    if (MenuID == 11) // Enquiries And Reports
                        tbstr.Items[ParentMenuID].ChildItems[8].ChildItems[3].Enabled = true;
                }

                #endregion
            }
            #endregion

            # endregion

            if (!Page.IsPostBack)
            {
                GetPrintDetails();
            }
        }

        private void GetPrintDetails()
        {
            try
            {
                string PrimaryBoxNo = (String)HttpContext.Current.Session["PrimaryBoxNumber"];

                DataSet ds = _dbObj.RetrievePrimaryBoxForPrint(PrimaryBoxNo);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    lblPrimaryBoxNo.Text = Convert.ToString(PrimaryBoxNo.Substring(1, 6));

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["PEDPrint"].ToString()))
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["PEDPrint"].ToString()) == true)
                        {
                            Panel1.Visible = false;
                        }
                        else if (Convert.ToBoolean(ds.Tables[0].Rows[0]["PEDPrint"].ToString()) == false)
                        {
                            Panel1.Visible = true;

                            lblCustomerNameText.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerName"].ToString());
                            lblVelanOrdertext.Text = Convert.ToString(ds.Tables[0].Rows[0]["OrderNo"].ToString());
                            lblPosText.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pos"].ToString());

                            lblCustomerPOText.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerOrderNo"].ToString());
                            lblCustomerOrderPosText.Text = Convert.ToString(ds.Tables[0].Rows[0]["CustomerOrderPos"].ToString());
                            lblQuantitytext.Text = Convert.ToString(ds.Tables[0].Rows[0]["PrimaryBoxQty"].ToString());
                            lblFigureNumberText.Text = Convert.ToString(ds.Tables[0].Rows[0]["Item"].ToString());

                            lblApplicableStdsText.Text = Convert.ToString(ds.Tables[0].Rows[0]["AppStd"].ToString());
                            lblDescriptionText.Text = Convert.ToString(ds.Tables[0].Rows[0]["Description"].ToString());
                        }
                    }

                    lblTeststd.Text = Convert.ToString(ds.Tables[0].Rows[0]["TestStd"].ToString());
                    lblShell.Text = Convert.ToString(ds.Tables[0].Rows[0]["Shell"].ToString());
                    lblPacking.Text = Convert.ToString(ds.Tables[0].Rows[0]["PackingSeat"].ToString());
                    lblSeatHP.Text = Convert.ToString(ds.Tables[0].Rows[0]["HPSeat"].ToString());
                    lblSeatLP.Text = Convert.ToString(ds.Tables[0].Rows[0]["LPSeat"].ToString());
                    lblBackseat.Text = Convert.ToString(ds.Tables[0].Rows[0]["BackSeat"].ToString());

                    lblShellTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["ShellTime"].ToString());
                    lblPackingTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["PackingSeatTime"].ToString());
                    lblSeatHPTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["HPSeatTime"].ToString());
                    lblSeatLPTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["LPSeatTime"].ToString());
                    lblBackseatTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["BackSeatTime"].ToString());

                    lblShellResult.Text = Convert.ToString(ds.Tables[0].Rows[0]["ShellResult"].ToString());
                    lblPackingResult.Text = Convert.ToString(ds.Tables[0].Rows[0]["PackingSeatResult"].ToString());
                    lblSeatHPResult.Text = Convert.ToString(ds.Tables[0].Rows[0]["HPSeatResult"].ToString());
                    lblSeatLPResult.Text = Convert.ToString(ds.Tables[0].Rows[0]["LPSeatResult"].ToString());
                    lblBackseatResult.Text = Convert.ToString(ds.Tables[0].Rows[0]["BackSeatResult"].ToString());


                    var sb = new StringBuilder();
                    sb.AppendFormat("<table style='border: 1px solid; width: 100%; margin: 0 auto; margin-top: 10px; border-collapse:collapse;'>");

                    #region Grid Columns
                    sb.AppendFormat("<tr style='height: 20px; border-bottom: 1px solid; font-size: 10px;'>");

                    sb.AppendFormat("<td style='text-align: center; width: 5%; font-weight: 600;'>");
                    sb.AppendFormat("<span>Supplier</span>");
                    sb.AppendFormat("</td>");
                    sb.AppendFormat("<td style='text-align: center; width: 5%; font-weight: 600;border-left: 1px solid;'>");
                    sb.AppendFormat("<span>Heat Code</span>");
                    sb.AppendFormat("</td>");
                    sb.AppendFormat("<td style='text-align: center; width: 6%; font-weight: 600;border-left: 1px solid;'>");
                    sb.AppendFormat("<span>ASTM Code</span>");
                    sb.AppendFormat("</td>");
                    sb.AppendFormat("<td style='text-align: center; width: 8%; font-weight: 600;border-left: 1px solid;'>");
                    sb.AppendFormat("<span>Description</span>");
                    sb.AppendFormat("</td>");
                    sb.AppendFormat("<td style='text-align: center; width: 37%; font-weight: 600;border-left: 1px solid;'>");
                    sb.AppendFormat("<span>CHEMICALS</span>");
                    sb.AppendFormat("</td>");
                    sb.AppendFormat("<td style='text-align: center; width: 40%; font-weight: 600;border-left: 1px solid;'>");
                    sb.AppendFormat("<span>MECHANICALS</span>");
                    sb.AppendFormat("</td>");

                    sb.AppendFormat("</tr>");
                    #endregion

                    var heatNo = Convert.ToString(ds.Tables[0].Rows[0]["BodyHeatNo"].ToString());

                    var bonnetNo = Convert.ToString(ds.Tables[0].Rows[0]["BonnetHeatNo"].ToString());

                    var splitHeatNo = heatNo.Split(',');

                    var splitBonnet = bonnetNo.Split(',');

                    for (int i = 0; i < splitHeatNo.Length; i++)
                    {
                        ds = _dbObj.RetrieveHeatCodeMasterDetails(splitHeatNo[i].Trim());

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {

                            sb.AppendFormat("<tr style='height: 30px; border-bottom: 10px; border-bottom:1px solid; font-size: 8px;'>");

                            #region Dynamic Values for first 4 columns
                            sb.AppendFormat("<td style='text-align: center; width: 5%; border-left: 1px solid;'>");
                            sb.AppendFormat("<span> " + Convert.ToString(ds.Tables[0].Rows[0]["Supplier"].ToString()) + "</span>");
                            sb.AppendFormat("</td>");

                            sb.AppendFormat("<td style='text-align: center; width: 5%; border-left: 1px solid;'>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["HeatNo"].ToString()) + "</span>");
                            sb.AppendFormat("</td>");

                            sb.AppendFormat("<td style='text-align: center; width: 6%; border-left: 1px solid;'>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["Matltype"].ToString()) + "</span>");
                            sb.AppendFormat("</td>");

                            sb.AppendFormat("<td style='text-align: center; width: 8%; border-left: 1px solid;'>");
                            sb.AppendFormat("<span>Body</span>");
                            sb.AppendFormat("</td>");

                            #endregion

                            #region Chemicals Column Items

                            sb.AppendFormat("<td style='text-align: left; border-left: 1px solid; display:flex;'>");
                            sb.AppendFormat("<div style='width: 28%;'>");
                            sb.AppendFormat("<span style='padding: 6px 21px 5px 3px;'>Carbon (C)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["CAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 26px 5px 3px;'>Sulfur (S)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["SAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 21px 5px 3px;'>Nickel (Ni)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["NiAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 12px 5px 3px;'>Vanadium (V)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["VAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 45px 5px 3px;'>C.E</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["CE"].ToString()) + "</span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("<div style='width: 28%;'>");
                            sb.AppendFormat("<span style='padding: 6px 11px 5px 3px;'>Manganese (Mn)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["MnAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 30px 5px 3px;'>Silicon (Si)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["SiAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 16px 5px 3px;'>Chromium (Cr)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["CrAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 8px 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("<div style='width: 33%;'>");
                            sb.AppendFormat("<span style='padding: 6px 20px 5px 3px;'>Phosphorous (P)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["PAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 32px 5px 3px;'>Copper (Cu)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["CuAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 11px 5px 3px;'>Molybdenum (Mo)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["MoAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("</td>");

                            #endregion

                            #region Mechanicals Column Items

                            sb.AppendFormat("<td style='text-align: left; border-left: 1px solid;'>");

                            sb.AppendFormat("<div style='width: 40%; display:inline-block;'>");
                            sb.AppendFormat("<span style='padding: 6px 19px 5px 3px;'>Tensile (MPa)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["TensileMPAAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 30px 5px 3px;'>Yield (ksi)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 16px 5px 3px;'>Hardness (HB)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["HardnessAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 31px 5px 3px;'>Impact (J)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["Impact6Act"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 14px 5px 3px;'>Heat Treatment</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["HTDesc"].ToString()) + "</span>");
                            //sb.AppendFormat("</br>");
                            //sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            //sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("<div style='width: 30%; display:inline-block;'>");
                            sb.AppendFormat("<span style='padding: 6px 21px 5px 3px;'>Tensile (ksi)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 12px 5px 3px;'>Elongation (%)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["ElongationAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 28px 5px 3px;'>Impact (J)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["Impact2Act"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 7px 5px 3px;'>Temperature(°C)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["TemperatureCAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("<div style='width: 30%; display:inline-block;'>");
                            sb.AppendFormat("<span style='padding: 6px 45px 5px 3px;'>Yield (MPa)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 13px 5px 3px;'>Reduction of Area(%)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["ReductionAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");

                            sb.AppendFormat("<span style='padding: 6px 52px 5px 3px;'>Impact (J)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["Impact4Act"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 3px 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("</td>");

                            #endregion

                            sb.AppendFormat("</tr>");
                        }
                    }

                    for (int i = 0; i < splitBonnet.Length; i++)
                    {
                        ds = _dbObj.RetrieveHeatCodeMasterDetails(splitBonnet[i].Trim());

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            sb.AppendFormat("<tr style='height: 30px; border-bottom: 10px; border-bottom:1px solid; font-size: 8px;'>");

                            #region Dynamic Values for first 4 columns
                            sb.AppendFormat("<td style='text-align: center; width: 5%; border-left: 1px solid;'>");
                            sb.AppendFormat("<span> " + Convert.ToString(ds.Tables[0].Rows[0]["Supplier"].ToString()) + "</span>");
                            sb.AppendFormat("</td>");

                            sb.AppendFormat("<td style='text-align: center; width: 5%; border-left: 1px solid;'>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["HeatNo"].ToString()) + "</span>");
                            sb.AppendFormat("</td>");

                            sb.AppendFormat("<td style='text-align: center; width: 6%; border-left: 1px solid;'>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["Matltype"].ToString()) + "</span>");
                            sb.AppendFormat("</td>");

                            sb.AppendFormat("<td style='text-align: center; width: 8%; border-left: 1px solid;'>");
                            sb.AppendFormat("<span>Bonnet</span>");
                            sb.AppendFormat("</td>");

                            #endregion

                            #region Chemicals Column Items

                            sb.AppendFormat("<td style='text-align: left; border-left: 1px solid; display:flex;'>");
                            sb.AppendFormat("<div style='width: 28%;'>");
                            sb.AppendFormat("<span style='padding: 6px 21px 5px 3px;'>Carbon (C)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["CAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 26px 5px 3px;'>Sulfur (S)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["SAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 21px 5px 3px;'>Nickel (Ni)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["NiAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 12px 5px 3px;'>Vanadium (V)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["VAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 45px 5px 3px;'>C.E</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["CE"].ToString()) + "</span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("<div style='width: 28%;'>");
                            sb.AppendFormat("<span style='padding: 6px 11px 5px 3px;'>Manganese (Mn)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["MnAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 30px 5px 3px;'>Silicon (Si)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["SiAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 16px 5px 3px;'>Chromium (Cr)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["CrAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 8px 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("<div style='width: 33%;'>");
                            sb.AppendFormat("<span style='padding: 6px 20px 5px 3px;'>Phosphorous (P)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["PAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 32px 5px 3px;'>Copper (Cu)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["CuAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 11px 5px 3px;'>Molybdenum (Mo)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["MoAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("</td>");

                            #endregion

                            #region Mechanicals Column Items

                            sb.AppendFormat("<td style='text-align: left; border-left: 1px solid;'>");

                            sb.AppendFormat("<div style='width: 40%; display:inline-block;'>");
                            sb.AppendFormat("<span style='padding: 6px 19px 5px 3px;'>Tensile (MPa)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["TensileMPAAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 30px 5px 3px;'>Yield (ksi)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 16px 5px 3px;'>Hardness (HB)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["HardnessAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 31px 5px 3px;'>Impact (J)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["Impact6Act"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 14px 5px 3px;'>Heat Treatment</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["HTDesc"].ToString()) + "</span>");                            
                            
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("<div style='width: 30%; display:inline-block;'>");
                            sb.AppendFormat("<span style='padding: 6px 21px 5px 3px;'>Tensile (ksi)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 12px 5px 3px;'>Elongation (%)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["ElongationAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 28px 5px 3px;'>Impact (J)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["Impact2Act"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 7px 5px 3px;'>Temperature(°C)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["TemperatureCAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("<div style='width: 30%; display:inline-block;'>");
                            sb.AppendFormat("<span style='padding: 6px 45px 5px 3px;'>Yield (MPa)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 13px 5px 3px;'>Reduction of Area(%)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["ReductionAct"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");

                            sb.AppendFormat("<span style='padding: 6px 52px 5px 3px;'>Impact (J)</span>");
                            sb.AppendFormat("<span>" + Convert.ToString(ds.Tables[0].Rows[0]["Impact4Act"].ToString()) + "</span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 3px 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</br>");
                            sb.AppendFormat("<span style='padding: 6px 0 5px 3px;'></span>");
                            sb.AppendFormat("<span></span>");
                            sb.AppendFormat("</div>");

                            sb.AppendFormat("</td>");

                            #endregion

                            sb.AppendFormat("</tr>");
                        }
                    }

                    sb.AppendFormat("</table>");

                    secondGrid.InnerHtml = sb.ToString();
                }

            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from Doc Page Two!");
            }
        }

        private string SecondGrid()
        {
            StringBuilder stringBuilder = new StringBuilder();

            //stringBuilder += @"<asp:Label ID="Label30" runat="server" Text="Supplier"></asp:Label>";

            return stringBuilder.ToString();
        }

        private void LogError(Exception ex, string section)
        {

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += "Exception from SQLConnectionOpen" + "-" + section;
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void FillItems(DataSet ds)
        {

        }
    }
}