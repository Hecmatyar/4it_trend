using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2
{
    public partial class Default : System.Web.UI.Page
    {
        public localhost.Validation emp = new localhost.Validation();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    GridView1.DataSource = emp.Employees();
        //    GridView1.DataBind();
        //}
    }
}