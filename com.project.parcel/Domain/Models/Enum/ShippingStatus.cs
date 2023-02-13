using System.Runtime.Serialization;

namespace com.project.parcel.Domain.Models.Enum;

public enum ShippingStatus
{  
    [EnumMember(Value = "COLLECTED")]
    COLLECTED=0,
    [EnumMember(Value = "PENDING")]
    PENDING=1,
    [EnumMember(Value = "PROCESSING")]
    PROCESSING=2,
    [EnumMember(Value = "REJECTED")]
    REJECTED=3,
    [EnumMember(Value = "COMPLETED")]
    COMPLETED=4
}