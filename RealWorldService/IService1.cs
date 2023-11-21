using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Fonlow.Demo.RealWorldService
{
    [ServiceContract(Namespace = "http://www.fonllow.com/demo/RealWorldService/2012/08")]
    public interface IService1
    {
        [OperationContract]
        [FaultContract(typeof(Evil666Error))]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }

    [DataContract(Namespace = "http://www.fonllow.com/demo/RealWorldService/Data/2012/08")]
    public class CompositeType
    {

        [DataMember]
        public bool BoolValue
        {
            get;
            set;
        }

        [DataMember]
        public string StringValue
        {
            get;
            set;
        }
    }

    [DataContract(Namespace = "http://www.fonllow.com/demo/RealWorldService/Data/2012/08")]
    public class Evil666Error 
    {
        [DataMember]
        public string Message { get; set; }
    }
}
