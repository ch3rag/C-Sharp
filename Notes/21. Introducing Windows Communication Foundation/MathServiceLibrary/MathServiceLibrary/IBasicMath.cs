using System;
using System.ServiceModel;

namespace MathServiceLibrary {
    [ServiceContract(Namespace="www.iamchirag.now.sh")]
    public interface IBasicMath {
        [OperationContract]
        int Add(int x, int y);
    }
}
