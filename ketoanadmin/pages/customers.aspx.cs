using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_customers : System.Web.UI.Page
{
    private CustomerRepo _CustomerRepo = new CustomerRepo();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        _CustomerRepo = new CustomerRepo();
        rptList.DataSource = _CustomerRepo.GetAll();
        rptList.DataBind();
    }
    public string getLink(object id)
    {
        return "customer.aspx?id=" + Utils.CIntDef(id, 0);
    }
    public string getLinkDelete(object id)
    {
        return "delete_customer.aspx?id=" + Utils.CIntDef(id, 0);
    }
    public string formatDate(object date)
    {
        return string.Format("{0:dd/MM/yyyy}", date);
    }
}