using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheese_factory.Core;
using Cheese_factory.Core.Command;
using Cheese_factory.Core.Interface;

namespace Cheese_factory.MVVM.ViewModel.FarmControlUCVM
{
    public sealed class FeedingEmployeeControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private readonly MyDBContext _dbContext;

        public FeedingEmployeeControlVM()
        {
            _dbContext = new MyDBContext();


            ((IDbBaseCommand)this).InitCommands();
        }

        public BaseCommand DeleteItemCommand { get; set; }
        public BaseCommand UpdateItemsCommand { get; set; }
        public BaseCommand AddItemCommand { get; set; }
        public BaseCommand ChangeItemCommand { get; set; }
        public BaseCommand TableClickCommand { get; set; }

        void IInitializeCommands.AddItem(object args)
        {
            throw new NotImplementedException();
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            throw new NotImplementedException();
        }

        void IInitializeCommands.UpdateItems(object args)
        {
            throw new NotImplementedException();
        }

        void IInitializeCommands.ChangeExistingItem(object args)
        {
            throw new NotImplementedException();
        }

        void IInitializeCommands.ClickOnTable(object args)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
