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
    public sealed class EquipmentControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private readonly MyDBContext _dbContext;

        private ObservableCollection<Equipment> _equipments;
        private Equipment _selectedEquipment;

        private string _name;
        private string _model;
        private string _manufacturer;

        public EquipmentControlVM()
        {
            _dbContext = new MyDBContext();

            _equipments = new ObservableCollection<Equipment>();
            _selectedEquipment = new Equipment();

            DBContextCommands.UpdateItems(_equipments, _dbContext.Equipments);
            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<Equipment> Equipments
        {
            get => _equipments;
            set => Set(ref _equipments, value, nameof(Equipments));
        }

        public Equipment SelectedEquipment
        {
            get => _selectedEquipment;
            set => Set(ref _selectedEquipment, value, nameof(SelectedEquipment));
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value, nameof(Name));
        }

        public string Model
        {
            get => _model;
            set => Set(ref _model, value, nameof(Model));
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set => Set(ref _manufacturer, value, nameof(Manufacturer));
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
            var item = new Equipment()
            {
                Name = _name,
                Model = _model,
                Manufacturer = _manufacturer
            };
            DBContextCommands.AddItem(_dbContext, _dbContext.Equipments, item);
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.Equipments, _selectedEquipment);
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
                var id = SelectedEquipment.ID;
                var oldItem = _dbContext.Equipments.Find(id);

                var newItem = new Equipment()
                {
                    ID = id,
                    Name = _name,
                    Model = _model,
                    Manufacturer = _manufacturer
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
                Name = SelectedEquipment.Name;
                Model = SelectedEquipment.Model;
                Manufacturer = SelectedEquipment.Manufacturer;
            }
            catch (Exception) { }
        }
                
        void IInitializeCommands.UpdateItems(object args)
        {
            try
            {
                _equipments?.Clear();
                DBContextCommands.UpdateItems(_equipments, _dbContext.Equipments);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR! {ex.Message}");
            }
        }
    }
}
