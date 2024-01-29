using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    public interface IRemoveableDisk : IDisk
    {
        bool HasDisk { get; }
    }

}
