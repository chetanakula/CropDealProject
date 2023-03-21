using CropDealProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Repository
{
    public class UserIdRepository : IUserIdRepository<int>
    {
        private readonly CropDealDataBaseContext _dbContext;
        public UserIdRepository(CropDealDataBaseContext dbContext) => this._dbContext = dbContext;

        #region getuserid
        public async Task<int> GetUserId(string item)
        {
            try
            {
                var userfound = await _dbContext.UserProfiles.SingleOrDefaultAsync(e => e.UserEmail == item);
                if (userfound != null)
                {
                    int userid = userfound.UserId;
                    return userid;
                }
                else
                {
                    return 404;
                }
            }
            catch
            {
                return 404;
            }
        }

        #endregion
    }
}
