using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master_Index : System.Web.UI.MasterPage
{
    public static int UserID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("~/pages/login.aspx");
        }
        UserID = ((User)Session["user"]).ID;
    }
}
