angular.module('app')
    .filter('subString', function () {
        return function (input,num) {
            if (input.length > num) {
                return input.substring(0, num) + "...";
            }
            return input;
        };
    });