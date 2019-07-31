using System;
using System.ServiceModel;
namespace MathServiceLibrary {
    // contract for WPF Service
    // known as Service Contract

    // The ServiceContractAttribute type supports many properties that further qualify its intended purpose. You can set two 
    // properties, Name and Namespace, to control the name of the service type and the name of the XML namespace that defines the
    // service type

    [ServiceContract(Name="MyMathService", Namespace="www.iamchirag.com")]
    public interface IMyMathContract {
        [OperationContract]
        int Sum(int x, int y);
    }
}
