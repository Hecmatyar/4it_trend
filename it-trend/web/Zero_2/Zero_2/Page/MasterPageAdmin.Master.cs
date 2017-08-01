using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class MasterPageAdmin : System.Web.UI.MasterPage
    {
        public int pageload = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Exit_Click(object sender, EventArgs e)
        {
            pageload = 0;
            Session["Pageload"] = pageload;
            //Response.Redirect(Request.Url.AbsolutePath);
            Response.Redirect(@"~\Page\ValidationPage.aspx");            
        }
    }
}