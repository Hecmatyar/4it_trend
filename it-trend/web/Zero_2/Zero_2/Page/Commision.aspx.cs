using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class Commision : System.Web.UI.Page
    {
        public localhost.Validation emp = new localhost.Validation();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductsListView1.DataSource = emp.Commision("PlanV");
            ProductsListView1.DataBind();
            ProductsListView2.DataSource = emp.Commision("Re");
            ProductsListView2.DataBind();
            ProductsListView3.DataSource = emp.Commision("Request");
            ProductsListView3.DataBind();
            ProductsListView4.DataSource = emp.Commision("UnPlan");
            ProductsListView4.DataBind();
            ListView1.DataSource = emp.GovernmentMan();
            ListView1.DataBind();
            ListView2.DataSource = emp.GovernmentMan();
            ListView2.DataBind();
            ListView3.DataSource = emp.GovernmentMan();
            ListView3.DataBind();
            if (!emp.Commission_Appointed("PlanV")) ListView1.Visible = false; 
            if (!emp.Commission_Appointed("Re")) ListView2.Visible = false;
            if (!emp.Commission_Appointed("UnPlan")) ListView3.Visible = false;

            DateTime date = new DateTime();
            //плановая аттестация
            string date1 = "Every_validation_AP";
            Label8.Text = emp.Date_Validation(date1);
            date = Convert.ToDateTime(Label8.Text);
            Label5.Text = date.ToString("M", CultureInfo.CreateSpecificCulture("ru-RU"));
            date1 = "Every_validation_ES";
            Label9.Text = emp.Date_Validation(date1);
            date = Convert.ToDateTime(Label9.Text);
            Label7.Text = date.ToString("M", CultureInfo.CreateSpecificCulture("ru-RU"));

            //повторная аттестация
            if (emp.DateRepeated())
            {               
                string date2 = "Date1";
                Label15.Text = emp.Date_Repeated(date2);
                date = Convert.ToDateTime(Label15.Text);
                Label12.Text = date.ToString("M", CultureInfo.CreateSpecificCulture("ru-RU"));
                date2 = "Date2";
                Label16.Text = emp.Date_Repeated(date2);
                date = Convert.ToDateTime(Label16.Text);
                Label14.Text = date.ToString("M", CultureInfo.CreateSpecificCulture("ru-RU"));
            }
            else
            {
                Label15.Text = "дата отсутствует";
                Label16.Text = "дата отсутствует";
                Label12.Text = "отсутствует";
                Label14.Text = "отсутствует";
            }
            //внеплановая
            if (emp.DateSurprise())
            {                
                string date3 = "Date1";
                Label29.Text = emp.Date_Surprise(date3);
                date = Convert.ToDateTime(Label29.Text);
                Label26.Text = date.ToString("M", CultureInfo.CreateSpecificCulture("ru-RU"));
                date3 = "Date2";
                Label30.Text = emp.Date_Surprise(date3);
                date = Convert.ToDateTime(Label30.Text);
                Label28.Text = date.ToString("M", CultureInfo.CreateSpecificCulture("ru-RU"));
            }
            else
            {
                Label29.Text = "дата отсутствует";
                Label30.Text = "дата отсутствует";
                Label26.Text = "отсутствует";
                Label28.Text = "отсутствует";
            }
            //заявки
            if(emp.Request())
            {
                Label22.Text = emp.DateRequest();
                date = Convert.ToDateTime(Label22.Text);
                Label19.Text = date.ToString("M", CultureInfo.CreateSpecificCulture("ru-RU"));
            }
            else { Label22.Text = "дата отсутствует"; Label19.Text = "отсутствует"; }
        }
    }
}