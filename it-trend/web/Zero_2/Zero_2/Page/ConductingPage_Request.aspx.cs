using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class ConductingPage_Request : System.Web.UI.Page
    {
        public localhost.Validation emp = new localhost.Validation();
        protected void Page_Load(object sender, EventArgs e)
        {            
            GridView2.DataSource = emp.WantRice();
            GridView2.DataBind();            
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["commissionpage"] = "ConductingPage_Request";
            Response.Redirect(@"~\Page\Approve.aspx");            
        }
    }
}