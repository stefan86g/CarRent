using BOLCarRent.ViewModels;
using DBCarRent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLCarRent.Car
{
    public class CarsService
    {
        //get all cars
        public IEnumerable<CarViewModel> GetAllCars()
        {
            IEnumerable<DBCarRent.Car> cars;
            using (CarsRepository carsRepository = new CarsRepository())
            {
                 cars = carsRepository.GetAllCars();
            }
            List<CarViewModel> carsVM = new List<CarViewModel>();
            foreach(DBCarRent.Car car in cars)
            {
                carsVM.Add(MapModelToViewModel(car));
            }
            return carsVM;
        }

        //get all available cars
        public IEnumerable<CarViewModel> GetAvailableCars()
        {
            IEnumerable<DBCarRent.Car> cars;
            using (CarsRepository carsRepository = new CarsRepository())
            {
                cars = carsRepository.GetAllAvailableCars();
            }
            List<CarViewModel> carsVM = new List<CarViewModel>();
            foreach (DBCarRent.Car car in cars)
            {
                carsVM.Add(MapModelToViewModel(car));
            }
            return carsVM;
        }

        //get car by id
        public CarViewModel GetById(int id)
        {
            DBCarRent.Car car = null;
            using (CarsRepository carsRepository = new CarsRepository())
            {
                car = carsRepository.GetCarById(id);
            }
            return MapModelToViewModel(car);
        }

        //add car
        public void Insert(CarViewModel carVM)
        {
            DBCarRent.Car car = MapViewModelToModel(carVM);
            using (CarsRepository carsRepository = new CarsRepository())
            {
                carsRepository.Insert(car);
            }
        }


        //update car
        public void Update(CarViewModel carVM)
        {
            DBCarRent.Car car = MapViewModelToModel(carVM);
            using (CarsRepository carsRepository = new CarsRepository())
            {
                var carNumber = car.CarNumber;
                carsRepository.Update(carNumber, car);
            }
        }

        //delete car
        public void Delete(string num)
        {
            
            using (CarsRepository carsRepository = new CarsRepository())
            {
                carsRepository.Delete(num);
            }

        }

        //rent car
        public void Rent(string carNumber)
        {
           
            using (CarsRepository carsRepository = new CarsRepository())
            {
                
                carsRepository.RentCar(carNumber);
            }
        }

        //ViewModel To Model
        private DBCarRent.Car  MapViewModelToModel(CarViewModel carVM)
        {
            DBCarRent.Car car = new DBCarRent.Car();
            
            car.Photo = carVM.Photo;
            car.Model = carVM.Model;
            car.PricePerDay = string.IsNullOrEmpty(carVM.PricePerDay) ? 0 : Int32.Parse(carVM.PricePerDay);
            car.CostOfDayOverdue = string.IsNullOrEmpty(carVM.CostOfDayOverdue) ? 0 : Int32.Parse(carVM.CostOfDayOverdue);
            car.Availability = carVM.Availability;
            car.Year = string.IsNullOrEmpty(carVM.Year) ? 0 :  Int32.Parse(carVM.Year);
            car.GearBox =  carVM.GearBox;
            car.Mileage = string.IsNullOrEmpty(carVM.Year) ? 0 : Int32.Parse(carVM.Mileage);
            car.CarNumber = carVM.CarNumber;
            car.Branch = carVM.Branch;
            
            return car;
        }

        //Model To ViewModel
        private CarViewModel MapModelToViewModel(DBCarRent.Car car)
        {
            CarViewModel carVM = new CarViewModel();
            
            carVM.Photo = car.Photo;
            carVM.Model = car.Model;
            carVM.PricePerDay = car.PricePerDay.ToString();
            carVM.CostOfDayOverdue = car.CostOfDayOverdue.ToString();
            carVM.Availability = car.Availability;
            carVM.Year = car.Year.ToString();
            carVM.GearBox = car.GearBox;
            carVM.Mileage = car.Mileage.ToString();
            carVM.CarNumber = car.CarNumber;
            carVM.Branch = car.Branch;

            return carVM;
        }
    }
}
