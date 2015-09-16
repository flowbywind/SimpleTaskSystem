(function () {
    var app = angular.module('app');

    var controllerId = 'sts.views.task.new';
    app.controller(controllerId, [
        '$scope', '$location', 'abp.services.tasksystem.task', 'abp.services.tasksystem.person', '$stateParams',
        function ($scope, $location, taskService, personService, $stateParams) {
            var vm = this;
            vm.localize = abp.localization.getSource('SimpleTaskSystem');
            vm.task = {
                id: 0,
                description: '',
                assignedPersonId: null
            };

            var localize = abp.localization.getSource('SimpleTaskSystem');

            vm.people = []; //TODO: Move Person combo to a directive?

            personService.getAllPeople().success(function (data) {
                vm.people = data.people;
            });
            if ($stateParams.id > 0)
                taskService.getTaskById({
                    id: $stateParams.id
                }).success(function (data) {
                    vm.task = data;
                });

            vm.saveTask = function () {
                abp.ui.setBusy(
                    null,
                    taskService.createTask(
                        vm.task
                    ).success(function () {
                        if (vm.task.id == 0) {
                            abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.task.description));
                        } else {
                            abp.notify.info(vm.localize('TaskUpdatedMessage'));
                        }
                        $location.path('/');

                    })
                );
            };
        }
    ]);
})();