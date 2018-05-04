using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LtTimer
{
    public partial class Form1 : Form
    {
        int _remaining = 300;

        public Form1()
        {
            InitializeComponent();
            DrawLabel();
        }

        private void timerSec_Tick(object sender, EventArgs e)
        {
            _remaining--;
            DrawLabel();
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

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            DrawLabel();
        }
    }
}
