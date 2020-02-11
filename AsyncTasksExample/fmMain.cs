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

namespace AsyncTasksExample
{
    public partial class fmMain : Form
    {
        SingleTask ST;

        private void Log()
        {
            richTextBox1.Text += @"Log..." + Environment.NewLine;
        }
        
        public fmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (ST == null)
            {
                ST = new SingleTask();
                ST.DoSomething += Log;
                ST.TaskRunAsync();
            }

            Thread.Sleep(1000);

            ST = new SingleTask();
            ST.DoSomething += Log;
            ST.TaskRunAsync();

        }
    }
}
