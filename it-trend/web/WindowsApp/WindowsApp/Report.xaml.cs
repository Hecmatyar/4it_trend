﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Shapes;

namespace WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        Web_Service.Validation web = new Web_Service.Validation();
        public Report()
        {
            InitializeComponent();            
        }               

        private void dataGrid1_AutoGeneratedColumns(object sender, EventArgs e)
        {
            //    dataGrid1.Columns[0].Width = 120;
            //    dataGrid1.Columns[1].Width = 100;
            //    dataGrid1.Columns[2].Width = 100;
            //    dataGrid1.Columns[3].Width = 105;
            //    dataGrid1.Columns[4].Width = 230;
            //    dataGrid1.Columns[5].Width = 120;
        }
        public string att = "";
        public bool bl = true;
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog printdialog = new System.Windows.Controls.PrintDialog();
            if ((bool)printdialog.ShowDialog().GetValueOrDefault())
            {
                Size pagesize = new Size(printdialog.PrintableAreaWidth, printdialog.PrintableAreaHeight);
                dataGrid1.Measure(pagesize);
                dataGrid1.Arrange(new Rect(5, 5, pagesize.Width, pagesize.Height));
                printdialog.PrintVisual(dataGrid1, Title);
            }
        }
        ObservableCollection<FillReport> collection = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label.Content = "Отчет о проведении " + att;
            //dataGrid1.ItemsSource = web.WA_EndAttestation(bl).DefaultView;
            if (collection == null)
            {
                collection = new ObservableCollection<FillReport>();
                dataGrid1.ItemsSource = collection;
            }
            DataTable table = new DataTable();
            table = web.WA_EndAttestation(bl);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                collection.Add(
                    new FillReport()
                    {
                        Ln = table.Rows[i][0].ToString(),
                        Fio = table.Rows[i][1].ToString().Trim() +" "
                        + table.Rows[i][2].ToString().Trim() + " "
                        + table.Rows[i][3].ToString().Trim(),
                        Kd = table.Rows[i][4].ToString(),
                        Sp = table.Rows[i][5].ToString(),
                        Ap = table.Rows[i][6].ToString(),
                        Es = table.Rows[i][7].ToString()
                    }
                    );
            }           
        }

        private void OverAttestation_Click(object sender, RoutedEventArgs e)
        {
            //Report report = new Report();
            //report.att = message;
            //report.bl = bl;
            //report.Show();4
            if (bl)
            {
                if (att == "плановой аттестации")
                {
                    web.ApproveAttestationReverse("PlanV");
                    web.ApproveDataDelete("PlanV");
                    web.OverAttestation("Speciality", "Every_validation_AP = DATEADD(yy, 1, Every_validation_AP), Every_validation_ES = DATEADD(yy, 1, Every_validation_ES)");
                }
                else if (att == "повторной аттестации")
                {
                    web.ApproveAttestationReverse("Re");
                    web.ApproveDataDelete("Re");
                    //web.OverAttestation(" Repeated_Validation ", " Bee = 0, Date1 = NULL, Date2= NULL");
                    web.OverAttestation(" Repeated_Validation ", " Bee = 0");
                }
                else if (att == "внеплановой аттестации")
                {
                    web.ApproveAttestationReverse("UnPlan");
                    web.ApproveDataDelete("UnPlan");
                    //web.OverAttestation(" Surprise_Validation ", " Bee = 0, Date1 = NULL, Date2= NULL");
                    web.OverAttestation(" Surprise_Validation ", " Bee = 0");
                }
            }
            else
            {
                web.ApproveAttestationReverse("Request");
                web.ApproveDataDelete("Request");
                //web.OverAttestation("Workbook", " Register_rise = 0, Register_date = NULL");
                web.OverAttestation("Workbook", " Register_rise = 0, Register_date = NULL");
            }
        }
    }
}
