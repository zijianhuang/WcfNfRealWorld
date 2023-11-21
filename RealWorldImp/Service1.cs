using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Fonlow.Demo.RealWorldService
{
    public class Service1 : IService1 
    {
        public string GetData(int value)
        {
            if (value == 666)
                throw new FaultException<Evil666Error>(new Evil666Error() { Message = "Hey, this is 666." });

            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }

            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
