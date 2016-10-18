using System;
using System.Collections.Generic;
using System.Reflection;

namespace Data.Common.Helpers.EF.Extensions
{
    internal class StoredProcedureParserHelper
    {
        public string GetParameterName(PropertyInfo propertyInfo)
        {
            var rValue = propertyInfo.Name;

            // grab the name of the parameter from the attribute, if it's defined.
            var attribute = Attributes.GetAttribute<StoredProcedureParameterAttribute>(propertyInfo);
            if (!string.IsNullOrEmpty(attribute?.ParameterName))
                rValue = attribute.ParameterName;

            return rValue;
        }

        public string GetUserDefinedTableType(PropertyInfo propertyInfo)
        {
            var collectionType = GetCollectionType(propertyInfo.PropertyType);
            var attribute = Attributes.GetAttribute<UserDefinedTableTypeAttribute>(collectionType);

            if (attribute == null)
                throw new InvalidOperationException(
                    $"{propertyInfo.PropertyType} has not been decorated with UserDefinedTableTypeAttribute.");

            return attribute.Name;
        }

        public Type GetCollectionType(Type type)
        {
            if (type.IsGenericType)
            {
                foreach (var interfaceType in type.GetInterfaces())
                {
                    if (interfaceType.GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        return interfaceType.GetGenericArguments()[0];
                    }
                }
            }

            return null;
        }

        public object GetUserDefinedTableValue(PropertyInfo propertyInfo, object storedProcedure)
        {
            var enumerableType = GetCollectionType(propertyInfo.PropertyType);
            var propertyValue = propertyInfo.GetValue(storedProcedure, null);

            var generator = new UserDefinedTableGenerator(enumerableType, propertyValue);

            var table = generator.GenerateTable();

            return table;
        }

        public bool IsUserDefinedTableParameter(PropertyInfo propertyInfo)
        {
            var collectionType = GetCollectionType(propertyInfo.PropertyType);

            return collectionType != null;
        }

        public bool ParameterIsMandatory(StoredProcedureParameterOptions options)
        {
            return (options & StoredProcedureParameterOptions.Mandatory) ==
                   StoredProcedureParameterOptions.Mandatory;
        }
    }
}