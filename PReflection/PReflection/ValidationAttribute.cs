using System;

namespace PReflection
{
	public abstract class ValidationAttribute: Attribute{

		public abstract String Validate(object obj);
	}
}

