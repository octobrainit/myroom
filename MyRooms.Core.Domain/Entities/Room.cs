using MyRooms.Core.Domain.Enum;
using MyRooms.Core.Domain.Messages;
using MyRooms.Shared.Entities;

namespace MyRooms.Core.Domain.Entities
{
    public class Room : BaseEntity
    {
        public Room() : base(null) {}
        public Room(int number, double value, Status status, int? id) : base(id)
        {
            Validate(number, value);
            if (!IsValid)
                return;

            Number = number;
            Value = value;
            RoomStatus = status;
        }

        private void Validate(int number, double value)
        {
            if (number < 0)
                AddMessage(EntityMessages.ROOM_NUMBER_INVALID);
            if(value < 0)
                AddMessage(EntityMessages.ROOM_VALUE_INVALID);
        }

        public int Number { get; private set; }
        public double Value { get; private set; }
        public Status RoomStatus { get; private set; }
    }
}
