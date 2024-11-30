using BFF.Core.Models;

namespace BFF.Core.Interfaces
{
    public interface IClientService
    {
        Task<ClientModel> GetClientAsync(string clientId);
        Task<ClientModel> CreateClientAsync(ClientModel client);
        Task<ClientModel> UpdateClientAsync(string clientId, ClientModel client);
    }
}