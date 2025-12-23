using FinalProjectNAA.Enum;
using FinalProjectNAA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNAA.Class
{
    public class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments { get; set; }
        private int employeeOrder = 0;

        public HumanResourceManager()
        {
            Departments = DataStorage.Load();

            employeeOrder = Departments
                .SelectMany(d => d.Employees)
                .Select(e => int.Parse(e.No.Substring(2)))
                .DefaultIfEmpty(1000)
                .Max() - 1000;
        }

        public void AddDepartment(string name, int workerLimit, double salaryLimit)
        {
            Departments.Add(new Department
            {
                Name = name,
                WorkerLimit = workerLimit,
                SalaryLimit = salaryLimit
            });

            DataStorage.Save(Departments);
        }

        public List<Department> GetDepartments() => Departments;

        public void EditDepartments(string oldName, string newName)
        {
            var dept = Departments.FirstOrDefault(d => d.Name == oldName);
            if (dept == null) throw new Exception("Departament tapilmadi");

            foreach (var emp in dept.Employees)
                emp.ChangeDepartmentCode(newName);

            dept.Name = newName;
            DataStorage.Save(Departments);
        }

        public void AddEmployee(
            string fullname,
            string position,
            double salary,
            string departmentName,
            string email,
            string phone,
            EducationLevel education,
            bool hasCertificate,
            DateTime? certificateExpireDate,
            DateTime birthday)
        {
            var dept = Departments.FirstOrDefault(d => d.Name == departmentName);
            if (dept == null) throw new Exception("Departament tapilmadi");

            if (dept.Employees.Count >= dept.WorkerLimit)
                throw new Exception("Isci limiti asilib");

            if (dept.Employees.Sum(e => e.Salary) + salary > dept.SalaryLimit)
                throw new Exception("Salary limiti asilir");

            employeeOrder++;

            Employee emp = new Employee(departmentName, employeeOrder)
            {
                Fullname = fullname,
                Position = position,
                Salary = salary,
                DepartmentName = departmentName,
                Email = email,
                PhoneNumber = phone,
                Education = education,
                HasCertificate = hasCertificate,
                CertificateExpireDate = certificateExpireDate,
                Birthday = birthday
            };

            emp.CheckCertificate();
            dept.Employees.Add(emp);
            DataStorage.Save(Departments);
        }

        public void RemoveEmployee(string employeeNo, string departmentName)
        {
            var dept = Departments.FirstOrDefault(d => d.Name == departmentName);
            var emp = dept?.Employees.FirstOrDefault(e => e.No == employeeNo);

            if (emp == null) throw new Exception("Isci tapilmadi");

            dept.Employees.Remove(emp);
            DataStorage.Save(Departments);
        }

        public void EditEmployee(string no, double salary, string position)
        {
            foreach (var d in Departments)
            {
                var emp = d.Employees.FirstOrDefault(e => e.No == no);
                if (emp != null)
                {
                    emp.Salary = salary;
                    emp.Position = position;
                    DataStorage.Save(Departments);
                    return;
                }
            }
            throw new Exception("Isci tapilmadi");
        }

        public List<Employee> Search(string value)
        {
            return Departments
                .SelectMany(d => d.Employees)
                .Where(e =>
                    e.Fullname.Contains(value) ||
                    e.No.Contains(value) ||
                    e.Email.Contains(value) ||
                    e.Position.Contains(value))
                .ToList();
        }
    }

}
