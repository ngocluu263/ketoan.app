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
        if (!IsPostBack)
        {
            LoadInfo();
        }
    }
    private void LoadInfo()
    {
        int id = Utils.CIntDef(Request.QueryString["id"], 0);
        _CustomerRepo = new CustomerRepo();
        Customer item = _CustomerRepo.GetById(id);
        if (item != null)
        {
            lbTen.Text = item.Fullname;
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
        _CustomerRepo = new CustomerRepo();        
        _CustomerRepo.Remove(id);
        Response.Redirect("~/pages/customers.aspx");
    }
    public string formatDate(object date)
    {
        return string.Format("{0:dd/MM/yyyy}", date);
    }
}