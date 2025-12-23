using FinalProjectNAA.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNAA.Class
{
    public class Employee
    {
        public string No { get; private set; }
        public string Fullname { get; set; }

        private string _position;
        public string Position
        {
            get => _position;
            set
            {
                if (value.Length < 2)
                    throw new Exception("Vezife minimum 2 herf olmalidir");
                _position = value;
            }
        }

        private double _salary;
        public double Salary
        {
            get => _salary;
            set
            {
                if (value < 250)
                    throw new Exception("Maas 250-den az ola bilmez");
                _salary = value;
            }
        }

        public string DepartmentName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public EducationLevel Education { get; set; }
        public string PhoneNumber { get; set; }

        public bool HasCertificate { get; set; }
        public DateTime? CertificateExpireDate { get; set; }

        public Employee() { } // JSON üçün

        public Employee(string departmentName, int order)
        {
            No = departmentName.Substring(0, 2).ToUpper() + (1000 + order);
        }

        public void ChangeDepartmentCode(string newDepartmentName)
        {
            string numberPart = No.Substring(2);
            No = newDepartmentName.Substring(0, 2).ToUpper() + numberPart;
            DepartmentName = newDepartmentName;
        }

        public void CheckCertificate()
        {
            if (HasCertificate && CertificateExpireDate.HasValue)
            {
                int daysLeft = (CertificateExpireDate.Value - DateTime.Now).Days;
                if (daysLeft <= 15)
                    throw new CertificateExpireException("⚠ Sertifikatin bitmesine 15 gun qalib!");
            }
        }
    }
}
