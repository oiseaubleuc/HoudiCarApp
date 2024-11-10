using HoudiCarApp;
using System.Windows;

namespace HoudiCarApp
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run(new MainWindow()); 
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

        }
    }
}
