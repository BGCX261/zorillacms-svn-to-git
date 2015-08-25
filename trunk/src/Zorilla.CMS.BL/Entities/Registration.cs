using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Zorilla.CMS.BL.Entities
{
    [ActiveRecord]
    public class Registration : ActiveRecordBase<Registration>
    {
        [PrimaryKey]
        public long Id { get; set; }

        [Property]
        public string Name { get; set; }

        [Property]
        public bool IsComing { get; set; }

        [Property]
        public bool WantBus { get; set; }

        [Property]
        public string Comment { get; set; }
    }
}
