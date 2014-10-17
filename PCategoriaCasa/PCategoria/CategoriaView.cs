using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;
using PCategoria;

namespace PCategoria
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			//entryNombre.Text =  "texto del entrynombre";
		}




		public CategoriaView (object id) : this(){

			entryNombre.Text = "id = " + id;

			MySqlCommand mySqlCommand = MainWindow.ConexionSQL().CreateCommand ();
			//mySqlCommand.CommandText = string.Format("update categoria (nombre) set ('{0}')", entryNombre.Text);

			//mySqlCommand.ExecuteNonQuery ();


		}

		/*
		 *Boton guardar datos 
		 */
		protected void OnSaveActionActivated (object sender, EventArgs e)
		{

		}


	}
}

