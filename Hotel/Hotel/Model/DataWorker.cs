using ManageStaffDBApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageStaffDBApp.Model
{
    public static class DataWorker
    {
        #region AllTables
        //получить все Reservation
        public static List<Reservation> GetAllReservations()//depertament
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Reservations.ToList();
                return result;
            }
        }
        //получить все Room
        public static List<Room> GetAllRooms() //postion
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Rooms.ToList();
                return result;
            }
        }
        //получить всех Client
        public static List<Client> GetAllClients()//user
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Clients.ToList();
                return result;
            }
        }
        #endregion

        //создать отдел
        public static string CreateReservations(DateTime CheckInDate, DateTime CheckOutDate,Client client, Room room, string ReservationStatus, string typePayment)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли отдел
                bool checkIsExist = db.Reservations.Any(el => el.Room == room);
                if (!checkIsExist)
                {
                    Reservation newReservation = new Reservation { CheckInDate = CheckInDate, CheckOutDate= CheckOutDate,ClientsId = client.Id,RoomsId=room.Id, ReservationStatus = ReservationStatus, typePayment = typePayment };
                    db.Reservations.Add(newReservation);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //содать позицию
        public static string CreateRooms(string Number, int Floor, string Type, int Capfcity, string Status,string Price)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли позиция
                bool checkIsExist = db.Rooms.Any(el => el.Number == Number);
                if (!checkIsExist)
                {
                    Room newRooms = new Room
                    {
                        Number = Number,
                        Floor = Floor,
                        Type = Type,
                        Capfcity = Capfcity,
                        Status = Status,
                        Price = Price,
                    };
                    db.Rooms.Add(newRooms);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //создать сотрудника
        public static string CreateClient(string FirstName, string LastName, string PhoneNumber, string Gender, string Passport, DateTime DateOfBrith)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check the user is exist
                bool checkIsExist = db.Clients.Any(el => el.FirstName == FirstName && el.LastName == LastName);
                if (!checkIsExist)
                {
                    Client newClient = new Client
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        PhoneNumber = PhoneNumber,
                        Gender = Gender,
                        Passport = Passport,
                        DateOfBrith = DateOfBrith,
                    };
                    db.Clients.Add(newClient);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //удаление отдел
        public static string DeleteReservations(Reservation Reservation)
        {
            string result = "Такого отела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Reservations.Remove(Reservation);
                db.SaveChanges();
                result = "Сделано! Reservations " + Reservation.Client + " delete";
            }
            return result;
        }
        //удаление позицию
        public static string DeleteRoom(Room Room)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check position is exist
                db.Rooms.Remove(Room);
                db.SaveChanges();
                result = "Сделано! Room " + Room.Number + " delete";
            }
            return result;
        }
        //удаление сотрудника
        public static string DeleteClients(Client Client)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Clients.Remove(Client);
                db.SaveChanges();
                result = "Сделано! client " + Client.FirstName + " delete";
            }
            return result;
        }
        //редактирование Reservation
        public static string EditReservations(Reservation oldReservation, DateTime newCheckInDate, DateTime newCheckOutDate, Client newclient, Room newroom, string newReservationStatus, string newtypePayment)
        {
            string result = "Такого отела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Reservation reservation = db.Reservations.FirstOrDefault(d => d.Id == oldReservation.Id);
                reservation.CheckInDate = newCheckInDate;
                reservation.CheckOutDate = newCheckOutDate;
                reservation.ClientsId= newclient.Id;
                reservation.RoomsId = newroom.Id;
                reservation.ReservationStatus = newReservationStatus;
                reservation.typePayment = newtypePayment;
                db.SaveChanges();
                result = "Сделано! Отдел " + reservation.CheckInDate + " изменен";
            }
            return result;
        }
        //редактирование Room
        public static string EditRoom(Room oldRoom, string newNumber, int newFloor, string newType, int newCapfcity, string newStatus, string newPrice)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Room Room = db.Rooms.FirstOrDefault(p => p.Id == oldRoom.Id);
                Room.Number = newNumber;
                Room.Floor = newFloor;
                Room.Type = newType;
                Room.Capfcity = newCapfcity;
                Room.Status = newStatus;
                Room.Price = newPrice;
                db.SaveChanges();
                result = "Сделано! Позиция " + Room.Number + " изменена";
            }
            return result;
        }
        //редактирование EditClient
        public static string EditClient(Client oldClient, string newFirstName, string newLastName, string newPhoneNumber, string newGender, string newPassport, DateTime newDateOfBrith)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check user is exist
                Client client = db.Clients.FirstOrDefault(p => p.Id == oldClient.Id);
                if (client != null)
                {
                    client.FirstName = newFirstName;
                    client.LastName = newLastName;
                    client.PhoneNumber = newPhoneNumber;
                    client.Gender = newGender;
                    client.Passport = newPassport;
                    client.DateOfBrith = newDateOfBrith;
                    db.SaveChanges();
                    result = "Сделано! Сотрудник " + client.LastName + client.FirstName + " изменен";
                }
            }
            return result;
        }

        //получение Room по id позитиции
        public static Room GetRoomById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Room pos = db.Rooms.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //получение Reservation по id отдела
        public static Reservation GetReservationById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Reservation pos = db.Reservations.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        public static Client GetclientById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Client pos = db.Clients.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //получение всех пользователей по id позицииr
        public static List<Client> GetAllclientId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Client> users = (from client in GetAllClients() where client.Id == id select client).ToList();
                return users;
            }
        }
        //получение всех Room по id отдела
        public static List<Room> GetAllPositionsByDepartmentId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Room> positions = (from Room in GetAllRooms() where Room.Id == id select Room).ToList();
                return positions;
            }
        }
    }
}
