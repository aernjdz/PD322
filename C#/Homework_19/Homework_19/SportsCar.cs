using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_19
{
    class SportsCar : Car
    {
        public event EventHandler Finish;

        public SportsCar()
        {
            Speed = 10; 
        }

        public override void Move()
        {
            Speed += new Random().Next(-5, 10);
            Speed = Speed < 0 ? 0 : Speed;
            if (Speed >= 100)
            {
                Finish?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
