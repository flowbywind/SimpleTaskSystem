(function () {
    var app = angular.module('app');
    app.service("EnumsService", function () {
        this.getEnumList = function (getEnumsService, para) {
            //获取枚举类别方法
            getEnumsService.getSelectList({
                enumType: para
            }).success(function (data) {
                return data.enums;
            });
        }
    });
})();