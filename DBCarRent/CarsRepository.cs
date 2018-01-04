using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCarRent
{
    public class CarsRepository : IDisposable
    {
        private DataCarRentEntities1 context;
        private DbSet<Car> cars;

        public CarsRepository()
        {
            context = new DataCarRentEntities1();
            cars = context.Cars;
        }

        //Get Car By Id
        public Car GetCarById(int id)
        {
            return cars.Find(id);
        }

        //Get All Cars
        public IEnumerable<Car> GetAllCars()
        {
            return cars.ToList();
        }

        //Get All Available Cars for users only
        public IEnumerable<Car> GetAllAvailableCars()
        {
            string Available = "available";
            return cars.Where(c => c.Availability == Available).ToList();
        }

        //Get Cars By Model
        public IEnumerable<Car> GetCarsByModel(string model)
        {
            return cars.Where(c => c.Model == model);
        }

        //Get Car By Number
        public Car GetCarByNumber(string Number)
        {
            return cars.FirstOrDefault(c => c.CarNumber == Number);
        }

        //Add car to database
        public void Insert(Car car)
        {
            cars.Add(car);

            context.SaveChanges();
        }

        //Update existed car
        public void Update(string carNum, Car carForUpdate)
        {
            Car car = context.Cars.FirstOrDefault(c => c.CarNumber == carNum);
            if (car != null)
            {
                car.Photo = carForUpdate.Photo;
                car.Model = carForUpdate.Model;
                car.PricePerDay = carForUpdate.PricePerDay;
                car.CostOfDayOverdue = carForUpdate.CostOfDayOverdue;
                car.Availability = carForUpdate.Availability;
                car.Year = carForUpdate.Year;
                car.Mileage = carForUpdate.Mileage;
                car.CarNumber = carForUpdate.CarNumber;
                car.Branch = carForUpdate.Branch;
                context.SaveChanges();
            }
        }

        // Rent Car (for users)
        public void RentCar(string carNum)
        {
            Car car = context.Cars.FirstOrDefault(c => c.CarNumber == carNum);
            if (car != null)
            {

                car.Availability = "Not Available";

                context.SaveChanges();
            }

        }

        // Delete car
        public void Delete(string num)
        {
            Car car = context.Cars.FirstOrDefault(c => c.CarNumber == num);
            context.Cars.Remove(car);
            context.SaveChanges();
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
