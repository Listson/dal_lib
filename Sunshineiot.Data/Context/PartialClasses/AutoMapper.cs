using System;

namespace Sunshineiot.Data
{
	public partial class DbContext
	{
		public IDbContext IgnoreIfAutoMapFails(bool ignoreIfAutoMapFails)
		{
			Data.IgnoreIfAutoMapFails = true;
			return this;
		}
	}
}
