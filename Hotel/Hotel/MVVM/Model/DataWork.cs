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
                    Clients NewClients = new Clients { FirstName = FirstName};
                    db.clients.Add(NewClients);
                    db.SaveChanges();
                    result = "сделано";
                }
                return result;
            }
        }

    }
}
