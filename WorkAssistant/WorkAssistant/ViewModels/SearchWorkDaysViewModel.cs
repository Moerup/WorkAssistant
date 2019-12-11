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
        #region Properties Get/Setters

        public List<WorkDay> WorkDays { get; set; }

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

        #endregion

        public SearchWorkDaysViewModel()
        {
            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
        }
    }
}
