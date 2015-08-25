using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public interface ITextRepository : IRepository<Text,string>
    { 
    }

    public class TextRepository : RepositoryBase<Text, string>, ITextRepository
    {
       
    }
}
