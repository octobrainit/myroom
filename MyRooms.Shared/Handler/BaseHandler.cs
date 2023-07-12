using FluentValidation;

namespace MyRooms.Shared.Handler
{
    public abstract class BaseHandler<TInput, TOutput> where TInput : IDataInputed where TOutput : class
    {
        private readonly IValidator<TInput> _validator;

        public abstract Task HandleAsync(TInput input, CancellationToken cancellationToken);
        public HandlerOutput Response { get; set; } = new();

        public BaseHandler(IValidator<TInput> validator)
        {
            _validator = validator;
        }

        public async Task<HandlerOutput> HandleExecutionAsync(TInput input, CancellationToken cancellationToken)
        {
            try
            {
                var validate = _validator.Validate(input);

                if (!validate.IsValid)
                {
                    Response.AddMessage(validate.Errors.Select(item => item.ErrorMessage).ToList());
                    return Response;
                }
                await HandleAsync(input, cancellationToken);

                return Response;
            }
            catch (Exception ex)
            {
                Response.Messages.Add($"Some error ocurred  CorrelationId: {input.GetCorrelationId()} error => {ex.Message}");
                return Response;
            }
        }
    }
}
