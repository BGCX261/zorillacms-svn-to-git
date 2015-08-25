using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public interface IWishRepository : IRepository<Wish,long>
    {
    }

    public class WishRepository : RepositoryBase<Wish, long>, IWishRepository
    {
    }
}
