using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Dapper;

namespace DapperPlus.Mapper
{
    public class EntityMapper<T> : SqlMapper.ITypeMap
    {
        private readonly List<PropertyMapper> properties;
        private readonly List<SqlMapper.ITypeMap> maps;

        public EntityMapper()
        {
            EntityType = typeof(T);

            properties = new List<PropertyMapper>();
            maps = new List<SqlMapper.ITypeMap>(2);
            maps.Add(new CustomPropertyTypeMap(EntityType, PropertySelect));
            maps.Add(new DefaultTypeMap(EntityType));
        }

        public Type EntityType
        {
            get;
            private set;
        }

        public string TableName
        {
            get;
            private set;
        }

        public IEnumerable<PropertyMapper> Properties
        {
            get
            {
                return properties;
            }
        }

        protected EntityMapper<T> Table(string table)
        {
            TableName = table;
            return this;
        }

        protected PropertyMapper Map(Expression<Func<T, object>> expression)
        {
            PropertyInfo property = ReflectionUtil.GetProperty(expression) as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("Expression is not property expression");
            }
            return Map(property);
        }

        protected PropertyMapper Map(PropertyInfo propertyInfo)
        {
            PropertyMapper mapper = new PropertyMapper(propertyInfo);
            AssertDuplicateProperty(mapper);
            properties.Add(mapper);
            return mapper;
        }

        protected virtual void AutoMapping(Func<Type, PropertyInfo, bool> @where = null)
        {
            PropertyInfo[] propertyInfos = EntityType.GetProperties();
            foreach (var property in propertyInfos)
            {
                if (Properties.Any(p => string.Equals(p.Property.Name, property.Name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    continue;
                }

                if (@where != null && !@where(EntityType, property))
                {
                    continue;
                }

                Map(property);
            }
            //SqlMapper.SetTypeMap(entityType, this); // set to dapper's sqlmapper
        }

        private void AssertDuplicateProperty(PropertyMapper propertyMapper)
        {
            if (Properties.Any(p => string.Equals(p.ColumnName, propertyMapper.ColumnName, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new ArgumentException($"Duplicate mapping for property {propertyMapper.ColumnName} detected.");
            }
        }

        private PropertyInfo PropertySelect(Type type, string name)
        {
            return properties.FirstOrDefault(p => string.Equals(p.Property.Name, name, StringComparison.CurrentCultureIgnoreCase)).Property;
        }

        ConstructorInfo SqlMapper.ITypeMap.FindConstructor(string[] names, Type[] types)
        {
            foreach (var map in maps)
            {
                ConstructorInfo result = map.FindConstructor(names, types);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        ConstructorInfo SqlMapper.ITypeMap.FindExplicitConstructor()
        {
            foreach (var map in maps)
            {
                var result = map.FindExplicitConstructor();
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        SqlMapper.IMemberMap SqlMapper.ITypeMap.GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            foreach (var map in maps)
            {
                var result = map.GetConstructorParameter(constructor, columnName);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        SqlMapper.IMemberMap SqlMapper.ITypeMap.GetMember(string columnName)
        {
            foreach (var map in maps)
            {
                var result = map.GetMember(columnName);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}