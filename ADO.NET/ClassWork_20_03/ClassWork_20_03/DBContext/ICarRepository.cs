using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassWork_20_03.Model;

namespace ClassWork_20_03.DBContext
{
    internal interface ICarRepository
    {
        Car Create(Car car);
        void Delete(int id);
        Car GetCar(int id);
        List<Car> GetCars();
        void Update(Car car);

    }
}
