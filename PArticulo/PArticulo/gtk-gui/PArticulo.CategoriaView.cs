
// This file has been generated by the GUI designer. Do not modify.
namespace PArticulo
{
	public partial class CategoriaView
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action saveAction;
		private global::Gtk.VBox vbox5;
		private global::Gtk.Toolbar toolbar4;
		private global::Gtk.VBox vbox6;
		private global::Gtk.HBox hbox4;
		private global::Gtk.HBox hbox5;
		private global::Gtk.HBox hbox6;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PArticulo.CategoriaView
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.saveAction = new global::Gtk.Action ("saveAction", null, null, "gtk-save");
			w1.Add (this.saveAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "PArticulo.CategoriaView";
			this.Title = global::Mono.Unix.Catalog.GetString ("CategoriaView");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PArticulo.CategoriaView.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar4'><toolitem name='saveAction' action='saveAction'/></toolbar></ui>");
			this.toolbar4 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar4")));
			this.toolbar4.Name = "toolbar4";
			this.toolbar4.ShowArrow = false;
			this.vbox5.Add (this.toolbar4);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.toolbar4]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			this.vbox6.Add (this.hbox4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.hbox4]));
			w3.Position = 0;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			this.vbox6.Add (this.hbox5);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.hbox5]));
			w4.Position = 1;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			this.vbox6.Add (this.hbox6);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.hbox6]));
			w5.Position = 2;
			this.vbox5.Add (this.vbox6);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.vbox6]));
			w6.Position = 1;
			this.Add (this.vbox5);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
