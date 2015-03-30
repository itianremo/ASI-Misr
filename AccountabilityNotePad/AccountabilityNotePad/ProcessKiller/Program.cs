using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace ProcessKiller
{
    class Program
    {
        static void Main(string[] args)
        {
            //Close The Accountability NotePad Application
            try
            {
                Process[] RunProc = Process.GetProcessesByName("AccountabilityNotePad");
                foreach (Process RP in RunProc)
                {
                    RP.Kill();
                }
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
            }
        }
    }
}
