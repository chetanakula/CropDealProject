using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Repository
{
    public interface IUserIdRepository<TKey>
    {
        Task<int> GetUserId(string item);
    }
}
