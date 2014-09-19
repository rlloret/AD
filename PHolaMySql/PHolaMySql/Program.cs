using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			MySqlConnection mySqlConnection = new MySqlConnection(/*Creamos la conex*/
				"DataSource=localhost;" +
				"Database=dbprueba;" +
				"User ID=root;" +
				"Password=sistemas");	                                                     
		

			mySqlConnection.Open ();/*Abrir el hilo de conex*/

			Console.WriteLine ("Hola Mysql");

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();

			/*mySqlCommand.CommandText =
				string.Format("insert into categoria (nombre) values ('{0}')",DateTime.Now);


			mySqlCommand.ExecuteNonQuery ();*/

			/*ExecuteNonQuery se utiliza para insert etc.no devuelve*/
			/*ExecuteReader se utiliza en select.devuelve un mySqlDataReader*/
			/*Propiedades DataReader: FieldCount,GetName etc..*/

			mySqlCommand.CommandText = "select * from categoria";
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();/*MySqlDataReader(metainformacion:columnas,nombre,tipo)*/


			Console.WriteLine ("FieldCount = {0}", mySqlDataReader.FieldCount);
			for (int index=0; index < mySqlDataReader.FieldCount; index++)

				Console.WriteLine ("column{0}={1}",index, mySqlDataReader.GetName (index));

			while (mySqlDataReader.Read()) {

				object id = mySqlDataReader["id"];
				object nombre = mySqlDataReader["nombre"];
				Console.WriteLine ("id={0} nombre={1}", id, nombre);

			}

			mySqlDataReader.Close ();
			mySqlConnection.Close ();


			Menu men = new Menu(); 
		}

	}
}
