using System;
using System.Collections.Generic;
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
        public SearchWorkDaysPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SearchWorkDaysViewModel();
        }

        async void SearchButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
                new NavigationPage(new FilteredWorkDaysPage(viewModel.WorkDays)));
        }
    }
}