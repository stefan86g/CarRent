using BOLCarRent.Users;
using BOLCarRent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Web.Http;
using System.Web.Security;

namespace ApiCarRent.Controllers
{
    
    public class UsersController : ApiController
    {
        private UsersService usersService;

        public UsersController()
        {
            usersService = new UsersService();
        }


        //get all users
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpGet]
        public IEnumerable<UsersViewModel> GetAllUsers()
        {
            return usersService.GetAllUsers();

        }

        //add new user
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpPost]
        public void InsertUser(UsersViewModel userVM)
        {
            usersService.InsertUser(userVM);

        }

        //Register new user
        [HttpPost]
        public void RegisterUser(UsersViewModel userVM)
        {
            usersService.RegisterNewUser(userVM);

        }

        //delete user
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpPost]
        public void DeleteUserByEmail(string id)
        {
            usersService.DeleteUser(id);

        }


        //update users 
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpPost]
        public void UpdateUsers(UsersViewModel userVM)
        {
            usersService.UpdateUser(userVM);

        }

        //Authenticate user 
        [HttpPost]
        public AuthViewModel Login(UsersViewModel userVM)
        {
            string email = userVM.Email.ToString();
            string password = userVM.Password.ToString();
            return usersService.Authentication(email, password);
        }


        //Get User Role
        [HttpPost]
        public string GetUserStatus(string email)
        {
            return usersService.UserStatus(email);
        }


    }
}
