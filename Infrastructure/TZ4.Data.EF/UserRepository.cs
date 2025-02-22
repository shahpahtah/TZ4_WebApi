using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using WebApi.DbModel;
namespace TZ4.Data.EF
{
    public class UserRepository : IUserRepository
    {
        DbContextUser _dbcontext;
        public UserRepository(DbContextUser context)
        {
            _dbcontext = context;
        }
        public User Delete(User user)
        {
            UserDto model = _dbcontext.Users.FirstOrDefault(i => i.Id == user.Id);
            _dbcontext.Remove(model);
            _dbcontext.SaveChanges();
            return user;
        }

        public User[] GetAll()
        {
            return _dbcontext.Users.Select(i => User.Mapper.Map(i)).ToArray();
        }

        public User GetById(int id)
        {
            return User.Mapper.Map(_dbcontext.Users.Single(i => i.Id == id));
        }

        public User Update(User user,int id)
        {
            UserDto upd = _dbcontext.Users.Single(i => i.Id == id);
            upd.FirstName = user.FirstName;
            upd.LastName = user.LastName;
            upd.Email = user.Email;
            upd.DateOfBirth = user.DateOfBirth;
            _dbcontext.SaveChanges();
            return user;
        }
        public User Add(User user)
        {
            
             var uer = _dbcontext.Users.Add(User.Mapper.Map(user));
            _dbcontext.SaveChanges();
            if (uer != null)
            {
                return user;
            }
            else
            {
                return null;
            }
         
        }

       
    }
}
