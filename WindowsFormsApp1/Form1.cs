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

        private static async Task<long> MultiMetod(Label _label1,TextBox _textBox1)
        {
            int[] numbers = Enumerable.Range(0, 10).ToArray();
            Task<long> task = Task.Run(() =>
            {
                //Console.WriteLine($"Task Start  {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                _textBox1.Text=($"Task Start  {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                long total = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    total += numbers[i]; Thread.Sleep(333); _label1.Text =($"Task Working  {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                }
                _label1.Text = ($"Task End  {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                return total;
            });

            return await task;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MultiMetod(label1,textBox1);
        }
    }
}
