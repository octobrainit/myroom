using MyRooms.Producer.Adapters.Database;
using MyRooms.Shared.Handler;

namespace MyRooms.Producer.UseCase.GetHotelDetails
{
    public class GetHotelDetailsUseCase : BaseHandler<GetHotelDetailsInput, GetHotelDetailsOutput>, IGetHotelDetailsUseCase
    {
        private readonly IRepository _repository;

        public GetHotelDetailsUseCase(IRepository repository) : base(new GetHotelDetailsInputValidator())
        {
            _repository = repository;
        }

        public override async Task HandleAsync(GetHotelDetailsInput input, CancellationToken cancellationToken)
        {
            var hotel = await _repository.GetHotelDetailsAsync(input.HotelId, cancellationToken);

            if (hotel is null)
            {
                Response.AddMessage("Hotel nao encontrado");
                return;
            }

            Response.AddResult(hotel);
        }
    }
}
