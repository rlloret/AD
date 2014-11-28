using System;

namespace PReflection
{
	public class EntityAttribute: Attribute{

		public EntityAttribute(){

			Console.WriteLine ("EntityAttribute constructor");

		}
		public String TableName{ get; set;}

	}
}

