using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_delete_user : System.Web.UI.Page
{
    private UserRepo _UserRepo = new UserRepo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadInfo();
        }
    }
    private void LoadInfo()
    {
        int id = Utils.CIntDef(Request.QueryString["id"], 0);
        _UserRepo = new UserRepo();
        User item = _UserRepo.GetById(id);
        if (item != null)
        {
            lbTen.Text = item.Username;
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (!chkChacchan.Checked)
        {
            lbMessage.Text = "Bạn chưa đồng ý chắc chắn xóa!";
            return;
        }
        int id = Utils.CIntDef(Request.QueryString["id"], 0);
        _UserRepo = new UserRepo();
        _UserRepo.Remove(id);
        Response.Redirect("~/pages/users.aspx");
    }
    public string formatDate(object date)
    {
        return string.Format("{0:dd/MM/yyyy}", date);
    }
}