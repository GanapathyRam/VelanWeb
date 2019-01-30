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

using Libraries.Entity;
using Libraries.Manager;

public partial class AddressControl : System.Web.UI.UserControl
{
    protected String _XRefenceType;
    protected String _XRefenceId;
    protected DateTime _createdDate = new DateTime();
    protected String _createdBy;
    protected DateTime _updatedDate = new DateTime();
    protected String _updatedBy;

    public String _AddressFor;


    public String AddressFor
    {

        get { return _AddressFor; }
        set { _AddressFor = value; }

    }

    public String XReferenceType
    {

        get { return _XRefenceType; }
        set { _XRefenceType = value; }

    }

    public String XReferenceId
    {

        get { return _XRefenceId; }
        set { _XRefenceId = value; }

    }

    public DateTime CreatedDate
    {

        get { return _createdDate; }
        set { _createdDate = value; }

    }

    public String CreatedBy
    {

        get { return _createdBy; }
        set { _createdBy = value; }

    }

    public DateTime UpdatedDate
    {

        get { return _updatedDate; }
        set { _updatedDate = value; }

    }

    public String UpdatedBy
    {

        get { return _updatedBy; }
        set { _updatedBy = value; }

    }

    public String AddressLine1
    {
        get { return txtAddr1.Text; }
        set { txtAddr1.Text = value; }
    }

    public String AddressLine2
    {
        get { return txtAddr2.Text; }
        set { txtAddr2.Text = value; }
    }
    public String AddressLine3
    {
        get { return txtAddr3.Text; }
        set { txtAddr3.Text = value; }
    }

    public String AddressCity
    {
        get { return txtCity.Text; }
        set { txtCity.Text = value; }
    }
    public String AddressState
    {
        get { return txtState.Text; }
        set { txtState.Text = value; }
    }
    public String AddressZip
    {
        get { return txtZip.Text; }
        set { txtZip.Text = value; }
    }

    public String AddressCountry
    {
        get { return drpDwCtry.SelectedValue; }
        set { drpDwCtry.SelectedValue = value; }
    }

    public String AddressType
    {
        get { return drpDwAddrType.SelectedValue; }
        set { drpDwAddrType.SelectedValue = value; }
    }




    protected void Page_Load(object sender, EventArgs e)
    {

        Page pg = (Page)this.Page;

        if (!IsPostBack)
        {
            if (_XRefenceId == null)
            {
                switch (_XRefenceType)
                {
                    case "Employee":

                        _XRefenceId = (String)Cache["EmployeeID"];
                        break;

                    case "Client":

                        _XRefenceId = (String)Cache["ClientID"];
                        break;

                    default:
                        break;

                }
            }

            DataSet ds = (DataSet)Cache["GlobalCache"];
            if (ds != null)
            {
                drpDwAddrType.DataSource = ds.Tables["AddressType"];
                drpDwAddrType.DataTextField = ds.Tables["AddressType"].Columns["value"].ToString();
                drpDwAddrType.DataValueField = ds.Tables["AddressType"].Columns["id"].ToString();
                drpDwAddrType.DataBind();

                drpDwCtry.DataSource = ds.Tables["Country"];
                drpDwCtry.DataTextField = ds.Tables["Country"].Columns["value"].ToString();
                drpDwCtry.DataValueField = ds.Tables["Country"].Columns["id"].ToString();
                drpDwCtry.DataBind();

            }

            Address addrObj = new Address();
            AddressManager addrMgr = new AddressManager();

            DataSet resultSet = new DataSet();
            addrObj.XReferenceID = _XRefenceId;
            addrObj.XReferenceType = _XRefenceType;
            addrObj.AddressType = drpDwAddrType.SelectedValue.ToString();
            resultSet = addrMgr.SearchAddress(addrObj);

            if (resultSet != null & resultSet.Tables[0].Rows.Count > 0)
            {
                string addressType = resultSet.Tables[0].Rows[0]["AddressType"].ToString();
                string address1 = resultSet.Tables[0].Rows[0]["Address1"].ToString();
                string address2 = resultSet.Tables[0].Rows[0]["Address2"].ToString();
                string address3 = resultSet.Tables[0].Rows[0]["Address3"].ToString();
                string city = resultSet.Tables[0].Rows[0]["City"].ToString();
                string State = resultSet.Tables[0].Rows[0]["State"].ToString();
                string country = resultSet.Tables[0].Rows[0]["Country"].ToString();
                string zip = resultSet.Tables[0].Rows[0]["Zip"].ToString();

                txtAddr1.Text = address1;
                txtAddr2.Text = address2;
                txtAddr3.Text = address3;
                txtCity.Text = city;
                drpDwCtry.Text = country;
                txtState.Text = State;
                txtZip.Text = zip;
                drpDwAddrType.Text = addressType;

            }
            else
            {
                txtAddr1.Text = "";
                txtAddr2.Text = "";
                txtAddr3.Text = "";
                txtCity.Text = "";
                drpDwCtry.SelectedIndex = 0;
                txtState.Text = "";
                txtZip.Text = "";
            }
       }
    }


    protected void buttonAddClick(object sender, EventArgs e)
    {

        Address addrObj = new Address();
        AddressManager addrMgr = new AddressManager();

        addrObj.Address1 = txtAddr1.Text;
        addrObj.Address2 = txtAddr2.Text;
        addrObj.Address3 = txtAddr3.Text;
        addrObj.City = txtCity.Text;
        addrObj.Country = drpDwCtry.SelectedItem.Value;
        addrObj.State = txtState.Text;
        addrObj.PinCode = txtZip.Text;

        if (_XRefenceId == null)
        {
            switch (_XRefenceType)
            {
                case "Employee":

                    _XRefenceId = (String)Cache["EmployeeID"];
                    break;

                case "Client":

                    _XRefenceId = (String)Cache["ClientID"];
                    break;

                default:
                    break;

            }
        }
        addrObj.XReferenceID = _XRefenceId;
        addrObj.XReferenceType = _XRefenceType;
        addrObj.AddressType = drpDwAddrType.SelectedItem.Value;

        try
        {
            DataSet resultSet = new DataSet();
            resultSet = addrMgr.SearchAddress(addrObj);

            if (resultSet != null & resultSet.Tables[0].Rows.Count > 0)
            {
                //Since Record  Exists for the given search Criteria, the record must be updated
                addrMgr.UpdateAddress(addrObj);
                
            }
            else
            {
                //No Record Exists for the given search Criteria. So it must add the record to the table
                addrMgr.AddAddress(addrObj);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        

        DataSet ds = new DataSet();
        ds = addrMgr.SearchAddress(addrObj);
        AddressList.DataSource = ds;
        AddressList.DataBind();
    }

    protected void buttonAddMoreClick(object sender, EventArgs e)
    { 
    }
    protected void buttonCancelClick(object sender, EventArgs e)
    {
        switch (_XRefenceType)
        {
            case "Employee":
                _XRefenceId = (String)Cache["EmployeeID"];
                if(_XRefenceId != null && _XRefenceId != "")
                    Response.Redirect("UpdateEmployee.aspx?BadgeNo=" + _XRefenceId);
                else
                    Response.Redirect("Home.aspx");
                break;
            case "Client":
                _XRefenceId = (String)Cache["ClientID"];
                if (_XRefenceId != null && _XRefenceId != "")
                    Response.Redirect("UpdateClient.aspx?ClNum="+_XRefenceId);
                else
                    Response.Redirect("Home.aspx");
                break;
            default:
                Response.Redirect("Home.aspx");
                break;
        }
    }
    protected void addressTypeChange(object sender, EventArgs e)
    {
        if (_XRefenceId == null)
        {
            switch (_XRefenceType)
            {
                case "Employee":

                    _XRefenceId = (String)Cache["EmployeeID"];
                    break;

                case "Client":

                    _XRefenceId = (String)Cache["ClientID"];
                    break;

                default:
                    break;

            }
        }

        Address addrObj = new Address();
        AddressManager addrMgr = new AddressManager();

        DataSet resultSet = new DataSet();
        addrObj.XReferenceID = _XRefenceId;
        addrObj.XReferenceType = _XRefenceType;
        addrObj.AddressType = drpDwAddrType.SelectedValue.ToString();
        resultSet = addrMgr.SearchAddress(addrObj);

        if (resultSet != null & resultSet.Tables[0].Rows.Count > 0)
        {
            string addressType = resultSet.Tables[0].Rows[0]["AddressType"].ToString();
            string address1 = resultSet.Tables[0].Rows[0]["Address1"].ToString();
            string address2 = resultSet.Tables[0].Rows[0]["Address2"].ToString();
            string address3 = resultSet.Tables[0].Rows[0]["Address3"].ToString();
            string city = resultSet.Tables[0].Rows[0]["City"].ToString();
            string State = resultSet.Tables[0].Rows[0]["State"].ToString();
            string country = resultSet.Tables[0].Rows[0]["Country"].ToString();
            string zip = resultSet.Tables[0].Rows[0]["Zip"].ToString();

            txtAddr1.Text = address1;
            txtAddr2.Text = address2;
            txtAddr3.Text = address3;
            txtCity.Text = city;
            drpDwCtry.Text = country;
            txtState.Text = State;
            txtZip.Text = zip;
            drpDwAddrType.Text = addressType;

        }
        else
        {
            txtAddr1.Text = "";
            txtAddr2.Text = "";
            txtAddr3.Text = "";
            txtCity.Text = "";
            drpDwCtry.SelectedIndex = 0;
            txtState.Text = "";
            txtZip.Text = "";
        }
    }
}
