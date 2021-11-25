using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace pr_32_prakt17_4_OAP_ZhuravlevTimofeyVasilievich
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Exists("input.txt");
            File.Exists("output.txt");
            File.Exists("sort.txt");
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");

            List<Student> students = new List<Student>();
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                string[] t = str.Split(' ');
                students.Add(new Student { F = t[0], I = t[1], O = t[2], GROUP = t[3], BALL = Convert.ToDouble(t[4]) });
            }

            StreamWriter sw1 = new StreamWriter("sort.txt");
            var s = from x in students
                    where x.BALL >= 4
                    select x;
            foreach (Student z in s)
            {
                sw1.WriteLine($"{z.F} {z.I} {z.O} {z.GROUP} {z.BALL}");
            }
            sw1.Close();

            StreamReader sr1 = new StreamReader("sort.txt");
            List<SortStudent> sortstudents = new List<SortStudent>();
            string str1;
            while ((str1 = sr1.ReadLine()) != null)
            {
                string[] t = str1.Split(' ');
                sortstudents.Add(new SortStudent { f = t[0], i = t[1], o = t[2], groupp = t[3], ball = Convert.ToDouble(t[4]) });
            }

            var studentsGroups = from stud in sortstudents
                                 group stud by stud.groupp into g 
                               select new
                               {
                                   Name = g.Key,
                                   Count = g.Count(),
                                   Studentes = from p in g select p
                               };
            foreach (var group in studentsGroups)
            {
                Console.WriteLine($"{group.Name} : {group.Count}");
                foreach (SortStudent stud in group.Studentes)
                {
                    Console.WriteLine($"{stud.f} - {stud.i} - {stud.o} - {stud.groupp} - {stud.ball}");
                }
                Console.WriteLine();
            }
            sr1.Close();
            sw.Close();
            Console.ReadLine();
        }
    }
    internal class Student
    {
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public string GROUP { get; set; }
        public double BALL { get; set; }
    }
    internal class SortStudent
    {
        public string f { get; set; }
        public string i { get; set; }
        public string o { get; set; }
        public string groupp { get; set; }
        public double ball { get; set; }
    }

}