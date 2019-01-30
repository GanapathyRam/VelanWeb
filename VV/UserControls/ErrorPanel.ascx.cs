using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControls_ErrorPanel : System.Web.UI.UserControl
{
    public bool SetVisible = false;

    public void AddMessage(string messageText, int errorType)
    {
        this.Visible = true;
        bltdList.Items.Add(messageText);
        this.lblErrorTitle.ForeColor = System.Drawing.Color.White;

        switch (errorType)
        {
            case 1:
                this.lblErrorTitle.Text = "Error";
                this.lblErrorTitle.BackColor = System.Drawing.Color.Firebrick;
                bltdList.ForeColor = System.Drawing.Color.Firebrick;
                break;
            case 2:
                this.lblErrorTitle.Text = "Information";
                this.lblErrorTitle.BackColor = System.Drawing.Color.DarkOliveGreen;
                bltdList.ForeColor = System.Drawing.Color.DarkOliveGreen;
                break;
            case 3:
                this.lblErrorTitle.Text = "Warning";
                this.lblErrorTitle.BackColor = System.Drawing.Color.RoyalBlue;
                bltdList.ForeColor = System.Drawing.Color.RoyalBlue;
                break;
            default:
                break;
        } 
    }

    public void ClearMessage()
    {
        bltdList.Items.Clear();
        this.Visible = false;
    }
}
