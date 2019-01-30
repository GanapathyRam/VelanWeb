using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VV
{
    public partial class VV : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkBtnMyProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
        }
    }
}