
(function () {
    "use strict";

    var enterNameDialogController = function ($scope, $rootScope, $mdDialog, $cookies, chatService) {

        $scope.user = { uniqueName: "" }

        $scope.takeTheName = function () {
            chatService.isAddedNameFree($scope.user.uniqueName).then(function (value) {
                if (value) {
                    $cookies.put('userUniqueName', $scope.user.uniqueName);
                    $mdDialog.cancel();
                }
            });
        }

        $scope.showEnterNameDialog = function () {
            if ($cookies.get('userUniqueName') === undefined) {
                $scope.dialog = $mdDialog.show({
                    controller: enterNameDialogController,
                    templateUrl: '/Angular/enterNameDialog.html',
                    parent: angular.element(document.body),
                    clickOutsideToClose: false,
                    fullscreen: $scope.customFullscreen
                });;
            }
        };
    }


    angular
        .module("WebChat.Controllers")
        .controller("enterNameDialogController", ["$scope", "$rootScope", "$mdDialog", "$cookies", "chatService", enterNameDialogController]);

})();