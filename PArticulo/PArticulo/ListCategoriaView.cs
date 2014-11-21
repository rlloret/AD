using Gtk;
using System;
using System.Data;

using SerpisAd;

namespace PArticulo
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ListCategoriaView : Gtk.Bin
	{
		private IDbConnection dbConnection;
		private ListStore listStore;

		public ListCategoriaView ()
		{
			this.Build ();

			deleteAction.Sensitive = false;
			editAction.Sensitive = false;

			dbConnection = App.Instance.DbConnection;


			treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
			treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
			listStore = new ListStore (typeof(ulong), typeof(string));
			treeView.Model = listStore;

			fillListStore ();

			treeView.Selection.Changed += selectionChanged;

			refreshAction.Activated += delegate {
				listStore.Clear();
				fillListStore();
			};

		}

		private void selectionChanged (object sender, EventArgs e) {
			Console.WriteLine ("selectionChanged");
			bool hasSelected = treeView.Selection.CountSelectedRows () > 0;
			deleteAction.Sensitive = hasSelected;
			editAction.Sensitive = hasSelected;
		}

		private void fillListStore() {
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = "select * from categoria";

			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				object id = dataReader ["id"];
				object nombre = dataReader ["nombre"];
				listStore.AppendValues (id, nombre);
			}
			dataReader.Close ();
		}

		protected void OnRefreshActionActivated (object sender, EventArgs e)
		{
			ListAll.Refresh(listStore);
			fillListStore ();
		}



		protected void OnDeleteActionActivated (object sender, EventArgs e)
		{
//			MessageDialog messageDialog = new MessageDialog (
//				this,
//				DialogFlags.Modal,
//				MessageType.Question,
//				ButtonsType.YesNo,
//				"¿Quieres eliminar el registro?"
//				);
//			messageDialog.Title = "Estás seguro";
//			ResponseType response = (ResponseType) messageDialog.Run ();
//			messageDialog.Destroy ();
//
//			if (response != ResponseType.Yes)
//				return;
//			else
				ListAll.Delete (treeView,listStore,dbConnection,"delete from categoria where id={0}");
		}



		protected void OnAddActionActivated (object sender, EventArgs e)
		{
			ListAll.Add(dbConnection,"insert into categoria (nombre) values ('Nueva Categoria')");
		}

	}
}

