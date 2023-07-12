using MyRooms.Core.Domain.Messages;
using MyRooms.Shared.Entities;

namespace MyRooms.Core.Domain.Entities
{
    internal class Reservation : BaseEntity
    {
        public Reservation(int roomId, DateTime startDate, DateTime endDate, int? id) : base(id)
        {
            Validate(roomId, startDate, endDate);
            if (!IsValid)
                return;

            RoomId = roomId;
            StartDate = startDate.ToUniversalTime();
            EndDate = endDate.ToUniversalTime();
        }

        private void Validate(int roomId, DateTime startDate, DateTime endDate)
        {
            if (roomId < 0)
                AddMessage(EntityMessages.RESERVATION_ROOMID_INVALID);
            if (startDate.ToUniversalTime() > endDate.ToUniversalTime())
                AddMessage(EntityMessages.RESERVATION_ROOM_DATES_INVALID);
        }

        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool HasReservationBetween(DateTime dateStart, DateTime dateEnd) =>
            ((dateStart > StartDate && dateStart > StartDate) || dateEnd < StartDate) &&
            dateStart < dateEnd &&
            dateStart >= DateTime.UtcNow;
    }
}
