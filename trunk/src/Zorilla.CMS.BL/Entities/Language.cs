using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Zorilla.CMS.BL.Entities
{
    //public interface ILanguage : IEntity, IEquatable<ILanguage>
    //{
    //    int Id { get; set; }
    //    string LanguageCode { get; set; }
    //    string Name { get; set; }
    //}

    [ActiveRecord]
    [Serializable]
    public class Language : ActiveRecordBase<Language>
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Property]
        public string LanguageCode { get; set; }
        [Property]
        public string Name { get; set; }

        public bool Equals(Language other)
        {
            return Id == other.Id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
