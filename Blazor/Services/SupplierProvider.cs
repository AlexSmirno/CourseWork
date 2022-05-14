using Blazor.Data.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Blazor.Services
{
    public class SupplierProvider : ISupplierProvider
    {
        private HttpClient _httpClient;
        public SupplierProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Supplier>?> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Supplier>>("https://localhost:7053/api/Supplier");
            //return await _httpClient.GetFromJsonAsync<List<Supplier>>("/api/Supplier");
        }

        public async Task<Supplier?> GetOne(int id)
        {
            return await _httpClient.GetFromJsonAsync<Supplier>($"https://localhost:7053/api/Supplier/{id}");
        }

        public async Task<bool> Add(Supplier product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var responce = await _httpClient.PostAsync("/api/Supplier", httpContent);

            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Supplier?> Edit(Supplier product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync("/api/Supplier", httpContent);

            Supplier? editSupplier = JsonConvert.DeserializeObject<Supplier>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(editSupplier);
        }
        public async Task<bool> Remove(int id)
        {
            var delete = await _httpClient.DeleteAsync($"/api/Supplier/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}
