using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Pti
{
    public partial class GraphicForm : Form
    {
        Korpus krp;
        public GraphicForm(Korpus krp)
        {
            InitializeComponent();
            this.krp = krp;
        }



        private void CreateGraph( int val_num, ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            // Задаем название графика и сторон
            myPane.Legend.IsVisible = false;
            myPane.Title.IsVisible = false;
            myPane.Title.FontSpec.Size = 14;

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
            myPane.XAxis.Scale.FontSpec.Size = 10;
            myPane.XAxis.Scale.IsVisible = true;
            myPane.YAxis.Scale.FontSpec.Size = 10;

            // Установим размеры шрифтов для подписей по осям
            myPane.XAxis.Title.IsVisible = true;
            myPane.XAxis.Title.FontSpec.Size = 10;
            myPane.YAxis.Title.IsVisible = true;
            myPane.YAxis.Title.FontSpec.Size = 14;
            // --------------------------------


            if ((val_num == 0) || (val_num == 1))
            {
                myPane.YAxis.Scale.Min = 0;
                myPane.YAxis.Scale.Max = 40;
            }
            else if ((val_num == 2) || (val_num == 3))
            {
                myPane.YAxis.Scale.Min = 0;
                myPane.YAxis.Scale.Max = 110;
            }

            myPane.XAxis.Type = AxisType.Date;
            
            myPane.XAxis.Scale.Format = "dd.MM\r\nHH:mm";
            //myPane.XAxis.Scale.FormatAuto = true;
            
            // строим синусойду
            double x, y;
            double xt;
            PointPairList list1 = new PointPairList();

            for (int i = 0; i < 30; i++)
            {
                x = i;
                if (krp.mas_time[val_num][29 - i] != new DateTime())
                {
                    xt = (XDate)krp.mas_time[val_num][29 - i];
                    y = krp.mas_t1[val_num][29 - i];
                    list1.Add(xt, y);
                }
            }
            // ----------------

            LineItem myCurve = myPane.AddCurve("T1", list1, Color.Blue, SymbolType.Circle); // отрисовываем график
            myCurve.Line.Width = 2.0f;
            myCurve.Symbol.Size = 4.0f;
            myCurve.Symbol.Fill = new Fill(Color.Blue);
            
            zgc.AxisChange();
            zgc.Invalidate();

        }

        private void GraphicForm_Load(object sender, EventArgs e)
        {
            CreateGraph(0, zedGraphControl1);
            CreateGraph(1, zedGraphControl2);
            CreateGraph(2, zedGraphControl3);
            CreateGraph(3, zedGraphControl4);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
       
    }
}
