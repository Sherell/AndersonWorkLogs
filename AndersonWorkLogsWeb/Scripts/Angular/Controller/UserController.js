//(function () {
//    'use strict';

//    angular
//        .module('App')
//        .controller('UserController', UserController);

//    UserController.$inject = ['$filter', '$window', 'EmployeeService', 'UserService'];

//    function UserController($filter, $window, EmployeeService, UserService) {
//        var vm = this;

//        vm.Employees = [];
//        vm.Users = [];

//        vm.GoToUpdatePage = GoToUpdatePage;
//        vm.Initialise = Initialise;

//        vm.UpdateEmployee = UpdateEmployee;

//        vm.Delete = Delete;

//        function GoToUpdatePage(userId) {
//            $window.location.href = '../User/Update/' + userId;
//        }

//        function Initialise() {
//            Read();
//            ReadEmployees();
//        }

//        function ReadEmployees() {
//            EmployeeService.Read()
//                .then(function (response) {
//                    vm.Employees = response.data;
//                })
//                .catch(function (data, status) {
//                    new PNotify({
//                        title: status,
//                        text: data,
//                        type: 'error',
//                        hide: true,
//                        addclass: "stack-bottomright"
//                    });

//                });
//        }

//        function Read() {
//            UserService.Read()
//                .then(function (response) {
//                    vm.Users = response.data;
//                })
//                .catch(function (data, status) {
//                    new PNotify({
//                        title: status,
//                        text: data,
//                        type: 'error',
//                        hide: true,
//                        addclass: "stack-bottomright"
//                    });
//                });
//        }

//        function UpdateEmployee(user) {
//            user.Employee = $filter('filter')(vm.Employees, { EmployeeId: user.EmployeeId })[0];
//        }

//        function Delete(userId) {
//            UserService.Delete(userId)
//                .then(function (response) {
//                    Read();
//                })
//                .catch(function (data, status) {
//                    new PNotify({
//                        title: status,
//                        text: data,
//                        type: 'error',
//                        hide: true,
//                        addclass: "stack-bottomright"
//                    });
//                });
//        }

//    }
//})();