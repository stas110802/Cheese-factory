using Cheese_factory.Core;
using Cheese_factory.Core.Command;
using Cheese_factory.Core.Interface;
using Cheese_factory.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cheese_factory.MVVM.ViewModel
{
    public sealed class MilkCollectionControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<MilkCollection> _milkCollections;
        private ObservableCollection<WorkingCouple> _workingCouples;

        private MilkCollection _selectedMilkCollection;
        private WorkingCouple _selectedWorkingCouple;

        private DateTime _collectionDate;
        private int _count;

        public MilkCollectionControlVM()
        {
            _dbContext = new MyDBContext();

            _milkCollections = new ObservableCollection<MilkCollection>();
            _workingCouples = new ObservableCollection<WorkingCouple>();

            _selectedMilkCollection = new MilkCollection();
            _selectedWorkingCouple = new WorkingCouple();

            DBContextCommands.AddItemsIntoCollection(_milkCollections, _dbContext.MilkCollections);
            DBContextCommands.AddItemsIntoCollection(_workingCouples, _dbContext.WorkingCouples);

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<MilkCollection> MilkCollections
        {
            get => _milkCollections;
            set => Set(ref _milkCollections, value, nameof(MilkCollections));
        }

        public ObservableCollection<WorkingCouple> WorkingCouples
        {
            get => _workingCouples;
            set => Set(ref _workingCouples, value, nameof(WorkingCouples));
        }

        public MilkCollection SelectedMilkCollection
        {
            get => _selectedMilkCollection;
            set => Set(ref _selectedMilkCollection, value, nameof(SelectedMilkCollection));
        }

        public WorkingCouple SelectedWorkingCouple
        {
            get => _selectedWorkingCouple;
            set => Set(ref _selectedWorkingCouple, value, nameof(SelectedWorkingCouple));
        }

        public DateTime CollectionDate
        {
            get => _collectionDate;
            set => Set(ref _collectionDate, value, nameof(CollectionDate));
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

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        void IInitializeCommands.AddItem(object args)
        {
            var item = new MilkCollection()
            {
                WorkingCoupleFK = _selectedWorkingCouple.ID,
                CollectionDate = _collectionDate,
                Count = _count
            };
            DBContextCommands.AddItem(_dbContext, _dbContext.MilkCollections, item);
        }

        void IInitializeCommands.ChangeExistingItem(object args)
        {
            try
            {
                var id = SelectedMilkCollection.ID;
                var oldItem = _dbContext.MilkCollections.Find(id);

                var newItem = new MilkCollection()
                {
                    ID = id,
                    WorkingCoupleFK = SelectedWorkingCouple.ID,
                    Count = _count,
                    CollectionDate = _collectionDate
                };

                DBContextCommands.ChangeExistingItem(_dbContext, oldItem, newItem);
                MessageBox.Show("OK");
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
                _count = SelectedMilkCollection.Count;
                _collectionDate = SelectedMilkCollection.CollectionDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error! {ex.Message}");
            }
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.MilkCollections, SelectedMilkCollection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }
        }

        void IInitializeCommands.UpdateItems(object args)
        {
            _milkCollections?.Clear();
            _workingCouples?.Clear();

            DBContextCommands.UpdateItems(_milkCollections, _dbContext.MilkCollections);
            DBContextCommands.UpdateItems(_workingCouples, _dbContext.WorkingCouples);
        }
    }
}
