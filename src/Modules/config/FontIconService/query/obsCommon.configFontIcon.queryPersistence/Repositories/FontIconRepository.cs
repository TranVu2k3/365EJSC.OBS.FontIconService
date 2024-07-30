using obsCommon.configFontIcon.queryDomain.Abstractions.Repositories;
using obsCommon.configFontIcon.queryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obsCommon.configFontIcon.queryPersistence.Repositories
{
    public class FontIconRepository : GenericRepository<FontIcon, string>, IFontIconRepository
    {
        public FontIconRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
