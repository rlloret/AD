using PNotebook;
using System;
using Gtk;

using PArticulo;
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
		treeView.Model = listStore; 

		LecturaDeDatos ();
		treeView.Selection.Changed += delegate {

			bool hasSelected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive  = hasSelected;
			deleteAction.Sensitive = hasSelected;

		};






		ArticuloAction.Activated += delegate{

			//addPage (new ArticuloView(),"Articulo");
			addPage (new MyTreeView(),"Articulo");

		};
		CategoriaAction.Activated += delegate{

			//addPage (new ArticuloView(),"Categoria");
			addPage (new MyTreeView(),"Categoria");

		};

		notebook1.SwitchPage += delegate{
			onPageChanged();
		};


		notebook1.PageRemoved += delegate {
			Console.WriteLine("notebook1.PageRemoved notebook.CurrentPage = {0}", notebook1.CurrentPage);
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


	private void onPageChanged(){

		Console.WriteLine("onPageChanged notebook.CurrentPage = {0}", notebook1.CurrentPage);

	}

	private void addPage (Widget widget,string label)
	{

		HBox hBox = new HBox ();
		hBox.Add (new Label (label));
		Button button = new Button (new Image(Stock.Cancel, IconSize.Button));
		hBox.Add (button);
		hBox.ShowAll ();

		notebook1.CurrentPage = notebook1.AppendPage (widget, hBox);

		button.Clicked += delegate {
			widget.Destroy();
			if (notebook1.CurrentPage == -1)
				onPageChanged();

		};


	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
