using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoMouse
{
    public partial class Form1 : Form
    {
        int Tick = 0;

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;      // The left  button is down.
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;        // The left  button is up.
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;     // The right button is down.
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;       // The right button is down.

        public Form1()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Tick++;
            if (Tick == 10)
            {
                Cursor.Position = new Point(20, 20);
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }
            else if (Tick == 30)
            {
                Cursor.Position = new Point(0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            else if (Tick == 59)
            {
                Cursor.Position = new Point(0, 0);
                Tick = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //F1キーが押されたか調べる
            if (e.KeyData == Keys.F7)
            {
                timer1.Start();
            }
            if (e.KeyData == Keys.F8)
            {
                timer1.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
