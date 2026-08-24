using System;

namespace Task07.App
{
    public class Company
    {
        private string _companyName;
        private decimal _budget;

        public Company(string companyName, decimal budget)
        {
            _companyName = companyName;
            _budget = budget;
        }

        public class Department
        {
            private string _departmentName;

            public Department(string departmentName)
            {
                _departmentName = departmentName;
            }

            public void ShowDepartmentInfo(Company company)
            {
                Console.WriteLine($"Company: {company._companyName}");
                Console.WriteLine($"Budget: {company._budget}");
                Console.WriteLine($"Department: {_departmentName}");
            }
        }
    }
}