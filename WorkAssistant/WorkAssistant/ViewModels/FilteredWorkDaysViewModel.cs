using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkAssistant.Models;
using WorkAssistant.Services;
using WorkAssistant.Helpers;

namespace WorkAssistant.ViewModels
{
    public class FilteredWorkDaysViewModel : BaseViewModel
    {
        public ObservableCollection<WorkDay> WorkDays { get; set; }

        public FilteredWorkDaysViewModel(List<WorkDay> workDaysList)
        {
            Title = "Filtered result";
            WorkDays = new ObservableCollection<WorkDay>();
            WorkDays.InsertRange(workDaysList);
        }
    }
}
