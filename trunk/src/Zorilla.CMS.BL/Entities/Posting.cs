using System;
using System.Linq;
using System.Collections.Generic;
using Castle.ActiveRecord;

namespace Zorilla.CMS.BL.Entities
{
    [ActiveRecord]
    public class Posting : ActiveRecordBase<Posting>
    {
        [PrimaryKey]
        public long Id { get; set; }
        [Property]
        public string Name { get; set; }
        [BelongsTo]
        public Template Template { get; set; }
        [BelongsTo]
        public Channel Channel { get; set; }
        [HasMany]
        public IList<PostingProperty> Properties { get; set; }

        public object GetProperty(string propertyName, Type type)
        {
            if (type == typeof(int)) return GetProperty<int>(propertyName);
            if (type == typeof(double)) return GetProperty<double>(propertyName);
            if (type == typeof(string)) return GetProperty<string>(propertyName);
            return null;
        }

        public T GetProperty<T>(string propertyName) 
        {
            if (Properties == null) return default(T);
            PostingProperty property = Properties.FirstOrDefault(p => p.Name == propertyName);
            if (property == null) return default(T);
            object o = null;
            if (typeof(T) == typeof(int)) o = property.IntValue; 
            if (typeof(T) == typeof(string)) o = property.StringValue;
            if (typeof(T) == typeof(double)) o = property.DoubleValue;
            
            return (T) o;
        }

        public void SetProperty<T>(string propertyName, T value)
        {
            PostingProperty property = Properties.FirstOrDefault(p => p.Name == propertyName);
            if (property == null)
            {
                property = new PostingProperty{ Posting = this, Name = propertyName};
                Properties.Add(property);
            }
            object val = value;
            if (typeof(T) == typeof(int)) property.IntValue = (int) val;
            if (typeof(T) == typeof(string)) property.StringValue = (string) val;
            if (typeof(T) == typeof(double)) property.DoubleValue = (double) val;

            property.Save();
        }
    }
}
