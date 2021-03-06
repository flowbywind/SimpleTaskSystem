﻿(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'abp'
        //,'ngSanitize',
        //'ngTable',
        //'ngRoute'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('tasklist', {
                    url: '/',
                    templateUrl: '/App/Main/views/task/list.cshtml',
                    menu: 'TaskList' //Matches to name of 'TaskList' menu in SimpleTaskSystemNavigationProvider
                })
                .state('newtask', {
                    url: '/new',
                    templateUrl: '/App/Main/views/task/new.cshtml',
                    menu: 'NewTask' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                })
                .state('edittask', {
                    url: '/new/:id',
                    templateUrl: '/App/Main/views/task/new.cshtml',
                    menu: 'TaskList' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                })
                .state('viewtask', {
                    url: '/detail/:id',
                    templateUrl: '/App/Main/views/task/detail.cshtml',
                    menu: 'TaskList' //Matches to name of 'TaskList' menu in SimpleTaskSystemNavigationProvider
                })
                .state('login', {
                    url: '/login',
                    templateUrl: '/App/Main/views/account/login.cshtml',
                    menu: 'TaskList' //Matches to name of 'TaskList' menu in SimpleTaskSystemNavigationProvider
                });
        }
    ]);
})();