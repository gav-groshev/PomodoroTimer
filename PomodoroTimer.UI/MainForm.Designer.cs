namespace PomodoroTimer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            titleBar = new Panel();
            settingsBtn = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            minimizeBtn = new Button();
            closeBtn = new Button();
            trayIcon = new NotifyIcon(components);
            trayContextMenu = new ContextMenuStrip(components);
            openToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            startBtn = new Button();
            timeLbl = new Label();
            stopBtn = new Button();
            shortBreakBtn = new Button();
            longBreakBtn = new Button();
            nextBreakLbl = new Label();
            pomodoroCounterLbl = new Label();
            extraLongBreakBtn = new Button();
            label4 = new Label();
            titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            trayContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // titleBar
            // 
            titleBar.Controls.Add(settingsBtn);
            titleBar.Controls.Add(label1);
            titleBar.Controls.Add(pictureBox1);
            titleBar.Controls.Add(minimizeBtn);
            titleBar.Controls.Add(closeBtn);
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(418, 35);
            titleBar.TabIndex = 0;
            // 
            // settingsBtn
            // 
            settingsBtn.BackgroundImage = (Image)resources.GetObject("settingsBtn.BackgroundImage");
            settingsBtn.BackgroundImageLayout = ImageLayout.Center;
            settingsBtn.Dock = DockStyle.Right;
            settingsBtn.FlatAppearance.BorderSize = 0;
            settingsBtn.FlatStyle = FlatStyle.Flat;
            settingsBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            settingsBtn.Location = new Point(313, 0);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(35, 35);
            settingsBtn.TabIndex = 3;
            settingsBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Light SemiCondensed", 16F);
            label1.Location = new Point(41, 1);
            label1.Name = "label1";
            label1.Size = new Size(150, 27);
            label1.TabIndex = 2;
            label1.Text = "Pomodoro Timer";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // minimizeBtn
            // 
            minimizeBtn.Dock = DockStyle.Right;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            minimizeBtn.Location = new Point(348, 0);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.Size = new Size(35, 35);
            minimizeBtn.TabIndex = 1;
            minimizeBtn.Text = "__";
            minimizeBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            closeBtn.Dock = DockStyle.Right;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            closeBtn.Location = new Point(383, 0);
            closeBtn.Margin = new Padding(1);
            closeBtn.Name = "closeBtn";
            closeBtn.Padding = new Padding(0, 6, 5, 0);
            closeBtn.Size = new Size(35, 35);
            closeBtn.TabIndex = 0;
            closeBtn.Text = "✕";
            closeBtn.TextAlign = ContentAlignment.TopRight;
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // trayIcon
            // 
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "Pomodoro Timer";
            trayIcon.Visible = true;
            trayIcon.MouseClick += trayIcon_MouseClick;
            trayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;
            // 
            // trayContextMenu
            // 
            trayContextMenu.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, closeToolStripMenuItem });
            trayContextMenu.Name = "contextMenuStrip1";
            trayContextMenu.Size = new Size(104, 48);
            trayContextMenu.Text = "Pomodoro Timer";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // startBtn
            // 
            startBtn.BackgroundImage = (Image)resources.GetObject("startBtn.BackgroundImage");
            startBtn.BackgroundImageLayout = ImageLayout.Stretch;
            startBtn.FlatAppearance.BorderColor = Color.White;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.ImageAlign = ContentAlignment.TopCenter;
            startBtn.Location = new Point(222, 81);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(70, 70);
            startBtn.TabIndex = 1;
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // timeLbl
            // 
            timeLbl.AutoSize = true;
            timeLbl.Font = new Font("Bahnschrift Light SemiCondensed", 45F);
            timeLbl.Location = new Point(36, 102);
            timeLbl.Name = "timeLbl";
            timeLbl.Size = new Size(152, 72);
            timeLbl.TabIndex = 3;
            timeLbl.Text = "00:00";
            // 
            // stopBtn
            // 
            stopBtn.BackgroundImage = (Image)resources.GetObject("stopBtn.BackgroundImage");
            stopBtn.BackgroundImageLayout = ImageLayout.Stretch;
            stopBtn.FlatAppearance.BorderColor = Color.White;
            stopBtn.FlatStyle = FlatStyle.Flat;
            stopBtn.Location = new Point(313, 81);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(70, 70);
            stopBtn.TabIndex = 4;
            stopBtn.UseVisualStyleBackColor = true;
            stopBtn.Click += stopBtn_Click;
            // 
            // shortBreakBtn
            // 
            shortBreakBtn.FlatAppearance.BorderColor = Color.Silver;
            shortBreakBtn.FlatStyle = FlatStyle.Flat;
            shortBreakBtn.Location = new Point(222, 194);
            shortBreakBtn.Name = "shortBreakBtn";
            shortBreakBtn.Size = new Size(161, 25);
            shortBreakBtn.TabIndex = 5;
            shortBreakBtn.Text = "00:05:00";
            shortBreakBtn.UseVisualStyleBackColor = true;
            shortBreakBtn.Click += shortBreakBtn_Click;
            // 
            // longBreakBtn
            // 
            longBreakBtn.FlatAppearance.BorderColor = Color.Silver;
            longBreakBtn.FlatStyle = FlatStyle.Flat;
            longBreakBtn.Location = new Point(222, 225);
            longBreakBtn.Name = "longBreakBtn";
            longBreakBtn.Size = new Size(161, 25);
            longBreakBtn.TabIndex = 6;
            longBreakBtn.Text = "00:15:00";
            longBreakBtn.UseVisualStyleBackColor = true;
            longBreakBtn.Click += longBreakBtn_Click;
            // 
            // nextBreakLbl
            // 
            nextBreakLbl.AutoSize = true;
            nextBreakLbl.Font = new Font("Bahnschrift Light SemiCondensed", 25F);
            nextBreakLbl.Location = new Point(62, 174);
            nextBreakLbl.Name = "nextBreakLbl";
            nextBreakLbl.Padding = new Padding(7, 0, 0, 0);
            nextBreakLbl.Size = new Size(94, 41);
            nextBreakLbl.TabIndex = 7;
            nextBreakLbl.Text = "05:00";
            // 
            // pomodoroCounterLbl
            // 
            pomodoroCounterLbl.AutoSize = true;
            pomodoroCounterLbl.Font = new Font("Bahnschrift Light SemiCondensed", 15F);
            pomodoroCounterLbl.Location = new Point(36, 77);
            pomodoroCounterLbl.Name = "pomodoroCounterLbl";
            pomodoroCounterLbl.Size = new Size(155, 24);
            pomodoroCounterLbl.TabIndex = 8;
            pomodoroCounterLbl.Text = "Pomodoro count: 0";
            // 
            // extraLongBreakBtn
            // 
            extraLongBreakBtn.FlatAppearance.BorderColor = Color.Silver;
            extraLongBreakBtn.FlatStyle = FlatStyle.Flat;
            extraLongBreakBtn.Location = new Point(222, 256);
            extraLongBreakBtn.Name = "extraLongBreakBtn";
            extraLongBreakBtn.Size = new Size(161, 25);
            extraLongBreakBtn.TabIndex = 9;
            extraLongBreakBtn.Text = "00:30:00";
            extraLongBreakBtn.UseVisualStyleBackColor = true;
            extraLongBreakBtn.Click += extraLongBreakBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift Light SemiCondensed", 15F);
            label4.Location = new Point(222, 164);
            label4.Name = "label4";
            label4.Size = new Size(97, 24);
            label4.TabIndex = 10;
            label4.Text = "Next break:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(418, 310);
            Controls.Add(label4);
            Controls.Add(extraLongBreakBtn);
            Controls.Add(pomodoroCounterLbl);
            Controls.Add(nextBreakLbl);
            Controls.Add(longBreakBtn);
            Controls.Add(shortBreakBtn);
            Controls.Add(stopBtn);
            Controls.Add(timeLbl);
            Controls.Add(startBtn);
            Controls.Add(titleBar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Pomodoro Timer";
            FormClosing += MainForm_FormClosing;
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            trayContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Panel titleBar;
        private Button closeBtn;
        private Button minimizeBtn;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayContextMenu;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label label1;
        private Button startBtn;
        private Label timeLbl;
        private Button stopBtn;
        private Button shortBreakBtn;
        private Button longBreakBtn;
        private Label nextBreakLbl;
        private Button settingsBtn;
        private Label pomodoroCounterLbl;
        private Button extraLongBreakBtn;
        private Label label4;
    }
}
