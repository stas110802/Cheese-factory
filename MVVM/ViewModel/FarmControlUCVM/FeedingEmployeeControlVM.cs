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

namespace Cheese_factory.MVVM.ViewModel.FarmControlUCVM
{
    public sealed class FeedingEmployeeControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private readonly MyDBContext _dbContext;

        private ObservableCollection<FeedingEmployee> _feedingEmployees;
        private ObservableCollection<Feeding> _feeding;
        private ObservableCollection<Employee> _employees;

        private FeedingEmployee _selectedFeedingEmployee;
        private Feeding _selectedFeeding;
        private Employee _selectedEmployee;

        public FeedingEmployeeControlVM()
        {
            _dbContext = new MyDBContext();

            _feedingEmployees = new ObservableCollection<FeedingEmployee>();
            _feeding = new ObservableCollection<Feeding>();
            _employees = new ObservableCollection<Employee>();

            _selectedFeedingEmployee = new FeedingEmployee();
            _selectedFeeding = new Feeding();
            _selectedEmployee = new Employee();

            DBContextCommands.UpdateItems(_feedingEmployees, _dbContext.FeedingEmployees);
            DBContextCommands.UpdateItems(_feeding, _dbContext.Feeding);
            DBContextCommands.UpdateItems(_employees, _dbContext.Employees);

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<FeedingEmployee> FeedingEmployees
        {
            get => _feedingEmployees;
            set => Set(ref _feedingEmployees, value, nameof(FeedingEmployees));
        }

        public ObservableCollection<Feeding> Feeding
        {
            get => _feeding;
            set => Set(ref _feeding, value, nameof(Feeding));
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => Set(ref _employees, value, nameof(Employees));
        }

        public FeedingEmployee SelectedFeedingEmployee
        {
            get => _selectedFeedingEmployee;
            set => Set(ref _selectedFeedingEmployee, value, nameof(SelectedFeedingEmployee));
        }

        public Feeding SelectedFeeding
        {
            get => _selectedFeeding;
            set => Set(ref _selectedFeeding, value, nameof(SelectedFeeding));
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value, nameof(SelectedEmployee));
        }

        public BaseCommand DeleteItemCommand { get; set; }
        public BaseCommand UpdateItemsCommand { get; set; }
        public BaseCommand AddItemCommand { get; set; }
        public BaseCommand ChangeItemCommand { get; set; }
        public BaseCommand TableClickCommand { get; set; }

        void IInitializeCommands.AddItem(object args)
        {
            var item = new FeedingEmployee()
            {
                FeedingFK = SelectedFeeding.ID,
                EmployeeFK = SelectedEmployee.ID
            };
            DBContextCommands.AddItem(_dbContext, _dbContext.FeedingEmployees, item);
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.FeedingEmployees, _selectedFeedingEmployee);
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
                _feedingEmployees?.Clear();
                _employees?.Clear();
                _feeding?.Clear();

                DBContextCommands.UpdateItems(_feedingEmployees, _dbContext.FeedingEmployees);
                DBContextCommands.UpdateItems(_employees, _dbContext.Employees);
                DBContextCommands.UpdateItems(_feeding, _dbContext.Feeding);
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
                var id = SelectedFeedingEmployee.ID;
                var oldItem = _dbContext.FeedingEmployees.Find(id);

                var newItem = new FeedingEmployee()
                {
                    ID = id,
                    FeedingFK = SelectedFeeding.ID,
                    EmployeeFK = SelectedEmployee.ID
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
                SelectedFeeding = SelectedFeedingEmployee.Feeding;
                SelectedEmployee = SelectedFeedingEmployee.Employee;
            }
            catch (Exception) { }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
