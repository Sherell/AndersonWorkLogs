(function () {
    'use strict';

    angular
        .module('App')
        .controller('WorkLogController', WorkLogController);

    WorkLogController.$inject = ['$filter', '$window', 'WorkLogService'];

    function WorkLogController($filter, $window, WorkLogService) {
        var vm = this;

        vm.AttendanceId;

        vm.WorkLogs = [];

        vm.Initialise = Initialise;

        function Initialise(attendanceId) {
            vm.AttendanceId = attendanceId
            Read();
        }

        function Read() {
            WorkLogService.Read(vm.AttendanceId)
                .then(function (response) {
                    vm.WorkLogs = response.data;
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