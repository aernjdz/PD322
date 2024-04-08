using System;
using System.IO;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the starting value of the range:");
        int start = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the ending value of the range:");
        int end = Convert.ToInt32(Console.ReadLine());

       
        Console.WriteLine("Enter the file Name (output.txt):");
        var fileName = Console.ReadLine();
        if (!File.Exists(fileName))
        {
            File.Create(fileName).Close();
            
        }
        GenerateMultiplicationTable(start, end, fileName);
    }

    static void GenerateMultiplicationTable(int start, int end,string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            Parallel.For(start, end + 1, i =>
        {

            for (int j = 1; j <= 10; j++)
            {
                sw.WriteLine($"{i} * {j} = {i * j}");
            }
            // Console.WriteLine("---");

        });
        }
    }
}