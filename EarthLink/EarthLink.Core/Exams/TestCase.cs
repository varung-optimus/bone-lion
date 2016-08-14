using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarthLink.Exams
{
    [Table("AbpTestCases")]
    public class TestCase : CreationAuditedEntity<long>
    {
        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }
        public virtual int ExamId { get; set; }

        [Required]
        public virtual string Input { get; set; }

        [Required]
        public virtual string ExpectedOutput { get; set; }
    }
}