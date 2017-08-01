using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Globalization;
using NUnit.Framework;

namespace Zero_1
{
    /// <summary>
    /// Сводное описание для Validation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    [TestFixture]
    public class Validation : System.Web.Services.WebService
    {
        static string path = HttpContext.Current.Server.MapPath("App_Data/First_DB.mdf");
        static string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True;Connect Timeout=30";
        static SqlConnection con = new SqlConnection(conStr);

        [WebMethod]
        public DataTable SelectLog()
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Select Time as [Время запроса], Login as [Запрос от], Action as [Действие] from Log";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }
        /*логирование*/
        [WebMethod]
        public void Insert(string login, string action)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            DateTime date = DateTime.Now;
            string request = "Insert into Log values(GETDATE(),N'" + login + "',N'" + action + "')";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        /*завершение аттестации*/
        [WebMethod]
        public void OverAttestation(string table, string set)
        {
            Insert("Руководитель", "Завершение проведения аттестации");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update " + table + " set " + set;
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        /*добавление аттестационной комиссии*/
        [WebMethod]
        public void ApproveAttestationPlan(string date1, string date2)
        {
            Insert("Руководитель", " Обновление даты проведения плановой аттестации."
                + " Назначенное время Техника безопасности: " + date1 + "    Электробезопасность: " + date2);
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update Speciality set Every_validation_AP = '" + date1 + "', Every_validation_ES = '"
                + date2 + "' where Id_speciality = 902";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void ApproveAttestationRequest(string date1)
        {
            Insert("Руководитель", " Назначение проведения аттестации на повышение разряда сотрудникам, которые подали заявления."
                + " Назначенное время:" + date1);
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update Workbook set Register_date = '" + date1 + "', Register_rise = 1 where Want_rise = 1";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void ApproveAttestationUnPlan(string date1, string date2)
        {
            Insert("Руководитель", "Обновление/Добавление даты проведения внеплановой аттестации "
                + " Назначенное время Техника безопасности: " + date1 + "    Электробезопасность: " + date2);
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update Surprise_Validation set Bee = 1, Date1 = '" + date1 + "',Date2 = '" + date2 + "'";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void ApproveAttestationRe(string date1, string date2)
        {
            Insert("Руководитель", "Обновление/Добавление даты проведения повторной аттестации "
                 + " Назначенное время Техника безопасности: " + date1 + "    Электробезопасность: " + date2);
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update Repeated_Validation set Bee = 1, Date1 = '" + date1 + "',Date2 = '" + date2 + "'";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void ApproveAttestation(string column)
        {
            string action;
            if (column == "PlanV") action = "Назначение комисии на плановую аттестацию";
            else if (column == "UnPlan") action = "Назначение комисии на внеплановую аттестацию";
            else if (column == "Re") action = "Назначение комисии на повторную аттестацию";
            else action = "Назначение комисии на аттестацию повышения разряда";
            Insert("Руководитель", action);
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update Commission_appoint set " + column + " = 1";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void ApproveAttestationReverse(string column)
        {            
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update Commission_appoint set " + column + " = 0";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void ApproveDataDelete(string column)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update Validation_Commission set " + column + " = 0";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void ApproveData(string id, string column)
        {
            string action;
            if (column == "PlanV") action = "на плановую аттестацию";
            else if (column == "UnPlan") action = "на внеплановую аттестацию";
            else if (column == "Re") action = "повторную аттестацию";
            else action = "на аттестацию повышения разряда";
            Insert("Руководитель", "Назначение члена комисии с личным номером " + id + " " + action);
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request1 = "Update Validation_Commission set " + column +
                " = 1 where Id_validperson = '" + id + "'";
            SqlCommand command = new SqlCommand(request1, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        /*выбор представителя правительственной службы*/
        [WebMethod]
        public string Government()
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Name_man, Surname_man, Patronymic_man FROM Government where Attestation = 1";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            string a = dr.GetValue(0).ToString() + dr.GetValue(1).ToString() + dr.GetValue(2).ToString();
            con.Close();
            return a;
        }

        /*метод выбора комиссии для списка*/
        [WebMethod]
        public DataSet Fill_Commission(string fill)
        {            
            //Insert("Руководитель", "Произведение выборки членов аттестационной комисии");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Name_vp, Surname_vp, Patronymic_vp, Id_validperson FROM Validation_Commission";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            con.Close();
            return ds;
        }
        /*метод на утверждение комисии*/
        [Test]
        [WebMethod]
        public bool Commission_Appointed(string p)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT " + p + " FROM Commission_appoint";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            bool a = Convert.ToBoolean(dr.GetValue(0));
            con.Close();
            return a;
        }        
       
        /*подача заявления*/
        [WebMethod]
        public void StatementReverse(string workbook)
        {            
            Insert("Сотрудник", "Сотрудник предприятия с личным делом: " + workbook + " отозвал заявление на повышение разряда");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            DateTime date = DateTime.Now;
            string request = "Update Workbook set Want_rise = 0, Want_date = NULL where Number_workbook = '" + workbook + "'";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void Statement(string workbook)
        {
            Insert("Сотрудник", "Сотрудник предприятия с личным делом: " + workbook + " подал заявление на повышение разряда");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            DateTime date = DateTime.Now;            
            string request = "Update Workbook set Want_rise = 1, Want_date = GETDATE() where Number_workbook = '" + workbook + "'";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        /*заполнение профиля*/
        [WebMethod]
        public void ProFile(string login,ref string[] array1, ref string[] array2, ref string[] array3)
        {
            Insert("", "Запрос на получение данных сотрудника с личным номером " + login);
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT * FROM Employees where Id_employees = '" + login + "'";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            //заполнение
            array1[0] = dr.GetValue(0).ToString();
            array1[1] = dr.GetValue(1).ToString();
            array1[2] = dr.GetValue(2).ToString();
            array1[3] = dr.GetValue(3).ToString();
            array1[4] = dr.GetValue(4).ToString();
            array1[5] = dr.GetValue(5).ToString();
            array1[6] = dr.GetValue(6).ToString();
            array1[7] = dr.GetValue(7).ToString();

            //array2[0] = Convert.ToBoolean(dr.GetValue(8));
            //array2[1] = Convert.ToBoolean(dr.GetValue(9));
            //array2[2] = Convert.ToBoolean(dr.GetValue(10));
            //array2[3] = Convert.ToBoolean(dr.GetValue(11));
            array2[0] = dr.GetValue(8).ToString();
            array2[1] = dr.GetValue(9).ToString();
            array2[2] = dr.GetValue(10).ToString();
            array2[3] = dr.GetValue(11).ToString();

            dr.Close();

            string request1 = "SELECT * FROM Workbook where Number_workbook = '" + array1[7] + "'";
            SqlCommand command1 = new SqlCommand(request1, con);
            SqlDataReader dr1 = command1.ExecuteReader();
            dr1.Read();

            string a1 = dr1.GetValue(1).ToString();
            string a2 = dr1.GetValue(2).ToString();
            string a3 = dr1.GetValue(7).ToString();
            string a4 = dr1.GetValue(9).ToString();
            string a5 = dr1.GetValue(13).ToString();

            //DateTime b1 = Convert.ToDateTime(a1);
            //DateTime b2 = Convert.ToDateTime(a2);
            //DateTime b3 = Convert.ToDateTime(a3);
            //DateTime b4 = Convert.ToDateTime(a4);

            array3[0] = a1;
            array3[1] = a2;
            array3[2] = a3;
            array3[3] = a4;
            array3[4] = a5;

            array2[4] = dr1.GetValue(6).ToString();
            array2[5] = dr1.GetValue(12).ToString();

            array1[8] = dr1.GetValue(3).ToString();
            array1[9] = dr1.GetValue(4).ToString();
            array1[10] = dr1.GetValue(5).ToString();
            array1[11] = dr1.GetValue(8).ToString();
            array1[12] = dr1.GetValue(10).ToString();
            array1[13] = dr1.GetValue(11).ToString();

            dr1.Close();
            con.Close();

        }
        
        /*вход в систему*/
        [WebMethod]
        public bool Authentification(string login, string password, ref int who)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            //login = login.Replace(" ", string.Empty);
            //password = password.Replace(" ", string.Empty);
            int res =0;
            bool isInt = Int32.TryParse(login, out res);
            bool a = false; bool b = false;
            if (isInt)
            {
                //если истина, то есть записи               
                string request = "SELECT * FROM Employees where Id_employees = '" + login +
                    "' and Pass_employees = '" + password + "'";
                SqlCommand command = new SqlCommand(request, con);
                SqlDataAdapter read = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                read.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                { a = true; Insert("Сотрудник", " Сотрудник с личным номером: " + login + " произвел вход на сайт"); }
                }
            else {
                string request1 = "SELECT * FROM Admin where Id_Admin = '" + login +
                    "' and Password_Admin = '" + password + "'";
                SqlCommand command1 = new SqlCommand(request1, con);
                SqlDataAdapter read1 = new SqlDataAdapter(command1);
                DataSet ds1 = new DataSet();
                read1.Fill(ds1);
                DataTable dt1 = ds1.Tables[0];
                if (dt1.Rows.Count == 1)
                {
                    b = true;
                    Insert("Руководитель", " Руководитель под логином: " + login + " произвел вход на сайт"); }
                }
            con.Close();
            if (a == true && b == false) { who = 2; return true; }
            if (a == false && b == true) { who = 1; return true; }            
            else return false;            
        }
        //метод 
        [Test]        
        [WebMethod]
        public string Date_Plan(string val, string val1)
        {
            //Insert("Руководитель", "Получение даты плановой аттестации");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT " + val + " FROM Speciality where Id_speciality = '" + val1 + "'";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();
            string a = dr3.GetValue(0).ToString();
            con.Close();
            DateTime date1 = Convert.ToDateTime(a);
            return date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
        }
        //дата повторной аттестации
        [WebMethod]
        public string Date_Repeated(string val)
        {
            //Insert("Руководитель", "Получение даты повторной аттестации");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT " + val + " FROM Repeated_Validation";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();
            string a = dr3.GetValue(0).ToString();
            con.Close();
            try {
                DateTime date1 = Convert.ToDateTime(a);
                return date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
            }
            catch
            {
                return "";
            }
        }
        /*повторная аттестация*/
        [WebMethod]
        public bool DateRepeated()
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Bee FROM Repeated_Validation";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();
            bool a = Convert.ToBoolean(dr3.GetValue(0));
            con.Close();
            return a;
        }
        //дата внеплановой аттестации
        [WebMethod]
        public string Date_UnPlan(string val)
        {
            //Insert("Руководитель", "Получение даты внеплановой аттестации");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT " + val + " FROM Surprise_Validation";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();
            string a = dr3.GetValue(0).ToString();
            con.Close();
            try {
                DateTime date1 = Convert.ToDateTime(a);
                return date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
            }
            catch
            {
                return "";
            }
        }
        /*внеплановая аттестация*/
        [WebMethod]
        public bool DateSurprise()
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Bee FROM Surprise_Validation";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();
            bool a = Convert.ToBoolean(dr3.GetValue(0));
            con.Close();
            return a;
        }

        [Test]
        [WebMethod]
        public bool Exists(string where)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            //если истина, то есть записи
            bool a = false;
            string request = "SELECT * FROM Employees where " + where;
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.Close();
            if (dt.Rows.Count == 0) { a = false; return a; }
            else { a = true; return a; }
        }
        /*отбор задолжников по 
        охране труда и технике безопасности
        электробезопасности*/
        [WebMethod]
        public string Date_Surprise(string val)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT " + val + " FROM Surprise_Validation";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();
            string a = dr3.GetValue(0).ToString();
            con.Close();

            DateTime date1 = Convert.ToDateTime(a);
            return date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
        }
        [WebMethod]
        public DataSet Validation_Duty(string where)
        {
            Insert("Руководитель", "Выборка списка сотрудников проходящих аттестацию");        
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Id_employees, Name, Surname, Patronymic, Number_workbook, Rank, Name_Speciality"
                + " FROM Employees e, Speciality s where e.Id_speciality=s.Id_speciality and " + where;
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            con.Close();
            return ds;
        }
        [WebMethod]
        public DataTable Commision(string where)
        {
            Insert("Руководитель", "Отбор членов комисии, ответственных за проведение аттестации");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Select * from Validation_Commission where " + where + " = 1";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }
        /*проверка на вставку новых данных в таблице*/
        //public void Ins()
        //{
        //    try { con.Open(); }
        //    catch { con.Close(); con.Open(); }
        //    string request = "INSERT INTO Validation_Employees_Request (Id_employees, Name, Surname, Patronymic, Id_speciality, Rank) " +
        //    " SELECT Id_employees, Name, Surname, Patronymic, Id_speciality, Rank FROM Employees";
        //    SqlCommand command = new SqlCommand(request, con);
        //    command.ExecuteNonQuery();
        //    con.Close();
        //}
        //[WebMethod]
        //public DataSet Insert()
        //{
        //    Ins();
        //    try { con.Open(); }
        //    catch { con.Close(); con.Open(); }
        //    string request = "SELECT * FROM Validation_Employees_Request";
        //    SqlCommand command = new SqlCommand(request, con);
        //    SqlDataAdapter read = new SqlDataAdapter(command);
        //    DataSet ds = new DataSet();
        //    read.Fill(ds);
        //    con.Close();
        //    return ds;
        //}

        /*метод для выбора сотрудников, которые хотят повышения*/
        [WebMethod]
        public DataSet WantRice()
        {
            Insert("Руководитель", " Выборка сотрудников, которые подали заявку на повышени разряда");        
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Id_employees, Name, Surname, Patronymic, e.Number_workbook, Rank, Want_date FROM Employees e," +
                "Workbook w WHERE e.Number_workbook=w.Number_workbook AND Want_rise = '1'";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            con.Close();
            return ds;
        }
        /*метод для получения даты проведения аттестации*/
        [WebMethod]
        public string Date_Validation(string val)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            //string request = "SELECT " + val + " FROM Speciality";   
            string request = "SELECT " + val + " FROM Speciality where Id_speciality = '902'";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();                        
            string a = dr3.GetValue(0).ToString();
            con.Close();          
            
            DateTime date1 = Convert.ToDateTime(a);
            return date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
        }


        //проверка заявок
        [WebMethod]
        public bool Request()
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Register_date FROM Workbook where Register_rise = 1";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();
            if (dr3.HasRows)
                return true;
            else return false;
        }
        [WebMethod]
        public string DateRequest()
        {
            Insert("Руководитель", "Получение даты аттестации на повышение разряда");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Register_date FROM Workbook where Register_rise = 1";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataReader dr3 = command.ExecuteReader();
            dr3.Read();
            string a = dr3.GetValue(0).ToString();
            con.Close();           
            DateTime date1 = Convert.ToDateTime(a);
            return date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
        }

        [Test]
        [WebMethod]
        public DataTable wh()
        {            
            string request = "Select Surname, Name , Patronymic from Employees where "
                + " Name = N'Виктор'";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            return a;
        }

        [WebMethod]
        public DataTable Employees(string where)
        {
            Insert("Руководитель", " Выборка всех сотрудников предприятия для поиска и назначения аттестации");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Select Employees.Surname, Employees.Name, Employees.Patronymic, Employees.Id_employees, " +
                "Employees.Number_workbook, Workbook.Mailing_address, Workbook.Phone_number, Speciality.Name_speciality " +
                "from Employees, Workbook, Speciality " +
                "where Employees.Number_workbook = Workbook.Number_workbook and Speciality.Id_speciality = Employees.Id_speciality " 
                + where;
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }
        [WebMethod]
        public DataTable GovernmentMan()
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Select * from Government";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }

        [WebMethod]
        public DataTable WA_Validation(string where)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Employees.Id_employees as [Личный номер], Employees.Surname as Фамилия ,Employees.Name as Имя, " +
                "Employees.Patronymic as Отчество, Speciality.Name_speciality as Специальность, Employees.Number_workbook as [Код должности] "
                + "FROM Employees, Speciality, Workbook where Employees.Number_workbook = Workbook.Number_workbook "
                + "and Speciality.Id_speciality = Employees.Id_speciality " + where;
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }
        [WebMethod]
        public DataTable WA_ValidationRequest(string where)
        {
            Insert("Руководитель", " Выборка сотрудников, проходящих аттесатцию на повышение разряда");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "SELECT Employees.Id_employees as [Личный номер], Employees.Surname as Фамилия ,Employees.Name as Имя, " +
                "Employees.Patronymic as Отчество, Employees.Number_workbook as [Код должности], Employees.Rank as Разряд, Workbook.Want_date as [Дата запроса] "
                + "FROM Employees, Speciality, Workbook where Employees.Number_workbook = Workbook.Number_workbook "
                + "and Speciality.Id_speciality = Employees.Id_speciality " + where;
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }
        [WebMethod]
        public DataTable WA_GovernmentMan()
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Select Patronymic_man, Name_man, Surname_man from Government";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }
        [WebMethod]
        public DataTable WA_CommissionMan(string where)
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Select Patronymic_vp, Name_vp, Surname_vp from Validation_Commission where " + where + " = 1";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }
        [WebMethod]
        public bool WA_Duty(string column, string id)
        {
            //Insert("Руководитель", "Получение личный данных сотрудника с номером " + id);
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Select " + column + " from Employees where Id_employees = '" + id + "'" ;
            SqlCommand command = new SqlCommand(request, con);            
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            bool a = Convert.ToBoolean(dr.GetValue(0));
            con.Close();
            return a;
        }
        [WebMethod]
        public void WA_UpdateDuty(string table, string column, string where)
        {
            Insert("Руководитель", "Обновление данных в таблице аттестаций сотрудников");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Update " + table + " set " + column + " where " + where;
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }

        //метод окончания аттестации
        [WebMethod]
        public DataTable WA_EndAttestation(bool bl)
        {
            //string table, string column, string where,
            //Insert("Руководитель", "Зарпос отчета");
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request= "";
            if (bl)
                request = "Select Id_employees, Surname, Name, Patronymic, Number_workbook, s.Name_speciality, r.Action, es.Action" +
                    " from Employees e, ReportResult r, ReportResult_ES es, Speciality s where "+
                    "e.Id_speciality = s.Id_speciality and e.Validation_duty_AP = r.Result and e.Validation_duty_ES = es.Result ";
            else
                request = "Select Id_employees, Surname, Name, Patronymic, Number_workbook, Rank, r.Action "+
                    "from ReportRequest p, ReportResultRequest r where r.Result = p.Result";
            SqlCommand command = new SqlCommand(request, con);
            SqlDataAdapter read = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            read.Fill(ds);
            DataTable a = new DataTable();
            a = ds.Tables[0];
            con.Close();
            return a;
        }        
        [WebMethod]
        public void WA_ReportRequest(string where)
        {           
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Insert into ReportRequest select Id_employees, Surname, Name, Patronymic, e.Number_workbook, Rank, w.Want_rise "
                + "from Employees e, Workbook w where e.Number_workbook = w.Number_workbook and e.Id_employees = " + where;
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        [WebMethod]
        public void WA_Delete()
        {
            try { con.Open(); }
            catch { con.Close(); con.Open(); }
            string request = "Delete from Log";
            SqlCommand command = new SqlCommand(request, con);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
