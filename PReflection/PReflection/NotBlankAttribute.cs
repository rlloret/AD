using System;

namespace PReflection
{
	public class NotBlankAttribute: ValidationAttribute{

		private string  message="No puede estar vacio";

		public override string Validate (object value){
//			if (value == null)
//				return message;
//			string stringValue = value.ToString ();
//			if (stringValue.Trim () == "")
//				return message;
//			return null;

			if (value == null || value.ToString ().Trim () == "")
				return message;
			return null;
		}

	}
}

