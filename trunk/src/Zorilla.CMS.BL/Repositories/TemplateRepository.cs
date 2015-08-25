using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public interface ITemplateRepository : IRepository<Template,long>
    {
        
    }
    public class TemplateRepository : RepositoryBase<Template, long>, ITemplateRepository
    {
    }
}
