using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_17_04
{
    public class MessageInfo
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public MessageInfo(string msg)
        {
            Message = msg;
            Time = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Message,-20} {Time}";
        }
    }
}
