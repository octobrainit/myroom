using MyRooms.Core.Domain.Entities;
using System.Threading;

namespace MyRooms.Producer.Adapters.Database
{
    public interface IRepository
    {
        Task<IList<Hotel>> GetHotelsAsync(CancellationToken cancellationToken);
        Task<Hotel> GetHotelDetailsAsync(int id, CancellationToken cancellationToken);
    }
}
