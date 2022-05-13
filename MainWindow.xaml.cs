using Cheese_factory.Core.Command;
using Cheese_factory.MVVM.View.UC;
using Cheese_factory.MVVM.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Cheese_factory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }
    }
}
