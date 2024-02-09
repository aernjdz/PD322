using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_19
{
    class Sedan : Car
    {
        public event EventHandler Finish;

        public Sedan()
        {
            Speed = 7; 
        }

        public override void Move()
        {
        
            Speed += new Random().Next(-3, 8);
            Speed = Speed < 0 ? 0 : Speed; 
            if (Speed >= 100)
            {
                Finish?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
