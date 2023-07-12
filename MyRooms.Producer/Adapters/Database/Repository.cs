using Dapper;
using MyRooms.Core.Domain.Entities;
using MySqlConnector;

namespace MyRooms.Producer.Adapters.Database
{
    public class Repository : IRepository
    {
        private readonly MySqlConnection _conn;

        public Repository(MySqlConnection conn)
        {
            if (conn is not null)
            {
                _conn = conn;
                _conn.Open();
                var data = _conn.Query<int>("SELECT count(*) AS TOTALNUMBEROFTABLES FROM INFORMATION_SCHEMA.TABLES \r\nWHERE TABLE_SCHEMA = 'testedb'");
                var tablesCreated = data.FirstOrDefault();

                if (tablesCreated is not 3)
                {
                    _conn.Execute(Queries.STARTDB_TABLES);
                }
                _conn.Close();
            }
        }

        public async Task<Hotel> GetHotelDetailsAsync(int id, CancellationToken cancellationToken)
        {
            await _conn.OpenAsync();

            var data = await _conn.QueryAsync<Hotel, Room, Hotel>(
               Queries.GET_HOTEL_DETAILS,
               (h, r) =>
               {
                   var hotel = h;

                   if (hotel is not null)
                   {
                       Room room = r;
                       if (room is not null)
                           hotel.AddRoom(room);
                   }
                   return hotel;
               },
               param: new{ Id = id });

            await _conn.CloseAsync();

            return data.FirstOrDefault() ?? new Hotel();
        }

        public async Task<IList<Hotel>> GetHotelsAsync(CancellationToken cancellationToken)
        {
            await _conn.OpenAsync();
            var data = await _conn.QueryAsync<Hotel>(
                sql: Queries.GET_HOTELS);
            await _conn.CloseAsync();

            return data.Select(item => new Hotel(item.Name, item.Street, item.ZipCode, item.RoomsAvailable, item.RoomsBooked, item.Country, null, id: item.Id)).ToList();
        }
    }
}
