﻿using System;
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
using Cheese_factory.MVVM.ViewModel;

namespace Cheese_factory.MVVM.View.UC
{
    /// <summary>
    /// Interaction logic for ProductionControl.xaml
    /// </summary>
    public partial class ProductionControl : UserControl
    {
        public ProductionControl()
        {
            InitializeComponent();
            DataContext = new ProductionControlVM();
        }
    }
}
