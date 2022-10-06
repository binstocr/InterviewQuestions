using System;
using System.Data;

namespace InterviewProblems
{
	public interface IDataFactory
	{
		IDataStore GetDataSource(string type);
	}

	public class DataFactory : IDataFactory
	{
		public IDataStore GetDataSource(string type)
		{
			if (type == "Sql")
			{
				return null;
			}
			else if (type == "Xml")
			{
				return new OracleDataStore();
			}
			else
			{
				throw new Exception();
			}
		}
	}

	public interface IDataStore
	{
		DataTable GetData();
	}

	public class OracleDataStore : IDataStore
	{
		public DataTable GetData()
		{
			return new DataTable();
		}
	}
}
