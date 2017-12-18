using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIP.Models
{
    public class FirstPageModel
    {
       
        private Dip_2Entities1 _db;

        public FirstPageModel()
        {
            _db = new Dip_2Entities1();
        }

        public IQueryable<Persons> GetPerson()
        {
            return _db.Persons;
        }
        public Persons GetUser(String email)
        {
            return _db.Persons.SingleOrDefault(it => it.Email == email);

        }
        public void AddPerson(string FirstName, string LastName, string Email, string Company, string Password)
        {
            Persons newUser = new Persons();

            newUser.FirstName = FirstName;
            newUser.LastName = LastName;
            newUser.Email = Email;
            newUser.Company = Company;
            newUser.Password = Password;


            _db.Persons.Add(newUser);
        }
        public void Save(Persons obj)
        {
            Persons oldUser = GetUser(obj.Email);
            oldUser.Password = obj.Password;
            _db.SaveChanges();


        }

    }
}