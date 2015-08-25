using System;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using NHibernate.Linq;
using NHibernate;

namespace ActiveRecord.Linq
{
    public class ActiveRecordContext : NHibernateContext
    {
        public ActiveRecordContext()
            : base(null)
        {
            session = GetSession();
        }
        private ISession GetSession()
        {
            ISessionScope scope = SessionScope.Current;
            if (scope == null)
                throw new InvalidOperationException("You should be in a SessionScope()");
            ISessionFactoryHolder holder = ActiveRecordMediator.GetSessionFactoryHolder();
            return holder.CreateSession(typeof(ActiveRecordBase));
        }
    }
}
