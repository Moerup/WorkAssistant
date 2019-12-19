using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkAssistant.Helpers;
using WorkAssistant.Models;

namespace WorkAssistant.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        public ObservableCollection<WorkDay> WorkDays { get; set; }

        public string GetNumberOfWorkDays
        {
            get
            {
                return WorkDays.Count().ToString();
            }
        }

        string _getWorkedHours;
        public string GetWorkedHours
        {
            get { return _getWorkedHours; }
            set
            {
                if (_getWorkedHours != value)
                {
                    _getWorkedHours = value;
                    OnPropertyChanged();
                }
            }
        }

        public StatsViewModel(List<WorkDay> workDaysList)
        {
            WorkDays = new ObservableCollection<WorkDay>();
            WorkDays.InsertRange(workDaysList);
        }
    }
}
