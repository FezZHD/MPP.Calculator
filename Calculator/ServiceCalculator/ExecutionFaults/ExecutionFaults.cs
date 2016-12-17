using System.Runtime.Serialization;

namespace ServiceCalculator.ExecutionFaults
{
    [DataContract]
    public class ExecutionFaults
    {
        internal ExecutionFaults(string message)
        {
            Message = message;
        }

        [DataMember]
        public string Message { get; private set; }
    }
}