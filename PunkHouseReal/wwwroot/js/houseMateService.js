(function () {
    'use strict';

    angular.module('app').factory('houseMateService', HouseMateService);

    HouseMateService.$inject = ['$http', '$q'];

    function HouseMateService($http, $q) {

        var service = {
            get: get,
            update: update,
            getHouseMateExpenses: getHouseMateExpenses,
            updateHouseMateExpense: updateHouseMateExpense
        }

        return service;

        /////////////////////

        function get () {
            return $http.get('/api/housemates')
                .then(onGetHouseMatesSuccess)
                .catch(onGetHouseMatesError);

            function onGetHouseMatesSuccess(response) {
                return response.data;
            }

            function onGetHouseMatesError(error) {
                return $q.reject("error getting houseMates");
            }
        }

        function update(data) {
            return $http.patch('/api/housemates', data)
                .then(onUpdateSuccess)
                .catch(onUpdateError);

            function onUpdateSuccess(response) {
                return response.data;
            }

            function onUpdateError(error) {
                return $q.reject("error updating houseMate");
            }
        };

        function updateHouseMateExpense(houseMateId, expenseId, data) {
            return $http.patch('/api/houseMates/' + houseMateId + '/expenses/' + expenseId, data)
                .then(onUpdateHouseMateExpenseSuccess)
                .catch(onUpdateHouseMateExpenseError);

            function onUpdateHouseMateExpenseSuccess(response) {
                return response.data;
            }

            function onUpdateHouseMateExpenseError(error) {
                return $q.reject("error updating hosueMateExpense");
            }
        }

        function getHouseMateExpenses(houseMateId, data) {
            return $http.get('/api/houseMates/' + houseMateId + '/expenses', {
                params: {
                    creatorId: data.creatorId,
                    isPaid: data.isPaid,
                    isMarkedPaid: data.isMarkedPaid
                }
            })
                .then(onGetHouseMateExpensesSuccess)
                .catch(onGetHouseMateExpensesError);

            function onGetHouseMateExpensesSuccess(response) {
                return response.data;
            }

            function onGetHouseMateExpensesError(error) {
                return $q.reject("error getting houseMateExpenses");
            }
        }

    }

}());