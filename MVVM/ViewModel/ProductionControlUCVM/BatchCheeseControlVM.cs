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
    public sealed class BatchCheeseControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<BatchCheese> _batchCheeses;
        private ObservableCollection<Batch> _batches;
        private ObservableCollection<Cheese> _cheeses;

        private BatchCheese _selectedBatchCheese;
        private Batch _selectedBatch;
        private Cheese _selectedCheese;

        private int _count;

        public BatchCheeseControlVM()
        {
            _dbContext = new MyDBContext();

            _batchCheeses = new ObservableCollection<BatchCheese>();
            _cheeses = new ObservableCollection<Cheese>();
            _batches = new ObservableCollection<Batch>();

            _selectedBatch = new Batch();
            _selectedBatchCheese = new BatchCheese();
            _selectedCheese = new Cheese();

            DBContextCommands.UpdateItems(_batchCheeses, _dbContext.BatchCheeses);
            DBContextCommands.UpdateItems(_cheeses, _dbContext.Cheeses);
            DBContextCommands.UpdateItems(_batches, _dbContext.Batches);

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<BatchCheese> BatchCheeses
        {
            get => _batchCheeses;
            set => Set(ref _batchCheeses, value, nameof(BatchCheeses));
        }

        public ObservableCollection<Batch> Batches
        {
            get => _batches;
            set => Set(ref _batches, value, nameof(Batches));
        }

        public ObservableCollection<Cheese> Cheeses
        {
            get => _cheeses;
            set => Set(ref _cheeses, value, nameof(Cheeses));
        }

        public BatchCheese SelectedBatchCheese
        {
            get => _selectedBatchCheese;
            set => Set(ref _selectedBatchCheese, value, nameof(SelectedBatchCheese));
        }

        public Batch SelectedBatch
        {
            get => _selectedBatch;
            set => Set(ref _selectedBatch, value, nameof(SelectedBatch));
        }

        public Cheese SelectedCheese
        {
            get => _selectedCheese;
            set => Set(ref _selectedCheese, value, nameof(SelectedCheese));
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
        public BaseCommand TableClickCommand { get; set; }

        void IInitializeCommands.AddItem(object args)
        {
            try
            {
                var item = new BatchCheese()
                {
                    Count = Count,
                    BatchFK = SelectedBatch.ID,
                    CheeseFK = SelectedCheese.ID
                };
                DBContextCommands.AddItem(_dbContext, _dbContext.BatchCheeses, item);
            }
            catch (Exception ex) { }
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.BatchCheeses, _selectedBatchCheese);
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
                _batches?.Clear();
                _batchCheeses?.Clear();
                _cheeses?.Clear();

                DBContextCommands.UpdateItems(_batches, _dbContext.Batches);
                DBContextCommands.UpdateItems(_batchCheeses, _dbContext.BatchCheeses);
                DBContextCommands.UpdateItems(_cheeses, _dbContext.Cheeses);
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
                var id = SelectedBatchCheese.ID;
                var oldItem = _dbContext.BatchCheeses.Find(id);

                var newItem = new BatchCheese()
                {
                    ID = id,
                    Count = Count,
                    BatchFK = SelectedBatch.ID,
                    CheeseFK = SelectedCheese.ID
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
                Count = SelectedBatchCheese.Count;
                SelectedCheese = SelectedBatchCheese.Cheese;
                SelectedBatch = SelectedBatchCheese.Batch;
            }
            catch (Exception) { }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
