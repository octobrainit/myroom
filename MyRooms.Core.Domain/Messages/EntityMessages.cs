namespace MyRooms.Core.Domain.Messages
{
    public static class EntityMessages
    {
        public static string ROOM_NUMBER_INVALID = "O numero do quarto deve ser maior que zero";
        public static string ROOM_VALUE_INVALID = "O valor do quarto deve ser maior que zero";

        public static string RESERVATION_ROOMID_INVALID = "O numero do quarto deve ser maior que zero";
        public static string RESERVATION_ROOM_DATES_INVALID = "A data de inicio deve ser maior que a data fim";

        public static string HOTEL_CHANGEROOMAVAILABLE_INVALID = "O numero de quartos cadastrados deve ser menor ou igual ao de quarto disponivel";
        public static string HOTEL_CHANGEROOMBOOKED_INVALID = "O numero de quartos alugados nao pode ultrapassar o numero de quartos";
        public static string HOTEL_ADDROOM_INVALID = "O numero de quartos ultrapassa o total cadastrado";
        public static string HOTEL_UPDATEROOM_INVALID = "Quarto alterado pois nao foi encontrado";
    }
}
