using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Zero_2.Page
{
    public partial class Approve : System.Web.UI.Page
    {
        public string comm;
        localhost.Validation lhv = new localhost.Validation();
        protected void Pre_Init(object sender, EventArgs e)
        {
            //HtmlSelect hts = Page.FindControl("")
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //try { Label19.Text = "|"+(string)Session["index"] + "|"; }
            //catch { }

            Label17.Text = lhv.Government();
            if (!IsPostBack)
            {
                int val = 0;
                //значения по умолчанию
                ListItem li = new ListItem("Не назначен", val.ToString(), true);
                DrList1.Items.Add(li);
                DrList2.Items.Add(li);
                DrList3.Items.Add(li);

                localhost.Validation a = new localhost.Validation();
                DataSet ds = a.Fill_Commission("1");
                DataTable tb = ds.Tables[0];

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //DrList2.Items.Add(tb.Rows[i][0].ToString() + " " + tb.Rows[i][1].ToString() + " " + tb.Rows[i][2].ToString());
                    //DrList3.Items.Add(tb.Rows[i][0].ToString() + " " + tb.Rows[i][1].ToString() + " " + tb.Rows[i][2].ToString());
                    string str = tb.Rows[i][0].ToString() + " " + tb.Rows[i][1].ToString() + " " + tb.Rows[i][2].ToString();
                    ListItem l = new ListItem(str, tb.Rows[i][3].ToString(), true);
                    DrList1.Items.Add(l);
                    DrList2.Items.Add(l);
                    DrList3.Items.Add(l);
                }
            }           
            comm = (string)Session["commissionpage"];
            if (comm == "ConductingPage_Plan")
            {                
                Label3.Text = "Плановая аттестация";
                this.DropDownList1.Style.Add("display", "none");
                this.DropDownList2.Style.Add("display", "none");
                this.DropDownList3.Style.Add("display", "none");
                this.DropDownList4.Style.Add("display", "none");
                this.DropDownList5.Style.Add("display", "none");
                this.DropDownList6.Style.Add("display", "none");
                this.Label24.Style.Add("display", "none");
                this.Label23.Style.Add("display", "none");
                this.Label22.Style.Add("display", "none");
            }
            else if (comm == "ConductingPage_Re")
            {
                Label3.Text = "Повторная аттестация";
            }
            else if (comm == "ConductingPage_Request")
            {
                Label16.Text = "Сотрудник государственной службы по охране труда и производственной безопасности не требуется";
                this.Label17.Style.Add("display", "none");                
                Label3.Text = "Заявки на повышение разряда";
                this.DropDownList4.Style.Add("display", "none");
                this.DropDownList5.Style.Add("display", "none");
                this.DropDownList6.Style.Add("display", "none");
                this.Label24.Style.Add("display", "none");
                Label23.Text = "Аттестация по заявлениям";
            }
            else if (comm == "ConductingPage_UnPlan")
            {
                Label3.Text = "Внеплановая аттестация";
            }
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            comm = (string)Session["commissionpage"];
            Response.Redirect(@"~\Page\" + comm + ".aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //string selected = select123.Value.ToString();
            //Session["index"] = DrList1.SelectedValue;
            string date1 ="", date2="";
            date1 = DropDownList2.Text + "-" + DropDownList1.Text + "-" + DropDownList3.Text;
            date2 = DropDownList5.Text + "-" + DropDownList4.Text + "-" + DropDownList6.Text;
            comm = (string)Session["commissionpage"];
            if (comm == "ConductingPage_Plan")
            {
                lhv.ApproveAttestation("PlanV");
                lhv.ApproveDataDelete("PlanV");

                lhv.ApproveData(DrList1.SelectedValue, "PlanV");
                lhv.ApproveData(DrList2.SelectedValue, "PlanV");
                lhv.ApproveData(DrList3.SelectedValue, "PlanV");
            }
            else if (comm == "ConductingPage_Re")
            {
                lhv.ApproveAttestation("Re");
                lhv.ApproveDataDelete("Re");
                lhv.ApproveAttestationRe(date1,date2);

                lhv.ApproveData(DrList1.SelectedValue, "Re");
                lhv.ApproveData(DrList2.SelectedValue, "Re");
                lhv.ApproveData(DrList3.SelectedValue, "Re");
            }
            else if (comm == "ConductingPage_Request")
            {
                lhv.ApproveAttestation("Request");
                lhv.ApproveDataDelete("Request");
                lhv.ApproveAttestationRequest(date1);

                lhv.ApproveData(DrList1.SelectedValue, "Request");
                lhv.ApproveData(DrList2.SelectedValue, "Request");
                lhv.ApproveData(DrList3.SelectedValue, "Request");
            }
            else if (comm == "ConductingPage_UnPlan")
            {
                lhv.ApproveAttestation("UnPlan");
                lhv.ApproveDataDelete("UnPlan");
                lhv.ApproveAttestationUnPlan(date1, date2);

                lhv.ApproveData(DrList1.SelectedValue, "UnPlan");
                lhv.ApproveData(DrList2.SelectedValue, "UnPlan");
                lhv.ApproveData(DrList3.SelectedValue, "UnPlan");
            }
            Response.Redirect(@"~..\..\Page\" + comm + ".aspx");
        }
        protected void SelectChanged_Click1(object sender, EventArgs e)
        {
            
        }
        protected void SelectChanged_Click2(object sender, EventArgs e)
        {

        }
        protected void SelectChanged_Click3(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string Fill_Commission()
        {            
            localhost.Validation a = new localhost.Validation();
            string b = "1";
            return a.Fill_Commission(b).GetXml();
        }
    }
}