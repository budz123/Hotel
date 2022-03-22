using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.MVVM.Model.Data;

namespace Hotel.MVVM.Model
{
    public  class DataWork
    {
        public string CreateClients(string FirstName, string LastName,DateTime DateOfBrith, string Gender, string PhoneNumber,string Passport)
        {
            string result = "Уже существует";
            using(ApplicationContext db = new ApplicationContext())
            {
                bool CheckIsExits = db.clients.Any(el => el.FirstName == FirstName);
                if (CheckIsExits)
                {
                    Clients NewClients = new Clients { FirstName = FirstName, LastName = LastName , DateOfBrith = DateOfBrith, Gender= Gender, PhoneNumber = PhoneNumber,Passport =Passport};
                    db.clients.Add(NewClients);
                    db.SaveChanges();
                    result = "сделано";
                }
                return result;
            }
        }
        public string deleteClients(Clients clients)
        {
            string result = "нету такого";
           using(ApplicationContext db = new ApplicationContext())
            {
                db.clients.Remove(clients);
                db.SaveChanges();
                result = "delete";
            }
            return result;
        }
        public string EditClients(Clients Oldclients, string FirstName, string LastName, DateTime DateOfBrith, string Gender, string PhoneNumber, string Passport)
        {
            string result = "нету такого";
            using (ApplicationContext db = new ApplicationContext())
            {
                Clients Newclients = db.clients.FirstOrDefault(d => d.Id == Oldclients.Id);
                Newclients.FirstName = FirstName; 
                Newclients.LastName = LastName;
                Newclients.DateOfBrith = DateOfBrith;
                Newclients.Gender = Gender;
                Newclients.PhoneNumber = PhoneNumber;
                Newclients.Passport = Passport;
                db.SaveChanges();
                result = "Edit";
            }
            return result;
        }
    }
}
