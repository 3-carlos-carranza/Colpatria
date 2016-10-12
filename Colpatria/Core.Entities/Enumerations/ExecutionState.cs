using System;

namespace Core.Entities.Enumerations
{
    public enum ExecutionState
    {
        Processing = 1,
        Returned = 2,
        PendingProcessing = 3,
        Rejected = 4,
        Expired = 5,
        Closed = 6,
        Approved = 7,
        Requesting = 8,
        Failed = 9,
        PaidOut = 10,
        NotInterested = 11,
        NoAgreement = 12
    }
}