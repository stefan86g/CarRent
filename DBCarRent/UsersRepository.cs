using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCarRent
{
    public class UsersRepository : IDisposable
    {
        private DataCarRentEntities1 context;
        private DbSet<User> users;

        public UsersRepository()
        {
            context = new DataCarRentEntities1();
            users = context.Users;
        }

        // Get User By Id
        public User GetUserById(int id)
        {
            return users.Find(id);
        }

        // Get All Users
        public IEnumerable<User> GetAllUsers()
        {
            return users.ToList();
        }

        // Get Users By Email
        public IEnumerable<User> GetUsersByEmail(string Email)
        {
            return users.Where(c => c.Email == Email);
        }

        


        // Insert User
        public void InsertUser(User user)
        {
            users.Add(user);

            context.SaveChanges();
        }

        // Register User
        public void RegisterUser(User user)
        {
            users.Add(user);

            context.SaveChanges();
        }

        // Update User
        public void UpdateUser(string Email, User userForUpdate)
        {
            User user = context.Users.FirstOrDefault(c => c.Email == Email);
            if (user != null)
            {
                user.UserName = userForUpdate.UserName;
                user.Password = userForUpdate.Password;
                user.FullName = userForUpdate.FullName;
                user.Email = userForUpdate.Email;
                user.Sex = userForUpdate.Sex;
                user.Passport = userForUpdate.Passport;
                user.IsAdmin = userForUpdate.IsAdmin;

                context.SaveChanges();
            }
        }


        // Delete User
        public void DeleteUser(string Email)
        {
            User user = context.Users.FirstOrDefault(c => c.Email == Email);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        

        //Authenticate user
        public User AuthenticateUser(string email, string password)
        {
            User user = users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            return user;
        }

        // Get Users status
        public string GetUsersStatus(string email)
        {
            User user = context.Users.FirstOrDefault(c => c.Email == email);
            if(user != null)
            {
                return user.IsAdmin;
            }
            else
            {
                throw new Exception("Can't get user status , user is not found");
            }
        }




        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

    }
}
