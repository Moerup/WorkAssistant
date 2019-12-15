using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Services;
using WorkAssistant.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchWorkDaysPage : ContentPage
    {
        SearchWorkDaysViewModel viewModel;
        AzureDataStore AzureDataStore;
        public SearchWorkDaysPage()
        {
            InitializeComponent();

            AzureDataStore = new AzureDataStore();
            BindingContext = viewModel = new SearchWorkDaysViewModel();
        }

        async void SearchButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                //TODO When searching for workdays, if the search enddate has a workday over midnight it doesn't get included. Fix
                var workDays = await AzureDataStore.FilterWorkDays(viewModel.StartDate.Date.ToString("yyyy-MM-dd"), viewModel.EndDate.Date.ToString("yyyy-MM-dd"));
                var workDaysList = workDays.ToList();
                var filteredWorkDaysViewModel = new FilteredWorkDaysViewModel(workDaysList);

                await Navigation.PushModalAsync(
                    new NavigationPage(new FilteredWorkDaysPage(filteredWorkDaysViewModel)));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $@"{ex.Message}", "OK");
                Debug.WriteLine(ex);
            }
        }
    }
}