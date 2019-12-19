using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using WorkAssistant.Models;

namespace WorkAssistant.Services
{
    public class AzureDataStore
    {
        readonly HttpClient client;
        IEnumerable<WorkDay> items;

        public AzureDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"https://workassistantapi.azurewebsites.net/");

            items = new List<WorkDay>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<WorkDay>> GetWorkDaysAsync(bool forceRefresh = false)
        {
            if (IsConnected)
            {
                var json = await client.GetStringAsync($"api/workday");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<WorkDay>>(json));
            }

            return items;
        }

        public async Task<WorkDay> GetWorkDayAsync(WorkDay item)
        {
            var parsedId = item.Id.ToString();
            if (parsedId != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/workday/{parsedId}");
                return await Task.Run(() => JsonConvert.DeserializeObject<WorkDay>(json));
            }

            return null;
        }

        public async Task<bool> CreateWorkDayAsync(WorkDay item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/workday", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateWorkDayAsync(WorkDay item)
        {
            if (item == null || item.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var parsedId = item.Id.ToString();
            var response = await client.PutAsync(new Uri($"api/workday/{parsedId}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteWorkDayAsync(WorkDay item)
        {
            var parsedId = item.Id.ToString();
            if (string.IsNullOrEmpty(parsedId) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/workday/{parsedId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<WorkDay> CheckIfWorkDayIsStarted()
        {
            var response = await client.GetAsync($"api/workday/currentday");
            var responseConent = await response.Content.ReadAsStringAsync();
            var workDay = JsonConvert.DeserializeObject<WorkDay>(responseConent);

            if (response.IsSuccessStatusCode)
            {
                return workDay;
            }

            var emptyWorkDay = new WorkDay();
            return emptyWorkDay;
        }

        public async Task<IEnumerable<WorkDay>> FilterWorkDays(string startDate, string endDate)
        {
            if (IsConnected)
            {
                var response = await client.GetAsync($@"api/workday/{startDate}/{endDate}");
                var responseConent = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<IEnumerable<WorkDay>>(responseConent);
            }

            return items;
        }
    }
}
