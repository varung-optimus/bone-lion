using EarthLink.EntityFramework;
using EntityFramework.DynamicFilters;

namespace EarthLink.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly EarthLinkDbContext _context;

        public InitialHostDbBuilder(EarthLinkDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new InitialExamCreator(_context).Create();
        }
    }
}
