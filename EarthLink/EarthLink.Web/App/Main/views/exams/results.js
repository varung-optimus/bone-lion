(function () {
    angular.module('app').controller('app.views.exams.results', [
        '$scope', '$modal', 'abp.services.app.user', '$state',
        function ($scope, $modal, userService, $state) {
            var vm = this;

            vm.results = [];

            vm.viewExamDetails = function (exam) {
                $state.go('report', {
                    exam: exam
                });
            };

            function getResults() {
                userService.getUsers({}).success(function (result) {
                    //vm.results = result.items;
                    vm.results = [{
                        id: 1,
                        pName: 'Varun Goel',
                        pEmail: 'varun@varungoel.net',
                        score: '90/100',
                        dos: '09-Aug-2016'
                    }, {
                        id: 2,
                        pName: 'John Doe',
                        pEmail: 'john@doe.net',
                        score: '70/100',
                        dos: '05-Aug-2016'
                    }, {
                        id: 3,
                        pName: 'Jane Doe',
                        pEmail: 'jane@doe.net',
                        score: '25/100',
                        dos: '05-Jul-2016'
                    }];
                });
            }

            getResults();
        }
    ]);
})();