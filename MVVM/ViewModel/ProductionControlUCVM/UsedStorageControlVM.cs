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
    public sealed class UsedStorageControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<UsedStorage> _usedStorages;
        private ObservableCollection<BatchCheese> _batchCheeses;
        private ObservableCollection<Storage> _storages;

        private UsedStorage _selectedUsedStorage;
        private BatchCheese _selectedBatchCheese;
        private Storage _selectedStorage;

        private DateTime _date;

        public UsedStorageControlVM()
        {
            _dbContext = new MyDBContext();

            _usedStorages = new ObservableCollection<UsedStorage>();
            _batchCheeses = new ObservableCollection<BatchCheese>();
            _storages = new ObservableCollection<Storage>();

            _selectedUsedStorage = new UsedStorage();
            _selectedBatchCheese = new BatchCheese();
            _selectedStorage = new Storage();

            DBContextCommands.UpdateItems(_batchCheeses, _dbContext.BatchCheeses);
            DBContextCommands.UpdateItems(_usedStorages, _dbContext.UsedStorages);
            DBContextCommands.UpdateItems(_storages, _dbContext.Storages);

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<UsedStorage> UsedStorages
        {
            get => _usedStorages;
            set => Set(ref _usedStorages, value, nameof(UsedStorages));
        }

        public ObservableCollection<BatchCheese> BatchCheeses
        {
            get => _batchCheeses;
            set => Set(ref _batchCheeses, value, nameof(BatchCheeses));
        }

        public ObservableCollection<Storage> Storages
        {
            get => _storages;
            set => Set(ref _storages, value, nameof(Storages));
        }

        public UsedStorage SelectedUsedStorage
        {
            get => _selectedUsedStorage;
            set => Set(ref _selectedUsedStorage, value, nameof(SelectedUsedStorage));
        }

        public BatchCheese SelectedBatchCheese
        {
            get => _selectedBatchCheese;
            set => Set(ref _selectedBatchCheese, value, nameof(SelectedBatchCheese));
        }

        public Storage SelectedStorage
        {
            get => _selectedStorage;
            set => Set(ref _selectedStorage, value, nameof(SelectedStorage));
        }

        public DateTime Date
        {
            get => _date;
            set => Set(ref _date, value, nameof(Date));
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
                var item = new UsedStorage()
                {
                    ReceiptDate = Date,
                    BatchCheeseFK = SelectedBatchCheese.ID,
                    StorageFK = SelectedStorage.ID
                };
                DBContextCommands.AddItem(_dbContext, _dbContext.UsedStorages, item);
            }
            catch (Exception ex) { }
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.UsedStorages, _selectedUsedStorage);
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
                _batchCheeses?.Clear();
                _usedStorages?.Clear();

                DBContextCommands.UpdateItems(_usedStorages, _dbContext.UsedStorages);
                DBContextCommands.UpdateItems(_batchCheeses, _dbContext.BatchCheeses);
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
                var id = SelectedUsedStorage.ID;
                var oldItem = _dbContext.UsedStorages.Find(id);

                var newItem = new UsedStorage()
                {
                    ID = id,
                    ReceiptDate = Date,
                    BatchCheeseFK = SelectedBatchCheese.ID,
                    StorageFK = SelectedStorage.ID
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
                Date = SelectedUsedStorage.ReceiptDate;
                SelectedStorage = SelectedUsedStorage.Storage;
                SelectedBatchCheese = SelectedUsedStorage.BatchCheese;
            }
            catch (Exception) { }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
