using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Models;
using WorkAssistant.Services;
using WorkAssistant.Views;
using Xamarin.Forms;

namespace WorkAssistant.ViewModels
{
    public class RegisterWorkDayViewModel : BaseViewModel
    {
        public WorkDay WorkDay { get; set; }

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

        TimeSpan _startTime;
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged();
                }
            }
        }

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

        TimeSpan _endTime;
        public TimeSpan EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool School
        {
            get { return WorkDay.School; }
            set
            {
                if (WorkDay.School != value)
                {
                    WorkDay.School = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Sick
        {
            get { return WorkDay.Sick; }
            set
            {
                if (WorkDay.Sick != value)
                {
                    WorkDay.Sick = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool TimeOff
        {
            get { return WorkDay.TimeOff; }
            set
            {
                if (WorkDay.TimeOff != value)
                {
                    WorkDay.TimeOff = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool OnCall
        {
            get { return WorkDay.CalledIn; }
            set
            {
                if (WorkDay.CalledIn != value)
                {
                    WorkDay.CalledIn = value;
                    OnPropertyChanged();
                }
            }
        }

        DateTime _currentDate;
        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set
            {
                if (_currentDate != value)
                {
                    _currentDate = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        public Command CreateWorkDayCommand { get; set; }

        public AzureDataStore AzureDataStore;

        public RegisterWorkDayViewModel()
        {
            Title = "New WorkDay";
            WorkDay = new WorkDay();
            _currentDate = new DateTime();
            _currentDate = DateTime.Now;
            _startDate = _currentDate;
            _endDate = _currentDate;
            AzureDataStore = new AzureDataStore();
            CreateWorkDayCommand = new Command(async () => await ExecuteCreateWorkDayCommand());

            MessagingCenter.Subscribe<RegisterWorkDayPage>(this, "StartTimeNowButtonClicked", (sender) =>
            {
                StartTime = DateTime.Now.TimeOfDay;
            });

            MessagingCenter.Subscribe<RegisterWorkDayPage>(this, "EndTimeNowButtonClicked", (sender) =>
            {
                EndTime = DateTime.Now.TimeOfDay;
            });
        }

        async Task ExecuteCreateWorkDayCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                WorkDay.StartTime = _startDate.Date.Add(_startTime);
                WorkDay.EndTime = _endDate.Date.Add(_endTime);
                var registerWorkDaySuccess = await AzureDataStore.CreateWorkDayAsync(WorkDay);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
