using System;

namespace Homework_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "settings.dat";
            AppSettingHelper settingHelper = new AppSettingHelper(filePath);

        
            settingHelper.SaveSettings("Red", "MyApp", 800, 600);
           
            Console.WriteLine("Settings saved.");

        
            var settings = settingHelper.LoadSettings();
            Console.WriteLine($"Console color: {settings.Item1}");
            Console.WriteLine($"Window title: {settings.Item2}");
            Console.WriteLine($"Window width: {settings.Item3}");
            Console.WriteLine($"Window height: {settings.Item4}");

            Console.WriteLine();
            string filename = "students.dat";

          
            Student[] students = new Student[]
            {
            new Student("John", "Doe", "Computer Science", new int[] { 90, 85, 88 }),
            new Student("Jane", "Smith", "Engineering", new int[] { 78, 82, 79 }),
            new Student("David", "Brown", "Mathematics", new int[] { 95, 91, 97 })
            };

           
            FileWorker.SaveStudents(students, filename);
            Console.WriteLine("Students saved to file.");

      
            Student[] loadedStudents = FileWorker.LoadStudents(filename);

          
            Console.WriteLine("Loaded students:");
            foreach (var student in loadedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}, {student.Specialty}");
                Console.WriteLine("Grades:");
                foreach (var grade in student.Grades)
                {
                    Console.Write(grade + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
