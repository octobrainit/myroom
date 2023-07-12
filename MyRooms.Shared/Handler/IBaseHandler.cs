namespace MyRooms.Shared.Handler
{
    public interface IBaseHandler<TInput, TOutput> 
        where TInput : IDataInputed 
        where TOutput : class
    {
        Task<HandlerOutput> HandleExecutionAsync(TInput input, CancellationToken cancellationToken);
    }
}
