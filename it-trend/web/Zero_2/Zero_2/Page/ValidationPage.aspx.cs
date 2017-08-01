using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class ValidationPage : System.Web.UI.Page
    {
        public localhost.Validation emp = new localhost.Validation();
        public int pageload;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string date1 = "Every_validation_AP";
                string date2 = "Every_validation_ES";
                Label8.Text = emp.Date_Validation(date1);
                Label9.Text = emp.Date_Validation(date2);
            }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            try { pageload = (int)Session["Pageload"]; }
            catch (NullReferenceException ex)
            {
                pageload = 0;
            }
            if (pageload==1) MasterPageFile = "~/Page/MasterPageAdmin.master";
            else if (pageload == 2) MasterPageFile = "~/Page/MasterPageEmployees.master";
            else MasterPageFile = "~/Page/MasterPage.master";
        }
    }
}