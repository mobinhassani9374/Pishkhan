using Pishkhan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Repositories
{
    public class UserPhoneNumberRepository : BaseRepository<UserPhoneNumber>
    {
        public UserPhoneNumberRepository(AppIdentityDbContext context) : base(context)
        {

        }
    }
}
