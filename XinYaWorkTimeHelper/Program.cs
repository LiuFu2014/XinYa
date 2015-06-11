using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace XinYaWorkTimeHelper
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_Login());
            try
            {
                string proc = Process.GetCurrentProcess().ProcessName;
                Process[] processes = Process.GetProcessesByName(proc);
                if (processes.Length > 1)
                {
                    MessageBox.Show("请勿重复运行系统！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frm_Login());
                }
            }
            catch (Exception ex)
            {
                LogExecute.WriteLineDataLog(ex.ToString());
                MessageBox.Show("程序出现未知异常，需要关闭！");
            }
        }

    }
}
