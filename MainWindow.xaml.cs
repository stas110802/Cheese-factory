using Cheese_factory.Core.Command;
using Cheese_factory.MVVM.View.UC;
using Cheese_factory.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cheese_factory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainScreenFrame;
        public MainWindow()
        {
            InitializeComponent();
            var succes = ScreenFrame.Navigate(new MainMenuControl());

            if(succes)
            {
                MainScreenFrame = ScreenFrame;
                DataContext = new MainMenuControlVM();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
        // создать класс ToolCommande и реализовать базовые команды (add, delete, update, change)
    }
}
