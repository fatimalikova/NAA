using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using FinalProjectNAA.Class;



namespace FinalProjectNAA.Class
{
    public static class DataStorage
    {
        private static string filePath = "data.json";

        public static void Save(List<Department> departments)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filePath, JsonSerializer.Serialize(departments, options));
        }

        public static List<Department> Load()
        {
            if (!File.Exists(filePath))
                return new List<Department>();

            return JsonSerializer.Deserialize<List<Department>>(File.ReadAllText(filePath))
                   ?? new List<Department>();
        }
    }
}
