using BFF.Core.Interfaces;
using BFF.Infrastructure.Services;
using Grpc.Net.Client;

namespace BFF.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGrpcServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Create gRPC channels
            var clientChannel = GrpcChannel.ForAddress(configuration["GrpcServices:ClientService"]);
            var productChannel = GrpcChannel.ForAddress(configuration["GrpcServices:ProductService"]);
            var contractChannel = GrpcChannel.ForAddress(configuration["GrpcServices:ContractService"]);

            // Register gRPC clients
            services.AddSingleton<IClientService>(new GrpcClientService(clientChannel));
            services.AddSingleton<IProductService>(new GrpcProductService(productChannel));
            services.AddSingleton<IContractService>(new GrpcContractService(contractChannel));

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ContractApplicationService>();
            // Add other application services here

            return services;
        }
    }
}