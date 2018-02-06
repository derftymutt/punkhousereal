(function () {
    'use strict';

    angular.module('app').factory('houseService', HouseService);

    HouseService.$inject = ['$http'];

    function HouseService($http) {

        var service = this;

        service.create = function (data) {
            return $http.post('/api/house', data);
        };

        service.get = function () {
            return $http.get('/api/house');
        };

        return service;
    }

}());