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
                title: '',
                description: '',
                taskLevel: null,
                beginTime: '',
                endTime: '',
                taskCategory: null,
                repeatMode: null,
                frequency: 0,
                repeatDays: 0,
                repeatType: null,
                remindType: null,
                remindTime: '',
                taskState: null,
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
                vm.taskLevel = data.enums;
            });
            //任务类别
            enumService.getSelectList({
                enumType: "TaskCategory"
            }).success(function (data) {
                vm.taskCategory = data.enums;
            });
            //重复模式
            enumService.getSelectList({
                enumType: "RepeatMode"
            }).success(function (data) {
                vm.repeatMode = data.enums;
            });
            //重复方式
            enumService.getSelectList({
                enumType: "RepeatType"
            }).success(function (data) {
                vm.repeatType = data.enums;
            });
            //提醒方式
            enumService.getSelectList({
                enumType: "RemindType"
            }).success(function (data) {
                vm.remindType = data.enums;
            });
            //任务状态
            enumService.getSelectList({
                enumType: "TaskState"
            }).success(function (data) {
                vm.taskState = data.enums;
            });

            $('div.date').datetimepicker({
                language: 'zh-CN',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                forceParse: 0,
                showMeridian: 1,
                initialDate: new Date(),
                format: "yyyy-mm-dd hh:ii"
            }).on("hide", function () {
                var $this = $(this).next().attr('ng-model');
                var _this = $(this).children()[0];
                var arr = $this.split('.');
                $scope.$apply(function () {
                    $scope[arr[0]][arr[1]][arr[2]] = _this.value;
                });
            }).datetimepicker('update', new Date());

            if ($stateParams.id > 0)
                taskService.getTaskById({
                    id: $stateParams.id
                }).success(function (data) {
                    vm.task = data;
                });

            vm.createTask = function () {
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