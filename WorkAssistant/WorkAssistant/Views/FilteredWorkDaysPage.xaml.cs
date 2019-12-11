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
    }
}