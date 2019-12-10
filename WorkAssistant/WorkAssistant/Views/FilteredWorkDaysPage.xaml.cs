using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilteredWorkDaysPage : ContentPage
    {
        public FilteredWorkDaysPage(IEnumerable<WorkDay> workDays)
        {
            InitializeComponent();
        }
    }
}