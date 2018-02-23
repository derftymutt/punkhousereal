(function () {
    'use strict';

    angular.module('app').factory('expenseService', ExpenseService);

    ExpenseService.$inject = ['$http'];

    function ExpenseService($http) {

        var service = this;

        service.create = function (data) {
            return $http.post('/api/expenses', data);
        };

        //BAD, REWORK
        service.updateHouseMateExpense = function (houseId, data) {
            return $http.patch('/api/expenses/' + houseId + '/houseMateExpense', data);
        };

        return service;
    }

}());