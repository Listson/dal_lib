using System;

namespace Sunshineiot.Data
{
	public interface IInsertBuilder : IExecute, IExecuteReturnLastId
	{
		BuilderData Data { get; }
		IInsertBuilder Column(string columnName, object value, DataTypes parameterType = DataTypes.Object, int size = 0);
		IInsertBuilder Fill(Action<IInsertUpdateBuilder> fillMethod);
	}
}