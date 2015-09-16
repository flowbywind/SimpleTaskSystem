(function () {
    var app = angular.module('app');

    var controllerId = 'sts.views.task.detail';
    app.controller(controllerId, [
        '$scope', '$location', 'abp.services.tasksystem.task', '$stateParams',
         function ($scope, $location, taskService, $stateParams) {
             var vm = this;
             vm.task = {
                 description: '',
                 assignedPersonId: null
             };
             vm.localize = abp.localization.getSource('SimpleTaskSystem');
             taskService.getTaskById({
                 id: $stateParams.id
             }).success(function (data) {
                 vm.task = data;
             });
             vm.returnList = function () {
                 $location.path('/');
             };
         }
    ]);
})();