(function () {
    angular.module('app').controller('app.views.exams.create', [
        '$scope', '$modal', 'abp.services.app.exam',
        function ($scope, $modal, examService) {
            var vm = this;
            vm.exam = {};
            vm.exam.name = 'Task 1';
            vm.exam.testCases = [];
            vm.exam.testCases.push({
                id: '1'
            })

            vm.createExam = function () {
                // Generate Exam Invitation Code
                vm.exam.invitationUrl = new Date().getTime();

                examService.createExam(vm.exam).success(function () {
                    vm.isSaved = true;
                    abp.notify.info(App.localize('SavedSuccessfully'));
                }).error(function () {
                    abp.notify.error(App.localize('Error'));
                });
            };
        }
    ]);
})();