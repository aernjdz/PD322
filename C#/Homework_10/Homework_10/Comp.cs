using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    class Comp
    {
        private int countDisk;
        private int countPrintDevice;
        private Disk[] disks;
        private IPrintInformation[] printDevices;

        public Comp(int countDisk, int countPrintDevice)
        {
            this.countDisk = countDisk;
            this.countPrintDevice = countPrintDevice;
            disks = new Disk[countDisk];
            printDevices = new IPrintInformation[countPrintDevice];
        }

        public void AddDisk(int index, Disk disk)
        {
            if (index >= 0 && index < countDisk)
            {
                disks[index] = disk;
            }
            else
            {
                Console.WriteLine("Invalid index for adding disk.");
            }
        }

        public void AddDevice(int index, IPrintInformation printDevice)
        {
            if (index >= 0 && index < countPrintDevice)
            {
                printDevices[index] = printDevice;
            }
            else
            {
                Console.WriteLine("Invalid index for adding print device.");
            }
        }

        public bool CheckDisk(string device)
        {
            foreach (var disk in disks)
            {
                if (disk != null && disk.GetName() == device)
                {
                    return true;
                }
            }
            return false;
        }

        public void InsertReject(string device, bool insert)
        {
            foreach (var disk in disks)
            {
                if (disk != null && disk.GetName() == device)
                {
                    if (insert)
                    {
                        disk.Insert();
                    }
                    else
                    {
                        disk.Reject();
                    }
                    return;
                }
            }
            Console.WriteLine($"Disk with name '{device}' not found.");
        }

        public void ShowDisk()
        {
            foreach (var disk in disks)
            {
                if (disk != null)
                {
                    Console.WriteLine(disk.ToString());
                }
            }
        }

        public void ShowPrintDevice()
        {
            foreach (var printDevice in printDevices)
            {
                if (printDevice != null)
                {
                    Console.WriteLine(printDevice.ToString());
                }
            }
        }

        public bool WriteInfo(string text, string showDevice)
        {
            foreach (var printDevice in printDevices)
            {
                if (printDevice != null && printDevice.ToString() == showDevice)
                {
                    printDevice.Print(text);
                    return true;
                }
            }
            Console.WriteLine($"Print device with info '{showDevice}' not found.");
            return false;
        }
    }
}
