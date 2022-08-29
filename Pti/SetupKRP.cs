using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pti
{
    public partial class SetupKRP : Form
    {
        Korpus krp;
        Form1 frm;
        bool edit = false;

        public SetupKRP(Form1 frm, string name_frm)
        {
            InitializeComponent();
            this.krp = frm.korpuses[frm.curr_korp];
            FillCmpnt();
            this.frm = frm;
            this.Text = name_frm;
        }

        public SetupKRP(Form1 frm, string name_frm, bool edit)
        {
            InitializeComponent();
            NewFillCmpnt();
            this.frm = frm;
            this.Text = name_frm;
            this.edit = edit;
        }

        private void FillCmpnt()
        {
            txtbx_name.Text = krp.name;
            dtp_dateBegin.Value = krp.dateBegin;
            txtbx_t1_dn.Text = krp.lim_values[0, 0].ToString();
            txtbx_t1_up.Text = krp.lim_values[0, 1].ToString();
            txtbx_t2_dn.Text = krp.lim_values[1, 0].ToString();
            txtbx_t2_up.Text = krp.lim_values[1, 1].ToString();
            txtbx_vn_dn.Text = krp.lim_values[2, 0].ToString();
            txtbx_vn_up.Text = krp.lim_values[2, 1].ToString();
            
            txtbx_t1_lnk.Text = krp.mas_lnk[0].ToString();
            txtbx_t2_lnk.Text = krp.mas_lnk[1].ToString();
            txtbx_vn_lnk.Text = krp.mas_lnk[2].ToString();
            txtbx_vl_lnk.Text = krp.mas_lnk[3].ToString();

            txtbx_path.Text = krp.path;
        }

        private void NewFillCmpnt()
        {
            txtbx_name.Text = "";
            dtp_dateBegin.Value = DateTime.Now;
            txtbx_t1_dn.Text = "0";
            txtbx_t1_up.Text = "0";
            txtbx_t2_dn.Text = "0";
            txtbx_t2_up.Text = "0";
            txtbx_vn_dn.Text = "0";
            txtbx_vn_up.Text = "0";

            txtbx_t1_lnk.Text = "-1";
            txtbx_t2_lnk.Text = "-1";
            txtbx_vn_lnk.Text = "-1";
            txtbx_vl_lnk.Text = "-1";

            txtbx_path.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                if (frm.db.InsertRowParameters(
                    0,
                    txtbx_name.Text, //name

                    txtbx_t1_lnk.Text, //lnk
                    txtbx_t2_lnk.Text,
                    txtbx_vn_lnk.Text,
                    txtbx_vl_lnk.Text,

                    txtbx_t1_up.Text, //limits
                    txtbx_t1_dn.Text,
                    txtbx_t2_up.Text,
                    txtbx_t2_dn.Text,
                    txtbx_vn_up.Text,
                    txtbx_vn_dn.Text,
                    txtbx_path.Text,

                    dtp_dateBegin.Value,
                    false
                    ))
                {
                    System.Threading.Thread.Sleep(1000);

                }
                else 
                    MessageBox.Show("Не удалось добавить корпус");

            }
            else
            {
                if (frm.db.UpdateRowParameters(
                    frm.curr_korp_pk, //ID
                    txtbx_name.Text, //name

                    txtbx_t1_lnk.Text, //lnk
                    txtbx_t2_lnk.Text,
                    txtbx_vn_lnk.Text,
                    txtbx_vl_lnk.Text,

                    txtbx_t1_up.Text, //limits
                    txtbx_t1_dn.Text,
                    txtbx_t2_up.Text,
                    txtbx_t2_dn.Text,
                    txtbx_vn_up.Text,
                    txtbx_vn_dn.Text,
                    txtbx_path.Text,

                    dtp_dateBegin.Value,
                    true
                    )
                    )
                {
                    System.Threading.Thread.Sleep(1000);

                }
                else MessageBox.Show("Не удалось сохранить параметры");
            }

            Close();

        }

        
    }
}
