using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using ZedGraph;
using System.Threading;

namespace Pti
{
    public partial class Form1 : Form
    {
//        DataGridView dgv = new DataGridView();
        public DB db = new DB();
        public List<Korpus> korpuses;
        public int curr_korp = -1;
        public int curr_korp_pk = -1;
        public int dgvCount = 0;
        public string[] settings ;

        Thread thr;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartWork(true);
            soundKRPs();
            enableKRPs();
            ClearDGV();
            FillDGV();
        }
        
        int krpCount = 0;
        List<DataGridView> lst_DGV = new List<DataGridView>();

        public void StartWork(bool fl)
        {
            timer1.Stop();
            timer2.Stop();
            db.ConnectToParameters(); //подключение к файлу с параметрами
            korpuses = db.GetKorpuses(); // создается список корпусов и заполняется параметрами

            krpCount = korpuses.Count;
            CreateDGV();
            setupsDGV();
            //if (fl)
            //{
            //    createDGV(); //создается таблица особо настроенная
            //    panel1.Controls.Add(dgv);
            //}
            //else
            //{
            //    fillHeaderDGV();
            //}

            timer1.Start();
            timer2.Start();
            if (this.WindowState != FormWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;
        }

        private void CreateDGV()
        {
            if (krpCount == 0) return;
            dgvCount = (krpCount - 1) / 10 + 1;

            for (int i = 0; i < lst_DGV.Count - 1; i++)
            {
                lst_DGV[i].Dispose();
            }
            lst_DGV.Clear();
            panel1.Controls.Clear();

            for (int i = 0; i < dgvCount; i++)  //перебор всех таблиц
            {
                lst_DGV.Add(new DataGridView()); //добавляем таблицы в список

                int dgvColCnt = 0;

                if (i == dgvCount - 1) //если последняя таблица
                {
                    dgvColCnt = krpCount % 10;   // выбираем кол-во корпусов из последнего десятка (из 14 корпусов выбираются 4 последних)
                    if (dgvColCnt == 0) dgvColCnt += 10;

                    for (int colcnt = 0; colcnt < krpCount; colcnt++)
                    {
                        lst_DGV[i].Columns.Add("n" + colcnt.ToString(), korpuses[colcnt].name); //добавляем колонки
                        if (krpCount - colcnt > dgvColCnt)
                        {
                            lst_DGV[i].Columns[colcnt].Visible = false; //часть колонок невидимые
                        }
                    }
                }
                else
                {
                    dgvColCnt = (i + 1) * 10;  //если таблица не последняя, то кол-во колонок всегда 10*(номер табл +1)
                    for (int colcnt = 0; colcnt < dgvColCnt; colcnt++)
                    {
                        lst_DGV[i].Columns.Add("n" + colcnt.ToString(), korpuses[colcnt].name); //добавл. колонки
                        if (dgvColCnt - colcnt > 10)
                        {
                            lst_DGV[i].Columns[colcnt].Visible = false; //убираем видимость колонок
                        }
                    }
                }

                lst_DGV[i].Dock = DockStyle.Top;
                lst_DGV[i].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
                if (i == 0)
                {
                    lst_DGV[i].Location = new Point(0, 0);
                    lst_DGV[i].Size = new Size(0,  lst_DGV[i].Rows.Count*(int)(lst_DGV[i].Font.SizeInPoints));
                }
                else
                {
                    lst_DGV[i].Location = new Point(0, 0);
                    lst_DGV[i].Size = new Size(0, lst_DGV[i - 1].Size.Height);
                }
            }

            for (int i = dgvCount - 1; i >= 0; i--)
            {
                lst_DGV[i].Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
               panel1.Controls.Add(lst_DGV[i]);
            }
        }


        //korp_num, val_num, location(x,y)
        private void PaintGraphs(int korp_num, int val_num, int x, int y, ZedGraphControl zgc )
        {
            CreateGraph(zgc, korp_num, val_num); //t1
            zgc.Location = new Point(x, y); // задаем положение графика
         //   zedGraphControl1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
            zgc.Size = new Size(250, 100);
        }

        private void CreateGraph(ZedGraphControl zgc, int korp_num, int val_num)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            // Задаем название графика и сторон
            myPane.Legend.IsVisible = false;
            myPane.Title.IsVisible = false;
            myPane.Title.FontSpec.Size = 8;

            if (zgc.Name == "zedGraphControl1")
                myPane.YAxis.Title.Text = "T1";
            if (zgc.Name == "zedGraphControl2")
                myPane.YAxis.Title.Text = "T2";
            if (zgc.Name == "zedGraphControl3")
                myPane.YAxis.Title.Text = "Внт %";
            if (zgc.Name == "zedGraphControl4")
                myPane.YAxis.Title.Text = "Влж %";


            myPane.XAxis.Title.Text = "Время";
            myPane.IsFontsScaled = false;

            // Установим размеры шрифтов для меток вдоль осей
            myPane.XAxis.Scale.FontSpec.Size = 8;
            myPane.XAxis.Scale.IsVisible = false;
            myPane.YAxis.Scale.FontSpec.Size = 8;

            // Установим размеры шрифтов для подписей по осям
            myPane.XAxis.Title.IsVisible = false;
            myPane.YAxis.Title.IsVisible = true;
            myPane.YAxis.Title.FontSpec.Size = 8;
            // --------------------------------


            if ((val_num == 0) || (val_num == 1))
            {
                myPane.YAxis.Scale.Min = 15;
                myPane.YAxis.Scale.Max = 35;
            }
            else if ((val_num == 2) || (val_num == 3))
            {
                myPane.YAxis.Scale.Min = 2;
                myPane.YAxis.Scale.Max = 110;
            }

            // строим синусойду
            double x, y;
            PointPairList list1 = new PointPairList();
            
            for (int i = 0; i < 30; i++)
            {
                x = i;
                y = korpuses[korp_num].mas_t1[val_num][29-i];
                list1.Add(x, y);
            }
            // ----------------

            LineItem myCurve = myPane.AddCurve("T1", list1, Color.Blue, SymbolType.None); // отрисовываем график
            myCurve.Line.Width = 3.0f;
            zgc.AxisChange();
            zgc.Invalidate();
            
        }

       private void setupsDGV()
        {
            for (int i = 0; i < dgvCount; i++)
            {
                lst_DGV[i].ColumnHeadersHeight = 20;

                lst_DGV[i].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lst_DGV[i].ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                lst_DGV[i].ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);

                //    columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
                //dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                //dgv.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                
                lst_DGV[i].RowCount = 8;
                lst_DGV[i].RowHeadersWidth = 100;
                lst_DGV[i].RowHeadersVisible = true;
                lst_DGV[i].RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                lst_DGV[i].RowHeadersDefaultCellStyle.Font = new Font("Verdana", 9, FontStyle.Regular);
                lst_DGV[i].AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                lst_DGV[i].Rows[0].HeaderCell.Value = "Т1 °С";
                lst_DGV[i].Rows[1].HeaderCell.Value = "Т2 °C";
                lst_DGV[i].Rows[2].HeaderCell.Value = "Внт %";
                lst_DGV[i].Rows[3].HeaderCell.Value = "Влж %";
                lst_DGV[i].Rows[4].HeaderCell.Value = "Заселение";
                lst_DGV[i].Rows[5].HeaderCell.Value = "Содержание";
                lst_DGV[i].Rows[6].HeaderCell.Value = "Контроль";
                lst_DGV[i].Rows[7].HeaderCell.Value = "Звук";

                lst_DGV[i].RowsDefaultCellStyle.Font = new Font("Verdana", Int32.Parse(comboBox3.SelectedItem.ToString()), FontStyle.Regular);
//                comboBox3.SelectedIndex = 4;
                lst_DGV[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                lst_DGV[i].CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDoubleClick);
                lst_DGV[i].CellMouseClick += new DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
                lst_DGV[i].SelectionMode = DataGridViewSelectionMode.CellSelect;
                lst_DGV[i].ReadOnly = true;
                lst_DGV[i].MultiSelect = false;
                lst_DGV[i].ContextMenuStrip = contextMenuStrip1;

                if (i == 0)
                {
                    lst_DGV[i].Location = new Point(0, 0);
                    lst_DGV[i].Size = new Size(0, GetHeightDGV(lst_DGV[i]) + 2);
                }
                else
                {
                    lst_DGV[i].Location = new Point(0, 0);
                    lst_DGV[i].Size = new Size(0, lst_DGV[i-1].Height);
                }
            }
        }

        void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            curr_korp = e.ColumnIndex;
            if (curr_korp > -1)
                curr_korp_pk = korpuses[curr_korp].pk;

            int num_dgv = curr_korp / 10;
            for (int i = 0; i < dgvCount; i++)
            {
                if (i != num_dgv)
                    lst_DGV[i].ClearSelection();
            }
                if (curr_korp > -1)
                {
                    label4.Text = korpuses[curr_korp].name;
                    if (korpuses[curr_korp].enabled)
                    {
                        //label4.Text = korpuses[curr_korp].name;
                        paintCurrentKRP();

                    }
                    else
                    {
                        //label4.Text = "";
                        clearPaintCurrentKRP();
                    }
                }
        }

        public void FillDGV()
        {
            int num_dgv = 0;
                for (int i = 0; i < krpCount; i++) //проход по корпусам/колонкам таблиц
                {
                    num_dgv = i/10; //номер таблицы в зависимости от номера корпуса
                    for (int j = 0; j <= 3; j++) //проход по строкам с датчиками (1-4)
                    {
                        lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.LightGray;  //сначала все очищаем, приводим в начальный серый вид
                        if (korpuses[i].enabled)
                            if (korpuses[i].mas_lnk[j] >= 0) //если есть ссылка у датчика, то
                            {
                                lst_DGV[num_dgv].Rows[j].Cells[i].Value = korpuses[i].curr_values[j].ToString("N2"); //выводим значение
                                lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.White;
                                
                                if ((j < 3) && ((korpuses[i].error != 1) && (korpuses[i].error != 2))) //перебираем значения t1 t2 vn и если нет еще ошибок
                                {
                                    if ((korpuses[i].curr_values[j] < korpuses[i].lim_values[j, 0]) || (korpuses[i].curr_values[j] > korpuses[i].lim_values[j, 1]))
                                    {
                                        korpuses[i].error = 4;
                                        lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.Pink;
                                    }
                                    if (korpuses[i].error == 3)
                                        lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.Pink;
                                }
                            }
                    }

                    if (korpuses[i].enabled)
                    {
                        lst_DGV[num_dgv].Rows[4].Cells[i].Style.BackColor = Color.White;
                        lst_DGV[num_dgv].Rows[5].Cells[i].Style.BackColor = Color.White;
                        lst_DGV[num_dgv].Rows[6].Cells[i].Style.BackColor = Color.LightGreen;

                        lst_DGV[num_dgv].Rows[4].Cells[i].Value = korpuses[i].dateBegin.ToString("dd.MM.yy");
                        lst_DGV[num_dgv].Rows[5].Cells[i].Value = korpuses[i].days_keep.ToString();

                    }
                    else
                    {
                        lst_DGV[num_dgv].Rows[4].Cells[i].Style.BackColor = Color.LightGray;
                        lst_DGV[num_dgv].Rows[5].Cells[i].Style.BackColor = Color.LightGray;
                        lst_DGV[num_dgv].Rows[6].Cells[i].Style.BackColor = Color.LightGray;
                    }

                    if (korpuses[i].sounded)
                    {
                        lst_DGV[num_dgv].Rows[7].Cells[i].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        lst_DGV[num_dgv].Rows[7].Cells[i].Style.BackColor = Color.LightGray;
                    }

                    lst_DGV[num_dgv].Rows[6].Cells[i].Value = korpuses[i].Enabled;
                    lst_DGV[num_dgv].Rows[7].Cells[i].Value = korpuses[i].Sounded;

                    if (((korpuses[i].error == 1) || (korpuses[i].error == 2)) && (korpuses[i].enabled))
                        for (int n = 0; n < 6; n++)
                        {
                            lst_DGV[num_dgv].Rows[n].Cells[i].Style.BackColor = Color.Pink;
                        }

                }
        }

        public void ClearErrorKorpuses()
        {
            foreach (Korpus krp in korpuses)
            {
                if (((krp.error == 1) || (krp.error == 2)) || (krp.connect == null))
                    db.ConnectToProtocol(krp);
                else
                    krp.error = 0;
            }
        }

        public void ClearDGV()
        {
            int num_dgv = 0;
            for (int i = 0; i < korpuses.Count; i++)
            {
                num_dgv = i / 10; //номер таблицы в зависимости от номера корпуса
                for (int j = 0; j < 8; j++)
                {
                    lst_DGV[num_dgv].Rows[j].Cells[i].Value = "";
                }
            }
        }

        int lbl2 = 0;
        DateTime date_old;
        DateTime date_new;
        TimeSpan date_diff;

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool enableKRPs = false;
            foreach (Korpus krp in korpuses)
            {
                if (krp.enabled) enableKRPs = true;
            }
            if (!enableKRPs) return;

            date_new = DateTime.Now;
            TimeSpan date_null = new DateTime().TimeOfDay;
            TimeSpan diff = date_new.TimeOfDay - date_null;

            if (diff.TotalMinutes < 10)
            {
                int num_dgv = 0;
                for (int i = 0; i < korpuses.Count; i++)
                {
                    korpuses[i].error = 0;
                    num_dgv = i / 10; //номер таблицы в зависимости от номера корпуса
                    for (int j = 0; j < 7; j++)
                    {
                        lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.White;
                        
                        if ((j == 5) && (korpuses[i].enabled))
                            lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.LightGreen;
                        else
                            lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.LightGray;
                        
                        if ((j == 6) && (korpuses[i].sounded))
                            lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.LightGreen;
                        else
                            lst_DGV[num_dgv].Rows[j].Cells[i].Style.BackColor = Color.LightGray;

                    }
                }

                return;
            }
            else
            {
                foreach (Korpus krp in korpuses)
                {
                    if (krp.enabled)
                        db.ConnectToProtocol(krp);
                }
            }


            ClearErrorKorpuses();

            for (int i = 0; i < korpuses.Count; i++)
            {
                TimeSpan dif = DateTime.Now - korpuses[i].dateBegin;
                korpuses[i].days_keep = dif.Days + 1;  //изменяем дату содержания

                for (int j = 0; j < 4; j++ )
                    if (korpuses[i].mas_lnk[j] >= 0)
                    { //если ссылка больше/равно 0, значит считываем значение
                        //thr = new Thread(new ThreadStart(db.GetType())).Start();
                        //ThreadPool.QueueUserWorkItem(new WaitCallback(db.GetValue(korpuses[i], korpuses[i].mas_lnk[j], j)));
                        
                        db.GetValue(korpuses[i], korpuses[i].mas_lnk[j], j); //заполняем значения объекта прочитанными данными
                        korpuses[i].curr_values[j] = korpuses[i].mas_t1[j][0];
                    }
            }
            
            ClearDGV();
            FillDGV();
            lbl2++;
            
            if ((curr_korp > -1) && (korpuses[curr_korp].enabled))
            {
                PaintGraphs(curr_korp, 0, 0, 43, zedGraphControl1);
                PaintGraphs(curr_korp, 1, 0, 143, zedGraphControl2);
                PaintGraphs(curr_korp, 2, 0, 243, zedGraphControl3);
                PaintGraphs(curr_korp, 3, 0, 343, zedGraphControl4);
            }

            date_old = DateTime.Now; //
        }

        private void ShowMessageError()
        {
            lstbx_error.Items.Clear();

            foreach (Korpus krp in korpuses)
            {
                if (krp.enabled)
                    switch (krp.error)
                    {
                        case 1:
                            lstbx_error.Items.Add(krp.name + " " + "не найден протокол");
                            break;
                        case 2:
                            lstbx_error.Items.Add(krp.name + " " + "не удалось подключиться к протоколу");
                            break;
                        case 3:
                            lstbx_error.Items.Add(krp.name + " " + "датчик не реагирует продолжительное время");
                            break;
                        case 4:
                            lstbx_error.Items.Add(krp.name + " " + "значение датчика вне допустимого предела");
                            break;
                    }
            }
        }

        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == 6)
            {
                comboBox1.SelectedIndex = -1;
                if (korpuses[e.ColumnIndex].enabled)
                {
                    korpuses[e.ColumnIndex].enabled = false;
                    korpuses[e.ColumnIndex].error = 0;
                    db.UpdateRowEnable(curr_korp_pk, false);
                }
                else
                {
                    korpuses[e.ColumnIndex].enabled = true;
                    db.ConnectToProtocol(korpuses[e.ColumnIndex]);
                    db.UpdateRowEnable(curr_korp_pk, true);
                }
            }
            if (e.RowIndex == 7)
            {
                comboBox2.SelectedIndex = -1;
                if (korpuses[e.ColumnIndex].sounded)
                {
                    korpuses[e.ColumnIndex].sounded = false;
                    db.UpdateRowSound(curr_korp_pk, false);
                }
                else
                {
                    korpuses[e.ColumnIndex].sounded = true;
                    db.UpdateRowSound(curr_korp_pk, true);

                }
            }
            ClearDGV();
            FillDGV();
                    
        }
       
        private void SetupKRPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curr_korp >= 0)
            {
                timer1.Stop();
                timer2.Stop();
                using (SetupKRP frmSetKrp = new SetupKRP(this, "Настройка корпуса"))
                {
                    frmSetKrp.StartPosition = FormStartPosition.CenterScreen;
                    frmSetKrp.ShowDialog();
                }

                foreach (Korpus krp in korpuses)
                    krp.connect.Dispose();
                korpuses.Clear();
                
                StartWork(false);
                
                soundKRPs();
                enableKRPs();
                ClearDGV();
                FillDGV();
                
                //timer1.Start();
                timer1_Tick(sender, e);
                timer1_Tick(sender, e);
                timer2.Start();
            }
        }

        private void enableKRPs()
        {
            if (comboBox1.SelectedIndex == 0)  //включить все корпуса
                foreach (Korpus krp in korpuses)
                {
                    krp.enabled = true;
                    db.UpdateRowEnable(krp.pk, true);
                    db.ConnectToProtocol(krp);

                }

            if (comboBox1.SelectedIndex == 1) //выключить
                foreach (Korpus krp in korpuses)
                {
                    krp.enabled = false;
                    db.UpdateRowEnable(krp.pk, false);

                    krp.error = 0;
                }
        }

        private void soundKRPs()
        {
            if (comboBox2.SelectedIndex == 0)  //включить звук всех корпусов
                foreach (Korpus krp in korpuses)
                {
                    krp.sounded = true;
                }

            if (comboBox2.SelectedIndex == 1) //выключить звук
                foreach (Korpus krp in korpuses)
                {
                    krp.sounded = false;
                }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            soundKRPs();
            enableKRPs();
            ClearDGV();
            FillDGV();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
                foreach (Korpus krp in korpuses)
                {
                    krp.sounded = true;
                    db.UpdateRowSound(krp.pk, true);

                }

            if (comboBox2.SelectedIndex == 1)
                foreach (Korpus krp in korpuses)
                {
                    krp.sounded = false;
                    db.UpdateRowSound(krp.pk, false);
                }

            ClearDGV();
            FillDGV();
        }

        //таймер для звука. 
        //каждые 2 секунды проверяется: если корпус с ошибкой и включен звук - выдаем звуковое оповещение
        //вывод звука в отдельный поток
        private void timer2_Tick(object sender, EventArgs e)
        {
            bool err = false;
            bool snd = false;
            
            ShowMessageError();

            foreach (Korpus krp in korpuses)
                if (krp.enabled)
                    if (krp.sounded)
                    {
                        snd = true;
                        break;
                    }

            foreach (Korpus krp in korpuses)
                if (krp.enabled)
                    if (krp.error > 0)
                    {
                        err = true;
                        break;
                    }
            
            if (err)
            {
                if (panel2.BackColor == SystemColors.Control)
                    panel2.BackColor = Color.Red;
                else if (panel2.BackColor == Color.Red)
                    panel2.BackColor = SystemColors.Control;

                if (snd)
                {
                 //   backgroundWorker1.RunWorkerAsync();
                    System.Threading.ThreadPool.QueueUserWorkItem(
                    (o) =>
                    {
                        Console.Beep(500, 500);
                        Console.Beep(1000, 500);
                    });
                }
            }
            else
                panel2.BackColor = SystemColors.Control;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.Beep(500, 500);
            Console.Beep(1000, 500);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (PrintForm frmPrn = new PrintForm(this))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                frmPrn.StartPosition = FormStartPosition.CenterScreen;
                frmPrn.ShowDialog();
                timer1.Enabled = true;
                timer2.Enabled = true;
            }

        }

        public int GetHeightDGV(DataGridView dgv)
        {
            int height = 0;
            height = dgv.ColumnHeadersHeight;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                height += dgv.Rows[i].Height;
            }
            return height;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings[0] = comboBox3.SelectedItem.ToString();
            resizeDGVFont();
        }

        private void resizeDGVFont()
        {
            for (int i = 0; i < dgvCount; i++)
            {
                lst_DGV[i].RowsDefaultCellStyle.Font = new Font("Verdana", Int32.Parse(comboBox3.SelectedItem.ToString()), FontStyle.Regular);

                if (lst_DGV[i].Equals(lst_DGV[0]))
                {
                    lst_DGV[i].Location = new Point(0, 0);
                    lst_DGV[i].Size = new Size(0, GetHeightDGV(lst_DGV[i]) + 2);
                }
                else
                {
                    lst_DGV[i].Location = new Point(0, 0);
                    lst_DGV[i].Size = new Size(0, lst_DGV[i - 1].Height);
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int.Parse( comboBox4.SelectedItem.ToString()))*1000;
         //   MessageBox.Show(timer1.Interval.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                settings = System.IO.File.ReadAllLines(@"c:\TMP\fontsz.dll"); //читаем настройки
            }
            catch
            {
                settings = new string[1];
                settings[0] = "11";  //если не прочитали настройки, значит устанавливаем все по умолчанию
            }

            //устанавливаем размер шрифта в таблицах
            comboBox3.SelectedIndex = comboBox3.FindString(settings[0]);
            comboBox3_SelectedIndexChanged(comboBox3, e);            

            comboBox4.SelectedIndex = 2; //цикличность опроса датчиков
            comboBox5.SelectedIndex = 0; //цикличность графиков

            this.MaximizeBox = true;
            StartWork(true);
            
            timer1_Tick(sender, e);
            timer1_Tick(sender, e);
            soundKRPs();
            enableKRPs();
            ClearDGV();
            FillDGV();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        int cnt = 0;
        int curr_KrpGraph = 0;
        
        // таймер для вывода времени
        private void timer3_Tick(object sender, EventArgs e)
        {
          textBox1.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AlarmForm frmAlarm = new AlarmForm(lstbx_error);
            frmAlarm.StartPosition = FormStartPosition.CenterScreen;
            frmAlarm.Show();
        }


        private void paintCurrentKRP()
        {
            txtbx_t1_dn.Text = korpuses[curr_korp].lim_values[0, 0].ToString();
            txtbx_t1_up.Text = korpuses[curr_korp].lim_values[0, 1].ToString();
            txtbx_t2_dn.Text = korpuses[curr_korp].lim_values[1, 0].ToString();
            txtbx_t2_up.Text = korpuses[curr_korp].lim_values[1, 1].ToString();
            txtbx_vn_dn.Text = korpuses[curr_korp].lim_values[2, 0].ToString();

            PaintGraphs(curr_korp, 0, 0, 43, zedGraphControl1);
            PaintGraphs(curr_korp, 1, 0, 143, zedGraphControl2);
            PaintGraphs(curr_korp, 2, 0, 243, zedGraphControl3);
            PaintGraphs(curr_korp, 3, 0, 343, zedGraphControl4);
        }


        private void clearPaintCurrentKRP()
        {
            txtbx_t1_dn.Text = "";
            txtbx_t1_up.Text = "";
            txtbx_t2_dn.Text = "";
            txtbx_t2_up.Text = "";
            txtbx_vn_dn.Text = "";
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl4.GraphPane.CurveList.Clear();
            zedGraphControl1.Invalidate();
            zedGraphControl2.Invalidate();
            zedGraphControl3.Invalidate();
            zedGraphControl4.Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                System.IO.File.Delete(@"c:\TMP\fontsz.dll");
                System.IO.File.WriteAllLines(@"c:\TMP\fontsz.dll", settings); //сохр. настройки
            }
            catch
            {
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curr_korp >= 0)
            {
                timer1.Stop();
                timer2.Stop();
                
                DialogResult dr = MessageBox.Show("Хотите удалить корпус?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (db.DeleteRow(korpuses[curr_korp].pk))
                    {
                        curr_korp = -1;
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                        MessageBox.Show("Не удалось удалить корпус");

                }

                foreach (Korpus krp in korpuses)
                    krp.connect.Dispose();
                korpuses.Clear();
                StartWork(false);

                soundKRPs();
             //   enableKRPs();
                ClearDGV();
                FillDGV();

                timer1.Start();
                timer1_Tick(sender, e);
                timer1_Tick(sender, e);
                timer2.Start();
            }



        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            timer1.Stop();
            timer2.Stop();
            using (SetupKRP frmSetKrp = new SetupKRP(this, "Добавление нового корпуса", true))
            {
                frmSetKrp.StartPosition = FormStartPosition.CenterScreen;
                frmSetKrp.ShowDialog();
            }
            
            foreach (Korpus krp in korpuses)
                krp.connect.Dispose();
            korpuses.Clear();
            StartWork(false);

            soundKRPs();
          //  enableKRPs();
            ClearDGV();
            FillDGV();

            timer1.Start();
            timer1_Tick(sender, e);
            timer1_Tick(sender, e);
            timer2.Start();
        }


        private void zedGraphControl_Click(object sender, EventArgs e)
        {
            if (curr_korp > -1)
            {
                GraphicForm gFrm = new GraphicForm(korpuses[curr_korp]);
                gFrm.StartPosition = FormStartPosition.CenterScreen;
                gFrm.ShowDialog();
            }

        }

        private void GraphsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curr_korp > -1)
            {
                GraphicForm gFrm = new GraphicForm(korpuses[curr_korp]);
                gFrm.StartPosition = FormStartPosition.CenterScreen;
                gFrm.ShowDialog();
            }
        }
    }

}
