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
            client.BaseAddress = new Uri($"http://10.142.86.22:5000/");

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

        public async Task<WorkDay> GetWorkDayAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/workday/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<WorkDay>(json));
            }

            return null;
        }

        public async Task<bool> AddWorkDayAsync(WorkDay item)
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

            var response = await client.PutAsync(new Uri($"api/workday/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteWorkDayAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/workday/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
