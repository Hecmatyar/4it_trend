using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class ConductingPage_UnPlan : System.Web.UI.Page
    {
        public localhost.Validation emp = new localhost.Validation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (emp.Commission_Appointed("UnPlan"))
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
                if (emp.DateSurprise())
                {
                    string where1 = "'1' = '1'";
                    GridView1.DataSource = emp.Validation_Duty(where1);
                    GridView1.DataBind();
                    string date1 = "Date1";
                    Label1.Text = "Техника безопасности - " + emp.Date_Surprise(date1);
                    Label2.Text = "Список сотрудников";
                    Label3.Text = "проходящих внеплановую аттестацию по дисциплине:";
                }
                else
                {
                    Label2.Text = "На данный момент проведение";
                    Label3.Text = "внеплановой аттестации не запланировано";
                    Label1.Text = "Назначить проведение внеплановой аттестации";
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (emp.DateSurprise())
            {
                string date1 = "Date1";
                Label1.Text = "Техника безопасности - " + emp.Date_Surprise(date1);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (emp.DateSurprise())
            {
                string date1 = "Date2";
                Label1.Text = "Электробезопасность - " + emp.Date_Surprise(date1);
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["commissionpage"] = "ConductingPage_UnPlan";
            Response.Redirect(@"~\Page\Approve.aspx");            
        }
    }
}