(function () {
    'use strict';

    angular
        .module('App')
        .controller('WorkLogController', WorkLogController);

    WorkLogController.$inject = ['$filter', '$window', 'WorkLogService'];

    function WorkLogController($filter, $window, WorkLogService) {
        var vm = this;

        vm.AttendanceId;

        vm.WorkLog = {
            WorkDone: '',
        };

        vm.WorkLogs = [];
        vm.DeletedWorkLogs = [];

        vm.Create = Create;

        vm.Initialise = Initialise;

        vm.Delete = Delete;

        function Create() {
            vm.WorkLogs.push(vm.WorkLog);
        }

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

        function Delete(workLog) {
            vm.DeletedWorkLogs.push(workLog);
            vm.WorkLogs.remove(workLog);
        }


    }
})();