using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;  // reflection namespace
using ERP.BOL;
using GenericFunctions;

namespace ERP.BLL
{
    public class BaseBLL
    {
        protected string InsertSQL(BaseBOL obj)
        {
            PropertyInfo[] propertyInfos;
            Type t = obj.GetType();
            propertyInfos = t.GetProperties();
            // sort properties by name
            Array.Sort(propertyInfos,
                    delegate(PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                    { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            // write property names
            StringBuilder sql = new StringBuilder();
            sql.Append(@"INSERT INTO `" + GetEntityName(obj) + "`(");
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                // prop = prop + propertyInfo.Name + " , " + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + ", ";
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length <= 0 ||
                    (
                    (((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText != "PrimaryKey")
                    &&
                    (((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText != "Exclude")
                    )
                    )
                    
                {
                    sql.Append("`" + propertyInfo.Name + "`,");
                }

            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(")  VALUES (");
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                // prop = prop + propertyInfo.Name + " , " + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + ", ";
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length <= 0 ||
                    (
                    (((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText != "PrimaryKey")
                    &&
                    (((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText != "Exclude")
                    )
                    )
                    
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        sql.Append("'" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "',");
                    }
                    else if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        sql.Append("STR_TO_DATE('" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "', '%c/%e/%Y %r'),");
                    }
                    else
                    {
                        sql.Append("" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + ",");
                    }
                }

            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(")");
            return sql.ToString();
        }
        protected string UpdateSQL(BaseBOL obj)
        {
            PropertyInfo[] propertyInfos;
            Type t = obj.GetType();
            propertyInfos = t.GetProperties();
            // sort properties by name
            Array.Sort(propertyInfos,
                    delegate(PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                    { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            // write property names
            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE `" + GetEntityName(obj) + "` SET ");
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length <= 0 ||
                    (
                    (((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText != "PrimaryKey")
                    &&
                    (((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText != "Exclude")
                    )
                    )
                {
                    sql.Append("`" + propertyInfo.Name + "` = ");
                }
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length <= 0 ||
                   (
                    (((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText != "PrimaryKey")
                    &&
                    (((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText != "Exclude")
                    )
                    )
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        sql.Append("'" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "',");
                    }
                    else if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        sql.Append("STR_TO_DATE('" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "', '%c/%e/%Y %r'),");
                    }
                    else
                    {
                        sql.Append("" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + ",");
                    }
                }

            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" WHERE ");
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length > 0 &&
                   ((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText == "PrimaryKey")
                {
                    sql.Append("`" + propertyInfo.Name + "` = ");
                }
                // prop = prop + propertyInfo.Name + " , " + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + ", ";
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length > 0 &&
                    ((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText == "PrimaryKey")
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        sql.Append("'" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "'");
                    }
                    else if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        sql.Append("STR_TO_DATE('" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "', '%c/%e/%Y %r')");
                    }
                    else
                    {
                        sql.Append("" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "");
                    }
                }

            }
            return sql.ToString();
        }
        protected string DeleteSQL(BaseBOL obj)
        {
            PropertyInfo[] propertyInfos;
            Type t = obj.GetType();
            propertyInfos = t.GetProperties();
            // sort properties by name
            Array.Sort(propertyInfos,
                    delegate(PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                    { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            // write property names
            bool primaryKeyFound = false;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"DELETE FROM `" + GetEntityName(obj) + "` ");
            sql.Append(" WHERE ");
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length > 0 &&
                   ((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText == "PrimaryKey")
                {
                    sql.Append("`" + propertyInfo.Name + "` = ");
                    primaryKeyFound = true;
                }
                // prop = prop + propertyInfo.Name + " , " + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + ", ";
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length > 0 &&
                    ((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText == "PrimaryKey")
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        sql.Append("'" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "'");
                    }
                    else if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        sql.Append("STR_TO_DATE('" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "', '%c/%e/%Y %r')");
                    }
                    else
                    {
                        sql.Append("" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "");
                    }
                }
                if (primaryKeyFound)
                {
                    break;
                }

            }
            return sql.ToString();
        }
        protected string SelectSQL(BaseBOL obj)
        {
            PropertyInfo[] propertyInfos;
            Type t = obj.GetType();
            propertyInfos = t.GetProperties();
            // sort properties by name
            Array.Sort(propertyInfos,
                    delegate(PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                    { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            // write property names
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT ");//(
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                // prop = prop + propertyInfo.Name + " , " + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + ", ";
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length > 0 &&
                    ((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText == "Exclude")
                {
                    continue;
                }
                else
                {
                    sql.Append("`" + propertyInfo.Name + "`,");
                }

            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" FROM  `" + GetEntityName(obj) + "`");
            sql.Append("    WHERE    "); 
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length > 0 &&
                    ((HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText == "Exclude")
                {
                    continue;
                }
                {
                    if (propertyInfo.PropertyType == typeof(string) &&
                        !string.IsNullOrEmpty(Convert.ToString(obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null)))
                        )
                    {
                        sql.Append("`"+ propertyInfo.Name +"` = ");
                        sql.Append("'" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "'");
                        sql.Append(" AND");
                    }
                    else if (propertyInfo.PropertyType == typeof(int))
                    {
                        if (Convert.ToInt32(obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null)) > 0)
                        {
                            sql.Append("`" + propertyInfo.Name + "` = ");
                            sql.Append("" + obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null) + "");
                            sql.Append(" AND");
                        }
                    }
                }

            }
            if (sql.Length > 0)
            {
            //    sql = sql.Remove(sql.Length - 3, 3);
                sql.Append(" 1 ");
            }
            //sql.Append(")");
            return sql.ToString();
        }

        public string GetEntityName(BaseBOL obj)
        {
            Type t = obj.GetType();
            var customAttributes = (HelpAttribute[])t.GetCustomAttributes(typeof(HelpAttribute), true);
            if (customAttributes.Length > 0)
            {
                var myAttribute = customAttributes[0];
                string value = myAttribute.HelpText;
                // TODO: Do something with the value
                return value;
            }
            return string.Empty;
        }
    }
}
 