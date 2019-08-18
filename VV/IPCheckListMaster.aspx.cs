using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class IPCheckListMaster : System.Web.UI.Page
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
                ShowIPCheckListMasterDetails();
                FillLocationCode();
                FillSubLocationCode();
                FillCheckListSerial();


                RadioButton1.Checked = true;
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            try
            {
                if (ddlLocationCode.SelectedItem.Text == "----Please Select----")
                {
                    lblRequiredFields1.Visible = false;
                    lblRequiredFields2.Visible = false;
                    lblRequiredFields.Visible = true;

                    return;
                }

                if (ddlSubLocationCode.SelectedItem.Text == "----Please Select----")
                {
                    lblRequiredFields1.Visible = true;
                    lblRequiredFields2.Visible = false;
                    lblRequiredFields.Visible = false;

                    return;
                }

                else if (ddlCheckListSerial.SelectedItem.Text == "----Please Select----")
                {
                    lblRequiredFields.Visible = false;
                    lblRequiredFields2.Visible = true;
                    lblRequiredFields1.Visible = false;

                    return;
                }

                string LocationCode = ddlLocationCode.SelectedValue.ToString();
                string SubLocationCode = ddlSubLocationCode.SelectedValue.ToString();
                string CheckListSerial = ddlCheckListSerial.SelectedValue.ToString();
                bool Active = RadioButton1.Checked;
                int Priority = Convert.ToInt32(txtPriority.Text.Trim());

                bool IsExist = _dbObj.IsIPCheckListDetailsExist(LocationCode, SubLocationCode, Convert.ToInt32(CheckListSerial), Active == false ? 0 : 1);

                if (IsExist)
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Selected IP CheckList Master details already exist in the system.";

                    return;
                }

                _dbObj.InsertFromIPCheckListMaster(LocationCode, SubLocationCode, Convert.ToInt32(CheckListSerial), Active == false ? 0 : 1, Priority);

                ShowIPCheckListMasterDetails();

                btnClear_Click(sender, e);

                lblRequiredFields.Visible = false;
                lblRequiredFields1.Visible = false;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "IP CheckList Master Details Added Successfully.";
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception occured -- insert IP Check list master details.");
            }
            finally
            {
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            ddlLocationCodeGrid.SelectedIndex = 0;
            ddlSubLocationCodeGrid.SelectedIndex = 0;
            txtPriority.Text = string.Empty;

            ddlLocationCode.SelectedIndex = 0;
            ddlSubLocationCode.SelectedIndex = 0;
            ddlCheckListSerial.SelectedIndex = 0;

            DataSet searchDS = (DataSet)Cache["CacheFromIPCheckListMasterDetails"];
            GridView1.DataSource = searchDS;
            GridView1.DataBind();

        }

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty;

            string subLocationName = ddlSubLocationCodeGrid.SelectedItem.Text.Trim();
            string locationName = ddlLocationCodeGrid.SelectedItem.Text.Trim();

            if (!string.IsNullOrEmpty(locationName))
            {
                searchRowFilter1 = "LocationName like '%" + locationName + "%'";
            }
            if (!string.IsNullOrEmpty(subLocationName))
            {
                searchRowFilter2 = "SubLocationName like '%" + subLocationName + "%'";
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

            if (!String.IsNullOrEmpty(searchRowFilter))
            {
                DataSet searchDS = (DataSet)Cache["CacheFromIPCheckListMasterDetails"];

                DataView dv;
                dv = searchDS.Tables[0].DefaultView;

                dv.RowFilter = searchRowFilter;

                GridView1.DataSource = dv;
                GridView1.DataBind();

                //DataSet DS = new DataSet();
                //DS.Tables.Add(dv.ToTable());
                //Cache["CacheFromEmployeeMasterDetails"] = DS;
            }
            else
            {
                DBUtil _DBObj = new DBUtil();
                DataSet ds = _DBObj.RetriveByIPCheckListMasterDetails();
                Cache["CacheFromIPCheckListMasterDetails"] = ds;

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataSet searchDS = (DataSet)Cache["CacheFromIPCheckListMasterDetails"];
            GridView1.DataSource = searchDS;
            GridView1.DataBind();

            GridView1.EditIndex = -1;
            //  showgrid();

            GridView1.DataSource = searchDS;
            GridView1.DataBind();

            GridView1.EditIndex = -1;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMessage.Visible = false;

            DataSet ds = (DataSet)Cache["CacheFromIPCheckListMasterDetails"];

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
                LogError(ex, "Exception from while clicking on page number from location master.");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblMessage.Visible = false;

            DataSet searchDS = (DataSet)Cache["CacheFromIPCheckListMasterDetails"];
            GridView1.DataSource = searchDS;
            GridView1.DataBind();

            GridView1.EditIndex = e.NewEditIndex;
            //  showgrid();

            GridView1.DataSource = searchDS;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblMessage.Visible = false;
            int isActive = 0;

            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];

                Label Active = (Label)GridView1.Rows[e.RowIndex].FindControl("lblActive");
                DropDownList ddlActiveGrid = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlActiveGrid");
                TextBox txtPriority = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGridPriority");


                HiddenField hdnvalLocationCode = ((HiddenField)row.FindControl("hdnLocationCode"));
                HiddenField hdnvalSubLocationCode = ((HiddenField)row.FindControl("hdnSubLocationCode"));
                HiddenField hdnvalCheckListSerial = ((HiddenField)row.FindControl("hdnCheckListSerial"));
                HiddenField hdnvalCheckListPriority = ((HiddenField)row.FindControl("hdnPriority"));

                if (Convert.ToString(ddlActiveGrid.SelectedItem.Text) == "False")
                {
                    isActive = 0;
                }
                else if (Convert.ToString(ddlActiveGrid.SelectedItem.Text) == "True")
                {
                    isActive = 1;
                }
                else if (Convert.ToString(ddlActiveGrid.SelectedItem.Text) == "--Select--")
                {
                    return;
                }

                Label LocationCodeGrid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblLocationCode");
                Label SubLocationCodeGrid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSubLocationCode");
                Label CheckListGrid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCheckListSerial");

                //DropDownList ddlLocationCodeGrid = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlLocationCodeGrid");
                //DropDownList ddlSubLocationCodeGrid = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlSubLocationCodeGrid");
                //DropDownList ddlCheckListGrid = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlCheckListSerialGrid");

                _dbObj.UpdateFormIPCheckListMaster(Convert.ToString(hdnvalLocationCode.Value), Convert.ToString(hdnvalSubLocationCode.Value),
                    Convert.ToInt32(hdnvalCheckListSerial.Value), isActive, Convert.ToInt32(txtPriority.Text.Trim()));

                GridView1.EditIndex = -1;

                ShowIPCheckListMasterDetails();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while updating row from location Master.");
            }
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMessage.Visible = false;

            int isActive = 0;

            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];

                Label Active = (Label)GridView1.Rows[e.RowIndex].FindControl("lblActive");
                DropDownList ddlActiveGrid = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlActiveGrid");

                HiddenField hdnvalLocationCode = ((HiddenField)row.FindControl("hdnLocationCode"));
                HiddenField hdnvalSubLocationCode = ((HiddenField)row.FindControl("hdnSubLocationCode"));
                HiddenField hdnvalCheckListSerial = ((HiddenField)row.FindControl("hdnCheckListSerial"));

                if (Convert.ToString(Active.Text) == "False")
                {
                    isActive = 0;
                }
                else if (Convert.ToString(Active.Text) == "True")
                {
                    isActive = 1;
                }

                _dbObj.DeleteFromIPCheckListMaster(Convert.ToString(hdnvalLocationCode.Value), Convert.ToString(hdnvalSubLocationCode.Value),
                    Convert.ToInt32(hdnvalCheckListSerial.Value), isActive);

                ShowIPCheckListMasterDetails();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while updating row from employee Master.");
            }
        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        //    {
        //        (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        //    }
        //}

        private void ShowIPCheckListMasterDetails()
        {
            try
            {
                string pageSize = ConfigurationManager.AppSettings["GridPageSize"].ToString();

                DBUtil _DBObj = new DBUtil();
                DataSet ds = _DBObj.RetriveByIPCheckListMasterDetails();

                Cache["CacheFromIPCheckListMasterDetails"] = ds;

                GridView1.PageSize = Convert.ToInt32(pageSize);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from display location master details!");
            }
        }

        private DataSet FillLocationCode()
        {

            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.RetriveByLocationName();

            ddlLocationCode.DataSource = ds;
            ddlLocationCode.DataBind();

            ddlLocationCode.Items.Insert(0, "----Please Select----");

            ddlLocationCodeGrid.DataSource = ds;
            ddlLocationCodeGrid.DataBind();

            ddlLocationCodeGrid.Items.Insert(0, "----Please Select----");

            return ds;
        }

        private DataSet FillSubLocationCode()
        {

            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.RetriveByIPSubLocationCode();

            ddlSubLocationCode.DataSource = ds;
            ddlSubLocationCode.DataBind();

            ddlSubLocationCode.Items.Insert(0, "----Please Select----");

            ddlSubLocationCodeGrid.DataSource = ds;
            ddlSubLocationCodeGrid.DataBind();

            ddlSubLocationCodeGrid.Items.Insert(0, "----Please Select----");

            return ds;
        }

        private DataSet FillCheckListSerial()
        {

            DBUtil _DBObj = new DBUtil();
            DataSet ds = _DBObj.RetriveByCheckListSerial();

            ddlCheckListSerial.DataSource = ds;
            ddlCheckListSerial.DataBind();

            ddlCheckListSerial.Items.Insert(0, "----Please Select----");

            return ds;
        }

        protected void ddlLocationCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DBUtil _DBObj = new DBUtil();

            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                //DataSet ds = _DBObj.RetriveByLocationCode();

                //if (ds != null && ds.Tables[0].Rows.Count > 0)
                //{
                //    DataRowView drv = e.Row.DataItem as DataRowView;

                //    HiddenField hdnval = (HiddenField)e.Row.FindControl("LocationCode");

                //    DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("ddlLocationCodeGrid");

                //    DropDownList1.DataSource = ds.Tables[0];

                //    DropDownList1.DataTextField = "LocationCode";

                //    DropDownList1.DataValueField = "LocationCode";

                //    DropDownList1.DataBind();

                //    DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));

                //    if (hdnval != null)
                //    {
                //        DropDownList1.Items.FindByValue(hdnval.Value).Selected = true;
                //    }

                //}

                //DataSet ds1 = _DBObj.RetriveByIPSubLocationCode();

                //if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                //{
                //    DataRowView drv = e.Row.DataItem as DataRowView;

                //    HiddenField hdnval = (HiddenField)e.Row.FindControl("SubLocationCode");

                //    DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("ddlSubLocationCodeGrid");

                //    DropDownList2.DataSource = ds1.Tables[0];

                //    DropDownList2.DataTextField = "SubLocationCode";

                //    DropDownList2.DataValueField = "SubLocationCode";

                //    DropDownList2.DataBind();

                //    DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));

                //    if (hdnval != null)
                //    {
                //        DropDownList2.Items.FindByValue(hdnval.Value).Selected = true;
                //    }

                //}

                //DataSet ds2 = _DBObj.RetriveByCheckListSerial();

                //if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                //{
                //    DataRowView drv = e.Row.DataItem as DataRowView;

                //    HiddenField hdnval = (HiddenField)e.Row.FindControl("CheckListSerial");

                //    DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("ddlCheckListSerialGrid");

                //    DropDownList2.DataSource = ds2.Tables[0];

                //    DropDownList2.DataTextField = "CheckListSerial";

                //    DropDownList2.DataValueField = "CheckListSerial";

                //    DropDownList2.DataBind();

                //    DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));

                //    if (hdnval != null)
                //    {
                //        DropDownList2.Items.FindByValue(hdnval.Value).Selected = true;
                //    }

                //}


                DataRowView drv = e.Row.DataItem as DataRowView;

                HiddenField hdnval = (HiddenField)e.Row.FindControl("hdnActive");

                DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("ddlActiveGrid");

                DropDownList2.DataSource = new DataSet();

                DropDownList2.DataTextField = "Active";

                DropDownList2.DataValueField = "Active";

                DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
                DropDownList2.Items.Insert(1, new ListItem("True", "1"));
                DropDownList2.Items.Insert(2, new ListItem("False", "2"));

                //DropDownList2.DataBind();

                //if (hdnval != null)
                //{
                //    DropDownList2.Items.FindByValue(hdnval.Value).Selected = true;
                //}
            }
        }

        protected void ddlSubLocationCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCheckListSerial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}