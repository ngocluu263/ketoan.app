using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_login : System.Web.UI.Page
{
    private UserRepo _UserRepo = new UserRepo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["status"] == "logout")
                Session.Abandon();            
        }
    }
    protected void lbkLogin_Click(object sender, EventArgs e)
    {
        var item = _UserRepo.GetByUsername(txtUsername.Value);
        if (item != null)
        {
            string password = Security.Encrypt(txtPassword.Value, item.Saft);
            if (item.Password == password)
            {
                if (Utils.CBoolDef(item.IsActive, false))
                {
                    Session["user"] = item;
                    Response.Redirect("~/pages/Index.aspx");
                }
                else
                {
                    lbMessage.Text = "Tài khoản này chưa được kích hoạt!";
                }
            }
            else
            {
                lbMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";//sai pass
            }
        }
        else
        {
            lbMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";//sai user
        }
    }
}