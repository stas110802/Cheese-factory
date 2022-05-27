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
            FarmControlCommand = MainWindow
                .MainScreenFrame
                .GetNavigationCommand(new FarmControl());

            ProductionControlCommand = MainWindow
                .MainScreenFrame
                .GetNavigationCommand(new ProductionControl());
        }

        public BaseCommand FarmControlCommand { get; private set; }
        public BaseCommand ProductionControlCommand { get; private set; }

       
    }
}
