using System;

namespace Homework_10
{
    class Program
    {
        static void Main(string[] args)
        {
            IRemoveableDisk disk = new Disk();
            disk.Insert();
            Console.WriteLine($"Disk Name: {disk.GetName()}");
            Console.WriteLine($"Has Disk: {disk.HasDisk}");
            disk.Reject();
            Console.WriteLine($"Has Disk after Reject: {disk.HasDisk}");
            Console.WriteLine($"Data Read from Disk: {disk.Read()}");
            disk.Write("Hello, Disk!");

            Console.WriteLine(disk.ToString());


            IRemoveableDisk cd = new CD();
            cd.Insert();
            Console.WriteLine($"CD Name: {cd.GetName()}");
            Console.WriteLine($"Has CD: {cd.HasDisk}");
            cd.Reject();
            Console.WriteLine($"Has CD after Reject: {cd.HasDisk}");
            Console.WriteLine($"Data Read from CD: {cd.Read()}");
            cd.Write("Hello, CD!");

            Console.WriteLine(cd.ToString());


            IRemoveableDisk flash = new Flash();
            flash.Insert();
            Console.WriteLine($"Flash Name: {flash.GetName()}");
            Console.WriteLine($"Has Flash: {flash.HasDisk}");
            flash.Reject();
            Console.WriteLine($"Has Flash after Reject: {flash.HasDisk}");
            Console.WriteLine($"Data Read from Flash: {flash.Read()}");
            flash.Write("Hello, Flash!");

            Console.WriteLine(flash.ToString());


            Disk hdd = new HDD();
            Console.WriteLine($"HDD Name: {hdd.GetName()}");
            Console.WriteLine($"Data Read from HDD: {hdd.Read()}");

            Console.WriteLine(hdd.ToString());


            IRemoveableDisk dvd = new DVD();
            dvd.Insert();
            Console.WriteLine($"DVD Name: {dvd.GetName()}");
            Console.WriteLine($"Has DVD: {dvd.HasDisk}");
            dvd.Reject();
            Console.WriteLine($"Has DVD after Reject: {dvd.HasDisk}");
            Console.WriteLine($"Data Read from DVD: {dvd.Read()}");
            dvd.Write("Hello, DVD!");

            Console.WriteLine(dvd.ToString());


            IPrintInformation printer = new Printer("Printer Memory", 100);
            Console.WriteLine(printer.GetInfo());
            printer.Print("Test Printing");


            IPrintInformation monitor = new Monitor("Main Monitor");
            Console.WriteLine($"Monitor Name: {monitor.GetName()}");
            monitor.Print("Test Display");

            Console.WriteLine(monitor.ToString());


            Comp computer = new Comp(countDisk: 3, countPrintDevice: 2);


            Disk disk1 = new Disk();
            Disk disk2 = new Disk();
            Disk disk3 = new Disk();

            IPrintInformation printer1 = new Printer("Printer1 Memory", 50);
            IPrintInformation printer2 = new Printer("Printer2 Memory", 100);


            computer.AddDisk(0, disk1);
            computer.AddDisk(1, disk2);
            computer.AddDisk(2, disk3);

            computer.AddDevice(0, printer1);
            computer.AddDevice(1, printer2);


            Console.WriteLine("\nComputer Components:");
            Console.WriteLine("Disks:");
            computer.ShowDisk();

            Console.WriteLine("\nPrint Devices:");
            computer.ShowPrintDevice();


            Console.WriteLine("\nChecking and Inserting/Rejecting Disk:");
            Console.WriteLine($"Does computer have disk with name 'Disk1': {computer.CheckDisk("Disk1")}");
            computer.InsertReject("Disk1", true);
            computer.ShowDisk();

            Console.WriteLine("\nWriting Info to Print Device:");
            computer.WriteInfo("Print this text", "Printer1 Memory");
        }
    }
}
