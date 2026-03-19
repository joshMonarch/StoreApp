using Confluent.Kafka;
using Infrastructure.Kafka.Consumer;
using Infrastructure.Kafka.Producer;
using Infrastructure.Messaging.Consumer;
using Infrastructure.Messaging.Coonsumer;
using Infrastructure.Messaging.Producer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Store.Application.Abstractions;
using Store.Application.Abstractions.Messaging;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.SQLServer;
using Store.Infrastructure.Repositories;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnection")));

        #region User
        services.AddScoped<IUserRepository, UserRepository>();
        #endregion
        #region Address
        services.AddScoped<IAddressRepository, AddressRepository>();
        #endregion
        #region Product
        services.AddScoped<IProductRepository, ProductRepository>();
        #endregion
        #region Location
        services.AddScoped<ILocationRepository, LocationRepository>();
        #endregion
        #region Category
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        #endregion
        #region MongoDB

        var mongoConnectionString = configuration.GetValue<string>("MongoSettings:ConnectionString");
        var mongoDatabaseName = configuration.GetValue<string>("MongoSettings:DatabaseName");

        Console.WriteLine($"[DEBUG] MongoDB connection string: {mongoConnectionString}");
        Console.WriteLine($"[DEBUG] MongoDB database name: {mongoDatabaseName}");

        services.Configure<MongoDbSettings>(
            configuration.GetSection("MongoSettings"));

        services.AddSingleton<MongoDbContext>();

        #endregion
        #region MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        #endregion
        #region Kafka
        // ── Producer ────────────────────────────────────────
        var producerConfig = configuration
            .GetSection(KafkaProducerConfig.Section)
            .Get<KafkaProducerConfig>()!;

        services.AddSingleton(new ProducerConfig
        {
            BootstrapServers = producerConfig.BootstrapServers,
            Acks = producerConfig.Acks switch
            {
                "all" => Acks.All,
                "1" => Acks.Leader,
                _ => Acks.None
            },
            MessageSendMaxRetries = producerConfig.Retries,
            RetryBackoffMs = producerConfig.RetryBackoffMs,
            LingerMs = producerConfig.LingerMs,
            EnableIdempotence = producerConfig.EnableIdempotence
        });

        services.AddSingleton<IEventBus, KafkaEventBus>();

        // ── Consumer ────────────────────────────────────────
        var consumerConfig = configuration
            .GetSection(KafkaConsumerConfig.Section)
            .Get<KafkaConsumerConfig>()!;

        services.AddSingleton(new ConsumerConfig
        {
            BootstrapServers = consumerConfig.BootstrapServers,
            GroupId = consumerConfig.GroupId,
            AutoOffsetReset = consumerConfig.AutoOffsetReset == "earliest"
                                   ? AutoOffsetReset.Earliest
                                   : AutoOffsetReset.Latest,
            EnableAutoCommit = consumerConfig.EnableAutoCommit
        });
        // needed for reading Topics and TimeoutMs
        services.AddSingleton(consumerConfig);
        services.AddHostedService<KafkaTopicInitializer>();
        services.AddHostedService<KafkaConsumerService>();
        #endregion

        return services;
    }
}
