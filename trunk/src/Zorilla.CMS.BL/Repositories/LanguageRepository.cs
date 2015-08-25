using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public interface ILanguageRepository : IRepository<Language, int>
    {
        Language GetLanguageByLanguageCode(string languageCode);
    }

    public class LanguageRepository : RepositoryBase<Language, int>, ILanguageRepository
    {
        public Language GetLanguageByLanguageCode(string languageCode)
        {
            using (new SessionScope())
            {
                var res = from l in Query
                          where l.LanguageCode == languageCode
                          select l;
                return res.FirstOrDefault();
            }
        }
    }
}
