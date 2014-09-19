using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	public class Menu
	{
		public Menu ()
		{
			Console.WriteLine ("0. Salir");
			Console.WriteLine ("1. Nuevo");
			Console.WriteLine ("2. Modificar");
			Console.WriteLine ("3. Eliminar");
			Console.WriteLine ("4. Ver");


			String seleccion;
			seleccion = Console.ReadLine();
			Console.WriteLine("El texto introducido es: " + seleccion);

		}
	}
}

