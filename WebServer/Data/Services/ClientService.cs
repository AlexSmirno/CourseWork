using Microsoft.EntityFrameworkCore;
using WebServer.Data.DTO;
using WebServer.Data.Models;
using WebServer.Data.Repositories;

namespace WebServer.Data.Services
{
    public class ClientService
    {
        private ClientRepository _clientRepository;

        public ClientService(ClientRepository storageRepository) => _clientRepository = storageRepository;
        public async Task<Client?> AddClient(ClientDTO client)
        {
            Client newClient = new Client()
            {
                CompanyName = client.CompanyName,
                DateEnd = client.DateEnd,
                DateStart = client.DateStart,
                Address = client.Address,
                Negotiator = client.Negotiator,
                Phone = client.Phone
            };

            var result = await _clientRepository.AddClientAsync(newClient);
            return await Task.FromResult(result);
        }
            
        public async Task<Client?> GetClient(int Id)
        {
            var result = await _clientRepository.GetClientByIdAsync(Id);
            return await Task.FromResult(result);
        }

        public async Task<List<Client>> GetClients()
        {
            var result = await _clientRepository.GetAllClientAsync();
            return await Task.FromResult(result);
        }

        public async Task<Client?> UpdateClient(ClientDTO newClient)
        {
            var client = await _clientRepository.GetClientByIdAsync(newClient.Id);
            if (client != null)
            {
                client.CompanyName = newClient.CompanyName;
                client.Address = newClient.Address;
                client.Negotiator = newClient.Negotiator;
                client.Phone = newClient.Phone;
                client.DateEnd = newClient.DateEnd;
                client.DateStart = newClient.DateStart;

                return await _clientRepository.UpdateClientAsync(client);
            }

            return null;
        }

        public async Task<bool> DeleteClient(int Id)
        {
            var client = await _clientRepository.GetClientByIdAsync(Id);

            if (client != null)
            {
                await _clientRepository.DeleteClientAsync(client);
                return true;
            }

            return false;
        }
    }
}
