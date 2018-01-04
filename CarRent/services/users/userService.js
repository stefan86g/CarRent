(function () {

    var userService = function ($http,$rootScope) {

        factory = {};
        
        //get all users from db
        factory.getAllUsers = function () {
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.get('http://localhost:52440/api/users/getAllUsers', {
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

         //add user to db
        factory.addUser = function (username, password, fullname, email, sex, passport,isadmin) {
            var newusr = { UserName: username, Password: password, FullName: fullname, Email: email, Sex: sex, Passport: passport, IsAdmin: isadmin };
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.post('http://localhost:52440/api/users/InsertUser', newusr, {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(function (response) {
                console.log("ok" + response.status);
                factory.getAllUsers();
            }, function (response) {
                console.log("error" + response.status);
            });
        }
        

        //delete user
        factory.RemoveUser = function (id) {
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.post('http://localhost:52440/api/users/DeleteUserByEmail/' + id, {}, {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(function (response) {
                console.log("ok" + response.status);
                factory.getAllUsers();
            },
                function (response) {
                    console.log("error" + response.status);
                });
        }

        //update existing user
        factory.UpdateUser = function (username, password, fullname, email, sex, passport, isadmin) {
            var updateUsr = { UserName: username, Password: password, FullName: fullname, Email: email, Sex: sex, Passport: passport, IsAdmin: isadmin };
            var token = $rootScope.logedUser.token;
            if (token == null || token == "") {
                alert("token fails");
                $location.path('../../views/Pages/LoginPage.html');
            }
            return $http.post('http://localhost:52440/api/users/UpdateUsers', updateUsr, {
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json",
                    "Authorization": token
                }
            }).then(function (response) {
                console.log("ok" + response.status);
                factory.getAllUsers();
            }, function (response) {
                console.log("error" + response.status);
            });
        }

        //login user
        factory.Login = function (email, password) {

            var full = { Email: email, Password: password };
            return $http.post('http://localhost:52440/api/users/Login', full, {
            }).then(function (response) {
                console.log("login ok" + response.data);
                var logedUser = { email: response.data.Email, role: response.data.IsAdmin, token: response.data.Token };
                $rootScope.logedUser = logedUser;
                localStorage.setItem('logedUser', JSON.stringify(logedUser));
                return true;

            }, function (response) {
                console.log("login fail " + response.status);
                return false;
            });
        };

        //register
        factory.Registration = function (username, password, fullname, email, sex, passport) {
            var regusr = { UserName: username, Password: password, FullName: fullname, Email: email, Sex: sex, Passport: passport, IsAdmin: 'User' };
            return $http.post('http://localhost:52440/api/users/RegisterUser', regusr).then(function (response) {
                console.log("ok" + response.status);
                alert('Registration Success');
            }, function (response) {
                console.log("error" + response.status);
            });
        }
        
      
        return factory;
    }

    angular.module('carRent')
        .factory('userService', userService);

}());

