using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Web_Service.Validation web = new Web_Service.Validation();

        #region //заполнение комиссии и аттестаций
        public void AppointDate()
        {           
            //начальное заполнение данными об аттестациях
            string date1 = "Every_validation_AP";
            plandate1.Content = web.Date_Validation(date1);
            plandate3.Content = web.Date_Validation(date1);
            date1 = "Every_validation_ES";
            plandate2.Content = web.Date_Validation(date1);
            plandate4.Content = web.Date_Validation(date1);
            //повторная аттестация
            if (web.DateRepeated())
            {
                string date2 = "Date1";
                redate1.Content = web.Date_Repeated(date2);
                date2 = "Date2";
                redate2.Content = web.Date_Repeated(date2);
                EndRebutton.Visibility = Visibility.Visible;
                ReGov.Visibility = Visibility.Visible;
            }
            else
            {
                redate1.Content = "отсутствует";
                redate2.Content = "отсутствует";
                EndRebutton.Visibility = Visibility.Hidden;
                ReGov.Visibility = Visibility.Hidden;
            }
            //внеплановая
            if (web.DateSurprise())
            {
                string date3 = "Date1";
                unplandate1.Content = web.Date_Surprise(date3);
                date3 = "Date2";
                unplandate2.Content = web.Date_Surprise(date3);
                EndUnplanbutton.Visibility = Visibility.Visible;
                UnplanGov.Visibility = Visibility.Visible;
            }
            else
            {
                unplandate1.Content = "отсутствует";
                unplandate2.Content = "отсутствует";
                EndUnplanbutton.Visibility = Visibility.Hidden;
                UnplanGov.Visibility = Visibility.Hidden;
            }
            //заявки
            if (web.Request())
            {
                requestdate.Content = web.DateRequest();
                EndRequestbutton.Visibility = Visibility.Visible;               
            }
            else { requestdate.Content = "отсутствует"; EndRequestbutton.Visibility = Visibility.Hidden; }
        }
        public void Commission(Label l1, Label l2, Label l3, Label l4, string where)
        {
            l1.Content = ""; l2.Content = ""; l3.Content = "";
            DataTable tablecom = new DataTable();
            tablecom = web.WA_CommissionMan(where);
            if (tablecom.Rows.Count == 3)
            {
                DataRow row = tablecom.Rows[0];
                l1.Content = row[0].ToString().Trim() +" "+ row[1].ToString().Trim() +" " + row[2].ToString().Trim();
                row = tablecom.Rows[1];
                l2.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
                row = tablecom.Rows[2];
                l3.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
            }
            else if (tablecom.Rows.Count == 2)
            {
                DataRow row = tablecom.Rows[0];
                l1.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
                row = tablecom.Rows[1];
                l2.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
            }
            else if (tablecom.Rows.Count == 1)
            {
                DataRow row = tablecom.Rows[0];
                l1.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
            }
            tablecom = web.WA_GovernmentMan();
            DataRow row1 = tablecom.Rows[0];
            l4.Content = row1[0].ToString().Trim() + " " + row1[1].ToString().Trim() + " " + row1[2].ToString().Trim();
        }
        public void Commission(Label l1, Label l2, Label l3, string where)
        {
            l1.Content = ""; l2.Content = ""; l3.Content = "";
            DataTable tablecom = new DataTable();
            tablecom = web.WA_CommissionMan(where);
            if (tablecom.Rows.Count == 3)
            {
                DataRow row = tablecom.Rows[0];
                l1.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
                row = tablecom.Rows[1];
                l2.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
                row = tablecom.Rows[2];
                l3.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
            }
            else if (tablecom.Rows.Count == 2)
            {
                DataRow row = tablecom.Rows[0];
                l1.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
                row = tablecom.Rows[1];
                l2.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
            }
            else if (tablecom.Rows.Count == 1)
            {
                DataRow row = tablecom.Rows[0];
                l1.Content = row[0].ToString().Trim() + " " + row[1].ToString().Trim() + " " + row[2].ToString().Trim();
            }            
        }
        #endregion
              
        //заполнение полей
        public void SetCommission()
        {           
            Commission(PlanMember1, PlanMember2, PlanMember3, PlanGov, "PlanV");
            Commission(ReMember1, ReMember2, ReMember3, ReGov, "Re");
            Commission(UnplanMember1, UnplanMember2, UnplanMember3, UnplanGov, "UnPlan");
            Commission(RequestMember1, RequestMember2, RequestMember3, "Request");            
        }
        public void SetCombobox()
        {
            WriteComboBox(attestationplan1, attestationplan2, attestationplan3);
            WriteComboBox(attestationre1, attestationre2, attestationre3);
            WriteComboBox(attestationrequest1, attestationrequest2, attestationrequest3);
            WriteComboBox(attestationunplan1, attestationunplan2, attestationunplan3);
        }
        public MainWindow()
        {
            InitializeComponent();
            string where = " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) ";
            dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
            dataGrid2.ItemsSource = web.WA_Validation("").DefaultView;
            AppointDate();
            SetCommission();
            SetCombobox();
        }
        #region //генерация колонок

        private void dataGrid3_AutoGeneratedColumns(object sender, EventArgs e)
        {
            WidthDataGrid3();
        }
        public void WidthDataGrid3()
        {                        
            dataGrid1.Columns[2].Width = 690;
        }
        private void dataGrid1_AutoGeneratedColumns(object sender, EventArgs e)
        {
            WidthDataGrid();
        }
        public void WidthDataGrid()
        {
            dataGrid1.Columns[0].Width = 110;
            dataGrid1.Columns[1].Width = 100;
            dataGrid1.Columns[2].Width = 100;
            dataGrid1.Columns[3].Width = 105;
            dataGrid1.Columns[4].Width = 230;
            dataGrid1.Columns[5].Width = 120;
        }
        public void WidthDataGrid2()
        {
            dataGrid1.Columns[0].Width = 110;
            dataGrid1.Columns[1].Width = 100;
            dataGrid1.Columns[2].Width = 100;
            dataGrid1.Columns[3].Width = 105;
            dataGrid1.Columns[4].Width = 115;
            dataGrid1.Columns[5].Width = 80;
        }
        private void dataGrid2_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dataGrid2.Columns[0].Width = 120;
            dataGrid2.Columns[1].Width = 100;
            dataGrid2.Columns[2].Width = 100;
            dataGrid2.Columns[3].Width = 105;
            dataGrid2.Columns[4].Width = 230;
            dataGrid2.Columns[5].Width = 120;
        }
        #endregion

        #region //переключение основных вкладок
        private void Attestationlabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            attestationgrid.Visibility = System.Windows.Visibility.Visible;
            employeesgrid.Visibility = System.Windows.Visibility.Hidden;            
            Attestationrect.Visibility = System.Windows.Visibility.Visible;
            Employeesrect.Visibility = System.Windows.Visibility.Hidden;
            Appointgrid.Visibility = System.Windows.Visibility.Hidden;
            Appointrect.Visibility = System.Windows.Visibility.Hidden;
            LogGrid.Visibility = System.Windows.Visibility.Hidden;
            Logrect.Visibility = System.Windows.Visibility.Hidden;
            //обновление

            AppointDate();
            SetCommission();
        }

        private void Employeeslabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            attestationgrid.Visibility = System.Windows.Visibility.Hidden;
            employeesgrid.Visibility = System.Windows.Visibility.Visible;
            Attestationrect.Visibility = System.Windows.Visibility.Hidden;
            Employeesrect.Visibility = System.Windows.Visibility.Visible;
            Appointgrid.Visibility = System.Windows.Visibility.Hidden;
            Appointrect.Visibility = System.Windows.Visibility.Hidden;
            LogGrid.Visibility = System.Windows.Visibility.Hidden;
            Logrect.Visibility = System.Windows.Visibility.Hidden;
            HeddenHead();
            Planrect.Visibility = System.Windows.Visibility.Visible;
            Planlabel.Foreground = Brushes.White;
            planinset = true;
            string where = " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) ";
            dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
        }
        ObservableCollection<FillDataGrid> collection = null;
        private void Log_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            attestationgrid.Visibility = System.Windows.Visibility.Hidden;
            employeesgrid.Visibility = System.Windows.Visibility.Hidden;
            Attestationrect.Visibility = System.Windows.Visibility.Hidden;
            Employeesrect.Visibility = System.Windows.Visibility.Hidden;
            Appointgrid.Visibility = System.Windows.Visibility.Hidden;
            Appointrect.Visibility = System.Windows.Visibility.Hidden;
            LogGrid.Visibility = System.Windows.Visibility.Visible;
            Logrect.Visibility = System.Windows.Visibility.Visible;

           
            if (collection == null)
            {
                collection = new ObservableCollection<FillDataGrid>();
                dataGrid3.ItemsSource = collection;
            }
            DataTable table = new DataTable();
            table = web.SelectLog();
            collection.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                collection.Add(
                    new FillDataGrid()
                    {
                        first = table.Rows[i][0].ToString(),
                        second = table.Rows[i][1].ToString(),
                        third = table.Rows[i][2].ToString()
                    }
                    );
            }

            //dataGrid3.ItemsSource = web.SelectLog().DefaultView;
        }
        private void Appointlabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LogGrid.Visibility = System.Windows.Visibility.Hidden;
            Logrect.Visibility = System.Windows.Visibility.Hidden;
            attestationgrid.Visibility = System.Windows.Visibility.Hidden;
            employeesgrid.Visibility = System.Windows.Visibility.Hidden;
            Attestationrect.Visibility = System.Windows.Visibility.Hidden;
            Employeesrect.Visibility = System.Windows.Visibility.Hidden;
            Appointgrid.Visibility = System.Windows.Visibility.Visible;
            Appointrect.Visibility = System.Windows.Visibility.Visible;
            dataGrid2.ItemsSource = web.WA_Validation("").DefaultView;
        }
        #endregion

        #region //переключение вкладок в проведении аттестации
        public bool planinset = false, reinset = false, requestinset = false, unplaninset = false;
        public void HeddenHead()
        {
            Allrect.Visibility = System.Windows.Visibility.Hidden;
            Planrect.Visibility = System.Windows.Visibility.Hidden;
            Rerect.Visibility = System.Windows.Visibility.Hidden;
            Requestrect.Visibility = System.Windows.Visibility.Hidden;
            Unplanrect.Visibility = System.Windows.Visibility.Hidden;
            Alllabel.Foreground = Brushes.Black;
            Planlabel.Foreground = Brushes.Black;
            Relabel.Foreground = Brushes.Black;
            Requestlabel.Foreground = Brushes.Black;
            Unplanlabel.Foreground = Brushes.Black;

            planinset = false;
            reinset = false;
            requestinset = false;
            unplaninset = false;           
        }
        private void Alllabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HeddenHead();
            Allrect.Visibility = System.Windows.Visibility.Visible;
            Alllabel.Foreground = Brushes.White;
        }
        public void Hidden_pupup()
        {
            pop_up_planandre.Visibility = Visibility.Hidden;
            pop_up_unplan.Visibility = Visibility.Hidden;
            pop_up_request.Visibility = Visibility.Hidden;
        }
        private void Planlabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HeddenHead();
            Planrect.Visibility = System.Windows.Visibility.Visible;
            Planlabel.Foreground = Brushes.White;
            planinset = true;
            string where = " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) ";
            dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
            WidthDataGrid();
            Hidden_pupup();
        }

        private void Relabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HeddenHead();
            Rerect.Visibility = System.Windows.Visibility.Visible;
            Relabel.Foreground = Brushes.White;
            reinset = true;
            string where = " and (Employees.Validation_duty_AP = 1 or Employees.Validation_duty_ES = 1) ";
            dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
            WidthDataGrid();
            Hidden_pupup();
        }

        private void Requestlabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HeddenHead();
            Requestrect.Visibility = System.Windows.Visibility.Visible;
            Requestlabel.Foreground = Brushes.White;
            requestinset = true;
            string where = "and Workbook.Want_rise = 1 ";
            dataGrid1.ItemsSource = web.WA_ValidationRequest(where).DefaultView;
            WidthDataGrid2();
            Hidden_pupup();
        }

        private void Unplanlabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HeddenHead();
            Unplanrect.Visibility = System.Windows.Visibility.Visible;
            Unplanlabel.Foreground = Brushes.White;
            unplaninset = true;
            if (web.DateSurprise())
            {
                string where = "";
                dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
            }
            else
            {
                string where = " and '1' = '2'";
                dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
            }
            WidthDataGrid();
            Hidden_pupup();
        }

        private void Searchbutton_Click(object sender, RoutedEventArgs e)
        {           
            string where = "";
            if (Name1.Text != "")
            {
                where += " and Employees.Surname = N'" + Name1.Text + "' ";
            }
            if (Name2.Text != "")
            {
                where += " and Employees.Name = N'" + Name2.Text + "' ";
            }
            if (Workbook1.Text != "")
            {
                where += " and Employees.Number_workbook like '%" + Workbook1.Text + "%' ";
            }
            if (it != true || r != true)
            {
                if (it) where += " and Employees.Id_speciality = 901 ";
                if (r) where += " and Employees.Id_speciality = 902 ";
            }
            if (planinset) { where += " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) "; }
            if (reinset) { where += " and (Employees.Validation_duty_AP = 1 or Employees.Validation_duty_ES = 1) "; }
            if (requestinset) { where += "and Workbook.Want_rise = 1 "; }
            if (!requestinset)
            {
                dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
                WidthDataGrid();
            }
            else { dataGrid1.ItemsSource = web.WA_ValidationRequest(where).DefaultView; WidthDataGrid2(); }
            Hidden_pupup();
        }

        private void Searchbutton1_Click(object sender, RoutedEventArgs e)
        {
            string where = "";
            if (Name3.Text != "")
            {
                where += " and Employees.Surname = N'" + Name3.Text + "' ";
            }
            if (Name4.Text != "")
            {
                where += "and Employees.Name = N'" + Name4.Text + "' ";
            }
            if (Workbook2.Text != "")
            {
                where += " and Employees.Number_workbook like '%" + Workbook2.Text + "%' ";
            }
            if (it1 != true || r1 != true)
            {
                if (it1) where += " and Employees.Id_speciality = 901 ";
                if (r1) where += " and Employees.Id_speciality = 902 ";
            }            
            dataGrid2.ItemsSource = web.WA_Validation(where).DefaultView;
            pop_up_window1.Visibility = Visibility.Hidden;
        }
        public bool it1 = true, r1 = true;
        private void Alllabel_Copy13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!it1)
            {
                it1 = true; itrect1.Visibility = Visibility.Visible;
                Alllabel_Copy13.Foreground = Brushes.White;
            }
            else
            {
                Alllabel_Copy13.Foreground = Brushes.Black;
                it1 = false; itrect1.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        private void exitchangeplan_Click(object sender, RoutedEventArgs e)
        {
            changeplan.Visibility = Visibility.Hidden;
        }
        private void exitchangere_Click(object sender, RoutedEventArgs e)
        {
            changere.Visibility = Visibility.Hidden;
        }
        private void exitchangerequest_Click(object sender, RoutedEventArgs e)
        {
            changerequest.Visibility = Visibility.Hidden;
        }

        private void exitchangeunplan_Click(object sender, RoutedEventArgs e)
        {
            changeunplan.Visibility = Visibility.Hidden;
        }         

        #region  //заполнение комбобоксов
        public void WriteComboBox(ComboBox cb1, ComboBox cb2, ComboBox cb3)
        {
            DataSet ds = web.Fill_Commission("1");
            DataTable tb = ds.Tables[0];
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string str = tb.Rows[i][2].ToString().Trim() + " " + tb.Rows[i][0].ToString().Trim() + " " + tb.Rows[i][1].ToString().Trim();
                ListBoxItem l1 = new ListBoxItem();
                l1.Content = str;
                l1.Uid = tb.Rows[i][3].ToString();
                cb1.Items.Add(l1);
            }
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string str = tb.Rows[i][2].ToString().Trim() + " " + tb.Rows[i][0].ToString().Trim() + " " + tb.Rows[i][1].ToString().Trim();
                ListBoxItem l1 = new ListBoxItem();
                l1.Content = str;
                l1.Uid = tb.Rows[i][3].ToString();
                cb2.Items.Add(l1);
            }

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string str = tb.Rows[i][2].ToString().Trim() + " " + tb.Rows[i][0].ToString().Trim() + " " + tb.Rows[i][1].ToString().Trim();
                ListBoxItem l1 = new ListBoxItem();
                l1.Content = str;
                l1.Uid = tb.Rows[i][3].ToString();
                cb3.Items.Add(l1);
            }
        }

        private void Planbutton_Click(object sender, RoutedEventArgs e)
        {
            changeplan.Visibility = Visibility.Visible;            
        }

        private void Rebutton_Click(object sender, RoutedEventArgs e)
        {
            changere.Visibility = Visibility.Visible;            
        }

        private void Requestbutton_Click(object sender, RoutedEventArgs e)
        {
            changerequest.Visibility = Visibility.Visible;            
        }

        private void Unplanbutton_Click(object sender, RoutedEventArgs e)
        {
            changeunplan.Visibility = Visibility.Visible;           
        }

        
        #endregion

        #region //кнопки в поиске
        private void Alllabel_Copy14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!r1)
            {
                Alllabel_Copy14.Foreground = Brushes.White;
                r1 = true; rrect1.Visibility = Visibility.Visible;
            }
            else
            {
                Alllabel_Copy14.Foreground = Brushes.Black;
                r1 = false; rrect1.Visibility = Visibility.Hidden;
            }
        }

        public bool it = true, r = true;       

        private void ErrorOk_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ErrorMessage.Visibility = Visibility.Hidden;
        }      

        private void Alllabel_Copy6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!it)
            {
                it = true; itrect.Visibility = Visibility.Visible;
                Alllabel_Copy6.Foreground = Brushes.White;
            }
            else
            {
                Alllabel_Copy6.Foreground = Brushes.Black;
                it = false; itrect.Visibility = Visibility.Hidden;
            }
        }
        
        private void Alllabel_Copy7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!r)
            {
                Alllabel_Copy7.Foreground = Brushes.White;
                r = true; rrect.Visibility = Visibility.Visible;
            }
            else
            {
                Alllabel_Copy7.Foreground = Brushes.Black;
                r = false; rrect.Visibility = Visibility.Hidden;
            }
        }



        #endregion


        #region // кнопки на проведении аттестации
        public void SelectDateAndCommission(string comm, string date1, string date2,
            ComboBox cb1, ComboBox cb2, ComboBox cb3)
        {
            ListBoxItem l1 = (ListBoxItem)cb1.SelectedItem;
            string a1 = l1.Uid.ToString();
            ListBoxItem l2 = (ListBoxItem)cb2.SelectedItem;
            string a2 = l2.Uid.ToString();
            ListBoxItem l3 = (ListBoxItem)cb3.SelectedItem;
            string a3 = l3.Uid.ToString();

            if (comm == "Plan")
            {
                web.ApproveAttestation("PlanV");
                web.ApproveDataDelete("PlanV");
                if (isdateplanatt)
                {
                    web.ApproveAttestationPlan(date1, date2);
                }
                web.ApproveData(a1, "PlanV");
                web.ApproveData(a2, "PlanV");
                web.ApproveData(a3, "PlanV");
            }
            else if (comm == "Re")
            {
                web.ApproveAttestation("Re");
                web.ApproveDataDelete("Re");
                web.ApproveAttestationRe(date1, date2);

                web.ApproveData(a1, "Re");
                web.ApproveData(a2, "Re");
                web.ApproveData(a3, "Re");
            }
            else if (comm == "Request")
            {
                web.ApproveAttestation("Request");
                web.ApproveDataDelete("Request");
                web.ApproveAttestationRequest(date1);

                web.ApproveData(a1, "Request");
                web.ApproveData(a2, "Request");
                web.ApproveData(a3, "Request");
            }
            else if (comm == "UnPlan")
            {
                web.ApproveAttestation("UnPlan");
                web.ApproveDataDelete("UnPlan");
                web.ApproveAttestationUnPlan(date1, date2);

                web.ApproveData(a1, "UnPlan");
                web.ApproveData(a2, "UnPlan");
                web.ApproveData(a2, "UnPlan");
            }            
        }

       
       

        private void ApplyPlanbutton_Click(object sender, RoutedEventArgs e)
        {
            if (attestationplan1.SelectedIndex != -1 && attestationplan2.SelectedIndex != -1 
                && attestationplan3.SelectedIndex != -1 )               
            {
                string date1 = "", date2 = "";
                if (isdateplanatt)
                {
                    if (dd1plan.SelectedIndex != -1 && mm1plan.SelectedIndex != -1 && yy1plan.SelectedIndex != -1
                        && dd2plan.SelectedIndex != -1 && mm2plan.SelectedIndex != -1 && yy2plan.SelectedIndex != -1)
                    {
                        date1 = Convert.ToInt32(mm1plan.SelectedIndex + 1).ToString() +
                            "-" + Convert.ToInt32(dd1plan.SelectedIndex + 1).ToString() +
                            "-" + Convert.ToInt32(yy1plan.SelectedIndex + 2016).ToString();
                        date2 = Convert.ToInt32(mm2plan.SelectedIndex + 1).ToString() +
                            "-" + Convert.ToInt32(dd2plan.SelectedIndex + 1).ToString() +
                            "-" + Convert.ToInt32(yy2plan.SelectedIndex + 2016).ToString();
                        SelectDateAndCommission("Plan", date1, date2, attestationplan1, attestationplan2, attestationplan3);
                        changeplan.Visibility = Visibility.Hidden;

                        AppointDate();
                        Commission(PlanMember1, PlanMember2, PlanMember3, PlanGov, "PlanV");
                    }
                    else ErrorMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    SelectDateAndCommission("Plan", date1, date2, attestationplan1, attestationplan2, attestationplan3);
                    changeplan.Visibility = Visibility.Hidden;

                    AppointDate();
                    Commission(PlanMember1, PlanMember2, PlanMember3, PlanGov, "PlanV");
                }
                    
            }
            else ErrorMessage.Visibility = Visibility.Visible;          
        }
        private void ApplyRebutton_Click(object sender, RoutedEventArgs e)
        {
            if (attestationre1.SelectedIndex != -1 && attestationre2.SelectedIndex != -1 && attestationre3.SelectedIndex != -1
                && dd1re.SelectedIndex != -1 && mm1re.SelectedIndex != -1 && yy1re.SelectedIndex != -1
                && dd2re.SelectedIndex != -1 && mm2re.SelectedIndex != -1 && yy2re.SelectedIndex != -1)
            {
                string date1 = "", date2 = "";
                date1 = Convert.ToInt32(mm1re.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(dd1re.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(yy1re.SelectedIndex + 2016).ToString();
                date2 = Convert.ToInt32(mm2re.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(dd2re.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(yy2re.SelectedIndex + 2016).ToString();
                SelectDateAndCommission("Re", date1, date2, attestationre1, attestationre2, attestationre3);
                changere.Visibility = Visibility.Hidden;

                AppointDate();
                Commission(ReMember1, ReMember2, ReMember3, ReGov, "Re");
            }
            else ErrorMessage.Visibility = Visibility.Visible;
        }
        private void ApplyRequestbutton_Click(object sender, RoutedEventArgs e)
        {
            if (attestationrequest1.SelectedIndex != -1 && attestationrequest2.SelectedIndex != -1 && attestationrequest3.SelectedIndex != -1
                && dd1request.SelectedIndex != -1 && mm1request.SelectedIndex != -1 && yy1request.SelectedIndex != -1)
            {
                string date1 = "", date2 = "";
                date1 = Convert.ToInt32(mm1request.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(dd1request.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(yy1request.SelectedIndex + 2016).ToString();                
                SelectDateAndCommission("Request", date1, date2, attestationrequest1, attestationrequest2, attestationrequest3);
                changerequest.Visibility = Visibility.Hidden;

                AppointDate();
                Commission(RequestMember1, RequestMember2, RequestMember3, "Request");
            }
            else ErrorMessage.Visibility = Visibility.Visible;
        }
        private void ApplyUnplanbutton_Click(object sender, RoutedEventArgs e)
        {
            if (attestationunplan1.SelectedIndex != -1 && attestationunplan2.SelectedIndex != -1 && attestationunplan3.SelectedIndex != -1
                && dd1unplan.SelectedIndex != -1 && mm1unplan.SelectedIndex != -1 && yy1unplan.SelectedIndex != -1
                && dd2unplan.SelectedIndex != -1 && mm2unplan.SelectedIndex != -1 && yy2unplan.SelectedIndex != -1)
            {
                string date1 = "", date2 = "";
                date1 = Convert.ToInt32(mm1unplan.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(dd1unplan.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(yy1unplan.SelectedIndex + 2016).ToString();
                date2 = Convert.ToInt32(mm2unplan.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(dd2unplan.SelectedIndex + 1).ToString() +
                    "-" + Convert.ToInt32(yy2unplan.SelectedIndex + 2016).ToString();
                SelectDateAndCommission("UnPlan", date1, date2, attestationunplan1, attestationunplan2, attestationunplan3);
                changeunplan.Visibility = Visibility.Hidden;

                AppointDate();
                Commission(UnplanMember1, UnplanMember2, UnplanMember3, "UnPlan");
            }
            else ErrorMessage.Visibility = Visibility.Visible;
        }
        #endregion

        private void CLose1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pop_up_window1.Visibility = Visibility.Hidden;
        }
        public string[] array1 = new string[14];
        public string[] array2 = new string[6];
        public string[] array3 = new string[5];
        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string c = "";
            try
            {
                c = Convert.ToString(((DataRowView)dataGrid2.SelectedItem)[0]);
                web.ProFile(c, ref array1, ref array2, ref array3);

                VisibilityAttestation(ValidPLan1, "Validation_AP", c);
                VisibilityAttestation(ValidPLan2, "Validation_ES", c);
                VisibilityAttestation(ValidRe1, "Validation_duty_AP", c);
                VisibilityAttestation(ValidRe2, "Validation_duty_ES", c);
            }
            catch (NullReferenceException ex)
            {

            }

            LNlabel.Content = c; //логин
            Workbooklabel.Content = array1[7]; //рабочая книжка
            DateTime date1 = Convert.ToDateTime(array3[0]);
            Datelabel.Content = date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")); //дата поступления на предприятие
            date1 = Convert.ToDateTime(array3[1]);
            Explabel.Content = (DateTime.Now.Year - date1.Year).ToString() + " лет/год(а)"; // стаж ан должности
            if (array1[5] == "901")     //специальность
            { Speclabel.Content = "Инженерно-технический сотрудник"; }
            else if (array1[5] == "902") Speclabel.Content = "Рядовой сотрудник" + "   Разряд: " + array1[6];
            FIO.Content = array1[3].Trim() + " " + array1[2].Trim() + " " + array1[4].Trim();   //ФИО
            date1 = Convert.ToDateTime(array3[3]);
            Burthlabel.Content = date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));        //день рождения
            Burthlabel.Content+= "     Полных лет:"+ (DateTime.Now.Year - date1.Year).ToString();
            Addresslabel.Content = array1[13];
            Phonelabel.Content = array1[12];
            Maillabel.Content = array1[11];
           
            pop_up_window1.Visibility = Visibility.Visible;
        }
        public void VisibilityAttestation(Button bt, string column, string id)
        {
            if (web.WA_Duty(column, id))
            {
                bt.Visibility = Visibility.Hidden;
            }
            else bt.Visibility = Visibility.Visible;
        }
       

        public void SetPLanReRequestUnplan(Label l1, Label l2, Label l3, Label l4, Label l5, Label FIO, string login)
        {
            FIO.Content = array1[3].Trim() + " " + array1[2].Trim() + " " + array1[4].Trim();   //ФИО
            l1.Content = login; //логин
            l2.Content = array1[7]; //рабочая книжка
            DateTime date1 = Convert.ToDateTime(array3[0]);
            l4.Content = date1.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")); //дата поступления на предприятие
            date1 = Convert.ToDateTime(array3[1]);
            l5.Content = (DateTime.Now.Year - date1.Year).ToString() + " лет/год(а)"; // стаж ан должности
            if (array1[5] == "901")     //специальность
            { l3.Content = "Инженерно-технический сотрудник"; }
            else if (array1[5] == "902") l3.Content = "Рядовой сотрудник" + "   Разряд: " + array1[6];
        }

        

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string c = "";
            try
            {
                c = Convert.ToString(((DataRowView)dataGrid1.SelectedItem)[0]);
                web.ProFile(c, ref array1, ref array2, ref array3);               
            }
            catch (NullReferenceException ex)
            {
               
            }
            if (planinset)
            {
                SetPLanReRequestUnplan(LNplanre, Workbookplanre, Specplanre, Dateplanre, Expplanre, FIO1, c);
                try
                {
                    VisibilityAttestationButton(ValidPlanre1, "Validation_AP", c);
                    VisibilityAttestationButton(ValidPlanre2, "Validation_ES", c);
                    VisibilityAttestation(ValidPlanre3, "Validation_duty_AP", c);
                    VisibilityAttestation(ValidPlanre4, "Validation_duty_ES", c);
                }
                catch { }
                pop_up_planandre.Visibility = Visibility.Visible;
            }
            else if (reinset)
            {
                SetPLanReRequestUnplan(LNplanre, Workbookplanre, Specplanre, Dateplanre, Expplanre, FIO1, c);
                try
                {
                    VisibilityAttestationButton(ValidPlanre1, "Validation_duty_AP", c);
                    VisibilityAttestationButton(ValidPlanre2, "Validation_duty_ES", c);
                    ValidPlanre3.Visibility = Visibility.Hidden;
                    ValidPlanre4.Visibility = Visibility.Hidden;
                }
                catch { }
                pop_up_planandre.Visibility = Visibility.Visible;
            }
            else if (unplaninset)
            {
                SetPLanReRequestUnplan(LNunplan, Workbookunplan, Specunplan, Dateunplan, Expunplan, FIO2, c);
                try
                {
                    VisibilityAttestation(ValidUnplan1, "Validation_duty_AP", c);
                    VisibilityAttestation(ValidUnplan2, "Validation_duty_ES", c);                    
                }
                catch { }
                pop_up_unplan.Visibility = Visibility.Visible;
            }
            else if (requestinset)
            {
                textBlock.Text = "";
                textBlock.Text += "Достижения и награды: " + Environment.NewLine + array1[9];       //достижения
                textBlock.Text += Environment.NewLine + Environment.NewLine;
                textBlock.Text += "Выговоры:" + Environment.NewLine + array1[10];      //выговоры                   

                SetPLanReRequestUnplan(LNrequest, Workbookrequest, Specrequest, DateRequest, Exprequest, FIO3, c);
                pop_up_request.Visibility = Visibility.Visible;
            }
        }
        private void Closeplanre_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pop_up_planandre.Visibility = Visibility.Hidden;
        }

        private void Closeunplan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            pop_up_unplan.Visibility = Visibility.Hidden;
        }
        #region //кнопки окна плановой и поторной аттестаций
        private void ValidPlanre1_Click(object sender, RoutedEventArgs e)
        {
            if (planinset)
            {
                web.WA_UpdateDuty("Employees", "Validation_AP = 0", "Id_employees = " + LNplanre.Content.ToString());
                ValidPlanre1.Visibility = Visibility.Hidden;

                if (!web.WA_Duty("Validation_ES", LNplanre.Content.ToString()) &&
                    !web.WA_Duty("Validation_AP", LNplanre.Content.ToString()))
                {
                    string where = " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) ";
                    dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
                    pop_up_planandre.Visibility = Visibility.Hidden;
                }
            }
            else if (reinset)
            {
                web.WA_UpdateDuty("Employees", "Validation_duty_AP = 0", "Id_employees = " + LNplanre.Content.ToString());
                ValidPlanre1.Visibility = Visibility.Hidden;

                if (!web.WA_Duty("Validation_duty_ES", LNplanre.Content.ToString()) &&
                    !web.WA_Duty("Validation_duty_AP", LNplanre.Content.ToString()))
                {
                    string where = " and (Employees.Validation_duty_AP = 1 or Employees.Validation_duty_ES = 1) ";
                    dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
                    pop_up_planandre.Visibility = Visibility.Hidden;
                }
            }            
        }

        private void ValidPlanre2_Click(object sender, RoutedEventArgs e)
        {
            if (planinset)
            {
                web.WA_UpdateDuty("Employees", "Validation_ES = 0", "Id_employees = " + LNplanre.Content.ToString());
                ValidPlanre2.Visibility = Visibility.Hidden;

                if (!web.WA_Duty("Validation_ES", LNplanre.Content.ToString()) &&
                    !web.WA_Duty("Validation_AP", LNplanre.Content.ToString()))
                {
                    string where = " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) ";
                    dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
                    pop_up_planandre.Visibility = Visibility.Hidden;
                }

            }
            else if (reinset)
            {
                web.WA_UpdateDuty("Employees", "Validation_duty_ES = 0", "Id_employees = " + LNplanre.Content.ToString());
                ValidPlanre1.Visibility = Visibility.Hidden;

                if (!web.WA_Duty("Validation_duty_ES", LNplanre.Content.ToString()) &&
                    !web.WA_Duty("Validation_duty_AP", LNplanre.Content.ToString()))
                {
                    string where = " and (Employees.Validation_duty_AP = 1 or Employees.Validation_duty_ES = 1) ";
                    dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
                    pop_up_planandre.Visibility = Visibility.Hidden;
                }
            }                
        }
        private void ValidPlanre3_Click(object sender, RoutedEventArgs e)
        {
            web.WA_UpdateDuty("Employees", "Validation_duty_AP = 1, Validation_AP = 0 ", "Id_employees = " + LNplanre.Content.ToString());
            ValidPlanre3.Visibility = Visibility.Hidden;
            ValidPlanre1.Visibility = Visibility.Hidden;

            if (!web.WA_Duty("Validation_ES", LNplanre.Content.ToString()) &&
                    !web.WA_Duty("Validation_AP", LNplanre.Content.ToString()))
            {
                string where = " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) ";
                dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
                pop_up_planandre.Visibility = Visibility.Hidden;
            }
        }       
        private void ValidPlanre4_Click(object sender, RoutedEventArgs e)
        {
            web.WA_UpdateDuty("Employees", "Validation_duty_ES = 1, Validation_ES = 0 ", "Id_employees = " + LNplanre.Content.ToString());
            ValidPlanre4.Visibility = Visibility.Hidden;
            ValidPlanre2.Visibility = Visibility.Hidden;

            if (!web.WA_Duty("Validation_ES", LNplanre.Content.ToString()) &&
                    !web.WA_Duty("Validation_AP", LNplanre.Content.ToString()))
            {
                string where = " and (Employees.Validation_AP = 1 or Employees.Validation_ES = 1) ";
                dataGrid1.ItemsSource = web.WA_Validation(where).DefaultView;
                pop_up_planandre.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        #region //кнопки внеплановой аттестации
        private void ValidUnplan1_Click(object sender, RoutedEventArgs e)
        {
            web.WA_UpdateDuty("Employees", "Validation_duty_AP = 1", "Id_employees = " + LNunplan.Content.ToString());
            ValidUnplan1.Visibility = Visibility.Hidden;
        }

        private void ValidUnplan2_Click(object sender, RoutedEventArgs e)
        {
            web.WA_UpdateDuty("Employees", "Validation_duty_ES = 1", "Id_employees = " + LNunplan.Content.ToString());
            ValidUnplan2.Visibility = Visibility.Hidden;
        }
        #endregion
        public void VisibilityAttestationButton(Button bt, string column, string id)
        {
            if (!web.WA_Duty(column, id))
            {
                bt.Visibility = Visibility.Hidden;
            }
            else bt.Visibility = Visibility.Visible;
        }
        //вывод сообщения об успешности действий
        public void Message(string a)
        {
            alabel.Text = a;
            Success.Visibility = Visibility.Visible;
        }
        private void CloseSuccess_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Success.Visibility = Visibility.Hidden;
        }
        #region //кнопки аттестации на повышение разряда
        private void Closerequest_HR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HonorAndReproof.Visibility = Visibility.Hidden;
        }

        private void VisibleHonorAndReproof_Click(object sender, RoutedEventArgs e)
        {
            HonorAndReproof.Visibility = Visibility.Visible;
        }
        #endregion
        private void IncreaseRank_Click(object sender, RoutedEventArgs e)
        {
            string rank = "";
            if (array1[6] == "5") rank = "master";
            else rank = (Convert.ToInt32(array1[6]) + 1).ToString();
            web.WA_ReportRequest(LNrequest.Content.ToString());
            web.WA_UpdateDuty("Workbook", 
                "Want_rise = 0, Want_date = NULL, Register_rise = 0, Register_date = NULL, Employment_rank = GETDATE()", 
                "Number_workbook = '" + array1[7] + "'");
            web.WA_UpdateDuty("Employees", "Rank = '" + rank + "'",
                "Number_workbook = '" + array1[7] + "'");
            
            string where = "and Workbook.Want_rise = 1 ";
            dataGrid1.ItemsSource = web.WA_ValidationRequest(where).DefaultView;
            WidthDataGrid2();
            pop_up_request.Visibility = Visibility.Hidden;

            Message("Повышение разряда выбранного сотрудника было произведено");
        }

        private void Rejectrise_Click(object sender, RoutedEventArgs e)
        {
            web.WA_UpdateDuty("Workbook", "Want_rise = 0, Want_date = NULL, Register_rise = 0, Register_date = NULL",
                "Number_workbook = '" + array1[7] + "'");
            web.WA_ReportRequest(LNrequest.Content.ToString());
            string where = "and Workbook.Want_rise = 1 ";
            dataGrid1.ItemsSource = web.WA_ValidationRequest(where).DefaultView;
            WidthDataGrid2();
            pop_up_request.Visibility = Visibility.Hidden;
            Message("В повышении разряда данному сотруднику было отказано");
        }
        #region //назначение аттестации всем сотрудникам
        string authomatickwhere = "1=1";
        private void Allordinary_Click(object sender, RoutedEventArgs e)
        {            
            AutomatickValid.Visibility = Visibility.Visible;
            authomatickwhere = "Id_speciality = 902";
        }

        private void AllEmployees_Click(object sender, RoutedEventArgs e)
        {
            authomatickwhere = "1=1";
            AutomatickValid.Visibility = Visibility.Visible;
        }
        private void ValidAutomatCancel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AutomatickValid.Visibility = Visibility.Hidden;
        }

        private void ValidAutomatOk_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            web.WA_UpdateDuty("Employees", "Validation_AP = 1", authomatickwhere);
            AutomatickValid.Visibility = Visibility.Hidden;
        }
        #endregion
        

        private void Closerequest_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pop_up_request.Visibility = Visibility.Hidden;
        }
        
        //назначение кнопок во вкладке назначение аттестации
        private void ValidPLan1_Click(object sender, RoutedEventArgs e)
        {            
            web.WA_UpdateDuty("Employees","Validation_AP = 1", "Id_employees = " + LNlabel.Content.ToString());
            ValidPLan1.Visibility = Visibility.Hidden;
        }
        private void ValidPLan2_Click(object sender, RoutedEventArgs e)
        {
            web.WA_UpdateDuty("Employees", "Validation_ES = 1", "Id_employees = " + LNlabel.Content.ToString());
            ValidPLan2.Visibility = Visibility.Hidden;
        }
        private void ValidRe1_Click(object sender, RoutedEventArgs e)
        {
            web.WA_UpdateDuty("Employees", "Validation_duty_AP = 1", "Id_employees = " + LNlabel.Content.ToString());
            ValidRe1.Visibility = Visibility.Hidden;
        }
        private void ValidRe2_Click(object sender, RoutedEventArgs e)
        {
            web.WA_UpdateDuty("Employees", "Validation_duty_ES = 1", "Id_employees = " + LNlabel.Content.ToString());
            ValidRe2.Visibility = Visibility.Hidden;
        }

        private void Log_Copy1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            web.WA_Delete();
            if (collection == null)
            {
                collection = new ObservableCollection<FillDataGrid>();
                dataGrid3.ItemsSource = collection;
            }
            DataTable table = new DataTable();
            table = web.SelectLog();
            collection.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                collection.Add(
                    new FillDataGrid()
                    {
                        first = table.Rows[i][0].ToString(),
                        second = table.Rows[i][1].ToString(),
                        third = table.Rows[i][2].ToString()
                    }
                    );
            }
        }

       

        #region
        public void ReportShow(string message,bool bl)
        {
            if (bl)
            {
                Report report = new Report();
                report.att = message;
                report.bl = bl;
                report.Show();
            }
            else
            {
                Request request = new Request();
                request.att = message;
                request.bl = bl;
                request.Show();
            }   
        }

        private void EndPlanbutton_Click(object sender, RoutedEventArgs e)
        {
            string message = "плановой аттестации";
            ReportShow(message, true);
        }
        private void EndRebutton_Click(object sender, RoutedEventArgs e)
        {
            string message = "повторной аттестации";
            ReportShow(message,true);
        }

        private void EndRequestbutton_Click(object sender, RoutedEventArgs e)
        {
            string message = "аттестации на повышение разряда";
            ReportShow(message,false);
        }

        private void EndUnplanbutton_Click(object sender, RoutedEventArgs e)
        {
            string message = "внеплановой аттестации";
            ReportShow(message,true);
        }
        #endregion

        //изменение даты плановой аттестации
        public bool isdateplanatt = false;
        private void Attestationlabel_Copy63_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DateAttPlan1.Visibility = Visibility.Hidden;
            PlanDate.Visibility = Visibility.Visible;
            isdateplanatt = true;
        }
        private void Attestationlabel_Copy64_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlanDate.Visibility = Visibility.Hidden;
            DateAttPlan1.Visibility = Visibility.Visible;
            isdateplanatt = false;
        }
    }
}
