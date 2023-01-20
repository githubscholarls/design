using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CreateDesignDemo.FactoryMethod.Infrastructure
{
    public abstract class AbstractCarFactory
    {
        public abstract AbstractCar CreateCar();
    }
}
