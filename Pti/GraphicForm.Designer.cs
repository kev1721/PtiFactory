namespace Pti
{
    partial class GraphicForm
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.IsEnableWheelZoom = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(574, 184);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl2.IsEnableHZoom = false;
            this.zedGraphControl2.IsEnableVZoom = false;
            this.zedGraphControl2.IsEnableWheelZoom = false;
            this.zedGraphControl2.Location = new System.Drawing.Point(12, 196);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0;
            this.zedGraphControl2.ScrollMaxX = 0;
            this.zedGraphControl2.ScrollMaxY = 0;
            this.zedGraphControl2.ScrollMaxY2 = 0;
            this.zedGraphControl2.ScrollMinX = 0;
            this.zedGraphControl2.ScrollMinY = 0;
            this.zedGraphControl2.ScrollMinY2 = 0;
            this.zedGraphControl2.Size = new System.Drawing.Size(574, 184);
            this.zedGraphControl2.TabIndex = 1;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl3.IsEnableHZoom = false;
            this.zedGraphControl3.IsEnableVZoom = false;
            this.zedGraphControl3.IsEnableWheelZoom = false;
            this.zedGraphControl3.Location = new System.Drawing.Point(12, 386);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0;
            this.zedGraphControl3.ScrollMaxX = 0;
            this.zedGraphControl3.ScrollMaxY = 0;
            this.zedGraphControl3.ScrollMaxY2 = 0;
            this.zedGraphControl3.ScrollMinX = 0;
            this.zedGraphControl3.ScrollMinY = 0;
            this.zedGraphControl3.ScrollMinY2 = 0;
            this.zedGraphControl3.Size = new System.Drawing.Size(574, 184);
            this.zedGraphControl3.TabIndex = 2;
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl4.IsEnableHZoom = false;
            this.zedGraphControl4.IsEnableVZoom = false;
            this.zedGraphControl4.IsEnableWheelZoom = false;
            this.zedGraphControl4.Location = new System.Drawing.Point(12, 576);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollGrace = 0;
            this.zedGraphControl4.ScrollMaxX = 0;
            this.zedGraphControl4.ScrollMaxY = 0;
            this.zedGraphControl4.ScrollMaxY2 = 0;
            this.zedGraphControl4.ScrollMinX = 0;
            this.zedGraphControl4.ScrollMinY = 0;
            this.zedGraphControl4.ScrollMinY2 = 0;
            this.zedGraphControl4.Size = new System.Drawing.Size(574, 184);
            this.zedGraphControl4.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(511, 774);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // GraphicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 809);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.zedGraphControl4);
            this.Controls.Add(this.zedGraphControl3);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "GraphicForm";
            this.Text = "Графики значений параметров";
            this.Load += new System.EventHandler(this.GraphicForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private System.Windows.Forms.Button btnClose;
    }
}