using System;

namespace PReflection
{
	public class ErrorInfo{

		string property = "";
		string message = "";

		public ErrorInfo (string property, string message){

			property = property;
			message = message;
		}
		public string Property{ get { return property; } }
		public string Message{ get { return message; }}

	}
}

