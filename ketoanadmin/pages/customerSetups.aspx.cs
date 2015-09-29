using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_customerSetups : System.Web.UI.Page
{
    private CustomerSetupRepo _CustomerSetupRepo = new CustomerSetupRepo();
    private CustomerRepo _CustomerRepo = new CustomerRepo();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        _CustomerSetupRepo = new CustomerSetupRepo();
        rptList.DataSource = _CustomerSetupRepo.GetAll();
        rptList.DataBind();
    }
    public string getCustomername(object cusid)
    {
        int id = Utils.CIntDef(cusid, 0);
        Customer item = _CustomerRepo.GetById(id);
        if(item != null)
        {
            return item.Fullname;
        }
        return "";
    }
    public string formatDate(object date)
    {
        return string.Format("{0:dd/MM/yyyy}", date);
    }
}