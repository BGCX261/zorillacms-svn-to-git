using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Zorilla.CMS.BL.Entities
{
    [Serializable]
    [ActiveRecord]
    public class Wish : ActiveRecordBase<Wish>
    {
        [PrimaryKey]
        public long Id { get; set; }

        [Property]
        public string Name { get; set; }

        [Property]
        public int Amount { get; set; }

        [Property]
        public int Reserved { get; set; }

        [Property]
        public string IP { get; set; }
    }
}
