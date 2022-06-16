using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cheese_factory.MVVM.ViewModel.ProductionControlUCVM;

namespace Cheese_factory.MVVM.View.UC.ProductionControlUC
{
    /// <summary>
    /// Interaction logic for ProcessingStepControl.xaml
    /// </summary>
    public partial class ProcessingStepControl : UserControl
    {
        public ProcessingStepControl()
        {
            InitializeComponent();
            DataContext = new ProcessingStepControlVM();
        }
    }
}
