using ServiceLibrary;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow
    {
        private string _path;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var service = (AsciiConverterService)((Button)sender).DataContext;
            service.Items.Clear();
            foreach (var line in service.Convert(_path).Split("S".ToCharArray()))
            {
                service.Items.Add(line);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _path = ((TextBox)sender).Text;
        }
    }
}
