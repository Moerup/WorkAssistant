using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Models;
using WorkAssistant.Services;
using WorkAssistant.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterWorkDayPage : ContentPage
    {
        RegisterWorkDayViewModel viewModel;

        public bool SuccessfullyCreated { get; set; }
        public AzureDataStore AzureDataStore;

        public RegisterWorkDayPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RegisterWorkDayViewModel();
            AzureDataStore = new AzureDataStore();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected virtual void OnModelChanged()
        {

        }

        //async void RegisterTime_Clicked(object sender, EventArgs e)
        //{
        //    viewModel.CreateWorkDayCommand.Execute(null);
        //}

        //async void RegisterEndTime_Clicked(object sender, EventArgs e)
        //{
        //    viewModel.CreateWorkDayCommand.Execute(null);
        //}
        
        async void Refresh_Clicked(object sender, EventArgs e)
        {

        }

        async void EndTimeNowButton_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EndTimeNowButtonClicked");
        }

        async void StartTimeNowButton_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "StartTimeNowButtonClicked");
        }

        private void OnStartDateSelected_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void OnEndDateSelected_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void OnStartTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        private void OnEndTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}