using Cheese_factory.Core;
using Cheese_factory.Core.Command;
using Cheese_factory.Core.Interface;
using Cheese_factory.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cheese_factory.MVVM.ViewModel
{
    public sealed class FeedWarehouseControlVM : ObservableObject,  IDisposable
    {
        private ObservableCollection<FeedWarehouse> _feedWarehouses;
        private ObservableCollection<Feed> _feeds;
        private ObservableCollection<Warehouse> _warehouses;
        private Feed _selectedFeed;
        private FeedWarehouse _selectedFeedWarehouse;
        private Warehouse _selectedWarehouse;
        private int _count;

        private MyDBContext _dbContext;//todo add interface IDBContexter

        ~FeedWarehouseControlVM()
        {
            Dispose();
        }

        public FeedWarehouseControlVM()
        {
            _dbContext = new MyDBContext();
            NotifyPropertyInit();
            InitFeeds();
            UpdateItems();
            InitCommands();
            AddItemsIntoCollection(_warehouses, _dbContext.Warehouses);
        }

        public ObservableCollection<FeedWarehouse> FeedWarehouses 
        {
            get => _feedWarehouses;
            set => Set(ref _feedWarehouses, value, nameof(FeedWarehouses));
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

        public FeedWarehouse SelectedFeedWarehouse 
        { 
            get => _selectedFeedWarehouse;
            set => Set(ref _selectedFeedWarehouse, value, nameof(SelectedFeedWarehouse));
        }
        public ObservableCollection<Warehouse> Warehouses
        {
            get => _warehouses;
            set => Set(ref _warehouses, value, nameof(Warehouses));
        }

        public Warehouse SelectedWarehouse 
        {
            get => _selectedWarehouse; 
            set => Set(ref _selectedWarehouse, value, nameof(SelectedWarehouse)); 
        }

        public int Count
        {
            get => _count;
            set => Set(ref _count, value, nameof(Count));
        }      

        public BaseCommand DeleteItemCommand { get; set; }
        public BaseCommand UpdateItemsCommand { get; set; }
        public BaseCommand AddItemCommand { get; set; }
        public BaseCommand ChangeItemCommand { get; set; }
        public BaseCommand FeedWarehousesClickCommand { get; set; }

        // rename method
        private void FeedWarehousesIsDoubleClick(object arg = null)
        {
            try
            {
                Count = SelectedFeedWarehouse.Count;
                SelectedFeed = SelectedFeedWarehouse.Feed;
                SelectedWarehouse = SelectedFeedWarehouse.Warehouse;
            }
            catch (Exception) { }
        }

        private void InitFeeds()
        {
            foreach (var item in _dbContext.Feeds)
            {
                _feeds.Add(item);
            }
        }

        private void UpdateItems(object arg = null)
        {
            _feedWarehouses.Clear();
            _warehouses.Clear();
            _feeds.Clear();
            
            DBContextCommands.AddItemsIntoCollection(_feedWarehouses, _dbContext.FeedWarehouses);
            DBContextCommands.AddItemsIntoCollection(_warehouses, _dbContext.Warehouses);
            DBContextCommands.AddItemsIntoCollection(_feeds, _dbContext.Feeds);
        }

        

        //todo add interface INotifyPropertyInitializer
        private void NotifyPropertyInit() 
        {
            _feeds = new ObservableCollection<Feed>();
            _feedWarehouses = new ObservableCollection<FeedWarehouse>();
            _selectedFeed = new Feed();
            _selectedFeedWarehouse = new FeedWarehouse();
            _warehouses = new ObservableCollection<Warehouse>();
        }

        private void InitCommands()
        {
            DeleteItemCommand = new BaseCommand(DeleteSelectedItem);
            UpdateItemsCommand = new BaseCommand(UpdateItems);
            AddItemCommand = new BaseCommand(AddItem);
            ChangeItemCommand = new BaseCommand(ChagneExistingItem);
            FeedWarehousesClickCommand = new BaseCommand(FeedWarehousesIsDoubleClick);
        }
        // by selected
        private void ChagneExistingItem(object obj = null)
        {
            try
            { 
                var oldItem = _dbContext.FeedWarehouses.Find(SelectedFeedWarehouse.ID);

                var newItem = new FeedWarehouse()
                {
                    ID = oldItem.ID,
                    Count = Count,
                    FeedFK = SelectedFeed.ID,
                    WarehouseFK = SelectedWarehouse.ID
                };

                _dbContext
                    .Entry(oldItem).CurrentValues
                    .SetValues(newItem);
                _dbContext.SaveChanges();
                MessageBox.Show("OK");
            }
            catch(Exception ex)
            {
                MessageBox.Show("SOME ERROR! {0}", ex.Message);
            }
        }

        // todo вынести метод в отдельный класс
        private void AddItemsIntoCollection<T>(ObservableCollection<T> collection, DbSet<T> dbSet)
            where T : class
        {
            foreach (var item in dbSet)
            {
                collection.Add(item);
            }
        }

        private void AddItem(object obj = null)
        {
            try
            {
                var item = new FeedWarehouse()
                {
                    Count = Count,
                    FeedFK = SelectedFeed.ID,
                    WarehouseFK = SelectedWarehouse.ID
                };
                _dbContext.FeedWarehouses.Add(item);
                _dbContext.SaveChanges();
                MessageBox.Show("OK");
            }
            catch(Exception ex)
            {
                MessageBox.Show("SOME ERROR! {0}", ex.Message);
            }
        }

        private void DeleteSelectedItem(object arg)
        {
            try
            {
                _dbContext.FeedWarehouses.Remove(SelectedFeedWarehouse);
                _dbContext.SaveChanges();               
                MessageBox.Show("OK");
            }
            catch (Exception err)
            {
                MessageBox.Show("SOME ERROR! {0}", err.Message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        } 
    }
}
