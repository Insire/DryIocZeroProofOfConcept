using DryIocZero;
using ServiceLibrary;
using System.Diagnostics;
using System.Windows;

namespace WpfApp1
{
    public partial class App : Application
    {
        private readonly Container _container = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow()
            {
                DataContext = _container.Resolve<ServicesViewModel>(),
            };

            foreach (var entry in _container.ResolveMany<IMyService>())
            {
                Debug.WriteLine(entry);
            }

            base.OnStartup(e);

            mainWindow.Show();
        }
    }
}
