using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public interface IRegistrationRepository : IRepository<Registration, long>
    {
    }

    public class RegistrationRepository : RepositoryBase<Registration, long>, IRegistrationRepository
    {
    }
}
