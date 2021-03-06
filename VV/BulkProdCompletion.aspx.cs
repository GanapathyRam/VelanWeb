﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Libraries.Entity;
using System.Linq;

namespace VV
{
    public partial class BulkProdCompletion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GetRemarks();
        }

        /// <summary>
        /// Do the Bulk Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DBUtil _dbObj = new DBUtil();
            bool isHeatNoControl = false;
            string SerialNo = string.Empty;
            string BodyHeatNo = string.Empty;

            try
            {
                int FromSerialNo = Int32.Parse(txtFromSerialNo.Text.Trim());
                int ToSerialNo = Int32.Parse(txtToSerialNo.Text.Trim());
                String Prefix = txtPrefix.Text.Trim();

                if (!Prefix.EndsWith("-"))
                    Prefix = Prefix + "-";

                // Create the list to store.
                List<String> YrStrList = new List<string>();

                // Loop through each item.
                for (int i = FromSerialNo; i <= ToSerialNo; i++)
                {
                    // If the item is selected, add the value to the list.
                    YrStrList.Add(Prefix + i.ToString());
                }

                // Join the string together using the ; delimiter.
                String BulkSerialNo = String.Join(",", YrStrList.ToArray());

                ds = _dbObj.FetchHeatNoControl();
                DataSet ds1 = _dbObj.FetchHeatNoControlAndSerialNoFromProdPrderNo(txtProdOrderNo.Text.Trim());

                if (ds.Tables.Count > 0)
                {
                    isHeatNoControl = Convert.ToBoolean(ds.Tables[0].Rows[0]["HeatNoControl"].ToString());
                }

                if (isHeatNoControl && drpDwnPrdRem.SelectedItem.Text.Trim() == "Under TPI")
                {
                    if (ds1 != null && ds1.Tables.Count > 0)
                    {
                        SerialNo = Convert.ToString(ds1.Tables[0].Rows[0]["SerialNo"].ToString());
                        BodyHeatNo = Convert.ToString(ds1.Tables[0].Rows[0]["BodyHeatNo"].ToString());

                        //int rowCount = ds1.Tables[0].AsEnumerable().Where(x =>  x.IsNull("BodyHeatNo") || x.ToString() != string.Empty).CopyToDataTable().Rows.Count;

                        //bool contains = ds1.Tables[0].AsEnumerable().Any(row => string.IsNullOrEmpty(test) == row.Field<String>("BodyHeatNo"));

                        bool rowCount = HasNull(ds1.Tables[0]);
                        
                        if (!rowCount)
                        {
                            _dbObj.BulkUpdateProdCompletion(txtProdOrderNo.Text.Trim(), BulkSerialNo.Trim(), txtProdCommitedDate.Text.Trim(), txtCompDate.Text.Trim(), drpDwnPrdRem.SelectedItem.Text.Trim());

                            lblResult.Text = "Updated Successfully";
                            btnSubmit.Enabled = false;
                        }
                        else
                        {
                            lblResult.Text = "Selected row does not have body heat number to proceed further.";
                            btnSubmit.Enabled = false;
                        }
                    }
                }
                else
                {
                    _dbObj.BulkUpdateProdCompletion(txtProdOrderNo.Text.Trim(), BulkSerialNo.Trim(), txtProdCommitedDate.Text.Trim(), txtCompDate.Text.Trim(), drpDwnPrdRem.SelectedItem.Text.Trim());

                    lblResult.Text = "Updated Successfully";
                    btnSubmit.Enabled = false;
                }

                //_dbObj.BulkUpdateProdCompletion(txtProdOrderNo.Text.Trim(), BulkSerialNo.Trim(), txtProdCommitedDate.Text.Trim(), txtCompDate.Text.Trim(), drpDwnPrdRem.SelectedItem.Text.Trim());
                //lblResult.Text = "Updated Successfully";
                //btnSubmit.Enabled = false;

            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + "Bulk Update : btnSubmit_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        /// <summary>
        /// Load the Remarks DropDown
        /// </summary>
        public void GetRemarks()
        {
            try
            {
                DataTable tblRemarks = new DataTable();

                DataColumn column;
                DataRow row;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "remarkdesc";
                tblRemarks.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "remarkid";
                tblRemarks.Columns.Add(column);

                string[] ddlValues = ConfigurationManager.AppSettings["ProdRemarks"].ToString().Split(',');

                for (int i = 0; i <= ddlValues.Length - 1; i++)
                {
                    row = tblRemarks.NewRow();
                    row["remarkid"] = ddlValues[i].Split('-')[0].Trim();
                    row["remarkdesc"] = ddlValues[i].Split('-')[1].Trim();
                    tblRemarks.Rows.Add(row);
                }

                DataSet dsRemarks = new DataSet();
                dsRemarks.Tables.Add(tblRemarks);

                drpDwnPrdRem.DataTextField = dsRemarks.Tables[0].Columns["remarkdesc"].ToString();
                drpDwnPrdRem.DataValueField = dsRemarks.Tables[0].Columns["remarkid"].ToString();

                drpDwnPrdRem.DataSource = dsRemarks.Tables[0];
                drpDwnPrdRem.DataBind();

                // return dsRemarks;
            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + " : GetRemarks : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }

        private bool HasNull(DataTable table)
        {
            bool isExist = false;

            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                var bodyheatno = Convert.ToString(table.Rows[i]["BodyHeatNo"]).ToString();

                if (string.IsNullOrEmpty(bodyheatno))
                {
                    isExist = true;
                }
            }

            return isExist;
        }
    }
}