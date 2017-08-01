using System;
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
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        Web_Service.Validation web = new Web_Service.Validation();
        public Request()
        {
            InitializeComponent();
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
        ObservableCollection<FillRequest> collection = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label.Content = "Отчет о проведении " + att;
            //dataGrid1.ItemsSource = web.WA_EndAttestation(bl).DefaultView;
            if (collection == null)
            {
                collection = new ObservableCollection<FillRequest>();
                dataGrid1.ItemsSource = collection;
            }
            DataTable table = new DataTable();
            table = web.WA_EndAttestation(bl);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                collection.Add(
                    new FillRequest()
                    {
                        Ln = table.Rows[i][0].ToString(),
                        Fio = table.Rows[i][1].ToString().Trim() + " "
                        + table.Rows[i][2].ToString().Trim() + " "
                        + table.Rows[i][3].ToString().Trim(),
                        Kd = table.Rows[i][4].ToString(),
                        Rn = table.Rows[i][5].ToString(),
                        Rc = table.Rows[i][6].ToString(),                       
                    }
                    );
            }
        }

        private void OverAttestation_Click(object sender, RoutedEventArgs e)
        {
            if (bl)
            {
                if (att == "плановой аттестации")
                {
                    web.ApproveDataDelete("PlanV");
                    web.OverAttestation("Speciality",
                        "Every_validation_AP = DATEADD(yy, 1, Every_validation_AP), Every_validation_ES = DATEADD(yy, 1, Every_validation_ES)");
                }
                else if (att == "повторной аттестации")
                {
                    web.ApproveDataDelete("Re");
                    web.OverAttestation(" Repeated_Validation ", " Bee = 0, Date1 = NULL, Date2= NULL");
                }
                else if (att == "внеплановой аттестации")
                {
                    web.ApproveDataDelete("UnPlan");
                    web.OverAttestation(" Surprise_Validation ", " Bee = 0, Date1 = NULL, Date2= NULL");
                }
            }
            else
            {
                web.ApproveDataDelete("Request");
                web.OverAttestation("Workbook", " Register_rise = 0, Register_date = NULL");
            }
        }
    }
}
