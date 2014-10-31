using Gtk;
using System;
using System.Data;

using SerpisAd;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		private object id;
		public ArticuloView () : base(Gtk.WindowType.Toplevel)	{
			this.Build ();
		}

		public ArticuloView(object id) : this() {
			this.id = id;
			IDbCommand dbCommand = 
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"select * from articulo where id={0}", id
				//Cargar el nombre de la categoria en lugar del id
				//"select articulo.nombre, articulo.categoria, articulo.precio, categoria.nombre FROM articulo,categoria WHERE articulo.categoria = categoria.id"
				);

			IDataReader dataReader = dbCommand.ExecuteReader ();
			dataReader.Read ();

			entryNombre.Text = dataReader ["nombre"].ToString ();
			entryCategoria.Text = dataReader ["categoria"].ToString ();
			entryPrecio.Text = dataReader ["precio"].ToString ().Replace(',','.');

			dataReader.Close ();
		}

		protected void OnSaveActionActivated (object sender, EventArgs e)
		{
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"update articulo set nombre=@nombre,categoria=@categoria,precio=@precio where id={0}", id
				);
			dbCommand.AddParameter ("nombre", entryNombre.Text);
			dbCommand.AddParameter ("categoria", entryCategoria.Text);
			dbCommand.AddParameter ("precio", entryPrecio.Text.Replace(',','.'));

			dbCommand.ExecuteNonQuery ();

			Destroy ();
		}
	}
}



