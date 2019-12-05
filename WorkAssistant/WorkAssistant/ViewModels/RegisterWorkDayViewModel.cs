using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WorkAssistant.Models;
using WorkAssistant.Services;
using Xamarin.Forms;

namespace WorkAssistant.ViewModels
{
    public class RegisterWorkDayViewModel : BaseViewModel
    {
        public bool SuccesfullCreated { get; set; }
        public DateTime MyDate { get; set; }
        public Command RegisterTimeCommand { get; set; }

        public RegisterWorkDayViewModel()
        {
            Title = "New WorkDay";
            MyDate = new DateTime();
            MyDate = DateTime.Now;
        }
    }
}
