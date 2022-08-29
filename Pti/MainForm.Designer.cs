namespace Pti
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstbx_error = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtbx_vn_dn = new System.Windows.Forms.TextBox();
            this.lbl_vn = new System.Windows.Forms.Label();
            this.txtbx_t2_dn = new System.Windows.Forms.TextBox();
            this.lbl_t2 = new System.Windows.Forms.Label();
            this.txtbx_t2_up = new System.Windows.Forms.TextBox();
            this.txtbx_t1_dn = new System.Windows.Forms.TextBox();
            this.lbl_dn = new System.Windows.Forms.Label();
            this.lbl_t1 = new System.Windows.Forms.Label();
            this.txtbx_t1_up = new System.Windows.Forms.TextBox();
            this.lbl_up = new System.Windows.Forms.Label();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setupKRPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GraphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(6, 721);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 873);
            this.panel1.TabIndex = 4;
            // 
            // lstbx_error
            // 
            this.lstbx_error.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstbx_error.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstbx_error.FormattingEnabled = true;
            this.lstbx_error.HorizontalScrollbar = true;
            this.lstbx_error.Location = new System.Drawing.Point(0, 750);
            this.lstbx_error.Name = "lstbx_error";
            this.lstbx_error.Size = new System.Drawing.Size(221, 119);
            this.lstbx_error.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.comboBox5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.txtbx_vn_dn);
            this.panel2.Controls.Add(this.lbl_vn);
            this.panel2.Controls.Add(this.txtbx_t2_dn);
            this.panel2.Controls.Add(this.lbl_t2);
            this.panel2.Controls.Add(this.txtbx_t2_up);
            this.panel2.Controls.Add(this.txtbx_t1_dn);
            this.panel2.Controls.Add(this.lbl_dn);
            this.panel2.Controls.Add(this.lbl_t1);
            this.panel2.Controls.Add(this.txtbx_t1_up);
            this.panel2.Controls.Add(this.lbl_up);
            this.panel2.Controls.Add(this.lstbx_error);
            this.panel2.Controls.Add(this.zedGraphControl4);
            this.panel2.Controls.Add(this.zedGraphControl3);
            this.panel2.Controls.Add(this.zedGraphControl2);
            this.panel2.Controls.Add(this.zedGraphControl1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(790, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 873);
            this.panel2.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(158, 849);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 20);
            this.button3.TabIndex = 45;
            this.button3.Text = "Подробно";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 24);
            this.textBox1.TabIndex = 44;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "10",
            "20",
            "40",
            "60"});
            this.comboBox5.Location = new System.Drawing.Point(9, 665);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(83, 21);
            this.comboBox5.TabIndex = 43;
            this.comboBox5.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 609);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Время опроса датчиков (сек):";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 649);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Цикличность графиков (сек):";
            this.label1.Visible = false;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "30"});
            this.comboBox4.Location = new System.Drawing.Point(9, 625);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox4.Size = new System.Drawing.Size(84, 21);
            this.comboBox4.TabIndex = 39;
            this.comboBox4.Visible = false;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(15, 569);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Шрифт:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.comboBox3.Location = new System.Drawing.Point(8, 585);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox3.Size = new System.Drawing.Size(84, 21);
            this.comboBox3.TabIndex = 37;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(137, 721);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "Печать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(145, 524);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Звук:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Вкл. все",
            "Выкл. все"});
            this.comboBox2.Location = new System.Drawing.Point(128, 540);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(84, 21);
            this.comboBox2.TabIndex = 34;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(15, 524);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Контроль:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Вкл. все",
            "Выкл. все"});
            this.comboBox1.Location = new System.Drawing.Point(8, 540);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox1.Size = new System.Drawing.Size(84, 21);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtbx_vn_dn
            // 
            this.txtbx_vn_dn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbx_vn_dn.Location = new System.Drawing.Point(167, 494);
            this.txtbx_vn_dn.Name = "txtbx_vn_dn";
            this.txtbx_vn_dn.ReadOnly = true;
            this.txtbx_vn_dn.Size = new System.Drawing.Size(45, 20);
            this.txtbx_vn_dn.TabIndex = 30;
            this.txtbx_vn_dn.WordWrap = false;
            // 
            // lbl_vn
            // 
            this.lbl_vn.AutoSize = true;
            this.lbl_vn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_vn.Location = new System.Drawing.Point(164, 448);
            this.lbl_vn.Name = "lbl_vn";
            this.lbl_vn.Size = new System.Drawing.Size(43, 13);
            this.lbl_vn.TabIndex = 31;
            this.lbl_vn.Text = "Вент.:";
            // 
            // txtbx_t2_dn
            // 
            this.txtbx_t2_dn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbx_t2_dn.Location = new System.Drawing.Point(106, 494);
            this.txtbx_t2_dn.Name = "txtbx_t2_dn";
            this.txtbx_t2_dn.ReadOnly = true;
            this.txtbx_t2_dn.Size = new System.Drawing.Size(45, 20);
            this.txtbx_t2_dn.TabIndex = 26;
            this.txtbx_t2_dn.WordWrap = false;
            // 
            // lbl_t2
            // 
            this.lbl_t2.AutoSize = true;
            this.lbl_t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_t2.Location = new System.Drawing.Point(103, 448);
            this.lbl_t2.Name = "lbl_t2";
            this.lbl_t2.Size = new System.Drawing.Size(53, 13);
            this.lbl_t2.TabIndex = 28;
            this.lbl_t2.Text = "Темп.2:";
            // 
            // txtbx_t2_up
            // 
            this.txtbx_t2_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbx_t2_up.Location = new System.Drawing.Point(106, 468);
            this.txtbx_t2_up.Name = "txtbx_t2_up";
            this.txtbx_t2_up.ReadOnly = true;
            this.txtbx_t2_up.Size = new System.Drawing.Size(45, 20);
            this.txtbx_t2_up.TabIndex = 24;
            this.txtbx_t2_up.WordWrap = false;
            // 
            // txtbx_t1_dn
            // 
            this.txtbx_t1_dn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbx_t1_dn.Location = new System.Drawing.Point(47, 494);
            this.txtbx_t1_dn.Name = "txtbx_t1_dn";
            this.txtbx_t1_dn.ReadOnly = true;
            this.txtbx_t1_dn.Size = new System.Drawing.Size(45, 20);
            this.txtbx_t1_dn.TabIndex = 21;
            this.txtbx_t1_dn.WordWrap = false;
            // 
            // lbl_dn
            // 
            this.lbl_dn.AutoSize = true;
            this.lbl_dn.Location = new System.Drawing.Point(5, 497);
            this.lbl_dn.Name = "lbl_dn";
            this.lbl_dn.Size = new System.Drawing.Size(41, 13);
            this.lbl_dn.TabIndex = 22;
            this.lbl_dn.Text = "Нижн.:";
            // 
            // lbl_t1
            // 
            this.lbl_t1.AutoSize = true;
            this.lbl_t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_t1.Location = new System.Drawing.Point(44, 448);
            this.lbl_t1.Name = "lbl_t1";
            this.lbl_t1.Size = new System.Drawing.Size(53, 13);
            this.lbl_t1.TabIndex = 23;
            this.lbl_t1.Text = "Темп.1:";
            // 
            // txtbx_t1_up
            // 
            this.txtbx_t1_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbx_t1_up.Location = new System.Drawing.Point(47, 468);
            this.txtbx_t1_up.Name = "txtbx_t1_up";
            this.txtbx_t1_up.ReadOnly = true;
            this.txtbx_t1_up.Size = new System.Drawing.Size(45, 20);
            this.txtbx_t1_up.TabIndex = 15;
            this.txtbx_t1_up.WordWrap = false;
            // 
            // lbl_up
            // 
            this.lbl_up.AutoSize = true;
            this.lbl_up.Location = new System.Drawing.Point(3, 471);
            this.lbl_up.Name = "lbl_up";
            this.lbl_up.Size = new System.Drawing.Size(43, 13);
            this.lbl_up.TabIndex = 20;
            this.lbl_up.Text = "Верхн.:";
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));
            this.zedGraphControl4.IsEnableHZoom = false;
            this.zedGraphControl4.IsEnableVZoom = false;
            this.zedGraphControl4.IsEnableWheelZoom = false;
            this.zedGraphControl4.Location = new System.Drawing.Point(0, 343);
            this.zedGraphControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollGrace = 0;
            this.zedGraphControl4.ScrollMaxX = 0;
            this.zedGraphControl4.ScrollMaxY = 0;
            this.zedGraphControl4.ScrollMaxY2 = 0;
            this.zedGraphControl4.ScrollMinX = 0;
            this.zedGraphControl4.ScrollMinY = 0;
            this.zedGraphControl4.ScrollMinY2 = 0;
            this.zedGraphControl4.Size = new System.Drawing.Size(221, 100);
            this.zedGraphControl4.TabIndex = 14;
            this.zedGraphControl4.Click += new System.EventHandler(this.zedGraphControl_Click);
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));
            this.zedGraphControl3.IsEnableHZoom = false;
            this.zedGraphControl3.IsEnableVZoom = false;
            this.zedGraphControl3.IsEnableWheelZoom = false;
            this.zedGraphControl3.Location = new System.Drawing.Point(0, 243);
            this.zedGraphControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0;
            this.zedGraphControl3.ScrollMaxX = 0;
            this.zedGraphControl3.ScrollMaxY = 0;
            this.zedGraphControl3.ScrollMaxY2 = 0;
            this.zedGraphControl3.ScrollMinX = 0;
            this.zedGraphControl3.ScrollMinY = 0;
            this.zedGraphControl3.ScrollMinY2 = 0;
            this.zedGraphControl3.Size = new System.Drawing.Size(221, 100);
            this.zedGraphControl3.TabIndex = 13;
            this.zedGraphControl3.Click += new System.EventHandler(this.zedGraphControl_Click);
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));
            this.zedGraphControl2.IsEnableHZoom = false;
            this.zedGraphControl2.IsEnableVZoom = false;
            this.zedGraphControl2.IsEnableWheelZoom = false;
            this.zedGraphControl2.Location = new System.Drawing.Point(0, 143);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0;
            this.zedGraphControl2.ScrollMaxX = 0;
            this.zedGraphControl2.ScrollMaxY = 0;
            this.zedGraphControl2.ScrollMaxY2 = 0;
            this.zedGraphControl2.ScrollMinX = 0;
            this.zedGraphControl2.ScrollMinY = 0;
            this.zedGraphControl2.ScrollMinY2 = 0;
            this.zedGraphControl2.Size = new System.Drawing.Size(221, 100);
            this.zedGraphControl2.TabIndex = 12;
            this.zedGraphControl2.Click += new System.EventHandler(this.zedGraphControl_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.IsEnableWheelZoom = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 43);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(221, 100);
            this.zedGraphControl1.TabIndex = 11;
            this.zedGraphControl1.Click += new System.EventHandler(this.zedGraphControl_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(67, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Корпус:";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupKRPToolStripMenuItem,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.GraphsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 92);
            // 
            // setupKRPToolStripMenuItem
            // 
            this.setupKRPToolStripMenuItem.Name = "setupKRPToolStripMenuItem";
            this.setupKRPToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setupKRPToolStripMenuItem.Text = "Настроить корпус";
            this.setupKRPToolStripMenuItem.Click += new System.EventHandler(this.SetupKRPToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.addToolStripMenuItem.Text = "Добавить корпус";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.deleteToolStripMenuItem.Text = "Удалить корпус";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // GraphsToolStripMenuItem
            // 
            this.GraphsToolStripMenuItem.Name = "GraphsToolStripMenuItem";
            this.GraphsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.GraphsToolStripMenuItem.Text = "Графики";
            this.GraphsToolStripMenuItem.Click += new System.EventHandler(this.GraphsToolStripMenuItem_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 873);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Система контроля показаний датчиков";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lstbx_error;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.TextBox txtbx_t1_dn;
        private System.Windows.Forms.Label lbl_dn;
        private System.Windows.Forms.TextBox txtbx_t1_up;
        private System.Windows.Forms.Label lbl_up;
        private System.Windows.Forms.TextBox txtbx_vn_dn;
        private System.Windows.Forms.Label lbl_vn;
        private System.Windows.Forms.TextBox txtbx_t2_dn;
        private System.Windows.Forms.Label lbl_t2;
        private System.Windows.Forms.TextBox txtbx_t2_up;
        private System.Windows.Forms.Label lbl_t1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupKRPToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Timer timer2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GraphsToolStripMenuItem;
    }
}

