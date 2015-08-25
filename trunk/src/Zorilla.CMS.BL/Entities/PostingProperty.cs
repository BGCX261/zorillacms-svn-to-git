using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Zorilla.CMS.BL.Entities
{
    [Castle.ActiveRecord.ActiveRecord]
    public class PostingProperty : ActiveRecordBase<PostingProperty>
    {
        [PrimaryKey]
        public long Id { get; set; }
        [Property]
        public string Name { get; set; }
        [Property]
        public int IntValue { get; set; }
        [Property]
        public double DoubleValue { get; set; }
        [Property]
        public string StringValue { get; set; }

        [BelongsTo]
        public Posting Posting { get; set; }
    }
}
