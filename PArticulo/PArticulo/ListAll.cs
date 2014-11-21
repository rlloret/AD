using Gtk;
using System;
using System.Data;

using SerpisAd;

namespace PArticulo
{
	public class ListAll
	{
		public ListAll ()
		{
		}
		public static void Refresh(ListStore listStore){
			listStore.Clear ();
		}

		public static void Delete (TreeView treeView,ListStore listStore,IDbConnection dbConnection,String sql){

			TreeIter treeIter;
			treeView.Selection.GetSelected (out treeIter);
			object id = listStore.GetValue (treeIter, 0);
			string deleteSql = string.Format (sql, id);
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = deleteSql;

			dbCommand.ExecuteNonQuery ();

		}


		public static void Add(IDbConnection dbConnection,String sql){
			string insertSql = string.Format(sql);
			Console.WriteLine ("insertSql={0}", insertSql);
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = insertSql;

			dbCommand.ExecuteNonQuery ();
		}

	}
}

