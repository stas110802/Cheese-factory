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
    public sealed class CheeseControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<Cheese> _cheeses;
        private Cheese _selectedCheese;

        private string _name;
        private string _type;
        private string _percentage;
        private string _typePasteurization;

        public CheeseControlVM()
        {
            _dbContext = new MyDBContext();
            _cheeses = new ObservableCollection<Cheese>();
            _selectedCheese = new Cheese();

            DBContextCommands.UpdateItems(_cheeses, _dbContext.Cheeses);
            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<Cheese> Cheeses
        {
            get => _cheeses;
            set => Set(ref _cheeses, value, nameof(Cheeses));
        }

        public Cheese SelectedCheese
        {
            get => _selectedCheese;
            set => Set(ref _selectedCheese, value, nameof(SelectedCheese));
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value, nameof(Name));
        }

        public string Type
        {
            get => _type;
            set => Set(ref _type, value, nameof(Type));
        }

        public string Percentage
        {
            get => _percentage;
            set => Set(ref _percentage, value, nameof(Percentage));
        }

        public string TypePasteurization
        {
            get => _typePasteurization;
            set => Set(ref _typePasteurization, value, nameof(TypePasteurization));
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
                var item = new Cheese()
                {
                    Name = Name,
                    Type = Type,
                    Percentage = Percentage,
                    TypePasteurization = TypePasteurization
                };
                DBContextCommands.AddItem(_dbContext, _dbContext.Cheeses, item);
            }
            catch (Exception ex) { }
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.Cheeses, _selectedCheese);
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
                _cheeses?.Clear();
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
                var id = SelectedCheese.ID;
                var oldItem = _dbContext.Cheeses.Find(id);

                var newItem = new Cheese()
                {
                    ID = id,
                    Name = Name,
                    Type = Type,
                    Percentage = Percentage,
                    TypePasteurization = TypePasteurization
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
                Name = SelectedCheese.Name;
                Type = SelectedCheese.Type;
                Percentage = SelectedCheese.Percentage;
                TypePasteurization = SelectedCheese.TypePasteurization;
            }
            catch (Exception) { }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
