using Cheese_factory.Core;
using Cheese_factory.MVVM.View.UC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cheese_factory.MVVM.ViewModel
{
    public class MainWindowVM : ObservableObject
    {
        private Frame _screenFrame;
        public MainWindowVM()
        {
            
        }

        public Frame ScreenFrame
        {
            get => _screenFrame;
            set => OnPropertyChangded(nameof(ScreenFrame));
        }

    }
}
