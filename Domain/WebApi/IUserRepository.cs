using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public interface IUserRepository
    {
        public User[] GetAll();
        public User GetById(int id);
        public User Delete(User user);
        public User Update(User user,int id);
        public User Add(User user);
    }
}
