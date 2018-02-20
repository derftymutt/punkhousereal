﻿(function () {
    'use strict';

    angular.module('app').factory('houseMateService', HouseMateService);

    HouseMateService.$inject = ['$http'];

    function HouseMateService($http) {

        var service = this;

        service.get = function () {
            return $http.get('/api/housemates');
        }

        service.update = function (data) {
            return $http.patch('/api/housemates', data);
        };

        service.updateHouseMateExpense = function (houseMateId, expenseId, data) {
            return $http.put('/api/houseMates/' + houseMateId + '/expenses/' + expenseId, data);
        }

        service.getHouseMateExpenses = function (houseMateId) {
            return $http.get('/api/houseMates/' + houseMateId + '/expenses/');
        }

        return service;
    }

}());