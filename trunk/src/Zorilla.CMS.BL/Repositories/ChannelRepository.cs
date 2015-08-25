using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public interface IChannelRepository : IRepository<Channel,long>
    {
        
    }
    public class ChannelRepository : RepositoryBase<Channel,long>, IChannelRepository
    {
    }
}
