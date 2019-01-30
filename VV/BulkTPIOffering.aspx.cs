using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Libraries.Entity;

namespace VV
{
    public partial class BulkTPIOffering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Do the Bulk Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
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

                DBUtil _dbObj = new DBUtil();
                _dbObj.BulkUpdateTPIOffering(txtProdOrderNo.Text.Trim(), BulkSerialNo.Trim(), txtTPIOfferDate.Text.Trim(), txtRemarks.Text.Trim(), txtIRNCompDate.Text.Trim());

                lblResult.Text = "Updated Successfully";
                btnSubmit.Enabled = false;

            }
            catch (Exception ex)
            {
                Logger.Write(this.GetType().ToString() + "Bulk Update : btnSubmit_Click : " + " : " + DateTime.Now + " : " + ex.Message.ToString(), Category.General, Priority.Highest);
                throw ex;
            }
        }
    }
}