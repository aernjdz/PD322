using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_19
{
    abstract class Car
    {
        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set { _speed = value < 0 ? 0 : value; } 
        }

        public abstract void Move();
    }
}
