using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class UpdateOrderStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Master Control

            #region Welcome Msg
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

            if (!Page.IsPostBack)
            {
                FillUpdatedOrderStatus();
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");

            # endregion
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["CacheFromUpdatedOrderStatus"];

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ds;
            GridView1.DataBind();

            try
            {
                DataView dv;
                dv = ds.Tables[0].DefaultView;
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, "Exception from while clicking on page number from buyer master.");
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                txtMaterialReceiptDate.Text = "";
                txtAssemblyReleaseDate.Text = "";
                txtMachiningCompletionDate.Text = "";
                txtTPI1Date.Text = "";
                txtTPI2Date.Text = "";

                String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty;

                string CustomerName = txtCustomerName.Text.Trim();
                string OrderNo = txtOrderNo.Text.Trim();
                string Pos = txtPos.Text.Trim();


                if (!string.IsNullOrEmpty(CustomerName))
                {
                    searchRowFilter1 = "CustomerName like '%" + CustomerName + "%'";
                }
                if (!string.IsNullOrEmpty(OrderNo))
                {
                    searchRowFilter2 = "OrderNo = '" + OrderNo + "'";
                }
                if (!string.IsNullOrEmpty(Pos))
                {
                    searchRowFilter3 = "Pos = '" + Pos + "'";
                }


                if (!String.IsNullOrEmpty(searchRowFilter1))
                    searchRowFilter = searchRowFilter1;

                if (!String.IsNullOrEmpty(searchRowFilter2))
                {
                    if (!String.IsNullOrEmpty(searchRowFilter))
                        searchRowFilter = searchRowFilter + " AND " + searchRowFilter2;
                    else
                        searchRowFilter = searchRowFilter2;
                }

                if (!String.IsNullOrEmpty(searchRowFilter3))
                {
                    if (!String.IsNullOrEmpty(searchRowFilter))
                        searchRowFilter = searchRowFilter + " AND " + searchRowFilter3;
                    else
                        searchRowFilter = searchRowFilter3;
                }

                if (!String.IsNullOrEmpty(searchRowFilter))
                {
                    DataSet searchDS = (DataSet)Cache["CacheFromUpdatedOrderStatus"];

                    DataView dv;
                    dv = searchDS.Tables[0].DefaultView;

                    dv.RowFilter = searchRowFilter;

                    GridView1.DataSource = dv;
                    GridView1.DataBind();

                    DataSet DS = new DataSet();
                    DS.Tables.Add(dv.ToTable());
                    Cache["CacheFromUpdatedOrderStatus"] = DS;
                }
                else
                {
                    FillUpdatedOrderStatus();
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, "Exception from while searching record based on CustomerName Order No and Pos!.");
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DBUtil _DBObj = new DBUtil();

            DateTime? receiptActivityDate = null;
            DateTime? machiningActivityDate = null;
            DateTime? assemblyActivityDate = null;
            DateTime? tp1ActivityDate = null;
            DateTime? tp2ActivityDate = null;


            bool receiptActivity = false;
            bool machiningActivity = false;
            bool assemblyActivity = false;
            bool tp1Activity = false;
            bool tp2Activity = false;

            bool nullDate = false;
            bool nullDate1 = false;
            bool nullDate2 = false;
            bool nullDate3 = false;
            bool nullDate4 = false;

            try
            {
                if (chkReceiptActivity.Checked)
                {
                    receiptActivity = true;
                    nullDate = false;
                    receiptActivityDate = null;
                }
                else if (!chkReceiptActivity.Checked && chkNullDate.Checked)
                {
                    receiptActivity = false;
                    nullDate = true;
                    receiptActivityDate = null;
                }
                else if (!chkReceiptActivity.Checked && !chkNullDate.Checked)
                {
                    receiptActivity = false;
                    nullDate = false;
                    var selectedDate = txtMaterialReceiptDate.Text == string.Empty ? null : txtMaterialReceiptDate.Text;
                    if (selectedDate != null)
                    {
                        receiptActivityDate = Convert.ToDateTime(selectedDate);
                    }
                }

                ///////////////////////

                if (chkMachiningActivity.Checked)
                {
                    machiningActivity = true;
                    nullDate1 = false;
                    machiningActivityDate = null;
                }
                else if (!chkMachiningActivity.Checked && chkNullDate1.Checked)
                {
                    machiningActivity = false;
                    nullDate1 = true;
                    machiningActivityDate = null;
                }
                else if (!chkMachiningActivity.Checked && !chkNullDate1.Checked)
                {
                    machiningActivity = false;
                    nullDate1 = false;
                    var selectedDate = txtMachiningCompletionDate.Text == string.Empty ? null : txtMachiningCompletionDate.Text;
                    if (selectedDate != null)
                    {
                        machiningActivityDate = Convert.ToDateTime(selectedDate);
                    }
                }

                ///////////////////

                if (chkAssemblyActivity.Checked)
                {
                    assemblyActivity = true;
                    nullDate2 = false;
                    assemblyActivityDate = null;
                }
                else if (!chkAssemblyActivity.Checked && chkNullDate2.Checked)
                {
                    assemblyActivity = false;
                    nullDate2 = true;
                    assemblyActivityDate = null;
                }
                else if (!chkAssemblyActivity.Checked && !chkNullDate2.Checked)
                {
                    assemblyActivity = false;
                    nullDate2 = false;
                    var selectedDate = txtAssemblyReleaseDate.Text == string.Empty ? null : txtAssemblyReleaseDate.Text;
                    if (selectedDate != null)
                    {
                        assemblyActivityDate = Convert.ToDateTime(selectedDate);
                    }
                }

                //////////////////////////////

                if (chkTPI1Activity.Checked)
                {
                    tp1Activity = true;
                    nullDate3 = false;
                    tp1ActivityDate = null;
                }
                else if (!chkTPI1Activity.Checked && chkNullDate3.Checked)
                {
                    tp1Activity = false;
                    nullDate3 = true;
                    tp1ActivityDate = null;
                }
                else if (!chkTPI1Activity.Checked && !chkNullDate3.Checked)
                {
                    tp1Activity = false;
                    nullDate3 = false;
                    var selectedDate = txtTPI1Date.Text == string.Empty ? null : txtTPI1Date.Text;
                    if (selectedDate != null)
                    {
                        tp1ActivityDate = Convert.ToDateTime(selectedDate);
                    }
                }

                /////////////////////////////

                if (chkTPI2Activity.Checked)
                {
                    tp2Activity = true;
                    nullDate4 = false;
                    tp2ActivityDate = null;
                }
                else if (!chkTPI2Activity.Checked && chkNullDate4.Checked)
                {
                    tp2Activity = false;
                    nullDate4 = true;
                    tp2ActivityDate = null;
                }
                else if (!chkTPI2Activity.Checked && !chkNullDate4.Checked)
                {
                    tp2Activity = false;
                    nullDate4 = false;
                    var selectedDate = txtTPI2Date.Text == string.Empty ? null : txtTPI2Date.Text;
                    if (selectedDate != null)
                    {
                        tp2ActivityDate = Convert.ToDateTime(selectedDate);
                    }
                }

                foreach (GridViewRow row in GridView1.Rows)
                {
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                    if (isChecked)
                    {
                        var CustomerNameHidden = ((System.Web.UI.HtmlControls.HtmlInputHidden)row.FindControl("hidCustomerName")).Value.ToString();
                        var OrderNoHidden = ((System.Web.UI.HtmlControls.HtmlInputHidden)row.FindControl("hidOrderNo")).Value.ToString();
                        var PosHidden = ((System.Web.UI.HtmlControls.HtmlInputHidden)row.FindControl("hidPos")).Value.ToString();

                        _DBObj.UpdateOrderStatus(CustomerNameHidden, Convert.ToInt32(OrderNoHidden), Convert.ToInt32(PosHidden), receiptActivityDate
                            , machiningActivityDate, assemblyActivityDate, tp1ActivityDate, tp2ActivityDate, txtReason.InnerText, receiptActivity, machiningActivity, assemblyActivity, tp1Activity, tp2Activity, nullDate, nullDate1, nullDate2, nullDate3,
                            nullDate4, chkReceipt.Checked, chkMachine.Checked, chkAssembly.Checked, chkTPI1.Checked, chkTPI2.Checked, chkReason.Checked);

                        lblMessage.Text = "Records Updated Successfully.";
                        lblMessage.Visible = true;
                    }
                }

                FillUpdatedOrderStatus();
            }
            catch (Exception ex)
            {
                Helper.LogError(ex, "Exception from while updating the order status.");
            }
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{

        //}

        private DataSet FillUpdatedOrderStatus()
        {
            string pageSize = ConfigurationManager.AppSettings["GridPageSize"].ToString();

            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.RetriveByUpdatedOrderStatus();

            Cache["CacheFromUpdatedOrderStatus"] = ds;

            GridView1.PageSize = Convert.ToInt32(pageSize);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            return ds;
        }

        protected void chkReceiptActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNullDate.Checked)
            {

            }
        }
    }
}