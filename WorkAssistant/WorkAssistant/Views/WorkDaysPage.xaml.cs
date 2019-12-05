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
    public partial class WorkDaysPage : ContentPage
    {
        WorkDaysViewModel viewModel;
        public WorkDaysPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WorkDaysViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var workDay = args.SelectedItem as WorkDay;
            if (workDay == null)
                return;

            //await Navigation.PushModalAsync(
            //    new NavigationPage(new ItemDetailPage(new ItemDetailViewModel(workDay))));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.WorkDays.Count == 0)
                viewModel.LoadWorkDaysCommand.Execute(null);
        }
    }
}