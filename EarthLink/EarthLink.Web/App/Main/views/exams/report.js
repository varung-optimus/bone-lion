(function () {
    angular.module('app').controller('app.views.exams.report', [
        '$scope', '$modal', 'abp.services.app.user',
        function ($scope, $modal, userService) {
            var vm = this;

            vm.results = [];

            vm.export = function () {
                html2canvas(document.getElementById('exportthis'), {
                    onrendered: function (canvas) {
                        var data = canvas.toDataURL();
                        var docDefinition = {
                            content: [{
                                image: data,
                                width: 500,
                            }]
                        };
                        pdfMake.createPdf(docDefinition).download(vm.report.pName + '- Score' + '.pdf');
                    }
                });
            };

            function getResults() {
                userService.getUsers({}).success(function (result) {
                    //vm.results = result.items;
                    vm.report = {
                        id: 1,
                        overall: '90/100',
                        isPassed: true,
                        pName: 'Varun Goel',
                        pEmail: 'varun@varungoel.net',
                        score: '90/100',
                        dos: '09-Aug-2016',
                        tasks: [{
                            name: 'Task 1',
                            solution: 'using System;\r\n\n// you can also use other imports, for example:\n// using System.Collections.Generic;\n\n// you can write to stdout for debugging purposes, e.g.\n// Console.WriteLine(\"this is a debug message\");\n\nclass Solution {\n    public int solution(int[] A) {\n        // write your code in C# 6.0 with .NET 4.5 (Mono)\n    }\n}',
                            score: '100/100',
                            tests: [{
                                id: 1,
                                status: 'pass',
                                marks: '20/20'
                            }, {
                                id: 2,
                                status: 'pass',
                                marks: '20/20'
                            }, {
                                id: 3,
                                status: 'pass',
                                marks: '20/20'
                            }, {
                                id: 4,
                                status: 'pass',
                                marks: '20/20'
                            }, {
                                id: 5,
                                status: 'pass',
                                marks: '20/20'
                            }]
                        }, {
                            name: 'Task 2',
                            solution: 'using System;\r\n\n// you can also use other imports, for example:\n// using System.Collections.Generic;\n\n// you can write to stdout for debugging purposes, e.g.\n// Console.WriteLine(\"this is a debug message\");\n\nclass Solution {\n    public int solution(int[] A) {\n        // write your code in C# 6.0 with .NET 4.5 (Mono)\n    }\n}',
                            score: '80/100',
                            tests: [{
                                id: 1,
                                status: 'pass',
                                marks: '20/20'
                            }, {
                                id: 2,
                                status: 'pass',
                                marks: '20/20'
                            }, {
                                id: 3,
                                status: 'fail',
                                marks: '0/20'
                            }, {
                                id: 4,
                                status: 'pass',
                                marks: '20/20'
                            }, {
                                id: 5,
                                status: 'pass',
                                marks: '20/20'
                            }]
                        }]
                    };
                });
            }

            getResults();
        }
    ]);
})();