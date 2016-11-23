
(function () {
    "use strict";

    var startLoadSiteController = function ($scope, $rootScope, $mdDialog, chatService) {

        $scope.getUserName = function () {
            var confirm = $mdDialog.prompt()
                   .title('Enter name to continue')
                   .placeholder('Name')
                   .ok('Take the name')

            $mdDialog.show(confirm).then(function (result) {
                //check user
                $scope.userUniqueName = result;
            });
        };
        
    }


    angular
        .module("WebChat.Controllers")
        .controller("startLoadSiteController.js", ["$scope", "$rootScope", "$mdDialog", "chatService", startLoadSiteController]);

})();