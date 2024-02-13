using System;
using System.Linq;


interface IEmployeeDataSource
{
    void SaveEmployeeData(string employeeName, string employeeData);
    string ReadEmployeeData(string employeeName);
}
class EmployeeDataSource : IEmployeeDataSource
{
    public void SaveEmployeeData(string employeeName, string employeeData)
    {
        Thread.Sleep(2000);
        Console.WriteLine($"Employee data saved, {employeeName}: {employeeData}");

    }
    public string ReadEmployeeData(string employeeName)
    {
        Thread.Sleep(1500);
        return $"Employee data {employeeName}: There is no information";
        Console.WriteLine();
    }
}
class EmployeeDataSourceProxy : IEmployeeDataSource
{
    private EmployeeDataSource _dataSource;
    public EmployeeDataSourceProxy()
    {
        _dataSource = DataSourseFactory.CreateEmployeeDataSource();
    }

    public void SaveEmployeeData(string employeeName, string employeeData)
    {
        Console.WriteLine($"Record data about the employee {employeeName} is processing...");
        _dataSource.SaveEmployeeData(employeeName, employeeData);
        Console.WriteLine($"Record data about the employee {employeeName} is done.");

    }
    public string ReadEmployeeData(string employeeName)
    {
        Console.WriteLine($"Getting data about the employee {employeeName} is processing...");
        var data = _dataSource.ReadEmployeeData(employeeName);
        Console.WriteLine($"Employee's data is received {employeeName}: {data}");
        return data;
    }

}
class DataSourseFactory
{
    public static EmployeeDataSource CreateEmployeeDataSource()
    {
        return new EmployeeDataSource();
    }
}

class Program
{
    static void Main()
    {
        IEmployeeDataSource dataSource = new EmployeeDataSourceProxy();
        dataSource.SaveEmployeeData("Oles","UnEmployeed");

        var employeeData = dataSource.ReadEmployeeData("Oles");

        Console.WriteLine(employeeData);

    }
}
