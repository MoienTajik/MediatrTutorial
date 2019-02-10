using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrTutorial.Infrastructure.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<RequestPerformanceBehaviour<TRequest, TResponse>> _logger;

        public RequestPerformanceBehaviour(ILogger<RequestPerformanceBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            TResponse response = await next();

            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > TimeSpan.FromSeconds(5).Milliseconds)
            {
                // This method has taken a long time, So we log that to check it later.
                _logger.LogWarning($"{request} has taken {stopwatch.ElapsedMilliseconds} to run completely !");
            }

            return response;
        }
    }
}