using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.OleDb;

namespace Pti
{
    public class Korpus
    {
        public Int16 pk;
        public string name; //имя корпуса
        public int[] mas_lnk = new int[4]; //links t1,t2,vn,vl
        public bool enabled; //состояние корпуса
        public string Enabled
        {
            get
            {
                if (enabled)
                    return "ВКЛ.";
                else
                    return "ВЫКЛ.";
            }
        }
        public bool sounded; //звуковое оповещение для корпуса
        public string Sounded
        {
            get
            {
                if (sounded)
                    return "ВКЛ.";
                else
                    return "ВЫКЛ.";
            }
        }
        public DateTime dateBegin; //дата заселения

        public string path; // путь к проколу
        public int error;
        
        public float[][] mas_t1 = new float[4][]; //массивы значений, считанных из протокола
        public DateTime[][] mas_time = new DateTime[4][];

        public float[] curr_values = new float[4]; //текущие (последние) значения t1 t2 vn vl

        //0 эл. - нижн предел, 1 эл. - верхний предел границ
        public int[,] lim_values = new int[3,2];  //t1, t2, vn

        public int days_keep; //день содержания (кол-во дней от начала заселения до текущей даты)

        public OleDbConnection connect;

        public DataGridView dgv;

        public Korpus(
            Int16 pk,
            string name,
            string path,
            int lnk_t1,
            int lnk_t2,
            int lnk_vn,
            int lnk_vl,
            int t1_up,
            int t1_dn,
            int t2_up,
            int t2_dn,
            int vn_up,
            int vn_dn,
            bool enabled,
            bool sounded,
            DateTime dateBegin
            )
        {
            this.pk = pk;
            this.name = name;
            this.path = path;
            this.mas_lnk[0] = lnk_t1;
            this.mas_lnk[1] = lnk_t2;
            this.mas_lnk[2] = lnk_vn;
            this.mas_lnk[3] = lnk_vl;
            
            this.lim_values[0,0] = t1_dn;
            this.lim_values[0,1] = t1_up;
            this.lim_values[1,0] = t2_dn;
            this.lim_values[1,1] = t2_up;
            this.lim_values[2,0] = vn_dn;
            this.lim_values[2,1] = vn_up;

//            this.limit_vn = vn_dn;
            this.enabled = enabled;
            this.sounded = sounded;
            this.dateBegin = dateBegin;
            TimeSpan dif = DateTime.Now - this.dateBegin;
            days_keep = dif.Days + 1;
            this.error = 0;
            this.mas_t1[0] = new float[Global.Count_Values];
            this.mas_t1[1] = new float[Global.Count_Values];
            this.mas_t1[2] = new float[Global.Count_Values];
            this.mas_t1[3] = new float[Global.Count_Values];
            for (int i = 0; i < 4; i++)
                this.mas_time[i] = new DateTime[Global.Count_Values];
            
            this.connect = new OleDbConnection();
        }

        private void createDGV()
        {
            dgv = new DataGridView();
            dgv.Name = "korpus:"+name;
            dgv.ColumnCount = 1;
            dgv.Columns[0].Name = name;
            dgv.Columns[0].HeaderText = name;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.RowCount = 8;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

    }

    static class Global
    {
        static public int Timeout_values = 15; //таймаут для датчиков, в минутах
        static public int Time_repeat_queryes = 20; //периодичность опроса протоколов, в секундах
        static public int Time_repeat_graphs = 10; //периодичность изменения графиков, в секундах
        static public int Count_Values = 30;
    }

}
