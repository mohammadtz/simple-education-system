using MediatR;

namespace Education.Common.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{

}