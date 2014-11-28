using System;
namespace PReflection
{

	[Entity(TableName = "category")]
	public class Categoria
	{

		public Categoria (ulong id, string nombre){

			this.id = id;
			[NotBlank]
			this.nombre = nombre;
		}


		[IdAtribute]
		public ulong id;
		public string nombre;


		public ulong Id{

			get {return id;}
			set {id = value;}

		}

		public string Nombre{

			get {return nombre;}
			set {nombre = value;}

		}

	}

}