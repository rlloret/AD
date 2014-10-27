using System;
using Gtk;

namespace PArticulo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Conexion
			App.Instance.DbConnection = new MySqlConnection("DataSource=localhost;" +
			                                                "Database=dbprueba;" +
			                                                "User ID=root;" +
			                                                "Password=sistemas");
			App.Instance.DbConnection.Open ();


			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
