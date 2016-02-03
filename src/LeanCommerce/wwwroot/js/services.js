angular.module('leancommerce.services', [])

    .factory('Settings', function () {
        var returnValue = {
            requiresSetup: true,
            SetupPath: '/setup'
        };
        return returnValue;
    });
