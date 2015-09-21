using System;
using System.Collections;
using System.Reflection;
using Utility;

namespace SimpleTaskSystem.Enum
{
    public class EnumAppService : IEnumAppService
    {

        public string GetEnumDescription(object e)
        {
            //获取枚举成员的Type对象
            Type t = e.GetType();
            //获取Type对象的所有字段
            FieldInfo[] ms = t.GetFields();
            //遍历所有字段
            foreach (FieldInfo f in ms)
            {
                if (f.Name != e.ToString())
                {
                    continue;
                }
                if (f.IsDefined(typeof(EnumDisplayNameAttribute), true))
                {
                    var enumDisplayNameAttribute = f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute;
                    if (enumDisplayNameAttribute != null)
                        return enumDisplayNameAttribute.DisplayName;
                }
            }
            return e.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public string GetSelectList()
        {
            Hashtable ht = new Hashtable();
            Type type = typeof(TaskLevel);
            foreach (object e in System.Enum.GetValues(type))
            {
                ht.Add((Convert.ToInt32(e)).ToString(), GetEnumDescription(e));
                //ht.Add("Text", GetEnumDescription(e));
                //ht.Add("Value", (Convert.ToInt32(e)).ToString());
            }
            return JsonHelper.SerializeObject(ht);
        }
    }
}
