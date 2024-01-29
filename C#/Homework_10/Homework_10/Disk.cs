using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    class Disk : IRemoveableDisk
    {
        protected bool hasDisk;

        public bool HasDisk => hasDisk;

        public virtual string GetName()
        {
            return "Disk";
        }

        public virtual void Insert()
        {
            hasDisk = true;
            Console.WriteLine($"{GetName()} inserted.");
        }

        public virtual void Reject()
        {
            hasDisk = false;
            Console.WriteLine($"{GetName()} rejected.");
        }

        public virtual string Read()
        {
            return "Reading data from disk.";
        }

        public void Write(string text)
        {
            Console.WriteLine($"Writing data to {GetName()}: {text}");
        }

        public override string ToString()
        {
            return $"{GetName()}: {Read()}, {HasDisk}";
        }
    }
}
