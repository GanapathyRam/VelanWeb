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

public partial class UserControls_ucNotes : System.Web.UI.UserControl
{
    private string mName;
    private string mNotes;

    public string ControlTitle
    {
        get { return mName; }
        set { mName = value; }
    }

    public string Notes
    {
        get { return mNotes; }
        set { mNotes = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblName.Text = this.mName;
    }
    
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        this.Notes = txtNotes.Text;
        this.Visible = false;
    }

    protected void imgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.Notes = String.Empty;
        this.Visible = false;
    }
}