using System;

namespace Sunshineiot.Data
{
	public interface IEntityFactory
	{
		object Create(Type type);
	}
}
