using MediatR;
using MongoDB.Driver;
using Store.Application.Events.ProductEvents;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.Mongo.ReadModels;

public class ProductProjectionHandler :
    INotificationHandler<ProductCreatedEvent>,
    INotificationHandler<ProductUpdatedEvent>
{
    private readonly IMongoCollection<ProductReadModel> _collection;

    public ProductProjectionHandler(MongoDbContext context)
    {
        _collection = context.GetCollection<ProductReadModel>("products");
    }

    public async Task Handle(
        ProductCreatedEvent notification,
        CancellationToken ct)
    {
        var readModel = new ProductReadModel
        (
            notification.Id,
            notification.UserId,
            notification.CategoryId,
            notification.Name,
            notification.Stock,
            notification.CreatedAt,
            notification.UpdatedAt
        );

        await _collection.InsertOneAsync(readModel, cancellationToken: ct);
    }

    public async Task Handle(
        ProductUpdatedEvent notification,
        CancellationToken ct)
    {
        /*
        var update = Builders<ProductReadModel>.Update
            .Set(x => x.CategoryId, notification.CategoryId)
            .Set(x => x.Name, notification.Name)
            .Set(x => x.Stock, notification.Stock)
            .Set(x => x.UpdatedAt, notification.UpdatedAt);

        await _collection.UpdateOneAsync(
            x => x.Id == notification.Id,
            update);
        */
    }
}