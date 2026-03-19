using MediatR;
using Store.Domain.Commons;

namespace Store.Application.Abstractions.Messaging;

public interface IApplicationEvent : IDomainEvent, INotification { }