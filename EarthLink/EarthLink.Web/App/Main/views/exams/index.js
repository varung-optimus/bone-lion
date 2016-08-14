(function () {
    angular.module('app').controller('app.views.exams.index', [
        '$scope', '$modal', 'abp.services.app.exam', '$state',
        function ($scope, $modal, examService, $state) {
            var vm = this;
            vm.exams = [];
            vm.isResultsBtn = false;

            function getExams() {
                examService.getExam({}).success(function (result) {
                    vm.exams = result.items;
                });
            }

            vm.viewExamDetails = function (exam) {
                if (!vm.isResultsBtn) {
                    $state.go('view', {
                        exam: exam
                    });
                }
            }

            vm.openDeleteExamModal = function (exam) {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/exams/deleteExamModal.cshtml',
                    controller: 'app.views.exams.deleteModal as vm',
                    backdrop: 'static',
                    resolve: {
                        exam: function () {
                            return exam;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    getExams();
                });
            }

            vm.onCopySuccess = function (e) {
                abp.notify.info(App.localize('Copied'));
                e.clearSelection();
            }

            vm.stopRedirection = function (ev) {
                ev.stopPropagation();
            }

            vm.viewExamResults = function (exam) {
                $state.go('results', {
                    exam: exam
                });
            }

            getExams();
        }
    ]);
})();