using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace DBInstaller
{
    static class Program
    {
        public static int StartBatchNo;
        public static int TargetVersion;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StartBatchNo = 0;
            TargetVersion = Assembly.GetExecutingAssembly().GetName().Version.Major;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}