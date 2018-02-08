(function () {
    'use strict';

    angular.module('app').factory('houseService', HouseService);

    HouseService.$inject = ['$http'];

    function HouseService($http) {

        var service = this;

        service.create = function (data) {
            return $http.post('/api/house', data);
        };

        service.getAll = function () {
            return $http.get('/api/house');
        };

        service.get = function (houseId) {
            return $http.get('/api/house/' + houseId);
        }

        return service;
    }

}());