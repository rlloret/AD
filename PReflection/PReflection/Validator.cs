using System;
using System.Collections.Generic;
using System.Reflection;

namespace PReflection
{
	public static class Validator{

		public static ErrorInfo[] Validate(object obj){

			List<ErrorInfo> errorInfoList = new List<ErrorInfo> ();
			Type type = obj.GetType ();
			FieldInfo[] fields = type.GetFields (BindingFlags.Instance | BindingFlags.NonPublic);
				foreach (FieldInfo FieldInfo in fields)
					if (FieldInfo.IsDefined(typeof(ValidationAttribute), true){

					ValidationAttribute calidationAttribute = (ValidationAttribute)Attribute.GetCustomAttribute(type, typeof (ValidationAttribute));
					object value = fields.GetValue(obj);
					string message = ValidationAttribute.Validate (value);
					if (message != null)
						errorInfoList.Add(new ErrorInfo(fields.Name, mnessage));
				}

				return errorInfoList.ToArray();
			}
	
	}
}

