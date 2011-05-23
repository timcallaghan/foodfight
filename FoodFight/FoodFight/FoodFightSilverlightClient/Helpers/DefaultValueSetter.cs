using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace FoodFightSilverlightClient.Helpers
{
    public static class DefaultValueSetter
    {
        public static void InitializeDefaultValues(object entity)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                MethodInfo propertySetter = property.GetSetMethod();
                if (propertySetter != null)
                {
                    DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)
                        property.GetCustomAttributes(typeof(DefaultValueAttribute), true).FirstOrDefault();

                    if (defaultValueAttribute != null)
                    {
                        object defaultValue = 
                            Convert.ChangeType(defaultValueAttribute.Value, property.PropertyType, CultureInfo.InvariantCulture);

                        propertySetter.Invoke(entity, new object[] { defaultValue });
                    }
                }
            }
        }
    }
}
