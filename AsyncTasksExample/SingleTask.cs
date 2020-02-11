using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace AsyncTasksExample
{
    class SingleTask
    {

        public delegate void MainFormMethod();
        public MainFormMethod DoSomething;
        
        public void TaskRun()
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;

            if (this.DoSomething != null)
            {
                DoSomething.Invoke();
            }

            Thread.Sleep(5000);

            excel.Quit();

            excel = null;

            GC.Collect();
        }

        public async void TaskRunAsync()
        {
            await Task.Run(() => TaskRun());
        }
    }
}
