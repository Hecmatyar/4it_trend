using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero_2.Page
{
    public partial class Profile : System.Web.UI.Page
    {
        public string log;
        public localhost.Validation emp = new localhost.Validation();

        public string[] array1 = new string[14];
        public string[] array2 = new string[6];
        public string[] array3 = new string[5];
        public void Attestatoin()
        {
            string date1 = emp.Date_Plan("Every_validation_AP", array1[5]);
            string date2 = emp.Date_Plan("Every_validation_ES", array1[5]);

            string date3 = emp.Date_UnPlan("Date1");
            string date4 = emp.Date_UnPlan("Date2");

            string date5 = emp.Date_Repeated("Date1");
            string date6 = emp.Date_Repeated("Date2");

            //плановая дата аттестаций
            if (array2[2] != "False") { Label34.Text = date1; }
            else { Label34.Text = "(отсутствует)"; }
            if (array2[3] != "False") { Label35.Text = date2; }
            else { Label35.Text = "(отсутствует)"; }

            //повторная аттестация
            if (emp.DateRepeated())
            {
                if (array2[0] != "False" || array2[1] != "False")
                    {
                    Label48.Visible = true; Label49.Visible = true;
                    Label50.Visible = true; Label51.Visible = true; Label52.Visible = true;
                    if (array2[0] != "False") { Label50.Text = date5; }
                    else { Label50.Text = "(отсутствует)"; }
                    if (array2[1] != "False") { Label52.Text = date6; }
                    else { Label52.Text = "(отсутствует)"; }
                }
                else
                {
                    Label48.Visible = false; Label49.Visible = false;
                    Label50.Visible = false; Label51.Visible = false; Label52.Visible = false;
                }
            }
            else
            {
                Label48.Visible = false; Label49.Visible = false;
                Label50.Visible = false; Label51.Visible = false; Label52.Visible = false;
            }

            //внеплановая дата аттестаций
            if (emp.DateSurprise())
            {
                Label45.Visible = true; Label47.Visible = true;
                Label44.Visible = true; Label46.Visible = true; Label53.Visible = true;
                Label45.Text = date3; Label47.Text = date4;                
            }
            else
            {
                Label45.Visible = false; Label47.Visible = false;
                Label44.Visible = false; Label46.Visible = false; Label53.Visible = false;
            }

            //DateTime date1 = Convert.ToDateTime(a);
            //return date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));        
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            log = (string)Session["login"];
            
            emp.ProFile(log, ref array1, ref array2, ref array3);

            //заполнение полей
            Label2.Text = log;    //логин
            Label3.Text = array1[1];    //пароль
            Label1.Text = array1[7];    //номер рабочей книжки

            DateTime date1 = Convert.ToDateTime(array3[0]);
            Label9.Text = date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));   //дата принятия на предприятие

            date1 = Convert.ToDateTime(array3[1]);
            Label10.Text = (DateTime.Now.Year - date1.Year).ToString() + " лет / год(а)";   //стаж на должности

            if (array1[5] == "901")     //специальность
            { Label11.Text = "Инженерно-технический сотрудник"; }
            else if (array1[5] == "902") Label11.Text = "Рядовой сотрудник";

            if (array1[5] == "901")     //разряд
            {
                Label12.Text = "( отсутствует )";
            }
            else Label12.Text = array1[6];

            Label13.Text = array1[3] + " " + array1[2] + " " + array1[4];   //ФИО
            date1 = Convert.ToDateTime(array3[3]);
            Label16.Text = date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));        //день рождения

            Label18.Text = (DateTime.Now.Year - date1.Year).ToString();
            Label20.Text = array1[13];      //адрес
            Label22.Text = array1[12];      //номер телефона
            Label24.Text = array1[11];      //почта
            Label27.Text = array1[10];      //выговоры
            Label29.Text = array1[9];       //достижения

            //аттестации
            Attestatoin();
            rise();
        }
        public void rise()
        {
            if (array1[5] != "901")
            { 
                System.Drawing.Color mycolor = new System.Drawing.Color();
                DateTime date = Convert.ToDateTime(array3[1]);
                string datetime = (DateTime.Now.Year - date.Year).ToString();
                if (Convert.ToInt16(datetime) < 3)
                {
                    mycolor = System.Drawing.Color.FromArgb(243, 131, 102);
                    Label37.Text = "Условия повышение разряда не соблюдены. Ваш стаж сотавляет - " + datetime + " год(а)";
                    Label38.Text = "Ознакомьтесь с условиями во вкладке «Документы»" ;
                    Label37.ForeColor = mycolor;
                    Button1.Visible = false;
                }
                else
                if (array1[6].Trim() == "мастер") 
                {
                    mycolor = new System.Drawing.Color();
                    mycolor = System.Drawing.Color.FromArgb(238, 196, 68);
                    Label37.ForeColor = mycolor; Label38.ForeColor = mycolor;
                    Label37.Text = "Вы имеет разряд 'мастер', повысить разряд не представляется возможным";
                    Label38.Text = "";
                    Button1.Visible = false;
                }
                else
                {
                    if (array2[4] == "False" && array2[5] == "False")
                    {
                        mycolor = System.Drawing.Color.FromArgb(203, 203, 205);
                        Label37.ForeColor = mycolor; Label38.ForeColor = mycolor;
                        Label37.Text = "Для повышения разряда необходимо подать заявление на проведение аттестации";
                        Label38.Text = "-";
                        Button1.Enabled = true;
                    }
                    else if (array2[4] == "True" && array2[5] == "False")
                    {
                        mycolor = System.Drawing.Color.FromArgb(203, 203, 205);
                        Label37.ForeColor = mycolor;
                        mycolor = System.Drawing.Color.FromArgb(238, 196, 68);
                        Label38.ForeColor = mycolor;
                        DateTime date1 = Convert.ToDateTime(array3[2]);
                        string wantdate = date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
                        Label37.Text = "Вы подали заявление: " + wantdate;
                        Label38.Text = "Заявление ожидает рассмотрения руководителя";
                        Button1.Visible = true;
                        Button1.Text = "Отозвать заявление";
                    }
                    else if (array2[4] == "True" && array2[5] == "True")
                    {
                        mycolor = System.Drawing.Color.FromArgb(203, 203, 205);
                        Label37.ForeColor = mycolor; Label38.ForeColor = mycolor;
                        DateTime date1 = Convert.ToDateTime(array3[2]);
                        string wantdate = date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
                        Label37.Text = "Вы подали заявление: " + wantdate;
                        date1 = Convert.ToDateTime(array3[4]);
                        wantdate = date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
                        Label38.Text = "Назначенное время аттестации: " + wantdate;
                        Button1.Visible = false;
                    }                                        
                }
               
            }
            else
            {
                System.Drawing.Color mycolor = new System.Drawing.Color();
                mycolor = System.Drawing.Color.FromArgb(238, 196, 68);
                Label37.ForeColor = mycolor; Label38.ForeColor = mycolor;
                Label37.Text = "Инженерно технический персонал не нуждается в проведении аттестации для повышения";
                Label38.Text = "";
                Button1.Visible = false;
            } 
        }
        protected void Statement_Click(object sender, EventArgs e)
        {
            // подача заявления
            if (array2[4] == "False" && array2[5] == "False")
            {
                emp.Statement(array1[7]);
                Response.Redirect(Request.Url.AbsolutePath);
            }
            else if(array2[4] == "True" && array2[5] == "False")
            {
                emp.StatementReverse(array1[7]);
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }
    }
}