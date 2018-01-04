(function () {
    angular.module('carRent').controller("usersManageController", function ($scope, $http, $location, userService) {

        var um = this;
        
        um.users = [];
        

        //get all users
        um.getUsers = function () {
            
           userService.getAllUsers().then(
                // call on suscees
                function (data) {
                    console.log('users received');
                    um.users = data;
                    console.log(um.users);
                },// call on error
                function (status) {
                    alert('cant get users');
                    console.log(status);
                });

        };


        //add  user to list
        um.addNewUser = function (username, password, fullname, email, sex, passport, isadmin) {
            userService.addUser(username, password, fullname, email, sex, passport, isadmin).then(
               
                // call on suscees 
                function () {
                    console.log('ok add user');
                    um.getUsers();
                },// call on error
                function (status) {
                    alert('cant add user');
                    console.log(status);
                });

        };

        //register user
        um.registerUser = function (username, password, fullname, email, sex, passport) {
            userService.Registration(username, password, fullname, email, sex, passport).then(
                // call on suscees 
                function () {
                    console.log('Registration Success');
                    $location.path('../../views/Pages/LoginPage.html');
                },// call on error
                function (status) {
                    alert('Registration Failed ');
                    console.log(status);
                });

        };


        //delete user
        um.deleteUser = function (id) {

            userService.RemoveUser(id).then(
                // call on suscees
                function () {
                    console.log('user deleted');
                    um.getUsers();
                },// call on error
                function (status) {
                    alert('cant delete user');
                    console.log(status);
                });

        };




        //Update user
        um.updateUser = function (username, password, fullname, email, sex, passport, isadmin) {
            userService.UpdateUser(username, password, fullname, email, sex, passport, isadmin).then(
                // call on suscees 
                function () {
                    console.log('user updated');
                    um.getUsers();
                },// call on error
                function (status) {
                    alert('cant update user');
                    console.log(status);
                });
            
        };

        // login
        um.login = function (email, password) {
            
            userService.Login(email, password).then(
                // call on suscees
                function (result) {
                    if (result === true) {
                        console.log('login ok');
                      
                       
                        $location.path('../../views/default.html');
                        return true;
                    }
                    
                },// call on error
                function (status) {
                    alert('login error');
                    console.log(status);
                });

        };

        
        // Get parameters from table to edit form
        $scope.getUserparam = function (userName, password, fullname, email, sex, passport, isadmin) {

            $scope.userName = userName;
            $scope.password = password;
            $scope.fullname = fullname;
            $scope.email = email;
            $scope.sex = sex;
            $scope.passport = passport;
            $scope.isadmin = isadmin;
        }
        
    });
}());