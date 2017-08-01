using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class CondactingPage_Plan : System.Web.UI.Page
    {
        public localhost.Validation emp = new localhost.Validation();        
        
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (emp.Commission_Appointed("PlanV"))
            {
                Label4.Text = "Аттестационная комисиия назначена";
                System.Drawing.Color mycolor = new System.Drawing.Color();
                mycolor = System.Drawing.Color.FromArgb(238, 196, 68);
                Label4.ForeColor = mycolor;
                Button3.Text = "Переопределить";
            }
            else
            {
                Label4.Text = "Аттестационная комисиия не назначена";
                Button3.Text = "Определить";
                Label4.ForeColor = System.Drawing.Color.LightGray;
            }
            if (!Page.IsPostBack)
            {
                //bool a = emp.Exists("Validation_AP = '1'");
                //bool b = emp.Exists("Validation_ES = '1'");
                //if (a == true || b == true)
                //{
                    string where1 = "Validation_AP = '1'";
                    GridView1.DataSource = emp.Validation_Duty(where1);
                    GridView1.DataBind();
                    string date1 = "Every_validation_AP";
                    Label1.Text = "Техника безопасности - " + emp.Date_Validation(date1);
                    
                //}                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string where1 = "Validation_AP = '1'";
            GridView1.DataSource = emp.Validation_Duty(where1);
            GridView1.DataBind();
            string date1 = "Every_validation_AP";
            Label1.Text = "Техника безопасности - " + emp.Date_Validation(date1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string where2 = "Validation_ES = '1'";
            GridView1.DataSource = emp.Validation_Duty(where2);
            GridView1.DataBind();
            string date2 = "Every_validation_ES";
            Label1.Text = "Электробезопасность - " + emp.Date_Validation(date2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["commissionpage"] = "ConductingPage_Plan";
            Response.Redirect(@"~\Page\Approve.aspx");            
        }
    }
}