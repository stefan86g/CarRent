(function () {
    angular.module('carRent').controller("manageController", function ($scope, $http, carsService) {

        var vm = this;

        vm.cars = [];
       


        //get all cars
        vm.getCars = function () {

            carsService.getAllCars().then(
                // call on suscees
                function (data) {
                    console.log('cars received');
                    vm.cars = data;
                    console.log(vm.cars);
                },// call on error
                function (status) {
                    alert('cant get cars');
                    console.log(status);
                });

        };

        //get all available cars
        vm.getAvailableCars = function () {

            carsService.GetAllAvailableCars().then(
                // call on suscees
                function (data) {
                    console.log('cars received');
                    vm.cars = data;
                    console.log(vm.cars);
                },// call on error
                function (status) {
                    alert('cant get cars');
                    console.log(status);
                });

        };

        //add  car to list
        vm.addCar = function (photo, model, pricePerDay, costOfDayOverdue, availability, year, gearBox, mileage, carNumber, branch) {
            carsService.addCar(photo, model, pricePerDay, costOfDayOverdue, availability, year, gearBox, mileage, carNumber, branch).then(
                // call on suscees 
                function () {
                    console.log('ok add car');
                    vm.getCars();
                },// call on error
                function (status) {
                    alert('cant add car');
                    console.log(status);
                });

        };


        //delete car
        vm.deleteCar = function (id) {

            carsService.Remove(id).then(
                // call on suscees
                function () {
                    console.log('car deleted');
                    vm.getCars();
                },// call on error
                function (status) {
                    alert('cant delete car');
                    console.log(status);
                });

        };

        //Update car
        vm.updateCar = function (photo, model, pricePerDay, costOfDayOverdue, availability, year, gearBox, mileage, carNumber, branch) {
            carsService.Update(photo, model, pricePerDay, costOfDayOverdue, availability, year, gearBox, mileage, carNumber, branch).then(
                // call on suscees 
                function () {
                    console.log('car updated');
                    vm.getCars();
                },// call on error
                function (status) {
                    alert('cant update car');
                    console.log(status);
                });

        };

        //Rent car
        vm.rentCar = function (carNumber) {
            carsService.RentCar(carNumber).then(
                // call on suscees 
                function () {
                    console.log('Rent Success');
                    vm.getAvailableCars();
                },// call on error
                function (status) {
                    alert('Rent Error');
                    console.log(status);
                });

        };

        //get parameters from table and transfer them to edit form
        $scope.getTable = function (photo, model, pricePerDay, costOfDayOverdue, availability, year, gearBox, mileage, carNumber, branch) {
            $scope.photo = photo;
            $scope.model = model;
            $scope.pricePerDay = pricePerDay
            $scope.costOfDayOverdue = costOfDayOverdue;
            $scope.availability = availability;
            $scope.year = year;
            $scope.gearBox = gearBox;
            $scope.mileage = mileage;
            $scope.carNumber = carNumber;
            $scope.branch = branch;
        }

        //get parameters from table and transfer them to Order form
        $scope.getOrder = function (pricePerDay, costOfDayOverdue, branch, carNumber) {
            
            $scope.pricePerDay = pricePerDay;
            $scope.costOfDayOverdue = costOfDayOverdue;
            $scope.branch = branch;
            $scope.carNumber = carNumber;
        }

        //Calculate total days rent 
        vm.calcDays = function calculateDate(startDate, endDate) {
            var diff = 0;
            var days = 1000 * 60 * 60 * 24;
            diff = endDate - startDate;
            var sum = Math.floor(diff / days);
            //var total = sum * pricePerDay;
            //var sss = 'days:'+sum + 'price:' +total;
            return sum;
        }

        //Calculate total price
        vm.calcTotalPrice = function calculateDate(days, pricePerDay) {

             var price = days * pricePerDay;
             return price;
        }
        
    });
}());