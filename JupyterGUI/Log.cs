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
        private string log_buffer = "";
        private Timer tick = new Timer()
        {
            Enabled = true,
            Interval = 100
        };
        public string LogText {
            set
            {
                log_buffer = log_buffer + value;
            }
        }
        public Log()
        {
            InitializeComponent();
            tick.Tick += Tick_Tick;
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            if (log_buffer != "")
                tb_Log.Text = tb_Log.Text + log_buffer + "\r\n";
            log_buffer = "";
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
