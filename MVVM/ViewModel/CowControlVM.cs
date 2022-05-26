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

namespace Cheese_factory.MVVM.ViewModel
{
    public sealed class CowControlVM :ObservableObject
    {
        private ObservableCollection<Cow> _cows;
        private Cow _selectedCow;

        private readonly MyDBContext _dbContext;

        private DateTime _dateBirth;
        private int _weight;
        private int _uid;

        public CowControlVM()
        {
            _cows = new ObservableCollection<Cow>();
            _selectedCow = new Cow();
            _dbContext = new MyDBContext();

            // init commands
            TableClickCommand = new BaseCommand(CowsTableDoubleClick);
            DeleteItemCommand = new BaseCommand(DeleteSelectedItem);
            AddItemCommand = new BaseCommand(AddSelectedItem);
            ChangeItemCommand = new BaseCommand(ChangeExistingItem);
            UpdateItemsCommand = new BaseCommand(UpdateItems);

            DBContextCommands.AddItemsIntoCollection(_cows, _dbContext.Cows);
        }

        public ObservableCollection<Cow> Cows
        {
            get => _cows;
            set => Set(ref _cows, value, nameof(Cows));
        }

        public Cow SelectedCow
        {
            get => _selectedCow;
            set => Set(ref _selectedCow, value, nameof(SelectedCow));
        }

        #region ScreenProp

        public DateTime DateBirth
        {
            get => _dateBirth;
            set => Set(ref _dateBirth, value, nameof(DateBirth));
        }

        public int Weight
        {
            get => _weight;
            set => Set(ref _weight, value, nameof(Weight));
        }
        public int UID
        {
            get => _uid;
            set => Set(ref _uid, value, nameof(UID));
        }

        #endregion
        
        #region Commands

        public BaseCommand DeleteItemCommand { get; set; }
        public BaseCommand UpdateItemsCommand { get; set; }
        public BaseCommand AddItemCommand { get; set; }
        public BaseCommand ChangeItemCommand { get; set; }
        public BaseCommand TableClickCommand { get; set; }

        #endregion

        // commands (by method) 
        private void CowsTableDoubleClick(object args = null)
        {
            try
            {
                Weight = SelectedCow.Weight;
                DateBirth = SelectedCow.DateBirth;
                UID = SelectedCow.UID;
            }
            catch (Exception) { }
        }

        
        private void DeleteSelectedItem(object args = null)
        {
            try
            {
                _dbContext.Cows.Remove(SelectedCow);
                _dbContext.SaveChanges();
                MessageBox.Show("OK");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void UpdateItems(object args = null)
        {
            try
            {
                if (_cows != null)
                    _cows.Clear();

                foreach (var item in _dbContext.Cows)
                {
                    _cows.Add(item);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void AddSelectedItem(object args = null)
        {
            try
            {
                var item = new Cow()
                {
                    Weight = Weight,
                    DateBirth = DateBirth,
                    UID = UID,
                };
                _dbContext.Cows.Add(item);
                _dbContext.SaveChanges();
                MessageBox.Show("OK");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void ChangeExistingItem(object args = null)
        {
            try
            {
                var oldItem = _dbContext.Cows.Find(SelectedCow.ID);
                if (oldItem == null) return;

                var newItem = new Cow()
                {
                    ID = oldItem.ID,
                    Weight = Weight,
                    DateBirth = DateBirth,
                    UID = UID
                };

                _dbContext
                    .Entry(oldItem)
                    .CurrentValues
                    .SetValues(newItem);
                _dbContext.SaveChanges();
                MessageBox.Show("OK");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
