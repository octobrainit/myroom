using MyRooms.Core.Domain.Enum;
using MyRooms.Core.Domain.Messages;
using MyRooms.Shared.Entities;
using System.Data;

namespace MyRooms.Core.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public Hotel() : base(null){}
        public Hotel(string name, string street, string zipCode, int roomsAvailable, int roomsBooked, string country, IList<Room> rooms, int? id) : base(id)
        {
            Name = name;
            Street = street;
            ZipCode = zipCode;
            RoomsAvailable = roomsAvailable;
            Rooms = rooms;
            Country = country;
            RoomsBooked = roomsBooked;

            if (Rooms is not null)
                GetMessages();
        }

        private void GetMessages()
        {
            _ = Rooms
                .Where(item => !item.IsValid)
                .Select(item =>
                {
                    _ = item.Messages.Select(data =>
                    {
                        this.AddMessage(string.Concat($"Quarto numero: {item.Id} com problema =>", data));
                        return data;
                    });
                    return item;
                });
        }

        public string Name { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public int RoomsAvailable { get; private set; }
        public int RoomsBooked { get; private set; }
        public IList<Room> Rooms { get; private set; } = new List<Room>();

        public void ChangeHotelName(string name)
        {
            if (!(string.IsNullOrWhiteSpace(name) && name.Length < 3))
                Name = name.ToUpper();
        }

        public void ChangeHotelCountry(string country)
        {
            if (!(string.IsNullOrWhiteSpace(country) && country.Length < 3))
                Country = country.ToUpper();
        }

        public void ChangeRoomsAvailable(int number)
        {
            if (number < Rooms.Count || number <= 0)
            {
                AddMessage(EntityMessages.HOTEL_CHANGEROOMAVAILABLE_INVALID);
                return;
            }

            RoomsAvailable = number;
        }

        public void ChangeRoomsBooked(int number)
        {
            if (number > Rooms.Count || number <= 0)
            {
                AddMessage(EntityMessages.HOTEL_CHANGEROOMBOOKED_INVALID);
                return;
            }

            RoomsAvailable = number;
        }


        public void ChangeHotelAddress(string street, string zipcode)
        {
            if (!(string.IsNullOrWhiteSpace(street) && street.Length < 3))
                Street = street;
            if (!(string.IsNullOrWhiteSpace(zipcode) && zipcode.Length < 3))
                ZipCode = zipcode;
        }

        public void AddRoom(Room room)
        {
            if (Rooms.Count + 1 <= RoomsAvailable)
            {
                Rooms.Add(room);
                return;
            }
            AddMessage(EntityMessages.HOTEL_ADDROOM_INVALID);
        }

        public void RemoveRoom(Room room)
        {
            Rooms.Remove(room);
        }

        public void UpdateRoom(Room room)
        {
            var data = Rooms.Where(item => item.Id == room.Id).FirstOrDefault();

            if (data is not null)
            {
                Rooms[Rooms.IndexOf(data)] = room;
                return;
            }
            AddMessage(EntityMessages.HOTEL_UPDATEROOM_INVALID);
        }

        public bool RoomIsAvailable(int roomId) =>
            Rooms.Any(item => item.Id == roomId && item.RoomStatus == Status.Available);

    }
}
