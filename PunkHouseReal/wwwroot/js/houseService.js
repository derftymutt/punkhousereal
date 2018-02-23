(function () {
    'use strict';

    angular.module('app').factory('houseService', HouseService);

    HouseService.$inject = ['$http'];

    function HouseService($http) {

        var service = this;

        service.getAll = function () {
            return $http.get('/api/houses');
        };

        service.getById = function (houseId) {
            return $http.get('/api/houses/' + houseId);
        }

        service.getExpenses = function (houseId) {
            return $http.get('/api/houses/' + houseId + '/expenses');
        }

        service.create = function (data) {
            return $http.post('/api/houses', data);
        };

        return service;
    }

}());