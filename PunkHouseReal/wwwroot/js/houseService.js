(function () {
    'use strict';

    angular.module('app').factory('houseService', HouseService);

    HouseService.$inject = ['$http', '$q'];

    function HouseService($http, $q) {

        var service = {
            getAll: getAll,
            getById: getById,
            getExpenses: getExpenses,
            create: create
        }

        return service;

        /////////////////

        function getAll () {
            return $http.get('/api/houses')
                .then(getHousesSuccess)
                .catch(getHousesError);

            function getHousesSuccess(response) {
                return response.data;
            }

            function getHousesError(error) {
                return $q.reject("error getting houses");
            }
        };

        function getById(houseId) {
            return $http.get('/api/houses/' + houseId)
                .then(getHouseByIdSuccess)
                .catch(getHouseByIdError);

            function gethouseByIdSuccess(response) {
                return response.data;
            }

            function getHouseByIdError(error) {
                return $q.reject("error getting houseById");
            }
        }

        function getExpenses(houseId) {
            return $http.get('/api/houses/' + houseId + '/expenses')
                .then(getExpensesSuccess)
                .catch(getExpensesError);

            function getExpensesSuccess(response) {
                return response.data;
            }

            function getExpensesError(error) {
                return $q.reject("error getting house expenses");
            }
        }

        function create(data) {
            return $http.post('/api/houses', data)
                .then(createHouseSuccess)
                .catch(createHouseError);

            function createHouseSuccess(response) {
                return response.data;
            }

            function createHouseError(e) {
                return $q.reject("error creating house");
            }
        };

    }

}());