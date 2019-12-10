using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Models;
using WorkAssistant.Services;
using Xamarin.Forms;

namespace WorkAssistant.ViewModels
{
    public class SearchWorkDaysViewModel : BaseViewModel
    { 
        public IEnumerable<WorkDay> WorkDays { get; set; }
        public Command FilterWorkDaysCommand { get; set; }
        public AzureDataStore AzureDataStore;

        #region Properties Get/Setters

        DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged();
                }
            }
        }

        //TimeSpan _startTime;
        //public TimeSpan StartTime
        //{
        //    get { return _startTime; }
        //    set
        //    {
        //        if (_startTime != value)
        //        {
        //            _startTime = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged();
                }
            }
        }

        //TimeSpan _endTime;
        //public TimeSpan EndTime
        //{
        //    get { return _endTime; }
        //    set
        //    {
        //        if (_endTime != value)
        //        {
        //            _endTime = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        #endregion

        public SearchWorkDaysViewModel()
        {
            _startDate = new DateTime();
            _startDate = DateTime.Now;
            AzureDataStore = new AzureDataStore();

            FilterWorkDaysCommand = new Command(async () => await ExecuteFilterWorkDaysCommand());
        }

        async Task ExecuteFilterWorkDaysCommand()
        {
            try
            {
                WorkDays = await AzureDataStore.FilterWorkDays(_startDate, _endDate);
                var listWorkDays = WorkDays.ToList();


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
