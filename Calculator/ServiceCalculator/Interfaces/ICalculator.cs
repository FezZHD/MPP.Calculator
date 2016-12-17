using System.ServiceModel;

namespace ServiceCalculator.Interfaces
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(ExecutionFaults.ExecutionFaults))]
        double Add(double a, double b);

        [OperationContract]
        [FaultContract(typeof(ExecutionFaults.ExecutionFaults))]
        double Substract(double a, double b);

        [OperationContract]
        [FaultContract(typeof(ExecutionFaults.ExecutionFaults))]
        double Multiply(double a, double b);

        [OperationContract]
        [FaultContract(typeof(ExecutionFaults.ExecutionFaults))]
        double Divide(double a, double b);

        [OperationContract]
        [FaultContract(typeof(ExecutionFaults.ExecutionFaults))]
        double Sqrt(double a);
    }
}
