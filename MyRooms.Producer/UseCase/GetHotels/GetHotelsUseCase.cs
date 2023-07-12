using MyRooms.Core.Domain.Entities;
using MyRooms.Producer.Adapters.Database;
using MyRooms.Shared.Handler;

namespace MyRooms.Producer.UseCase.GetHotels
{
    public class GetHotelsUseCase : BaseHandler<GetHotels, IList<Hotel>>, IGetHotelsUseCase
    {
        private readonly IRepository _repository;

        public GetHotelsUseCase(IRepository repository) : base(new GetHotelsValidator())
        {
            _repository = repository;
        }
        public override async Task HandleAsync(GetHotels input, CancellationToken cancellationToken)
        {
            Response.AddResult(await _repository.GetHotelsAsync(cancellationToken));
        }
    }
}
