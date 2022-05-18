using Blazor.Data.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Blazor.Services
{
    public class ClientProvider : IClientProvider
    {
        private readonly HttpClient _httpClient;
        public ClientProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Client>?> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Client>>("/api/Client");
        }

        public async Task<List<string>> GetAllNames()
        {
            return await _httpClient.GetFromJsonAsync<List<string>>("/api/Client/Names");
        }

        public async Task<Client?> GetOne(int id)
        {
            return await _httpClient.GetFromJsonAsync<Client>($"/api/Client/{id}");
        }

        public async Task<bool> Add(Client client)
        {
            string data = JsonConvert.SerializeObject(client);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var responce = await _httpClient.PostAsync("/api/Client", httpContent);

            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Client?> Edit(Client product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync("/api/Client", httpContent);

            Client? editClient = JsonConvert.DeserializeObject<Client>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(editClient);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _httpClient.DeleteAsync($"/api/Client/{id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}
