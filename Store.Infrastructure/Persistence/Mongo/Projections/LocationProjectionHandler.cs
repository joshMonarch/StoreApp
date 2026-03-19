using MediatR;
using MongoDB.Driver;
using Store.Application.Events.LocationEvents;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.Mongo.ReadModels;

public class LocationProjectionHandler :
    INotificationHandler<LocationCreatedEvent>,
    INotificationHandler<LocationUpdatedEvent>
{
    private readonly IMongoCollection<LocationReadModel> _collection;

    public LocationProjectionHandler(MongoDbContext context)
    {
        _collection = context.GetCollection<LocationReadModel>("locations");
    }

    public async Task Handle(
        LocationCreatedEvent notification,
        CancellationToken ct)
    {
        var readModel = new LocationReadModel
        (
            notification.Id,
            notification.LocationType,
            notification.CreatedAt,
            notification.UpdatedAt
        );

        await _collection.InsertOneAsync(readModel, cancellationToken: ct);
    }

    public async Task Handle(
        LocationUpdatedEvent notification,
        CancellationToken ct)
    {
        /*
        var update = Builders<LocationReadModel>.Update
            .Set(x => x.LocationType, notification.LocationType)
            .Set(x => x.UpdatedAt, notification.UpdatedAt);

        await _collection.UpdateOneAsync(
            x => x.Id == notification.Id,
            update);
        */
    }
}