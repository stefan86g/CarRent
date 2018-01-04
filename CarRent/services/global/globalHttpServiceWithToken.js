//(function () {

//    var globalHttpServiceWithToken = function ($http, $rootScope) {

//        factory = {};

//        //get all cars from db
//        factory.get = function (url) {
//            var token = $rootScope.logedUser.token;
//            if (token == null || token == "") {
//                alert("token fails");
//                // go to login
//            }
//            return $http.get(url, {
//                headers: {
//                    "Content-Type": "application/json",
//                    "Accept": "application/json",
//                    "Authorization": token
//                }
//            });
//        };

//        return factory;
//    }

//    angular.module('carRent')
//        .factory('globalHttpServiceWithToken', globalHttpServiceWithToken);

//}());

