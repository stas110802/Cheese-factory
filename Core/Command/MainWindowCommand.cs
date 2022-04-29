using Cheese_factory.MVVM.View.UC;
using System.Windows;

namespace Cheese_factory.Core.Command
{
    public static class MainWindowCommand
    {
        private static MainWindow _window;

        public static void SetWindow(MainWindow window)
        {
            _window = window;
        }

        public static void ChangeToFarmUC(object obj)
        {
            _window.ScreenFrame.Navigate(new FarmControl());
        }
    }
}
