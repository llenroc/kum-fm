

using Mao.EntityFramework.EntityFramework;

namespace Mao.EntityFramework.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly MaoDbContext _context;

        public InitialHostDbBuilder(MaoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
