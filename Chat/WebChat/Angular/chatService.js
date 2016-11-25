(function () {
    "use strict";

    function chatService($rootScope, $http, $q) {

        this.isAddedNameFree = function (name) {
            var deferrred = $q.defer();
            var user = { UniqueName: name }
                var config = {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            $http.post("api/User/IfAddedNameFreeAdd", user, config).success(function (data) {
                deferrred.resolve(data);
            }).error(function (data) { deferrred.reject(data); });
            return deferrred.promise;
        }

        this.getAllMessages = function () {
            var deferrred = $q.defer();
            $http.get("api/User/GetAllMessages").success(function (data) {
                deferrred.resolve(data);
            }).error(function (data) {
                deferrred.reject(data);
            });
            return deferrred.promise;
        };

        this.getAllUsersMessages = function () {
            var deferrred = $q.defer();
            $http.get("api/Chat/GetAllUsersMessages").success(function (data) {
                deferrred.resolve(data);
            }).error(function (data) {
                deferrred.reject(data);
            });
            return deferrred.promise;
        };

        this.addNewUserMessage = function (message) {
            var deferrred = $q.defer();

            var config = {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
            $http.post("api/Chat/AddNewUserMessage", message, config).success(function (data) {
                deferrred.resolve(data);
            }).error(function (data) {
                deferrred.reject(data);
            });
            return deferrred.promise;
        };

    };

    angular
        .module("WebChat.Services")
        .service("chatService", ["$rootScope", "$http", "$q", chatService]);

})();
