using Hotel.MVVM.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.MVVM.Model;

namespace Hotel.Model
{
    public static class DataWorker
    {
        //получить все Clients
        public static List<Clients> GetAllClients()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.clients.ToList();
                return result;
            }
        }
        //получить все Rooms
        public static List<Rooms> GetAllRooms()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.rooms.ToList();
                return result;
            }
        }
        //получить всех Reservations
        public static List<Reservations> GetAllReservations()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.reservations.ToList();
                return result;
            }
        }
        //создать Rooms
        public static string CreateRooms(string Number, int Floor, string Type,int Capfcity,string Status,string Price)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли отдел
                bool checkIsExist = db.rooms.Any(el => el.Number == Number);
                if (!checkIsExist)
                {
                    Rooms newRooms = new Rooms 
                    { 
                        Number = Number,
                        Floor = Floor,
                        Type = Type,
                        Capfcity = Capfcity,
                        Status = Status,
                        Price = Price,

                    };
                    db.rooms.Add(newRooms);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //содать Reservations
        public static string CreateReservations(DateTime CheckInDate, DateTime CheckOutDate,Rooms rooms,string ReservationsStatus,string TypePayment,Clients clients)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли позиция
                bool checkIsExist = db.reservations.Any(el => el.RoomId == rooms);
                if (!checkIsExist)
                {
                    Reservations newReservations = new Reservations
                    {
                        CheckInDate = CheckInDate,
                        CheckOutdate = CheckOutDate,
                        RoomId = rooms,
                        ReservationsStatus = ReservationsStatus,
                        TypePayment = TypePayment,
                        ClientsId = clients,

                    };
                    db.reservations.Add(newReservations);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //создать Clients
        public static string CreateClients(string FirstName, string lastName, string PhoneNumber, string Gender,string Passport, DateTime DateOfBrith)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check the user is exist
                bool checkIsExist = db.clients.Any(el => el.FirstName == FirstName && el.LastName == FirstName );
                if (!checkIsExist)
                {
                    Clients newClients = new Clients
                    {
                        FirstName = FirstName,
                        LastName = lastName,
                        PhoneNumber = PhoneNumber,
                        Gender = Gender,
                        Passport = Passport,
                        DateOfBrith = DateOfBrith,
                    };
                    db.clients.Add(newClients);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //удаление отдел
        public static string DeleteReservationst(Reservations Reservations)
        {
            string result = "Такого отела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.reservations.Remove(Reservations);
                db.SaveChanges();
                result = "Сделано! Отдел " + Reservations.Id + Reservations.ClientsId + "удален";
            }
            return result;
        }
        //удаление позицию
        public static string DeleteRooms(Rooms Rooms)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check position is exist
                db.rooms.Remove(Rooms);
                db.SaveChanges();
                result = "Сделано! Позиция " + Rooms.Number + " удалена";
            }
            return result;
        }
        //удаление сотрудника
        public static string DeleteClients(Clients DelClients)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.clients.Remove(DelClients);
                db.SaveChanges();
                result = "Сделано! Clients " + DelClients.FirstName + " Del";
            }
            return result;
        }
        //редактирование Reservationst
        public static string EditReservationst(Reservations oldReservationst, DateTime newCheckInDate, DateTime newCheckOutDate, Rooms newrooms, string newReservationsStatus, string newTypePayment, Clients newclients)
        {
            string result = "Такого отела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Reservations Reservations = db.reservations.FirstOrDefault(d => d.Id == oldReservationst.Id);
                Reservations.CheckInDate = newCheckInDate;
                Reservations.CheckOutdate = newCheckOutDate;
                Reservations.RoomId = newrooms;
                Reservations.ReservationsStatus = newReservationsStatus;
                Reservations.TypePayment = newTypePayment;
                Reservations.ClientsId = newclients;

                db.SaveChanges();
                result = "Сделано! Отдел " + Reservations.Id + " изменен";
            }
            return result;
        }
        //редактирование Rooms
        public static string EditRooms(Rooms oldRooms, string newNumber, int newFloor, string newType, int newCapfcity, string newStatus, string newPrice)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Rooms Rooms = db.rooms.FirstOrDefault(p => p.Id == oldRooms.Id);
                Rooms.Number = newNumber;
                Rooms.Floor = newFloor;
                Rooms.Type = newType;
                Rooms.Capfcity = newCapfcity;
                Rooms.Status = newStatus;
                Rooms.Price = newPrice;
                db.SaveChanges();
                result = "Сделано! Rooms " + Rooms.Number + " изменена";
            }
            return result;
        }
        //редактирование сотрудника
        public static string EditClients(Clients oldClients, string newFirstName, string newlastName, string newPhoneNumber, string newGender, string newPassport, DateTime newDateOfBrith)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check user is exist
                Clients Clients = db.clients.FirstOrDefault(p => p.Id == oldClients.Id);
                if (Clients != null)
                {
                    Clients.FirstName = newFirstName;
                    Clients.LastName = newlastName;
                    Clients.PhoneNumber = newPhoneNumber;
                    Clients.Gender = newGender;
                    Clients.Passport = newPassport;
                    Clients.DateOfBrith = newDateOfBrith;
                    db.SaveChanges();
                    result = "Сделано! Сотрудник " + Clients.FirstName + " изменен";
                }
            }
            return result;
        }

        //получение Clients по id Clients
        public static Clients GetClientsById(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Clients pos = db.clients.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //получение отдела по id отдела
        public static Rooms GetRoomsById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Rooms pos = db.rooms.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //получение всех пользователей по id позиции
        public static List<Reservations> GetAllUsersByPositionId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Reservations> users = (from Reservations in GetAllReservations() where Reservations.Id == id select Reservations).ToList();
                return users;
            }
        }
        //получение всех позиций по id отдела
        //public static List<Position> GetAllPositionsByDepartmentId(int id)
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        List<Position> positions = (from position in GetAllPositions() where position.DepartmentId == id select position).ToList();
        //        return positions;
        //    }
        //}
    }
}
