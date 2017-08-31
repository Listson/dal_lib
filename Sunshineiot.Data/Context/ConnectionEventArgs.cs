using System;
using System.Data;

namespace Sunshineiot.Data
{
	public class ConnectionEventArgs : EventArgs
	{
		public IDbConnection Connection { get; private set; }

		public ConnectionEventArgs(System.Data.IDbConnection connection)
		{
			Connection = connection;
		}
	}
}
