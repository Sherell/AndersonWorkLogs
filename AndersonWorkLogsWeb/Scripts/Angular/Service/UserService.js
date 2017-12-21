(function () {
    'use strict';

    angular
        .module('App')
        .factory('UserService', UserService);

    UserService.$inject = ['$http'];

    function UserService($http) {
        return {
            Read: Read
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/User/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();