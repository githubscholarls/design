using CreateDesignDemo.FactoryMethod.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CreateDesignDemo.FactoryMethod.Application.Hongqi
{

    public class HongqiCar : AbstractCar
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void Startup()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }

        public override void Turn(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
