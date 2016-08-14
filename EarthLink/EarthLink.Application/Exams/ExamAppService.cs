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
    }
}