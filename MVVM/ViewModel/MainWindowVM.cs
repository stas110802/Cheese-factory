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
    public sealed class MainWindowVM : ObservableObject
    {
        #region INotifyPropertyChanged fields
        private Frame _screenFrame;
        #endregion

        public MainWindowVM()
        {
            _screenFrame = new Frame();
            FarmControlCommand = new BaseCommand(OpenFarmControl);
        }

        public Frame ScreenFrame 
        { 
            get => _screenFrame;
            set => Set(ref _screenFrame, value, nameof(ScreenFrame));
        }

        public BaseCommand FarmControlCommand { get; private set; } 

        private void OpenFarmControl(object obj = null)
        {
            _screenFrame.Navigate(new FarmControl());
        }

    }
}
