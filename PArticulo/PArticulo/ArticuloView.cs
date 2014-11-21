using System;
using System.Collections.Generic;
using Gtk;
using System.Data;
using SerpisAd;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			List<Articulo> articulos = new List<Articulo> ();

			int categoriaId = 2;

			CellRendererText cellRendererText = new CellRendererText ();
			comboBoxCategoria.PackStart (cellRendererText, false);
			comboBoxCategoria.AddAttribute (cellRendererText, "text", 1);

			ListStore listStore = new ListStore (typeof(int),typeof(string));
			TreeIter initialTreeIter=listStore.AppendValues (0, "<sin asignar>");

			foreach (Articulo articulo in articulos) {
				TreeIter currentTreeIter=listStore.AppendValues (articulo.Id, articulo.Nombre);
				if (articulo.Id == categoriaId)
					initialTreeIter = currentTreeIter;

		}

			comboBoxCategoria.Model = listStore;

			comboBoxCategoria.SetActiveIter (initialTreeIter);

	}
		protected void OnSaveActionActivated (object sender, EventArgs e)
		{
//			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
//			dbCommand.CommandText = String.Format (
//				"update articulo set nombre=@nombre,categoria=@categoria,precio=@precio where id={0}", id
//				);
//			dbCommand.AddParameter ("nombre", entryNombre.Text);
//			dbCommand.AddParameter ("categoria", comboBoxCategoria);
//			dbCommand.AddParameter ("precio", spinButtonPrecio.Text.Replace(',','.'));
//
//			dbCommand.ExecuteNonQuery ();
//
//			Destroy ();
		}


}
}
public class Articulo{

		public Articulo (int id, string nombre){
			Id = id;
			Nombre = nombre;

		}

		public int Id {get;set;}
		public string Nombre {get;set;}
	}

