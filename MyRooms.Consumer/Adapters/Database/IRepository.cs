using MyRooms.Core.Domain.Entities;

namespace MyRooms.Consumer.Adapters.Database
{
    public interface IRepository
    {
        Task CreateHotelAsync(Hotel hotel, CancellationToken cancellationToken);
        Task CreateHotelRoomAsync(Hotel hotel, CancellationToken cancellationToken);
    }
}
