using System;
using System.Data;

namespace PArticulo
{
	public class PArticulo
	{
		private PArticulo ()
		{
		}

		private static PArticulo instance = new PArticulo();

		public static PArticulo Instance {

			get{return instance;}

		}

		private IDbConnection dbConnection;
		public IDbConnection DbConnection {

			get {return dbConnection;}
			set {dbConnection = value;}
		}


	}

}

