using DryIocZero;

namespace WpfApp1
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var container = new Container();
            var service = container.Resolve<IMyService>();

            DataContext = service;
        }
    }
}
