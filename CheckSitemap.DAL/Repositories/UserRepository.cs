using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckSitemap.DAL.Entities;
using CheckSitemap.DAL.Interfaces;
using CheckSitemap.DAL.EF;
using System.Data.Entity;

namespace CheckSitemap.DAL.Repositories
{
    public class UserRepository:IRepository<User>
    {
        private RequestContext context;

        public UserRepository(RequestContext cont)
        {
            context = cont;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public void Create(User user)
        {
            context.Users.Add(user);
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return context.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
                context.Users.Remove(user);
        }
    }
}
