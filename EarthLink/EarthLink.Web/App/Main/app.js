(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp',
        'textAngular',
        'ngclipboard',
        'ngSanitize'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in EarthLinkNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            //if (abp.auth.hasPermission('Pages.Tenants')) {
            //    $stateProvider
            //        .state('tenants', {
            //            url: '/tenants',
            //            templateUrl: '/App/Main/views/tenants/index.cshtml',
            //            menu: 'Tenants' //Matches to name of 'Tenants' menu in EarthLinkNavigationProvider
            //        });
            //    $urlRouterProvider.otherwise('/tenants');
            //}

            if (abp.auth.hasPermission('Pages.Exams')) {
                $stateProvider
                    .state('exams', {
                        url: '/exams',
                        templateUrl: '/App/Main/views/exams/index.cshtml',
                        menu: 'Exams' //Matches to name of 'Exams' menu in EarthLinkNavigationProvider
                    }).state('create', {
                        url: '/exams/create',
                        templateUrl: '/App/Main/views/exams/create.cshtml'
                    }).state('view', {
                        url: '/exams/view',
                        templateUrl: '/App/Main/views/exams/view.cshtml',
                        params: {
                            exam: {
                                value: 'null'
                            },
                            hiddenParam: 'YES'
                        }
                    }).state('results', {
                        url: '/exams/results',
                        templateUrl: '/App/Main/views/exams/results.cshtml',
                        params: {
                            exam: {
                                value: 'null'
                            },
                            hiddenParam: 'YES'
                        }
                    }).state('report', {
                        url: '/exams/report',
                        templateUrl: '/App/Main/views/exams/report.cshtml',
                        params: {
                            exam: {
                                value: 'null'
                            },
                            hiddenParam: 'YES'
                        }
                    });
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in EarthLinkNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in EarthLinkNavigationProvider
                });
        }
    ]);
})();