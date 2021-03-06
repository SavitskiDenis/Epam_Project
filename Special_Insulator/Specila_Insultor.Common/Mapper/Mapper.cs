﻿using SpecialInsulator.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialInsulator.Common.Mapper
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
                        string[] dates = value.ToString().Split(new char[] { '/' ,'.'});
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

        public static E UpdateInfo <T,E> (E edit,T editor)
        {
            var tProperties = typeof(T).GetProperties();
            var eProperties = typeof(E).GetProperties();

            foreach (var property in eProperties)
            {
                var findProperty = tProperties.FirstOrDefault(item => item.Name == property.Name);

                if (findProperty != null )
                {
                    if(findProperty.PropertyType.Name == "DateTime" && property.PropertyType.Name == "String")
                    {
                        DateTime date = (DateTime)findProperty.GetValue(editor, null);
                        string myDate = "";
                        if (date.Day < 10)
                        {
                            myDate += "0" + date.Day + ".";
                        }
                        else
                        {
                            myDate += date.Day + ".";
                        }
                        if (date.Month < 10)
                        {
                            myDate += "0" + date.Month + ".";
                        }
                        else
                        {
                            myDate += date.Month + ".";
                        }
                        property.SetValue(edit, myDate+date.Year);
                    }
                    else if(findProperty.PropertyType.Name == property.PropertyType.Name)
                    {
                        var value = findProperty.GetValue(editor, null);
                        property.SetValue(edit, value);
                    }
                        
                }

            }

            return edit;
        }

        public static List<T> MapCollection<T>(List<WorkerAndName> oldCol) where T:class,new()
        {
            List<T> workers = new List<T>();
            foreach (var item in oldCol)
            {
                T myItem = new T();
                myItem = Mapper.MapToItem<Person, T>(item.Person);
                myItem = Mapper.UpdateInfo<Worker, T>(myItem, item.Worker);

                workers.Add(myItem);
            }

            return workers;
        }
    }
}
