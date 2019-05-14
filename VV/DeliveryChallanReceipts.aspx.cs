﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class DeliveryChallanReceipts : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DBUtil _dbObj = new DBUtil();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Master Control

            #region Welcome Msg

            DateTime dt = DateTime.MinValue;
            Console.WriteLine(dt);
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
                # endregion

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
            #endregion



            #endregion

            if (!Page.IsPostBack)
            {
                DateTime currentDate = DateTime.UtcNow;
                txtDcDate.Text = Convert.ToString(currentDate.ToString("dd/MM/yyyy"));
                txtReceivedDate.Text = Convert.ToString(currentDate.ToString("dd/MM/yyyy"));

                GetDropDownInfo();
                ds = FillVendorName();
                ddlVendor.DataSource = ds;
                ddlVendor.DataBind();

                ShowDeliveryChallanReceiptsDetails();
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
        }

        private void ShowDeliveryChallanReceiptsDetails()
        {
            try
            {
                string pageSize = ConfigurationManager.AppSettings["GridPageSize"].ToString();

                DBUtil _DBObj = new DBUtil();
                DataSet ds = _DBObj.RetriveByDeliveryChallanReceiptsDetails(Convert.ToInt32(ddlVendor.SelectedValue));

                ViewState["CacheFromDeliveryChallanReceiptsDetails"] = ds.Tables[0];

                GridView1.PageSize = Convert.ToInt32(pageSize);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from view delivery challan receipts details!");
            }
        }

        private DataSet FillVendorName()
        {
            ds = _dbObj.RetriveByVendorNameForDeliveryChallan();

            return ds;
        }

        public DataSet GetDropDownInfo()
        {
            int dc = 1;
            ds = _dbObj.GetEmployeeName(dc);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlReceiveddBy.DataSource = ds;
                ddlReceiveddBy.DataBind();
            }

            return ds;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Visible = false;
                ShowDeliveryChallanReceiptsDetails();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from view delivery challan receipts details!");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            try
            {
                string vendorDCNumber = txtDcNumber.Text;
                string vendorDCDate = txtDcDate.Text;
                string vendorReceivedDate = txtReceivedDate.Text;
                string receivedBy = ddlReceiveddBy.SelectedValue;
                int vendorCode = Convert.ToInt32(ddlVendor.SelectedValue);

                if (string.IsNullOrEmpty(vendorDCNumber))
                {
                    lblRequiredFields.Visible = true;
                    return;
                }

                foreach (GridViewRow row in GridView1.Rows)
                {
                    string slno = ((Label)row.FindControl("lblRowNumber")).Text.ToString();
                    string dcNumber = ((Label)row.FindControl("lblDCNumber")).Text.ToString();
                    string itemDescription = ((Label)row.FindControl("lblItemDescription")).Text.ToString();
                    string alreadyReceivedQty = ((Label)row.FindControl("lblQtyAlreadyReceived")).Text.ToString();
                    string quantityReceived = ((TextBox)row.FindControl("txtReceived")).Text.ToString();
                    string quantitySend = ((Label)row.FindControl("lblQtySend")).Text.ToString();
                    string units = ((Label)row.FindControl("lblUnits")).Text.ToString();
                    string balanceQty = ((Label)row.FindControl("lblQtyBalance")).Text.ToString();
                    string rate = ((Label)row.FindControl("lblRate")).Text.ToString();

                    if (Convert.ToDecimal(string.IsNullOrEmpty(quantityReceived) ? 0 : Convert.ToDecimal(quantityReceived)) > 0)
                    {
                        if (Convert.ToDecimal(string.IsNullOrEmpty(balanceQty) ? 0 : Convert.ToDecimal(balanceQty)) <
                       Convert.ToDecimal(string.IsNullOrEmpty(quantityReceived) ? 0 : Convert.ToDecimal(quantityReceived)))
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Visible = true;
                            lblMessage.Text = "Input Quantity should be less than already received quantity!.";
                            return;
                        }

                        _dbObj.InsertIntoDeliveryChallanReceiptsDetails(vendorCode, vendorReceivedDate, dcNumber, Convert.ToInt32(slno),
                            Convert.ToDecimal(quantityReceived), vendorDCNumber,
                            vendorDCDate, receivedBy);

                        decimal receivedQty = 0;
                        decimal updatedReceivedQty = 0;
                        DataSet ds = _dbObj.GetDeliveryChallanReceivedQty(dcNumber, Convert.ToInt32(slno));

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            receivedQty = Convert.ToDecimal(ds.Tables[0].Rows[0]["QuantityReceived"].ToString());
                            updatedReceivedQty = receivedQty + Convert.ToDecimal(string.IsNullOrEmpty(quantityReceived) ? 0 : Convert.ToDecimal(quantityReceived));
                        }

                        _dbObj.UpdateIntoDeliveryChallanDetails(dcNumber, Convert.ToInt32(slno), Convert.ToString(units),
                               Convert.ToDecimal(string.IsNullOrEmpty(quantitySend.ToString()) ? 0 : Convert.ToDecimal(quantitySend.ToString())), Convert.ToDecimal(string.IsNullOrEmpty(rate.ToString()) ? 0 : Convert.ToDecimal(rate)), itemDescription,
                               Convert.ToDecimal(string.IsNullOrEmpty(updatedReceivedQty.ToString()) ? 0 : Convert.ToDecimal(updatedReceivedQty)));

                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Visible = true;
                        lblMessage.Text = "DC Receipts Details Updated Successfully.";

                        txtDcNumber.Text = string.Empty;
                        ShowDeliveryChallanReceiptsDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from view delivery challan receipts details!");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void txtReceived_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtQtyReceived = (TextBox)sender;

                //place it in naming container
                GridViewRow gvRow = (GridViewRow)txtQtyReceived.NamingContainer;
                TextBox textReceived = (TextBox)gvRow.FindControl("txtReceived");
                int count = Convert.ToInt32(textReceived.Text);

            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from view delivery challan receipts details!");
            }
        }

        protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Visible = false;
                ShowDeliveryChallanReceiptsDetails();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception while changing the vendor drop down!");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMessage.Visible = false;

            DataTable dt = (DataTable)ViewState["CacheFromDeliveryChallanReceiptsDetails"];

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            try
            {
                DataView dv;
                dv = dt.DefaultView;
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while clicking on page number from DeliveryChallanReceipts.");
            }
        }
    }
}