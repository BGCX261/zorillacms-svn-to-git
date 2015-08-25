using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Repositories
{
    public interface IRepository<Entity, PrimaryKey>
    {
        Entity GetByPrimaryKey(PrimaryKey id);
        IList<Entity> GetAll();
        IQueryable<Entity> Query { get; }
        void Update(Entity e);
        void Create(Entity e);
        void Save(Entity e);
    }
}
