using Application.Boundaries.UseCases;
using Domain.Receip;
using Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection serviceCollection)
    {
        BsonClassMap.RegisterClassMap<Receip>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(c => c.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance);
            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }

    public static IServiceCollection ConfigureIoC(this IServiceCollection serviceCollection)
    {

        serviceCollection.AddTransient<IReceipRepository, ReceipRepository>();

        serviceCollection.AddMediatR(typeof(ProcessReceip).Assembly);

        return serviceCollection;
    }
}