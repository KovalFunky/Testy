using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static async Task<long> MultiMetod(Label _label1,TextBox _textBox1,TextBox _textBox2)
        {
            UpdateControl(_textBox2, $"Task Start  {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            int[] numbers = Enumerable.Range(0, 10).ToArray();
            Task<long> task = Task.Run(() =>
            {
                UpdateControl(_textBox1, $"Task Start  {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                long total = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    total += numbers[i]; Thread.Sleep(333);
                    
                    UpdateControl(_label1, $"Task Working  {System.Threading.Thread.CurrentThread.ManagedThreadId}  ->  {total}");
                }
                
                UpdateControl(_textBox1, $"Task End  {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                return total;
            });

            return await task;
        }

        private static void UpdateControl(System.Windows.Forms.Control guiControl, string v)
        {
            if (guiControl != null)
            {
                if (guiControl.InvokeRequired)
                {
                    Action safeWrite = delegate { guiControl.Text = v; };
                    guiControl.Invoke(safeWrite);
                }

                guiControl.Text = v;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MultiMetod(label1,textBox1,textBox2);
        }
    }
}
