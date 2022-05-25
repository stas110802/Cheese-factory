using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cheese_factory.Core;
using Cheese_factory.Core.Command;
using Cheese_factory.Core.Interface;
using Cheese_factory.MVVM.Model;

namespace Cheese_factory.MVVM.ViewModel
{
    public sealed class FeedControlVM : ObservableObject, IDbBaseCommand
    {
        private MyDBContext _dbContext;
        private ObservableCollection<Feed> _feeds;
        private Feed _selectedFeed;

        private string _manufacturer;
        private string _name;

        public FeedControlVM()
        {
            _dbContext = new MyDBContext();
            _feeds = new ObservableCollection<Feed>();
            _selectedFeed = new Feed();
        }

        public ObservableCollection<Feed> Feeds
        {
            get => _feeds;
            set => Set(ref _feeds, value, nameof(Feeds));
        }

        public Feed SelectedFeed
        {
            get => _selectedFeed;
            set => Set(ref _selectedFeed, value, nameof(SelectedFeed));
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set => Set(ref _manufacturer, value, nameof(Manufacturer));
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value, nameof(Name));
        }

        public BaseCommand DeleteItemCommand { get; set; }
        public BaseCommand UpdateItemsCommand { get; set; }
        public BaseCommand AddItemCommand { get; set; }
        public BaseCommand ChangeItemCommand { get; set; }
        public BaseCommand TableClickCommand { get; set; }


        void IInitializeCommands.AddItem(object args)
        {
            var item = new Feed()
            {
                Name = _name,
                Manufacturer = _manufacturer
            };
            DBContextCommands.AddItem(_dbContext, _dbContext.Feeds, item);
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
    }
}
