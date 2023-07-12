namespace MyRooms.Consumer.Adapters.Database
{
    public static class Queries
    {
        public static string STARTDB_TABLES = @"
            DROP TABLE IF EXISTS RoomReservation;
            DROP TABLE IF EXISTS Room;
            DROP TABLE IF EXISTS Hotel;

            SET NAMES utf8;
            SET time_zone = '+00:00';
            SET foreign_key_checks = 0;
            SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

            USE `testedb`;

            SET NAMES utf8mb4;

            CREATE TABLE `Hotel` (
              `Id` int(11) NOT NULL AUTO_INCREMENT,
              `Name` varchar(255) NOT NULL,
              `Street` varchar(255) NOT NULL,
              `ZipCode` varchar(255) NOT NULL,
              `Country` varchar(255) NOT NULL,
              `RoomsAvailable` int(11) NOT NULL,
              `RoomsBoocked` int(11) NOT NULL,
              PRIMARY KEY (`Id`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

            INSERT INTO `Hotel` (`Name`, `Street`, `ZipCode`, `Country`, `RoomsAvailable`, `RoomsBoocked`) VALUES
            ('Hotel Transilvânia',	'Rua dos Maracujas',	'15999999',	'Brasil',	50,	30),
            ('Hotel Biju',	'Konoha',	'15000000',	'Brasil',	15,	0);

            CREATE TABLE `Room` (
              `Id` int(11) NOT NULL AUTO_INCREMENT,
              `Number` int(11) NOT NULL,
              `Status` varchar(11) NOT NULL,
              `Hotel_Id` int(11) NOT NULL,
              `Price` NUMERIC NOT NULL,
              PRIMARY KEY (`Id`),
              KEY `Hotel_Id` (`Hotel_Id`),
              CONSTRAINT `Room_ibfk_1` FOREIGN KEY (`Hotel_Id`) REFERENCES `Hotel` (`Id`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

            INSERT INTO `Room` (`Number`, `Status`, `Hotel_Id`) VALUES
            (1,	'AVAILABLE',	1),
            (2,	'UNAVAILABLE',	1),
            (5,	'AVAILABLE',	2);

            CREATE TABLE `RoomReservation` (
              `Id` int(11) NOT NULL AUTO_INCREMENT,
              `Room_Id` int(11) NOT NULL,
              `DateStart` datetime NOT NULL,
              `DateEnd` datetime NOT NULL,
              PRIMARY KEY (`Id`),
              KEY `Room_Id` (`Room_Id`),
              CONSTRAINT `RoomReservation_ibfk_1` FOREIGN KEY (`Room_Id`) REFERENCES `Room` (`Id`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
        ";

        public static string CREATE_HOTEL = @"
            INSERT INTO `Hotel` (`Name`, `Street`, `ZipCode`, `Country`, `RoomsAvailable`, `RoomsBoocked`) VALUES
            (@Name,	@Street, @ZipCode, @Country, @RoomsAvailable,@RoomsBooked)
         ";

        public static string CREATE_ROOM = @"
           INSERT INTO `Room` (`Number`, `Status`, `Hotel_Id`, `Price`) VALUES
            (@RoomNumber,	@Status, @HotelId, @Price),
         ";
    }
}
