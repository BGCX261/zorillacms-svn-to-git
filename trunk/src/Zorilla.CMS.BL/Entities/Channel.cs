using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Zorilla.CMS.BL.Entities
{
    [Serializable]
    [ActiveRecord]
    public class Channel : ActiveRecordBase<Channel>, IEquatable<Channel>, IComparable<Channel>
    {
        [PrimaryKey]
        public long Id { get; set; }
        [Property]
        public string Name { get; set; }
        [Property]
        public string TextId { get; set; }
        [Property]
        public int Ordering { get; set; }
        [Property]
        public string Url { get; set; }


        [HasMany]
        public IList<Channel> SubChannels { get; set; }
        [BelongsTo]
        public Channel Parent { get; set; }
        [HasMany]
        public IList<Posting> Postings { get; set; }

        public bool IsRoot
        {
            get { return Parent == null; }
        }

        public bool Equals(Channel other)
        {
            return Id == other.Id;
        }

        public int CompareTo(Channel other)
        {
            return Ordering.CompareTo(other.Ordering);
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
