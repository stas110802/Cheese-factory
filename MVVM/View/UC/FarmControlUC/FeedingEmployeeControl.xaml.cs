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
using Cheese_factory.MVVM.ViewModel.FarmControlUCVM;

namespace Cheese_factory.MVVM.View.UC.FarmControlUC
{
    /// <summary>
    /// Interaction logic for FeedingEmployeeControl.xaml
    /// </summary>
    public partial class FeedingEmployeeControl : UserControl
    {
        public FeedingEmployeeControl()
        {
            InitializeComponent();
            DataContext = new FeedingEmployeeControlVM();
        }
    }
}
