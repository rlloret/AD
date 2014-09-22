using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		Console.WriteLine ("Has hecho click en aceptar");
		//labelSaludo.LabelProp = "Hola " + entry.Text;
		labelSaludo.LabelProp = string.Format ("Hola {0}", entry.Text);
	}
	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		Console.WriteLine ("Has activado la acción newAction");
	}


}
