using FluentValidation;
using MyRooms.Core.Domain.Entities;
using MyRooms.Shared.Handler;

namespace MyRooms.Producer.UseCase.GetHotels
{
    public interface IGetHotelsUseCase : IBaseHandler<GetHotels, IList<Hotel>> { }

    public record GetHotels() : BaseInput;

    public class GetHotelsValidator : AbstractValidator<GetHotels>
    {
        public GetHotelsValidator(){}
    }
}
