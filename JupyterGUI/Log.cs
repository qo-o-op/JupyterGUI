using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JupyterGUI
{
    public partial class Log : Form
    {
        public string LogText { set
            {
                tb_Log.Text = tb_Log.Text + value;
            }
        }
        public Log()
        {
            InitializeComponent();
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
