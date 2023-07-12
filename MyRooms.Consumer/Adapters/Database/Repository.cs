using Dapper;
using MyRooms.Core.Domain.Entities;
using MySqlConnector;

namespace MyRooms.Consumer.Adapters.Database
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

        public async Task CreateHotelAsync(Hotel hotel, CancellationToken cancellationToken)
        {
            await _conn.OpenAsync();
            await _conn.ExecuteAsync(
                sql: Queries.CREATE_HOTEL, 
                param: new { hotel.Name, hotel.Country, hotel.Street, hotel.RoomsAvailable, hotel.RoomsBooked, hotel.ZipCode 
            });
            await _conn.CloseAsync();
        }

        public async Task CreateHotelRoomAsync(Hotel hotel, CancellationToken cancellationToken)
        {
            var room = hotel.Rooms.First();
            await _conn.OpenAsync();
            await _conn.ExecuteAsync(
                sql: Queries.CREATE_ROOM,
                param: new
                {
                    HotelId = hotel.Id,
                    Status = room.RoomStatus.ToString().ToUpper(),
                    RoomNumber = room.Number,
                    Price = room.Value
                });
            await _conn.CloseAsync();
        }
    }
}
