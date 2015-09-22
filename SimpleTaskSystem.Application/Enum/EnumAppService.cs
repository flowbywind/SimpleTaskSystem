using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleTaskSystem.Enum.Dtos;
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
        /// <param name="input"></param>
        /// <returns></returns>
        public GetEnumsOutput GetSelectList(GetEnumsInput input)
        {
            var fullName = "SimpleTaskSystem.Enum." + input.enumType;
            const string assemblyName = "SimpleTaskSystem.Core";
            string path = fullName + "," + assemblyName;
            Type type = Type.GetType(path);
            if (type == null) return null;
            List<EnumDto> Enums = (from object e in System.Enum.GetValues(type)
                                   let Text = GetEnumDescription(e)
                                   where !string.IsNullOrEmpty(Text)
                                   select new EnumDto
                                   {
                                       Value = Convert.ToInt32(e),
                                       Text = Text
                                   }).ToList();
            GetEnumsOutput getEnums = new GetEnumsOutput { Enums = Enums };
            return getEnums;
        }
    }
}
