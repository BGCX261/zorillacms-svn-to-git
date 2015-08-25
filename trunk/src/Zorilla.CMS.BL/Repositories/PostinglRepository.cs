using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public interface IPostingRepository : IRepository<Posting, long>
    {
        
    }
    public class PostingRepository : RepositoryBase<Posting, long>, IPostingRepository
    {
    }
}
