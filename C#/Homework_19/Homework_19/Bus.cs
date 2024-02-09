using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_19
{
    class Bus : Car
    {
        public event EventHandler Finish;

        public Bus()
        {
            Speed = 5; 
        }

        public override void Move()
        {
         
            Speed += new Random().Next(-2, 6);
            Speed = Speed < 0 ? 0 : Speed; 
            if (Speed >= 100)
            {
                Finish?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
