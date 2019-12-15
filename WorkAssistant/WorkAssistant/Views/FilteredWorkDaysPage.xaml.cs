using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Models;
using WorkAssistant.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilteredWorkDaysPage : ContentPage
    {
        FilteredWorkDaysViewModel viewModel;
        public FilteredWorkDaysPage(FilteredWorkDaysViewModel filteredWorkDaysViewModel)
        {
            InitializeComponent();

            BindingContext = viewModel = filteredWorkDaysViewModel;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //TODO: Create new page for showing stats. Passes the found WorkDays in this viewmodel into the StatsViewModel
        }
    }
}