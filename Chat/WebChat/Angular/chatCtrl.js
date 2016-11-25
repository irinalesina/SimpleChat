(function () {
    "use strict";

    var chatController = function ($scope, $rootScope, $cookies, chatService) {

        chatService.getAllMessages().then(function (value) {
            $scope.chatMessages = value;
        });


        $scope.addMessage = function () {
            if ($scope.newChatMsg != "") {
                var message = {
                    UserUniqueName: $cookies.get('userUniqueName'),
                    Text: $scope.newChatMsg,
                    AddDateTime: new Date()
                };
                $scope.chatMessages.push(message);
                chatService.addNewUserMessage(message);
                $scope.newChatMsg = "";
            }
        }
    }


    angular
        .module("WebChat.Controllers")
        .controller("chatController", ["$scope", "$rootScope", "$cookies", "chatService", chatController]);

})();