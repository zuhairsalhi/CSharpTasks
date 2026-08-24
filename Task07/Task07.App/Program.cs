using System;

namespace Task07.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company("Bank",300);

            Company.Department department = new Company.Department("IT");

            department.ShowDepartmentInfo(company);
        }
    }
}