using BFF.Core.DTOs;
using BFF.Core.Interfaces;

namespace BFF.Core.Services
{
    public class ContractApplicationService
    {
        private readonly IContractService _contractService;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public ContractApplicationService(
            IContractService contractService,
            IClientService clientService,
            IProductService productService)
        {
            _contractService = contractService;
            _clientService = clientService;
            _productService = productService;
        }

        public async Task<ContractResponse> CreateContractAsync(ContractDTO contractDto)
        {
            // Validate client exists
            var client = await _clientService.GetClientAsync(contractDto.ClientId);
            if (client == null)
                throw new InvalidOperationException($"Client {contractDto.ClientId} not found");

            // Validate all products exist
            foreach (var productId in contractDto.ProductIds)
            {
                var product = await _productService.GetProductAsync(productId);
                if (product == null)
                    throw new InvalidOperationException($"Product {productId} not found");
            }

            // Create contract
            var contract = await _contractService.CreateContractAsync(new Models.ContractModel
            {
                ClientId = contractDto.ClientId,
                ProductIds = contractDto.ProductIds,
                StartDate = contractDto.StartDate,
                EndDate = contractDto.EndDate
            });

            return MapToResponse(contract);
        }

        private static ContractResponse MapToResponse(Models.ContractModel contract)
        {
            return new ContractResponse
            {
                ContractId = contract.ContractId,
                ClientId = contract.ClientId,
                ProductIds = contract.ProductIds,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                Status = contract.Status,
                CreatedAt = contract.CreatedAt,
                UpdatedAt = contract.UpdatedAt
            };
        }
    }
}