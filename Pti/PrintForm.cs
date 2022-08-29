using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastReport;

using System.IO;
using FastReport.Utils;
using FastReport.Data;

namespace Pti
{
    public partial class PrintForm : Form
    {
        Form1 frm;
        public PrintForm(Form1 frm)
        {
            InitializeComponent();
            this.frm = frm;
            
        }

        private void getData()
        {
            if (frm.korpuses != null)
                foreach (Korpus krp in frm.korpuses)
                {
                    comboBox1.Items.Add(krp.name);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                if (comboBox1.SelectedIndex >= 0)
                {
                        if (File.Exists(frm.korpuses[comboBox1.SelectedIndex].path + "\\" + dateTimePicker1.Value.ToString("MMddyyyy") + ".opr"))
                        {
                            getDataProtocol(frm.korpuses[comboBox1.SelectedIndex].path + "\\" + dateTimePicker1.Value.ToString("MMddyyyy") + ".opr", frm.korpuses[comboBox1.SelectedIndex].name);
                        }
                        else
                        {
                            MessageBox.Show("Не найден протокол за период");
                        }
                 }
                else
                    MessageBox.Show("Не выбран корпус");
            else if (radioButton2.Checked)
                try
                {
                    getDataProtocol(openFileDialog1.InitialDirectory + openFileDialog1.FileName, "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно открыть файл. Ошибка:" + ex.Message);
                }
            else if (radioButton3.Checked)
            {

                DataSet ds_full = new DataSet();
                ds_full.Tables.Add(new DataTable("protocol"));
                ds_full.Tables["protocol"].Columns.Add("EventDate", Type.GetType("System.DateTime"));
                ds_full.Tables["protocol"].Columns.Add("EventTime", Type.GetType("System.DateTime"));
                ds_full.Tables["protocol"].Columns.Add("KrpName", Type.GetType("System.String"));

                ds_full.Tables["protocol"].Columns.Add("t1_nrm", Type.GetType("System.String"));
                ds_full.Tables["protocol"].Columns.Add("t1_val", Type.GetType("System.String"));
                ds_full.Tables["protocol"].Columns.Add("t1_length", Type.GetType("System.String"));

                ds_full.Tables["protocol"].Columns.Add("t2_nrm", Type.GetType("System.String"));
                ds_full.Tables["protocol"].Columns.Add("t2_val", Type.GetType("System.String"));
                ds_full.Tables["protocol"].Columns.Add("t2_length", Type.GetType("System.String"));

                ds_full.Tables["protocol"].Columns.Add("vn_nrm", Type.GetType("System.String"));
                ds_full.Tables["protocol"].Columns.Add("vn_val", Type.GetType("System.String"));
                ds_full.Tables["protocol"].Columns.Add("vn_length", Type.GetType("System.String"));
                
                string error = "";
                
                foreach (Korpus krp in frm.korpuses)
                {
                    if (File.Exists(krp.path + "\\" + dateTimePicker2.Value.ToString("MMddyyyy") + ".opr"))
                    {
                        getDataProtocolWarning(krp.path + "\\" + dateTimePicker2.Value.ToString("MMddyyyy") + ".opr", krp, ds_full);
                    }
                    else
                    {
                        error = error + krp.name + "; ";
                    }
                }

                DataTable orders = ds_full.Tables["protocol"];
                EnumerableRowCollection<DataRow> query = null;
                DataView view = null;

                if (radioButton5.Checked)
                {
                    query = from order in orders.AsEnumerable()
                            orderby order.Field<String>("KrpName")
                            select order;
                    view = query.AsDataView();

                }
                else
                {
                    query = from order in orders.AsEnumerable()
                            orderby order.Field<DateTime>("EventTime")
                            select order;
                    view = query.AsDataView();
                }


                using (Report report = new Report())
                {
                    if (rdBtnGraph.Checked)
                    {
//                        report.Load("ProtocolWarningGraph.frx");
                        getDataProtocolWarningGraph();

                    }
                    else if (rdBtnTable.Checked)
                    {
                        report.Load("ProtocolWarning.frx");
                        report.RegisterData(view, "prot");
                        report.SetParameterValue("error", error);
                        report.Show();
                        // report.Design();
                    }
                    else
                    {
                        MessageBox.Show("Не выбран тип протокола!");
                        return;
                    }
                }

                Close();
            }
 
        }


        private void getDataProtocol(string pathProt, string nameKRP)
        {
            DataSet ds = frm.db.GetProtocolPrint(pathProt);
            RefDesc rd = frm.db.GetDescriptPrint(pathProt);

            using (Report report = new Report())
            {
                string[] splStr = pathProt.Split(new string[1] { "\\" }, StringSplitOptions.None);
                int numStr = splStr.Length - 2;
                if (nameKRP.Length == 0)
                nameKRP = splStr[numStr];

                if (rdBtnGraph.Checked)
                    report.Load("ProtocolGraphPrint.frx");
                else if (rdBtnTable.Checked)
                    report.Load("ProtocolPrint.frx");
                else
                {
                    MessageBox.Show("Не выбран тип протокола!");
                    return;
                }
                                
                report.RegisterData(ds, "parameters");
                
                report.SetParameterValue("KRPname", nameKRP);
                report.SetParameterValue("Desc", rd.masDesc);
                report.SetParameterValue("Ref", rd.masRef);
                report.SetParameterValue("CntRefs", rd.cntRefs);
                report.Show();
               // report.Design();
                
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;

                button1.Enabled = false;
                button3.Enabled = true;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;

                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                dateTimePicker2.Enabled = false;

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                getData();
                radioButton2.Checked = false;
                
                button1.Enabled = true;
                button3.Enabled = false;
                comboBox1.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = false;

                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.Enabled = true;
            }
        }

        private void rdBtnTable_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnTable.Checked)
            {
                rdBtnGraph.Checked = false;
            }
        }

        private void rdBtnGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnGraph.Checked)
            {
                rdBtnTable.Checked = false;
            }
        }



        private void getDataProtocolWarning(string pathProt, Korpus krp, DataSet ds_full)
        {
            frm.db.GetProtocolWarningPrint(pathProt, krp, ds_full);
         //   Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            //foreach (Korpus krp in frm.korpuses)
            //{
            //    if (File.Exists(krp.path + "\\" + dateTimePicker2.Value.ToString("MMddyyyy") + ".opr"))
            //    {
            //        getDataProtocolWarning(krp.path + "\\" + dateTimePicker2.Value.ToString("MMddyyyy") + ".opr", krp, ds_full);
            //    }
            //}

            //using (Report report = new Report())
            //{
            //    report.Load("ProtocolWarningGraph.frx");
            //    report.RegisterData(ds_full, "protocol");
            //    //                report.Show();
            //    report.Design();
            //}
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                dateTimePicker2.Enabled = true;
                button1.Enabled = true;
                
                button3.Enabled = false;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;

                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }





        private void getDataProtocolWarningGraph()
        {
            //DataSet ds = frm.db.GetProtocolPrint(pathProt);
            //RefDesc rd = frm.db.GetDescriptPrint(pathProt);

            using (Report report = new Report())
            {
                string pathProt = "";
                int idKrp = 0;
                int idKrpPage = 0;
                int cntKrpPage = 3;
                int cntPage = 1;
                ReportPage page1 = new ReportPage();
                DataBand db = new DataBand();

                //string[] splStr = pathProt.Split(new string[1] { "\\" }, StringSplitOptions.None);
                //int numStr = splStr.Length - 2;
                //if (nameKRP.Length == 0)
                //    nameKRP = splStr[numStr];

                //    report.Load("ProtocolWarningGraph1.frx");

                //report.RegisterData(ds, "parameters");

                //report.SetParameterValue("KRPname", nameKRP);
                //report.SetParameterValue("Desc", rd.masDesc);
                //report.SetParameterValue("Ref", rd.masRef);
                //report.SetParameterValue("CntRefs", rd.cntRefs);
                //// report.Show();
                //report.Design();

                //page1.ReportTitle = new ReportTitleBand();
                //page1.ReportTitle.Name = "rpt1";
                //page1.ReportTitle.Height = 500;
                //page1.ReportTitle.Objects.Add(msc);
                foreach (Korpus _krp in frm.korpuses)
                {
                    pathProt = _krp.path + "\\" + dateTimePicker2.Value.ToString("MMddyyyy") + ".opr";

                    KrpGraph krpgr = frm.db.GetProtocolWarningPrintGraph(pathProt, _krp);
                    if (krpgr.cntRefs == 0)
                        continue;

                    idKrp++;
                    idKrpPage++;

                    if (idKrpPage >= 4)
                    {
                        idKrpPage = 1;
                        cntPage++;
                    }

                    FastReport.MSChart.MSChartObject msc_t1 = new FastReport.MSChart.MSChartObject();
                    msc_t1.Name = "msc_t1_" + idKrpPage.ToString();

                    FastReport.MSChart.MSChartSeries ser_t1 = new FastReport.MSChart.MSChartSeries();
                    ser_t1.Name = "ser_t1_" + idKrpPage.ToString();

                    FastReport.MSChart.MSChartObject msc_t2 = new FastReport.MSChart.MSChartObject();
                    msc_t2.Name = "msc_t2_" + idKrpPage.ToString();

                    FastReport.MSChart.MSChartSeries ser_t2 = new FastReport.MSChart.MSChartSeries();
                    ser_t2.Name = "ser_t2_" + idKrpPage.ToString();

                    FastReport.MSChart.MSChartObject msc_vn = new FastReport.MSChart.MSChartObject();
                    msc_vn.Name = "msc_vn_" + idKrpPage.ToString();

                    FastReport.MSChart.MSChartSeries ser_vn = new FastReport.MSChart.MSChartSeries();
                    ser_vn.Name = "ser_vn_" + idKrpPage.ToString();

                    if (idKrpPage == 1)
                    {
                        chart_settup(msc_t1, 3, 50);
                        chart_settup(msc_t2, 353, 50);
                        chart_settup(msc_vn, 710, 50);
                    }
                    else if (idKrpPage == 2)
                    {
                        chart_settup(msc_t1, 3, 270);
                        chart_settup(msc_t2, 353, 270);
                        chart_settup(msc_vn, 710, 270);
                    }
                    else if (idKrpPage == 3)
                    {
                        chart_settup(msc_t1, 3, 490);
                        chart_settup(msc_t2, 353, 490);
                        chart_settup(msc_vn, 710, 490);
                    }

                    

                    for (int i = 0; i < 3; i++)
                    {
                        if (_krp.mas_lnk[i] != -1)
                        {
                            switch (i)
                            {
                                case 0:
                                    for (int j = 0; j < krpgr.t1_valueX.Count; j++)
                                        msc_t1.Chart.Series[0].Points.AddXY(krpgr.t1_valueX[j], krpgr.t1_valueY[j]);
                                    msc_t1.Chart.ChartAreas[0].Axes[1].Title = "T1";
                                    msc_t1.Chart.Series[0].LegendText = krpgr.t1_descr;
                                    break;
                                case 1:
                                    for (int j = 0; j < krpgr.t2_valueX.Count; j++)
                                        msc_t2.Chart.Series[0].Points.AddXY(krpgr.t2_valueX[j], krpgr.t2_valueY[j]);
                                    msc_t2.Chart.ChartAreas[0].Axes[1].Title = "T2";
                                    msc_t2.Chart.Series[0].LegendText = krpgr.t2_descr;
                                    break;
                                case 2:
                                    for (int j = 0; j < krpgr.vn_valueX.Count; j++)
                                        msc_vn.Chart.Series[0].Points.AddXY(krpgr.vn_valueX[j], krpgr.vn_valueY[j]);
                                    msc_vn.Chart.ChartAreas[0].Axes[1].Title = "ВНТ";
                                    msc_vn.Chart.Series[0].LegendText = krpgr.vn_descr;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    //msc.Chart.Series[0].Points.AddXY(DateTime.Parse("2012.09.20 00:10:00"), 10);
                    //msc.Chart.Series[0].Points.AddXY(DateTime.Parse("2012.09.20 00:15:00"), 8);
                    //msc.Chart.Series[0].Points.AddXY(DateTime.Parse("2012.09.20 00:20:00"), 9);
                    //msc.Chart.Series[0].Points.AddXY(DateTime.Parse("2012.09.20 01:25:00"), 11);

                    if (idKrpPage == 1)
                    {
                        db = new DataBand();
                        db.Name = "db" + idKrpPage.ToString();
                        db.CanGrow = true;
                        db.Height = 500;
                    }

                    if (idKrp < 2)
                        db.Objects.Add(nameKrp(" Протоколы корпусов с отклонениями за " + dateTimePicker2.Value.ToShortDateString(), 0, 0));

                    if (idKrpPage == 1)
                    {
                        db.Objects.Add(nameKrp("Корпус: " + _krp.name, 0, 20));
                    }
                    else if (idKrpPage ==2)
                    {
                        db.Objects.Add(nameKrp("Корпус: " + _krp.name, 0, 250));
                    }
                    else if (idKrpPage ==3)
                    {
                        db.Objects.Add(nameKrp("Корпус: " + _krp.name, 0, 470));
                    }

                    db.Objects.Add(msc_t1);
                    db.Objects.Add(msc_t2);
                    db.Objects.Add(msc_vn);

                    if (idKrpPage == 1)
                    {

                        page1 = new ReportPage();
                        page1.Name = "pg" + cntPage.ToString();
                        page1.Landscape = true;
                        page1.Bands.Add(db);
                        report.Pages.Add(page1);
                    }
                    

                }
                //report.Design();
                report.Show();
                //           Close();
            }
        }

        private void chart_settup(FastReport.MSChart.MSChartObject _msc, int X, int Y)
        {

            _msc.AddSeries(System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line);

            _msc.Width = 350;
            _msc.Height = 200;
            _msc.Left = (float)X;
            _msc.Top = (float)Y;
            _msc.Visible = true;

            _msc.Chart.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            _msc.Chart.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            _msc.Chart.Legends[0].Alignment = StringAlignment.Center;
            _msc.Chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
            _msc.Chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            _msc.Chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            _msc.Chart.Series[0].Color = Color.Black;
            _msc.Chart.Series[0].MarkerSize = 2;
            _msc.Chart.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            _msc.Chart.ChartAreas[0].Axes[1].TitleFont = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

        }

        private TextObject nameKrp(string str, int X, int Y)
        {
            TextObject text1 = new TextObject();
            text1.Name = "Text1";
            //text1.Left = (float)X;
            //text1.Top = (float)Y;
            text1.Bounds = new RectangleF((float)X, (float)Y,
              Units.Centimeters * 29, Units.Centimeters * 1);
            text1.Text = str;
            text1.HorzAlign = HorzAlign.Center;
            text1.Font = new Font("Tahoma", 14, FontStyle.Bold);

            return text1;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        // register the "Products" table
        //DataSet dataSet1 = new DataSet();

        //dataSet1.Tables.Add(new DataTable("Products"));
        //dataSet1.Tables["Products"].Columns.Add("ProductName", Type.GetType("System.String"));
        //dataSet1.Tables["Products"].Columns.Add("Her", Type.GetType("System.String"));


        //dataSet1.Tables["Products"].Rows.Add("pdl1", "one");
        //dataSet1.Tables["Products"].Rows.Add("pdl2", "two");
        //dataSet1.Tables["Products"].Rows.Add("pdl3", "three");

        //report.RegisterData(dataSet1.Tables["Products"], "Products");

        //// enable it to use in a report

        //report.GetDataSource("Products").Enabled = true;

        //ReportPage page1 = new ReportPage();
        //page1.Name = "Page1";
        //report.Pages.Add(page1);

        //page1.ReportTitle = new ReportTitleBand();
        //page1.ReportTitle.Name = "ReportTitle1";
        //page1.ReportTitle.Height = Units.Centimeters * 1.5f;

        //GroupHeaderBand group1 = new GroupHeaderBand();
        //group1.Name = "GroupHeader1";
        //group1.Height = Units.Centimeters * 1;
        //group1.Condition = "[Products.ProductName].Substring(0, 1)";
        //page1.Bands.Add(group1);

        //group1.GroupFooter = new GroupFooterBand();
        //group1.GroupFooter.Name = "GroupFooter1";
        //group1.GroupFooter.Height = Units.Centimeters * 1;

        //DataBand data1 = new DataBand();
        //data1.Name = "Data1";
        //data1.Height = Units.Centimeters * 0.5f;
        //data1.DataSource = report.GetDataSource("Products");
        //group1.Data = data1;

        //TextObject text1 = new TextObject();
        //text1.Name = "Text1";
        //text1.Bounds = new RectangleF(0, 0,
        //  Units.Centimeters * 19, Units.Centimeters * 1);
        //text1.Text = "PRODUCTS";
        //text1.HorzAlign = HorzAlign.Center;
        //text1.Font = new Font("Tahoma", 14, FontStyle.Bold);
        //page1.ReportTitle.Objects.Add(text1);

        //TextObject text2 = new TextObject();
        //text2.Name = "Text2";
        //text2.Bounds = new RectangleF(0, 0,
        //  Units.Centimeters * 2, Units.Centimeters * 1);
        //text2.Text = "[[Products.ProductName].Substring(0, 1)]";
        //text2.Font = new Font("Tahoma", 10, FontStyle.Bold);
        //group1.Objects.Add(text2);

        //TextObject text3 = new TextObject();
        //text3.Name = "Text3";
        //text3.Bounds = new RectangleF(0, 0,
        //  Units.Centimeters * 10, Units.Centimeters * 0.5f);
        //text3.Text = "[Products.ProductName]";
        //text3.Font = new Font("Tahoma", 8);
        //data1.Objects.Add(text3);

        //TextObject text4 = new TextObject();
        //text4.Name = "Text4";
        //text4.Bounds = new RectangleF(0, 0,
        //  Units.Centimeters * 10, Units.Centimeters * 0.5f);
        //text4.Text = "Count: [CountOfProducts]";
        //text4.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //group1.GroupFooter.Objects.Add(text4);

        //Total groupTotal = new Total();
        //groupTotal.Name = "CountOfProducts";
        //groupTotal.TotalType = TotalType.Count;
        //groupTotal.Evaluator = data1;
        //groupTotal.PrintOn = group1.Footer;
        //report.Dictionary.Totals.Add(groupTotal);

        //report.Show();
    }
}
