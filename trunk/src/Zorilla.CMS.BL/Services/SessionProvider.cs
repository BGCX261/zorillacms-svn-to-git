using System;
using Castle.ActiveRecord;

namespace Zorilla.CMS.BL.Services
{
    public interface ISessionProvider
    {
        IDisposable GetSession();
    }

    public class SessionProvider : ISessionProvider
    {
        public IDisposable GetSession()
        {
            return new SessionScope();
        }
    }
}