using BOLCarRent.ViewModels;
using DBCarRent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLCarRent.Users
{
    public class UsersService
    {
        //get all Users
        public IEnumerable<UsersViewModel> GetAllUsers()
        {
            IEnumerable<DBCarRent.User> users ;
            using (UsersRepository usersRepository = new UsersRepository())
            {
                users = usersRepository.GetAllUsers();
            }
            List<UsersViewModel> usersVM = new List<UsersViewModel>();
            foreach (DBCarRent.User user in users)
            {
                usersVM.Add(UserMapModelToViewModel(user));
            }
            return usersVM;
        }

        //get Users by id
        public UsersViewModel GetUserById(int id)
        {
            DBCarRent.User user = null;
            using (UsersRepository usersRepository = new UsersRepository())
            {
                user = usersRepository.GetUserById(id);
            }
            return UserMapModelToViewModel(user);
        }

        //add user
        public void InsertUser(UsersViewModel userVM)
        {
            DBCarRent.User user = UserMapViewModelToModel(userVM);
            using (UsersRepository userRepository = new UsersRepository())
            {
                userRepository.InsertUser(user);
            }
        }

        //register user
        public void RegisterNewUser(UsersViewModel userVM)
        {
            DBCarRent.User user = UserMapViewModelToModel(userVM);
            using (UsersRepository userRepository = new UsersRepository())
            {
                userRepository.RegisterUser(user);
            }
        }


        //update user
        public void UpdateUser(UsersViewModel userVM)
        {
            DBCarRent.User user = UserMapViewModelToModel(userVM);
            using (UsersRepository userRepository = new UsersRepository())
            {
                var email = user.Email;
                userRepository.UpdateUser(email, user);
            }
        }

        //delete user
        public void DeleteUser(string email)
        {

            using (UsersRepository userRepository = new UsersRepository())
            {
                userRepository.DeleteUser(email);
            }

        }

        //Authentication user
        public AuthViewModel Authentication(string email, string password)
        {
            AuthViewModel authVM = new AuthViewModel();
            using (UsersRepository userRepository = new UsersRepository())
            {
                User user = userRepository.AuthenticateUser(email, password);
                if (user != null)
                {
                    authVM.Token = Token(user.Email, user.IsAdmin);
                    authVM.Email = user.Email;
                    authVM.IsAdmin = user.IsAdmin;
                    return authVM;
                }
                else
                {
                    return null;
                }
            }
        }

        


        //get user status
        public string UserStatus(string email)
        {
            using (UsersRepository userRepository = new UsersRepository())
            {
               return userRepository.GetUsersStatus(email);
            }

        }

        public string Token(string email,string role)
        {
            var expires = DateTime.UtcNow.AddMinutes(10);
            string TokenData = email+"#"+role + "#" + expires;
            byte[] bString = Encoding.UTF8.GetBytes(TokenData);
            string Token = Convert.ToBase64String(bString);

            return Token;
        }








        //ViewModel To Model
        private DBCarRent.User UserMapViewModelToModel(UsersViewModel userVM)
        {
            DBCarRent.User user = new DBCarRent.User();

            user.UserName = userVM.UserName;
            user.Password = userVM.Password;
            user.FullName = userVM.FullName;
            user.Email = userVM.Email;
            user.Sex = userVM.Sex;
            user.Passport = userVM.Passport;
            user.IsAdmin = userVM.IsAdmin;

            return user;
        }

        //Model To ViewModel
        private UsersViewModel UserMapModelToViewModel(DBCarRent.User user)
        {
            UsersViewModel userVM = new UsersViewModel();

            userVM.UserName = user.UserName;
            userVM.Password = user.Password;
            userVM.FullName = user.FullName;
            userVM.Email = user.Email;
            userVM.Sex = user.Sex;
            userVM.Passport = user.Passport;
            userVM.IsAdmin = user.IsAdmin;

            return userVM;
        }

        private AuthViewModel AuthMapModelToViewModel(DBCarRent.User user)
        {
            AuthViewModel userVM = new AuthViewModel();

            userVM.Email = user.Email;
            userVM.IsAdmin = user.IsAdmin;

            return userVM;
        }
    }
}
