using System;
using System.Windows;

namespace OdamnRecorder
{
    public partial class App : Application
    {
    }

    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            var mainWindow = new MainWindow();
            app.Run(mainWindow);
        }
    }
}