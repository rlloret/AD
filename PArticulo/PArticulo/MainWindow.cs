using Gtk;
using System;
using System.Data;

using PArticulo;
using SerpisAd;

public partial class MainWindow: Gtk.Window

{	

	private IDbConnection dbConnection;
	private ListStore listStore,listStoreCat;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction.Sensitive = false;
		editAction.Sensitive = false;

		dbConnection = App.Instance.DbConnection;

		//ARTICULO
		treeviewArticulo.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeviewArticulo.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeviewArticulo.AppendColumn ("categoria", new CellRendererText (), "text", 2);
		treeviewArticulo.AppendColumn ("precio", new CellRendererText (), "text", 3);
		listStore = new ListStore (typeof(ulong), typeof(string),typeof(ulong), typeof(string));
		//CATEGORIA
		treeviewCategoria.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeviewCategoria.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		listStoreCat = new ListStore (typeof(ulong), typeof(string));


		treeviewArticulo.Model = listStore;
		treeviewCategoria.Model = listStoreCat;

		fillListStore ();
		fillListStoreCat ();

		treeviewArticulo.Selection.Changed += selectionChanged;
		treeviewCategoria.Selection.Changed += selectionChangedCat;





	}
	private void selectionChanged (object sender, EventArgs e) {
		bool hasSelected = treeviewArticulo.Selection.CountSelectedRows () > 0;
		deleteAction.Sensitive = hasSelected;
		editAction.Sensitive = hasSelected;
	}

	private void selectionChangedCat (object sender, EventArgs e) {
		bool hasSelected = treeviewCategoria.Selection.CountSelectedRows () > 0;
		deleteActionCat.Sensitive = hasSelected;
		editAction1.Sensitive = hasSelected;
	}



	private void fillListStore() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from articulo";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			object categoria = dataReader ["categoria"];
			object precio = dataReader ["precio"].ToString ().Replace(',','.');
			listStore.AppendValues (id, nombre, categoria, precio);
		}
		dataReader.Close ();
	}


	private void fillListStoreCat() {
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from categoria";

		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			object id = dataReader ["id"];
			object nombre = dataReader ["nombre"];
			listStoreCat.AppendValues (id, nombre);
		}
		dataReader.Close ();
	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		string insertSql = string.Format(
			"insert into articulo (nombre,precio) values ('NuevoArticulo','00.00')"
			//"Nuevo " + DateTime.Now,"00"
			);
		Console.WriteLine ("insertSql={0}", insertSql);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = insertSql;

		dbCommand.ExecuteNonQuery ();
	}

	protected void OnRefreshAction1Activated (object sender, EventArgs e)
	{
		listStore.Clear ();
		fillListStore ();
	}

	//BORRAR CATEGORIA
	protected void OnDeleteActionCatActivated (object sender, EventArgs e)
	{
		MessageDialog messageDialog = new MessageDialog (
			this,
			DialogFlags.Modal,
			MessageType.Question,
			ButtonsType.YesNo,
			"¿Quieres eliminar el registro?"
			);
		messageDialog.Title = Title;
		ResponseType response = (ResponseType) messageDialog.Run ();
		messageDialog.Destroy ();

		if (response != ResponseType.Yes)
			return;

		TreeIter treeIter;
		treeviewCategoria.Selection.GetSelected (out treeIter);
		object id = listStoreCat.GetValue (treeIter, 0);
		string deleteSql = string.Format ("delete from categoria where id={0}", id);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = deleteSql;

		dbCommand.ExecuteNonQuery ();
	}

	//BORRAR ARTICULO
	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		MessageDialog messageDialog = new MessageDialog (
			this,
			DialogFlags.Modal,
			MessageType.Question,
			ButtonsType.YesNo,
			"¿Quieres eliminar el registro?"
			);
		messageDialog.Title = Title;
		ResponseType response = (ResponseType) messageDialog.Run ();
		messageDialog.Destroy ();

		if (response != ResponseType.Yes)
			return;

		TreeIter treeIter;
		treeviewArticulo.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		string deleteSql = string.Format ("delete from articulo where id={0}", id);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = deleteSql;

		dbCommand.ExecuteNonQuery ();
	}

	//EDITAR ARTICULO
	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeviewArticulo.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		ArticuloView articuloView = new ArticuloView (id);
	}

	//EDITAR CATEGORIA
	protected void OnEditAction1Activated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeviewCategoria.Selection.GetSelected (out treeIter);
		object id = listStoreCat.GetValue (treeIter, 0);
		CategoriaView categoriaView = new CategoriaView (id);
	}

	//REFRESCAR ARTICULO
	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		listStoreCat.Clear ();
		fillListStoreCat ();
	}


	//AÑADIR CATEGORIA
	protected void OnAddActionCatActivated (object sender, EventArgs e)
	{
		string insertSql = string.Format(
			"insert into categoria (nombre) values ('Nueva Categoria')"
			);
		Console.WriteLine ("insertSql={0}", insertSql);
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = insertSql;

		dbCommand.ExecuteNonQuery ();
	}

}
