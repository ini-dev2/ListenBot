using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ListenBot.Scripts;

namespace ListenBot
{
    public partial class MainForm : Form
    {
        private Calculater calculater;
        private Utils utils;

        private List<int> playersId;

        private string _lastClipboardText = string.Empty;
        private Timer _clipboardCheckTimer;
        private bool _isFirstRun = true;
        public MainForm()
        {
            InitializeComponent();
            InitializeClipboardListener();
            calculater = new Calculater();
            utils = new Utils();
        }

        private void InitializeClipboardListener()
        {
            _clipboardCheckTimer = new Timer();
            _clipboardCheckTimer.Interval = 500;
            _clipboardCheckTimer.Tick += ClipboardCheckTimer_Tick;
            _clipboardCheckTimer.Start();
        }

        private void ClipboardCheckTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    string currentText = Clipboard.GetText();

                    if (_isFirstRun)
                    {
                        _lastClipboardText = currentText;
                        _isFirstRun = false;
                        return;
                    }

                    if (currentText != _lastClipboardText)
                    {
                        _lastClipboardText = currentText;
                        textBox2.Text += _lastClipboardText + ";" + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка доступа к буферу обмена: {ex.Message}");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            playersId = utils.GetNumber(textBox2);

            System.Threading.Thread.Sleep(2);

            double result = calculater.CalcResult(playersId);
            textBox1.Text = utils.ExecuteCommand(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = utils.ExecuteCommand(-1);
        }
    }
}