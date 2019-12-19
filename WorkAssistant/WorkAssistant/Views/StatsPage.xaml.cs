using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        StatsViewModel viewModel;
        public StatsPage(StatsViewModel statsViewModel)
        {
            InitializeComponent();

            BindingContext = viewModel = statsViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.GetWorkedHours = CalculateHours();
        }

        public string CalculateHours()
        {
            var totaltimeWorked = new TimeSpan();

            foreach (var workday in viewModel.WorkDays)
            {
                totaltimeWorked += workday.EndTime - workday.StartTime;
            }

            return string.Format("{0}:{1}", totaltimeWorked.TotalHours.ToString("N0"), totaltimeWorked.Minutes);
        }
    }
}