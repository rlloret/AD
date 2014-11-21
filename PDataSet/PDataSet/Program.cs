using System;
using Gtk;

using SerpisAd;
using MySql.Data.MySqlClient;

namespace PDataSet
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
