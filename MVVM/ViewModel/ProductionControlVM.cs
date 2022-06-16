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
        }

        public Frame ScreenFrame
        {
            get => _screenFrame;
            set => Set(ref _screenFrame, value, nameof(ScreenFrame));
        }

        public BaseCommand EquipmentCommand { get; private set; }// оборудование 
        public BaseCommand EmployeeEquipmentCommand { get; private set; }// оборудование сотрудника
    }
}
