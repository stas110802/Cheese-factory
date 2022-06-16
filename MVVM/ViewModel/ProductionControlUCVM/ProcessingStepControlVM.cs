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
    public sealed class ProcessingStepControlVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<ProcessingStep> _processingSteps;
        private ProcessingStep _selectedProcessingStep;

        private string _step;

        public ProcessingStepControlVM()
        {
            _dbContext = new MyDBContext();

            _processingSteps = new ObservableCollection<ProcessingStep>();
            _selectedProcessingStep = new ProcessingStep();

            DBContextCommands.UpdateItems(_processingSteps, _dbContext.ProcessingSteps);

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<ProcessingStep> ProcessingSteps
        {
            get => _processingSteps;
            set => Set(ref _processingSteps, value, nameof(ProcessingSteps));
        }

        public ProcessingStep SelectedProcessingStep
        {
            get => _selectedProcessingStep;
            set => Set(ref _selectedProcessingStep, value, nameof(SelectedProcessingStep));
        }

        public string Step
        {
            get => _step;
            set => Set(ref _step, value, nameof(Step));
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
                var item = new ProcessingStep()
                {
                    Step = Step
                };
                DBContextCommands.AddItem(_dbContext, _dbContext.ProcessingSteps, item);
            }
            catch (Exception ex) { }
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.ProcessingSteps, _selectedProcessingStep);
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
                _processingSteps?.Clear();
                DBContextCommands.UpdateItems(_processingSteps, _dbContext.ProcessingSteps);
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
                var id = SelectedProcessingStep.ID;
                var oldItem = _dbContext.ProcessingSteps.Find(id);

                var newItem = new ProcessingStep()
                {
                    ID = id,
                    Step = Step
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
                Step = SelectedProcessingStep.Step;
            }
            catch (Exception) { }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
