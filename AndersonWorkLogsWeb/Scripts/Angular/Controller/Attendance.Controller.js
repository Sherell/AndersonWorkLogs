(function () {
    'use strict';

    angular
        .module('App')
        .controller('AttendanceController', AttendanceController);

    AttendanceController.$inject = ['$filter', '$window', 'AttendanceService','UserService'];

    function AttendanceController($filter, $window, AttendanceService, UserService) {
        var vm = this;

         
        vm.AttendanceId;

        vm.Users = [];
        vm.Attendances = [];


        vm.GoToUpdatePage = GoToUpdatePage;
        vm.UpdateUser = UpdateUser;
        vm.Initialise = Initialise;

        vm.Delete = Delete;

        function GoToUpdatePage(attendanceId) {
            $window.location.href = '../Attendance/Update/' + attendanceId;
        }

        function Initialise() {
            Read();
            //ReadUsers();
        }

        function Read() {
            AttendanceService.Read()
                .then(function (response) {
                    vm.Attendances = response.data;
                    ReadUsers();
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

        function UpdateUser(attendance) {
            angular.forEach(vm.Attendances, function (attendances) {
                attendances.Users = $filter('filter')(vm.Users, { UserId: attendances.UserId })[0];
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