using obsCommon.configFontIcon.commandDomain.Abstractions.Repositories;
using obsCommon.configFontIcon.commandDomain.Entities;

namespace obsCommon.configFontIcon.commandPersistence.Repositories
{
    public class FontIconRepository : GenericRepository<FontIcon, string>, IFontIconRepository
    {
        public FontIconRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
