using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(gb => gb).Select(num => $"Broj {num.Key} ponavlja se {num.Count()} puta").OrderBy(ob => ob).ToArray();
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(uni => uni.Students.All(stud => stud.Gender.Equals(Gender.Male))).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            var avg = (from uni in universityArray
                          from stud in uni.Students
                          select stud
                      ).Count() / universityArray.Count();

            return universityArray.Where(uni => uni.Students.Count() < avg).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return (from uni in universityArray
                    from stud in uni.Students
                    select stud).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(uni =>
                    uni.Students.All(stud => stud.Gender.Equals(Gender.Male)) ||
                    uni.Students.All(stud => stud.Gender.Equals(Gender.Female)))
                .SelectMany(uni => uni.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return (from uni in universityArray
                    from stud in uni.Students
                    group stud by stud)
                    .Where(group => group.Count() > 1)
                    .Select(group => group.Key)
                    .ToArray();
        }
    }

    public class University
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }
    }
}

