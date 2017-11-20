//(function () {
//    'use strict';

//    angular
//        .module('App')
//        .factory('AttendanceService', AttendanceService);

//    AttendanceService.$inject = ['$http'];

//    function AttendanceService($http) {
//        return {
//            Read: Read,
//            Delete: Delete
//        }

//        function Read() {
//            return $http({
//                method: 'POST',
//                url: '/Attendance/Read',
//                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
//            });
//        }

//        function Delete(attendanceId) {
//            return $http({
//                method: 'DELETE',
//                url: '/Attendance/Delete/' + attendanceId,
//                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
//            });
//        }
//    }
//})();