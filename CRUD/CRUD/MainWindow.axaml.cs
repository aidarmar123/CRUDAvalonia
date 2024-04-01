using Avalonia.Controls;

namespace CRUD
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.mainWindow = this;
            UCMainWindow.Content = new AllUser();
        }
    }
}