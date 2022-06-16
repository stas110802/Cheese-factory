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
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Cow> _cows;

        private MilkCollection _selectedMilkCollection;
        private Employee _selectedEmployee;
        private Cow _selectedCow;

        private DateTime _collectionDate;
        private int _count;

        public MilkCollectionControlVM()
        {
            _dbContext = new MyDBContext();

            _milkCollections = new ObservableCollection<MilkCollection>();
            _employees = new ObservableCollection<Employee>();
            _cows = new ObservableCollection<Cow>();

            _selectedMilkCollection = new MilkCollection();
            _selectedEmployee = new Employee();
            _selectedCow = new Cow();

            DBContextCommands.UpdateItems(_milkCollections, _dbContext.MilkCollections);
            DBContextCommands.UpdateItems(_employees, _dbContext.Employees);
            DBContextCommands.UpdateItems(_cows, _dbContext.Cows);

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<MilkCollection> MilkCollections
        {
            get => _milkCollections;
            set => Set(ref _milkCollections, value, nameof(MilkCollections));
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => Set(ref _employees, value, nameof(Employees));
        }

        public ObservableCollection<Cow> Cows
        {
            get => _cows;
            set => Set(ref _cows, value, nameof(Cows));
        }


        public MilkCollection SelectedMilkCollection
        {
            get => _selectedMilkCollection;
            set => Set(ref _selectedMilkCollection, value, nameof(SelectedMilkCollection));
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value, nameof(SelectedEmployee));
        }

        public Cow SelectedCow
        {
            get => _selectedCow;
            set => Set(ref _selectedCow, value, nameof(SelectedCow));
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
                EmployeeFK = SelectedEmployee.ID,
                CowFK = SelectedCow.ID,
                CollectionDate = _collectionDate,
                Count = _count
            };
            DBContextCommands.AddItem(_dbContext, _dbContext.MilkCollections, item);
        }

        void IInitializeCommands.ChangeExistingItem(object args)
        {
            try
            {
                var id = _selectedMilkCollection.ID;
                var oldItem = _dbContext.MilkCollections.Find(id);

                var newItem = new MilkCollection()
                {
                    ID = id,
                    EmployeeFK = SelectedEmployee.ID,
                    CowFK = SelectedCow.ID,
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
                SelectedCow = SelectedMilkCollection.Cow;
                SelectedEmployee = SelectedMilkCollection.Employee;
                Count = _selectedMilkCollection.Count;
                CollectionDate = _selectedMilkCollection.CollectionDate;
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
                DBContextCommands.DeleteItem(_dbContext, _dbContext.MilkCollections, _selectedMilkCollection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }
        }

        void IInitializeCommands.UpdateItems(object args)
        {
            _milkCollections?.Clear();
            _employees?.Clear();
            _cows?.Clear();

            DBContextCommands.UpdateItems(_milkCollections, _dbContext.MilkCollections);
            DBContextCommands.UpdateItems(_employees, _dbContext.Employees);
            DBContextCommands.UpdateItems(_cows, _dbContext.Cows);
        }
    }
}
