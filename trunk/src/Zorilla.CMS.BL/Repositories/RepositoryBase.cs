using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Linq;
using ActiveRecord.Linq;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public abstract class RepositoryBase<Entity,PrimaryKey> : IRepository<Entity,PrimaryKey> where Entity : ActiveRecordBase<Entity>
    {
        #region IRepository<Entity,PrimaryKey> Members

        public Entity GetByPrimaryKey(PrimaryKey id)
        {
            return ActiveRecordBase<Entity>.Find(id);
        }

        public IList<Entity> GetAll()
        {
            return new List<Entity>(ActiveRecordBase<Entity>.FindAll());
        }

        public IQueryable<Entity> Query
        {
            get { 
                var context = new ActiveRecordContext();
                return context.Session.Linq<Entity>();
            }
        }

        public void Update(Entity e)
        {
            e.Update();
        }

        public void Create(Entity e)
        {
            e.Create();
        }

        public void Save(Entity e)
        {
            e.Save();
        }

        #endregion
    }
}
