using PomodoroTimer.Core;
using PomodoroTimer.Interfaces;
using PomodoroTimer.Models;
using System.Diagnostics;
using System.Media;
using System.Windows.Forms;

namespace PomodoroTimer
{
    public partial class MainForm : Form
    {
        private bool _isPlaying = false;
        private PomodoroController? _pomodoroController;

        public MainForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            BringToFront();
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (_pomodoroController == null)
            {
                _pomodoroController = new PomodoroController();

                // Подписка на события таймера
                _pomodoroController.OnTick += time =>
                {
                    this.Invoke(() =>
                    {
                        timeLbl.Text = _pomodoroController.GetTimeLeftString();
                    });
                };

                _pomodoroController.OnSessionChanged += session =>
                {
                    this.Invoke(() =>
                    {
                        nextBreakLbl.Text = _pomodoroController.GetNextSessionString();

                        var currentSession = _pomodoroController.GetCurrentSession();
                        SetBreakOverridesActive(currentSession.IsWorkSession);

                        trayIcon.BalloonTipTitle = "Pomodoro Timer";
                        trayIcon.BalloonTipText = $"Новая сессия: {session.Description} ({session.Duration:mm\\:ss})";
                        trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                        trayIcon.ShowBalloonTip(3000);
                        SystemSounds.Asterisk.Play();
                    });
                };

                _pomodoroController.OnPomodoroCountChanged += count =>
                {
                    this.Invoke(() =>
                    {
                        pomodoroCounterLbl.Text = $"Pomodoro count: {count}";
                    });
                };
            }


            if (!_isPlaying)
            {
                _pomodoroController.Play();
                _isPlaying = true;
            }
            else
            {
                _pomodoroController.Pause();
                _isPlaying = false;
            }

            UpdateStartButtonIcon(_isPlaying);
        }

        private void SetBreakOverridesActive(bool isActive)
        {
            shortBreakBtn.Enabled = isActive;
            longBreakBtn.Enabled = isActive;
            extraLongBreakBtn.Enabled = isActive;
        }

        private void UpdateStartButtonIcon(bool isPlaying)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + @"Resources\";
            string fileName = isPlaying ? "pause.png" : "play.png";
            string fullPath = Path.Combine(basePath, fileName);

            if (File.Exists(fullPath))
            {
                startBtn.BackgroundImage = Image.FromFile(fullPath);
                startBtn.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (_pomodoroController != null)
            {
                _pomodoroController.Stop();

                pomodoroCounterLbl.Text = $"Pomodoro count: 0";
                timeLbl.Text = "00:00";
                nextBreakLbl.Text = "05:00";
                UpdateStartButtonIcon(false);
            }


        }

        private void shortBreakBtn_Click(object sender, EventArgs e)
        {
            if (_pomodoroController != null)
            {
                IPomodoroSession breakOverride = new ShortBreakSession();
                nextBreakLbl.Text = breakOverride.LabelText;
                _pomodoroController.SetNextBreakOverride(breakOverride);
            }
        }

        private void extraLongBreakBtn_Click(object sender, EventArgs e)
        {
            if (_pomodoroController != null)
            {
                IPomodoroSession breakOverride = new ExtraLongBreakSession();
                nextBreakLbl.Text = breakOverride.LabelText;
                _pomodoroController.SetNextBreakOverride(breakOverride);
            }
        }

        private void longBreakBtn_Click(object sender, EventArgs e)
        {
            if (_pomodoroController != null)
            {
                IPomodoroSession breakOverride = new LongBreakSession();
                nextBreakLbl.Text = breakOverride.LabelText;
                _pomodoroController.SetNextBreakOverride(breakOverride);
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            trayIcon.MouseDoubleClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    Show();
            };
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                trayContextMenu.Show(MousePosition);
                trayContextMenu.BringToFront();
            }
        }
    }
}
