(function () {
    'use strict';

    angular
        .module('App')
        .controller('AttendanceController', AttendanceController);

    AttendanceController.$inject = ['$filter', '$window', 'AttendanceService'];

    function AttendanceController($filter, $window, AttendanceService) {
        var vm = this;

        vm.AttendanceId;

        vm.Attendances = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

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