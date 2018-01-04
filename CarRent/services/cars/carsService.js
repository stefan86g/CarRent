(function () {

    var carsService = function ($http, $rootScope, $location) {

        factory = {};

        //get all cars from db
        factory.getAllCars = function () {
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.get('http://localhost:52440/api/cars/getAllCars', {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(
                function (results) {
                    return results.data;
                });
        };

        //get all available cars from db
        factory.GetAllAvailableCars = function () {
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.get('http://localhost:52440/api/cars/GetAvailableCars', {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(
                function (results) {
                    return results.data;
                });
        };

        //add car to db
        factory.addCar = function (photo, model, pricePerDay, costOfDayOverdue, availability, year, gearBox, mileage, carNumber, branch) {
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            var newCar = { Photo: photo, Model: model, PricePerDay: pricePerDay, CostOfDayOverdue: costOfDayOverdue, Availability: availability, Year: year, GearBox: gearBox, Mileage: mileage, CarNumber: carNumber, Branch: branch };
            return $http.post('http://localhost:52440/api/cars/insert', newCar, {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(function (response) {
                console.log("ok" + response.status);
                factory.getAllCars();
            }, function (response) {
                console.log("error" + response.status);
            });
        }


        //delete car
        factory.Remove = function (id) {
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.post('http://localhost:52440/api/cars/DeleteCarByNumber/' + id, {}, {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(function (response) {
                console.log("ok" + response.status);
                factory.getAllCars();
            },
                function (response) {
                    console.log("error" + response.status);
                });
        }

        //rent car
        factory.RentCar = function (id) {
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.post('http://localhost:52440/api/cars/RentCarByNumber/' + id, {}, {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(function (response) {
                console.log("ok" + response.status);
                alert('Rent Success');
                factory.GetAllAvailableCars();
            },
                function (response) {
                    console.log("error" + response.status);
                });
        }

        //update existing car
        factory.Update = function (photo, model, pricePerDay, costOfDayOverdue, availability, year, gearBox, mileage, carNumber, branch) {
            var updateCar = { Photo: photo, Model: model, PricePerDay: pricePerDay, CostOfDayOverdue: costOfDayOverdue, Availability: availability, Year: year, GearBox: gearBox, Mileage: mileage, CarNumber: carNumber, Branch: branch };
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.post('http://localhost:52440/api/cars/UpdateCarinfo', updateCar, {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(function (response) {
                console.log("ok" + response.status);
                factory.getAllCars();
            }, function (response) {
                console.log("error" + response.status);
            });
        }



        return factory;
    }

    angular.module('carRent')
        .factory('carsService', carsService);

}());

