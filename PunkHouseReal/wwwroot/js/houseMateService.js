(function () {
    'use strict';

    angular.module('app').factory('houseMateService', HouseMateService);

    HouseMateService.$inject = ['$http'];

    function HouseMateService($http) {

        var service = this;

        service.getHouseMate = function () {
            return $http.get('/api/housemate');
        }

        service.update = function (houseId) {
            return $http.put('/api/housemate/' + houseId);
        };

        return service;
    }




}());