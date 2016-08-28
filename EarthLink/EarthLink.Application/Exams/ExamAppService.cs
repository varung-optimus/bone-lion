using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using EarthLink.Authorization;
using EarthLink.Exams.Dto;
using EarthLink.Exams;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace EarthLink.Users
{
    [AutoMapTo(typeof(Exam))]
    public class CreateExamInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string InvitationUrl { get; set; }

        [Required]
        public Collection<AddTestCaseInput> TestCases { get; set; }
    }

    [AutoMapTo(typeof(Exam))]
    public class UpdateExamInput
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string InvitationUrl { get; set; }
    }

    public class TestCaseResult
    {
        public string expected { get; set; }
        public string actual { get; set; }
        public bool isPassed { get; set; }
    }

    public class ExamResult
    {
        public bool hasError { get; set; }
        public List<string> errors;
        public List<TestCaseResult> outputStatus;
    }

    [AbpAuthorize(PermissionNames.Pages_Exams)]
    public class ExamAppService : EarthLinkAppServiceBase, IExamAppService
    {
        private readonly IRepository<Exam> _examRepository;
        //private readonly IRepository<TestCase> _testCaseRepository;

        public ExamAppService(IRepository<Exam> examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task CreateExam(CreateExamInput input)
        {
            var exam = input.MapTo<Exam>();
            await _examRepository.InsertAsync(exam);
        }

        public void UpdateExam(UpdateExamInput input)
        {
            var exam = _examRepository.Get(input.Id);
            exam.Name = input.Name;
            exam.Description = input.Description;
        }

        public async Task DeleteExam(IdInput input)
        {
            await _examRepository.DeleteAsync(input.Id);
        }

        public ListResultOutput<ExamListDto> GetExam()
        {
            var exams = _examRepository.GetAllIncluding(p => p.TestCases)
            .OrderBy(p => p.Id)
            .ThenBy(p => p.Name)
            .ToList();

            return new ListResultOutput<ExamListDto>(exams.MapTo<List<ExamListDto>>());
        }

        //public async Task DeleteTestCase(IdInput input)
        //{
        //    await _testCaseRepository.DeleteAsync(input.Id);
        //}

        public async Task<TestCaseInExamListDto> AddTestCase(AddTestCaseInput input)
        {
            var exam = _examRepository.Get(input.ExamId);

            var testCase = input.MapTo<TestCase>();
            exam.TestCases.Add(testCase);

            await CurrentUnitOfWork.SaveChangesAsync();

            return testCase.MapTo<TestCaseInExamListDto>();
        }

        public ExamResult ValidateExam(string submission)
        {
            #region "Exam Mock data"
            submission = @"using System;
            class Program {
              public static void Main(string[] args) {}

              public static string Main1(string abc) {
                bool myresult=false;

                if(Int32.Parse(abc)>0)
                  myresult=true;
                else
                  myresult=false;

                return abc + "": "" + (myresult ? ""myresult is true"" : ""myresult is false"");
              }
            }";
            #endregion

            ExamResult examResult = new ExamResult();

            CSharpCodeProvider codeProvider = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            CompilerParameters parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" });
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, submission);

            // Parse results for any errors in compilation or validation of output
            if (results.Errors.HasErrors)
            {
                // Compilation errors
                examResult.hasError = true;
                examResult.errors = new List<string>();
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => examResult.errors.Add(error.ErrorText));
            }
            else
            {
                // Compilation - Successful
                // Check for each input and validate results

                /**
                 *  TODO: Get all test cases for this exercise and create object for TestCaseResult with expected
                 * **/
                examResult.outputStatus = new List<TestCaseResult>();
                var scriptClass = results.CompiledAssembly.GetType("Program");
                var scriptMethod = scriptClass.GetMethod("Main1", BindingFlags.Static | BindingFlags.Public);

                /**
                 *  TODO: Iterate over each test case and push the result
                 *  **/
                // Below data is mocked for now
                #region "Mocked Data"
                List<TestCase> examTestCases = new List<TestCase>(new TestCase[] {
                    new TestCase()
                    {
                        ExpectedOutput = "10: myresult is true",
                        Input = "10"
                    },
                    new TestCase()
                    {
                        ExpectedOutput = "-20: myresult is false",
                        Input = "-20"
                    },
                    new TestCase()
                    {
                        ExpectedOutput = "1: myresult is true",
                        Input = "1"
                    },
                    new TestCase()
                    {
                        ExpectedOutput = "1000000: myresult is true",
                        Input = "1000000"
                    }
                });
                #endregion

                #region "Execute each test case and get result"
                foreach (TestCase tc in examTestCases)
                {
                    var methodResult = scriptMethod.Invoke(null, new object[] {
                    tc.Input
                }).ToString();

                    TestCaseResult tcResult = new TestCaseResult();
                    tcResult.expected = tc.ExpectedOutput;
                    // store actual result for this test case in test case result
                    tcResult.actual = methodResult;
                    // If actual matches expected, then pass
                    tcResult.isPassed = (tcResult.actual == tcResult.expected);
                    examResult.outputStatus.Add(tcResult);
                }
                #endregion
            }

            return examResult;
        }
    }
}