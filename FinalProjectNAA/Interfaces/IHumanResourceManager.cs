using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectNAA.Class;
using System.Collections.Generic;
using FinalProjectNAA.Enum;

namespace FinalProjectNAA.Interfaces
{

    public interface IHumanResourceManager
    {
        List<Department> Departments { get; set; }

        void AddDepartment(string name, int workerLimit, double salaryLimit);
        List<Department> GetDepartments();
        void EditDepartments(string oldName, string newName);

        void AddEmployee(
            string fullname,
            string position,
            double salary,
            string departmentName,
            string email,
            string phone,
            EducationLevel education,
            bool hasCertificate,
            System.DateTime? certificateExpireDate,
            System.DateTime birthday
        );

        void RemoveEmployee(string employeeNo, string departmentName);
        void EditEmployee(string no, double salary, string position);
        List<Employee> Search(string value);
    }

}
