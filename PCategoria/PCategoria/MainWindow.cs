using System;
using Gtk;
using System.Data;

using PCategoria;
using SerpisAd;

public partial class MainWindow: Gtk.Window
{	

	private ListStore listStore;
	private IDbConnection dbConnection;    
	private IDbCommand dbCommand;




	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		dbConnection = App.Instance.DbConnection;

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
			bool hasSelected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive  = hasSelected;
			deleteAction.Sensitive = hasSelected;/*Lo que devuelve el CountSR cambia el estado de Sensitive*/

	};


	}

	protected void LecturaDeDatos()
	{

		IDbCommand dbCommand = dbConnection.CreateCommand ();

		dbCommand.CommandText = "select * from categoria";

		IDataReader dataReader = dbCommand.ExecuteReader ();


		//Console.WriteLine ("id.GetType()={0}", IDbCommand.GetType());//Muestra el tipo de dato utilizado

		while (dataReader.Read()) {

			object id = dataReader["id"].ToString();
			object nombre = dataReader["nombre"];
			listStore.AppendValues (id, nombre);

		}
		dataReader.Close ();

	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		//listStore.AppendValues ("1", "uno");

		dbCommand.CommandText = string.Format("insert into categoria (nombre) values ('{0}')","Nuevo "+ DateTime.Now);


		dbCommand.ExecuteNonQuery ();//Si el insert no funciona, se lanza una excepción

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


			dbCommand.CommandText = string.Format ("delete from categoria where id ={0}", id);
			dbCommand.ExecuteNonQuery ();/*Devuelve las filas afectadas por el ultimo comando*/


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
		//throw new NotImplementedException ();
		TreeIter treeIter;/*Apunta la posición del arbol*/
		treeView.Selection.GetSelected (out treeIter);/*Devuelve la posicion*/
		object id = listStore.GetValue (treeIter, 0);/*columna 0 de la fila seleccionada*/
		new CategoriaView (id);
	}

}
