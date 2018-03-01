(function () {
    'use strict';

    angular.module('app').factory('expenseService', ExpenseService);

    ExpenseService.$inject = ['$http', '$q'];

    function ExpenseService($http, $q) {

        var service = {
            create: create
        }

        return service;

        ///////////////////

        function create(data) {
            return $http.post('/api/expenses', data)
                .then(onCreateSuccess)
                .catch(onCreateError);

            function onCreateSuccess(response) {
                return response;
            }

            function onCreateError(error) {
                return $q.reject("error creating expense");
            }
        };
    }

}());