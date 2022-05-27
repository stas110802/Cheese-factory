using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cheese_factory.Core.Command
{
    public static class MainBaseCommand
    {
        public static BaseCommand GetNavigationCommand(this Frame frame, Control screen)
        {
            return new BaseCommand(x =>
            {
                frame.Navigate(screen);
            });
        }
    }
}
