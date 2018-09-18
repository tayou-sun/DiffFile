using System;
using System.Windows.Forms;
using FileDiff.Presenter;

namespace FileDiff
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainPresenter = new MainPresenter();
            mainPresenter.Run();
        }
    }
}
