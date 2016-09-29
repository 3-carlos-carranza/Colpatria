using Crosscutting.Common.Tools.DataType;

namespace Core.DataTransferObject.WebServiceConsultation
{
    public enum ServiceNameType
    {
        [StringValue("Evidente Answer")]
        Answer = 1,
        [StringValue("Evidente Get Questions")]
        Questions = 2,
        [StringValue("Evidente Validate User")]
        Validate = 3,
        [StringValue("Ws Motor Validate User")]
        WsMotorValidate = 4
    }
}
