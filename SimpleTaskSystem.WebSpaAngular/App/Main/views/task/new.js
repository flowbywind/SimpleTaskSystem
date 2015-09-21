(function () {
    var app = angular.module('app');
    var controllerId = 'sts.views.task.new';
    app.controller(controllerId, [
        '$scope', '$location', 'abp.services.tasksystem.task',
        'abp.services.tasksystem.enum',
         'abp.services.tasksystem.person',
        '$stateParams',
        function ($scope, $location, taskService,
            enumService,
            personService,
            $stateParams) {
            var vm = this;
            vm.localize = abp.localization.getSource('SimpleTaskSystem');
            vm.task = {
                id: 0,
                title: "",
                description: '',
                starttime: '',
                endtime: '',
                assignedPersonId: null
            };

            var localize = abp.localization.getSource('SimpleTaskSystem');

            vm.people = []; //TODO: Move Person combo to a directive?
            personService.getAllPeople().success(function (data) {
                vm.people = data.people;
            });

            vm.level = [];
            enumService.getSelectList().success(function (data) {
                vm.level = data;
            });

            $('.form_datetime').datetimepicker({
                language: 'zh-CN',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                forceParse: 0,
                showMeridian: 1,
                format: "yyyy-mm-dd hh:ii:ss"
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
            vm.returnList = function () {
                $location.path('/');
            };
        }
    ]);
})();