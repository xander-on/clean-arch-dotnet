


using Microsoft.Extensions.DependencyInjection;

namespace Application.Utilities.Mediator;

public class SimpleMediator(IServiceProvider sp) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        var useCase = sp.GetRequiredService(handlerType);

        var method = handlerType.GetMethod("Handle")
            ?? throw new InvalidOperationException("Handle method not found");
            
        var result = method.Invoke(useCase, new object[] { request })
            ?? throw new InvalidOperationException("Handler returned null");

        // return await (Task<TResponse>)method.Invoke(useCase, new object[] { request });
        return await (Task<TResponse>)result;
    }
}