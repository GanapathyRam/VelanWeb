using System;
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
    public partial class DeliveryChallan : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DBUtil _dbObj = new DBUtil();

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
            #endregion



            #endregion

            if (!Page.IsPostBack)
            {
                ShowDeliveryChallanMasterDetails();
                DateTime currentDate = DateTime.UtcNow;
                txtDcDate.Text = Convert.ToString(currentDate.ToString("dd/MM/yyyy"));
                txtDcDate.Enabled = false;
            }

            Panel1.Visible = false;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
        }

        public DataSet GetUnitsMaster()
        {
            DataSet ds = new DataSet();

            ds = _dbObj.GetUnitsMasterDetails();

            return ds;
        }

        public DataSet GetDropDownInfo()
        {
            DataSet ds = new DataSet();

            ds = _dbObj.GetDCTypeName();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDcType.DataSource = ds;
                ddlDcType.DataBind();

                ddlDcType.Items.Insert(0, new ListItem("--Please Select--"));
            }

            ds = _dbObj.GetVendorName();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlVendorName.DataSource = ds;
                ddlVendorName.DataBind();
            }

            int dc = 1;
            ds = _dbObj.GetEmployeeName(dc);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPreparedBy.DataSource = ds;
                ddlPreparedBy.DataBind();
            }

            dc = 0;
            ds = _dbObj.GetEmployeeName(dc);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlRequestedBy.DataSource = ds;
                ddlRequestedBy.DataBind();
            }

            return ds;
        }

        public DataSet getItemDescription()
        {
            DataSet ds = new DataSet();

            ds = _dbObj.GetItemName();

            return ds;
        }

        private void ShowDeliveryChallanMasterDetails()
        {
            try
            {
                string pageSize = ConfigurationManager.AppSettings["GridPageSize"].ToString();

                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add("SLNo", typeof(string));
                dt.Columns.Add("ItemDescription", typeof(string));
                dt.Columns.Add("Units", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));
                dt.Columns.Add("QuantityReceived", typeof(string));
                dt.Columns.Add("Rate", typeof(string));

                dr = dt.NewRow();
                dr["SLNo"] = 1;
                dr["ItemDescription"] = string.Empty;
                dr["Units"] = string.Empty;
                dr["Rate"] = string.Empty;
                dt.Rows.Add(dr);

                //Store the DataTable in ViewState for future reference   
                ViewState["CacheFromDeliveryChallanDetails"] = dt;

                //Bind the Gridview   
                GridView1.PageSize = Convert.ToInt32(pageSize);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                //After binding the gridview, we can then extract and fill the DropDownList with Data   
                DropDownList ddl1 = (DropDownList)GridView1.Rows[0].Cells[2].FindControl("ddlForUnits");

                DataSet ds = _dbObj.GetUnitsMasterDetails();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl1.DataSource = ds;
                    ddl1.DataBind();
                }

                //DBUtil _DBObj = new DBUtil();
                //DataSet ds = _DBObj.RetriveByDeliveryChallanDetails();

                //ds.Tables[0].Columns.Add("SLNo", typeof(string));
                //ds.Tables[0].Columns.Add("ItemDescription", typeof(string));
                //ds.Tables[0].Columns.Add("Units", typeof(string));
                //ds.Tables[0].Columns.Add("Quantity", typeof(string));
                //ds.Tables[0].Columns.Add("QuantityReceived", typeof(string));

                //ds.Tables[0].Rows[0]["SLNo"] = 1;
                //ds.Tables[0].Rows[0]["ItemDescription"] = string.Empty;
                ////ds.Tables[0].Rows[0]["Units"] = 1;
                //ds.Tables[0].Rows[0]["Quantity"] = 0;
                //ds.Tables[0].Rows[0]["QuantityReceived"] = 0;

                //ViewState["CacheFromDeliveryChallanDetails"] = ds.Tables[0];

                //GridView1.PageSize = Convert.ToInt32(pageSize);
                //GridView1.DataSource = ds;
                //GridView1.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from view delivery challan master details!");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            Panel1.Visible = true;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnSearch.Visible = false;
            btnUpdate.Visible = true;
            btnAddItem.Visible = false;

            GetDropDownInfo();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            Panel1.Visible = true;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnSearch.Visible = true;
            btnUpdate.Visible = true;
            btnAddItem.Visible = false;
            ddlDcType.Enabled = false;
            lblDcType.Enabled = false;
            GridView1.Visible = false;
            txtDcNumber.ReadOnly = false;
            txtDcNumber.Enabled = true;
            GridView1.Visible = true;
            btnCancel.Visible = true;

            GetDropDownInfo();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            btnCancel.Visible = false;

            AddNewRowToGrid();
        }

        private void AddNewRowToGrid()
        {

            if (ViewState["CacheFromDeliveryChallanDetails"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CacheFromDeliveryChallanDetails"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["SLNo"] = Convert.ToInt32(dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1]["SlNo"].ToString()) + 1;
                    //add new row to DataTable
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState
                    ViewState["CurrentTable"] = dtCurrentTable;

                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {
                        //extract the DropDownList Selected Items
                        DropDownList ddl1 = (DropDownList)GridView1.Rows[i].Cells[2].FindControl("ddlForUnits");

                        // Update the DataRow with the DDL Selected Items
                        dtCurrentTable.Rows[i]["Units"] = ddl1.SelectedItem.Text;

                    }

                    //Rebind the Grid with the current data
                    ViewState["CacheFromDeliveryChallanAddDetails"] = dtCurrentTable;
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            DataSet ds = new DataSet();

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Set the Previous Selected Items on Each DropDownList on Postbacks
                        DropDownList ddl1 = (DropDownList)GridView1.Rows[i].Cells[2].FindControl("ddlForUnits");

                        //Fill the DropDownList with Data
                        ds = _dbObj.GetUnitsMasterDetails();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl1.DataSource = ds;
                            ddl1.DataBind();
                        }

                        if (i < dt.Rows.Count - 1)
                        {
                            ddl1.ClearSelection();
                            ddl1.Items.FindByText(dt.Rows[i]["Units"].ToString()).Selected = true;
                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ddlDcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string DCNumber = string.Empty;
                int Number = 0;
                var dcNumber = string.Empty;
                lblMessage.Visible = false;
                txtReason.Text = string.Empty;

                lblDcTypeErrorMsg.Visible = false;
                string ddlDCTypeSelectedItem = ddlDcType.SelectedValue;
                DateTime ddlDcDateSelectedItem = Convert.ToDateTime(txtDcDate.Text);
                int count = 1;

                int currentMonth = DateTime.UtcNow.Month;

                if (currentMonth >= 4)
                {
                    DataSet ds = _dbObj.GetDCTypeSavedItems(ddlDCTypeSelectedItem, Convert.ToInt32(ddlDcDateSelectedItem.AddYears(1).ToString().Substring(8, 2)));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DCNumber = ds.Tables[0].Rows[0]["DCNumber"].ToString();

                        Number = Convert.ToInt32(DCNumber.Substring(9));
                    }

                    dcNumber = "VVI-" + ddlDCTypeSelectedItem + "-" + ddlDcDateSelectedItem.AddYears(1).ToString().Substring(8, 2) + "-" +
                        (Number + count).ToString().PadLeft(4, '0');
                }
                else
                {
                    DataSet ds = _dbObj.GetDCTypeSavedItems(ddlDCTypeSelectedItem, Convert.ToInt32(ddlDcDateSelectedItem.ToString().Substring(8, 2)));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DCNumber = ds.Tables[0].Rows[0]["DCNumber"].ToString();

                        Number = Convert.ToInt32(DCNumber.Substring(9));
                    }

                    dcNumber = "VVI-" + ddlDCTypeSelectedItem + "-" + ddlDcDateSelectedItem.ToString().Substring(8, 2) + "-" +
                        (Number + count).ToString().PadLeft(4, '0');
                }


                txtDcNumber.Text = dcNumber;
                Panel1.Visible = true;

                ShowDeliveryChallanMasterDetails();

            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from DC type drop down selection");
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            lblDcTypeErrorMsg.Visible = false;
            lblMessage.Visible = false;

            string ddlDCTypeSelectedItem = ddlDcType.SelectedValue;
            DateTime ddlDcDateSelectedItem = Convert.ToDateTime(txtDcDate.Text);

            int dcPendingCount = _dbObj.GetDCPendings(Convert.ToInt32(ddlRequestedBy.SelectedValue));

            if (dcPendingCount > Convert.ToInt32(ConfigurationManager.AppSettings["DcPendingItems"].ToString()) && ddlDCTypeSelectedItem != "N")
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Selected Requested by already has more than " + ConfigurationManager.AppSettings["DcPendingItems"].ToString() + " pending items, please choose others or complete the pending items!.";
                return;
            }

            if (!string.IsNullOrEmpty(txtDcNumber.Text))
            {
                try
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        string quantity = ((TextBox)row.FindControl("txtQty")).Text.ToString();
                        decimal quantityCount = Convert.ToDecimal(string.IsNullOrEmpty(quantity.ToString()) ? 0 : Convert.ToDecimal(quantity.ToString()));

                        if (Convert.ToDecimal(quantityCount) <= 0)
                        {
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Quantity Send should be higher than zero.";
                            return;
                        }
                    }

                    string dcNumber = txtDcNumber.Text;
                    string dcDate = txtDcDate.Text;
                    string reason = txtReason.Text;
                    string dcType = ddlDcType.SelectedValue;

                    int ddlvendorcode = Convert.ToInt32(ddlVendorName.SelectedValue);
                    int ddlrequestedby = Convert.ToInt32(ddlRequestedBy.SelectedValue);
                    int ddlpreparedby = Convert.ToInt32(ddlPreparedBy.SelectedValue);

                    DateTime currentDate = Convert.ToDateTime(System.DateTime.UtcNow.ToString("dd/MM/yyyy"));
                    //DateTime nextDayDate = Convert.ToDateTime(System.DateTime.UtcNow.ToString("dd/MM/yyyy")).AddDays(1);

                    //if (Convert.ToDateTime(dcDate.ToString()) == currentDate) { }
                    if (Convert.ToDateTime(dcDate.ToString()) == currentDate || Convert.ToDateTime(dcDate.ToString()) == currentDate.AddDays(-1))
                    { }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "DC details can be update within 2 days of generation.";
                        return;
                    }

                    bool isDCNumberAvailableInMaster = _dbObj.IsDCMasterAvailableForDCNo(txtDcNumber.Text);

                    if (isDCNumberAvailableInMaster)
                    {
                        _dbObj.UpdateIntoDeliveryChallanMaster(dcNumber, dcDate, ddlvendorcode, reason, ddlrequestedby, ddlpreparedby);
                    }
                    else if (!isDCNumberAvailableInMaster && ddlDcType.SelectedIndex != 0)
                    {
                        _dbObj.InsertIntoDeliveryChallanMaster(dcNumber, dcType, dcDate, ddlvendorcode, reason, ddlrequestedby, ddlpreparedby);
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Entered DC Number is not available!. Please try to add new DC Number.";
                        return;
                    }

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        DropDownList ddlUnit = ((DropDownList)row.FindControl("ddlForUnits"));
                        String slno = ((Label)row.FindControl("lblRowNumber")).Text.ToString();
                        string itemDescription = ((TextBox)row.FindControl("txtItemDescription")).Text.ToString();
                        String quantity = ((TextBox)row.FindControl("txtQty")).Text.ToString();
                        string quantityReceived = ((TextBox)row.FindControl("txtReceived")).Text.ToString();
                        string rate = ((TextBox)row.FindControl("txtRate")).Text.ToString();

                        decimal receivedQty = _dbObj.GetReceivedQtyForParticularDCNumber(txtDcNumber.Text, Convert.ToInt32(slno));
                        bool isDCNumberAvailableInDetails = _dbObj.IsDCDetailsAvailableForSlNo(txtDcNumber.Text, Convert.ToInt32(slno));

                        if (isDCNumberAvailableInDetails)
                        {
                            if (Convert.ToDecimal(string.IsNullOrEmpty(quantity.ToString()) ? 0 : Convert.ToDecimal(quantity.ToString())) <= receivedQty)
                            {
                                lblMessage.Visible = true;
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                lblMessage.Text = "Quantity send should be greater than received quantity.";
                                return;
                            }
                            else if (receivedQty != 0)
                            {
                                lblMessage.Visible = true;
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                lblMessage.Text = "Cannot change DC Description, because it has some received quantity!.";
                                return;
                            }

                            _dbObj.UpdateIntoDeliveryChallanDetails(dcNumber, Convert.ToInt32(slno), ddlUnit.SelectedItem.Text.ToString(),
                         Convert.ToDecimal(quantity), Convert.ToDecimal(rate), itemDescription,
                         Convert.ToDecimal(string.IsNullOrEmpty(quantityReceived.ToString()) ? 0 : Convert.ToDecimal(quantityReceived.ToString())));

                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "DC Details Updated Successfully.";
                        }
                        else
                        {
                            _dbObj.InsertIntoDeliveryChallanDetails(dcNumber, Convert.ToInt32(slno), ddlUnit.SelectedItem.Text.ToString(),
                      Convert.ToDecimal(quantity), Convert.ToDecimal(rate), itemDescription, Convert.ToString(ddlpreparedby));

                            ddlDcType.SelectedIndex = 0;

                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "DC Details Added Successfully.";
                        }

                    }
                }
                catch (Exception ex)
                {
                    LogError(ex, "Exception from Update Delivery Challan");
                }

            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            //lblDcTypeErrorMsg.Visible = false;

            //try
            //{
            //    if (ddlDcType.SelectedIndex == 0)
            //    {
            //        lblDcTypeErrorMsg.Visible = true;
            //    }

            //    string dcNumber = txtDcNumber.Text;
            //    string dcDate = txtDcDate.Text;
            //    string reason = txtReason.Text;
            //    string dcType = ddlDcType.SelectedValue;
            //    int ddlvendorcode = Convert.ToInt32(ddlVendorName.SelectedValue);
            //    int ddlrequestedby = Convert.ToInt32(ddlRequestedBy.SelectedValue);
            //    int ddlpreparedby = Convert.ToInt32(ddlPreparedBy.SelectedValue);

            //    bool isDCNumberAvailableInMaster = _dbObj.IsDCMasterAvailableForDCNo(txtDcNumber.Text);

            //    if (!isDCNumberAvailableInMaster)
            //    {
            //        _dbObj.InsertIntoDeliveryChallanMaster(dcNumber, dcType, dcDate, ddlvendorcode, reason, ddlrequestedby, ddlpreparedby);
            //    }

            //    foreach (GridViewRow row in GridView1.Rows)
            //    {
            //        String ddlUnit = ((DropDownList)row.FindControl("ddlForUnits")).Text.ToString();
            //        String slno = ((Label)row.FindControl("lblRowNumber")).Text.ToString();
            //        string itemDescription = ((TextBox)row.FindControl("txtItemDescription")).Text.ToString();
            //        String quantity = ((TextBox)row.FindControl("txtQty")).Text.ToString();
            //        string quantityReceived = ((TextBox)row.FindControl("txtReceived")).Text.ToString();

            //        bool isDCNumberAvailableInDetails = _dbObj.IsDCDetailsAvailableForSlNo(txtDcNumber.Text, Convert.ToInt32(slno));
            //        if (!isDCNumberAvailableInDetails)
            //        {
            //            _dbObj.InsertIntoDeliveryChallanDetails(dcNumber, Convert.ToInt32(slno), Convert.ToInt32(ddlUnit),
            //            Convert.ToDecimal(quantity), itemDescription, Convert.ToString(ddlpreparedby));

            //            lblMessage.Visible = true;
            //            lblMessage.Text = "DC Details Added Successfully.";
            //        }
            //        else
            //        {
            //            _dbObj.UpdateIntoDeliveryChallanDetails(dcNumber, Convert.ToInt32(slno), Convert.ToInt32(ddlUnit),
            //               Convert.ToDecimal(quantity), itemDescription, Convert.ToDecimal(quantityReceived));

            //            lblMessage.Visible = true;
            //            lblMessage.Text = "DC Details Updated Successfully.";
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogError(ex, "Exception from Add Delivery Challan.");
            //}
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            Panel1.Visible = true;
            GridView1.Visible = true;

            lblDcTypeErrorMsg.Visible = false;
            DataSet ds = new DataSet();

            try
            {
                string dcNumber = txtDcNumber.Text;
                ds = _dbObj.GetDeliveryChallanSavedMasterDetails(dcNumber);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlVendorName.SelectedValue = ds.Tables[0].Rows[0]["VendorCode"].ToString();
                    ddlPreparedBy.SelectedValue = ds.Tables[0].Rows[0]["PreparedBy"].ToString();
                    ddlRequestedBy.SelectedValue = ds.Tables[0].Rows[0]["RequestedBy"].ToString();
                    txtReason.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
                    txtDcDate.Text = ds.Tables[0].Rows[0]["DCDate"].ToString();
                }

                ds = GetDCDetailsForParticularDCNo(dcNumber);
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from Searching DC Number");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMessage.Visible = false;

            try
            {
                int index = Convert.ToInt32(e.RowIndex);
                string dcNumber = txtDcNumber.Text;

                if (index != 0)
                {
                    int slNo = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                    DataTable dt = ViewState["CacheFromDeliveryChallanAddDetails"] as DataTable;

                    string dcDate = txtDcDate.Text;
                    DateTime currentDate = Convert.ToDateTime(System.DateTime.UtcNow.ToString("dd-MM-yyyy"));
                    //DateTime nextDayDate = Convert.ToDateTime(System.DateTime.UtcNow.ToString("dd-MM-yyyy")).AddDays(1);

                    if (Convert.ToDateTime(dcDate.ToString()) == currentDate || Convert.ToDateTime(dcDate.ToString()) == currentDate.AddDays(-1))
                    { }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "DC details can be delete within 2 days of generation.";

                        Panel1.Visible = true;
                        btnAdd.Visible = false;
                        btnEdit.Visible = false;
                        btnSearch.Visible = true;
                        btnUpdate.Visible = true;
                        btnAddItem.Visible = false;

                        GetDropDownInfo();

                        return;
                    }

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        decimal receivedQty = _dbObj.GetReceivedQtyForParticularDCNumber(txtDcNumber.Text, Convert.ToInt32(slNo));
                        // Checking whether DeliveryChallan Details already addded into particular DC Number.
                        bool isDCAvailable = _dbObj.IsDCDetailsAvailableForSlNo(txtDcNumber.Text, slNo);
                        if (isDCAvailable && receivedQty == 0)
                        {
                            _dbObj.RemoveDeliveryChallanSavedDetails(slNo, txtDcNumber.Text);
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "DC Details Deleted Successfully.";
                        }

                        dt.Rows[index].Delete();
                        ViewState["CurrentTable"] = dt;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        ViewState["CacheFromDeliveryChallanDetails"] = dt;

                        SetPreviousData();
                    }
                    else
                    {
                        decimal receivedQty = _dbObj.GetReceivedQtyForParticularDCNumber(txtDcNumber.Text, Convert.ToInt32(slNo));
                        // Checking whether DeliveryChallan Details already addded into particular DC Number.
                        bool isDCAvailable = _dbObj.IsDCDetailsAvailableForSlNo(txtDcNumber.Text, slNo);
                        if (isDCAvailable && receivedQty == 0)
                        {
                            _dbObj.RemoveDeliveryChallanSavedDetails(slNo, txtDcNumber.Text);
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "DC Details Deleted Successfully.";
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Cannot be deleted because it has receive quantity.";
                        }

                        DataSet ds = GetDCDetailsForParticularDCNo(txtDcNumber.Text);
                    }
                }

                Panel1.Visible = true;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSearch.Visible = true;
                btnUpdate.Visible = true;
                btnAddItem.Visible = false;

                GetDropDownInfo();

            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from While deleting the delivery chalan details.");
            }
        }

        private DataSet GetDCDetailsForParticularDCNo(string DCNumber)
        {
            DataSet ds = _dbObj.GetDeliveryChallanSavedDetails(DCNumber);

            ViewState["CacheFromDeliveryChallanDetails"] = ds.Tables[0];

            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();

                for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
                {
                    Label lblSerialNo = (Label)GridView1.Rows[i].Cells[0].FindControl("lblRowNumber");
                    TextBox textItemDescription = (TextBox)GridView1.Rows[i].Cells[1].FindControl("txtItemDescription");
                    DropDownList ddl1 = (DropDownList)GridView1.Rows[i].Cells[2].FindControl("ddlForUnits");
                    TextBox textQuantitySend = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtQty");
                    TextBox textRate = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtRate");
                    Label lblLocationID = (Label)GridView1.FindControl("lblUnitsID");

                    DataSet dsForItemCode = _dbObj.GetUnitsMasterDetails();

                    lblSerialNo.Text = ds.Tables[0].Rows[i]["SlNo"].ToString();
                    textItemDescription.Text = ds.Tables[0].Rows[i]["ItemDescription"].ToString();
                    textQuantitySend.Text = ds.Tables[0].Rows[i]["Quantity"].ToString();
                    textRate.Text = ds.Tables[0].Rows[i]["Rate"].ToString();

                    ddl1.DataSource = dsForItemCode;
                    //ddl1.DataValueField = "Id";
                    //ddl1.DataTextField = "Units";
                    ddl1.DataBind();
                    ddl1.SelectedValue = ds.Tables[0].Rows[i]["Id"].ToString();
                }
            }

            return ds;
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtQtySend = (TextBox)sender;

                //place it in naming container
                GridViewRow gvRow = (GridViewRow)txtQtySend.NamingContainer;
                TextBox textReceived = (TextBox)gvRow.FindControl("txtQty");
                int count = Convert.ToInt32(string.IsNullOrEmpty(textReceived.Text) ? 0 : Convert.ToInt32(textReceived.Text));

                if (count <= 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Quantity Send should be higher than zero.";
                    return;
                }


            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from view delivery challan receipts details!");
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDCNumberAvailableInMaster = _dbObj.IsDCMasterAvailableForDCNo(txtDcNumber.Text);

                if (!string.IsNullOrEmpty(txtDcNumber.Text) && isDCNumberAvailableInMaster)
                {
                    Session["DCNumber"] = txtDcNumber.Text;

                    Response.Redirect("~/DCReports.aspx", false);
                }

                Panel1.Visible = true;
                GridView1.Visible = true;
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from Print!");
            }
        }

        protected void ddlRequestedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            string ddlDCTypeSelectedItem = ddlDcType.SelectedValue;
            DateTime ddlDcDateSelectedItem = Convert.ToDateTime(txtDcDate.Text);

            int dcPendingCount = _dbObj.GetDCPendings(Convert.ToInt32(ddlRequestedBy.SelectedValue));

            if (dcPendingCount > Convert.ToInt32(ConfigurationManager.AppSettings["DcPendingItems"].ToString()) && ddlDCTypeSelectedItem != "N")
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Selected Requested by already has more than " + ConfigurationManager.AppSettings["DcPendingItems"].ToString() + " pending items, please choose others or complete the pending items!.";
            }

            ddlRequestedBy.SelectedValue = Convert.ToString(ddlRequestedBy.SelectedValue);
            Panel1.Visible = true;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnSearch.Visible = true;
            btnUpdate.Visible = true;
            btnAddItem.Visible = false;

            //GetDropDownInfo();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            try
            {
                string dcDate = txtDcDate.Text.Trim();
                DateTime currentDate = Convert.ToDateTime(System.DateTime.UtcNow.ToString("dd-MM-yyyy"));
                //DateTime nextDayDate = Convert.ToDateTime(System.DateTime.UtcNow.ToString("dd-MM-yyyy")).AddDays(1);

                bool isDCNumberAvailableInMaster = _dbObj.IsDCMasterAvailableForDCNo(txtDcNumber.Text.Trim());

                if (!isDCNumberAvailableInMaster)
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid DCNumber.";
                }
                else
                {
                    if (Convert.ToDateTime(dcDate.ToString()) == currentDate || Convert.ToDateTime(dcDate.ToString()) == currentDate.AddDays(-1))
                    {
                        decimal receivedQty = _dbObj.GetReceivedQtyFromDCNumber(txtDcNumber.Text.Trim());

                        if (receivedQty == 0)
                        {
                            _dbObj.RemoveDeliveryChallanMasterAndDetails(txtDcNumber.Text);
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "DC Details Cancelled Successfully.";
                            txtDcNumber.Text = "";
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Cannot be deleted because it has receive quantity.";
                        }
                    }
                    //else if (Convert.ToDateTime(dcDate.ToString()) >= nextDayDate) { }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "DC details can be delete within 2 days of generation.";
                        txtDcNumber.Text = "";

                        Panel1.Visible = true;
                        btnAdd.Visible = false;
                        btnEdit.Visible = false;
                        btnSearch.Visible = true;
                        btnUpdate.Visible = true;
                        btnAddItem.Visible = false;

                        GetDropDownInfo();

                        return;
                    }
                }

                Panel1.Visible = true;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSearch.Visible = true;
                btnUpdate.Visible = true;
                btnAddItem.Visible = false;

                GetDropDownInfo();

            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from While cancelling item from delivery chalan details and master.");
            }
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}