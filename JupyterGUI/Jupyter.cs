using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace JupyterGUI
{
    public partial class Jupyter : Form
    {
        private Process ps;
        private Log frm_log;

        public Jupyter()
        {
            InitializeComponent();
            frm_log = new Log();
        }

        private void btn_browse_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_dir.Text = dlg.SelectedPath;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        private void Jupyter_Load(object sender, EventArgs e)
        {
            cb_ip.Items.Clear();
            string hostname = Dns.GetHostName();
            try
            {
                IPHostEntry ip_list = Dns.GetHostByName(hostname);
                foreach (IPAddress ip in ip_list.AddressList)
                {
                    cb_ip.Items.Add(
                        String.Format("{0}.{1}.{2}.{3}",
                        ip.GetAddressBytes()[0],
                        ip.GetAddressBytes()[1],
                        ip.GetAddressBytes()[2],
                        ip.GetAddressBytes()[3]));
                }
                cb_ip.Items.Add("127.0.0.1");
                cb_ip.Items.Add("0.0.0.0");
                cb_ip.SelectedIndex = cb_ip.Items.Count - 1;
            }
            catch (Exception)
            {

            }
            tb_dir.Text = Properties.Settings.Default.dir;
            cb_ip.Text = Properties.Settings.Default.ip;
            tb_port.Text = Properties.Settings.Default.port;
            cb_browser.Checked = Properties.Settings.Default.no_browser;
        }

        private void Jupyter_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notify.Visible = true;
                this.ShowInTaskbar = false;
                notify.ShowBalloonTip(3, "Jupyter", "Jupytyer-notebook is running.", ToolTipIcon.Info);                
            }
        }

        private void Jupyter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ps != null)
                ps.Kill();
            Properties.Settings.Default.dir = tb_dir.Text;
            Properties.Settings.Default.ip = cb_ip.Text;
            Properties.Settings.Default.port = tb_port.Text;
            Properties.Settings.Default.no_browser = cb_browser.Checked;
            notify.Visible = false;
            Properties.Settings.Default.Save();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(tb_port.Text);
                string[] a_ip = cb_ip.Text.Split('.');
                byte[] ip = new byte[4];
                ip[0] = byte.Parse(a_ip[0]);
                ip[1] = byte.Parse(a_ip[1]);
                ip[2] = byte.Parse(a_ip[2]);
                ip[3] = byte.Parse(a_ip[3]);

                if (port > 0 && port < 65535)
                {
                    TcpListener tcp = new TcpListener(new IPAddress(ip), port);
                    tcp.Start();
                    tcp.Stop();
                }
                else
                {
                    tb_port.Focus();
                    MessageBox.Show("Port is busy or number not between 1-65534", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                tb_port.Focus();
                MessageBox.Show("Port is busy or number not between 1-65534", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string jupyter_dir = this.Text = GetFullPath("jupyter-notebook.exe");
            if (jupyter_dir == null)
            {
                MessageBox.Show("Can not find jupyter-notebook.exe", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            ProcessStartInfo ps_info = new ProcessStartInfo();
            ps_info.FileName = jupyter_dir;
            ps_info.WindowStyle = ProcessWindowStyle.Hidden;
            ps_info.Arguments = string.Format("{0} --ip={1} --port={2} --notebook-dir={3}",
               cb_browser.Checked ? "--no-browser" : "",
               cb_ip.Text,
               tb_port.Text,
               tb_dir.Text);
            ps_info.CreateNoWindow = true;
            ps_info.UseShellExecute = false;
            ps_info.RedirectStandardOutput = true;
            ps_info.RedirectStandardError = true;
            ps_info.RedirectStandardInput = true;
            ps = Process.Start(ps_info);
            ps.Exited += Ps_Disposed;
            ps.Disposed += Ps_Disposed;
            ps.OutputDataReceived += Ps_OutputDataReceived;
            ps.ErrorDataReceived += Ps_ErrorDataReceived;
            ps.BeginErrorReadLine();
            ps.BeginOutputReadLine();
            btn_browse_folder.Enabled = false;
            tb_port.Enabled = false;
            cb_browser.Enabled = false;
            cb_ip.Enabled = false;
            btn_stop.Enabled = true;
            btn_start.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            if (notify.Visible)
                notify.ShowBalloonTip(5, "Jupyter", "Service started.", ToolTipIcon.Info);
        }

        private void Ps_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            frm_log.LogText = e.Data + "\r\n";
        }

        private void Ps_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            frm_log.LogText = e.Data + "\r\n";
        }

        private void Ps_Disposed(object sender, EventArgs e)
        {
            btn_browse_folder.Enabled = true;
            tb_port.Enabled = true;
            cb_browser.Enabled = true;
            cb_ip.Enabled = true;
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
        }

        private void cb_browser_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            Properties.Settings.Default.no_browser = cb.Checked;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            ps.Kill();
            Ps_Disposed(null, null);
            if (notify.Visible)
                notify.ShowBalloonTip(5, "Jupyter", "Service stoped.", ToolTipIcon.Info);
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            frm_log.Show();
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            notify.Visible = false;
            this.ShowInTaskbar = true;
        }
    }
}
