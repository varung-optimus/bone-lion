using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EarthLink.Exams.Dto;
using System.Threading.Tasks;

namespace EarthLink.Users
{
    public interface IExamAppService : IApplicationService
    {
        ListResultOutput<ExamListDto> GetExam();
        Task CreateExam(CreateExamInput input);
        void UpdateExam(UpdateExamInput input);
        Task DeleteExam(IdInput input);
        Task<TestCaseInExamListDto> AddTestCase(AddTestCaseInput input);
    }
}