(function () {
    "use strict";

    function chatService($rootScope, $http, $q) {

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

            var sendMessage = {
                UserUniqueName: message.username,
                Text: message.text,
                AddDateTime: message.origDt

            };

            var config = {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
            $http.post("api/Chat/AddNewUserMessage", sendMessage, config).success(function (data) {
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
