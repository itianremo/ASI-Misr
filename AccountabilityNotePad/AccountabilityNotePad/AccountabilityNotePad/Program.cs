using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace AccountabilityNotePad
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ok;
            System.Threading.Mutex m = new System.Threading.Mutex(true, "AccountabilityNotePad", out ok);
            if (!ok)
            {
                //MessageBox.Show("Another instance is already running.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            Application.Exit();
            GC.KeepAlive(m); 

            //bool newMutexCreated = false;
            ////string mutexName = "Local\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            //string mutexName = "AccountabilityNotePad";
            //Mutex mutex = null;
            //try
            //{
            //    mutex = new Mutex(false, mutexName, out newMutexCreated);
            //}
            //catch(Exception Ecp)
            //{
            //    Application.Exit();
            //}
            //if (newMutexCreated)
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new LoginForm());
            //    //SingleInstance.SingleApplication.Run(new LoginForm());

            //}            
        }
    }
}