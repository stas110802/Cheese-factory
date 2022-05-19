using Cheese_factory.Core;
using Cheese_factory.Core.Command;
using Cheese_factory.MVVM.View.UC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cheese_factory.MVVM.ViewModel
{
    public sealed class MainMenuControlVM : ObservableObject
    {
        public MainMenuControlVM()
        {
            FarmControlCommand = new BaseCommand(OpenFarmControl);
        }

        public BaseCommand FarmControlCommand { get; private set; } 

        private void OpenFarmControl(object obj = null)
        {
            MainWindow.MainScreenFrame
                .Navigate(new FarmControl());
        }
    }
}
