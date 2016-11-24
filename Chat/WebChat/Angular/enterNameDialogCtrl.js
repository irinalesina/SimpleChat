
(function () {
    "use strict";

    var enterNameDialogController = function ($scope, $rootScope, $mdDialog, chatService) {

        $scope.user = { uniqueName: "" }

        $scope.takeTheName = function () {
            chatService.isAddedNameFree($scope.user.uniqueName).then(function (value) {
                if (value) {
                    $rootScope.userUniqueName = $scope.user.uniqueName;
                    $mdDialog.cancel();
                }
            });
        }

        $scope.showEnterNameDialog = function () {
            $scope.dialog = $mdDialog.show({
                controller: enterNameDialogController,
                templateUrl: '/Angular/enterNameDialog.html',
                parent: angular.element(document.body),
                clickOutsideToClose: false,
                fullscreen: $scope.customFullscreen
            });;
        };
    }


    angular
        .module("WebChat.Controllers")
        .controller("enterNameDialogController", ["$scope", "$rootScope", "$mdDialog", "chatService", enterNameDialogController]);

})();