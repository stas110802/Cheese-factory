using Cheese_factory.MVVM.ViewModel;
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

namespace Cheese_factory.MVVM.View.UC.FarmControlUC
{
    /// <summary>
    /// Логика взаимодействия для MilkCollectionControl.xaml
    /// </summary>
    public partial class MilkCollectionControl : UserControl
    {
        public MilkCollectionControl()
        {
            InitializeComponent();
            DataContext = new MilkCollectionControlVM();
        }
    }
}
