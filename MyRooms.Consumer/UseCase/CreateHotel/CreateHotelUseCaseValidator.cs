using FluentValidation;

namespace MyRooms.Consumer.UseCase.CreateHotel
{
    public class CreateHotelUseCaseValidator : AbstractValidator<CreateHotelInput>
    {
        public CreateHotelUseCaseValidator()
        {
            RuleFor(item => item.RoomsAvailable).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(item => item.Name).MinimumLength(3).NotNull().NotEmpty();
            RuleFor(item => item.RoomsAvailable).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(item => item.RoomsBooked).GreaterThanOrEqualTo(0).NotNull().NotEmpty();
            RuleFor(item => item).Custom((data, context) =>
            {
                if (data.RoomsBooked >= data.RoomsAvailable)
                    context.AddFailure("Quartos disponiveis deve ser maior que reservados");
            });
            RuleFor(item => item.Address).Custom((data, context) =>
            {
                if (string.IsNullOrWhiteSpace(data.ZipCode))
                    context.AddFailure("ZipCode e requerido");
                if (string.IsNullOrWhiteSpace(data.Country))
                    context.AddFailure("ZipCode e requerido");
                if (string.IsNullOrWhiteSpace(data.Street))
                    context.AddFailure("ZipCode e requerido");
            });
        }
    }
}
