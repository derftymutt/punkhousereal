(function () {
    'use strict';

    angular.module('app').factory('expenseService', ExpenseService);

    ExpenseService.$inject = ['$http'];

    function ExpenseService($http) {

        var service = this;

        service.create = function (data) {
            return $http.post('/api/expense', data);
        };

        service.getByHouseId = function (houseId) {
            return $http.get('/api/expense/' + houseId);
        };

        return service;
    }

}());