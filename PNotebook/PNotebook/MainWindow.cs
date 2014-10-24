using PNotebook;
using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		ArticuloAction.Activated += delegate{

			addPage (new MyTreeView(),"Categoria");

		};
		CategoraAction.Activated += delegate{

			addPage (new MyTreeView(),"Categoria");

		};

		notebook1.SwitchPage += delegate {
			Console.WriteLine("notebook.CurrentPage = {0}", notebook1.CurrentPage);
			//Captura la pestaña del notebook
	};


		addPage (new MyTreeView(), "Articulo2");
		addPage (new MyTreeView(), "Categoría2");

		//treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		//treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		//treeView.Model = new ListStore (typeof(long), typeof(string));
	}

	private void addPage (Widget widget,string label)
	{

		HBox hBox = new HBox ();
		hBox.Add (new Label (label));
		Button button = new Button (new Image(Stock.Cancel, IconSize.Button));
		hBox.Add (button);
		hBox.ShowAll ();

		notebook1.AppendPage (widget, hBox);

		button.Clicked += delegate {
		
			widget.Destroy();
		
		};


	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
