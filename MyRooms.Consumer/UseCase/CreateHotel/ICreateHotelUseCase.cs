using MyRooms.Core.Domain.Entities;
using MyRooms.Shared.Handler;

namespace MyRooms.Consumer.UseCase.CreateHotel
{
    public interface ICreateHotelUseCase : IBaseHandler<CreateHotelInput, HotelOutput> { }

    public record CreateHotelInput(string Name, HotelAddress Address, int RoomsAvailable, int RoomsBooked) : BaseInput
    {
        public Hotel ToDomain()
        {
            var hotel = new Hotel(Name, Address.Street, Address.ZipCode, RoomsAvailable, RoomsBooked, Address.Country, new List<Room>(), null);
            return hotel;
        }

    };

    public record HotelAddress(string Street, string ZipCode, string Country);

    public record HotelOutput();
}

