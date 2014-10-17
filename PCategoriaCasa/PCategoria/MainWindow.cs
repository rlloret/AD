using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;

using PCategoria;

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

	//	treeView.Selection.Changed += selectionChanged; /*Cuando se produce el evento changed llama a la funcion */
	//	treeView.Selection.Mode = SelectionMode.Multiple; /*Multiple selección en el treeView*/
		treeView.Selection.Changed += delegate {

			//OnEditActionActivated.Sensitive = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive  = treeView.Selection.CountSelectedRows() > 0;
			deleteAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;/*Lo que devuelve el CountSR cambia el estado de Sensitive*/

	};


	}

	/*
	 * Lee los datos y pinta el liststore
	 */

	protected void LecturaDeDatos()
	{

		MySqlCommand mySqlCommand = ConexionSQL().CreateCommand ();

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

	/*
	 * Crea la conexion con la base de datos
	 */

	public static MySqlConnection ConexionSQL(){

		MySqlConnection mySqlConnection = new MySqlConnection("DataSource=localhost;" +
		                                      "Database=dbprueba;" +
		                                      "User ID=root;" +
		                                      "Password=sistemas");
		mySqlConnection.Open ();
		return (mySqlConnection);

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



	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{

		if (!ConfirmDelete())
			return;

			TreeIter treeIter;/*Apunta la posición del arbol*/
			treeView.Selection.GetSelected (out treeIter);/*Devuelve la posicion*/
			object id = listStore.GetValue (treeIter, 0);/*columna 0 de la fila seleccionada*/


			mySqlCommand.CommandText = string.Format ("delete from categoria where id ={0}", id);
			mySqlCommand.ExecuteNonQuery ();/*Devuelve las filas afectadas por el ultimo comando*/


	}



	public bool ConfirmDelete(){

		return Confirm ("Realmente quieres eliminar?");
	}



	public bool Confirm(String text){

		MessageDialog messageDialog = new MessageDialog (/*Ventana de confirmación de la eliminación*/
		      this,
		      DialogFlags.Modal,
		      MessageType.Question,
		      ButtonsType.YesNo,
		      text
		      );

		messageDialog.Title = "Estas seguro";
		ResponseType response = (ResponseType)messageDialog.Run ();
		messageDialog.Destroy ();


		return response == ResponseType.Yes;
	}



	protected void OnEditActionActivated (object sender, EventArgs e)
	{

		TreeIter treeIter;
		treeView.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		CategoriaView categoriaview = new CategoriaView (id);

	}

}
