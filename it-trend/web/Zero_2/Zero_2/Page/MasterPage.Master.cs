using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public int pageload = 0;
        public localhost.Validation emp = new localhost.Validation();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.7.2.min.js",

            });
        }     
        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (input_password.Value != "" && input_login.Value!="")
            {
                if(emp.Authentification(input_login.Value, input_password.Value, ref pageload))
                {                   
                    Session["Pageload"] = pageload;
                    Session["login"] = input_login.Value;
                    Response.Redirect(Request.Url.AbsolutePath);
                } 
            }
        }
    }
}