using System;
using System.ServiceModel;
namespace MagicEightBallServiceLib {
    [ServiceContract(Namespace = "http://MyCompany.com")]
    public interface IEightBall {
        [OperationContract]
        string ObtainAnswerToQuestion(string userQuestion);
    }
}
