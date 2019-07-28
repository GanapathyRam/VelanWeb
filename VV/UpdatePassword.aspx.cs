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
    public partial class UpdatePassword : System.Web.UI.Page
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
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " :UpdatePassword - Page_Load : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Updates/ Inserts the Records in the MISFinanceInput Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String NewPassword = txtNewPassword.Text.Trim();

                DBUtil _DBObj = new DBUtil();

                _DBObj.UpdatePassword(NewPassword);

                buttonUpdate.Enabled = false;

                lblMessage.Visible = true;
                lblMessage.Text = "Password Updated Successfully";

            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " :UpdatePassword - buttonUpdate_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
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
            Response.Redirect("UpdatePassword.aspx");
        }
    }
}