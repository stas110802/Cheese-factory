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
    public sealed class FeedingReportVM : ObservableObject, IDbBaseCommand, IDisposable
    {
        private MyDBContext _dbContext;

        private ObservableCollection<FeedingReport> _feedingReports;
        private ObservableCollection<Feed> _feeds;

        private FeedingReport _selectedFeedingReport;
        private Feed _selectedFeed;

        private int _countFeed;
        private DateTime _feedingDate;

        public FeedingReportVM()
        {
            _dbContext = new MyDBContext();

            _feedingReports = new ObservableCollection<FeedingReport>();
            _feeds = new ObservableCollection<Feed>();
            _selectedFeedingReport = new FeedingReport();
            _selectedFeed = new Feed();

            DBContextCommands.AddItemsIntoCollection(_feedingReports, _dbContext.FeedingReports);
            DBContextCommands.AddItemsIntoCollection(_feeds, _dbContext.Feeds);

            ((IDbBaseCommand)this).InitCommands();
        }

        public ObservableCollection<FeedingReport> FeedingReports
        {
            get => _feedingReports;
            set => Set(ref _feedingReports, value, nameof(FeedingReports));
        }

        public ObservableCollection<Feed> Feeds
        {
            get => _feeds;
            set => Set(ref _feeds, value, nameof(Feeds));
        }

        public FeedingReport SelectedFeedingReport
        {
            get => _selectedFeedingReport;
            set => Set(ref _selectedFeedingReport, value, nameof(SelectedFeedingReport));
        }

        public Feed SelectedFeed
        {
            get => _selectedFeed;
            set => Set(ref _selectedFeed, value, nameof(SelectedFeed));
        }

        public int CountFeed
        {
            get => _countFeed;
            set => Set(ref _countFeed, value, nameof(CountFeed));
        }

        public DateTime FeedingDate
        {
            get => _feedingDate;
            set => Set(ref _feedingDate, value, nameof(FeedingDate));
        }

        public BaseCommand DeleteItemCommand { get; set; }
        public BaseCommand UpdateItemsCommand { get; set; }
        public BaseCommand AddItemCommand { get; set; }
        public BaseCommand ChangeItemCommand { get; set; }
        public BaseCommand TableClickCommand { get; set; }
        
        void IInitializeCommands.AddItem(object args)
        {
            var item = new FeedingReport()
            {
                ID = SelectedFeedingReport.ID,
                FeedFK = SelectedFeed.ID,
                CountFeed = CountFeed,
                FeedingDate = FeedingDate
            };
            DBContextCommands.AddItem(_dbContext, _dbContext.FeedingReports, item);
        }

        void IInitializeCommands.DeleteSelectedItem(object args)
        {
            try
            {
                DBContextCommands.DeleteItem(_dbContext, _dbContext.FeedingReports, SelectedFeedingReport);
                MessageBox.Show("OK");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"ERROR {exception.Message}");
            }
        }

        void IInitializeCommands.UpdateItems(object args)
        {
            try
            {
                _feedingReports?.Clear();
                _feeds?.Clear();

                DBContextCommands.UpdateItems(_feedingReports, _dbContext.FeedingReports);
                DBContextCommands.UpdateItems(_feeds, _dbContext.Feeds);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error! {exception.Message}");
            }
        }

        void IInitializeCommands.ChangeExistingItem(object args)
        {
            try
            {
                var id = SelectedFeedingReport.ID;
                var oldItem = _dbContext.FeedingReports.Find(id);

                var newItem = new FeedingReport()
                {
                    ID = id,
                    FeedFK = SelectedFeed.ID,
                    FeedingDate = FeedingDate,
                    CountFeed = CountFeed
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
                FeedingDate = SelectedFeedingReport.FeedingDate;
                CountFeed = SelectedFeedingReport.CountFeed;
                SelectedFeed = SelectedFeedingReport.Feed;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error! {exception.Message}");
            }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
