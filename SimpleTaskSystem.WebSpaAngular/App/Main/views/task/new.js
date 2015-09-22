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
                tasklevel: '',
                begintime: '',
                endtime: '',
                taskcategory: '',
                repeatmode: '',
                frequency: '',
                repeatdays: '',
                repeattype: '',
                remindtype: '',
                remindtime: '',
                assignedPersonId: null
            };

            var localize = abp.localization.getSource('SimpleTaskSystem');

            vm.people = []; //TODO: Move Person combo to a directive?
            personService.getAllPeople().success(function (data) {
                vm.people = data.people;
            });

            //任务级别
            enumService.getSelectList({
                enumType: "TaskLevel"
            }).success(function (data) {
                vm.level = data.enums;
            });
            //任务类别
            enumService.getSelectList({
                enumType: "TaskCategory"
            }).success(function (data) {
                vm.category = data.enums;
            });
            //重复模式
            enumService.getSelectList({
                enumType: "RepeatMode"
            }).success(function (data) {
                vm.repeatmode = data.enums;
            });
            //重复方式
            enumService.getSelectList({
                enumType: "RepeatType"
            }).success(function (data) {
                vm.repeattype = data.enums;
            });
            //提醒方式
            enumService.getSelectList({
                enumType: "RemindType"
            }).success(function (data) {
                vm.remindtype = data.enums;
            });

            $('.date').datetimepicker({
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
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.task.description));
                        $location.path('/');

                    })
                );
            };
            vm.updateTask = function () {
                abp.ui.setBusy(
                    null,
                    taskService.updateTask(
                        vm.task
                    ).success(function () {
                        abp.notify.info(vm.localize('TaskUpdatedMessage'));
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