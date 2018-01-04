(function () {
    var app = angular
        .module("carRent", ['ngRoute']);
        app.config(['$routeProvider', function ($routeProvider) {
       
        $routeProvider
            .when('/default', {
               templateUrl: '/views/default.html'
            })
            .when('/manager', {
                controller: 'manageController',
                templateUrl: '/views/Pages/Cars.html',
                controllerAs: 'vm'

            })
            .when('/users', {
                controller: 'usersManageController',
                templateUrl: '/views/Pages/Users.html',
                controllerAs: 'um'

            })
            .when('/login', {
                controller: 'usersManageController',
                templateUrl: '/views/Pages/LoginPage.html',
                controllerAs: 'um'
            })
            .when('/Registr', {
                controller: 'usersManageController',
                templateUrl: '/views/Pages/RegistrationPage.html',
                controllerAs: 'um'
            })
            .when('/rent', {
                controller: 'manageController',
                templateUrl: '/views/Pages/OrderPage.html',
                controllerAs: 'vm'
            })
            .when('/contact', {
                templateUrl: '/views/Pages/ContactPage.html',
                
            })
            .when('/logout', {
                templateUrl: '/views/default.html'
            })

            .otherwise({
                redirectTo: 'default'
                });

    }]);

        //controler for navbar role authentication
        app.controller('appController', ['$scope', '$rootScope', '$window', function ($scope, $rootScope, $window) {

            //check if loged user is admin
            $scope.isAdmin = function () {
                if ($rootScope.logedUser != null) {
                    return $rootScope.logedUser.role == "Admin";
                }
                return false;
            };

            //check if there no user to show logout icon
            $scope.isAuth = function () {
                if ($rootScope.logedUser == null) {
                    return true;
                }
                return false;
            };

            //clear local storage
            $scope.logOutUser = function () {
                $window.localStorage.clear();
                $window.location.reload();

            }

            // get user from local storage
            getUserFromLocalStorage = function () {
                var logedUser = localStorage.getItem('logedUser');
                if (logedUser != null) {
                    $rootScope.logedUser = JSON.parse(logedUser);
                   
                }
            }
            getUserFromLocalStorage();


        }]);

}());
