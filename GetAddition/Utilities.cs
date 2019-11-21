using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Diagnostics;

namespace GetAddition
{
    public class Utilities
    {
        public static void KillProcessAndChildren(int pid)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
             ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {

                try
                {
                    KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
                }
                catch
                {
                    break;
                }
            }

            try
            {
                Process proc = Process.GetProcessById(pid);

                proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }

        public static void KillProcessAndChildren(string p_name)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
              ("Select * From Win32_Process Where Name = '" + p_name + "'");

            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                try
                {
                    KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
                }
                catch (ArgumentException)
                {
                    break;
                }
            }
        }


    }
}
