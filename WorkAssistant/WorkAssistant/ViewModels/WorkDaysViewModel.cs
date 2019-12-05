using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Models;
using WorkAssistant.Services;
using Xamarin.Forms;

namespace WorkAssistant.ViewModels
{
    public class WorkDaysViewModel : BaseViewModel
    {
        public ObservableCollection<WorkDay> WorkDays { get; set; }
        public Command LoadWorkDaysCommand { get; set; }
        public AzureDataStore AzureDataStore;

        public WorkDaysViewModel()
        {
            Title = "WorkDays";
            WorkDays = new ObservableCollection<WorkDay>();
            AzureDataStore = new AzureDataStore();
            LoadWorkDaysCommand = new Command(async () => await ExecuteLoadWorkDaysCommand());
        }

        async Task ExecuteLoadWorkDaysCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                WorkDays.Clear();
                var workDays = await AzureDataStore.GetWorkDaysAsync();
                foreach (var workDay in workDays)
                {
                    WorkDays.Add(workDay);
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
    }
}
