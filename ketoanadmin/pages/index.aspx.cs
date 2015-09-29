using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_index : System.Web.UI.Page
{
    private ketoanadminDataContext db = new ketoanadminDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadCount();
        }
    }
    private void LoadCount()
    {
        var list = db.Customers.ToList();
        if(list != null && list.Count>0)
        {
            lbCountCustomer.Text = list.Count.ToString();
        } 
        var list2 = db.CustomerSetups.ToList();
        if (list2 != null && list2.Count > 0)
        {
            lbCountCustomerSetups.Text = list2.Count.ToString();
        } 
        var list3 = db.Users.ToList();
        if (list3 != null && list3.Count > 0)
        {
            lbCountUser.Text = list3.Count.ToString();
        }
    }
}