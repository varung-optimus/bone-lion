(function () {
    angular.module('app').controller('app.views.exams.deleteModal', [
        '$scope', '$modalInstance', 'abp.services.app.exam', 'exam',
        function ($scope, $modalInstance, examService, exam) {
            var vm = this;
            vm.exam = exam;

            vm.deleteExam = function () {
                examService.deleteExam(vm.exam)
                    .success(function () {
                        abp.notify.success(App.localize('Deleted Successfully'));
                        $modalInstance.close();
                    });
            };

            vm.cancel = function () {
                $modalInstance.dismiss();
            };
        }
    ]);
})();