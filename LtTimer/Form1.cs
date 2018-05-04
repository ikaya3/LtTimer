using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LtTimer
{
    public partial class Form1 : Form
    {
        int _remainingInit = 300;
        int _remaining;

        public Form1()
        {
            _remaining = _remainingInit;

            InitializeComponent();
            DrawLabel();
        }

        private void timerSec_Tick(object sender, EventArgs e)
        {
            _remaining--;
            DrawLabel();
            PlayAudio();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Space:
                    if (timerSec.Enabled)
                    {
                        timerSec.Stop();
                    }
                    else
                    {
                        timerSec.Start();
                    }
                    break;
                case Keys.R:
                    timerSec.Stop();
                    _remaining = _remainingInit;
                    DrawLabel();
                    break;
                default:
                    break;
            }
        }

        void DrawLabel()
        {
            var sizeFontPixel = labelTime.Width / 3;
            labelTime.Font = new Font("Ariel", sizeFontPixel, FontStyle.Bold, GraphicsUnit.Pixel);

            labelTime.ForeColor = (_remaining >= 0) ? Color.White : Color.Red;

            var remainingAbs = Math.Abs(_remaining);
            labelTime.Text = String.Format("{0}:{1:D2}", remainingAbs / 60, remainingAbs % 60);
        }

        void PlayAudio()
        {
            var filesAudio = new Dictionary<int, string>{
                {  0, "timeup.wav"  },
                { 60, "hurryup.wav" },
            };
            if (filesAudio.ContainsKey(_remaining))
            {
                new System.Media.SoundPlayer(
                    Path.Combine(Environment.CurrentDirectory, "audio", filesAudio[_remaining])).Play();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            DrawLabel();
        }
    }
}
