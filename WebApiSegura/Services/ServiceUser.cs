using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSegura.Models;

namespace WebApiSegura.Services
{
    public class ServiceUser
    {
        private readonly Entities _entities;

        public ServiceUser()
        {
            _entities = new Entities();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }

        public User get_UserByLogin(string username, string password)
        {
            return _entities.users.Where(c => c.username == username && c.passwoord == password && c.active == true).Select
               (c => new User
               {
                   Id = c.id,
                   UserName = c.username,
                   Password = c.passwoord,
                   Email = c.email,
                   Rol = c.rol,
                   Active = c.active.Value

               }).First();
        }
    }
}