using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarthLink.Exams
{
    [Table("AbpExams")]
    public class Exam : FullAuditedEntity
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public virtual string InvitationUrl { get; set; }

        public virtual ICollection<TestCase> TestCases { get; set; }
    }
}