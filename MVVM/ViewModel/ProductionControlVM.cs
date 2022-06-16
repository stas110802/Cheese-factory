using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Cheese_factory.Core;
using Cheese_factory.Core.Command;
using Cheese_factory.Core.Interface;
using Cheese_factory.MVVM.View.UC.ProductionControlUC;

namespace Cheese_factory.MVVM.ViewModel
{
    public sealed class ProductionControlVM: ObservableObject
    {
        private Frame _screenFrame;
        
        public ProductionControlVM()
        {
            _screenFrame = new Frame();
            EquipmentCommand = _screenFrame.GetNavigationCommand(new EquipmentControl());
            StorageCommand = _screenFrame.GetNavigationCommand(new StorageControl());
            ProcessingStepCommand = _screenFrame.GetNavigationCommand(new ProcessingStepControl());
            BatchCommand = _screenFrame.GetNavigationCommand(new BatchControl());
            CheeseCommand = _screenFrame.GetNavigationCommand(new CheeseControl());
            BatchCheeseCommand = _screenFrame.GetNavigationCommand(new BatchCheeseControl());
        }

        public Frame ScreenFrame
        {
            get => _screenFrame;
            set => Set(ref _screenFrame, value, nameof(ScreenFrame));
        }

        public BaseCommand EquipmentCommand { get; private set; }// оборудование 
        public BaseCommand StorageCommand { get; private set; }// хранилища
        public BaseCommand ProcessingStepCommand { get; private set; }// хранилища
        public BaseCommand BatchCommand { get; private set; }// партия
        public BaseCommand CheeseCommand { get; private set; }// сыр
        public BaseCommand BatchCheeseCommand { get; private set; }// партия сыра
    }
}
