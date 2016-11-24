(function () {
    "use strict";

    angular.module("WebChat.Services", []);
    angular.module("WebChat.Controllers", []);
    angular.module("WebChat.Externals", ['ngMaterial']);

    var app = angular.module("WebChat", ["WebChat.Services", "WebChat.Controllers", "WebChat.Externals"]);

    app.filter('reverse', function () {
        return function (items) {
            return items.slice().reverse();
        };
    });


    app.run(['$rootScope', '$location', '$http', '$mdDialog',
        function ($rootScope, $location, $http, $mdDialog) {
        }
    ]);

})();