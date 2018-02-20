(function () {
    'use strict';

    angular.module('app').factory('houseMateService', HouseMateService);

    HouseMateService.$inject = ['$http'];

    function HouseMateService($http) {

        var service = this;

        service.getHouseMate = function () {
            return $http.get('/api/housemates');
        }

        service.update = function (data) {
            return $http.patch('/api/housemates', data);
        };

        return service;
    }

}());