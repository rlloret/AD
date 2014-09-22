using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	public class Menu
	{
		public Menu ()
		{

			MySqlConnection mySqlConnection = new MySqlConnection(/*Creamos la conex*/
			                                                      "DataSource=localhost;" +
			                                                      "Database=dbprueba;" +
			                                                      "User ID=root;" +
			                                                      "Password=sistemas");	                                                     

			mySqlConnection.Open ();
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();


			Console.WriteLine ("0. Salir");
			Console.WriteLine ("1. Nuevo");
			Console.WriteLine ("2. Modificar");
			Console.WriteLine ("3. Eliminar");
			Console.WriteLine ("4. Ver");


			String seleccion;
			seleccion = Console.ReadLine();
			Console.WriteLine("El texto introducido es: " + seleccion);

			do {

			switch (seleccion) {

				case "0":
		
				break;
				case "1":
				
				break;
				case "2":

				break;
				case "3":

				break;
				case "4":
				

				mySqlCommand.CommandText = "select * from categoria";
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();/*MySqlDataReader(metainformacion:columnas,nombre,tipo)*/


				while (mySqlDataReader.Read()) {

					object id = mySqlDataReader["id"];
					object nombre = mySqlDataReader["nombre"];
					Console.WriteLine ("id={0} nombre={1}", id, nombre);

				}

		
				break;
				}

				}

		 while(seleccion!=0)

		
	}
}

