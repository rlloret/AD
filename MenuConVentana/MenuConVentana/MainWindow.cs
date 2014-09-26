using System;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBotonNuevoClicked (object sender, EventArgs e)
	{
		MySqlConnection mySqlConnection = new MySqlConnection(
		                                                      "DataSource=localhost;" +
		                                                      "Database=dbprueba;" +
		                                                      "User ID=root;" +
		                                                      "Password=sistemas");	                                                     


		mySqlConnection.Open ();

		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();

		mySqlCommand.CommandText =
				string.Format("insert into categoria (nombre) values ('{0}')",DateTime.Now);


			mySqlCommand.ExecuteNonQuery ();
	
		mySqlConnection.Close ();

		campoMostrar.LabelProp = ("Insertado");

	}

	protected void OnBotonVerClicked (object sender, EventArgs e)
	{
		MySqlConnection mySqlConnection = new MySqlConnection(
		                                                      "DataSource=localhost;" +
		                                                      "Database=dbprueba;" +
		                                                      "User ID=root;" +
		                                                      "Password=sistemas");	                                                     


		mySqlConnection.Open ();


		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();


		mySqlCommand.CommandText = "select * from categoria";
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();


		while (mySqlDataReader.Read()) {

			object id = mySqlDataReader["id"];
			object nombre = mySqlDataReader["nombre"];
			Console.WriteLine ("id={0} nombre={1}", id, nombre);


			campoMostrar.LabelProp = ("Hola");

		}

		mySqlDataReader.Close ();
		mySqlConnection.Close ();
	}
}
