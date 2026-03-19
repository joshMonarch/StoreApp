using MediatR;
using MongoDB.Driver;
using Store.Application.Events.CategoryEvents;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.Mongo.ReadModels;

public class CategoryProjectionHandler :
    INotificationHandler<CategoryCreatedEvent>,
    INotificationHandler<CategoryUpdatedEvent>
{
    private readonly IMongoCollection<CategoryReadModel> _collection;

    public CategoryProjectionHandler(MongoDbContext context)
    {
        _collection = context.GetCollection<CategoryReadModel>("categories");
    }

    public async Task Handle(
        CategoryCreatedEvent notification,
        CancellationToken ct)
    {
        var readModel = new CategoryReadModel
        (
            notification.Id,
            notification.CategoryName,
            notification.CreatedAt,
            notification.UpdatedAt
        );

        await _collection.InsertOneAsync(readModel, cancellationToken: ct);
    }

    public async Task Handle(
        CategoryUpdatedEvent notification,
        CancellationToken ct)
    {
        /*
        var update = Builders<CategoryReadModel>.Update
            .Set(x => x.CategoryName, notification.CategoryName)
            .Set(x => x.UpdatedAt, notification.UpdatedAt);

        await _collection.UpdateOneAsync(
            x => x.Id == notification.Id,
            update);
        */
    }
}