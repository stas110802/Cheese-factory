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

namespace Cheese_factory.MVVM.ViewModel.ProductionControlUCVM
{
    public sealed class EmployeeEquipmentControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<EmployeeEquipment> _employeeEquipments;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Equipment> _equipments;

        private EmployeeEquipment _selectedEmployeeEquipment;
        private Employee _selectedEmployee;
        private Equipment _selectedEquipment;

        public EmployeeEquipmentControlVM()
        {
            _dbContext = new MyDBContext();

            _employeeEquipments = new ObservableCollection<EmployeeEquipment>();
            _employees = new ObservableCollection<Employee>();
            _equipments = new ObservableCollection<Equipment>();

            _selectedEmployeeEquipment = new EmployeeEquipment();
            _selectedEmployee = new Employee();
            _selectedEquipment = new Equipment();

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<EmployeeEquipment> EmployeeEquipments
        {
            get => _employeeEquipments;
            set => Set(ref _employeeEquipments, value, nameof(EmployeeEquipments));
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => Set(ref _employees, value, nameof(Employees));
        }
               
        public ObservableCollection<Equipment> Equipments
        {
            get => _equipments;
            set => Set(ref _equipments, value, nameof(Equipments));
        }

        public EmployeeEquipment SelectedEmployeeEquipment
        {
            get => _selectedEmployeeEquipment;
            set => Set(ref _selectedEmployeeEquipment, value, nameof(SelectedEmployeeEquipment));
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value, nameof(SelectedEmployee));
        }

        public Equipment SelectedEquipment
        {
            get => _selectedEquipment;
            set => Set(ref _selectedEquipment, value, nameof(SelectedEquipment));
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
            var item = new EmployeeEquipment()
            {
                EmployeeFK = _selectedEmployee.ID,
                EquipmentFK = SelectedEquipment.ID
            };
            DBContextCommands.AddItem(_dbContext, _dbContext.EmployeeEquipments, item);
        }

        void IInitializeCommands.ChangeExistingItem(object args)
        {
            try
            {
                var id = SelectedEmployeeEquipment.ID;
                var oldItem = _dbContext.EmployeeEquipments.Find(id);

                var newItem = new EmployeeEquipment()
                {
                    ID = id,
                    // changes 
                    EmployeeFK = _selectedEmployee.ID,
                    EquipmentFK = _selectedEquipment.ID
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
                SelectedEmployee = SelectedEmployeeEquipment.Employee;
                SelectedEquipment = SelectedEmployeeEquipment.Equipment;
            }
            catch (Exception) { }
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext,
                    _dbContext.EmployeeEquipments, _selectedEmployeeEquipment);
                MessageBox.Show("OK");
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
                _employeeEquipments?.Clear();
                _employees?.Clear();
                _equipments?.Clear();

                DBContextCommands.UpdateItems(_employeeEquipments, _dbContext.EmployeeEquipments);
                DBContextCommands.UpdateItems(_employees, _dbContext.Employees);
                DBContextCommands.UpdateItems(_equipments, _dbContext.Equipments);
            }
            catch (Exception) { }      
        }

    }
}
