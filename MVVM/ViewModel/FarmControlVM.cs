using Cheese_factory.Core;
using Cheese_factory.Core.Command;
using Cheese_factory.MVVM.View.UC.FarmControlUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Cheese_factory.MVVM.Model;

namespace Cheese_factory.MVVM.ViewModel
{
    public sealed class FarmControlVM : ObservableObject
    {
        #region INotifyPropertyChanged fields
        private Frame _screenFrame;
        #endregion

        public FarmControlVM()
        {
            _screenFrame = new Frame();
            FeedWarehouseCommand = GetNavigationCommand(new FeedWarehouseControl());
            CowCommand = GetNavigationCommand(new CowControl());
            FeedCommand = GetNavigationCommand(new FeedControl());
        }

        public Frame ScreenFrame
        {
            get => _screenFrame;
            set => Set(ref _screenFrame, value, nameof(ScreenFrame));
        }

        public BaseCommand FeedWarehouseCommand { get; private set; }
        public BaseCommand CowCommand { get; private set; }
        public BaseCommand FeedCommand { get; private set; }

       
        private BaseCommand GetNavigationCommand(Control screen)
        {
            return new BaseCommand(x =>
            {
                _screenFrame.Navigate(screen);
            });
        }
    }
}
