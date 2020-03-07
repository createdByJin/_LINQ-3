using System;
using Course.Entities;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double filterSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            using(StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] vet = sr.ReadLine().Split(',');
                    string name = vet[0];
                    string email = vet[1];
                    double salary = double.Parse(vet[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }
            }

            var query1 = list.Where(p => p.Salary > filterSalary).OrderBy(p => p.Email).Select(p => p.Email);

            var query2 = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);            

            Console.WriteLine("\nEmail of people whose salary is more than " + filterSalary.ToString("f2", CultureInfo.InvariantCulture) + ":");

            foreach(string email in query1)
            {
                Console.WriteLine(email);
            }

            Console.Write("\nSum of salary of people whose name starts with 'M': " + query2.ToString("f2", CultureInfo.InvariantCulture));
        }
    }
}
