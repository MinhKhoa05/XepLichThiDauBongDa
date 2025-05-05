using System;
using System.Windows.Forms;
using CORE;
using GUI.Forms;

namespace GUI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FrmLoading());

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Logger.Instance.Log("Lỗi không xác định: " + e.ExceptionObject.ToString(), LogLevel.Error);
            };

        }
    }
}
