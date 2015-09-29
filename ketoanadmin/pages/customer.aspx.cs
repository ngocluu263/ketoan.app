using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_customer : System.Web.UI.Page
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
            txtTen.Value = item.Fullname;
            txtDiachi.Value = item.Address;
            lbAppcode.Text = item.Appcode;
            txtSoluong.Value = Utils.CStrDef(item.Appnumber, "");
            ddlKichhoat.SelectedIndex = Utils.CBoolDef(item.IsActive, false) ? 0 : 1;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = Utils.CIntDef(Request.QueryString["id"], 0);
        _CustomerRepo = new CustomerRepo();
        Customer item = _CustomerRepo.GetById(id);
        if (item != null)
        {
            item.Fullname = txtTen.Value;
            item.Address = txtDiachi.Value;
            item.Appcode = lbAppcode.Text;
            item.Appnumber = Utils.CIntDef(txtSoluong.Value, 0);
            item.IsActive = (ddlKichhoat.SelectedItem.Value == "1") ? true : false;
            _CustomerRepo.Update(item);
        }
        else
        {
            item = new Customer();
            item.Fullname = txtTen.Value;
            item.Address = txtDiachi.Value;
            string appcode = CreateAppcode();
            item.Appcode = appcode; 
            item.Appnumber = Utils.CIntDef(txtSoluong.Value, 0);
            item.IsActive = (ddlKichhoat.SelectedItem.Value == "1") ? true : false;
            item.CreatedDate = DateTime.Now;
            _CustomerRepo.Create(item);
        }
        Response.Redirect("~/pages/customers.aspx");
    }
    private string CreateAppcode()
    {
        string appcode = Security.CreateAppcode();
        _CustomerRepo = new CustomerRepo();
        Customer item = _CustomerRepo.GetByAppcode(appcode);
        if (item != null)
            CreateAppcode();
        return appcode;
    }
    public string formatDate(object date)
    {
        return string.Format("{0:dd/MM/yyyy}", date);
    }
}