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

        async void EndTimeNowButton_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EndTimeNowButtonClicked");
        }

        async void StartTimeNowButton_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "StartTimeNowButtonClicked");
        }

        async void RegisterWorkDayButton_Clicked(object sender, EventArgs e)
        {
            viewModel.CreateWorkDayCommand.Execute(null);
        }
    }
}