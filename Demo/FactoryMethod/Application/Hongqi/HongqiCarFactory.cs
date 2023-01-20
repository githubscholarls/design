using CreateDesignDemo.FactoryMethod.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CreateDesignDemo.FactoryMethod.Application.Hongqi
{
    public class HongqiCarFactory : AbstractCarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new HongqiCar();
        }
    }
}
