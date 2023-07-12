using FluentValidation;
using MyRooms.Shared.Handler;

namespace MyRooms.Producer.UseCase.GetHotelDetails
{
    public interface IGetHotelDetailsUseCase : IBaseHandler<GetHotelDetailsInput, GetHotelDetailsOutput> {}

    public record GetHotelDetailsInput(int HotelId) : BaseInput;
    public record GetHotelDetailsOutput();

    public class GetHotelDetailsInputValidator: AbstractValidator<GetHotelDetailsInput>
    {
        public GetHotelDetailsInputValidator()
        {
            RuleFor(item => item.HotelId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
