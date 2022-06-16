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
    public sealed class BatchControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<Batch> _batches;
        private Batch _selectedBatch;

        private string _uid;

        public BatchControlVM()
        {
            _dbContext = new MyDBContext();
            _batches = new ObservableCollection<Batch>();
            _selectedBatch = new Batch();

            DBContextCommands.UpdateItems(_batches, _dbContext.Batches);
            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<Batch> Batches
        {
            get => _batches;
            set => Set(ref _batches, value, nameof(Batches));
        }

        public Batch SelectedBatch
        {
            get => _selectedBatch;
            set => Set(ref _selectedBatch, value, nameof(SelectedBatch));
        }

        public string UID
        {
            get => _uid;
            set => Set(ref _uid, value, nameof(UID));
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
                var item = new Batch()
                {
                    UIDConsignment = UID
                };
                DBContextCommands.AddItem(_dbContext, _dbContext.Batches, item);
            }
            catch (Exception ex) { }
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.Batches, _selectedBatch);
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
                DBContextCommands.UpdateItems(_batches, _dbContext.Batches);
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
                var id = SelectedBatch.ID;
                var oldItem = _dbContext.Batches.Find(id);

                var newItem = new Batch()
                {
                    ID = id,
                    UIDConsignment = UID
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
                UID = SelectedBatch.UIDConsignment;
            }
            catch (Exception) { }
        }

      
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
