using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EarthLink.Exams.Dto
{
    [AutoMapFrom(typeof(Exam))]
    public class ExamListDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string InvitationUrl { get; set; }
        public Collection<TestCaseInExamListDto> TestCases { get; set; }
    }

    [AutoMapFrom(typeof(TestCase))]
    public class TestCaseInExamListDto : CreationAuditedEntityDto<long>
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
    }

    [AutoMapTo(typeof(TestCase))]
    public class AddTestCaseInput
    {
        public int ExamId { get; set; }

        [Required]
        public string input { get; set; }

        [Required]
        public string expectedOutput { get; set; }
    }
}