using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class Employees : System.Web.UI.Page
    {
        System.Drawing.Color mycolor = new System.Drawing.Color();
        public bool pressit = true;
        public bool pressr = true;
        public bool all = true;
        public bool plan = false;
        public bool re = false;
        public bool request = false;
        public bool unplan = false;
        public void allfalse()
        {
            all = false;
            plan = false;
            re = false;
            request = false;
            //unplan = false;
        }
       
        
        protected void Pre_Init(object sender, EventArgs e)
        {
                    
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["Pageload"] == 1)
            {
                if (!Page.IsPostBack)
                {
                    Session["shapestring"] = "";
                    Session["active"] = "all";
                    Session["it"] = true;
                    Session["r"] = true;
                    ProductsListView1.DataSource = emp.Employees(where);
                    ProductsListView1.DataBind();
                }
            }
            else Response.Redirect(@"~\Page\ValidationPage.aspx");
        }
        public localhost.Validation emp = new localhost.Validation();
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //Response.Redirect(@"~\Page\ValidationPage.aspx");
        }
        public string where = "";   
        protected void Search_Click(object sender, EventArgs e)
        {
            where = "";
            if (TextBox1.Text != "")
            {
                where += " and Employees.Surname = N'" + TextBox1.Text + "' ";
            }
            if (TextBox2.Text != "")
            {
                where += " and Employees.Name = N'" + TextBox2.Text + "' ";
            }
            if (TextBox3.Text != "")
            {
                where += " and Employees.Number_workbook like '%" + TextBox3.Text + "%' ";
            }
            if ((bool)Session["it"] != true || (bool)Session["r"] != true)
            {
                if ((bool)Session["it"]) where += " and Employees.Id_speciality = 901 ";
                if ((bool)Session["r"]) where += " and Employees.Id_speciality = 902 ";
            }
            if ((string)Session["active"] != "all")
            {
                if ((string)Session["active"] == "plan") { where += " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) "; }
                if ((string)Session["active"] == "re") { where += " and (Employees.Validation_duty_AP = 1 or Employees.Validation_duty_ES = 1) "; }
                if ((string)Session["active"] == "request") { where += "and Workbook.Want_rise = 1 "; }
            }
            ProductsListView1.DataSource = emp.Employees(where);
            ProductsListView1.DataBind();
        }
        protected void It_Click(object sender, EventArgs e)
        {
            if ((bool)Session["it"])
            {
                Session["it"] = false;
                itbutton.CssClass = "styleleftbut it";
            }
            else
            {
                Session["it"] = true;
                itbutton.CssClass = "reversestyleleftbut it";
            }            
        }
        protected void R_Click(object sender, EventArgs e)
        {
            if ((bool)Session["r"])
            {
                Session["r"] = false;
                rbutton.CssClass = "styleleftbut it";
            }
            else
            {
                Session["r"] = true;
                rbutton.CssClass = "reversestyleleftbut it";
            }
        }
        protected void All_Click(object sender, EventArgs e)
        {
            AllButton.CssClass = "upbut bt1reverse";
            PlanButton.CssClass = "upbut bt2";
            ReButton.CssClass = "upbut bt3";
            RequestButton.CssClass = "upbut bt4";

            allfalse(); all = true; Session["active"] = "all";
            where = "";
            ProductsListView1.DataSource = emp.Employees(where);
            ProductsListView1.DataBind();            
            
        }
        protected void Plan_Click(object sender, EventArgs e)
        {
            AllButton.CssClass = "upbut bt1"; 
            PlanButton.CssClass = "upbut bt2reverse";
            ReButton.CssClass = "upbut bt3";
            RequestButton.CssClass = "upbut bt4";

            allfalse(); plan = true; Session["active"] = "plan";
            where = " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) ";
            ProductsListView1.DataSource = emp.Employees(where);
            ProductsListView1.DataBind();
            
        }
        protected void Re_Click(object sender, EventArgs e)
        {
            AllButton.CssClass = "upbut bt1";
            PlanButton.CssClass = "upbut bt2";
            ReButton.CssClass = "upbut bt3reverse";
            RequestButton.CssClass = "upbut bt4";

            allfalse(); re = true; Session["active"] = "re";
            where = " and (Employees.Validation_duty_AP = 1 or Employees.Validation_duty_ES = 1) ";
            ProductsListView1.DataSource = emp.Employees(where);
            ProductsListView1.DataBind();
        }
        protected void Request_Click(object sender, EventArgs e)
        {
            AllButton.CssClass = "upbut bt1";
            PlanButton.CssClass = "upbut bt2";
            ReButton.CssClass = "upbut bt3";
            RequestButton.CssClass = "upbut bt4reverse";

            allfalse(); request = true; Session["active"] = "request";
            where = "and Workbook.Want_rise = 1 ";
            ProductsListView1.DataSource = emp.Employees(where);
            ProductsListView1.DataBind();
        }

        protected void ProductsListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ProductsListView1.FindControl("DataPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ProductsListView1.DataSource = emp.Employees(where);
            ProductsListView1.DataBind();
        }
    }
}