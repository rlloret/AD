using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace MenuConVentana
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();


		}
	}
}
