using Cheese_factory.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.Core.Interface
{
    public interface IDbBaseCommand : IInitializeCommands
    {
        public BaseCommand DeleteItemCommand { get; set; }
        public BaseCommand UpdateItemsCommand { get; set; }
        public BaseCommand AddItemCommand { get; set; }
        public BaseCommand ChangeItemCommand { get; set; }
        public BaseCommand TableClickCommand { get; set; }

        /// <summary>
        /// Binds commands and methods
        /// </summary>
        public void InitCommands()
        {
            AddItemCommand = new BaseCommand(AddItem);
            DeleteItemCommand = new BaseCommand(DeleteSelectedItem);
            UpdateItemsCommand = new BaseCommand(UpdateItems);
            ChangeItemCommand = new BaseCommand(ChangeExistingItem);
            TableClickCommand = new BaseCommand(ClickOnTable);
        }
    }
}

