(function () {
    'use strict';

    angular
        .module('App')
        .factory('WorkLogService', WorkLogService);

    WorkLogService.$inject = ['$http'];

    function WorkLogService($http) {
        return {
            Read: Read
        }

        function Read(attendanceId) {
            return $http({
                method: 'POST',
                url: '/WorkLog/Read/' + attendanceId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();