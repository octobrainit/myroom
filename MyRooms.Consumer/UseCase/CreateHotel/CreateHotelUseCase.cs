using MyRooms.Consumer.Adapters.Database;
using MyRooms.Shared.Handler;

namespace MyRooms.Consumer.UseCase.CreateHotel
{
    public class CreateHotelUseCase : BaseHandler<CreateHotelInput, HotelOutput>, ICreateHotelUseCase
    {
        private readonly IRepository _repository;

        public CreateHotelUseCase(IRepository repository) : base(new CreateHotelUseCaseValidator())
        {
            _repository = repository;
        }

        public override async Task HandleAsync(CreateHotelInput input, CancellationToken cancellationToken)
        {
            var hotel = input.ToDomain();

            if (!hotel.IsValid)
            {
                Response.AddMessage(hotel.Messages);
                return;
            }

            await _repository.CreateHotelAsync(hotel, cancellationToken);
        }
    }
}
