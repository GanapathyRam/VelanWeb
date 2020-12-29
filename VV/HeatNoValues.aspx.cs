using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

            if (!IsPostBack)
            {
                GetDropDownInfo();
            }
        }

        protected void txtHeatNo_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            DataSet ds = _dbObj.GetHeatNoDetails(txtHeatNo.Text.Trim());

            Panel2.Visible = false;

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlMaterialCode.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["MaterialCode"]);

                ddlHeatTreatment.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["HTCode"]);

                txtSupplier.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier"]);

                RadioButtonList1.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["PED"]);

                ddlMaterialCode.Enabled = false;

                Panel1.Visible = true;

                FillTableValue(Convert.ToString(ds.Tables[0].Rows[0]["MaterialCode"]), Convert.ToString(ds.Tables[0].Rows[0]["Matltype"]), txtHeatNo.Text.Trim());

                btnNew.Enabled = false;

                btnUpdate.Enabled = true;

                btnDelete.Enabled = true;
            }
            else
            {

                GetDropDownInfo();

                txtSupplier.Text = "";

                RadioButtonList1.SelectedIndex = Convert.ToInt32("1");

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
                    if (ddlMaterialCode.SelectedItem.Text != "--Please Select--" && ddlHeatTreatment.SelectedItem.Text != "--Please Select--"
                        && txtHeatNo.Text.Trim() != string.Empty && string.IsNullOrEmpty(TextArea1.Value))
                    {
                        _dbObj.InsertHeatNoMaster(txtHeatNo.Text.Trim(), txtSupplier.Text.Trim(), Convert.ToString(ddlMaterialCode.SelectedItem.Value), Convert.ToString(ddlMaterialCode.SelectedItem.Text), RadioButtonList1.SelectedItem.Value,
                            txtCActual.Text.Trim(), txtMnActual.Text.Trim(), txtPActual.Text.Trim(), txtSActual.Text.Trim(), txtSiActual.Text.Trim(), txtCuActual.Text.Trim(), txtNiActual.Text.Trim(), txtCrActual.Text.Trim(),
                            txtMoActual.Text.Trim(), txtVActual.Text.Trim(), txtCuNiCrMoVActual.Text.Trim(), txtCrMoActual.Text.Trim(), txtNbActual.Text.Trim(), txtNActual.Text.Trim(), txtAlActual.Text.Trim(), txtTiActual.Text.Trim(),
                            txtZrActual.Text.Trim(), txtFeActual.Text.Trim(), txtTaActual.Text.Trim(), txtNbTaActual.Text.Trim(), txtTensileMPAActual.Text.Trim(), txtTensileKSIActual.Text.Trim(), txtYieldMPAActual.Text.Trim(),
                            txtYieldKSIActual.Text.Trim(), txtElongationActual.Text.Trim(), txtReductionActual.Text.Trim(), txtHardnessActual.Text.Trim(), Convert.ToString(ddlHeatTreatment.SelectedItem.Value), txtImpact1.Text.Trim(),
                            txtImpact2.Text.Trim(), txtImpact3.Text.Trim(), txtImpact4.Text.Trim(), txtImpact5.Text.Trim(), txtImpact6.Text.Trim(), txtTemperatureF.Text.Trim(), txtTemperatureC.Text.Trim());

                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Saved Successfully!";

                        GetDropDownInfo();

                        txtSupplier.Text = "";

                        RadioButtonList1.SelectedIndex = Convert.ToInt32("1");

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
                    if (ddlMaterialCode.SelectedItem.Text != "--Please Select--" && ddlHeatTreatment.SelectedItem.Text != "--Please Select--"
                        && txtHeatNo.Text.Trim() != string.Empty && string.IsNullOrEmpty(TextArea1.Value))
                    {
                        _dbObj.UpdateHeatNoMaster(txtHeatNo.Text.Trim(), txtSupplier.Text.Trim(), Convert.ToString(ddlMaterialCode.SelectedItem.Value), Convert.ToString(ddlMaterialCode.SelectedItem.Text), RadioButtonList1.SelectedItem.Value,
                            txtCActual.Text.Trim(), txtMnActual.Text.Trim(), txtPActual.Text.Trim(), txtSActual.Text.Trim(), txtSiActual.Text.Trim(), txtCuActual.Text.Trim(), txtNiActual.Text.Trim(), txtCrActual.Text.Trim(),
                            txtMoActual.Text.Trim(), txtVActual.Text.Trim(), txtCuNiCrMoVActual.Text.Trim(), txtCrMoActual.Text.Trim(), txtNbActual.Text.Trim(), txtNActual.Text.Trim(), txtAlActual.Text.Trim(), txtTiActual.Text.Trim(),
                            txtZrActual.Text.Trim(), txtFeActual.Text.Trim(), txtTaActual.Text.Trim(), txtNbActual.Text.Trim(), txtTensileMPAActual.Text.Trim(), txtTensileKSIActual.Text.Trim(), txtYieldMPAActual.Text.Trim(),
                            txtYieldKSIActual.Text.Trim(), txtElongationActual.Text.Trim(), txtReductionActual.Text.Trim(), txtHardnessActual.Text.Trim(), Convert.ToString(ddlHeatTreatment.SelectedItem.Value), txtImpact1.Text.Trim(),
                            txtImpact2.Text.Trim(), txtImpact3.Text.Trim(), txtImpact4.Text.Trim(), txtImpact5.Text.Trim(), txtImpact6.Text.Trim(), txtTemperatureC.Text.Trim(),
                            txtTemperatureF.Text.Trim());

                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Updated Successfully!";
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
                    lblMessage.Text = "Deleted Successfully!";

                    GetDropDownInfo();

                    txtSupplier.Text = "";

                    RadioButtonList1.SelectedIndex = Convert.ToInt32("1");

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
            Panel2.Visible = false;

            if (ddlMaterialCode.SelectedItem.Text != "--Please Select--" && ddlHeatTreatment.SelectedItem.Text != "--Please Select--" && txtHeatNo.Text.Trim() != string.Empty)
            {
                lblMessage.Visible = false;

                Panel1.Visible = true;

                DataSet ds = _dbObj.GetHeatNoDetails(txtHeatNo.Text.Trim());

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    FillTableValue(ddlMaterialCode.SelectedItem.Value, ddlMaterialCode.SelectedItem.Text, txtHeatNo.Text.Trim());
                }
                else
                {
                    FillTableValueWithOutHeatCode(ddlMaterialCode.SelectedItem.Value, ddlMaterialCode.SelectedItem.Text);
                }
            }
            else
            {
                lblMessage.Visible = true;

                Panel1.Visible = false;

                lblMessage.ForeColor = System.Drawing.Color.Red;

                lblMessage.Text = "Selection Missing";
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

        private void FillTableValue(string materialCode, string description, string heatCode)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = _dbObj.GetMinAndMaxWithHeatCode(materialCode, description, heatCode);

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
                    txtCrMoActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMoAct"]);

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
                    txtYieldKSIActual.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIAct"]);

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
                else
                {
                    lblCMin.Text = "";
                    lblCMax.Text = "";
                    txtCActual.Text = "";

                    lblMnMin.Text = "";
                    lblMnMax.Text = "";
                    txtMnActual.Text = "";

                    lblPMin.Text = "";
                    lblPMax.Text = "";
                    txtPActual.Text = "";

                    lblSMin.Text = "";
                    lblSMax.Text = "";
                    txtSActual.Text = "";

                    lblSiMin.Text = "";
                    lblSiMax.Text = "";
                    txtSiActual.Text = "";

                    lblCuMin.Text = "";
                    lblCuMax.Text = "";
                    txtCuActual.Text = "";

                    lblNiMin.Text = "";
                    lblNiMax.Text = "";
                    txtNiActual.Text = "";

                    lblCrMin.Text = "";
                    lblCrMax.Text = "";
                    txtCrActual.Text = "";

                    lblMoMin.Text = "";
                    lblMoMax.Text = "";
                    txtMoActual.Text = "";

                    lblVMin.Text = "";
                    lblVMax.Text = "";
                    txtVActual.Text = "";

                    lblCuNiCrMoVMin.Text = "";
                    lblCuNiCrMoVMax.Text = "";
                    txtCuNiCrMoVActual.Text = "";

                    lblCrMoMin.Text = "";
                    lblCrMoMax.Text = "";
                    txtCrMoActual.Text = "";

                    lblNbMin.Text = "";
                    lblNbMax.Text = "";
                    txtNbActual.Text = "";

                    lblNMin.Text = "";
                    lblNMax.Text = "";
                    txtNActual.Text = "";

                    lblAlMin.Text = "";
                    lblAlMax.Text = "";
                    txtAlActual.Text = "";

                    lblTiMin.Text = "";
                    lblTiMax.Text = "";
                    txtTiActual.Text = "";

                    lblZrMin.Text = "";
                    lblZrMax.Text = "";
                    txtZrActual.Text = "";

                    lblFeMax.Text = "";
                    lblFeMin.Text = "";
                    txtFeActual.Text = "";

                    lblTaMin.Text = "";
                    lblTaMax.Text = "";
                    txtTaActual.Text = "";

                    lblNbTaMin.Text = "";
                    lblNbTaMax.Text = "";
                    txtNbTaActual.Text = "";

                    lblTensileMPAMin.Text = "";
                    TensileMPAMax.Text = "";
                    txtTensileMPAActual.Text = "";

                    lblTensileKSIMin.Text = "";
                    lblTensileKSIMax.Text = "";
                    txtTensileKSIActual.Text = "";

                    lblYieldMPAMin.Text = "";
                    //lblCMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAMax"]);
                    txtYieldMPAActual.Text = "";

                    lblYieldKSIMin.Text = "";
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIMax"]);
                    txtYieldKSIActual.Text = "";

                    lblElongationMin.Text = "";
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtElongationActual.Text = "";

                    lblReductionMin.Text = "";
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtReductionActual.Text = "";

                    lblHardnessMin.Text = "";
                    lblHardnessMax.Text = "";
                    txtHardnessActual.Text = "";


                    txtImpact1.Text = "";
                    txtImpact2.Text = "";
                    txtImpact3.Text = "";
                    txtImpact4.Text = "";
                    txtImpact5.Text = "";
                    txtImpact6.Text = "";
                    txtTemperatureC.Text = "";
                    txtTemperatureF.Text = "";
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

        private void FillTableValueWithOutHeatCode(string materialCode, string description)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = _dbObj.GetMinAndMaxWithoutHeatCode(materialCode, description);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblCMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CMin"]);
                    lblCMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CMax"]);
                    txtCActual.Text = "";

                    lblMnMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["MnMin"]);
                    lblMnMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["MnMax"]);
                    txtMnActual.Text = "";

                    lblPMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMin"]);
                    lblPMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMax"]);
                    txtPActual.Text = "";

                    lblSMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMin"]);
                    lblSMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMax"]);
                    txtSActual.Text = "";

                    lblSiMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiMin"]);
                    lblSiMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["SiMax"]);
                    txtSiActual.Text = "";

                    lblCuMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuMin"]);
                    lblCuMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuMax"]);
                    txtCuActual.Text = "";

                    lblNiMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["NiMin"]);
                    lblNiMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["NiMax"]);
                    txtNiActual.Text = "";

                    lblCrMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMin"]);
                    lblCrMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMax"]);
                    txtCrActual.Text = "";

                    lblMoMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["MoMin"]);
                    lblMoMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["MoMax"]);
                    txtMoActual.Text = "";

                    lblVMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMin"]);
                    lblVMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMax"]);
                    txtVActual.Text = "";

                    lblCuNiCrMoVMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuNiCrMoVMin"]);
                    lblCuNiCrMoVMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CuNiCrMoVMax"]);
                    txtCuNiCrMoVActual.Text = "";

                    lblCrMoMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMoMin"]);
                    lblCrMoMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CrMoMax"]);
                    txtCrMoActual.Text = "";

                    lblNbMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbMin"]);
                    lblNbMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbMax"]);
                    txtNbActual.Text = "";

                    lblNMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["NMin"]);
                    lblNMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["NMax"]);
                    txtNActual.Text = "";

                    lblAlMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["AlMin"]);
                    lblAlMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["AlMax"]);
                    txtAlActual.Text = "";

                    lblTiMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["TiMin"]);
                    lblTiMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TiMax"]);
                    txtTiActual.Text = "";

                    lblZrMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZrMin"]);
                    lblZrMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZrMax"]);
                    txtZrActual.Text = "";

                    lblFeMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["FeMax"]);
                    lblFeMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["FeMin"]);
                    txtFeActual.Text = "";

                    lblTaMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["TaMin"]);
                    lblTaMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TaMax"]);
                    txtTaActual.Text = "";

                    lblNbTaMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbTaMin"]);
                    lblNbTaMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["NbTaMax"]);
                    txtNbTaActual.Text = "";

                    lblTensileMPAMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileMPAMin"]);
                    TensileMPAMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileMPAMax"]);
                    txtTensileMPAActual.Text = "";

                    lblTensileKSIMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMin"]);
                    lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtTensileKSIActual.Text = "";

                    lblYieldMPAMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAMin"]);
                    //lblCMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAMax"]);
                    txtYieldMPAActual.Text = "";

                    lblYieldKSIMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIMin"]);
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIMax"]);
                    txtYieldKSIActual.Text = "";

                    lblElongationMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElongationMin"]);
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtElongationActual.Text = "";

                    lblReductionMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReductionMin"]);
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtReductionActual.Text = "";

                    lblHardnessMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["HardnessMin"]);
                    lblHardnessMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["HardnessMax"]);
                    txtHardnessActual.Text = "";


                    txtImpact1.Text = "";
                    txtImpact2.Text = "";
                    txtImpact3.Text = "";
                    txtImpact4.Text = "";
                    txtImpact5.Text = "";
                    txtImpact6.Text = "";
                    txtTemperatureC.Text = "";
                    txtTemperatureF.Text = "";
                }
                else
                {
                    lblCMin.Text = "";
                    lblCMax.Text = "";
                    txtCActual.Text = "";

                    lblMnMin.Text = "";
                    lblMnMax.Text = "";
                    txtMnActual.Text = "";

                    lblPMin.Text = "";
                    lblPMax.Text = "";
                    txtPActual.Text = "";

                    lblSMin.Text = "";
                    lblSMax.Text = "";
                    txtSActual.Text = "";

                    lblSiMin.Text = "";
                    lblSiMax.Text = "";
                    txtSiActual.Text = "";

                    lblCuMin.Text = "";
                    lblCuMax.Text = "";
                    txtCuActual.Text = "";

                    lblNiMin.Text = "";
                    lblNiMax.Text = "";
                    txtNiActual.Text = "";

                    lblCrMin.Text = "";
                    lblCrMax.Text = "";
                    txtCrActual.Text = "";

                    lblMoMin.Text = "";
                    lblMoMax.Text = "";
                    txtMoActual.Text = "";

                    lblVMin.Text = "";
                    lblVMax.Text = "";
                    txtVActual.Text = "";

                    lblCuNiCrMoVMin.Text = "";
                    lblCuNiCrMoVMax.Text = "";
                    txtCuNiCrMoVActual.Text = "";

                    lblCrMoMin.Text = "";
                    lblCrMoMax.Text = "";
                    txtCrMoActual.Text = "";

                    lblNbMin.Text = "";
                    lblNbMax.Text = "";
                    txtNbActual.Text = "";

                    lblNMin.Text = "";
                    lblNMax.Text = "";
                    txtNActual.Text = "";

                    lblAlMin.Text = "";
                    lblAlMax.Text = "";
                    txtAlActual.Text = "";

                    lblTiMin.Text = "";
                    lblTiMax.Text = "";
                    txtTiActual.Text = "";

                    lblZrMin.Text = "";
                    lblZrMax.Text = "";
                    txtZrActual.Text = "";

                    lblFeMax.Text = "";
                    lblFeMin.Text = "";
                    txtFeActual.Text = "";

                    lblTaMin.Text = "";
                    lblTaMax.Text = "";
                    txtTaActual.Text = "";

                    lblNbTaMin.Text = "";
                    lblNbTaMax.Text = "";
                    txtNbTaActual.Text = "";

                    lblTensileMPAMin.Text = "";
                    TensileMPAMax.Text = "";
                    txtTensileMPAActual.Text = "";

                    lblTensileKSIMin.Text = "";
                    lblTensileKSIMax.Text = "";
                    txtTensileKSIActual.Text = "";

                    lblYieldMPAMin.Text = "";
                    //lblCMin.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldMPAMax"]);
                    txtYieldMPAActual.Text = "";

                    lblYieldKSIMin.Text = "";
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["YieldKSIMax"]);
                    txtYieldKSIActual.Text = "";

                    lblElongationMin.Text = "";
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtElongationActual.Text = "";

                    lblReductionMin.Text = "";
                    //lblTensileKSIMax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TensileKSIMax"]);
                    txtReductionActual.Text = "";

                    lblHardnessMin.Text = "";
                    lblHardnessMax.Text = "";
                    txtHardnessActual.Text = "";


                    txtImpact1.Text = "";
                    txtImpact2.Text = "";
                    txtImpact3.Text = "";
                    txtImpact4.Text = "";
                    txtImpact5.Text = "";
                    txtImpact6.Text = "";
                    txtTemperatureC.Text = "";
                    txtTemperatureF.Text = "";
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Exception from assiging values to heat no values if heat code not exists");
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

        protected void txtCActual_TextChanged(object sender, EventArgs e)
        {
            var cMin = lblCMin.Text;
            var cMax = lblCMax.Text;
            var cActual = txtCActual.Text;

            if (!string.IsNullOrEmpty(cActual))
            {
                if (cMin == "--")
                {
                    if (cMax != "--")
                    {
                        if (Convert.ToDouble(cMax) >= Convert.ToDouble(cActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - C";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (cMax != "--")
                    {
                        if (Convert.ToDouble(cMin) <= Convert.ToDouble(cActual))
                        {
                            if (Convert.ToDouble(cMax) >= Convert.ToDouble(cActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - C";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - C";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(cMin) <= Convert.ToDouble(cActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - C";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtSActual_TextChanged(object sender, EventArgs e)
        {
            var sMin = lblSMin.Text;
            var sMax = lblSMax.Text;
            var sActual = txtSActual.Text;

            if (!string.IsNullOrEmpty(sActual))
            {
                if (sMin == "--")
                {
                    if (sMax != "--")
                    {
                        if (Convert.ToDouble(sMax) >= Convert.ToDouble(sActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - S";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (sMax != "--")
                    {
                        if (Convert.ToDouble(sMin) <= Convert.ToDouble(sActual))
                        {
                            if (Convert.ToDouble(sMax) >= Convert.ToDouble(sActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - S";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - S";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(sMin) <= Convert.ToDouble(sActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - S";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtNiActual_TextChanged(object sender, EventArgs e)
        {
            var niMin = lblNiMin.Text;
            var niMax = lblNiMax.Text;
            var niActual = txtNiActual.Text;

            if (!string.IsNullOrEmpty(niActual))
            {
                if (niMin == "--")
                {
                    if (niMax != "--")
                    {
                        if (Convert.ToDouble(niMax) >= Convert.ToDouble(niActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ni";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (niMax != "--")
                    {
                        if (Convert.ToDouble(niMin) <= Convert.ToDouble(niActual))
                        {
                            if (Convert.ToDouble(niMax) >= Convert.ToDouble(niActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Ni";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ni";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(niMin) <= Convert.ToDouble(niActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ni";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtVActual_TextChanged(object sender, EventArgs e)
        {
            var vMin = lblVMin.Text;
            var vMax = lblVMax.Text;
            var vActual = txtVActual.Text;

            if (!string.IsNullOrEmpty(vActual))
            {
                if (vMin == "--")
                {
                    if (vMax != "--")
                    {
                        if (Convert.ToDouble(vMax) >= Convert.ToDouble(vActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - V";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (vMax != "--")
                    {
                        if (Convert.ToDouble(vMin) <= Convert.ToDouble(vActual))
                        {
                            if (Convert.ToDouble(vMax) >= Convert.ToDouble(vActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - V";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - V";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(vMin) <= Convert.ToDouble(vActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - V";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtNbActual_TextChanged(object sender, EventArgs e)
        {
            var nbMin = lblNbMin.Text;
            var nbMax = lblNbMax.Text;
            var nbActual = txtNbActual.Text;

            if (!string.IsNullOrEmpty(nbActual))
            {
                if (nbMin == "--")
                {
                    if (nbMax != "--")
                    {
                        if (Convert.ToDouble(nbMax) >= Convert.ToDouble(nbActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Nb";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (nbMax != "--")
                    {
                        if (Convert.ToDouble(nbMin) <= Convert.ToDouble(nbActual))
                        {
                            if (Convert.ToDouble(nbMax) >= Convert.ToDouble(nbActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Nb";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Nb";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(nbMin) <= Convert.ToDouble(nbActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Nb";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtTiActual_TextChanged(object sender, EventArgs e)
        {
            var tiMin = lblTiMin.Text;
            var tiMax = lblTiMax.Text;
            var tiActual = txtTiActual.Text;

            if (!string.IsNullOrEmpty(tiActual))
            {
                if (tiMin == "--")
                {
                    if (tiMax != "--")
                    {
                        if (Convert.ToDouble(tiMax) >= Convert.ToDouble(tiActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ti";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (tiMax != "--")
                    {
                        if (Convert.ToDouble(tiMin) <= Convert.ToDouble(tiActual))
                        {
                            if (Convert.ToDouble(tiMax) >= Convert.ToDouble(tiActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Ti";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ti";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(tiMin) <= Convert.ToDouble(tiActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ti";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtTaActual_TextChanged(object sender, EventArgs e)
        {
            var taMin = lblTaMin.Text;
            var taMax = lblTaMax.Text;
            var taActual = txtTaActual.Text;

            if (!string.IsNullOrEmpty(taActual))
            {
                if (taMin == "--")
                {
                    if (taMax != "--")
                    {
                        if (Convert.ToDouble(taMax) >= Convert.ToDouble(taActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ta";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (taMax != "--")
                    {
                        if (Convert.ToDouble(taMin) <= Convert.ToDouble(taActual))
                        {
                            if (Convert.ToDouble(taMax) >= Convert.ToDouble(taActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Ta";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ta";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(taMin) <= Convert.ToDouble(taActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ta";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtTensileKSIActual_TextChanged(object sender, EventArgs e)
        {
            var TensileKSIMin = lblTensileKSIMin.Text;
            var TensileKSIMax = lblTensileKSIMax.Text;
            var TensileKSIActual = txtTensileKSIActual.Text;

            if (!string.IsNullOrEmpty(TensileKSIActual))
            {
                if (TensileKSIMin == "--")
                {
                    if (TensileKSIMax != "--")
                    {
                        if (Convert.ToDouble(TensileKSIMax) >= Convert.ToDouble(TensileKSIActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - TensileKSI";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (TensileKSIMax != "--")
                    {
                        if (Convert.ToDouble(TensileKSIMin) <= Convert.ToDouble(TensileKSIActual))
                        {
                            if (Convert.ToDouble(TensileKSIMax) >= Convert.ToDouble(TensileKSIActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - TensileKSI";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - TensileKSI";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(TensileKSIMin) <= Convert.ToDouble(TensileKSIActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - TensileKSI";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtElongationActual_TextChanged(object sender, EventArgs e)
        {
            var ElongationMin = lblElongationMin.Text;
            var ElongationMax = lblElongationMax.Text;
            var ElongationActual = txtElongationActual.Text;

            if (!string.IsNullOrEmpty(ElongationActual))
            {
                if (ElongationMin == "--")
                {
                    if (ElongationMax != "--")
                    {
                        if (Convert.ToDouble(ElongationMax) >= Convert.ToDouble(ElongationActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Elongation";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (ElongationMax != "--" && !string.IsNullOrEmpty(ElongationMax))
                    {
                        if (Convert.ToDouble(ElongationMin) <= Convert.ToDouble(ElongationActual))
                        {
                            if (Convert.ToDouble(ElongationMax) >= Convert.ToDouble(ElongationActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Elongation";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Elongation";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(ElongationMin) <= Convert.ToDouble(ElongationActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Elongation";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtMnActual_TextChanged(object sender, EventArgs e)
        {
            var MnMin = lblMnMin.Text;
            var MnMax = lblMnMax.Text;
            var MnActual = txtMnActual.Text;

            if (!string.IsNullOrEmpty(MnActual))
            {
                if (MnMin == "--")
                {
                    if (MnMax != "--")
                    {
                        if (Convert.ToDouble(MnMax) >= Convert.ToDouble(MnActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Mn";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (MnMax != "--")
                    {
                        if (Convert.ToDouble(MnMin) <= Convert.ToDouble(MnActual))
                        {
                            if (Convert.ToDouble(MnMax) >= Convert.ToDouble(MnActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Mn";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Mn";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(MnMin) <= Convert.ToDouble(MnActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Mn";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtSiActual_TextChanged(object sender, EventArgs e)
        {
            var siMin = lblSiMin.Text;
            var siMax = lblSiMax.Text;
            var siActual = txtSiActual.Text;

            if (!string.IsNullOrEmpty(siActual))
            {
                if (siMin == "--")
                {
                    if (siMax != "--")
                    {
                        if (Convert.ToDouble(siMax) >= Convert.ToDouble(siActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Si";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (siMax != "--")
                    {
                        if (Convert.ToDouble(siMin) <= Convert.ToDouble(siActual))
                        {
                            if (Convert.ToDouble(siMax) >= Convert.ToDouble(siActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Si";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Si";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(siMin) <= Convert.ToDouble(siActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Si";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtCrActual_TextChanged(object sender, EventArgs e)
        {
            var crMin = lblCrMin.Text;
            var crMax = lblCrMax.Text;
            var crActual = txtCrActual.Text;

            if (!string.IsNullOrEmpty(crActual))
            {
                if (crMin == "--")
                {
                    if (crMax != "--")
                    {
                        if (Convert.ToDouble(crMax) >= Convert.ToDouble(crActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Cr";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (crMax != "--")
                    {
                        if (Convert.ToDouble(crMin) <= Convert.ToDouble(crActual))
                        {
                            if (Convert.ToDouble(crMax) >= Convert.ToDouble(crActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Cr";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Cr";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(crMin) <= Convert.ToDouble(crActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Cr";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtNActual_TextChanged(object sender, EventArgs e)
        {
            var nMin = lblNMin.Text;
            var nMax = lblNMax.Text;
            var nActual = txtNActual.Text;

            if (!string.IsNullOrEmpty(nActual))
            {
                if (nMin == "--")
                {
                    if (nMax != "--")
                    {
                        if (Convert.ToDouble(nMax) >= Convert.ToDouble(nActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - N";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (nMax != "--")
                    {
                        if (Convert.ToDouble(nMin) <= Convert.ToDouble(nActual))
                        {
                            if (Convert.ToDouble(nMax) >= Convert.ToDouble(nActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - N";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - N";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(nMin) <= Convert.ToDouble(nActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - N";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtZrActual_TextChanged(object sender, EventArgs e)
        {
            var ZRMin = lblZrMin.Text;
            var ZRMax = lblZrMax.Text;
            var ZRActual = txtZrActual.Text;

            if (!string.IsNullOrEmpty(ZRActual))
            {
                if (ZRMin == "--")
                {
                    if (ZRMax != "--")
                    {
                        if (Convert.ToDouble(ZRMax) >= Convert.ToDouble(ZRActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Zr";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (ZRMax != "--")
                    {
                        if (Convert.ToDouble(ZRMin) <= Convert.ToDouble(ZRActual))
                        {
                            if (Convert.ToDouble(ZRMax) >= Convert.ToDouble(ZRActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Zr";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Zr";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(ZRMin) <= Convert.ToDouble(ZRActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Zr";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtYieldMPAActual_TextChanged(object sender, EventArgs e)
        {
            var YieldMPAMin = lblYieldMPAMin.Text;
            var YieldMPAMax = lblYieldMPAMax.Text;
            var YieldMPAActual = txtYieldMPAActual.Text;

            if (!string.IsNullOrEmpty(YieldMPAActual))
            {
                if (YieldMPAMin == "--")
                {
                    if (YieldMPAMax != "--")
                    {
                        if (Convert.ToDouble(YieldMPAMax) >= Convert.ToDouble(YieldMPAActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - YieldMPA";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (YieldMPAMax != "--" && !string.IsNullOrEmpty(YieldMPAMax))
                    {
                        if (Convert.ToDouble(YieldMPAMin) <= Convert.ToDouble(YieldMPAActual))
                        {
                            if (Convert.ToDouble(YieldMPAMax) >= Convert.ToDouble(YieldMPAActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - YieldMPA";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - YieldMPA";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(YieldMPAMin) <= Convert.ToDouble(YieldMPAActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - YieldMPA";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtReductionActual_TextChanged(object sender, EventArgs e)
        {
            var ReductionMin = lblReductionMin.Text;
            var ReductionMax = lblReductionMax.Text;
            var ReductionActual = txtReductionActual.Text;

            if (!string.IsNullOrEmpty(ReductionActual))
            {
                if (ReductionMin == "--")
                {
                    if (ReductionMax != "--")
                    {
                        if (Convert.ToDouble(ReductionMax) >= Convert.ToDouble(ReductionActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Reduction";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (ReductionMax != "--" && !string.IsNullOrEmpty(ReductionMax))
                    {
                        if (Convert.ToDouble(ReductionMin) <= Convert.ToDouble(ReductionActual))
                        {
                            if (Convert.ToDouble(ReductionMax) >= Convert.ToDouble(ReductionActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Reduction";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Reduction";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(ReductionMin) <= Convert.ToDouble(ReductionActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Reduction";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtHardnessActual_TextChanged(object sender, EventArgs e)
        {
            var HardnessMin = lblHardnessMin.Text;
            var HardnessMax = lblHardnessMax.Text;
            var HardnessActual = txtHardnessActual.Text;

            if (!string.IsNullOrEmpty(HardnessActual))
            {
                if (HardnessMin == "--")
                {
                    if (HardnessMax != "--")
                    {
                        if (Convert.ToDouble(HardnessMax) >= Convert.ToDouble(HardnessActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Hardness";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (HardnessMax != "--")
                    {
                        if (Convert.ToDouble(HardnessMin) <= Convert.ToDouble(HardnessActual))
                        {
                            if (Convert.ToDouble(HardnessMax) >= Convert.ToDouble(HardnessActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Hardness";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Hardness";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(HardnessMin) <= Convert.ToDouble(HardnessActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Hardness";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
        }

        protected void txtYieldKSIActual_TextChanged(object sender, EventArgs e)
        {
            var YieldKSIMin = lblYieldKSIMin.Text;
            var YieldKSIMax = lblYieldKSIMax.Text;
            var YieldKSIActual = txtYieldKSIActual.Text;

            if (!string.IsNullOrEmpty(YieldKSIActual))
            {
                if (YieldKSIMin == "--")
                {
                    if (YieldKSIMax != "--")
                    {
                        if (Convert.ToDouble(YieldKSIMax) >= Convert.ToDouble(YieldKSIActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - YieldKSI";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (YieldKSIMax != "--" && !string.IsNullOrEmpty(YieldKSIMax))
                    {
                        if (Convert.ToDouble(YieldKSIMin) <= Convert.ToDouble(YieldKSIActual))
                        {
                            if (Convert.ToDouble(YieldKSIMax) >= Convert.ToDouble(YieldKSIActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - YieldKSI";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - YieldKSI";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(YieldKSIMin) <= Convert.ToDouble(YieldKSIActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - YieldKSI";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtTensileMPAActual_TextChanged(object sender, EventArgs e)
        {
            var TensileMPAMin = lblTensileMPAMin.Text;
            var tensileMPAMax = TensileMPAMax.Text;
            var TensileMPAActual = txtTensileMPAActual.Text;

            if (!string.IsNullOrEmpty(TensileMPAActual))
            {
                if (TensileMPAMin == "--")
                {
                    if (tensileMPAMax != "--")
                    {
                        if (Convert.ToDouble(tensileMPAMax) >= Convert.ToDouble(TensileMPAActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - TensileMPA";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (tensileMPAMax != "--")
                    {
                        if (Convert.ToDouble(TensileMPAMin) <= Convert.ToDouble(TensileMPAActual))
                        {
                            if (Convert.ToDouble(tensileMPAMax) >= Convert.ToDouble(TensileMPAActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - TensileMPA";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - TensileMPA";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(TensileMPAMin) <= Convert.ToDouble(TensileMPAActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - TensileMPA";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtFeActual_TextChanged(object sender, EventArgs e)
        {
            var feMin = lblFeMin.Text;
            var feMax = lblFeMax.Text;
            var feActual = txtFeActual.Text;

            if (!string.IsNullOrEmpty(feActual))
            {
                if (feMin == "--")
                {
                    if (feMax != "--")
                    {
                        if (Convert.ToDouble(feMax) >= Convert.ToDouble(feActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Fe";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (feMax != "--")
                    {
                        if (Convert.ToDouble(feMin) <= Convert.ToDouble(feActual))
                        {
                            if (Convert.ToDouble(feMax) >= Convert.ToDouble(feActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Fe";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Fe";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(feMin) <= Convert.ToDouble(feActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Fe";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtAlActual_TextChanged(object sender, EventArgs e)
        {
            var aiMin = lblAlMin.Text;
            var aiMax = lblAlMinAlMax.Text;
            var aiActual = txtAlActual.Text;

            if (!string.IsNullOrEmpty(aiActual))
            {
                if (aiMin == "--")
                {
                    if (aiMax != "--")
                    {
                        if (Convert.ToDouble(aiMax) >= Convert.ToDouble(aiActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ai";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (aiMax != "--")
                    {
                        if (Convert.ToDouble(aiMin) <= Convert.ToDouble(aiActual))
                        {
                            if (Convert.ToDouble(aiMax) >= Convert.ToDouble(aiActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Ai";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ai";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(aiMin) <= Convert.ToDouble(aiActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Ai";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtMoActual_TextChanged(object sender, EventArgs e)
        {
            var moMin = lblMoMin.Text;
            var moMax = lblMoMax.Text;
            var moActual = txtMoActual.Text;

            if (!string.IsNullOrEmpty(moActual))
            {
                if (moMin == "--")
                {
                    if (moMax != "--")
                    {
                        if (Convert.ToDouble(moMax) >= Convert.ToDouble(moActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Mo";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (moMax != "--")
                    {
                        if (Convert.ToDouble(moMin) <= Convert.ToDouble(moActual))
                        {
                            if (Convert.ToDouble(moMax) >= Convert.ToDouble(moActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Mo";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Mo";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(moMin) <= Convert.ToDouble(moActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Mo";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtCuActual_TextChanged(object sender, EventArgs e)
        {
            var CuMin = lblCuMin.Text;
            var CuMax = lblCuMax.Text;
            var CuActual = txtCuActual.Text;

            if (!string.IsNullOrEmpty(CuActual))
            {
                if (CuMin == "--")
                {
                    if (CuMax != "--")
                    {
                        if (Convert.ToDouble(CuMax) >= Convert.ToDouble(CuActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Cu";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (CuMax != "--")
                    {
                        if (Convert.ToDouble(CuMin) <= Convert.ToDouble(CuActual))
                        {
                            if (Convert.ToDouble(CuMax) >= Convert.ToDouble(CuActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - Cu";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Cu";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(CuMin) <= Convert.ToDouble(CuActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - Cu";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }

        protected void txtPActual_TextChanged(object sender, EventArgs e)
        {
            var pMin = lblPMin.Text;
            var pMax = lblPMax.Text;
            var pActual = txtPActual.Text;

            if (!string.IsNullOrEmpty(pActual))
            {
                if (pMin == "--")
                {
                    if (pMax != "--")
                    {
                        if (Convert.ToDouble(pMax) >= Convert.ToDouble(pActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - P";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (pMax != "--")
                    {
                        if (Convert.ToDouble(pMin) <= Convert.ToDouble(pActual))
                        {
                            if (Convert.ToDouble(pMax) >= Convert.ToDouble(pActual))
                            {
                                Panel2.Visible = false;
                                TextArea1.Value = string.Empty;

                                return;
                            }
                            else
                            {
                                TextArea1.Value = "Out of Range - P";
                                Panel2.Visible = true;
                            }
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - P";
                            Panel2.Visible = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(pMin) <= Convert.ToDouble(pActual))
                        {
                            Panel2.Visible = false;
                            TextArea1.Value = string.Empty;

                            return;
                        }
                        else
                        {
                            TextArea1.Value = "Out of Range - P";
                            Panel2.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Panel2.Visible = false;
                TextArea1.Value = string.Empty;

                return;
            }
        }
    }
}