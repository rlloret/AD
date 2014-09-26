using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	

	private ListStore listStore;
	private MySqlConnection mySqlConnection;                                                




	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		treeView.AppendColumn ("Id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("Nombre", new CellRendererText (), "text", 1);

		listStore = new ListStore (typeof(String), typeof(String));

		treeView.Model = listStore; 
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		//listStore.AppendValues ("1", "uno");

		mySqlConnection = new MySqlConnection("DataSource=localhost;" +
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
			listStore.AppendValues (id, nombre);

		}




	}

}
