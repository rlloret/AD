using System;
using System.Collections.Generic;
using Gtk;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			List<Articulo> articulos = new List<Articulo> ();
//			categorias.Add (new Categoria(1,"Uno"));
//			categorias.Add (new Categoria(2,"Dos"));
//			categorias.Add (new Categoria(3,"Tres"));
//			categorias.Add (new Categoria(4,"Cuatro"));

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

			propertiesAction.Activated += delegate {

				TreeIter treeIter;
				bool activeIter = comboBox.GetActiveIter (out treeIter);
				object id = activeIter ? listStore.GetValue (treeIter, 0):0;
				Console.WriteLine ("id={0}", id);
			};
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

