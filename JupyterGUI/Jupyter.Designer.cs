namespace JupyterGUI
{
    partial class Jupyter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jupyter));
            this.tb_dir = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.btn_browse_folder = new System.Windows.Forms.Button();
            this.cb_ip = new System.Windows.Forms.ComboBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_log = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_browser = new System.Windows.Forms.CheckBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_dir
            // 
            this.tb_dir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tb_dir.Location = new System.Drawing.Point(12, 12);
            this.tb_dir.Name = "tb_dir";
            this.tb_dir.ReadOnly = true;
            this.tb_dir.Size = new System.Drawing.Size(248, 22);
            this.tb_dir.TabIndex = 0;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(12, 67);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 20);
            this.tb_port.TabIndex = 1;
            this.tb_port.Text = "8888";
            // 
            // btn_browse_folder
            // 
            this.btn_browse_folder.Location = new System.Drawing.Point(266, 12);
            this.btn_browse_folder.Name = "btn_browse_folder";
            this.btn_browse_folder.Size = new System.Drawing.Size(75, 23);
            this.btn_browse_folder.TabIndex = 2;
            this.btn_browse_folder.Text = "Browse";
            this.btn_browse_folder.UseVisualStyleBackColor = true;
            this.btn_browse_folder.Click += new System.EventHandler(this.btn_browse_folder_Click);
            // 
            // cb_ip
            // 
            this.cb_ip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ip.FormattingEnabled = true;
            this.cb_ip.Location = new System.Drawing.Point(12, 40);
            this.cb_ip.Name = "cb_ip";
            this.cb_ip.Size = new System.Drawing.Size(248, 21);
            this.cb_ip.TabIndex = 3;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 93);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(100, 23);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(126, 93);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(100, 23);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_log
            // 
            this.btn_log.Location = new System.Drawing.Point(240, 93);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(100, 23);
            this.btn_log.TabIndex = 6;
            this.btn_log.Text = "Log";
            this.btn_log.UseVisualStyleBackColor = true;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.menu;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "jupyter notebook";
            this.notify.Visible = true;
            this.notify.Click += new System.EventHandler(this.notify_Click);
            this.notify.DoubleClick += new System.EventHandler(this.notify_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.logToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(99, 92);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cb_browser
            // 
            this.cb_browser.AutoSize = true;
            this.cb_browser.Location = new System.Drawing.Point(126, 70);
            this.cb_browser.Name = "cb_browser";
            this.cb_browser.Size = new System.Drawing.Size(84, 17);
            this.cb_browser.TabIndex = 8;
            this.cb_browser.Text = "--no-browser";
            this.cb_browser.UseVisualStyleBackColor = true;
            this.cb_browser.CheckedChanged += new System.EventHandler(this.cb_browser_CheckedChanged);
            // 
            // Jupyter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 124);
            this.Controls.Add(this.cb_browser);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.cb_ip);
            this.Controls.Add(this.btn_browse_folder);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_dir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Jupyter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jupyter notebook - GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Jupyter_FormClosing);
            this.Load += new System.EventHandler(this.Jupyter_Load);
            this.Resize += new System.EventHandler(this.Jupyter_ResizeEnd);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_dir;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Button btn_browse_folder;
        private System.Windows.Forms.ComboBox cb_ip;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_browser;
    }
}

