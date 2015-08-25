using System;
using Castle.ActiveRecord;


namespace Zorilla.CMS.BL.Entities
{
//    public interface IText 
//    {
//        long Id { get; set; }
//        string TextId { get; set; }
//        ILanguage Language { get; set; }
//        string Value { get; set; }
//    }

    [Serializable]
    [ActiveRecord]
    public class Text : ActiveRecordBase<Text>
    {
        public bool IsCreated { get { return Id != 0; } }

        [PrimaryKey]
        public long Id { get; set; }

        [Property]
        public string TextId { get; set; }

        [Property]
        public string Value { get; set; }

        [BelongsTo]
        public Language Language { get; set; }
    }
}
