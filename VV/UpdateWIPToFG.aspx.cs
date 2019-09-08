using Libraries.Entity;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class UpdateWIPToFG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                # region Master Control

                # region Welcome Msg
                string UserName = (String)HttpContext.Current.Session["LoggedOnUser"];
                Label lblUserName = (Label)this.Page.Master.FindControl("lblUserName");
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
                # endregion

                # endregion

                if (!Page.IsPostBack)
                {
                    lblMessage.Visible = false;

                    String orderNo = Request.QueryString["OrderNo"].ToString();
                    String LineNo = Request.QueryString["LineNum"].ToString();
                    String Pos = Request.QueryString["Pos"].ToString();
                    String SerialNo = Request.QueryString["SerialNo"].ToString();
                    String ProdOrderNo = Request.QueryString["ProdOrderNo"].ToString();

                    DataSet ds = (DataSet)Cache["WIPDataFromDBCache"];

                    if (ds != null)
                    {
                        DataRow[] dr = ds.Tables[0].Select("OrderNo = '" + orderNo + "' And LineNum = '" + LineNo + "' AND Pos = '" + Pos + "' AND SerialNo = '" + SerialNo + "' AND ProdOrderNo = '" + ProdOrderNo + "'");

                        if (dr.Length > 0)
                        {
                            lblOrderNoVal.Text = orderNo;
                            lblOrderTypeVal.Text = dr[0]["OrderType"].ToString().Trim();
                            lblPosVal.Text = dr[0]["Pos"].ToString().Trim();
                            lblLineNumVal.Text = dr[0]["LineNum"].ToString().Trim();
                            lblSerialNoVal.Text = dr[0]["SerialNo"].ToString().Trim();
                            lblProdOrderNoVal.Text = dr[0]["ProdOrderNo"].ToString().Trim();
                            lblCustNameVal.Text = dr[0]["CustomerName"].ToString().Trim();
                            lblCusOrderNoVal.Text = dr[0]["CustomerOrderNo"].ToString().Trim();
                            lblItemVal.Text = dr[0]["Item"].ToString().Trim();
                            lblDescVal.Text = dr[0]["Description"].ToString().Trim();
                            lblOrderQtyVal.Text = dr[0]["OrderQty"].ToString().Trim();
                            lblWIPQtyVal.Text = dr[0]["WIPQty"].ToString().Trim();
                            lblBalanceQtyVal.Text = dr[0]["ProdBalanceQty"].ToString().Trim();

                            if (!String.IsNullOrEmpty(dr[0]["WIPQty"].ToString().Trim()))
                                Cache["WIPQty"] = Int32.Parse(dr[0]["WIPQty"].ToString().Trim());
                            else
                                Cache["WIPQty"] = 0;

                            if (!String.IsNullOrEmpty(dr[0]["FGQty"].ToString().Trim()))
                                Cache["FGQty"] = Int32.Parse(dr[0]["FGQty"].ToString().Trim());
                            else
                                Cache["FGQty"] = 0;

                            if (!String.IsNullOrEmpty(dr[0]["ProdBalanceQty"].ToString().Trim()))
                                Cache["ProdBalanceQty"] = Int32.Parse(dr[0]["ProdBalanceQty"].ToString().Trim());
                            else
                                Cache["ProdBalanceQty"] = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " :Update WIP to FG - Page_Load : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Generates the serial No & ingest the records into the ProdRelease Table. Also updates the WIPQty & ToReleaseQty in MISOrderStatus table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil _DBObj = new DBUtil();

                DataSet ds = new DataSet();

                int UpdatedFGQty = Int32.Parse(txtFGQty.Text.Trim());

                int _FGQty = (int)Cache["FGQty"];
                int _WIPQty = (int)Cache["WIPQty"];
                int _BalanceQty = (int)Cache["ProdBalanceQty"];


                if (_WIPQty > 0 && _WIPQty >= UpdatedFGQty)
                    _WIPQty = _WIPQty - UpdatedFGQty;
                else
                    _WIPQty = UpdatedFGQty;

                _FGQty = _FGQty + UpdatedFGQty;

                _BalanceQty = _BalanceQty - UpdatedFGQty;

                _DBObj.UpdateQtyInMISOrderStatusTableForWIPToFG(lblOrderTypeVal.Text.Trim(), Int32.Parse(lblOrderNoVal.Text.Trim()), lblLineNumVal.Text.Trim(), Int32.Parse(lblPosVal.Text.Trim()), _FGQty, _WIPQty);

                _DBObj.UpdateBalanceQtyInProdOrderReleaseTableForWIPToFG(Int32.Parse(lblOrderNoVal.Text.Trim()), lblLineNumVal.Text.Trim(), Int32.Parse(lblPosVal.Text.Trim()), lblProdOrderNoVal.Text.Trim(), lblSerialNoVal.Text.Trim(), _BalanceQty);

                buttonUpdate.Enabled = false;

                Cache.Remove("FGQty");
                Cache.Remove("WIPQty");
                Cache.Remove("ProdBalanceQty");

                lblMessage.Text = "Updated Successfully";
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " :Update WIP to FG - buttonUpdate_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Cancel Button Operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewWIPItems.aspx");
        }
    }
}