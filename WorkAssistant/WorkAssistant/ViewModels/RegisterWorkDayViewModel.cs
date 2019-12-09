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

        public DateTime StartTime
        {
            get { return WorkDay.StartTime; }
            set
            {
                if (WorkDay.StartTime != value)
                {
                    WorkDay.StartTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime EndTime
        {
            get { return WorkDay.EndTime; }
            set
            {
                if (WorkDay.EndTime != value)
                {
                    WorkDay.EndTime = value;
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
            get { return WorkDay.OnCall; }
            set
            {
                if (WorkDay.OnCall != value)
                {
                    WorkDay.OnCall = value;
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

        public Command CheckIfStartedCommand { get; set; }
        public Command CreateWorkDayCommand { get; set; }
        public Command UpdateWorkDayCommand { get; set; }

        public AzureDataStore AzureDataStore;

        public RegisterWorkDayViewModel()
        {
            Title = "New WorkDay";
            WorkDay = new WorkDay();
            _currentDate = new DateTime();
            _currentDate = DateTime.Now;
            AzureDataStore = new AzureDataStore();
            //CheckIfStartedCommand = new Command(async () => await ExecuteCheckIfStartedCommand());
            //CreateWorkDayCommand = new Command(async () => await ExecuteCreateWorkDayCommand());
            //UpdateWorkDayCommand = new Command(async () => await ExecuteUpdateWorkDayCommand());

            MessagingCenter.Subscribe<RegisterWorkDayPage>(this, "StartTimeNowButtonClicked", (sender) =>
            {
                StartTime = DateTime.Now;
            });

            MessagingCenter.Subscribe<RegisterWorkDayPage>(this, "EndTimeNowButtonClicked", (sender) =>
            {
                EndTime = DateTime.Now;
            });
        }
    }
}
