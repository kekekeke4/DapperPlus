using System;
using System.Reflection;

namespace DapperPlus.Mapper
{
    public class PropertyMapper
    {
        internal PropertyMapper(PropertyInfo propertyInfo)
        {
            Property = propertyInfo;
            ColumnName = Property.Name;
        }

        public PropertyMapper Column(string columnName)
        {
            ColumnName = columnName;
            return this;
        }

        public PropertyMapper PrimaryKey()
        {
            IsPrimaryKey = true;
            return this;
        }

        public PropertyMapper Ignore()
        {
            IsIgnore = true;
            return this;
        }

        public PropertyMapper AutoIncrement()
        {
            IsAutoIncrement = true;
            return this;
        }

        public bool IsAutoIncrement
        {
            get;
            private set;
        }

        public bool IsIgnore
        {
            get;
            private set;
        }

		public bool IsPrimaryKey
        {
            get;
            private set;
        }

        public string ColumnName
        {
            get;
            private set;
        }

        public PropertyInfo Property
        {
            get;
            private set;
        }
    }
}
