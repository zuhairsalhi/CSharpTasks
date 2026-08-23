namespace Task04.App.Models
{
    public class Employee
    {
   
        public const decimal MaxSalary = 100_000m;
        private readonly int _id;
        private string _name;
        private decimal _salary;
        private string[] _skills;

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                _name = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative.");
                }

                if (value > MaxSalary)
                {
                    throw new ArgumentException(
                        $"Salary cannot be greater than {MaxSalary}.");
                }
                _salary = value;
            }
        }

        public Employee()
        {
            _id = 0;
            _name = "Unknown";
            _salary = 0;
            _skills = new string[5];
        }

        public Employee(int id, string name, decimal salary)
        {
            _id = id;
            Name = name;
            Salary = salary;
            _skills = new string[5];
        }

        public Employee(Employee employee)
        {
            _id = employee._id;
            Name = employee.Name;
            Salary = employee.Salary;

            _skills = new string[employee._skills.Length];

            for (int i = 0; i < employee._skills.Length; i++)
            {
                _skills[i] = employee._skills[i];
            }
        }

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= _skills.Length)
                {
                    throw new IndexOutOfRangeException("Invalid skill index.");
                }

                return _skills[index];
            }
            set
            {
                if (index < 0 || index >= _skills.Length)
                {
                    throw new IndexOutOfRangeException("Invalid skill index.");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Skill cannot be empty.");
                }

                _skills[index] = value;
            }
        }
    }
}