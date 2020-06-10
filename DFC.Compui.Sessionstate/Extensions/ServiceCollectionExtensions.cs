using DFC.Compui.Cosmos;
using DFC.Compui.Cosmos.Contracts;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DFC.Compui.Sessionstate
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSessionStateServices<TModel>(this IServiceCollection services, CosmosDbConnection cosmosDbConnection, bool isDevelopment)
            where TModel : class, new()
        {
            _ = cosmosDbConnection ?? throw new ArgumentNullException(nameof(cosmosDbConnection));

            var documentClient = new DocumentClient(cosmosDbConnection!.EndpointUrl, cosmosDbConnection!.AccessKey);
            object[] serviceArguments = { cosmosDbConnection, documentClient, isDevelopment };

            services.AddSingleton(cosmosDbConnection);
            services.AddSingleton<IDocumentClient>(documentClient);
            services.AddSingleton<ICosmosRepository<SessionStateModel<TModel>>>(x => ActivatorUtilities.CreateInstance<CosmosRepository<SessionStateModel<TModel>>>(x, serviceArguments));
            services.AddTransient<IDocumentService<SessionStateModel<TModel>>, DocumentService<SessionStateModel<TModel>>>();
            services.AddTransient<ISessionStateService<TModel>, SessionStateService<TModel>>();

            return services;
        }
    }
}
