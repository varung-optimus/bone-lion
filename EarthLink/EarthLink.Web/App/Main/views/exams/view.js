(function () {
    angular.module('app').controller('app.views.exams.view', [
        '$scope', '$modal', 'abp.services.app.exam', '$stateParams', '$state', '$window',
        function ($scope, $modal, examService, $stateParams, $state, $window) {
            var vm = this;
            vm.data = $stateParams;

            vm.onCopySuccess = function (e) {
                abp.notify.info(App.localize('Copied'));
                e.clearSelection();
            }

            vm.viewExamResults = function (exam) {
                $state.go('results', {
                    exam: exam
                });
            }

            vm.updateExam = function () {
                examService.updateExam(vm.data.exam)
                    .success(function () {
                        vm.isUpdated = true;
                        $window.scrollTo(0, 0);
                        vm.isEditingMode = false;
                        abp.notify.success(App.localize('Updated Successfully'));
                    });
            }
        }
    ]);
})();