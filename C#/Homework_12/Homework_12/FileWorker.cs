using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Homework_12
{
    class FileWorker
    {
        public static void SaveStudents(Student[] students, string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                writer.Write(students.Length);
                foreach (var student in students)
                {
                    writer.Write(student.FirstName);
                    writer.Write(student.LastName);
                    writer.Write(student.Specialty);

                
                    writer.Write(student.Grades.Length);
                    foreach (var grade in student.Grades)
                    {
                        writer.Write(grade);
                    }
                }
            }
        }

        public static Student[] LoadStudents(string filename)
        {
            List<Student> students = new List<Student>();

            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                int studentCount = reader.ReadInt32(); 
                for (int i = 0; i < studentCount; i++)
                {
                    string firstName = reader.ReadString();
                    string lastName = reader.ReadString();
                    string specialty = reader.ReadString();

                    int gradeCount = reader.ReadInt32(); 
                    int[] grades = new int[gradeCount];
                    for (int j = 0; j < gradeCount; j++)
                    {
                        grades[j] = reader.ReadInt32();
                    }

                    students.Add(new Student(firstName, lastName, specialty, grades));
                }
            }

            return students.ToArray();
        }
    }
}
