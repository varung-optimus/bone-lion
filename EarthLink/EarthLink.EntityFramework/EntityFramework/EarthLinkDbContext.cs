using System.Data.Common;
using Abp.Zero.EntityFramework;
using EarthLink.Authorization.Roles;
using EarthLink.MultiTenancy;
using EarthLink.Users;
using System.Data.Entity;
using EarthLink.Exams;

namespace EarthLink.EntityFramework
{
    public class EarthLinkDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Exam> Exams { get; set; }
        public virtual IDbSet<TestCase> TestCases { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public EarthLinkDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in EarthLinkDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of EarthLinkDbContext since ABP automatically handles it.
         */
        public EarthLinkDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public EarthLinkDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
