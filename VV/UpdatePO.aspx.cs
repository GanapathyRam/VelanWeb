using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class UpdatePO : System.Web.UI.Page
    {
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
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataSet searchDS = (DataSet)Cache["CacheFromPOUploadItemsFromSuppliers"];
            GridView3.EditIndex = -1;

            GridView3.DataSource = searchDS;
            GridView3.DataBind();
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSet searchDS = (DataSet)Cache["CacheFromPOUploadItemsFromSuppliers"];

            GridView3.EditIndex = e.NewEditIndex;
           
            GridView3.DataSource = searchDS;
            GridView3.DataBind();

        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label lblPoOrderNo = (Label)GridView3.Rows[e.RowIndex].FindControl("lblPoOrderNo");
                Label lbPoPosition = (Label)GridView3.Rows[e.RowIndex].FindControl("lblPOPosition");

                CheckBox chkShipped = (CheckBox)GridView3.Rows[e.RowIndex].FindControl("chkShipped");
                DropDownList ddlRemarks = (DropDownList)GridView3.Rows[e.RowIndex].FindControl("ddlSupplierRemarks");

                TextBox txtCommittment1 = (TextBox)GridView3.Rows[e.RowIndex].FindControl("txtCommitment1");
                TextBox txtCommittment2 = (TextBox)GridView3.Rows[e.RowIndex].FindControl("txtCommitment2");
                TextBox txtCommittment3 = (TextBox)GridView3.Rows[e.RowIndex].FindControl("txtCommitment3");


                DBUtil _dbObj = new DBUtil();
                _dbObj.UpdatePOCommittmentFromSuppliers(lblPoOrderNo.Text.Trim(), lbPoPosition.Text.Trim(), txtCommittment1.Text.Trim(),
                    txtCommittment2.Text.Trim(), txtCommittment3.Text.Trim(), Convert.ToBoolean(chkShipped.Checked), ddlRemarks.SelectedItem.Text);


                lblresult.ForeColor = System.Drawing.Color.Green;
                lblresult.Text = "Details Updated successfully";

                GridView3.EditIndex = -1;

                var selectedListItem = RadioButtonList1.SelectedValue;

                ShowPOGrid(Convert.ToInt32(selectedListItem), "");
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from while updating row from PO Upload Items.");
            }
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Cache["CacheFromPOUploadItemsFromSuppliers"];

            GridView3.PageIndex = e.NewPageIndex;

            try
            {
                DataView dv;
                dv = ds.Tables[0].DefaultView;
                GridView3.DataSource = dv;
                GridView3.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from PO while clicking on page number for Uploaded Items.");
            }
        }

        public void ShowPOGrid(int isDueFor, string SupplierName)
        {
            try
            {
                string pageSize = ConfigurationManager.AppSettings["GridPageSize"].ToString();
                DBUtil _DBObj = new DBUtil();

                //bool isDueFor = 

                DataSet ds = _DBObj.RetriveByPOCommittmentFromSuppliers(isDueFor, SupplierName);

                Cache["CacheFromPOUploadItemsFromSuppliers"] = ds;

                GridView3.PageSize = Convert.ToInt32(pageSize);
                GridView3.DataSource = ds;
                GridView3.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from Upload PO button click!");
            }
        }

        //protected void btnSearchBox_Click(object sender, EventArgs e)
        //{
        //    String searchRowFilter = String.Empty, searchRowFilter1 = String.Empty, searchRowFilter2 = String.Empty, searchRowFilter3 = String.Empty, searchRowFilter4 = String.Empty;

        //    BulkUpdatePO.Visible = true;

        //    string ProdOrder = txtPoOrder.Text.Trim();
        //    string ItemNumber = txtItemNumber.Text.Trim();
        //    string Buyers = txtBuyers.Text.Trim();
        //    string SupplierName = txtName.Text.Trim();

        //    if (!string.IsNullOrEmpty(ProdOrder))
        //    {
        //        searchRowFilter1 = "PoOrder like '%" + ProdOrder + "%'";
        //    }
        //    if (!string.IsNullOrEmpty(ItemNumber))
        //    {
        //        searchRowFilter2 = "ItemNumber like '%" + ItemNumber + "%'";
        //    }
        //    if (!string.IsNullOrEmpty(Buyers))
        //    {
        //        searchRowFilter3 = "Buyer like '%" + Buyers + "%'";
        //    }
        //    if (!string.IsNullOrEmpty(SupplierName))
        //    {
        //        searchRowFilter4 = "Name like '%" + SupplierName + "%'";
        //    }

        //    if (!String.IsNullOrEmpty(searchRowFilter1))
        //        searchRowFilter = searchRowFilter1;

        //    if (!String.IsNullOrEmpty(searchRowFilter2))
        //    {
        //        if (!String.IsNullOrEmpty(searchRowFilter))
        //            searchRowFilter = searchRowFilter + " AND " + searchRowFilter2;
        //        else
        //            searchRowFilter = searchRowFilter2;
        //    }

        //    if (!String.IsNullOrEmpty(searchRowFilter3))
        //    {
        //        if (!String.IsNullOrEmpty(searchRowFilter))
        //            searchRowFilter = searchRowFilter + " AND " + searchRowFilter3;
        //        else
        //            searchRowFilter = searchRowFilter3;
        //    }

        //    if (!String.IsNullOrEmpty(searchRowFilter4))
        //    {
        //        if (!String.IsNullOrEmpty(searchRowFilter))
        //            searchRowFilter = searchRowFilter + " AND " + searchRowFilter4;
        //        else
        //            searchRowFilter = searchRowFilter4;
        //    }

        //    if (!String.IsNullOrEmpty(searchRowFilter))
        //    {
        //        DataSet searchDS = (DataSet)Cache["CacheFromPOUploadItemsFromSuppliers"];

        //        DataView dv;
        //        dv = searchDS.Tables[0].DefaultView;

        //        dv.RowFilter = searchRowFilter;

        //        GridView3.DataSource = dv;
        //        GridView3.DataBind();
        //    }
        //    else if (string.IsNullOrEmpty(searchRowFilter1) && string.IsNullOrEmpty(searchRowFilter2) && string.IsNullOrEmpty(searchRowFilter3)
        //       && string.IsNullOrEmpty(searchRowFilter4))
        //    {
        //        DataSet searchDS = (DataSet)Cache["CacheFromPOUploadItemsFromSuppliers"];

        //        DataView dv;
        //        dv = searchDS.Tables[0].DefaultView;

        //        dv.RowFilter = "Buyer = '' OR Buyer is null";

        //        GridView3.DataSource = dv;
        //        GridView3.DataBind();
        //    }
        //    else
        //    {
        //        DataSet searchDS = (DataSet)Cache["CacheFromPOUploadItemsFromSuppliers"];
        //        GridView3.DataSource = searchDS;
        //        GridView3.DataBind();
        //    }
        //}

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DBUtil _DBObj = new DBUtil();

            if (e.Row.RowType == DataControlRowType.DataRow && GridView3.EditIndex == e.Row.RowIndex)
            {
                DataSet ds = _DBObj.RetriveBySupplierRemarksForDropDown();

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRowView drv = e.Row.DataItem as DataRowView;

                    HiddenField hdnval = (HiddenField)e.Row.FindControl("SupplierRemarks");

                    DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("ddlSupplierRemarks");

                    DropDownList1.DataSource = ds.Tables[0];

                    DropDownList1.DataTextField = "SupplierRemarks";

                    DropDownList1.DataValueField = "Id";

                    DropDownList1.DataBind();

                    DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));

                    if (hdnval != null)
                    {
                        DropDownList1.Items.FindByValue(hdnval.Value).Selected = true;
                    }

                }

            }
        }

        protected void GridView3_PreRender(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                TextBox txtComm1 = GridView3.Rows[i].FindControl("txtCommitment1") as TextBox;
                TextBox txtComm2 = GridView3.Rows[i].FindControl("txtCommitment2") as TextBox;
                TextBox txtComm3 = GridView3.Rows[i].FindControl("txtCommitment3") as TextBox;

                if (txtComm1 != null && !string.IsNullOrEmpty(txtComm1.Text))
                {
                    txtComm1.Enabled = false;
                }

                if (txtComm2 != null && !string.IsNullOrEmpty(txtComm2.Text))
                {
                    txtComm2.Enabled = false;
                }

                if (txtComm3 != null && !string.IsNullOrEmpty(txtComm3.Text))
                {
                    txtComm3.Enabled = false;
                }

                if (txtComm1 != null && string.IsNullOrEmpty(txtComm1.Text))
                {
                    txtComm1.Enabled = true;
                    txtComm2.Enabled = false;
                    txtComm3.Enabled = false;
                }

                else if (txtComm2 != null && string.IsNullOrEmpty(txtComm2.Text))
                {
                    txtComm1.Enabled = false;
                    txtComm2.Enabled = true;
                    txtComm3.Enabled = false;
                }

                else if (txtComm3 != null && string.IsNullOrEmpty(txtComm3.Text))
                {
                    txtComm1.Enabled = false;
                    txtComm2.Enabled = false;
                    txtComm3.Enabled = true;
                }
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblresult.Text = "";
            var selectedListItem = RadioButtonList1.SelectedValue;

            ShowPOGrid(Convert.ToInt32(selectedListItem), "");
        }

        /// <summary>
        /// Method for Error logs 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="section"></param>
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
    }
}