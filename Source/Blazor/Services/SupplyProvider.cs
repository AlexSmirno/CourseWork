﻿using Blazor.Data.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Blazor.Services
{
    public class SupplyProvider : ISupplyProvider
    {
        private HttpClient _httpClient;
        public SupplyProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Supply>?> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Supply>>("/api/Supply");
        }   

        public async Task<Supply?> GetOne(int id)
        {
            return await _httpClient.GetFromJsonAsync<Supply>($"/api/Supply/{id}");
        }

        public async Task<bool> Add(Supply product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var responce = await _httpClient.PostAsync("/api/Supply", httpContent);

            Console.WriteLine(await responce.Content.ReadAsStringAsync());

            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Supply?> Edit(Supply product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync("/api/Supply", httpContent);

            Supply? editSupply = JsonConvert.DeserializeObject<Supply>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(editSupply);
        }
        public async Task<bool> Remove(int id)
        {
            var delete = await _httpClient.DeleteAsync($"/api/Supply/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}