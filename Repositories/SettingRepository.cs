using Pishkhan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Repositories
{
    public class SettingRepository : BaseRepository<Setting>
    {
        public SettingRepository(AppIdentityDbContext context) : base(context)
        {

        }
    }
}
