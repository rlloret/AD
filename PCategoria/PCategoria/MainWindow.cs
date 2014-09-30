using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	

	private ListStore listStore;
	private MySqlConnection mySqlConnection;    
	private MySqlCommand mySqlCommand;




	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		treeView.AppendColumn ("Id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("Nombre", new CellRendererText (), "text", 1);

		listStore = new ListStore (typeof(String), typeof(String));/*Pinta los contenidos dentro del treeview*/
		//listStore = new ListStore (typeof(ulong), typeof(String));//Para no parsear 
		treeView.Model = listStore; 

		LecturaDeDatos ();

	}

	protected void LecturaDeDatos()
	{

		mySqlConnection = new MySqlConnection("DataSource=localhost;" +
		                                      "Database=dbprueba;" +
		                                      "User ID=root;" +
		                                      "Password=sistemas");
		mySqlConnection.Open ();

	    mySqlCommand = mySqlConnection.CreateCommand ();

		mySqlCommand.CommandText = "select * from categoria";

		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();


		//Console.WriteLine ("id.GetType()={0}", IDbCommand.GetType());//Muestra el tipo de dato utilizado

		while (mySqlDataReader.Read()) {

			object id = mySqlDataReader["id"].ToString();
			object nombre = mySqlDataReader["nombre"];
			listStore.AppendValues (id, nombre);

		}
		mySqlDataReader.Close ();

	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		mySqlConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		//listStore.AppendValues ("1", "uno");

		mySqlCommand.CommandText = string.Format("insert into categoria (nombre) values ('{0}')","Nuevo "+ DateTime.Now);


		mySqlCommand.ExecuteNonQuery ();//Si el insert no funciona, se lanza una excepción

	}

	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		listStore.Clear();
		LecturaDeDatos ();
	}

}
