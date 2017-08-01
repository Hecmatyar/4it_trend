using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class DocPage : System.Web.UI.Page
    {
        public int pageload;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            try { pageload = (int)Session["Pageload"]; }
            catch (NullReferenceException ex)
            {
                pageload = 0;
            }
            if (pageload == 1) MasterPageFile = "~/Page/MasterPageAdmin.master";
            else if (pageload == 2) MasterPageFile = "~/Page/MasterPageEmployees.master";
            else MasterPageFile = "~/Page/MasterPage.master";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}