using System;
using System.Collections;
using System.Data;

namespace InterviewProblems
{
	// Take a look at the code in this file (don't worry about DataStorage.cs,
	// there is nothing interesting there) and decide what could or couldn't
	// be improved in any way.  This code doesn't output anything good,
	// so don't worry about that, either.
	internal class EmployeeApplication
	{
		private static ArrayList Employees = new ArrayList();
		private static ArrayList Managers = new ArrayList();

		public EmployeeApplication()
		{
			LoadData();
			string[] employees = GetResult();
			for (int i = 0; i < employees.Length; i++)
			{
				Console.WriteLine(employees[i]);
			}
		}

		private void LoadData()
		{
			// IDataFactory and IDataStore are interfaces
			// within this solution.  They don't do anything
			// outside of what's implied below.
			IDataFactory f = new DataFactory();
			IDataStore sql = f.GetDataSource("Sql");
			IDataStore xml = f.GetDataSource("Xml");

			if (sql != null)
			{
				DataTable data = sql.GetData();
				for (int i = 0; i < data.Rows.Count; i++)
				{
					int employeeID = (int)data.Rows[i]["EmployeeID"];
					string name = data.Rows[i]["Name"].ToString();
					int daysVacation = (int)data.Rows[i]["DaysVacation"];
					bool isManager = (bool)data.Rows[i]["IsManager"];
					if (isManager)
						Managers.Add(new Manager(employeeID, name, daysVacation));
					else
						Employees.Add(new Employee(employeeID, name, daysVacation));
				}
			}
			else if (xml != null)
			{
				DataTable data = xml.GetData();
				for (int i = 0; i < data.Rows.Count; i++)
				{
					int employeeID = (int)data.Rows[i]["EmployeeID"];
					string name = data.Rows[i]["Name"].ToString();
					int daysVacation = (int)data.Rows[i]["DaysVacation"];
					bool isManager = (bool)data.Rows[i]["IsManager"];
					if (isManager)
						Managers.Add(new Manager(employeeID, name, daysVacation));
					else
						Employees.Add(new Employee(employeeID, name, daysVacation));
				}
			}
		}

		private string[] GetResult()
		{

			string[] employees = new string[Employees.Count + Managers.Count];
			for (int i = 0; i < Employees.Count; i++)
			{
				if (((Employee)Employees[i]).DaysVacation >= 21)
					employees[i] = (((Employee)Employees[i]).Name);
			}

			for (int i = 0; i < Managers.Count; i++)
			{
				if (((Manager)Managers[i]).DaysVacation >= 21)
					employees[Employees.Count + i] = (((Manager)Managers[i]).Name);
			}

			ArrayList employeeArray = new ArrayList();
			for (int i = 0; i < employees.Length; i++)
			{
				if ((employees[i] != null) && (employees[i] != ""))
					employeeArray.Add(employees[i]);
			}

			string[] emps = new string[employeeArray.Count];
			for (int i = 0; i < employeeArray.Count; i++)
				emps[i] = employeeArray[i].ToString();

			return emps;
		}
	}

	internal class Employee
	{
		public int EmployeeID;
		public string Name;
		public int DaysVacation;
		public Employee(int employeeID, string name, int daysVacation)
		{
			EmployeeID = employeeID;
			Name = name;
			DaysVacation = daysVacation;
		}
	}

	internal class Manager
	{
		public int EmployeeID;
		public string Name;
		public int DaysVacation;
		public Employee[] Employees;
		public Manager(int employeeID, string name, int daysVacation)
		{
			EmployeeID = employeeID;
			Name = name;
			DaysVacation = daysVacation;
		}
	}
}
