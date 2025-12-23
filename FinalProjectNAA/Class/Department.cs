using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNAA.Class
{
    public class Department
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 2)
                    throw new Exception("Departament adi minimum 2 herf olmalidir");
                _name = value;
            }
        }

        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public double CalcSalaryAverage()
        {
            if (Employees.Count == 0) return 0;
            return Employees.Average(e => e.Salary);
        }
    }
}
