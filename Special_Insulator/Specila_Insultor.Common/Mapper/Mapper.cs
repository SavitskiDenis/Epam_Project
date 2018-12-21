using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mapper
{
    public class Mapper
    {
        public static N MapToItem<C,N>(C create) where C: class where N: class,new()
        {
            N toItem = new N();
            var cProperties = typeof(C).GetProperties();
            var nProperties = typeof(N).GetProperties();

            foreach(var property in cProperties)
            {
                var findProperty = nProperties.FirstOrDefault(item => item.Name == property.Name);

                if(findProperty !=null)
                {
                    if(findProperty.PropertyType.Name == "DateTime" && property.PropertyType.Name == "String")
                    {
                        var value = property.GetValue(create,null);
                        string[] dates = value.ToString().Split('/');
                        DateTime date = new DateTime(int.Parse(dates[2]),int.Parse(dates[1]),int.Parse(dates[0]));
                        findProperty.SetValue(toItem,date);
                    }
                    else if(findProperty.PropertyType.Name == property.PropertyType.Name)
                    {
                        var value = property.GetValue(create, null);
                        findProperty.SetValue(toItem, value);
                    }
                }

            }


            return toItem;
        }
    }
}
