using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Models;
using WorkAssistant.Services;
using Xamarin.Forms;

namespace WorkAssistant.ViewModels
{
    public class RegisterWorkDayViewModel : BaseViewModel
    {
        bool alreadyStarted;
        public WorkDay CurrentWorkDay { get; set; }
        public bool SuccessfullyCreated { get; private set; }
        public bool AlreadyStarted
        {
            get { return alreadyStarted; }
            set
            {
                if (alreadyStarted != value)
                {
                    alreadyStarted = value;
                    OnPropertyChanged();
                } 
            }
        }
        public DateTime MyDate { get; set; }
        public Command CheckIfStartedCommand { get; set; }
        public Command CreateWorkDayCommand { get; set; }
        public Command UpdateWorkDayCommand { get; set; }
        

        public AzureDataStore AzureDataStore;

        public RegisterWorkDayViewModel()
        {
            Title = "New WorkDay";
            MyDate = new DateTime();
            MyDate = DateTime.Now;
            AzureDataStore = new AzureDataStore();
            CheckIfStartedCommand = new Command(async () => await ExecuteCheckIfStartedCommand());
            CreateWorkDayCommand = new Command(async () => await ExecuteCreateWorkDayCommand());
            UpdateWorkDayCommand = new Command(async () => await ExecuteUpdateWorkDayCommand());
        }

        async Task ExecuteCheckIfStartedCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                CurrentWorkDay = new WorkDay();
                CurrentWorkDay = await AzureDataStore.CheckIfWorkDayIsStarted();
                var emptyId = new ObjectId();
                if (CurrentWorkDay.Id != emptyId)
                {
                    AlreadyStarted = true;
                }
                else
                {
                    AlreadyStarted = false;
                }
                
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

        async Task ExecuteCreateWorkDayCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var newWorkDay = new WorkDay
                {
                    Id = ObjectId.GenerateNewId(),
                    StartTime = DateTime.Now,
                    EndTime = new DateTime(),
                    Sick = false,
                    School = false,
                    TimeOff = false
                };

                SuccessfullyCreated = await AzureDataStore.CreateWorkDayAsync(newWorkDay);
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

        async Task ExecuteUpdateWorkDayCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SuccessfullyCreated = await AzureDataStore.UpdateWorkDayAsync(CurrentWorkDay);
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
