using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_user : System.Web.UI.Page
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
            txtTendangnhap.Disabled = true;
            txtTendangnhap.Value = item.Username;
            ddlKichhoat.SelectedIndex = Utils.CBoolDef(item.IsActive, false) ? 0 : 1;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = Utils.CIntDef(Request.QueryString["id"], 0);
        _UserRepo = new UserRepo();
        User item = _UserRepo.GetById(id);
        if (item != null)
        {
            //item.Username = txtTendangnhap.Value;
            string saft = Security.CreateSalt();
            string password = Security.Encrypt(txtMatkhau.Value, saft);
            item.Saft = saft;
            item.Password = password;
            item.IsActive = (ddlKichhoat.SelectedItem.Value == "1") ? true : false;
            _UserRepo.Update(item);
        }
        else
        {
            item = _UserRepo.GetByUsername(txtTendangnhap.Value);
            if (item != null)
            {
                lbMessage.Text = "Tên đăng nhập này đã tồn tại!";
                return;
            }
            item = new User();
            item.Username = txtTendangnhap.Value;
            string saft = Security.CreateSalt();
            string password = Security.Encrypt(txtMatkhau.Value, saft);
            item.Saft = saft;
            item.Password = password;
            item.IsActive = (ddlKichhoat.SelectedItem.Value == "1") ? true : false;
            _UserRepo.Create(item);
        }
        Response.Redirect("~/pages/users.aspx");
    }
    public string formatDate(object date)
    {
        return string.Format("{0:dd/MM/yyyy}", date);
    }
}