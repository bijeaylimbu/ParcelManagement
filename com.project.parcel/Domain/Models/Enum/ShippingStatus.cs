using System.Runtime.Serialization;

namespace com.project.parcel.Domain.Models.Enum;

public enum ShippingStatus
{  
    [EnumMember(Value = "PENDING")]
    PENDING=0,
    [EnumMember(Value = "PROCESSING")]
    PROCESSING=1,
    [EnumMember(Value = "REJECTED")]
    REJECTED=2,
    [EnumMember(Value = "COMPLETED")]
    COMPLETED=4
}