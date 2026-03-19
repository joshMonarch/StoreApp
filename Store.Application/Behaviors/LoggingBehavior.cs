using MediatR;
using Microsoft.Extensions.Logging;

namespace Store.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(
            ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken ct)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Handling {RequestName}",
                    typeof(TRequest).Name);
            }

            var response = await next(ct);

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Handled {RequestName}",
                    typeof(TRequest).Name);
            }

            return response;
        }
    }
}