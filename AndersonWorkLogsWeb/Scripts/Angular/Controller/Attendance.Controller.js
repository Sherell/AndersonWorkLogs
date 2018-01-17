(function () {
    'use strict';

    angular
        .module('App')
        .controller('AttendanceController', AttendanceController);

    AttendanceController.$inject = ['$filter', '$window', 'AttendanceService','UserService', 'EmployeeService'];

    function AttendanceController($filter, $window, AttendanceService, UserService, EmployeeService) {
        var vm = this;
        
        vm.Attendances = [];
        vm.Users = [];
        vm.Employees = [];
        
        vm.Initialise = Initialise;
        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Approve = Approve;
        vm.Delete = Delete;

        function GoToUpdatePage(attendanceId) {
            $window.location.href = '../Attendance/Update/' + attendanceId;
        }

        function Initialise() {
            Read();
        }

        function Read() {
            AttendanceService.Read()
                .then(function (response) {
                    vm.Attendances = response.data;
                    ReadUsers();
                    ReadEmployees();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function ReadUsers() {
            UserService.Read()
                .then(function (response) {
                    vm.Users = response.data;
                    UpdateUser();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function UpdateUser() {
            angular.forEach(vm.Attendances, function (attendance) {
                attendance.User = $filter('filter')(vm.Users, { UserId: attendance.CreatedBy })[0];
            });
        }

        function ReadEmployees() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                    UpdateEmployee();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function UpdateEmployee() {
            angular.forEach(vm.Attendances, function (attendance) {
                attendance.Employee = $filter('filter')(vm.Employees, { EmployeeId: attendance.User.EmployeeId })[0];
                attendance.Employee.FullName = attendance.Employee.LastName + ", " + attendance.Employee.FirstName + " " + attendance.Employee.MiddleName;
                attendance.Manager = $filter('filter')(vm.Employees, { EmployeeId: attendance.ManagerEmployeeId })[0];
                attendance.Manager.FullName = attendance.Manager.LastName + ", " + attendance.Manager.FirstName + " " + attendance.Manager.MiddleName;
            });
        }

        function Approve(id) {
            AttendanceService.Approve(id)
                .then(function (response) {
                    if (response.data === true) {
                        Read();
                    }
                })
                .catch(function (data, status) {
                });
        }

        function Delete(attendanceId) {
            AttendanceService.Delete(attendanceId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }
    }
})();