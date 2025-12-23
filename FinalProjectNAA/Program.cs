using FinalProjectNAA.Class;
using FinalProjectNAA.Enum;
using System;

namespace FinalProjectNAA
{
    class Program
    {
        static void Main()
        {
            Console.Title = "HR MANAGEMENT SYSTEM";
            HumanResourceManager hr = new HumanResourceManager();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.WriteLine("       HR MANAGEMENT SYSTEM         ");
                Console.WriteLine("====================================\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Departament elave et");
                Console.WriteLine("2. Isci elave et");
                Console.WriteLine("3. Departament adi deyis");
                Console.WriteLine("4. Isci sil");
                Console.WriteLine("5. Isci edit et");
                Console.WriteLine("6. Axtaris");
                Console.WriteLine("7. Departamentlere bax");
                Console.WriteLine("0. Cixis\n");
                Console.ResetColor();

                Console.Write("Secim edin: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": AddDepartment(hr); break;
                        case "2": AddEmployee(hr); break;
                        case "3": EditDepartment(hr); break;
                        case "4": RemoveEmployee(hr); break;
                        case "5": EditEmployee(hr); break;
                        case "6": SearchEmployee(hr); break;
                        case "7": ShowDepartments(hr); break;
                        case "0": return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Yanlis secim!");
                            Console.ResetColor();
                            break;
                    }

                    Console.WriteLine("\nDevam etmek ucun ENTER basin...");
                    Console.ReadLine();
                }
                catch (CertificateExpireException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("XEBDARLIQ: " + ex.Message);
                    Console.ResetColor();
                    Console.WriteLine("\nDevam etmek ucun ENTER basin...");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Xeta: " + ex.Message);
                    Console.ResetColor();
                    Console.WriteLine("\nDevam etmek ucun ENTER basin...");
                    Console.ReadLine();
                }
            }
        }

        static void AddDepartment(HumanResourceManager hr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== Departament elave et ===\n");
            Console.ResetColor();

            Console.Write("Departament adi: ");
            string name = Console.ReadLine();

            Console.Write("Worker limit: ");
            int workerLimit = int.Parse(Console.ReadLine());

            Console.Write("Salary limit: ");
            double salaryLimit = double.Parse(Console.ReadLine());

            hr.AddDepartment(name, workerLimit, salaryLimit);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nDepartament '{name}' elave olundu ✅");
            Console.ResetColor();
        }

        static void EditDepartment(HumanResourceManager hr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== Departament adi deyis ===\n");
            Console.ResetColor();

            Console.Write("Kohne departament adi: ");
            string oldName = Console.ReadLine();

            Console.Write("Yeni departament adi: ");
            string newName = Console.ReadLine();

            hr.EditDepartments(oldName, newName);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nDepartament adi '{oldName}' -> '{newName}' ✅");
            Console.ResetColor();
        }

        static void AddEmployee(HumanResourceManager hr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== Isci elave et ===\n");
            Console.ResetColor();

            Console.Write("Ad Soyad: "); string fullname = Console.ReadLine();
            Console.Write("Vezife: "); string position = Console.ReadLine();
            Console.Write("Maas: "); double salary = double.Parse(Console.ReadLine());
            Console.Write("Departament adi: "); string deptName = Console.ReadLine();
            Console.Write("Email: "); string email = Console.ReadLine();
            Console.Write("Telefon: "); string phone = Console.ReadLine();
            Console.Write("Tehsil (0-Orta, 1-Ali): "); EducationLevel education = (EducationLevel)int.Parse(Console.ReadLine());
            Console.Write("Ad gunu (yyyy-mm-dd): "); DateTime birthday = DateTime.Parse(Console.ReadLine());

            Console.Write("Sertifikati var? (b/x): "); bool hasCert = Console.ReadLine().ToLower() == "b";
            DateTime? certDate = null;
            if (hasCert)
            {
                Console.Write("Sertifikat bitme tarixi (yyyy-mm-dd): ");
                certDate = DateTime.Parse(Console.ReadLine());
            }

            hr.AddEmployee(fullname, position, salary, deptName, email, phone, education, hasCert, certDate, birthday);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nIsci '{fullname}' elave olundu ✅");
            Console.ResetColor();
        }

        static void RemoveEmployee(HumanResourceManager hr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== Isci sil ===\n");
            Console.ResetColor();

            Console.Write("Isci nomresi: "); string no = Console.ReadLine();
            Console.Write("Departament adi: "); string dept = Console.ReadLine();

            hr.RemoveEmployee(no, dept);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nIsci '{no}' silindi ✅");
            Console.ResetColor();
        }

        static void EditEmployee(HumanResourceManager hr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== Isci edit et ===\n");
            Console.ResetColor();

            Console.Write("Isci nomresi: "); string no = Console.ReadLine();
            Console.Write("Yeni maas: "); double salary = double.Parse(Console.ReadLine());
            Console.Write("Yeni vezife: "); string position = Console.ReadLine();

            hr.EditEmployee(no, salary, position);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nIsci '{no}' yenilendi ✅");
            Console.ResetColor();
        }

        static void SearchEmployee(HumanResourceManager hr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== Isci axtar ===\n");
            Console.ResetColor();

            Console.Write("Axtaris sozu: "); string value = Console.ReadLine();
            var result = hr.Search(value);

            if (result.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Netice tapilmadi");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var e in result)
            {
                Console.WriteLine($"[{e.No}] {e.Fullname} | {e.Position} | {e.Salary} AZN | {e.DepartmentName}");
            }
            Console.ResetColor();
        }

        static void ShowDepartments(HumanResourceManager hr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== Departamentler ===\n");
            Console.ResetColor();

            foreach (var d in hr.GetDepartments())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Departament: {d.Name} | Isci sayi: {d.Employees.Count} | Orta maas: {d.CalcSalaryAverage():0.00} AZN");
                Console.ResetColor();

                foreach (var e in d.Employees)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"  [{e.No}] {e.Fullname} | {e.Position} | {e.Salary} AZN");
                    Console.ResetColor();
                }
            }
        }
    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        HumanResourceManager hr = new HumanResourceManager();

    //        while (true)
    //        {
    //            Console.WriteLine("\n===== HR MANAGEMENT SYSTEM =====");
    //            Console.WriteLine("1. Departament elave et");
    //            Console.WriteLine("2. Isci elave et");
    //            Console.WriteLine("3. Departament adi deyis");
    //            Console.WriteLine("4. Isci sil");
    //            Console.WriteLine("5. Isci edit et");
    //            Console.WriteLine("6. Axtaris");
    //            Console.WriteLine("7. Departamentlere bax");
    //            Console.WriteLine("0. Cixis");
    //            Console.Write("Secim edin: ");

    //            string choice = Console.ReadLine();

    //            try
    //            {
    //                switch (choice)
    //                {
    //                    case "1":
    //                        AddDepartment(hr);
    //                        break;
    //                    case "2":
    //                        AddEmployee(hr);
    //                        break;
    //                    case "3":
    //                        EditDepartment(hr);
    //                        break;
    //                    case "4":
    //                        RemoveEmployee(hr);
    //                        break;
    //                    case "5":
    //                        EditEmployee(hr);
    //                        break;
    //                    case "6":
    //                        SearchEmployee(hr);
    //                        break;
    //                    case "7":
    //                        ShowDepartments(hr);
    //                        break;
    //                    case "0":
    //                        return;
    //                    default:
    //                        Console.WriteLine("Yanlis secim!");
    //                        break;
    //                }
    //            }
    //            catch (CertificateExpireException ex)
    //            {
    //                Console.WriteLine(ex.Message);
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine("Xeta: " + ex.Message);
    //            }
    //        }
    //    }

    //    // ---------------- DEPARTAMENT ----------------

    //    static void AddDepartment(HumanResourceManager hr)
    //    {
    //        Console.Write("Departament adi: ");
    //        string name = Console.ReadLine();

    //        Console.Write("Worker limit: ");
    //        int workerLimit = int.Parse(Console.ReadLine());

    //        Console.Write("Salary limit: ");
    //        double salaryLimit = double.Parse(Console.ReadLine());

    //        hr.AddDepartment(name, workerLimit, salaryLimit);
    //        Console.WriteLine("Departament elave olundu ✅");
    //    }

    //    static void EditDepartment(HumanResourceManager hr)
    //    {
    //        Console.Write("Kohne departament adi: ");
    //        string oldName = Console.ReadLine();

    //        Console.Write("Yeni departament adi: ");
    //        string newName = Console.ReadLine();

    //        hr.EditDepartments(oldName, newName);
    //        Console.WriteLine("Departament adi deyisdirildi ✅");
    //    }

    //    static void ShowDepartments(HumanResourceManager hr)
    //    {
    //        foreach (var d in hr.GetDepartments())
    //        {
    //            Console.WriteLine($"\nDepartament: {d.Name}");
    //            Console.WriteLine($"Isci sayi: {d.Employees.Count}");
    //            Console.WriteLine($"Orta maas: {d.CalcSalaryAverage()}");
    //        }
    //    }

    //    // ---------------- ISCI ----------------

    //    static void AddEmployee(HumanResourceManager hr)
    //    {
    //        Console.Write("Ad Soyad: ");
    //        string fullname = Console.ReadLine();

    //        Console.Write("Vezife: ");
    //        string position = Console.ReadLine();

    //        Console.Write("Maas: ");
    //        double salary = double.Parse(Console.ReadLine());

    //        Console.Write("Departament adi: ");
    //        string deptName = Console.ReadLine();

    //        Console.Write("Email: ");
    //        string email = Console.ReadLine();

    //        Console.Write("Telefon: ");
    //        string phone = Console.ReadLine();

    //        Console.Write("Tehsil (0-Orta, 1-Ali): ");
    //        EducationLevel education = (EducationLevel)int.Parse(Console.ReadLine());

    //        Console.Write("Ad gunu (yyyy-mm-dd): ");
    //        DateTime birthday = DateTime.Parse(Console.ReadLine());

    //        Console.Write("Sertifikati var? (b/x): ");
    //        bool hasCert = Console.ReadLine().ToLower() == "b";

    //        DateTime? certDate = null;
    //        if (hasCert)
    //        {
    //            Console.Write("Sertifikat bitme tarixi (yyyy-mm-dd): ");
    //            certDate = DateTime.Parse(Console.ReadLine());
    //        }

    //        hr.AddEmployee(
    //            fullname,
    //            position,
    //            salary,
    //            deptName,
    //            email,
    //            phone,
    //            education,
    //            hasCert,
    //            certDate,
    //            birthday
    //        );

    //        Console.WriteLine("Isci elave olundu ✅");
    //    }

    //    static void RemoveEmployee(HumanResourceManager hr)
    //    {
    //        Console.Write("Isci nomresi: ");
    //        string no = Console.ReadLine();

    //        Console.Write("Departament adi: ");
    //        string dept = Console.ReadLine();

    //        hr.RemoveEmployee(no, dept);
    //        Console.WriteLine("Isci silindi ✅");
    //    }

    //    static void EditEmployee(HumanResourceManager hr)
    //    {
    //        Console.Write("Isci nomresi: ");
    //        string no = Console.ReadLine();

    //        Console.Write("Yeni maas: ");
    //        double salary = double.Parse(Console.ReadLine());

    //        Console.Write("Yeni vezife: ");
    //        string position = Console.ReadLine();

    //        hr.EditEmployee(no, salary, position);
    //        Console.WriteLine("Isci melumatlari yenilendi ✅");
    //    }

    //    static void SearchEmployee(HumanResourceManager hr)
    //    {
    //        Console.Write("Axtaris sozu: ");
    //        string value = Console.ReadLine();

    //        var result = hr.Search(value);

    //        if (result.Count == 0)
    //        {
    //            Console.WriteLine("Netice tapilmadi");
    //            return;
    //        }

    //        foreach (var e in result)
    //        {
    //            Console.WriteLine($"{e.No} | {e.Fullname} | {e.Position} | {e.Salary}");
    //        }
    //    }
    //}

}
