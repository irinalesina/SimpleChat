(function () {
    "use strict";

    var chatController = function ($scope, $rootScope, chatService) {

        chatService.getAllMessages().then(function (value) {
            $scope.chatMessages = value;
        });;


        $scope.addMessage = function () {
            if ($scope.newChatMsg != "") {

                var message = {
                    username: $scope.userUniqueName,
                    text: $scope.newChatMsg,
                    origDt: new Date()
                };

                $scope.chatMessages.push(message);
                
                chatService.addNewUserMessage(message);

                $scope.newChatMsg = "";
            }
            else {

            }


        }
    }


    angular
        .module("WebChat.Controllers")
        .controller("chatController", ["$scope", "$rootScope", "chatService", chatController]);

})();