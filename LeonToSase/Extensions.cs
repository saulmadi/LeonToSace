using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace LeonToSase
{
    public static class Extensions
    {
        public static List<T> ToList<T>(this EnumerableRowCollection<DataRow> rows) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            var result = new List<T>();

            foreach (var row in rows)
            {
                var item = CreateItemFromRow<T>(row, properties);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            var item = new T();
            foreach (var property in properties)
                if (property.PropertyType == typeof(DayOfWeek))
                {
                    var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else
                {
                    if (!row.Table.Columns.Contains(property.Name)) continue;
                    var value = row[property.Name];
                    property.SetValue(item, Convert.ChangeType(value, property.PropertyType), null);
                }
            return item;
        }
    }
}