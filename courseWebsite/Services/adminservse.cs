using courseWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace courseWebsite.Services
{
    public interface Iadminservse
    {
        bool login(string email, string password);
        bool changepassword(string email, string password);
        bool forgotpassword(string email);


    }
    public class adminservse : Iadminservse
    {
        public coursedbcontect context { get; set; }
        adminservse()
        {
            context = new coursedbcontect();
        }
        
        public bool login(string email, string password)
        {
            return context.admins.Where(n => n.email == email && n.password == password).Any();
        }

        public bool changepassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool forgotpassword(string email)
        {
            throw new NotImplementedException();
        }

       
    }
}