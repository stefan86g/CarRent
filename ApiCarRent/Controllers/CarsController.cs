using BOLCarRent.Car;
using BOLCarRent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Threading;
using System.Web.Http;

namespace ApiCarRent.Controllers
{

    
    public class CarsController : ApiController
    {
        private CarsService carsService;

        public CarsController()
        {
            carsService = new CarsService();
        }

        // get all cars
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetAllCars()
        {
            return carsService.GetAllCars();
        }

        // add new car
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpPost]
        public void Insert(CarViewModel carVM)
        {
            carsService.Insert(carVM);

        }

        // delete car
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpPost]
        public void DeleteCarByNumber(string id)
        {
           carsService.Delete(id);

        }


        // update car 
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpPost]
        public void UpdateCarinfo(CarViewModel carVM)
        {
            carsService.Update(carVM);

        }

        // rent car
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpPost]
        public void RentCarByNumber(string id)
        {
            carsService.Rent(id);

        }

        // get all Available cars
        [Authentication]
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        [HttpGet]
        public IEnumerable<CarViewModel> GetAvailableCars()
        {
            return carsService.GetAvailableCars();

        }
    }
}
