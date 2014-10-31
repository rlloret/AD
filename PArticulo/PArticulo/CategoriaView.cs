using Gtk;
using System;
using System.Data;

using SerpisAd;

namespace PArticulo
{
	public partial class CategoriaView : Gtk.Window
	{
		private object id;
		public CategoriaView () : base(Gtk.WindowType.Toplevel)	{
			this.Build ();
		}

		public CategoriaView(object id) : this() {
			this.id = id;
			IDbCommand dbCommand = 
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"select * from categoria where id={0}", id
				);

			IDataReader dataReader = dbCommand.ExecuteReader ();
			dataReader.Read ();

			entryCatCat.Text = dataReader ["nombre"].ToString ();

			dataReader.Close ();
		}

		protected void OnSaveActionCatActivated (object sender, EventArgs e)
		{
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"update categoria set nombre=@nombre where id={0}", id
				);
			dbCommand.AddParameter ("nombre", entryCatCat.Text);

			dbCommand.ExecuteNonQuery ();

			Destroy ();
		}



	}
}


