using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Zorilla.CMS.BL.Entities
{
    [ActiveRecord]
    public class Template : ActiveRecordBase<Template>
    {
        [PrimaryKey]
        public long Id { get; set; }
        [Property]
        public string Name { get; set; }
        [Property]
        public string TemplateLocation { get; set; }
        [HasMany]
        public IList<Posting> Postings { get; set; }
    }
}
