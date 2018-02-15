(function () {
    'use strict';

    angular.module('app').factory('houseService', HouseService);

    HouseService.$inject = ['$http'];

    function HouseService($http) {

        var service = this;

        service.create = function (data) {
            return $http.post('/api/houses', data);
        };

        service.getAll = function () {
            return $http.get('/api/houses');
        };

        service.get = function (houseId) {
            return $http.get('/api/houses/' + houseId);
        }

        service.getExpenses = function (houseId) {
            return $http.get('/api/houses/' + houseId + '/expenses');
        }

        return service;
    }

}());