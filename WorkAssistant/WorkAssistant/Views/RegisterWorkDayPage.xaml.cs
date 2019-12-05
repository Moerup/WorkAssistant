using MongoDB.Bson;
using System;
using System.Collections.Generic;
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

        public bool SuccesfullCreated { get; set; }
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

        async void RegisterTime_Clicked(object sender, EventArgs e)
        {
            try
            {
                var newWorkDay = new WorkDay
                {
                    StartTime = DateTime.Now,
                    EndTime = new DateTime(),
                    Sick = false,
                    School = false,
                    TimeOff = false
                };

                SuccesfullCreated = await AzureDataStore.AddWorkDayAsync(newWorkDay);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}