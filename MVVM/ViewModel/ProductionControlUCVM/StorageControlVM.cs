using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cheese_factory.Core;
using Cheese_factory.Core.Command;
using Cheese_factory.Core.Interface;
using Cheese_factory.MVVM.Model;

namespace Cheese_factory.MVVM.ViewModel.ProductionControlUCVM
{
    public sealed class StorageControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<Storage> _storages;
        private Storage _selectedStorage;

        private int _floorArea;

        public StorageControlVM()
        {
            _dbContext = new MyDBContext();
            _storages = new ObservableCollection<Storage>();
            _selectedStorage = new Storage();

            DBContextCommands.UpdateItems(_storages, _dbContext.Storages);

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<Storage> Storages
        {
            get => _storages;
            set => Set(ref _storages, value, nameof(Storages));
        }

        public Storage SelectedStorage
        {
            get => _selectedStorage;
            set => Set(ref _selectedStorage, value, nameof(SelectedStorage));
        }

        public int FloorArea
        {
            get => _floorArea;
            set => Set(ref _floorArea, value, nameof(FloorArea));
        }

        public BaseCommand DeleteItemCommand { get; set; }
        public BaseCommand UpdateItemsCommand { get; set; }
        public BaseCommand AddItemCommand { get; set; }
        public BaseCommand ChangeItemCommand { get; set; }
        public BaseCommand TableClickCommand { get; set; }

        void IInitializeCommands.AddItem(object args)
        {
            try
            {
                var item = new Storage()
                {
                    FloorArea = FloorArea
                };
                DBContextCommands.AddItem(_dbContext, _dbContext.Storages, item);
            }
            catch(Exception ex) { }
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.Storages, _selectedStorage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR! {ex.Message}");
            }
        }

        void IInitializeCommands.UpdateItems(object args)
        {
            try
            {
                _storages?.Clear();
                DBContextCommands.UpdateItems(_storages, _dbContext.Storages);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR! {ex.Message}");
            }
        }

        void IInitializeCommands.ChangeExistingItem(object args)
        {
            try
            {
                var id = SelectedStorage.ID;
                var oldItem = _dbContext.Storages.Find(id);

                var newItem = new Storage()
                {
                    ID = id,
                    FloorArea = FloorArea
                };

                DBContextCommands.ChangeExistingItem(_dbContext, oldItem, newItem);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error! {exception.Message}");
            }
        }

        void IInitializeCommands.ClickOnTable(object args)
        {
            try
            {
                FloorArea = SelectedStorage.FloorArea;
            }
            catch (Exception) { }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
