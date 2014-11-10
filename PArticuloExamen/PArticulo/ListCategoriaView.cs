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


		}
	}
}

