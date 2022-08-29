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
    public partial class AlarmForm : Form
    {
        public AlarmForm(ListBox lstbx_err)
        {
            InitializeComponent();
            foreach(string strAlarm in lstbx_err.Items)
                listBox1.Items.Add(strAlarm);
        }
    }
}
