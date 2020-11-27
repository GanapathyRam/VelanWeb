using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class HeatNoValues : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DBUtil _dbObj = new DBUtil();

        protected void Page_Load(object sender, EventArgs e)
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

            if (!IsPostBack)
            {
                GetDropDownInfo();
            }
        }

        protected void txtHeatNo_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            DataSet ds = _dbObj.GetHeatNoDetails(txtHeatNo.Text.Trim());

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlMaterialCode.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["MaterialCode"]);

                ddlHeatTreatment.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["HTCode"]);

                txtSupplier.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier"]);

                CheckBoxList1.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["PED"]);

                ddlMaterialCode.Enabled = false;

                Panel1.Visible = true;

                FillTableValue(Convert.ToString(ds.Tables[0].Rows[0]["MaterialCode"]), Convert.ToString(ds.Tables[0].Rows[0]["Matltype"]));

                btnNew.Enabled = false;

                btnUpdate.Enabled = true;

                btnDelete.Enabled = true;
            }
            else
            {

                GetDropDownInfo();

                txtSupplier.Text = "";

                CheckBoxList1.SelectedIndex = Convert.ToInt32("1");

                ddlMaterialCode.Enabled = true;

                btnNew.Enabled = true;

                btnUpdate.Enabled = false;

                btnDelete.Enabled = false;

                Panel1.Visible = false;

                ddlMaterialCode.Enabled = false;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = _dbObj.GetHeatNoDetails(txtHeatNo.Text.Trim());

                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    if (ddlMaterialCode.SelectedItem.Text != "--Please Select--" && ddlHeatTreatment.SelectedItem.Text != "--Please Select--" && txtHeatNo.Text.Trim() != string.Empty)
                    {
                        _dbObj.InsertHeatNoMaster(txtHeatNo.Text.Trim(), txtSupplier.Text.Trim(), Convert.ToString(ddlMaterialCode.SelectedItem.Value), Convert.ToString(ddlMaterialCode.SelectedItem.Text), CheckBoxList1.SelectedItem.Value,
                            txtCActual.Text.Trim(), txtMnActual.Text.Trim(), txtPActual.Text.Trim(), txtSActual.Text.Trim(), txtSiActual.Text.Trim(), txtCuActual.Text.Trim(), txtNiActual.Text.Trim(), txtCrActual.Text.Trim(),
                            txtMoActual.Text.Trim(), txtVActual.Text.Trim(), txtCuNiCrMoVActual.Text.Trim(), txtCrMoActual.Text.Trim(), txtNbActual.Text.Trim(), txtNActual.Text.Trim(), txtAlActual.Text.Trim(), txtTiActual.Text.Trim(),
                            txtZrActual.Text.Trim(), txtFeActual.Text.Trim(), txtTaActual.Text.Trim(), txtNbActual.Text.Trim(), txtTensileMPAActual.Text.Trim(), txtTensileKSIActual.Text.Trim(), txtYieldMPAActual.Text.Trim(),
                            txtYieldKSIActual.Text.Trim(), txtElongationActual.Text.Trim(), txtReductionActual.Text.Trim(), txtHardnessActual.Text.Trim(), Convert.ToString(ddlHeatTreatment.SelectedItem.Value), txtImpact1.Text.Trim(),
                            txtImpact2.Text.Trim(), txtImpact3.Text.Trim(), txtImpact4.Text.Trim(), txtImpact5.Text.Trim(), txtImpact6.Text.Trim(), txtTemperatureC.Text.Trim(),
                            txtTemperatureF.Text.Trim());

                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Saved Successfully!.";

                        GetDropDownInfo();

                        txtSupplier.Text = "";

                        CheckBoxList1.SelectedIndex = Convert.ToInt32("1");

                        ddlMaterialCode.Enabled = true;

                        btnNew.Enabled = true;

                        btnUpdate.Enabled = false;

                        btnDelete.Enabled = false;

                        txtHeatNo.Text = "";

                        Panel1.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from saving heat no values");
            }
            finally
            {
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = _dbObj.GetHeatNoDetails(txtHeatNo.Text.Trim());

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ddlMaterialCode.SelectedItem.Text != "--Please Select--" && ddlHeatTreatment.SelectedItem.Text != "--Please Select--" && txtHeatNo.Text.Trim() != string.Empty)
                    {
                        _dbObj.UpdateHeatNoMaster(txtHeatNo.Text.Trim(), txtSupplier.Text.Trim(), Convert.ToString(ddlMaterialCode.SelectedItem.Value), Convert.ToString(ddlMaterialCode.SelectedItem.Text), CheckBoxList1.SelectedItem.Value,
                            txtCActual.Text.Trim(), txtMnActual.Text.Trim(), txtPActual.Text.Trim(), txtSActual.Text.Trim(), txtSiActual.Text.Trim(), txtCuActual.Text.Trim(), txtNiActual.Text.Trim(), txtCrActual.Text.Trim(),
                            txtMoActual.Text.Trim(), txtVActual.Text.Trim(), txtCuNiCrMoVActual.Text.Trim(), txtCrMoActual.Text.Trim(), txtNbActual.Text.Trim(), txtNActual.Text.Trim(), txtAlActual.Text.Trim(), txtTiActual.Text.Trim(),
                            txtZrActual.Text.Trim(), txtFeActual.Text.Trim(), txtTaActual.Text.Trim(), txtNbActual.Text.Trim(), txtTensileMPAActual.Text.Trim(), txtTensileKSIActual.Text.Trim(), txtYieldMPAActual.Text.Trim(),
                            txtYieldKSIActual.Text.Trim(), txtElongationActual.Text.Trim(), txtReductionActual.Text.Trim(), txtHardnessActual.Text.Trim(), Convert.ToString(ddlHeatTreatment.SelectedItem.Value), txtImpact1.Text.Trim(),
                            txtImpact2.Text.Trim(), txtImpact3.Text.Trim(), txtImpact4.Text.Trim(), txtImpact5.Text.Trim(), txtImpact6.Text.Trim(), txtTemperatureC.Text.Trim(),
                            txtTemperatureF.Text.Trim());

                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Updated Successfully!.";
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from updating heat no values");
            }
            finally
            {
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = _dbObj.GetHeatNoDetails(txtHeatNo.Text.Trim());

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    _dbObj.DeleteHeatNoMaster(txtHeatNo.Text.Trim(), Convert.ToString(ddlMaterialCode.SelectedItem.Value));

                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Deleted Successfully!.";

                    GetDropDownInfo();

                    txtSupplier.Text = "";

                    CheckBoxList1.SelectedIndex = Convert.ToInt32("1");

                    ddlMaterialCode.Enabled = true;

                    btnNew.Enabled = true;

                    btnUpdate.Enabled = false;

                    btnDelete.Enabled = false;

                    Panel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from deleting heat no values");
            }
            finally
            {
            }
        }

        protected void ddlHeatTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMaterialCode.Enabled = true;
        }

        protected void ddlMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaterialCode.SelectedItem.Text != "--Please Select--" && ddlHeatTreatment.SelectedItem.Text != "--Please Select--" && txtHeatNo.Text.Trim() != string.Empty)
            {
                lblMessage.Visible = false;

                Panel1.Visible = true;

                FillTableValue(ddlMaterialCode.SelectedItem.Value, ddlMaterialCode.SelectedItem.Text);
            }
            else
            {
                lblMessage.Visible = true;

                Panel1.Visible = false;

                lblMessage.ForeColor = System.Drawing.Color.Red;

                lblMessage.Text = "Please select the required fields to proceed further.";
            }
        }

        public void GetDropDownInfo()
        {
            DataSet ds = new DataSet();

            ds = _dbObj.GetMatrialCodeFromChemicalMechanicalMaster();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlMaterialCode.DataSource = ds;
                ddlMaterialCode.DataBind();

                ddlMaterialCode.Items.Insert(0, new ListItem("--Please Select--"));
            }

            ds = _dbObj.GetMatrialCodeForHeatNoValues();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlHeatTreatment.DataSource = ds;
                ddlHeatTreatment.DataBind();

                ddlHeatTreatment.Items.Insert(0, new ListItem("--Please Select--"));
            }
        }

        public void FillGridView()
        {
            DataSet ds = new DataSet();

            ds = _dbObj.GetHeatNoValuesFromMaterialCode("", "");

            if (ds.Tables[0].Rows.Count > 0)
            {
                //GridView1.DataSource = ds;
                //GridView1.DataBind();
            }

        }

        private void FillTableValue(string materialCode, string description)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = _dbObj.GetHeatNoValuesFromMaterialCode(materialCode, description);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblCMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CMin"]);
                    lblCMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CMax"]);
                    txtCActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["CAct"]);

                    lblMnMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["MnMin"]);
                    lblMnMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["MnMax"]);
                    txtMnActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["MnAct"]);

                    lblPMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMin"]);
                    lblPMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMax"]);
                    txtPActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["PAct"]);

                    lblSMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMin"]);
                    lblSMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMax"]);
                    txtSActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["SAct"]);

                    lblSiMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiMin"]);
                    lblSiMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiMax"]);
                    txtSiActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiAct"]);

                    lblCuMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuMin"]);
                    lblCuMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuMax"]);
                    txtCuActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuAct"]);

                    lblNiMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["NiMin"]);
                    lblNiMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["NiMax"]);
                    txtNiActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["NiAct"]);

                    lblCrMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMin"]);
                    lblCrMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMax"]);
                    txtCrActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrAct"]);

                    lblMoMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["MoMin"]);
                    lblMoMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["MoMax"]);
                    txtMoActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["MoAct"]);

                    lblVMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMin"]);
                    lblVMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMax"]);
                    txtVActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["VAct"]);

                    lblCuNiCrMoVMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuNiCrMoVMin"]);
                    lblCuNiCrMoVMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuNiCrMoVMax"]);
                    txtCuNiCrMoVActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuNiCrMoVAct"]);

                    lblCrMoMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMoMin"]);
                    lblCrMoMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMoMax"]);
                    txtCrActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMoAct"]);

                    lblNbMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbMin"]);
                    lblNbMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbMax"]);
                    txtNbActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbAct"]);

                    lblNMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["NMin"]);
                    lblNMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["NMax"]);
                    txtNActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["NAct"]);

                    lblAlMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["AlMin"]);
                    lblAlMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["AlMax"]);
                    txtAlActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["AlAct"]);

                    lblTiMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["TiMin"]);
                    lblTiMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TiMax"]);
                    txtTiActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["TiAct"]);

                    lblZrMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZrMin"]);
                    lblZrMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZrMax"]);
                    txtZrActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZrAct"]);

                    lblFeMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["FeMax"]);
                    lblFeMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["FeMin"]);
                    txtFeActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["FeAct"]);

                    lblTaMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["TaMin"]);
                    lblTaMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TaMax"]);
                    txtTaActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["TaAct"]);

                    lblNbTaMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbTaMin"]);
                    lblNbTaMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbTaMax"]);
                    txtNbTaActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbTaAct"]);

                    lblTensileMPAMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileMPAMin"]);
                    TensileMPAMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileMPAMax"]);
                    txtTensileMPAActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileMPAAct"]);

                    lblTensileKSIMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMin"]);
                    lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtTensileKSIActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIAct"]);

                    lblYieldMPAMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAMin"]);
                    //lblCMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAMax"]);
                    txtYieldMPAActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAAct"]);

                    lblYieldKSIMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIMin"]);
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIMax"]);
                    txtYieldKSIActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIAct"]);

                    lblElongationMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElongationMin"]);
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtElongationActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElongationAct"]);

                    lblReductionMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReductionMin"]);
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtReductionActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReductionAct"]);

                    lblHardnessMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["HardnessMin"]);
                    lblHardnessMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["HardnessMax"]);
                    txtHardnessActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["HardnessAct"]);


                    txtImpact1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Impact1Act"]);
                    txtImpact2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Impact2Act"]);
                    txtImpact3.Text = Convert.ToString(ds.Tables[0].Rows[0]["Impact3Act"]);
                    txtImpact4.Text = Convert.ToString(ds.Tables[0].Rows[0]["Impact4Act"]);
                    txtImpact5.Text = Convert.ToString(ds.Tables[0].Rows[0]["Impact5Act"]);
                    txtImpact6.Text = Convert.ToString(ds.Tables[0].Rows[0]["Impact6Act"]);
                    txtTemperatureC.Text = Convert.ToString(ds.Tables[0].Rows[0]["TemperatureCAct"]);
                    txtTemperatureF.Text = Convert.ToString(ds.Tables[0].Rows[0]["TemperatureFAct"]);
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from assiging values to heat no values based on heat no");
            }
            finally
            {
            }

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