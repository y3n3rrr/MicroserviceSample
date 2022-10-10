using MediatR;

namespace Product.API.Services
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}