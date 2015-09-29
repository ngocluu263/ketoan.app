using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_users : System.Web.UI.Page
{
    private UserRepo _UserRepo = new UserRepo();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        _UserRepo = new UserRepo();
        rptList.DataSource = _UserRepo.GetAll();
        rptList.DataBind();
    }
    public string getLink(object id)
    {
        return "user.aspx?id=" + Utils.CIntDef(id, 0);
    }
    public string getLinkDelete(object id)
    {
        return "delete_user.aspx?id=" + Utils.CIntDef(id, 0);
    }
}